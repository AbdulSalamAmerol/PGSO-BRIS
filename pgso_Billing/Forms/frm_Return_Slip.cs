using Microsoft.Reporting.WinForms;
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
    public partial class frm_Return_Slip : Form
    {
        private readonly int _reservationId;
        private List<Model_Billing> _slipData;
        private readonly Repo_Billing _repoBilling = new Repo_Billing();
        public frm_Return_Slip(int reservationId)
        {
            InitializeComponent();
            _reservationId = reservationId;

            // 2) Hook the Load event
            this.Load += frm_Return_Slip_Load;
        }

        private void frm_Return_Slip_Load(object sender, EventArgs e)
        {

            try
            {
                LoadSlipDetails();   // fetch data
                DisplayReport();     // bind & refresh
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading confirmation slip: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                this.Close();
            }
        }
        private void LoadSlipDetails()
        {
            var records = _repoBilling.GetBillingRecordsByReservationId(_reservationId);
            if (records == null || records.Count == 0)
            {
                MessageBox.Show(
                    "No confirmation slip data found for this reservation.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Close();
                return;
            }

            _slipData = records;
        }

        // 5) Configure the ReportViewer and refresh
        private void DisplayReport()
        {
            if (_slipData == null || _slipData.Count == 0)
                return;

            // Use embedded resource or .rdlc file path
            Return_Slip_Report_Viewer.LocalReport.ReportEmbeddedResource
                = "pgso.pgso_Billing.Forms.Report_Return_Slip.rdlc";
            // If you prefer an external file path:
            // Confirmation_Slip_Report_Viewer.LocalReport.ReportPath = @"C:\...\Report_Confirmation_Slip.rdlc";

            // Set up the data source name to match the RDLC’s DataSet name
            var rds = new ReportDataSource("BillingDataset", _slipData);

            Return_Slip_Report_Viewer.LocalReport.DataSources.Clear();
            Return_Slip_Report_Viewer.LocalReport.DataSources.Add(rds);

            Return_Slip_Report_Viewer.RefreshReport();
        }

        private void Return_Slip_Report_Viewer_Load(object sender, EventArgs e)
        {

        }
    }
}
