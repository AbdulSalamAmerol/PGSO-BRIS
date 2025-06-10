    using Microsoft.Reporting.WinForms;
    using pgso.Billing.Models;
    using pgso.Billing.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    namespace pgso.pgso_Billing.Forms
    {
        public partial class frm_Print_Billing : Form
        {
            private int _reservationId;
            private List<Model_Billing> _billingData;
            private Repo_Billing repo_Billing = new Repo_Billing(); // Repository instance

            // Accept only pk_ReservationID when opening the form
            public frm_Print_Billing(int reservationId)
            {
                InitializeComponent();
                _reservationId = reservationId;
            }

            private void Print_Billing_Report_Viewer_Load(object sender, EventArgs e)
            {
            
                try
                {
                    LoadBillingDetails(); // Fetch data first
                    DisplayReport(); // Load the data into the report viewer
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Close form on failure
                }
            }

        private void LoadBillingDetails()
        {
            var billingRecords = repo_Billing.GetBillingRecordsByReservationId(_reservationId);

            if (billingRecords == null || billingRecords.Count == 0)
            {
                MessageBox.Show("No revenue details found for this reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
                _billingData = billingRecords; // ✅ Store the full list correctly

                // ✅ Output fld_Username for each record
                foreach (var record in billingRecords)
                {
                    Console.WriteLine("fld_Username: " + record.fld_Username);
                    System.Diagnostics.Debug.WriteLine("fld_Username: " + record.fld_Username);
                }
            }

            Console.WriteLine("Records count: " + billingRecords.Count);
            foreach (var record in billingRecords)
            {
                Console.WriteLine("Record object: " + record);
            }

            foreach (var record in billingRecords)
            {
                Console.WriteLine($"fld_Username: '{record.fld_Username}");
            }
        }


        private void DisplayReport()
            {
                if (_billingData == null || _billingData.Count == 0) return;

                // Set the report definition path or embedded resource
                 Print_Billing_Report_Viewer.LocalReport.ReportEmbeddedResource = "pgso.pgso_Billing.Forms.Report_Print_Billing.rdlc";

                // Prepare Report Data Source
                ReportDataSource rds = new ReportDataSource("BillingDataset", _billingData);

                // Assign DataSource to ReportViewer
                Print_Billing_Report_Viewer.LocalReport.DataSources.Clear();
                Print_Billing_Report_Viewer.LocalReport.DataSources.Add(rds);

                // Refresh Report Viewer
                Print_Billing_Report_Viewer.RefreshReport();
            }

        }

    }
