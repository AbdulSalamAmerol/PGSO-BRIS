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

                // Validate OR Extension
                if (!int.TryParse(orExtensionText, out int orExtensionInt))
                {
                    MessageBox.Show("Please enter a valid numeric OR number for the extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Hours
                if (string.IsNullOrEmpty(extendHoursText) || !decimal.TryParse(extendHoursText, out decimal inputHours))
                {
                    MessageBox.Show("Please enter a valid number for extended hours.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int roundedHours = (int)Math.Ceiling(inputHours);

                // Update reservation with the new hours and OR number
                var result = await repo_Billing.UpdateReservationExtension(_reservationID, roundedHours, orExtensionInt);
                if (result)
                {
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
