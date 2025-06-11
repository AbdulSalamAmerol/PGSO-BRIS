using pgso.Billing.Models;
using pgso.Billing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Extend_Venue : Form
    {
        public event Action OnExtensionSuccessful;  // Define the event
        private int _reservationID;
        private List<Model_Billing> _billingData;
        private Repo_Billing repo_Billing = new Repo_Billing(); // Repository instance
        public event Action<int?> RequestBillingRefresh;
        public frm_Extend_Venue(int reservationID)
        {
            InitializeComponent();
            _reservationID = reservationID;
            this.Load += frm_Extend_Venue_Load;
        }
        private async void frm_Extend_Venue_Load(object sender, EventArgs e)
        {
            await LoadCurrentExtensionDetails();
        }
        private async Task LoadCurrentExtensionDetails()
        {
            try
            {
                var billingData = await repo_Billing.GetCurrentExtensionDetails(_reservationID);
                if (billingData != null)
                {
                    // Check if OR extension is 0 or less
                    if (billingData.fld_OR_Extension <= 0)
                        tb_OR_Extension.Text = "Enter Official Receipt Number";
                    else
                        tb_OR_Extension.Text = billingData.fld_OR_Extension.ToString();

                    tb_Extend_Venue.Text = billingData.fld_OT_Hours.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }





        private async void btn_Extend_Venue_Click(object sender, EventArgs e)
        {
            try
            {
                // Get inputs from editable fields
                string orExtensionText = tb_OR_Extension.Text.Trim();
                string extendHoursText = tb_Extend_Venue.Text.Trim();

                int orExtensionInt = 0; // Default value

                // Try parsing the OR Extension
                if (!int.TryParse(orExtensionText, out orExtensionInt))
                {
                    // Default remains 0 if parsing fails
                }

                // Validate Hours
                if (string.IsNullOrEmpty(extendHoursText) || !decimal.TryParse(extendHoursText, out decimal inputHours))
                {
                    MessageBox.Show("Please enter a valid number for extended hours.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int roundedHours = (int)Math.Ceiling(inputHours);

                // Call method to handle OT and OR extension logic
                var result = await repo_Billing.UpdateReservationExtension(_reservationID, roundedHours, orExtensionInt);
                if (result)
                {

                    // auditlog start
                    string affectedTable = "tbl_Reservation";
                    string affectedRecordPk = _reservationID.ToString();
                    string actionType = "Extended Reservation";
                    string changedBy = frm_login.LoggedInUserRole;
                    DateTime changedAt = DateTime.Now;
                    int userId = frm_login.LoggedInUserId;

                    // Fetch previous data before the update
                    var prevBillingData = await repo_Billing.GetCurrentExtensionDetails(_reservationID);

                    // Serialize previous data (before extension)
                    string prevDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                    {
                        ControlNumber = prevBillingData.fld_Control_Number,
                        Activity = prevBillingData.fld_Activity_Name,
                        StartDate = prevBillingData.fld_Start_Date,
                        EndDate = prevBillingData.fld_End_Date,
                        StartTime = prevBillingData.fld_Start_Time,
                        EndTime = prevBillingData.fld_End_Time,
                        OTHours = prevBillingData.fld_OT_Hours,
                        ORExtension = prevBillingData.fld_OR_Extension,
                        TotalAmount = prevBillingData.fld_Total_Amount,
                        Status = prevBillingData.fld_Reservation_Status
                    });

                    // Serialize new data (after extension)
                    string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                    {
                        ControlNumber = prevBillingData.fld_Control_Number,
                        Activity = prevBillingData.fld_Activity_Name,
                        StartDate = prevBillingData.fld_Start_Date,
                        EndDate = prevBillingData.fld_End_Date,
                        StartTime = prevBillingData.fld_Start_Time,
                        EndTime = prevBillingData.fld_End_Time,
                        OTHours = int.TryParse(tb_Extend_Venue.Text.Trim(), out int newOtHours) ? newOtHours : prevBillingData.fld_OT_Hours,
                        ORExtension = int.TryParse(tb_OR_Extension.Text.Trim(), out int newOrExt) ? newOrExt : prevBillingData.fld_OR_Extension,
                        TotalAmount = prevBillingData.fld_Total_Amount, // Update if you recalculate
                        Status = prevBillingData.fld_Reservation_Status // Update if status changes
                    });

                    // Use the same connection string as Repo_Billing
                    string connectionString = "Data Source=172.17.16.125;Initial Catalog=RBIS;User ID=RBIS;Password=Nvsuojt_2025;Encrypt=False;TrustServerCertificate=True";

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
                    MessageBox.Show("Reservation extended successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RequestBillingRefresh?.Invoke(_reservationID);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to extend the reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
