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

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Edit_Equipment_Billing : Form
    {
        private int _reservationEquipmentID;
        private Repo_Billing _repo = new Repo_Billing();

        public frm_Edit_Equipment_Billing(int reservationEquipmentID)
        {
            InitializeComponent();
            _reservationEquipmentID = reservationEquipmentID;
            this.Load += new System.EventHandler(this.frm_Edit_Equipment_Billing_Load);
    
        }



        private void frm_Edit_Equipment_Billing_Load(object sender, EventArgs e)
        {
            LoadEquipmentDropdown();
            LoadExistingReservation();
            LoadInventory();
        }

        private void LoadInventory()
        {
            var inventory = _repo.GetAllEquipmentInventory();
            dgv_Equipment_Inventory.DataSource = inventory;
        }

        private void LoadEquipmentDropdown()
        {
            var equipmentList = _repo.GetAllEquipments(); // Same as Add
            cmb_Equipment.DisplayMember = "fld_Equipment_Name";
            cmb_Equipment.ValueMember = "pk_EquipmentID";
            cmb_Equipment.DataSource = equipmentList;
        }

        private void LoadExistingReservation()
        {
            var reservation = _repo.GetEquipmentReservationByID(_reservationEquipmentID);
            if (reservation == null)
            {
                MessageBox.Show("Failed to load reservation details.");
                this.Close();
                return;
            }

            cmb_Equipment.SelectedValue = reservation.fk_EquipmentID;
            num_Quantity.Value = reservation.fld_Quantity;
            dtp_Start_Date_Eq.Value = reservation.fld_Start_Date_Eq;
            dtp_End_Date_Eq.Value = reservation.fld_End_Date_Eq;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int equipmentID = Convert.ToInt32(cmb_Equipment.SelectedValue);
                int quantity = (int)num_Quantity.Value;
                DateTime start = dtp_Start_Date_Eq.Value.Date;
                DateTime end = dtp_End_Date_Eq.Value.Date;
                int days = (end - start).Days + 1;

                if (start > end)
                {
                    MessageBox.Show("Start date cannot be after end date.");
                    return;
                }

                var pricing = _repo.GetEquipmentPricingByEquipmentID(equipmentID);
                if (pricing == null)
                {
                    MessageBox.Show("Pricing not found.");
                    return;
                }

                decimal totalCost = (pricing.fld_Equipment_Price * quantity) +
                                    (pricing.fld_Equipment_Price_Subsequent * (days - 1) * quantity);

                bool success = _repo.UpdateEditEquipmentReservation(
                    _reservationEquipmentID,
                    equipmentID,
                    pricing.pk_Equipment_PricingID,
                    quantity,
                    days,
                    totalCost,
                    start,
                    end
                );

                if (success)
                {
                    int reservationID = _repo.GetReservationIDFromEquipmentReservation(_reservationEquipmentID);
                    _repo.UpdateReservationTotalAmount(reservationID);

                    MessageBox.Show("Updated successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmb_Equipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Ensure something is selected in the combo box
                if (cmb_Equipment.SelectedValue is int selectedEquipmentID)
                {
                    // Fetch pricing for the selected equipment
                    var pricing = _repo.GetEquipmentPricingByEquipmentID(selectedEquipmentID);

                    // If pricing data is available
                    if (pricing != null)
                    {
                        // Update textboxes with the fetched pricing details
                        lbl_Standard_Price.Text = pricing.fld_Equipment_Price.ToString("C");
                        lbl_Subsequent_Price.Text = pricing.fld_Equipment_Price_Subsequent.ToString("C");
                    }
                    else
                    {
                        MessageBox.Show(" No pricing found for the selected equipment.");
                    }
                }
                else
                {
                    MessageBox.Show(" Please select a valid equipment item.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }
        }
        private void frm_Add_Equipment_Billing_Load_1(object sender, EventArgs e)
        {
            this.tbl_EquipmentTableAdapter1.Fill(this._BRIS_EXPERIMENT_3_0DataSet1.tbl_Equipment);
            this.tbl_EquipmentTableAdapter.Fill(this._BRIS_EXPERIMENT_3_0DataSet.tbl_Equipment);

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
