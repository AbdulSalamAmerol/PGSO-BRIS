using System;
using System.Windows.Forms;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Report_Billing : Form
    {
        public frm_Report_Billing()
        {
            InitializeComponent();
        }

        private void btn_Generate_Report_Click(object sender, EventArgs e)
        {
            // Ensure a report is selected
            if (cmb_Choose_Report.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedReport = cmb_Choose_Report.SelectedItem.ToString().Trim();
            DateTime startDate = dtp_Start_Date.Value.Date;
            DateTime endDate = dtp_End_Date.Value.Date;

            // Ensure start date is not after end date
            if (startDate > endDate)
            {
                MessageBox.Show("Start Date cannot be after End Date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected payment status (default to "All" if nothing is selected)
            string paymentStatus = cmb_Payment_Status.SelectedItem?.ToString().Trim() ?? "All";

            // Get selected reservation type (default to "All" if nothing is selected)
            string reservationType = cmb_Venue_Or_Equipment.SelectedItem?.ToString().Trim() ?? "All";

            if (selectedReport == "Revenue By Reservation Type")
            {
                frm_Report_Revenue_By_Reservation_Type reportForm =
                    new frm_Report_Revenue_By_Reservation_Type(startDate, endDate, paymentStatus, reservationType);
                reportForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a valid report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
