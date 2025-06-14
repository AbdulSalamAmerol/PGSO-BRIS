﻿using pgso.Billing.Repositories;
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
            this.StartPosition = FormStartPosition.CenterScreen;
            // Adjust as needed, this gives ~99px margin around
            pb_Logo.Size = new Size(500, 500);
            pb_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Logo.BackColor = Color.Transparent;

            // Center it inside the panel
            pb_Logo.Location = new Point(
                (pnl_Billing_Details.Width - pb_Logo.Width) / 2,
                (pnl_Billing_Details.Height - pb_Logo.Height) / 2
            );

            // Optional: Make sure it's the top-most control in the panel
            pb_Logo.BringToFront();

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
            this.MinimumSize = new Size(1920, 1200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;

            dgv_Billing_Records.Columns["col_Amount_Due"].DefaultCellStyle.Format = "C2";
            dgv_Billing_Records.Columns["col_Amount_Due"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-PH");
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
              
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load billing records: " + ex.Message);
            }

            ////FILTERING
            cmb_Billing_Filter.Items.Clear();
            cmb_Billing_Filter.Items.AddRange(new string[] { "All", "Pending", "Confirmed", "Cancelled" });
            cmb_Billing_Filter.SelectedIndexChanged += cmb_Billing_Filter_SelectedIndexChanged;
            cmb_Billing_Filter.SelectedIndex = 1; // Default to "Pending"
            
            //SORTING
            cmb_Billing_Sort.Items.Clear();
            cmb_Billing_Sort.Items.AddRange(new string[] { "Control Number", "Reservation Date", "Requesting Person", "Reservation Type", "Reservation Status", "Amount Due" });
            cmb_Billing_Sort.SelectedIndex = 0; // Default selection
            cmb_Billing_Sort.SelectedIndexChanged += cmb_Billing_Sort_SelectedIndexChanged;
            ApplySearchFilter(""); // ✅ This will apply default filter + sort on load
        }

        private void cmb_Billing_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySearchFilter(sb_Billing_Search_Bar.Text.Trim().ToLower());
        }

        private void cmb_Billing_Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySearchFilter(sb_Billing_Search_Bar.Text.Trim().ToLower());
        }

        private void ApplySearchFilter(string searchTerm)
        {
            IEnumerable<Model_Billing> filtered = groupedBillingData;

            if (groupedBillingData == null)
                return;

            // Apply filter
            string filterValue = cmb_Billing_Filter.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(filterValue) && filterValue != "All")
            {
                filtered = filtered.Where(b => b.fld_Reservation_Status.Equals(filterValue, StringComparison.OrdinalIgnoreCase));
            }

            // Apply search
            if (!string.IsNullOrEmpty(searchTerm))
            {
                filtered = filtered.Where(item =>
                    (item.fld_Control_Number?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Full_Name?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Venue_Name?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Reservation_Type?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Reservation_Status?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.EquipmentNames.Any(equipment => equipment.ToLower().Contains(searchTerm)))
                );
            }

            // Apply sort
            string sortBy = cmb_Billing_Sort.SelectedItem?.ToString();
            switch (sortBy)
            {
                case "Control Number":
                    filtered = filtered.OrderByDescending(b => b.pk_ReservationID);
                    break;
                case "Reservation Date":
                    filtered = filtered.OrderByDescending(b => b.fld_Start_Date);
                    break;
                case "Requesting Person":
                    filtered = filtered.OrderByDescending(b => b.fld_Full_Name);
                    break;
                case "Reservation Type":
                    filtered = filtered.OrderByDescending(b => b.fld_Reservation_Type);
                    break;
                case "Reservation Status":
                    filtered = filtered.OrderByDescending(b => b.fld_Reservation_Status);
                    break;
                case "Amount Due":
                    filtered = filtered.OrderByDescending(b => b.fld_Total_Amount);
                    break;
            }

            dgv_billing_binding_source.DataSource = filtered.ToList();
            dgv_Billing_Records.DataSource = dgv_billing_binding_source;
        }

        //Search Bar
        private void sb_Billing_Search_Bar_TextChanged(object sender, EventArgs e)
        {
            ApplySearchFilter(sb_Billing_Search_Bar.Text.Trim().ToLower());
        }


        // Block all resizes
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int WM_NCLBUTTONDBLCLK = 0xA3; // <- THIS blocks double-click resize
            const int HTCAPTION = 0x2;

            if ((m.Msg == WM_NCLBUTTONDOWN || m.Msg == WM_NCLBUTTONDBLCLK) && m.WParam.ToInt32() == HTCAPTION)
                return; // ignore both drag and double-click maximize

            base.WndProc(ref m);
        }

       

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

   
        private void LoadVenueBillingControl(Model_Billing billingDetails)
        {
            pnl_Billing_Details.Controls.Clear(); // Or wherever you load the control

            Venue_User_Control venueControl = new Venue_User_Control(billingDetails, repo_billing);

            // ⛓️ Subscribe to refresh event
            venueControl.RequestBillingRefresh += (updatedReservationID) =>
            {
                RefreshBillingRecords(updatedReservationID);
            };

            pnl_Billing_Details.Controls.Add(venueControl); // Add it to your container
        }

        // Datagrid Cell Content Click
        private async void dgv_Billing_Records_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            // Check if the clicked cell is not a header row
            if (e.RowIndex >= 0)
            {
                // You can use e.RowIndex and e.ColumnIndex to get the clicked cell's data
                var clickedCellValue = dgv_Billing_Records[e.ColumnIndex, e.RowIndex].Value;
            }

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
                    var venueControl = new Venue_User_Control(billing, repo_billing);
                    venueControl.Dock = DockStyle.Fill;
                    venueControl.LoadBillingDetails(billing);
                    venueControl.OnRequestVenueExtension += (reservationID, status) =>
                    {
                        OpenExtendVenueForm(reservationID); // Your existing logic
                    };
                    billingControl = venueControl;
                    venueControl.RequestBillingRefresh += RefreshBillingRecords;
                    pnl_Billing_Details.Controls.Clear();
                    pnl_Billing_Details.Controls.Add(venueControl);
                   
                    break;

                case "Equipment":
                    var equipmentControl = new Equipment_User_Control(billing, repo_billing);
                    equipmentControl.Dock = DockStyle.Fill;
                    equipmentControl.LoadBillingDetails(billing);
                    // ✅ Subscribe to the event when the Equipment User Control is loaded
                    equipmentControl.EquipmentBillingUpdated += (s, e) =>
                    {
                        // When the equipment billing is updated, refresh the billing records
                        RefreshBillingRecords(highlightReservationID: reservationID);
                    };
                    billingControl = equipmentControl;
                    equipmentControl.RequestBillingRefresh += RefreshBillingRecords;
                    pnl_Billing_Details.Controls.Clear();
                    pnl_Billing_Details.Controls.Add(equipmentControl);

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
                    /* Removed Feature
                case "col_Approved":
                    await HandleApprovalAsync(reservationID, currentStatus);
                    break;

                case "col_Cancel":
                    await HandleCancellationAsync(reservationID, currentStatus);
                    break;

                case "col_Extend":
                    HandleExtension(reservationID, e.RowIndex);
                    break;
                    */
            }
        }

        // Datagridview Color Format
        private void dgv_Billing_Records_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if it's a data row (ignore header and new row placeholder)
            if (e.RowIndex >= 0 && e.RowIndex < dgv_Billing_Records.Rows.Count && !dgv_Billing_Records.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgv_Billing_Records.Rows[e.RowIndex];
                string statusColumnName = "col_Reservation_Status";

                try
                {
                    object cellValue = row.Cells[statusColumnName].Value;
                    var billing = row.DataBoundItem as Model_Billing;

                    if (billing != null && billing.fld_Created_At != null)
                    {
                        TimeSpan timeSinceCreated = DateTime.Now - billing.fld_Created_At;

                        if (cellValue?.ToString() == "Pending" && timeSinceCreated.TotalHours >= 72)
                        {
                            // 🔥 Expired pending reservation (3+ days old)
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 228, 225); // RED
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            // Handle regular color coding
                            if (cellValue?.ToString() == "Cancelled")
                                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 220, 255); // BLUE

                            else if (cellValue?.ToString() == "Confirmed")
                                row.DefaultCellStyle.BackColor = Color.FromArgb(225, 255, 225); // GREEN
                               
                            else if (cellValue?.ToString() == "Pending")
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // WHITE
                                row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during cell formatting: {ex.Message}");
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                // Alignment logic
                string columnName = dgv_Billing_Records.Columns[e.ColumnIndex].Name;
                if (columnName == "fld_Control_Number" || columnName == "col_Print" || columnName == "fld_Full_Name")
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                else
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

            using (frm_OR orForm = new frm_OR(reservationID, repo_billing)) 
            {

                DialogResult result = orForm.ShowDialog(this); // 'this' sets the owner window (frm_Billing)

                // --- Step 3: Check if the user confirmed AND the OR update was successful in frm_OR ---
                if (result == DialogResult.OK)
                {
                    // --- User clicked btn_OR_Confirm in frm_OR, AND ---
                    // --- the OR number was successfully updated in the database within frm_OR ---

                    // Optional: You can now access data from the form if you added properties
                    string officialReceiptNumber = orForm.EnteredORNumber; // Get the OR# confirmed in frm_OR
                                                                           // Console.WriteLine($"frm_OR confirmed with OR#: {officialReceiptNumber}"); // For debugging

                    // --- Step 4: Proceed with updating the reservation STATUS and refreshing UI ---
                    bool statusUpdateSuccess = await UpdateReservationStatusAsync(reservationID, "Confirmed");
                    ShowStatusMessage(statusUpdateSuccess, "Confirmed"); // Show status update message

                    if (statusUpdateSuccess)
                    {
                        // Use the retrieved OR number in the success message
                        MessageBox.Show($"Reservation approved successfully with OR# {officialReceiptNumber}. Refreshing billing records...",
                                        "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshBillingRecords(reservationID); // Refresh local billing data if needed

                        Model_Billing updatedDetails = repo_billing.GetBillingDetailsByReservationID(reservationID); // Fetch updated details

                        if (updatedDetails != null)
                        {
                            // Load correct UserControl dynamically
                            pnl_Billing_Details.Controls.Clear();
                            UserControl billingControl = null;

                            switch (updatedDetails.fld_Reservation_Type)
                            {
                                case "Venue":
                                    var venueControl = new Venue_User_Control(updatedDetails, repo_billing);
                                    venueControl.Dock = DockStyle.Fill;
                                    venueControl.LoadBillingDetails(updatedDetails);
                                    billingControl = venueControl;
                                    break;

                                case "Equipment":
                                    var equipmentControl = new Equipment_User_Control(updatedDetails, repo_billing);
                                    equipmentControl.Dock = DockStyle.Fill;
                                    equipmentControl.LoadBillingDetails(updatedDetails);
                                    billingControl = equipmentControl;
                                    break;

                                default:
                                    MessageBox.Show("Unsupported reservation type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                            }

                            if (billingControl != null)
                            {
                                pnl_Billing_Details.Controls.Add(billingControl);
                                pnl_Billing_Details.Visible = true;
                            }
                            else
                            {
                                pnl_Billing_Details.Visible = false; // Hide panel if no control could be loaded
                            }
                        }
                        else
                        {
                            pnl_Billing_Details.Visible = false; // Hide panel if details are null after refresh
                            MessageBox.Show("Could not retrieve updated billing details after approval.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    // else: ShowStatusMessage already handled the status update failure message.
                }
                else // result != DialogResult.OK
                {
                    // --- User closed frm_OR without confirming (e.g., clicked Cancel, 'X', or DB update failed inside frm_OR) ---
                    MessageBox.Show("Approval process cancelled or OR Number entry failed.", "Approval Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Do not proceed with UpdateReservationStatusAsync etc.
                }
            } // The 'using' statement ensures orForm.Dispose() is called here
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
                        MessageBox.Show("Reservation cancelled and deduction applied. WHAT THE FUCK");
                    else
                        MessageBox.Show("Cancellation applied, but deduction failed. WHAT THE FUCK", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ShowStatusMessage(success, "cancelled");
            }
        }

        private async Task<bool> UpdateReservationStatusAsync(int reservationID, string newStatus)
        {
            try
            {
                return await Task.Run(() => repo_billing.UpdateReservationStatusAsync(reservationID, newStatus));
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
                controlToDisplay = new Venue_User_Control(details, repo_billing);
            }
            else if (details.fld_Reservation_Type == "Equipment")
            {
                controlToDisplay = new Equipment_User_Control(details, repo_billing);
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
                all_billing_model = repo_billing.GetAllBillingRecords() ?? new List<Model_Billing>();

                if (all_billing_model.Count == 0)
                {
                    dgv_Billing_Records.DataSource = null;
                    MessageBox.Show("No billing records found.");
                    return;
                }

                // ✅ Update grouped data
                groupedBillingData = GroupAndFormatBillingData(all_billing_model);

                // ✅ Re-apply filter, search, and sort
                ApplySearchFilter(sb_Billing_Search_Bar.Text.Trim().ToLower());

                // ✅ Highlight row if needed
                if (highlightReservationID.HasValue)
                {
                    bool rowFound = false;
                    foreach (DataGridViewRow row in dgv_Billing_Records.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["pk_ReservationID"].Value) == highlightReservationID.Value)
                        {
                            row.Selected = true;

                            dgv_Billing_Records.CurrentCell = row.Cells
                                .Cast<DataGridViewCell>()
                                .FirstOrDefault(c => c.Visible);

                            rowFound = true;
                            break;
                        }
                    }

                    if (rowFound)
                    {
                        var selectedRow = dgv_Billing_Records.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => r.Selected);

                        if (selectedRow != null)
                        {
                            dgv_Billing_Records.FirstDisplayedScrollingRowIndex = selectedRow.Index;
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
                        item.fld_Reservation_Status,
                        item.fld_Created_At
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
                        HeaderText = "RESERVATION",
                        DataPropertyName = "DisplayReservationName",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
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
                Image rawImage = ByteArrayToImage(Properties.Resources.Printer_Icon);
                Image resized = ResizeImage(rawImage, 20, 20); // smaller icon
                Image padded = AddMarginToImage(resized, 30, 30); // add transparent padding
                imgCol.Image = padded;
            }
            /*  REMOVED FEATURE
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
            */
        }
        //Margin for Icons Formatting
        private Image AddMarginToImage(Image original, int totalWidth, int totalHeight)
        {
            Bitmap bmp = new Bitmap(totalWidth, totalHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent); // or set to match DataGridView background
                int x = (totalWidth - original.Width) / 2;
                int y = (totalHeight - original.Height) / 2;
                g.DrawImage(original, x, y, original.Width, original.Height);
            }
            return bmp;
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

        public void OpenExtendVenueForm(int reservationID)
        {
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
                            var venueControl = new Venue_User_Control(updatedDetails, repo_billing); // Pass updated details to the constructor
                            venueControl.Dock = DockStyle.Fill;
                            billingControl = venueControl;
                            break;

                        case "Equipment":
                            var equipmentControl = new Equipment_User_Control(updatedDetails, repo_billing); // Pass updated details to the constructor
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

        private void btn_Create_Venue_Reservation_Click(object sender, EventArgs e)
        {
            frm_Create_Venuer_Reservation Venue = new frm_Create_Venuer_Reservation();
            Venue.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Create_Equipment_Reservation Equipment = new frm_Create_Equipment_Reservation();
            Equipment.ShowDialog();
        }

        private void cmb_Billing_Filter_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}