using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private int currentPage = 1;
        private int pageSize = 35; // You can adjust this as needed
        private int totalRecords = 0;
        private int totalPages = 0;

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
            dt_Audit.AutoGenerateColumns = false;
            // Load data when the form loads
            RefreshData();
        }

        private void RefreshData(string search = "")
        {
            try
            {
                using (SqlConnection con = new SqlConnection(mycon))
                {
                    // Count total records
                    string countQuery = @"
                SELECT COUNT(*)
                FROM tbl_Audit_Log al
                LEFT JOIN tbl_User u ON al.fk_UserID = u.pk_UserID
                WHERE (u.fld_Username LIKE @Search OR al.fld_Changed_By LIKE @Search OR al.fld_ActionType LIKE @Search)";
                    SqlCommand countCmd = new SqlCommand(countQuery, con);
                    countCmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                    con.Open();
                    totalRecords = (int)countCmd.ExecuteScalar();
                    con.Close();

                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (currentPage > totalPages) currentPage = totalPages == 0 ? 1 : totalPages;
                    if (currentPage < 1) currentPage = 1;

                    // Fetch paginated data
                    string query = @"
                SELECT 
                    al.fld_ActionType,
                    al.fld_Changed_By,
                    al.fld_Changed_At,
                    al.fld_Previous_Data_Json,   
                    al.fld_New_Data_Json,   
                    u.fld_Username
                FROM tbl_Audit_Log al
                LEFT JOIN tbl_User u ON al.fk_UserID = u.pk_UserID
                WHERE (u.fld_Username LIKE @Search OR al.fld_Changed_By LIKE @Search OR al.fld_ActionType LIKE @Search)
                ORDER BY al.fld_Changed_At DESC
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@Search", "%" + search + "%");
                    sda.SelectCommand.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize);
                    sda.SelectCommand.Parameters.AddWithValue("@PageSize", pageSize);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Add processed difference columns
                    if (!dt.Columns.Contains("PrevData"))
                        dt.Columns.Add("PrevData", typeof(string));
                    if (!dt.Columns.Contains("NewData"))
                        dt.Columns.Add("NewData", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        string prevJson = row["fld_Previous_Data_Json"]?.ToString();
                        string newJson = row["fld_New_Data_Json"]?.ToString();
                        string changesPrev = "", changesNew = "";

                        if (!string.IsNullOrWhiteSpace(prevJson) && !string.IsNullOrWhiteSpace(newJson))
                        {
                            try
                            {
                                var prevDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(prevJson);
                                var newDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(newJson);

                                foreach (var key in prevDict.Keys)
                                {
                                    var oldVal = prevDict[key]?.ToString();
                                    var newVal = newDict.ContainsKey(key) ? newDict[key]?.ToString() : null;

                                    if (oldVal != newVal)
                                    {
                                        changesPrev += $"{key}: '{oldVal}'\n";
                                        changesNew += $"{key}: '{newVal}'\n";
                                    }
                                }
                            }
                            catch
                            {
                                changesPrev = prevJson;
                                changesNew = newJson;
                            }
                        }

                        row["PrevData"] = changesPrev.Trim();
                        row["NewData"] = changesNew.Trim();
                    }

                    dt_Audit.DataSource = dt;
                    NormalizeDataGridViewStyle();

                    // Word wrap configuration (IMPORTANT)
                    if (dt_Audit.Columns.Contains("PrevData"))
                    {
                        dt_Audit.Columns["PrevData"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    }
                    if (dt_Audit.Columns.Contains("NewData"))
                    {
                        dt_Audit.Columns["NewData"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    }

                    // Allow row height to expand based on wrapped content
                    dt_Audit.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    // Pagination UI
                    lblPageInfo.Text = $"Page {currentPage} of {Math.Max(totalPages, 1)}";
                    btnPrevPage.Enabled = currentPage > 1;
                    btnNextPage.Enabled = currentPage < totalPages;
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
            currentPage = 1;
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

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                RefreshData(searchbox.Text.Trim());
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                RefreshData(searchbox.Text.Trim());
            }
        }

        private void lblPageInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
