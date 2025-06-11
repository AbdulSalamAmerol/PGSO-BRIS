using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Report_Billing_Main : Form
    {
        public frm_Report_Billing_Main()
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
            // Ensure a payment status is selected
            if (cmb_Payment_Status.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paymentStatus = cmb_Payment_Status.SelectedItem.ToString().Trim();
            // Get selected reservation type (default to "All" if nothing is selected)
            string reservationType = cmb_Venue_Or_Equipment.SelectedItem?.ToString().Trim() ?? "All";

            if (selectedReport == "Revenue Report")
            {
                if (reservationType == "Venue")
                {
                    frm_Report_Billing_Venue reportForm =
                        new frm_Report_Billing_Venue(startDate, endDate, paymentStatus, reservationType);
                    reportForm.ShowDialog();
                    // auditlog start
                    string affectedTable = "Report";
                    string affectedRecordPk = Guid.NewGuid().ToString(); // No PK, so use a unique identifier for the log
                    string actionType = "Generated a Billing Report for Venue";
                    string changedBy = frm_login.LoggedInUserRole;
                    DateTime changedAt = DateTime.Now;
                    int userId = frm_login.LoggedInUserId;

                    string prevDataJson = DBNull.Value.ToString(); // No previous data for report generation

                    string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                    {
                        ReportType = selectedReport,
                        StartDate = startDate,
                        EndDate = endDate,
                        PaymentStatus = paymentStatus,
                        ReservationType = reservationType
                    });

                    // Use the same connection string as Repo_Billing
                    string connectionString = "Data Source=KIMABZ\\SQL;Initial Catalog=BRIS_EXPERIMENT_3.0;User ID=sa;Password=abz123;Encrypt=False;TrustServerCertificate=True";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand auditCmd = new SqlCommand(@"
                                INSERT INTO tbl_Audit_Log
                                (fk_UserID, fld_Affected_Table, fld_Affected_Record_PK, fld_ActionType, fld_Previous_Data_Json, fld_New_Data_Json, fld_Changed_By, fld_Changed_At)
                                VALUES (@UserID, @Table, @RecordPK, @ActionType, @PrevJson, @NewJson, @ChangedBy, @ChangedAt)", conn, transaction))
                                {
                                    auditCmd.Parameters.AddWithValue("@UserID", userId);
                                    auditCmd.Parameters.AddWithValue("@Table", affectedTable);
                                    auditCmd.Parameters.AddWithValue("@RecordPK", affectedRecordPk);
                                    auditCmd.Parameters.AddWithValue("@ActionType", actionType);
                                    auditCmd.Parameters.AddWithValue("@PrevJson", prevDataJson);
                                    auditCmd.Parameters.AddWithValue("@NewJson", newDataJson);
                                    auditCmd.Parameters.AddWithValue("@ChangedBy", changedBy);
                                    auditCmd.Parameters.AddWithValue("@ChangedAt", changedAt);

                                    auditCmd.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    // end auditlog
                }
                else if (reservationType == "Equipment")
                {
                    frm_Report_Billing_Equipment reportForm =
                        new frm_Report_Billing_Equipment(startDate, endDate, paymentStatus, reservationType);
                    reportForm.ShowDialog();
                    // auditlog start
                    string affectedTable = "Report";
                    string affectedRecordPk = Guid.NewGuid().ToString(); // No PK, so use a unique identifier for the log
                    string actionType = "Generated a Billing Report fro Equipment";
                    string changedBy = frm_login.LoggedInUserRole;
                    DateTime changedAt = DateTime.Now;
                    int userId = frm_login.LoggedInUserId;

                    string prevDataJson = DBNull.Value.ToString(); // No previous data for report generation

                    string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                    {
                        ReportType = selectedReport,
                        StartDate = startDate,
                        EndDate = endDate,
                        PaymentStatus = paymentStatus,
                        ReservationType = reservationType
                    });

                    // Use the same connection string as Repo_Billing
                    string connectionString = "Data Source=KIMABZ\\SQL;Initial Catalog=BRIS_EXPERIMENT_3.0;User ID=sa;Password=abz123;Encrypt=False;TrustServerCertificate=True";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand auditCmd = new SqlCommand(@"
                                INSERT INTO tbl_Audit_Log
                                (fk_UserID, fld_Affected_Table, fld_Affected_Record_PK, fld_ActionType, fld_Previous_Data_Json, fld_New_Data_Json, fld_Changed_By, fld_Changed_At)
                                VALUES (@UserID, @Table, @RecordPK, @ActionType, @PrevJson, @NewJson, @ChangedBy, @ChangedAt)", conn, transaction))
                                {
                                    auditCmd.Parameters.AddWithValue("@UserID", userId);
                                    auditCmd.Parameters.AddWithValue("@Table", affectedTable);
                                    auditCmd.Parameters.AddWithValue("@RecordPK", affectedRecordPk);
                                    auditCmd.Parameters.AddWithValue("@ActionType", actionType);
                                    auditCmd.Parameters.AddWithValue("@PrevJson", prevDataJson);
                                    auditCmd.Parameters.AddWithValue("@NewJson", newDataJson);
                                    auditCmd.Parameters.AddWithValue("@ChangedBy", changedBy);
                                    auditCmd.Parameters.AddWithValue("@ChangedAt", changedAt);

                                    auditCmd.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    // end auditlog
                }
                else if (reservationType == "ALL")
                {
                    frm_Report_Billing_Venue_And_Equipment reportForm =
                        new frm_Report_Billing_Venue_And_Equipment(startDate, endDate, paymentStatus, reservationType);
                    reportForm.ShowDialog();

                    // auditlog start
                    string affectedTable = "Report";
                    string affectedRecordPk = Guid.NewGuid().ToString(); // No PK, so use a unique identifier for the log
                    string actionType = "Generated a Billing Report both Venue and Equipment";
                    string changedBy = frm_login.LoggedInUserRole;
                    DateTime changedAt = DateTime.Now;
                    int userId = frm_login.LoggedInUserId;

                    string prevDataJson = DBNull.Value.ToString(); // No previous data for report generation

                    string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                    {
                        ReportType = selectedReport,
                        StartDate = startDate,
                        EndDate = endDate,
                        PaymentStatus = paymentStatus,
                        ReservationType = reservationType
                    });

                    // Use the same connection string as Repo_Billing
                    string connectionString = "Data Source=KIMABZ\\SQL;Initial Catalog=BRIS_EXPERIMENT_3.0;User ID=sa;Password=abz123;Encrypt=False;TrustServerCertificate=True";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand auditCmd = new SqlCommand(@"
                                INSERT INTO tbl_Audit_Log
                                (fk_UserID, fld_Affected_Table, fld_Affected_Record_PK, fld_ActionType, fld_Previous_Data_Json, fld_New_Data_Json, fld_Changed_By, fld_Changed_At)
                                VALUES (@UserID, @Table, @RecordPK, @ActionType, @PrevJson, @NewJson, @ChangedBy, @ChangedAt)", conn, transaction))
                                {
                                    auditCmd.Parameters.AddWithValue("@UserID", userId);
                                    auditCmd.Parameters.AddWithValue("@Table", affectedTable);
                                    auditCmd.Parameters.AddWithValue("@RecordPK", affectedRecordPk);
                                    auditCmd.Parameters.AddWithValue("@ActionType", actionType);
                                    auditCmd.Parameters.AddWithValue("@PrevJson", prevDataJson);
                                    auditCmd.Parameters.AddWithValue("@NewJson", newDataJson);
                                    auditCmd.Parameters.AddWithValue("@ChangedBy", changedBy);
                                    auditCmd.Parameters.AddWithValue("@ChangedAt", changedAt);

                                    auditCmd.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    // end auditlog
                }
                else
                {
                    MessageBox.Show("Invalid reservation type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel and close this form?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
