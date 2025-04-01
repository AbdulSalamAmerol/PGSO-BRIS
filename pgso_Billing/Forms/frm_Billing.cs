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
                if (dgv_Billing_Records.Columns["col_Print"] is DataGridViewImageColumn imgCol)
                {
                    imgCol.Image = ResizeImage(ByteArrayToImage(Properties.Resources.Printer_Icon), 24, 24);
                    // Adjust size as needed
                }
                if (all_billing_model.Count == 0)
                {
                    MessageBox.Show("No billing records found.");
                    return;
                }

                // Manually define DataGridView columns (disable auto-generation)
                dgv_Billing_Records.AutoGenerateColumns = false;

                // Bind the data
                dgv_billing_binding_source.DataSource = all_billing_model;
                dgv_Billing_Records.DataSource = dgv_billing_binding_source;
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
    }
}