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

        private void frm_Billing_Load(object sender, EventArgs e)
        {
            try
            {
                // Get all billing records
                all_billing_model = repo_billing.GetAllBillingRecords() ?? new List<Billing_Model>();

                // Show the count of retrieved records
                Console.WriteLine($"Billing Records Count: {all_billing_model.Count}");

                if (all_billing_model.Count == 0)
                {
                    MessageBox.Show("No billing records found.");
                    return;
                }

                // ✅ Group reservations by control number and merge equipment names
                var groupedData = all_billing_model
                    .GroupBy(item => new
                    {
                        item.fld_Control_Number,
                        item.fld_Reservation_Type,
                        item.fld_Start_Date,
                        item.fld_Amount_Due,
                        item.fld_Payment_Status
                    })
                    .Select(group =>
                    {
                        var billingRecord = group.First(); // Get the first item in the group

                        // Set EquipmentNames property correctly
                        billingRecord.EquipmentNames = group
                            .Select(x => x.fld_Equipment_Name)
                            .Where(name => !string.IsNullOrEmpty(name))
                            .ToList();

                        // Don't try to assign to DisplayReservationName; it computes its value automatically
                        // DisplayReservationName will automatically show the correct value based on the reservation type

                        return billingRecord;
                    })
                    .ToList();

                // ✅ Ensure "Reservation Name" column exists
                if (!dgv_Billing_Records.Columns.Contains("col_Reservation_Name"))
                {
                    DataGridViewTextBoxColumn reservationNameColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "col_Reservation_Name",
                        HeaderText = "Reservation",
                        DataPropertyName = "DisplayReservationName", // Bind to the computed property
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };
                    dgv_Billing_Records.Columns.Add(reservationNameColumn);
                }

                // ✅ Ensure the print button column icon is set
                if (dgv_Billing_Records.Columns["col_Print"] is DataGridViewImageColumn imgCol)
                {
                    imgCol.Image = ResizeImage(ByteArrayToImage(Properties.Resources.Printer_Icon), 24, 24);
                }

                // ✅ Disable auto-generation of columns
                dgv_Billing_Records.AutoGenerateColumns = false;

                // ✅ Bind the corrected data source
                dgv_billing_binding_source.DataSource = groupedData;
                dgv_Billing_Records.DataSource = dgv_billing_binding_source;

                // ✅ Adjust the display order of columns
                dgv_Billing_Records.Columns["col_Reservation_Name"].DisplayIndex = 2;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load billing records: " + ex.Message);
            }
        }



        private void dgv_Billing_Records_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks
            Console.WriteLine($"Clicked Column: {dgv_Billing_Records.Columns[e.ColumnIndex].Name}, Row: {e.RowIndex}");
            // Ensure the click is on the "Print" column
            if (dgv_Billing_Records.Columns[e.ColumnIndex].Name == "col_Print")
            {
                // Get the selected row's reservation ID
                int reservationId = Convert.ToInt32(dgv_Billing_Records.Rows[e.RowIndex].Cells["pk_ReservationID"].Value);

                // Open frm_Print_Billing and pass reservation ID
                frm_Print_Billing printBillingForm = new frm_Print_Billing(reservationId);
                printBillingForm.ShowDialog();
            }
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            frm_Report_Billing_Main reportBillingForm = new frm_Report_Billing_Main();
            reportBillingForm.ShowDialog(); // Opens the form as a modal dialog

        }

        private void sb_Billing_Search_Bar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = sb_Billing_Search_Bar.Text.Trim().ToLower(); // Convert search term to lowercase

            if (string.IsNullOrEmpty(searchTerm))
            {
                dgv_billing_binding_source.DataSource = all_billing_model;
            }
            else
            {
                var filteredData = all_billing_model.Where(item =>
                    item.fld_Control_Number.ToLower().Contains(searchTerm) ||  // Search by control number
                    item.fld_Full_Name.ToLower().Contains(searchTerm) ||     // Search by full name
                    item.fld_Venue_Name.ToLower().Contains(searchTerm) ||    // Search by venue name
                    item.fld_Reservation_Type.ToLower().Contains(searchTerm) || // Search by reservation type
                    item.fld_Payment_Status.ToLower().Contains(searchTerm) || // Search by payment status
                    item.EquipmentNames.Any(equipment => equipment.ToLower().Contains(searchTerm)) // Search within merged equipment names
                ).ToList();

                dgv_billing_binding_source.DataSource = filteredData;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}