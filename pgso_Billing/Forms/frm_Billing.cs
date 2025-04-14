using pgso.Billing.Repositories;
using pgso.Billing.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;
using pgso.pgso_Billing.Forms;
using System.Drawing;
using pgso.Properties;
using System.IO;
using System.Threading.Tasks;
using pgso.pgso_Billing.User_Control;
using pgso.pgso_Billing;



namespace pgso
{
    public partial class frm_Billing : Form
    {
        private List<Model_Billing> all_billing_model = new List<Model_Billing>(); // Global list to hold all billing records
        private List<Model_Billing> groupedBillingData; // Store grouped data globally
        private Repo_Billing repo_billing = new Repo_Billing();
        private BindingSource dgv_billing_binding_source = new BindingSource();// Binding source for DataGridView

        public frm_Billing()
        {
            InitializeComponent();
        }

        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap resizedImg = new Bitmap(img, new Size(width, height));
            return resizedImg;
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void frm_Billing_Load(object sender, EventArgs e)
        {

            try
            {
                all_billing_model = repo_billing.GetAllBillingRecords() ?? new List<Model_Billing>(); // Get all billing records

                if (all_billing_model.Count == 0)
                {
                    dgv_Billing_Records.DataSource = null; // Clear DataGridView if no data
                    MessageBox.Show("No billing records found.");
                    return;
                }

                // Group and format the billing data using the GroupAndFormatBillingData method
                groupedBillingData = GroupAndFormatBillingData(all_billing_model);

                // Bind the grouped data to the DataGridView
                dgv_billing_binding_source.DataSource = groupedBillingData;
                dgv_Billing_Records.DataSource = dgv_billing_binding_source;
                SetIconColumns(); // Set icons for the columns
                // Adjust column display order (if needed)
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load billing records: " + ex.Message);
            }
        }

