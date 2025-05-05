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
                    // Check if OR extension is 0 or less
                    if (billingData.fld_OR_Extension <= 0)
                        tb_OR_Extension.Text = "Enter Official Receipt";
                    else
                        tb_OR_Extension.Text = billingData.fld_OR_Extension.ToString();

                    tb_Extend_Venue.Text = billingData.fld_OT_Hours.ToString();

                    // Disable the textbox if no OT hours exist
                    if (billingData.fld_OT_Hours <= 0)
                    {
                        tb_Extend_Venue.ReadOnly = true;
                        tb_Extend_Venue.TabStop = false;
                    }
                  

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

                int orExtensionInt = 0; // Default value

                // Try parsing the input, but don't show an error message if it fails
                if (!int.TryParse(orExtensionText, out orExtensionInt))
                {
                    // If parsing fails, the value will remain 0 (default behavior)
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
