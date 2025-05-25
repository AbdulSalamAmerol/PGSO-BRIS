using pgso.Billing.Models;
using pgso.Billing.Repositories;
using pgso.pgso_Billing.Forms;
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

// WHAT TO ADD NEXT

namespace pgso.pgso_Billing.User_Control
{
    public partial class Equipment_User_Control : UserControl
    {
        public event EventHandler EquipmentBillingUpdated;
        private Repo_Billing _repoBilling; // ✅ Add this field
        public event Action<int?> RequestBillingRefresh;


        protected virtual void OnEquipmentBillingUpdated()

        {
            EquipmentBillingUpdated?.Invoke(this, EventArgs.Empty);
        }

        private Repo_Billing repo_billing = new Repo_Billing();
        private Model_Billing _billingDetails;
        public Equipment_User_Control(Model_Billing billingDetailsList, Repo_Billing repoBilling)
        {
            InitializeComponent();
            btn_Add_Equipment_Billing.ForeColor = Color.FromArgb(242, 239, 231);
            _billingDetails = billingDetailsList; // Store the passed-in model
            _repoBilling = repoBilling; // ✅ Store the repository
            LoadBillingDetails(billingDetailsList);
            LoadBillingDetails(_billingDetails);  // Reload the data after deletion
        }

        public void LoadBillingDetails(Model_Billing billingDetailsList)
        {
            pnl_Billing_Details.Visible = true;
        
            btn_Delete_Equipment_Billing.Enabled = (billingDetailsList.fld_Reservation_Status == "Pending");
            btn_Add_Equipment_Billing.Enabled = (billingDetailsList.fld_Reservation_Status == "Pending");
            btn_Return.Enabled = (billingDetailsList.fld_Reservation_Status == "Confirmed");


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

            bool showOR = billingDetailsList.fld_OR != null && billingDetailsList.fld_OR != 0;
            lbl_OR.Visible = tb_OR.Visible = showOR;

            if (showOR)
            {
                lbl_OR.Text = billingDetailsList.fld_OR.ToString();
            }
            // First, center align *everything* by default
            dgv_Equipment_Billing_Records.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Equipment_Billing_Records.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Then, set only the first column (index 0) to be left-aligned
            if (dgv_Equipment_Billing_Records.Columns.Count > 0)
            {
                dgv_Equipment_Billing_Records.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
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

        private void btn_Return_Click(object sender, EventArgs e)
        {
            if (dgv_Equipment_Billing_Records.CurrentRow == null)
            {
                MessageBox.Show("Please select a row first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected equipment reservation
            var selectedBilling = dgv_Equipment_Billing_Records.CurrentRow.DataBoundItem as Model_Billing;

            if (selectedBilling == null)
            {
                MessageBox.Show("Unable to retrieve equipment details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm_Equipment_Returns returnForm = new frm_Equipment_Returns(selectedBilling);
            returnForm.OnEquipmentReturned += () =>
            {
                LoadBillingDetails(_billingDetails); // refresh display
            };
            returnForm.ShowDialog();
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

        private void btn_Cancel_Reservation_Click(object sender, EventArgs e)
        {
            using (var cancelForm = new frm_Cancellation_Reason(_billingDetails.pk_ReservationID))
            {
                // 🔗 Wire the event from the form to this control
                cancelForm.RequestBillingRefresh += (reservationId) =>
                {
                    var updatedDetails = new Repo_Billing().GetBillingDetailsByReservationID(reservationId ?? _billingDetails.pk_ReservationID);
                    if (updatedDetails != null)
                    {
                        _billingDetails = updatedDetails;
                        LoadBillingDetails(_billingDetails);
                        RequestBillingRefresh?.Invoke(_billingDetails.pk_ReservationID); // Notify frm_Billing
                    }
                };

                var result = cancelForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var returnSlip = new frm_Return_Slip(_billingDetails.pk_ReservationID))
            {
                returnSlip.ShowDialog();
            }
        }

        private void btn_Confirm_Reservation_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Reservation_Click_1(object sender, EventArgs e)
        {

        }
    }
}