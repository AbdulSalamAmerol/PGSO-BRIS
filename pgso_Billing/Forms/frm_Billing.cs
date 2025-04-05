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

namespace pgso
{
    public partial class frm_Billing : Form
    {
        private Dictionary<int, Billing_Model> billingDetailsCache = new Dictionary<int, Billing_Model>(); //for cache
        private List<Billing_Model> groupedBillingData; // Store grouped data globally
        private Repo_Billing repo_billing = new Repo_Billing();
        private List<Billing_Model> all_billing_model = new List<Billing_Model>(); // Global list to hold all billing records
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
                // Get all billing records
                all_billing_model = repo_billing.GetAllBillingRecords() ?? new List<Billing_Model>();

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
                    (item.fld_Payment_Status?.ToLower().Contains(searchTerm) ?? false) ||
                    item.EquipmentNames.Any(equipment => equipment.ToLower().Contains(searchTerm))
                ).ToList();

                dgv_billing_binding_source.DataSource = filteredData;
            }
        }// 🔍 Fixed Search Method

        private Billing_Model GetBillingDetailsByReservationID(int reservationID)
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

            // Get selected column name
            string columnName = dgv_Billing_Records.Columns[e.ColumnIndex].Name;

            // Get Reservation ID from selected row
            int reservationID = Convert.ToInt32(dgv_Billing_Records.Rows[e.RowIndex].Cells["pk_ReservationID"].Value);

            // Get Current Status
            string currentStatus = dgv_Billing_Records.Rows[e.RowIndex].Cells["col_Payment_Status"].Value.ToString();

            // Validate Reservation ID
            if (reservationID <= 0)
            {
                MessageBox.Show("Invalid Reservation ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await DisplayBillingDetails(reservationID);
            // ✅ Handle Different Column Clicks
            switch (columnName)
            {
                case "col_Print":
                    PrintBilling(reservationID);
                    break;

                case "col_Approved":
                    await HandleApprovalAsync(reservationID, currentStatus);
                    break;

                case "col_Cancel":
                    await HandleCancellationAsync(reservationID, currentStatus);
                    break;
                
              
            }
        }

        private void PrintBilling(int reservationID) // Print Collection Slip
        {
            frm_Print_Billing printBillingForm = new frm_Print_Billing(reservationID);
            printBillingForm.ShowDialog();
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
            }
        }

        private async Task HandleCancellationAsync(int reservationID, string currentStatus)
        {
            if (currentStatus != "Pending" && currentStatus != "Confirmed")
            {
                MessageBox.Show("Only 'Pending' or 'Confirmed' reservations can be cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to cancel this reservation?",
                                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool success = await UpdateReservationStatusAsync(reservationID, "Cancelled");
                if (success)
                {
                    // Apply 95% deduction logic here
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

        




        private async Task DisplayBillingDetails(int reservationID)
        {
            try
            {
                // Fetch billing details asynchronously
                var billingDetails = await Task.Run(() => repo_billing.GetBillingDetailsByReservationID(reservationID));

                if (billingDetails != null)
                {
                    // Update the UI on the main thread
                    Invoke(new Action(() => DisplayBillingDetailsInPanel(billingDetails)));
                }
                else
                {
                    MessageBox.Show("No billing details found for this reservation.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching billing details: {ex.Message}");
            }
        }
        //Details Panel
        private void DisplayBillingDetailsInPanel(Billing_Model billingDetails)
        {
            pnl_Billing_Details.Visible = true;

            // Populate the labels with values from the billingDetails model

            lbl_Control_Number.Text = billingDetails.fld_Control_Number;
            lbl_Activity_Name.Text = billingDetails.fld_Activity_Name;
            lbl_Requesting_Person.Text = $"{billingDetails.fld_First_Name} {billingDetails.fld_Middle_Name} {billingDetails.fld_Surname}";
            lbl_Requesting_Office.Text = billingDetails.fld_Requesting_Person_Address;
            lbl_Origin_Request.Text = billingDetails.fld_Request_Origin;
            lbl_Contact_Number.Text = billingDetails.fld_Contact_Number;
            lbl_Address.Text = billingDetails.fld_Requesting_Person_Address;

            // Format reservation dates (start and end)
            lbl_Reservation_Dates.Text = $"{billingDetails.fld_Start_Date.ToString("MM/dd/yyyy")} - {billingDetails.fld_End_Date.ToString("MM/dd/yyyy")}";

            // Format reservation times (start and end)
            lbl_Reservation_Time.Text = $"{billingDetails.fld_Start_Time.ToString(@"hh\:mm")} - {billingDetails.fld_End_Time.ToString(@"hh\:mm")}";

            lbl_Number_Of_Participants.Text = billingDetails.fld_Number_Of_Participants.ToString();
            lbl_Reservation_Status.Text = billingDetails.fld_Reservation_Status;

            // Venue details
            lbl_Venue_Name.Text = billingDetails.fld_Venue_Name;
            lbl_Venue_Scope.Text = billingDetails.fld_Venue_Scope_Name;
            lbl_Rate_Type.Text = billingDetails.fld_Rate_Type;

            // Venue pricing details (based on hourly charges, etc.)
            lbl_Base_Charge_Amount.Text = billingDetails.fld_First4Hrs_Rate.ToString("C");
            lbl_Additional_Hourly_Charge.Text = billingDetails.fld_Hourly_Rate.ToString("C");
            lbl_Additional_Charge.Text = billingDetails.fld_Additional_Charge.ToString("C");
            lbl_Total_Hour.Text = (billingDetails.Total_Hours - 4).ToString("F0");
            lbl_Additional_Hours_Amount.Text =  (billingDetails.fld_Hourly_Rate * (decimal)(billingDetails.Total_Hours - 4)).ToString("C");


            // If you are showing equipment details (if available)
            lbl_Venue_Name_Transact.Text = billingDetails.fld_Equipment_Name;
            lbl_Venue_Scope_Transact.Text = billingDetails.fld_Venue_Scope_Name;

            // Calculated charges based on overtime
            
            lbl_OT_Hours.Text = billingDetails.fld_OT_Hours.ToString();
            lbl_OT_Hourly_Charge.Text = billingDetails.fld_Hourly_Rate.ToString("C");
            lbl_OT_Hours_Amount.Text = (billingDetails.fld_OT_Hours * billingDetails.fld_Hourly_Rate).ToString("C");

            // Cancellation charge (if applicable)
            //    lbl_Cancel_Charge_Amount.Text = billingDetails.fld_Cancellation_Charge.ToString("C");

            // Payment details
            lbl_Paid_Amount.Text = billingDetails.fld_Amount_Paid.ToString("C");
            lbl_Total_Amount.Text = billingDetails.fld_Total_Amount.ToString("C");
            lbl_Balance.Text = (billingDetails.fld_Total_Amount - billingDetails.fld_Amount_Paid).ToString("C");
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            frm_Report_Billing_Main reportBillingForm = new frm_Report_Billing_Main();
            reportBillingForm.ShowDialog(); // Opens the form as a modal dialog

        }

        private void RefreshBillingRecords()
        {
            try
            {
                // Re-fetch all billing records
                all_billing_model = repo_billing.GetAllBillingRecords() ?? new List<Billing_Model>();

                if (all_billing_model.Count == 0)
                {
                    dgv_Billing_Records.DataSource = null;
                    MessageBox.Show("No billing records found.");
                    return;
                }

                // Group and format billing data, with UI updates handled inside GroupAndFormatBillingData
                groupedBillingData = GroupAndFormatBillingData(all_billing_model);

                // Refresh the DataGridView display
                dgv_Billing_Records.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to refresh billing records: " + ex.Message);
            }
        }


        private List<Billing_Model> GroupAndFormatBillingData(List<Billing_Model> billingData)
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
                        item.fld_Payment_Status
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

                // Disable auto-generated columns
                dgv_Billing_Records.AutoGenerateColumns = false;

                // Re-assign the data source
                dgv_billing_binding_source.DataSource = groupedData;
                dgv_Billing_Records.DataSource = dgv_billing_binding_source;

                // Refresh icon columns if needed
                SetIconColumns();

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
                return new List<Billing_Model>(); // Return empty list in case of error
            }
        }

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


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}