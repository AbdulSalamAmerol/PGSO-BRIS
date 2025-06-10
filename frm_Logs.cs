using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Logs : Form
    {
        private string mycon;

        public frm_Logs()
        {
            InitializeComponent();

            // Retrieve the connection string from App.config
            mycon = ConfigurationManager.ConnectionStrings["pgso.Properties.Settings.strCon"]?.ConnectionString;

            if (string.IsNullOrEmpty(mycon))
            {
                MessageBox.Show("Error: Database connection string is not initialized. Check App.config settings.",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load data when the form loads
            RefreshData();
        }

        private void RefreshData(string search = "")
        {
            try
            {
                using (SqlConnection con = new SqlConnection(mycon))
                {
                    string query = @"
            SELECT 
                al.fld_ActionType,
                al.fld_Changed_By,
                al.fld_Changed_At,
                u.fld_Username
            FROM
                tbl_Audit_Log al
            LEFT JOIN
                tbl_User u ON al.fk_UserID = u.pk_UserID
            WHERE
                (u.fld_Username LIKE @Search OR al.fld_Changed_By LIKE @Search OR al.fld_ActionType LIKE @Search)
            ORDER BY al.fld_Changed_At DESC"; // Sort by latest to oldest

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@Search", "%" + search + "%");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Bind data to DataGridView
                    dt_Audit.DataSource = dt;
                  
                    NormalizeDataGridViewStyle();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading audit trail data: " + ex.Message);
            }
        }

        private DataTable GetFilteredAuditTrailData()
        {

            DataTable originalDataTable = (DataTable)dt_Audit.DataSource;
            DataTable filteredDataTable = new DataTable();

            // Add desired columns to the new DataTable
            filteredDataTable.Columns.Add("Username", typeof(string));
            filteredDataTable.Columns.Add("UserType", typeof(string));
            filteredDataTable.Columns.Add("Action", typeof(string));
            filteredDataTable.Columns.Add("Time", typeof(DateTime));

            // Copy data from the original DataTable to the new DataTable
            foreach (DataRow row in originalDataTable.Rows)
            {
                DataRow newRow = filteredDataTable.NewRow();
                newRow["Username"] = row["fld_Username"]?.ToString().Trim();
                newRow["UserType"] = row["fld_Changed_By"]?.ToString().Trim();
                newRow["Action"] = row["fld_ActionType"]?.ToString().Trim();
                newRow["Time"] = row["fld_Changed_At"];
                filteredDataTable.Rows.Add(newRow);
            }


            return filteredDataTable;

        }

        private void NormalizeDataGridViewStyle()
        {
            // Set a consistent style for all rows
            dt_Audit.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dt_Audit.AlternatingRowsDefaultCellStyle = dt_Audit.DefaultCellStyle;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text.Trim();
            RefreshData(search);
        }




        private void btnGeneratePDFadm_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable auditTrailData = GetFilteredAuditTrailData(); // Get filtered data
                Class_Pdf_Generator pdfGenerator = new Class_Pdf_Generator();
                string tempFilePath = Path.Combine(Path.GetTempPath(), "AuditTrail.pdf");
                pdfGenerator.CreatePdf(tempFilePath, auditTrailData);

                // Open the PDF in Microsoft Edge
                try
                {
                    string browserPath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

                    if (!File.Exists(browserPath))
                    {
                        MessageBox.Show("Microsoft Edge executable not found: " + browserPath);
                        return;
                    }

                    System.Diagnostics.Process.Start(browserPath, "\"" + tempFilePath + "\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening PDF: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message);
            }
        }



        private void dt_Audit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_Logs_Load(object sender, EventArgs e)
        {

        }
    }
}
