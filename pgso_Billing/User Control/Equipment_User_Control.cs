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
using static iText.Kernel.Pdf.Colorspace.PdfPattern;

namespace pgso.pgso_Billing.User_Control
{
    public partial class Equipment_User_Control : UserControl
    {
        private Repo_Billing repo_billing = new Repo_Billing();

        public Equipment_User_Control(Model_Billing billingDetailsList)
        {
            InitializeComponent();
            LoadBillingDetails(billingDetailsList);
        }

        public void LoadBillingDetails(Model_Billing billingDetailsList)
        {
            pnl_Billing_Details.Visible = true;

            try
            {
                var reservationID = billingDetailsList.pk_ReservationID;

                // Fetch equipment reservation records
                //var equipmentDetails = repo_billing.GetBillingDetailsByReservationID(reservationID);
                var equipmentDetails = repo_billing.GetEquipmentBillingDetailsByReservationID(reservationID);

                if (equipmentDetails == null )
                {
                    dgv_Equipment_Billing_Records.DataSource = null;
                    MessageBox.Show("No equipment reservations found for this billing.");
                    return;
                }

                // Optional: Group or format if needed


                // Bind to DataGridView
                dgv_Equipment_Billing_Records.AutoGenerateColumns = false; // Disable auto-generation of columns
                BindingSource equipmentBindingSource = new BindingSource();
                equipmentBindingSource.DataSource = equipmentDetails;
                dgv_Equipment_Billing_Records.DataSource = equipmentBindingSource;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load equipment billing details: " + ex.Message);
            }


        
            lbl_Control_Number.Text = billingDetailsList.fld_Control_Number;

            lbl_Requesting_Person.Text = $"{billingDetailsList.fld_First_Name} {billingDetailsList.fld_Middle_Name} {billingDetailsList.fld_Surname}";
            lbl_Requesting_Office.Text = billingDetailsList.fld_Requesting_Person_Address;
            lbl_Origin_Request.Text = billingDetailsList.fld_Request_Origin;
            lbl_Contact_Number.Text = billingDetailsList.fld_Contact_Number;
            lbl_Address.Text = billingDetailsList.fld_Requesting_Person_Address;

      
            lbl_Reservation_Dates.Text = $"{billingDetailsList.fld_Start_Date.ToString("MM/dd/yyyy")} - {billingDetailsList.fld_End_Date.ToString("MM/dd/yyyy")}";

         
            lbl_Rate_Type.Text = billingDetailsList.fld_Rate_Type;
         
        }
    }
}