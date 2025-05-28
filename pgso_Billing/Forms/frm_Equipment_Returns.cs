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

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Equipment_Returns : Form
    {
        private Model_Billing _selectedEquipment;
        private Repo_Billing repo_billing = new Repo_Billing();

        public event Action OnEquipmentReturned;

        public frm_Equipment_Returns(Model_Billing selectedEquipment)
        {
            InitializeComponent();
            _selectedEquipment = selectedEquipment;

            tb_Equipment.Text = _selectedEquipment.fld_Equipment_Name;
            tb_Quantity.Text = _selectedEquipment.fld_Quantity.ToString();
            tb_Returned.Text = _selectedEquipment.fld_Quantity_Returned.ToString();
            this.Load += frm_Equipment_Returns_Load;

        }

        private void frm_Equipment_Returns_Load(object sender, EventArgs e)
        {

            tb_Equipment.Text = _selectedEquipment.fld_Equipment_Name;
            tb_Quantity.Text = _selectedEquipment.fld_Quantity.ToString();

            int alreadyReturned = _selectedEquipment.fld_Quantity_Returned;
            int damaged = _selectedEquipment.fld_Quantity_Damaged;
            int totalReturned = alreadyReturned + damaged;

            tb_Returned.Text = totalReturned.ToString();

            // Calculate deficit
            int totalIssued = _selectedEquipment.fld_Quantity;
            int returnDeficit = totalIssued - totalReturned;

            tb_Return_Deficit.Text = returnDeficit.ToString();
        }


        private async void btn_SubmitReturn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_Return_Now.Text, out int returnNow) || returnNow < 0)
            {
                MessageBox.Show("Enter a valid quantity to return.");
                return;
            }

            if (!int.TryParse(tb_Damaged.Text, out int damaged) || damaged < 0)
            {
                MessageBox.Show("Enter a valid damaged quantity.");
                return;
            }

            int alreadyReturned = _selectedEquipment.fld_Quantity_Returned;
            int alreadyDamaged = _selectedEquipment.fld_Quantity_Damaged;
            int totalAlreadyReturned = alreadyReturned + alreadyDamaged;
            int maxReturnable = _selectedEquipment.fld_Quantity - totalAlreadyReturned;

            if ((returnNow + damaged) > maxReturnable)
            {
                MessageBox.Show($"You cannot return more than {maxReturnable} remaining items.");
                return;
            }

            bool success = await repo_billing.UpdateEquipmentReturnAsync(
                _selectedEquipment.pk_Reservation_EquipmentID, returnNow, damaged);

            if (success)
            {
                MessageBox.Show("Return updated successfully.");
                OnEquipmentReturned?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update return.");
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
