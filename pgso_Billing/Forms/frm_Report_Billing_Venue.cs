﻿using Microsoft.Reporting.WinForms;
using pgso.Billing.Models;
using pgso.Billing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Report_Billing_Venue : Form
    {
        private List<Model_Billing> _revenueData;
        private Repo_Billing repo_Billing = new Repo_Billing(); // Repository instance

        private DateTime _startDate;
        private DateTime _endDate;
        private string _paymentStatus;
        private string _reservationType;
        public frm_Report_Billing_Venue(DateTime startDate, DateTime endDate, string paymentStatus, string reservationType)
        {
            InitializeComponent();
            _startDate = startDate;
            _endDate = endDate;
            _paymentStatus = paymentStatus;
            _reservationType = reservationType;
        }

        private void frm_Report_Billing_Venue_Load(object sender, EventArgs e)
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

            //  Clear existing data sources
            Report_Viewer_Venue_Revenue.LocalReport.DataSources.Clear();
            Report_Viewer_Venue_Revenue.LocalReport.ReportEmbeddedResource = "pgso.pgso_Billing.Forms.Report_Billing_Venue.rdlc";

            //  Add the dataset to the report
            ReportDataSource rds = new ReportDataSource("BillingDataset", _revenueData);
            Report_Viewer_Venue_Revenue.LocalReport.DataSources.Add(rds);

            Report_Viewer_Venue_Revenue.LocalReport.SetParameters(new ReportParameter("StartDate", _startDate.ToString("MMMM dd, yyyy")));
            Report_Viewer_Venue_Revenue.LocalReport.SetParameters(new ReportParameter("EndDate", _endDate.ToString("MMMM dd, yyyy")));
            Report_Viewer_Venue_Revenue.LocalReport.SetParameters(new ReportParameter("PaymentStatus", _paymentStatus));
            Report_Viewer_Venue_Revenue.LocalReport.SetParameters(new ReportParameter("ReservationType", _reservationType));

            //  Refresh the report to apply changes
            Report_Viewer_Venue_Revenue.RefreshReport();
        }
    }
}
