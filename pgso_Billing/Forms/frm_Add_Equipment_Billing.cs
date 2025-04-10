using pgso.Billing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Add_Equipment_Billing : Form
    {
        private int _reservationID;
        private Repo_Billing _repo = new Repo_Billing();

        public frm_Add_Equipment_Billing(int reservationID)
        {
            InitializeComponent();
            _reservationID = reservationID;
            LoadEquipmentDropdown();
        }

        private void frm_Add_Equipment_Billing_Load(object sender, EventArgs e)
        {
            LoadEquipmentDropdown();
        }

        private void LoadEquipmentDropdown()
        {
            var equipmentList = _repo.GetAllEquipments(); // Get a list of { pk_EquipmentID, fld_Equipment_Name }
            cmb_Equipment.DisplayMember = "fld_Equipment_Name";
            cmb_Equipment.ValueMember = "pk_EquipmentID";
            cmb_Equipment.DataSource = equipmentList;
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
                        MessageBox.Show("⚠️ No pricing found for the selected equipment.");
                    }
                }
                else
                {
                    MessageBox.Show("⚠️ Please select a valid equipment item.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int equipmentID = Convert.ToInt32(cmb_Equipment.SelectedValue);
                int quantity = (int)num_Quantity.Value;
                int days = (int)num_Days.Value;

                // Fetch pricing for the selected equipment using the new method
                var pricing = _repo.GetEquipmentPricingByEquipmentID(equipmentID);
                decimal totalCost = 0;

                if (pricing != null)
                {
                    // Calculate total cost using the formula
                    totalCost = (pricing.fld_Equipment_Price * quantity) +
                                (pricing.fld_Equipment_Price_Subsequent * (days - 1) * quantity);
                }

                // Add the equipment reservation
                bool success = _repo.AddEquipmentReservation(_reservationID, equipmentID, pricing.pk_Equipment_PricingID, quantity, days, totalCost);

                if (success)
                {
                    // Update the total amount in tbl_Reservation for the current reservation
                    bool updateSuccess = _repo.UpdateReservationTotalAmount(_reservationID);

                    if (updateSuccess)
                    {
                        MessageBox.Show("✅ Equipment reservation added successfully, and total amount updated.");
                    }
                    else
                    {
                        MessageBox.Show("⚠️ Equipment reservation added, but failed to update total amount.");
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("⚠️ Failed to add equipment reservation.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
        }




    }
}
