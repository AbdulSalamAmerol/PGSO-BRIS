using pgso.Billing.Models;
using pgso.Billing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Cancellation_Reason : Form
    {
        private readonly int _reservationId;
        private Model_Billing _billingDetail; // changed to a single object
        private readonly Repo_Billing _repoBilling = new Repo_Billing();
        public event Action<int, string> OnRequestVenueExtension;// Check if extension is applicable

        public event Action<int?> RequestBillingRefresh;
        public frm_Cancellation_Reason(int reservationID)
        {
            InitializeComponent();
            _reservationId = reservationID;

            // You can load billing record here or elsewhere
            var billingRecords = _repoBilling.GetBillingRecordsByReservationId(_reservationId);
            _billingDetail = billingRecords?.FirstOrDefault();
        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (_billingDetail == null)
            {
                MessageBox.Show("Billing record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string currentStatus = _billingDetail.fld_Reservation_Status;
            string cancellationReason = rtb_Cancellation_Reason.Text.Trim();

            if (string.IsNullOrWhiteSpace(cancellationReason))
            {
                MessageBox.Show("Please provide a reason for cancellation.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentStatus != "Pending" && currentStatus != "Confirmed")
            {
                MessageBox.Show("Only 'Pending' or 'Confirmed' reservations can be cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_billingDetail.fld_OT_Hours > 0)
            {
                MessageBox.Show("This reservation has overtime hours. Cancellation is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to cancel this reservation?",
                                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool success = await _repoBilling.UpdateReservationStatusAsync(_reservationId, "Cancelled");



                if (success)
                {
                    // Save the cancellation reason to the database
                    bool saved = _repoBilling.SaveCancellationReason(_reservationId, cancellationReason);

                    if (!saved)
                    {
                        MessageBox.Show("Failed to save cancellation reason.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    bool deductionSuccess = await Task.Run(() => _repoBilling.ApplyCancellationDeduction(_reservationId));

                    if (deductionSuccess)
                    {
                        MessageBox.Show("Reservation cancelled and deduction applied.");
                        RequestBillingRefresh?.Invoke(_billingDetail.pk_ReservationID); // 🔁 Notify parent to refresh billing
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Cancellation applied, but deduction failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RequestBillingRefresh?.Invoke(_billingDetail.pk_ReservationID); // 🔁 Notify parent to refresh billing
                        this.Close();
                    }

                }

                // auditlog start
                string affectedTable = "tbl_Reservation";
                string affectedRecordPk = _reservationId.ToString();
                string actionType = "Cancelled Reservation";
                string changedBy = frm_login.LoggedInUserRole;
                DateTime changedAt = DateTime.Now;
                int userId = frm_login.LoggedInUserId;

                // Optionally, serialize previous data (e.g., previous status)
                string prevDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    Status = currentStatus
                });

                // Serialize new data (after cancellation)
                string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    ControlNumber = _billingDetail.fld_Control_Number,
                    Activity = _billingDetail.fld_Activity_Name,
                    VenueID = _billingDetail.fk_VenueID,
                    StartDate = _billingDetail.fld_Start_Date,
                    EndDate = _billingDetail.fld_End_Date,
                    StartTime = _billingDetail.fld_Start_Time,
                    EndTime = _billingDetail.fld_End_Time,
                    TotalAmount = _billingDetail.fld_Total_Amount,
                    CancellationReason = cancellationReason,
                    Status = "Cancelled"
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

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
