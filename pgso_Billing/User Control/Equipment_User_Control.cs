﻿using pgso.Billing.Models;
using pgso.Billing.Repositories;
using pgso.pgso_Billing.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.Kernel.Pdf.Colorspace.PdfPattern;
using System.Globalization;

// WHAT TO ADD NEXT

namespace pgso.pgso_Billing.User_Control
{
    public partial class Equipment_User_Control : UserControl
    {
        public event EventHandler EquipmentBillingUpdated;
        private Repo_Billing _repoBilling; //  Add this field
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
            dgv_Equipment_Billing_Records.CellValueChanged += dgv_Equipment_Billing_Records_CellValueChanged;
            dgv_Equipment_Billing_Records.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgv_Equipment_Billing_Records.IsCurrentCellDirty)
                {
                    dgv_Equipment_Billing_Records.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };
            btn_Add_Equipment_Billing.ForeColor = Color.FromArgb(242, 239, 231);
            _billingDetails = billingDetailsList; // Store the passed-in model
            _repoBilling = repoBilling; //  Store the repository
            LoadBillingDetails(billingDetailsList);
            LoadBillingDetails(_billingDetails);  // Reload the data after deletion
        }

        private void dgv_Equipment_Billing_Records_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            var row = dgv_Equipment_Billing_Records.Rows[e.RowIndex];

            try
            {
                int qty = Convert.ToInt32(row.Cells["col_Quantity"].Value ?? 0);
                int returned = Convert.ToInt32(row.Cells["col_Quantity_Returned"].Value ?? 0);
                int damaged = Convert.ToInt32(row.Cells["col_Quantity_Damaged"].Value ?? 0);
                int unreturned = qty - (returned + damaged);

                row.Cells["col_Unreturned"].Value = unreturned;
            }
            catch
            {
                // Optional: Show error or ignore if invalid input
            }
        }


        public void LoadBillingDetails(Model_Billing billingDetailsList)
        {
            pnl_Billing_Details.Visible = true;

            btn_Delete_Equipment_Billing.Enabled = (billingDetailsList.fld_Reservation_Status == "Pending");
            btn_Add_Equipment_Billing.Enabled = (billingDetailsList.fld_Reservation_Status == "Pending");
            btn_Return.Enabled = (billingDetailsList.fld_Reservation_Status == "Confirmed");
            btn_Edit.Enabled = (billingDetailsList.fld_Reservation_Status == "Pending");
            btn_Confirm_Reservation.Enabled = (billingDetailsList.fld_Reservation_Status == "Pending");
            btn_Cancel_Reservation.Enabled = (billingDetailsList.fld_Reservation_Status == "Pending" || billingDetailsList.fld_Reservation_Status == "Confirmed");
            try
            {
                var reservationID = billingDetailsList.pk_ReservationID;
                // Fetch equipment reservation records
                var equipmentDetails = repo_billing.GetEquipmentBillingDetailsByReservationID(reservationID);

                if (equipmentDetails == null)
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
                foreach (DataGridViewRow row in dgv_Equipment_Billing_Records.Rows)
                {
                    if (row.IsNewRow) continue;

                    int qty = Convert.ToInt32(row.Cells["col_Quantity"].Value ?? 0);
                    int returned = Convert.ToInt32(row.Cells["col_Quantity_Returned"].Value ?? 0);
                    int damaged = Convert.ToInt32(row.Cells["col_Quantity_Damaged"].Value ?? 0);
                    int unreturned = qty - (returned + damaged);

                    row.Cells["col_Unreturned"].Value = unreturned;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load equipment billing details: " + ex.Message);
            }
            lbl_Control_Number.Text = billingDetailsList.fld_Control_Number;
            lbl_Requesting_Person.Text = $"{billingDetailsList.fld_First_Name} {billingDetailsList.fld_Middle_Name} {billingDetailsList.fld_Surname}";
            lbl_Requesting_Office.Text = billingDetailsList.fld_Requesting_Office;
            lbl_Origin_Request.Text = billingDetailsList.fld_Request_Origin;
            lbl_Contact_Number.Text = billingDetailsList.fld_Contact_Number;
            lbl_Address.Text = billingDetailsList.fld_Requesting_Person_Address;
            lbl_Activity_Name.Text = billingDetailsList.fld_Activity_Name;
            lbl_Reservation_Dates.Text = $"{billingDetailsList.fld_Start_Date.ToString("MM/dd/yyyy")} - {billingDetailsList.fld_End_Date.ToString("MM/dd/yyyy")}";
            lbl_Reservation_Status.Text = billingDetailsList.fld_Reservation_Status;
            lbl_fld_Total_Amount.Text = billingDetailsList.fld_Total_Amount.ToString("C", new CultureInfo("en-PH"));

            if (billingDetailsList.fld_OR == 0)
            {
                lbl_OR.Visible = false; // hides the label entirely
            }
            else
            {
                lbl_OR.Text = billingDetailsList.fld_OR.ToString();
                lbl_OR.Visible = true;
            }
            lbl_OR.Visible = billingDetailsList.fld_OR != null;
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
                            MessageBox.Show("Equipment reservation deleted successfully.");

                            // Update the total amount for the reservation
                            bool updateSuccess = repo_billing.UpdateReservationTotalAmount(reservationID);

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
                        _billingDetails = _repoBilling.GetBillingDetailsByReservationID(_billingDetails.pk_ReservationID);
                        LoadBillingDetails(_billingDetails);

                        RequestBillingRefresh?.Invoke(_billingDetails.pk_ReservationID); //Notify parent to refresh billing

                    }
                    else
                    {
                        MessageBox.Show("Failed to update reservation status to 'Confirmed'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btn_Cancel_Reservation_Click(object sender, EventArgs e)
        {
            var repo = new Repo_Billing();
            bool allReturnedOrDamaged = repo.IsAllEquipmentReturnedOrDamaged(_billingDetails.pk_ReservationID);

            if (!allReturnedOrDamaged && (_billingDetails.fld_Reservation_Status != "Pending"))
            {
                MessageBox.Show("Cannot cancel reservation. All equipment must be returned or reported as damaged.",
                                "Cancellation Blocked",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var cancelForm = new frm_Cancellation_Reason(_billingDetails.pk_ReservationID))
            {
                cancelForm.RequestBillingRefresh += (reservationId) =>
                {
                    var updatedDetails = repo.GetBillingDetailsByReservationID(reservationId ?? _billingDetails.pk_ReservationID);
                    if (updatedDetails != null)
                    {
                        _billingDetails = updatedDetails;
                        LoadBillingDetails(_billingDetails);
                        RequestBillingRefresh?.Invoke(_billingDetails.pk_ReservationID);
                    }
                };

                cancelForm.ShowDialog();
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

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Control_Number_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_Equipment_Billing_Records.CurrentRow?.DataBoundItem is Model_Billing selectedItem)
            {
                if (selectedItem.pk_Reservation_EquipmentID <= 0)
                {
                    MessageBox.Show("Invalid record selected.");
                    return;
                }
                var editForm = new frm_Edit_Equipment_Billing(selectedItem.pk_Reservation_EquipmentID.Value);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    int reservationID = _billingDetails.pk_ReservationID;

                    // ito yung equipment billing grid
                    var updatedEquipment = repo_billing.GetEquipmentBillingDetailsByReservationID(reservationID);
                    dgv_Equipment_Billing_Records.DataSource = updatedEquipment;
                    // Ito yung billing details object
                    _billingDetails = repo_billing.GetBillingDetailsByReservationID(reservationID);
                    // Refresh namn sa UI
                    LoadBillingDetails(_billingDetails);
                    // Ping parent refresh
                    EquipmentBillingUpdated?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                MessageBox.Show("Please select an equipment record to edit.");
            }
        }

        private void btn_Complete_Reservation_Click(object sender, EventArgs e)
        {
            if (_billingDetails == null)
            {
                MessageBox.Show("Reservation details are missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
       
            MessageBox.Show($@"
                Rate Type: {_billingDetails.fld_Rate_Type}
                Status: {_billingDetails.fld_Reservation_Status}
                End Date: {_billingDetails.fld_End_Date}
                Confirmation Date: {_billingDetails.fld_Confirmation_Date}
                OR: {_billingDetails.fld_OR}
                OT Hours: {_billingDetails.fld_OT_Hours}
                OR Extension: {_billingDetails.fld_OR_Extension}
                Quantity : {_billingDetails.fld_Quantity}
                Quantity Returned: {_billingDetails.fld_Quantity_Returned}
                Quantity Damaged: {_billingDetails.fld_Quantity_Damaged}
                ", "Debug Values");
         
            bool isPGNV = _billingDetails.fld_Rate_Type.Equals("PGNV", StringComparison.OrdinalIgnoreCase);
   
            
                if (_billingDetails.fld_Reservation_Status != "Confirmed")
                {
                    MessageBox.Show("Only reservations with 'Confirmed' status can be completed.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!_billingDetails.fld_Confirmation_Date.HasValue)
                {
                    MessageBox.Show("Cannot complete reservation without a confirmation date.", "Missing Confirmation Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                /*if (DateTime.Now <= _billingDetails.fld_End_Date)
                {
                    MessageBox.Show("Reservation has not ended yet. It can only be completed after the end date.", "Too Early", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/

                if (_billingDetails.fld_OR == null || _billingDetails.fld_OR <= 0)
                {
                    MessageBox.Show("A valid Official Receipt (OR) number is required to complete the reservation.", "Missing OR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_billingDetails.fld_OT_Hours > 0)
                {
                    if (_billingDetails.fld_OR_Extension == null || _billingDetails.fld_OR_Extension <= 0)
                    {
                        MessageBox.Show("Overtime exists, but no valid OR for extension found.", "Missing OR for Overtime", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            if (!_billingDetails.fld_Rate_Type.Equals("PGNV", StringComparison.OrdinalIgnoreCase))
            {
                bool allReturned = _repoBilling.AreAllEquipmentReturnedOrDamaged(_billingDetails.pk_ReservationID);
                if (!allReturned)
                {
                    MessageBox.Show("All equipment must be returned or accounted for before completing this reservation.",
                                    "Incomplete Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }



            //  All validations passed — mark as completed
            bool success = _repoBilling.MarkReservationAsCompleted(_billingDetails.pk_ReservationID);
            if (success)
            {
                MessageBox.Show("Reservation marked as Completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RequestBillingRefresh?.Invoke(_billingDetails.pk_ReservationID); // 🔁 Trigger UI refresh
            }
            else
            {
                MessageBox.Show("Failed to mark reservation as Completed. It may already be completed or cancelled.", "No Action Taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }
