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

namespace pgso
{
    public partial class frm_Billing : Form
    {
        
        private Repo_Billing repo_billing = new Repo_Billing();

        // Global list to hold all billing records
        private List<Billing_Model> all_billing_model = new List<Billing_Model>();

        // Binding source for DataGridView
        private BindingSource dgv_billing_binding_source = new BindingSource();

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

        private List<Billing_Model> groupedBillingData; // Store grouped data globally


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

                // ✅ Group reservations by control number and merge equipment names
                groupedBillingData = all_billing_model
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
                        var billingRecord = group.First(); // Keep only the first record per control number

                        // Merge equipment names
                        billingRecord.EquipmentNames = group
                            .Select(x => x.fld_Equipment_Name)
                            .Where(name => !string.IsNullOrEmpty(name))
                            .Distinct()
                            .ToList();

                        return billingRecord;
                    })
                    .ToList();

                // ✅ Ensure "Reservation Name" column exists
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

                // ✅ Ensure the print button column icon is set
                if (dgv_Billing_Records.Columns["col_Print"] is DataGridViewImageColumn imgCol)
                {
                    imgCol.Image = ResizeImage(ByteArrayToImage(Properties.Resources.Printer_Icon), 24, 24);
                }

                // ✅ Disable auto-generation of columns
                dgv_Billing_Records.AutoGenerateColumns = false;

                // ✅ Bind the corrected data source
                dgv_billing_binding_source.DataSource = groupedBillingData;
                dgv_Billing_Records.DataSource = dgv_billing_binding_source;

                // ✅ Adjust column display order
                dgv_Billing_Records.Columns["col_Reservation_Name"].DisplayIndex = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load billing records: " + ex.Message);
            }
        }

        // 🔍 Fixed Search Method
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
        }



        private Billing_Model GetBillingDetailsByReservationID(int reservationID)
        {
            // Assuming repo_billing has a method like GetBillingDetailsByReservationID
            // If it's not there, you can implement it in the Repo_Billing class.
            return repo_billing.GetBillingDetailsByReservationID(reservationID);
        }

        private void dgv_Billing_Records_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is not on the header row
            if (e.RowIndex < 0) return; // Ignore header clicks
            Console.WriteLine($"Clicked Column: {dgv_Billing_Records.Columns[e.ColumnIndex].Name}, Row: {e.RowIndex}");

            // Get the selected row's reservation ID
            int reservationID = Convert.ToInt32(dgv_Billing_Records.Rows[e.RowIndex].Cells["pk_ReservationID"].Value);

            // Check if reservationID is valid (greater than 0)
            if (reservationID > 0)
            {
                // Get billing details by reservation ID
                var billingDetails = GetBillingDetailsByReservationID(reservationID);

                // If billing details are found, display them in the panel
                if (billingDetails != null)
                {
                    DisplayBillingDetailsInPanel(billingDetails);
                }
                else
                {
                    MessageBox.Show("No billing details found for this reservation.");
                }
            }
            else
            {
                // Optional: Handle invalid Reservation ID here
                MessageBox.Show("Invalid Reservation ID.");
            }

            // Additional logic for specific columns (e.g., Print column)
            if (dgv_Billing_Records.Columns[e.ColumnIndex].Name == "col_Print")
            {
                // Open frm_Print_Billing and pass reservation ID
                frm_Print_Billing printBillingForm = new frm_Print_Billing(reservationID);
                printBillingForm.ShowDialog();
            }
        }
        private void DisplayBillingDetailsInPanel(Billing_Model billingDetails)
        {
            pnl_Billing_Details.Visible = true;
            // Example: Populate controls on the panel to show the billing details

            // Assuming you have Labels like lbl_ControlNumber, lbl_ActivityName, etc., in the panel
            lbl_Control_Number.Text = billingDetails.fld_Control_Number;
          
        }



        private void btn_Reports_Click(object sender, EventArgs e)
        {
            frm_Report_Billing_Main reportBillingForm = new frm_Report_Billing_Main();
            reportBillingForm.ShowDialog(); // Opens the form as a modal dialog

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}