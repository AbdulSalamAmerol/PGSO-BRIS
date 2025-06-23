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

    _reservationId = reservationId;
    _repository = repository;

    // Check if PGNV and disable OR input
    string rateType = _repository.GetRateTypeForReservation(_reservationId);
    if (rateType == "PGNV")
    {
        txtORNumber.Enabled = false;
        txtORNumber.Text = ""; // Optional: clear any existing text
    }
}



        private void Form_Load(object sender, EventArgs e)
        {
            string rateType = _repository.GetRateTypeForReservation(_reservationId);

            if (rateType == "PGNV")
            {
                txtORNumber.Enabled = false;
                txtORNumber.Text = ""; // Ensure it's blank
            }
        }

        private void btn_OR_Confirm_Click(object sender, EventArgs e)
        {
            // --- Step 0: Check fld_Rate_Type for this reservation ---
            string rateType = _repository.GetRateTypeForReservation(_reservationId); // You must implement this method
            if (rateType == "PGNV")
            {
                txtORNumber.Enabled = false;
                string orNumberPGNV = "00000"; // CHANGED FROM " " or "PLGU"
                DialogResult confirmRateResult = MessageBox.Show(
               $"This is a PLGU Reservation and OR Number '{orNumberPGNV}' will be assigned?",
               "Confirm OR Number Assignment",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

                if (confirmRateResult == DialogResult.Yes)
                {
                    bool success = false;
                    try
                    {
                        success = _repository.UpdateReservationORNumber(_reservationId, orNumberPGNV);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while updating the database:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (success)
                    {
                        // Update Confirmation Date
                        _repository.UpdateConfirmationDate(_reservationId, DateTime.Now);

                        MessageBox.Show("Official Receipt number updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.EnteredORNumber = orNumberPGNV;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the Official Receipt number in the database.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                // --- Proceed with normal logic if NOT PGNV ---
                string orNumber = txtORNumber.Text.Trim();

                // Step 1: Basic Validation
                if (string.IsNullOrWhiteSpace(orNumber))
                {
                    MessageBox.Show("Please enter the Official Receipt Number.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtORNumber.Focus();
                    return;
                }

                // Step 2: Check if OR already exists
                bool orExists = false;
                try
                {
                    orExists = _repository.CheckORExists(orNumber);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while checking the OR number:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (orExists)
                {
                    MessageBox.Show($"The Official Receipt Number '{orNumber}' already exists in the database. Please enter a different one.",
                                    "Duplicate OR Number",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    txtORNumber.Focus();
                    txtORNumber.SelectAll();
                    return;
                }

                // Step 3: Second confirmation
                DialogResult confirmResult = MessageBox.Show(
                    $"Are you sure you want to assign OR Number '{orNumber}' to this reservation?",
                    "Confirm OR Number Assignment",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    bool success = false;
                    try
                    {
                        success = _repository.UpdateReservationORNumber(_reservationId, orNumber);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while updating the database:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (success)
                    {
                        // Update Confirmation Date
                        _repository.UpdateConfirmationDate(_reservationId, DateTime.Now);
                        MessageBox.Show("Official Receipt number updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.EnteredORNumber = orNumber;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the Official Receipt number in the database.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


                
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
