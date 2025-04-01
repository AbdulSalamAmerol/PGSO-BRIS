using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using pgso.Billing.Models;
using pgso.Billing.Repositories;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Report_Revenue_By_Reservation_Type : Form
    {
        private List<Billing_Model> _revenueData;
        private Repo_Billing repo_Billing = new Repo_Billing(); // Repository instance

        private DateTime _startDate;
        private DateTime _endDate;
        private string _paymentStatus;
        private string _reservationType;

        public frm_Report_Revenue_By_Reservation_Type(DateTime startDate, DateTime endDate, string paymentStatus, string reservationType)
        {
            InitializeComponent();
            _startDate = startDate;
            _endDate = endDate;
            _paymentStatus = paymentStatus;
            _reservationType = reservationType;
        }

        private void frm_Report_Revenue_By_Reservation_Type_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRevenueData();  // Fetch data first
                DisplayReport();    // Load the data into the ReportViewer
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Close form if there is an issue
            }
        }
        private void LoadRevenueData()
        {
            _revenueData = repo_Billing.GetRevenueByFilters(_startDate, _endDate, _paymentStatus, _reservationType);

            if (_revenueData == null || _revenueData.Count == 0)
            {
                MessageBox.Show("No revenue records found for the selected filters.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void DisplayReport()
        {
            if (_revenueData == null || _revenueData.Count == 0) return;

            Revenu_Report_Viewer.LocalReport.DataSources.Clear();
            Revenu_Report_Viewer.LocalReport.ReportEmbeddedResource = "pgso.pgso_Billing.Forms.Report_Revenue_By_Reservation_Type.rdlc"; //##
            // ✅ Bind data source
            ReportDataSource rds = new ReportDataSource("BillingDataset", _revenueData);
            Revenu_Report_Viewer.LocalReport.DataSources.Add(rds); 
            // ✅ Refresh the report
            Revenu_Report_Viewer.RefreshReport(); 
        }


    }
}
