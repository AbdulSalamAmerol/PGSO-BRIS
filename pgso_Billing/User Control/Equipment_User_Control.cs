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
        public event EventHandler EquipmentBillingUpdated;
        protected virtual void OnEquipmentBillingUpdated()
        {
            EquipmentBillingUpdated?.Invoke(this, EventArgs.Empty);
        }

        private Repo_Billing repo_billing = new Repo_Billing();
        private Model_Billing _billingDetails;
        public Equipment_User_Control(Model_Billing billingDetailsList)
        {
            InitializeComponent();
            _billingDetails = billingDetailsList; // Store the passed-in model
            LoadBillingDetails(billingDetailsList);
            LoadBillingDetails(_billingDetails);  // Reload the data after deletion
        }

        public void LoadBillingDetails(Model_Billing billingDetailsList)
        {
            pnl_Billing_Details.Visible = true;

            try
            {
                var reservationID = billingDetailsList.pk_ReservationID;
                // Fetch equipment reservation records
                var equipmentDetails = repo_billing.GetEquipmentBillingDetailsByReservationID(reservationID);

                if (equipmentDetails == null )
                {
                    dgv_Equipment_Billing_Records.DataSource = null;
                    MessageBox.Show("No equipment reservations found for this billing.");
                    return;
                }
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
            lbl_Reservation_Status.Text = billingDetailsList.fld_Reservation_Status;
            lbl_fld_Total_Amount.Text = billingDetailsList.fld_Total_Amount.ToString("C");  
        }
        private void btn_Add_Equipment_Billing_Click(object sender, EventArgs e)
        {
            int reservationID = _billingDetails.pk_ReservationID;

            using (var form = new pgso.pgso_Billing.Forms.frm_Add_Equipment_Billing(reservationID))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Refresh equipment list
                    var updatedEquipment = repo_billing.GetEquipmentBillingDetailsByReservationID(reservationID);
                    dgv_Equipment_Billing_Records.DataSource = updatedEquipment;

                    // Refresh billing details in the user control
                    _billingDetails = repo_billing.GetBillingDetailsByReservationID(reservationID);
                    LoadBillingDetails(_billingDetails);

                    // 🔥 Notify parent form
                    EquipmentBillingUpdated?.Invoke(this, EventArgs.Empty);
                }
            }
        }



        private void btn_Delete_Equipment_Billing_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (dgv_Equipment_Billing_Records.SelectedRows.Count > 0)
                {
                    // Retrieve the pk_Reservation_EquipmentID from the selected row
                    int reservationEquipmentID = Convert.ToInt32(dgv_Equipment_Billing_Records.SelectedRows[0].Cells["col_Reservation_EquipmentID"].Value);
                    int reservationID = _billingDetails.pk_ReservationID;  // Retrieve the ReservationID for total amount update

                    // Ask for confirmation before deleting
                    var confirmation = MessageBox.Show("Are you sure you want to delete this equipment reservation?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmation == DialogResult.Yes)
                    {
                        // Call a method to delete the record from the database
                        bool success = repo_billing.DeleteEquipmentReservation(reservationEquipmentID);

                        if (success)
                        {
                            MessageBox.Show("✅ Equipment reservation deleted successfully.");

                            // Update the total amount for the reservation
                            bool updateSuccess = repo_billing.UpdateReservationTotalAmount(reservationID);

                            if (updateSuccess)
                            {
                                MessageBox.Show("✅ Reservation total amount updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("⚠️ Failed to update reservation total amount.");
                            }

                            // Re-fetch the updated billing details to refresh the label
                            _billingDetails = repo_billing.GetBillingDetailsByReservationID(reservationID);  // You need a method to fetch the updated billing details
                            LoadBillingDetails(_billingDetails);  // Refresh everything, including the total amount label
                        }
                        else
                        {
                            MessageBox.Show("⚠️ Failed to delete equipment reservation. No More Equipment Reservation to Delete. ");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("⚠️ Please select a row to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
            OnEquipmentBillingUpdated();
        }
    }
}