        private void sb_Billing_Search_Bar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = sb_Billing_Search_Bar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // ✅ Restore the grouped dataset (prevents missing equipment names)
                dgv_billing_binding_source.DataSource = groupedBillingData;
            }
            else
            {
                var filteredData = groupedBillingData.Where(item =>
                    (item.fld_Control_Number?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Full_Name?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Venue_Name?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Reservation_Type?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Reservation_Status?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.EquipmentNames.Any(equipment => equipment.ToLower().Contains(searchTerm)))
                ).ToList();

                dgv_billing_binding_source.DataSource = filteredData;
            }
        }// 🔍 Fixed Search Method

        private Dictionary<int, Model_Billing> billingDetailsCache = new Dictionary<int, Model_Billing>(); //for cache
        private Model_Billing GetBillingDetailsByReservationID(int reservationID)
        {
            if (billingDetailsCache.ContainsKey(reservationID))
            {
                return billingDetailsCache[reservationID];
            }

            // Fetch the billing details from the database/repository if not in cache
            var billingDetails = repo_billing.GetBillingDetailsByReservationID(reservationID);

            // Cache the result for future use
            if (billingDetails != null)
            {
                billingDetailsCache[reservationID] = billingDetails;
            }

            return billingDetails;
        }

        // Datagrid Cell Content Click
        private async void dgv_Billing_Records_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks

            string columnName = dgv_Billing_Records.Columns[e.ColumnIndex].Name;

            int reservationID = Convert.ToInt32(dgv_Billing_Records.Rows[e.RowIndex].Cells["pk_ReservationID"].Value);
            string currentStatus = dgv_Billing_Records.Rows[e.RowIndex].Cells["col_Reservation_Status"].Value.ToString();

            if (reservationID <= 0)
            {
                MessageBox.Show("Invalid Reservation ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Load billing details
            Model_Billing billing = repo_billing.GetBillingDetailsByReservationID(reservationID);

            if (billing == null)
            {
                MessageBox.Show("Billing details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Dynamically load correct UserControl
            pnl_Billing_Details.Controls.Clear(); // my panel to host the control
            UserControl billingControl = null;

            switch (billing.fld_Reservation_Type)
            {
                case "Venue":
                    var venueControl = new Venue_User_Control(billing);
                    venueControl.Dock = DockStyle.Fill;
                    venueControl.LoadBillingDetails(billing);
                    billingControl = venueControl;
                    break;

                case "Equipment":
                    var equipmentControl = new Equipment_User_Control(billing);
                    equipmentControl.Dock = DockStyle.Fill;
                    equipmentControl.LoadBillingDetails(billing);
                    // ✅ Subscribe to the event when the Equipment User Control is loaded
                    equipmentControl.EquipmentBillingUpdated += (s, e) =>
                    {
                        // When the equipment billing is updated, refresh the billing records
                        RefreshBillingRecords(highlightReservationID: reservationID);
                    };


                    billingControl = equipmentControl;
                    break;

                default:
                    MessageBox.Show("Unsupported reservation type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            if (billingControl != null)
            {
                pnl_Billing_Details.Controls.Add(billingControl);
                pnl_Billing_Details.Visible = true;
            }

            // ✅ Handle Specific Column Actions
            switch (columnName)
            {
                case "col_Print":
                    await PrintBilling(reservationID, currentStatus);
                    break;

                case "col_Approved":
                    await HandleApprovalAsync(reservationID, currentStatus);
                    break;

                case "col_Cancel":
                    await HandleCancellationAsync(reservationID, currentStatus);
                    break;

                case "col_Extend":
                    HandleExtension(reservationID, e.RowIndex);
                    break;
            }
        }


        private async Task PrintBilling(int reservationID, string currentStatus) // Print Collection Slip
        {
            // Check if the reservation status is "Pending"
            if (currentStatus != "Pending")
            {
                MessageBox.Show("Only 'Pending' reservations can be printed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If the status is "Pending", print the collection slip
            frm_Print_Billing printBillingForm = new frm_Print_Billing(reservationID);
            printBillingForm.ShowDialog();
        }



        private void HandleExtension(int reservationID, int rowIndex)
        {
            // Get reservation status from the selected row
            string reservationStatus = dgv_Billing_Records.Rows[rowIndex].Cells["col_Reservation_Status"].Value.ToString();

            // Check if the reservation status is not "Confirmed"
            if (reservationStatus == "Cancelled" || reservationStatus == "Pending")
            {
                MessageBox.Show("Only Confirmed reservations can be extended.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further processing if the status is "Cancelled" or "Pending"
            }

            // Get reservation type from the selected row
            string reservationType = dgv_Billing_Records.Rows[rowIndex].Cells["col_Reservation_Type"].Value.ToString();

            if (reservationType == "Venue")
            {
                // Open frm_Extend_Venue if reservation type is "Venue"
                OpenExtendVenueForm(reservationID);
            }
            else if (reservationType == "Equipment")
            {
                // Open frm_Extend_Equipment if reservation type is "Equipment"
                frm_Extend_Equipment extendEquipmentForm = new frm_Extend_Equipment(reservationID);
                extendEquipmentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Reservation type is not valid for extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task HandleApprovalAsync(int reservationID, string currentStatus)
        {
            if (currentStatus != "Pending")
            {
                MessageBox.Show("Only 'Pending' reservations can be approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to approve this reservation?",
                                "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool success = await UpdateReservationStatusAsync(reservationID, "Confirmed");
                ShowStatusMessage(success, "Confirmed");

                if (success)
                {
                    MessageBox.Show("Reservation approved successfully. Refreshing billing records...");

                    RefreshBillingRecords(reservationID);

                    Model_Billing updatedDetails = repo_billing.GetBillingDetailsByReservationID(reservationID);


                    if (updatedDetails != null)
                    {
                        // Load correct UserControl dynamically
                        pnl_Billing_Details.Controls.Clear();
                        UserControl billingControl = null;

                        switch (updatedDetails.fld_Reservation_Type)
                        {
                            case "Venue":
                                var venueControl = new Venue_User_Control(updatedDetails);
                                venueControl.Dock = DockStyle.Fill;
                                venueControl.LoadBillingDetails(updatedDetails);
                                billingControl = venueControl;
                                break;

                            case "Equipment":
                                var equipmentControl = new Equipment_User_Control(updatedDetails);
                                equipmentControl.Dock = DockStyle.Fill;
                                equipmentControl.LoadBillingDetails(updatedDetails);
                                billingControl = equipmentControl;
                                break;

                            default:
                                MessageBox.Show("Unsupported reservation type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }

                        if (billingControl != null)
                        {
                            pnl_Billing_Details.Controls.Add(billingControl);
                            pnl_Billing_Details.Visible = true;
                        }
                    }
                }
            }
        }



        private async Task HandleCancellationAsync(int reservationID, string currentStatus)
        {
            if (currentStatus != "Pending" && currentStatus != "Confirmed")
            {
                MessageBox.Show("Only 'Pending' or 'Confirmed' reservations can be cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔍 Get billing record for OT Hours check (synchronously, already implemented in repo)
            var billingRecords = repo_billing.GetBillingRecordsByReservationId(reservationID);
            if (billingRecords != null && billingRecords.Count > 0)
            {
                var otHours = billingRecords[0].fld_OT_Hours;
                if (otHours > 0)
                {
                    MessageBox.Show("This reservation has overtime hours. Cancellation is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (MessageBox.Show("Are you sure you want to cancel this reservation?",
                                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool success = await UpdateReservationStatusAsync(reservationID, "Cancelled");
                if (success)
                {
                    bool deductionSuccess = await Task.Run(() => repo_billing.ApplyCancellationDeduction(reservationID));
                    if (deductionSuccess)
                        MessageBox.Show("Reservation cancelled and deduction applied.");
                    else
                        MessageBox.Show("Cancellation applied, but deduction failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ShowStatusMessage(success, "cancelled");
            }
        }




        private async Task<bool> UpdateReservationStatusAsync(int reservationID, string newStatus)
        {
            try
            {
                return await Task.Run(() => repo_billing.UpdateReservationStatus(reservationID, newStatus));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating reservation: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ShowStatusMessage(bool success, string action)
        {
            if (success)
            {
                MessageBox.Show($"Reservation successfully {action}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshBillingRecords(); // Refresh UI after update
            }
            else
            {
                MessageBox.Show($"Failed to {action} the reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ShowBillingDetailsInPanel(Model_Billing details)
        {
            // Clear existing controls from the billing panel
            pnl_Billing_Details.Controls.Clear();

            UserControl controlToDisplay;

            if (details.fld_Reservation_Type == "Venue")
            {
                controlToDisplay = new Venue_User_Control(details);
            }
            else if (details.fld_Reservation_Type == "Equipment")
            {
                controlToDisplay = new Equipment_User_Control(details);
            }
            else
            {
                MessageBox.Show("Unknown reservation type. Cannot display billing details.");
                return;
            }

            // Set docking and add to the panel
            controlToDisplay.Dock = DockStyle.Fill;
            pnl_Billing_Details.Controls.Add(controlToDisplay);

            // Show the panel if it was hidden
            if (!pnl_Billing_Details.Visible)
                pnl_Billing_Details.Visible = true;
        }


        private void btn_Reports_Click(object sender, EventArgs e)
        {
            frm_Report_Billing_Main reportBillingForm = new frm_Report_Billing_Main();
            reportBillingForm.ShowDialog(); // Opens the form as a modal dialog

        }
        
        private void RefreshBillingRecords(int? highlightReservationID = null)
        {
            try
            {
                MessageBox.Show("Refreshing billing records...");

                all_billing_model = repo_billing.GetAllBillingRecords() ?? new List<Model_Billing>();

                if (all_billing_model.Count == 0)
                {
                    dgv_Billing_Records.DataSource = null;
                    MessageBox.Show("No billing records found.");
                    return;
                }

                // Group the data
                groupedBillingData = GroupAndFormatBillingData(all_billing_model);
                dgv_Billing_Records.DataSource = groupedBillingData;
                dgv_Billing_Records.Refresh();

                MessageBox.Show($"Refreshed data. Total records: {groupedBillingData.Count}");

                // Reselect the row if a reservation ID is passed
                if (highlightReservationID.HasValue)
                {
                    bool rowFound = false;
                    foreach (DataGridViewRow row in dgv_Billing_Records.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["pk_ReservationID"].Value) == highlightReservationID.Value)
                        {
                            row.Selected = true; // Select the entire row

                            // Set the CurrentCell to any visible cell (avoiding invisible cells)
                            dgv_Billing_Records.CurrentCell = row.Cells.Cast<DataGridViewCell>()
                                .FirstOrDefault(c => c.Visible); // Ensure we use a visible cell

                            rowFound = true;
                            break;
                        }
                    }

                    if (rowFound)
                    {
                        // Scroll to the selected row
                        var selectedRow = dgv_Billing_Records.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => r.Selected);

                        if (selectedRow != null)
                        {
                            dgv_Billing_Records.FirstDisplayedScrollingRowIndex = selectedRow.Index;
                            MessageBox.Show("Row selected and scrolled into view.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected row could not be found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to refresh billing records: " + ex.Message);
            }
        }

        // DGV Grouping and Formatting
        private List<Model_Billing> GroupAndFormatBillingData(List<Model_Billing> billingData)
        {
            try
            {
                var groupedData = billingData
                    .GroupBy(item => new
                    {
                        item.fld_Control_Number,
                        item.fld_Reservation_Type,
                        item.fld_Start_Date,
                        item.fld_Total_Amount,
                        item.fld_Reservation_Status
                    })
                    .Select(group =>
                    {
                        var billingRecord = group.First(); // Keep the first record per group

                        // Combine equipment names into a list
                        billingRecord.EquipmentNames = group
                            .Select(x => x.fld_Equipment_Name)
                            .Where(name => !string.IsNullOrEmpty(name))
                            .Distinct()
                            .ToList();

                        return billingRecord;
                    })
                    .ToList();

                dgv_Billing_Records.AutoGenerateColumns = false;// Disable auto-generated columns

                // Re-assign the data source
                dgv_billing_binding_source.DataSource = groupedData;
                dgv_Billing_Records.DataSource = dgv_billing_binding_source;

                SetIconColumns();// Refresh icon 

                // Adjust column order if needed
                if (!dgv_Billing_Records.Columns.Contains("col_Reservation_Name"))
                {
                    dgv_Billing_Records.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "col_Reservation_Name",
                        HeaderText = "Reservation",
                        DataPropertyName = "DisplayReservationName",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                    });
                }
                if (dgv_Billing_Records.Columns.Contains("col_Reservation_Name"))
                {
                    dgv_Billing_Records.Columns["col_Reservation_Name"].DisplayIndex = 2;
                }
                return groupedData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to group and format billing records: " + ex.Message);
                return new List<Model_Billing>(); // Return empty list in case of error
            }
        }


        // Icons Formatting For DGV (print/cancel/approve/extend)
        private void SetIconColumns()
        {
            if (dgv_Billing_Records.Columns["col_Print"] is DataGridViewImageColumn imgCol)
            {
                imgCol.Image = ResizeImage(ByteArrayToImage(Properties.Resources.Printer_Icon), 24, 24);
            }

            if (dgv_Billing_Records.Columns["col_Cancel"] is DataGridViewImageColumn imgCol_Cancel)
            {
                imgCol_Cancel.Image = ResizeImage(Properties.Resources.Cancelled_Icon, 24, 24);
            }

            if (dgv_Billing_Records.Columns["col_Approved"] is DataGridViewImageColumn imgCol_Approved)
            {
                imgCol_Approved.Image = ResizeImage(Properties.Resources.Approved_Icon, 24, 24);
            }

            if (dgv_Billing_Records.Columns["col_Extend"] is DataGridViewImageColumn imgCol_Extend)
            {
                imgCol_Extend.Image = ResizeImage(Properties.Resources.Extend_Icon, 24, 24);
            }
        }


        private void btn_Extend_Venue_Click(object sender, EventArgs e)
        {
            if (dgv_Billing_Records.CurrentRow != null)
            {
                int reservationID = Convert.ToInt32(dgv_Billing_Records.CurrentRow.Cells["pk_ReservationID"].Value);
                MessageBox.Show($"Opening Extend Venue Form for Reservation ID: {reservationID}");
                OpenExtendVenueForm(reservationID);
            }
            else
            {
                MessageBox.Show("Please select a reservation first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void OpenExtendVenueForm(int reservationID)
        {
            MessageBox.Show("Opening Extend Venue Form...");
            frm_Extend_Venue extendForm = new frm_Extend_Venue(reservationID);

            // Subscribe to the event BEFORE showing the form
            extendForm.OnExtensionSuccessful += () =>
            {
                MessageBox.Show("Event triggered: Reservation extended. Refreshing billing records...");

                // Re-fetch and refresh the data with the row selected
                // RefreshBillingRecords(reservationID); // This will refresh the grid and reselect the row

                // Ensure we get the updated details of the reservation after it is extended
                Model_Billing updatedDetails = all_billing_model.FirstOrDefault(r => r.pk_ReservationID == reservationID);
                if (updatedDetails != null)
                {
                    MessageBox.Show("Updated billing details found, updating the panel...");

                    // Dynamically load the correct UserControl based on the reservation type
                    UserControl billingControl = null;
                    switch (updatedDetails.fld_Reservation_Type)
                    {
                        case "Venue":
                            var venueControl = new Venue_User_Control(updatedDetails); // Pass updated details to the constructor
                            venueControl.Dock = DockStyle.Fill;
                            billingControl = venueControl;
                            break;

                        case "Equipment":
                            var equipmentControl = new Equipment_User_Control(updatedDetails); // Pass updated details to the constructor
                            equipmentControl.Dock = DockStyle.Fill;
                            billingControl = equipmentControl;
                            break;

                        default:
                            MessageBox.Show("Unsupported reservation type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                    }

                    if (billingControl != null)
                    {
                        pnl_Billing_Details.Controls.Clear(); // Clear existing controls
                        pnl_Billing_Details.Controls.Add(billingControl); // Add the new control
                        pnl_Billing_Details.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Updated billing details not found for the reservation.");
                }
            };

            extendForm.ShowDialog();

            // After the dialog closes, you can refresh the data again in case the event wasn't triggered
            RefreshBillingRecords(reservationID);
        }


        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}