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

        public frm_Extend_Venue(int reservationID)
        {
            InitializeComponent();
            _reservationID = reservationID;
        }

        private async void btn_Extend_Venue_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate OR Extension
                string orExtension = lbl_OR_Extension.Text.Trim();
                if (string.IsNullOrEmpty(orExtension))
                {
                    MessageBox.Show("Please enter a valid OR number for the extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if extension already exists
                bool alreadyExtended = await repo_Billing.CheckIfAlreadyExtended(_reservationID);
                if (alreadyExtended)
                {
                    MessageBox.Show("This reservation has already been extended and has an OR number.", "Extension Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate Hours
                if (string.IsNullOrEmpty(lbl_Extend_Venue.Text) || !decimal.TryParse(lbl_Extend_Venue.Text, out decimal inputHours))
                {
                    MessageBox.Show("Please enter a valid number for extended hours.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int roundedHours = (int)Math.Ceiling(inputHours);

                // Update
                var result = await repo_Billing.UpdateReservationExtension(_reservationID, roundedHours, orExtension); // include OR
                if (result)
                {
                    MessageBox.Show("Reservation extended successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnExtensionSuccessful?.Invoke();
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


    }
}
