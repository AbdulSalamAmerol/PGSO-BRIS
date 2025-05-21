using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pgso.Billing.Repositories;
using pgso.Billing.Models;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_OR : Form
    {
        private readonly int _reservationId;
        private readonly Repo_Billing _repository;
        public string EnteredORNumber { get; private set; }

        public frm_OR(int reservationId, Repo_Billing repository)
        {
            InitializeComponent();
            // Argument validation...
            _reservationId = reservationId;
            _repository = repository;
        }

        private void btn_OR_Confirm_Click(object sender, EventArgs e)
        {
            // Trim whitespace from input
            string orNumber = txtORNumber.Text.Trim();

            // --- Step 1: Basic Validation ---
            if (string.IsNullOrWhiteSpace(orNumber))
            {
                MessageBox.Show("Please enter the Official Receipt Number.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtORNumber.Focus();
                return; // Stop processing
            }

            // --- Step 2: Check if OR Number Already Exists ---
            bool orExists = false;
            try
            {
                orExists = _repository.CheckORExists(orNumber);
            }
            catch (Exception ex)
            {
                // Handle potential exceptions thrown by CheckORExists if you modified it to throw
                MessageBox.Show($"An error occurred while checking the OR number:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop processing if check fails critically
            }

            if (orExists)
            {
                MessageBox.Show($"The Official Receipt Number '{orNumber}' already exists in the database. Please enter a different one.",
                                "Duplicate OR Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtORNumber.Focus(); // Optional: Set focus back
                txtORNumber.SelectAll(); // Optional: Select text for easy replacement
                return; // Stop processing
            }

            // --- Step 3: SECOND Confirmation (Only if OR doesn't exist) ---
            DialogResult confirmResult = MessageBox.Show(
                $"Are you sure you want to assign OR Number '{orNumber}' to this reservation?",
                "Confirm OR Number Assignment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // --- Step 4: Call Repository to Update Database ---
                bool success = false;
                try
                {
                    // Pass the trimmed OR number
                    success = _repository.UpdateReservationORNumber(_reservationId, orNumber);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the database:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }

                // --- Step 5: Handle Update Result ---
                if (success)
                {
                    MessageBox.Show("Official Receipt number updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.EnteredORNumber = orNumber; // Store the confirmed value
                    this.DialogResult = DialogResult.OK; // Signal success and close
                }
                else
                {
                    MessageBox.Show("Failed to update the Official Receipt number in the database. Please check the details or contact support.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Keep form open
                }
            }
            // else: User clicked 'No' on the second confirmation, do nothing.
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            // ... (existing cancel logic) ...
            if (MessageBox.Show("Are you sure you want to cancel entering the OR Number?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
       
    }
}
