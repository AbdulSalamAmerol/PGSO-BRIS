using pgso.Billing.Models;
using pgso.Billing.Repositories;
using pgso.pgso_Billing.Forms;
using pgso.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace pgso.pgso_Billing
{
    public partial class Venue_User_Control : UserControl
    {
       
        public event Action<int?> RequestBillingRefresh;
        private Repo_Billing _repoBilling; // ✅ Add this field
        public event Action<int, string> OnRequestVenueExtension;// Check if extension is applicable
        private Model_Billing _billingDetails;
        // Constructor that accepts Model_Billing
        public Venue_User_Control(Model_Billing billingDetails, Repo_Billing repoBilling)
        {
            InitializeComponent();

            _billingDetails = billingDetails; // ✅ Store for later use
            _repoBilling = repoBilling; // ✅ Store the repository
            LoadBillingDetails(billingDetails); // Populate the fields on creation
            int reservationID = billingDetails.pk_ReservationID;
            Console.WriteLine("CHECK billingDetails.fld_Reservation_Status" + billingDetails.fld_Reservation_Status);
        }
        private void newbtn_Extend_Venue_Click(object sender, EventArgs e)
        {
            if (_billingDetails != null)
            {
                string reservationStatus = _billingDetails.fld_Reservation_Status;

                // Check if the reservation is not "Confirmed"
                if (reservationStatus == "Cancelled" || reservationStatus == "Pending")
                {
                    MessageBox.Show("Only Confirmed reservations can be extended.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // --- AUDIT LOG: Capture previous state before extension ---
                var prevData = new
                {
                    ControlNumber = _billingDetails.fld_Control_Number,
                    Status = _billingDetails.fld_Reservation_Status,
                    OTHours = _billingDetails.fld_OT_Hours,
                    ORExtension = _billingDetails.fld_OR_Extension,
                    ExtensionStatus = _billingDetails.fld_Extension_Status
                };

                OnRequestVenueExtension?.Invoke(_billingDetails.pk_ReservationID, reservationStatus); // Optionally pass status
                _billingDetails = _repoBilling.GetBillingDetailsByReservationID(_billingDetails.pk_ReservationID);
                LoadBillingDetails(_billingDetails);

                // --- AUDIT LOG: Capture new state after extension ---
                var newData = new
                {
                    ControlNumber = _billingDetails.fld_Control_Number,
                    Status = _billingDetails.fld_Reservation_Status,
                    OTHours = _billingDetails.fld_OT_Hours,
                    ORExtension = _billingDetails.fld_OR_Extension,
                    ExtensionStatus = _billingDetails.fld_Extension_Status
                };

                // --- AUDIT LOG START ---
                string affectedTable = "tbl_Reservation";
                string affectedRecordPk = _billingDetails.pk_ReservationID.ToString();
                string actionType = "Extended Reservation";
                string changedBy = frm_login.LoggedInUserRole;
                DateTime changedAt = DateTime.Now;
                int userId = frm_login.LoggedInUserId;

                string prevDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(prevData);
                string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(newData);

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
                // --- AUDIT LOG END ---





                RequestBillingRefresh?.Invoke(_billingDetails.pk_ReservationID); // 🔁 Notify parent to refresh billing
            }
            else
            {
                MessageBox.Show("Reservation details are missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_Change_Reservation_info_Click(object sender, EventArgs e)
        {
            // ✅ Only allow if status is Confirmed or Pending
            if (_billingDetails.fld_Reservation_Status != "Confirmed" && _billingDetails.fld_Reservation_Status != "Pending")
            {
                MessageBox.Show("You can only edit reservations that are Confirmed or Pending.",
                "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- AUDIT LOG: Capture previous state before edit ---
            var prevData = new
            {
                ControlNumber = _billingDetails.fld_Control_Number,
                Status = _billingDetails.fld_Reservation_Status,
                StartDate = _billingDetails.fld_Start_Date,
                EndDate = _billingDetails.fld_End_Date,
                StartTime = _billingDetails.fld_Start_Time,
                EndTime = _billingDetails.fld_End_Time,
                VenueName = _billingDetails.fld_Venue_Name,
                VenueScope = _billingDetails.fld_Venue_Scope_Name,
                OTHours = _billingDetails.fld_OT_Hours,
                ORExtension = _billingDetails.fld_OR_Extension,
                ExtensionStatus = _billingDetails.fld_Extension_Status,
                TotalAmount = _billingDetails.fld_Total_Amount
            };

            frm_Edit_Venue_Reservation_Info editForm = new frm_Edit_Venue_Reservation_Info(_billingDetails);

            var result = editForm.ShowDialog();

            // 👇 Refresh only if dialog result is OK (successful save)
            if (result == DialogResult.OK)
            {
                // Reload the billing details in this control
                var updatedDetails = new Repo_Billing().GetBillingDetailsByReservationID(_billingDetails.pk_ReservationID);
                if (updatedDetails != null)
                {
                    _billingDetails = updatedDetails;
                    LoadBillingDetails(_billingDetails);
                }

                // --- AUDIT LOG: Capture new state after edit ---
                var newData = new
                {
                    ControlNumber = _billingDetails.fld_Control_Number,
                    Status = _billingDetails.fld_Reservation_Status,
                    StartDate = _billingDetails.fld_Start_Date,
                    EndDate = _billingDetails.fld_End_Date,
                    StartTime = _billingDetails.fld_Start_Time,
                    EndTime = _billingDetails.fld_End_Time,
                    VenueName = _billingDetails.fld_Venue_Name,
                    VenueScope = _billingDetails.fld_Venue_Scope_Name,
                    OTHours = _billingDetails.fld_OT_Hours,
                    ORExtension = _billingDetails.fld_OR_Extension,
                    ExtensionStatus = _billingDetails.fld_Extension_Status,
                    TotalAmount = _billingDetails.fld_Total_Amount
                };

                // --- AUDIT LOG START ---
                string affectedTable = "tbl_Reservation";
                string affectedRecordPk = _billingDetails.pk_ReservationID.ToString();
                string actionType = "Edited Reservation Info";
                string changedBy = frm_login.LoggedInUserRole;
                DateTime changedAt = DateTime.Now;
                int userId = frm_login.LoggedInUserId;

                string prevDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(prevData);
                string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(newData);

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
                // --- AUDIT LOG END ---

                // 🔔 Trigger refresh event to inform frm_Billing
                RequestBillingRefresh?.Invoke(_billingDetails.pk_ReservationID);
            }
        }

        // Method to load billing details into the controls
        public void LoadBillingDetails(Model_Billing billingDetails)
        {
            HideOvertimeAndRefundDetails(_billingDetails);
            pnl_Billing_Details.Visible = true;

            // Populate the labels with values from the billingDetails model
            lbl_Service_Fee.Text = billingDetails.fld_Caterer_Fee.ToString("C", new CultureInfo("en-PH"));
            lbl_Control_Number.Text = billingDetails.fld_Control_Number;
            lbl_Activity_Name.Text = billingDetails.fld_Activity_Name;
            lbl_Requesting_Person.Text = $"{billingDetails.fld_First_Name} {billingDetails.fld_Middle_Name} {billingDetails.fld_Surname}";
            lbl_Requesting_Office.Text = billingDetails.fld_Requesting_Office;
            lbl_Origin_Request.Text = billingDetails.fld_Request_Origin;
            lbl_Contact_Number.Text = billingDetails.fld_Contact_Number;
            lbl_Address.Text = billingDetails.fld_Requesting_Person_Address;
            //bool showOR = billingDetails.fld_OR != null && billingDetails.fld_OR != 0;
            //lbl_OR.Visible = tb_OR.Visible = showOR;
            lbl_OR_2.Text = billingDetails.fld_OR_Extension.ToString();
            btn_Extension_Slip.Enabled = (billingDetails.fld_OT_Hours > 0);
            btn_Confirm_Reservation.Enabled = (billingDetails.fld_Reservation_Status == "Pending");
            btn_Cancellation_Slip.Enabled = (billingDetails.fld_Reservation_Status == "Cancelled");
            btn_Cancel_Reservation.Enabled =
            (billingDetails.fld_Reservation_Status == "Pending" || billingDetails.fld_Reservation_Status == "Confirmed")
            && billingDetails.fld_OR_Extension <= 0;
            newbtn_Extend_Venue.Enabled = (billingDetails.fld_Reservation_Status == "Confirmed");
            btn_Change_Reservation_info.Enabled = true;
            
            tb_Extension_Status.Text = billingDetails.fld_Extension_Status;
            if (billingDetails.fld_Reservation_Status == "Cancelled" || billingDetails.fld_OT_Hours > 0)
            {
                btn_Change_Reservation_info.Enabled = false;
            }

            if (billingDetails.fld_OR == 0)
            {
                lbl_OR.Visible = false; // hides the label entirely
            }
            else
            {
                lbl_OR.Text = billingDetails.fld_OR.ToString();
                lbl_OR.Visible = true;
            }
            lbl_OR.Visible = billingDetails.fld_OR != null;
            // Format reservation dates (start and end)
            lbl_Reservation_Dates.Text = $"{billingDetails.fld_Start_Date.ToString("MM/dd/yyyy")} - {billingDetails.fld_End_Date.ToString("MM/dd/yyyy")}";

            // Format reservation times (start and end)
            lbl_Reservation_Time.Text = $"{billingDetails.Formatted_Start_Time.ToString()} - {billingDetails.Formatted_End_Time.ToString()}";

            lbl_Number_Of_Participants.Text = billingDetails.fld_Number_Of_Participants.ToString();
            lbl_Reservation_Status.Text = billingDetails.fld_Reservation_Status;

            // Venue details
            lbl_Venue_Name.Text = billingDetails.fld_Venue_Name;
            lbl_Venue_Scope.Text = billingDetails.fld_Venue_Scope_Name;

            string scopeName_Detail = billingDetails.fld_Venue_Scope_Name;

            switch (scopeName_Detail)
            {
                case "AH_Whole_Building":
                case "CS_Whole_Building":
                    lbl_Venue_Scope.Text = "Entire Venue";
                    break;
                case "CS_Lobby":
                    lbl_Venue_Scope.Text = "Lobby Only";
                    break;
                case "CS_Main_Hall":
                    lbl_Venue_Scope.Text = "Main Hall Only";
                    break;
                case "CS_Main_Hall_And_Mezzanine":
                    lbl_Venue_Scope.Text = "Main Hall and Mezzanine";
                    break;
                case "PS_Room_A":
                    lbl_Venue_Scope.Text = "Room A Only";
                    break;
                case "PS_Room_ABC":
                    lbl_Venue_Scope.Text = "Room A, B and C";
                    break;
                case "PS_Room_BC":
                    lbl_Venue_Scope.Text = "Room B and C";
                    break;
                default:
                    lbl_Venue_Scope.Text = scopeName_Detail; // fallback if not matched
                    break;
            }


            
            lbl_Rate_Type.Text = billingDetails.fld_Rate_Type;
            lbl_Rate_Type2.Text = billingDetails.fld_Rate_Type;
            lbl_Is_Aircon.Text = billingDetails.fld_Aircon ? "Yes" : "No";
            var succeedingHours = Math.Max(0, Math.Ceiling(billingDetails.Total_Hours - 4));

            // Venue pricing details (based on hourly charges, etc.)
            lbl_Base_Charge_Amount.Text = billingDetails.fld_First4Hrs_Rate.ToString("C", new CultureInfo("en-PH"));
            lbl_Additional_Hourly_Charge.Text = billingDetails.fld_Hourly_Rate.ToString("C", new CultureInfo("en-PH"));
            lbl_Additional_Charge.Text = billingDetails.fld_Additional_Charge.ToString("C", new CultureInfo("en-PH"));

            lbl_Total_Hour.Text = $"{succeedingHours} HRS";
            lbl_Additional_Hours_Amount.Text = (billingDetails.fld_Hourly_Rate * (decimal)succeedingHours).ToString("C", new CultureInfo("en-PH"));

            // If you are showing equipment details (if available)
            lbl_Venue_Name_Transact.Text = billingDetails.fld_Venue_Name;
            string scopeName = billingDetails.fld_Venue_Scope_Name;

            switch (scopeName)
            {
                case "AH_Whole_Building":
                case "CS_Whole_Building":
                    lbl_Venue_Scope_Transact.Text = "Entire Venue";
                    break;
                case "CS_Lobby":
                    lbl_Venue_Scope_Transact.Text = "Lobby Only";
                    break;
                case "CS_Main_Hall":
                    lbl_Venue_Scope_Transact.Text = "Main Hall Only";
                    break;
                case "CS_Main_Hall_And_Mezzanine":
                    lbl_Venue_Scope_Transact.Text = "Main Hall and Mezzanine";
                    break;
                case "PS_Room_A":
                    lbl_Venue_Scope_Transact.Text = "Room A Only";
                    break;
                case "PS_Room_ABC":
                    lbl_Venue_Scope_Transact.Text = "Room A, B and C";
                    break;
                case "PS_Room_BC":
                    lbl_Venue_Scope_Transact.Text = "Room B and C";
                    break;
                default:
                    lbl_Venue_Scope_Transact.Text = scopeName; // fallback if not matched
                    break;
            }


            // Calculated charges based on overtime
            lbl_OT_Hours.Text = billingDetails.fld_OT_Hours.ToString() + " HRS";
            lbl_OT_Hourly_Charge.Text = billingDetails.fld_Hourly_Rate.ToString("C", new CultureInfo("en-PH"));
            lbl_Overtime_Fee.Text = (billingDetails.fld_OT_Hours * billingDetails.fld_Hourly_Rate).ToString("C", new CultureInfo("en-PH"));

            // Payment details
            lbl_Paid_Amount.Text = billingDetails.fld_Amount_Paid.ToString("C", new CultureInfo("en-PH"));
            decimal otCharge = billingDetails.fld_OT_Hours * billingDetails.fld_Hourly_Rate;

            lbl_Total_Amount.Text = (billingDetails.fld_Additional_Charge+billingDetails.fld_First4Hrs_Rate + ((decimal)Math.Ceiling(billingDetails.Total_Hours - 4) * billingDetails.fld_Hourly_Rate)+billingDetails.fld_Caterer_Fee).ToString("C", new CultureInfo("en-PH"));
            lbl_Balance.Text = ((billingDetails.fld_Additional_Charge + billingDetails.fld_First4Hrs_Rate + ((decimal)Math.Ceiling(billingDetails.Total_Hours - 4) * billingDetails.fld_Hourly_Rate)+billingDetails.fld_Caterer_Fee) - billingDetails.fld_Amount_Paid).ToString("C", new CultureInfo("en-PH"));
            lbl_Refund_Amount.Text = (billingDetails.fld_Cancellation_Fee).ToString("C", new CultureInfo("en-PH"));

            //lbl_Final_Amount_Paid.Text = (billingDetails.fld_Final_Amount_Paid).ToString("C");
            lbl_Overtime_Fee.Text = billingDetails.fld_Overtime_Fee.ToString("C", new CultureInfo("en-PH"));
            textBox24.Text = (billingDetails.fld_First4Hrs_Rate / 4).ToString("C", new CultureInfo("en-PH"));
            lbl_Total_Amount_2.Text = (billingDetails.fld_Overtime_Fee+billingDetails.fld_Cancellation_Fee).ToString("C", new CultureInfo("en-PH"));




            lbl_Paid_Amount_2.Text = billingDetails.fld_Amount_Paid_Overtime.ToString("C", new CultureInfo("en-PH"));

            lbl_Balance_2.Text = (billingDetails.fld_Overtime_Fee - billingDetails.fld_Amount_Paid_Overtime).ToString("C", new CultureInfo("en-PH"));
            Console.WriteLine(billingDetails.fld_Amount_Paid_Overtime);
        }

        private void HideOvertimeAndRefundDetails(Model_Billing billingDetails)
        {

            decimal Refund_Charge = billingDetails.fld_Amount_Paid;


           


            if (billingDetails.fld_Overtime_Fee == 0 && billingDetails.fld_Cancellation_Fee == 0)
            {

                // Hide all specified controls
                lbl_OR_2.Visible = false;
                OR2.Visible = false;
                tb1.Visible = false;
                tb2.Visible = false;
                tb3.Visible = false;
                tb4.Visible = false;
                tb5.Visible = false;
                tb6.Visible = false;
                tb7.Visible = false;
                tb8.Visible = false;
                tb9.Visible = false;
                tb10.Visible = false;
                tb11.Visible = false;
                tb12.Visible = false;
                lbl_h1.Visible = false;
                lbl_h2.Visible = false;
                tb_Rate_Type.Visible = false;
                tb_Status.Visible = false;
                label34.Visible = false;
           
        
                label45.Visible = false;
                label46.Visible = false;

                lbl_Rate_Type2.Visible = false;
                tb_Extension_Status.Visible = false;








                label19.Visible = true;
                label20.Visible = false;
            
                label27.Visible = false;
           
                label34.Visible = false;
              
                lbl_OT_Hours.Visible = false;
                lbl_OT_Hourly_Charge.Visible = false;
                lbl_Overtime_Fee.Visible = false;
                lbl_Refund_Amount.Visible = false;
                lbl_Total_Amount_2.Visible = false;
                lbl_Paid_Amount_2.Visible = false;
                lbl_Balance_2.Visible = false;
            }
            if (billingDetails.fld_Overtime_Fee > 0)
            {
                tb_Rate_Type.Visible = true;
                tb_Status.Visible = true;
                lbl_OR_2.Visible = (billingDetails.fld_OR_Extension > 0);
                OR2.Visible = true;
                tb1.Visible = true;
                tb2.Visible = true;
                tb3.Visible = true;
                tb4.Visible = true;
                tb5.Visible = true;
                tb6.Visible = true;
                tb7.Visible = true;
                tb8.Visible = true;
                tb9.Visible = false;
                tb10.Visible = true;
                tb11.Visible = true;
                tb12.Visible = true;

                lbl_h1.Visible = true;
                lbl_h2.Visible = true;
 

                label34.Visible = true;
        

                label45.Visible = true;
                label46.Visible = true;
               


                label19.Visible = true;
                label20.Visible = true;
  
                label27.Visible = true;
      
                
                lbl_OT_Hours.Visible = true;
                lbl_OT_Hourly_Charge.Visible = true;
                lbl_Overtime_Fee.Visible = true;
                lbl_Refund_Amount.Visible = false;
                lbl_Total_Amount_2.Visible = true;
                lbl_Paid_Amount_2.Visible = true;
                lbl_Balance_2.Visible = true;
                lbl_Rate_Type2.Visible = true;
                tb_Extension_Status.Visible = true;


            }

            if (billingDetails.fld_Reservation_Status == "Cancelled")
            {
                tb_Rate_Type.Visible = true;
                tb_Status.Visible = true;
                lbl_Rate_Type2.Visible = true;
                tb_Extension_Status.Visible = true;
                lbl_OR_2.Visible = (billingDetails.fld_OR_Extension > 0);
                OR2.Visible = true;
                tb1.Visible = true;
                tb2.Visible = true;
                tb3.Visible = true;
                tb4.Visible = true;
                tb5.Visible = true;
                tb6.Visible = true;
                tb7.Visible = false;
                tb8.Visible = false;
                tb9.Visible = true;
                tb10.Visible = true;
                tb11.Visible = true;
                tb12.Visible = true;

                lbl_h1.Visible = true;
                lbl_h2.Visible = true;


                label34.Visible = true;
     

                label45.Visible = true;
                label46.Visible = true;
     


                label19.Visible = true;
                label20.Visible = true;
   
                label27.Visible = true;
          

                lbl_OT_Hours.Visible = false;
                lbl_OT_Hourly_Charge.Visible = false;
                lbl_Overtime_Fee.Visible = false;
                lbl_Refund_Amount.Visible = true;
                lbl_Total_Amount_2.Visible = true;
                lbl_Paid_Amount_2.Visible = true;
                lbl_Balance_2.Visible = true;
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }



       

        private void btn_Extension_Slip_Click(object sender, EventArgs e)
        {
            using (var extension = new frm_Extension_Slip(_billingDetails.pk_ReservationID))
            {
                extension.ShowDialog();
                // --- AUDIT LOG START ---
                string affectedTable = "tbl_Reservation";
                string affectedRecordPk = _billingDetails.pk_ReservationID.ToString();
                string actionType = "Generated Extension Slip";
                string changedBy = frm_login.LoggedInUserRole;
                DateTime changedAt = DateTime.Now;
                int userId = frm_login.LoggedInUserId;

                // No previous data for slip generation
                string prevDataJson = DBNull.Value.ToString();

                // New data: log the slip generation event
                string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    ControlNumber = _billingDetails.fld_Control_Number,
                    Status = _billingDetails.fld_Reservation_Status,
                    OTHours = _billingDetails.fld_OT_Hours,
                    ORExtension = _billingDetails.fld_OR_Extension
                });

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
                // --- AUDIT LOG END ---
            }
        }

        private void btn_Cancellation_Slip_Click(object sender, EventArgs e)
        {
            using (var cancellation = new frm_Cancellation_Slip(_billingDetails.pk_ReservationID))
            {
                cancellation.ShowDialog();
                // --- AUDIT LOG START ---
                string affectedTable = "tbl_Reservation";
                string affectedRecordPk = _billingDetails.pk_ReservationID.ToString();
                string actionType = "Generated Cancellation Slip";
                string changedBy = frm_login.LoggedInUserRole;
                DateTime changedAt = DateTime.Now;
                int userId = frm_login.LoggedInUserId;

                // Previous data: status before slip generation
                string prevDataJson = DBNull.Value.ToString(); // No previous data for slip generation

                // New data: log the slip generation event
                string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    ControlNumber = _billingDetails.fld_Control_Number,
                    Status = _billingDetails.fld_Reservation_Status,
                    CancellationReason = _billingDetails.fld_Cancellation_Reason
                });

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
                // --- AUDIT LOG END ---
            }
        }

        private void btn_Cancel_Reservation_Click(object sender, EventArgs e)
        {
            using (var cancelForm = new frm_Cancellation_Reason(_billingDetails.pk_ReservationID))
            {
                var result = cancelForm.ShowDialog();
                // If the cancellation was successful, refresh the billing details
                
                    _billingDetails = _repoBilling.GetBillingDetailsByReservationID(_billingDetails.pk_ReservationID);
                    LoadBillingDetails(_billingDetails);
                // --- AUDIT LOG START ---
                string affectedTable = "tbl_Reservation";
                string affectedRecordPk = _billingDetails.pk_ReservationID.ToString();
                string actionType = "Cancelled Reservation";
                string changedBy = frm_login.LoggedInUserRole;
                DateTime changedAt = DateTime.Now;
                int userId = frm_login.LoggedInUserId;

                // Previous data: status is before cancellation
                string prevDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    ControlNumber = _billingDetails.fld_Control_Number,
                    Status = "Confirmed", // or use the actual previous status if you store it
                    CancellationReason = (string)null
                });

                // New data: status is now "Cancelled"
                string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    ControlNumber = _billingDetails.fld_Control_Number,
                    Status = "Cancelled",
                    CancellationReason = _billingDetails.fld_Cancellation_Reason
                });

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
                // --- AUDIT LOG END ---
                RequestBillingRefresh?.Invoke(_billingDetails.pk_ReservationID); // 🔁 Notify parent to refresh billing
                
            }
        }

     
        private async void btn_Confirm_Reservation_Click(object sender, EventArgs e)
        {
            if (_billingDetails.fld_Reservation_Status != "Pending")
            {
                MessageBox.Show("Only 'Pending' reservations can be approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frm_OR orForm = new frm_OR(_billingDetails.pk_ReservationID, _repoBilling))
            {
                DialogResult result = orForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    string officialReceiptNumber = orForm.EnteredORNumber;

                    bool statusUpdateSuccess = await Task.Run(() =>
                        _repoBilling.UpdateReservationStatusAsync(_billingDetails.pk_ReservationID, "Confirmed"));

                    if (statusUpdateSuccess)
                    {
                        // --- AUDIT LOG START ---
                        string affectedTable = "tbl_Reservation";
                        string affectedRecordPk = _billingDetails.pk_ReservationID.ToString();
                        string actionType = "Confirmed a Reservation";
                        string changedBy = frm_login.LoggedInUserRole;
                        DateTime changedAt = DateTime.Now;
                        int userId = frm_login.LoggedInUserId;

                        // Previous data: status is still "Pending"
                        string prevDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                        {
                            ControlNumber = _billingDetails.fld_Control_Number,
                            Status = "Pending",
                            ORNumber = officialReceiptNumber
                        });

                        // New data: status is now "Confirmed"
                        string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                        {
                            ControlNumber = _billingDetails.fld_Control_Number,
                            Status = "Confirmed",
                            ORNumber = officialReceiptNumber
                        });

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
                        // --- AUDIT LOG END ---

                        MessageBox.Show($"Reservation approved successfully with OR# {officialReceiptNumber}.",
                                        "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _billingDetails = _repoBilling.GetBillingDetailsByReservationID(_billingDetails.pk_ReservationID);
                        LoadBillingDetails(_billingDetails);

                        RequestBillingRefresh?.Invoke(_billingDetails.pk_ReservationID); // 🔁 Notify parent to refresh billing
                    }
                    else
                    {
                        MessageBox.Show("Failed to update reservation status to 'Confirmed'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Approval process cancelled or OR Number entry failed.",
                                    "Approval Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Additional_Hourly_Charge_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_OR_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_OT_Hours_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnl_Billing_Details_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
