using pgso.Billing.Repositories;
using pgso.Billing.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;
using pgso.pgso_Billing.Forms;
using System.Drawing;
using pgso.Properties;
using System.IO;
using System.Threading.Tasks;

namespace pgso.pgso_Billing
{
    public partial class Venue_User_Control : UserControl
    {
       
        public event Action<int?> RequestBillingRefresh;
        private Model_Billing _billingDetails;
        // Constructor that accepts Model_Billing
        public Venue_User_Control(Model_Billing billingDetails)
        {
            InitializeComponent();
            _billingDetails = billingDetails; // ✅ Store for later use
            LoadBillingDetails(billingDetails); // Populate the fields on creation
        }


        private void btn_Change_Reservation_info_Click(object sender, EventArgs e)
        {
            // ✅ Only allow if status is Confirmed or Pending
            if (_billingDetails.fld_Reservation_Status != "Confirmed" && _billingDetails.fld_Reservation_Status != "Pending")
            {
                MessageBox.Show("Reservation Information Adjustment Error. ",
                                "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                // 🔔 Trigger refresh event to inform frm_Billing
                RequestBillingRefresh?.Invoke(_billingDetails.pk_ReservationID);
            }
        }





        // Method to load billing details into the controls
        public void LoadBillingDetails(Model_Billing billingDetails)
        {
            pnl_Billing_Details.Visible = true;

            // Populate the labels with values from the billingDetails model
            lbl_Control_Number.Text = billingDetails.fld_Control_Number;
            lbl_Activity_Name.Text = billingDetails.fld_Activity_Name;
            lbl_Requesting_Person.Text = $"{billingDetails.fld_First_Name} {billingDetails.fld_Middle_Name} {billingDetails.fld_Surname}";
            lbl_Requesting_Office.Text = billingDetails.fld_Requesting_Office;
            lbl_Origin_Request.Text = billingDetails.fld_Request_Origin;
            lbl_Contact_Number.Text = billingDetails.fld_Contact_Number;
            lbl_Address.Text = billingDetails.fld_Requesting_Person_Address;

            // Format reservation dates (start and end)
            lbl_Reservation_Dates.Text = $"{billingDetails.fld_Start_Date.ToString("MM/dd/yyyy")} - {billingDetails.fld_End_Date.ToString("MM/dd/yyyy")}";

            // Format reservation times (start and end)
            lbl_Reservation_Time.Text = $"{billingDetails.fld_Start_Time.ToString(@"hh\:mm")} - {billingDetails.fld_End_Time.ToString(@"hh\:mm")}";

            lbl_Number_Of_Participants.Text = billingDetails.fld_Number_Of_Participants.ToString();
            lbl_Reservation_Status.Text = billingDetails.fld_Reservation_Status;

            // Venue details
            lbl_Venue_Name.Text = billingDetails.fld_Venue_Name;
            lbl_Venue_Scope.Text = billingDetails.fld_Venue_Scope_Name;
            lbl_Rate_Type.Text = billingDetails.fld_Rate_Type;
            lbl_Is_Aircon.Text = billingDetails.fld_Aircon ? "Yes" : "No";

            // Venue pricing details (based on hourly charges, etc.)
            lbl_Base_Charge_Amount.Text = billingDetails.fld_First4Hrs_Rate.ToString("C");
            lbl_Additional_Hourly_Charge.Text = billingDetails.fld_Hourly_Rate.ToString("C");
            lbl_Additional_Charge.Text = billingDetails.fld_Additional_Charge.ToString("C");
            lbl_Total_Hour.Text = (billingDetails.Total_Hours - 4).ToString("F0");
            lbl_Additional_Hours_Amount.Text = (billingDetails.fld_Hourly_Rate * (decimal)(billingDetails.Total_Hours - 4)).ToString("C");

            // If you are showing equipment details (if available)
            lbl_Venue_Name_Transact.Text = billingDetails.fld_Venue_Name;
            lbl_Venue_Scope_Transact.Text = billingDetails.fld_Venue_Scope_Name;

            // Calculated charges based on overtime
            lbl_OT_Hours.Text = billingDetails.fld_OT_Hours.ToString();
            lbl_OT_Hourly_Charge.Text = billingDetails.fld_Hourly_Rate.ToString("C");
            lbl_Overtime_Fee.Text = (billingDetails.fld_OT_Hours * billingDetails.fld_Hourly_Rate).ToString("C");

            // Payment details
            lbl_Paid_Amount.Text = billingDetails.fld_Amount_Paid.ToString("C");
            lbl_Paid_Amount_2.Text = billingDetails.fld_Amount_Paid.ToString("C");
            lbl_Total_Amount.Text = billingDetails.fld_Total_Amount.ToString("C");
            lbl_Balance.Text = (billingDetails.fld_Total_Amount - billingDetails.fld_Amount_Paid).ToString("C");
            lbl_Refund_Amount.Text = (billingDetails.fld_Refund_Amount != 0 && billingDetails.fld_Refund_Amount != null)
                        ? " - " + billingDetails.fld_Refund_Amount.ToString("C")
                        : billingDetails.fld_Refund_Amount.ToString("C");

            lbl_Final_Amount_Paid.Text = billingDetails.fld_Final_Amount_Paid.ToString("C");

            lbl_Overtime_Fee.Text = billingDetails.fld_Overtime_Fee.ToString("C");

            
        }

       
    }

}
