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
    public partial class frm_OR : Form
    {
        // Optional: Add a property to get the entered OR Number if needed later
        public string EnteredORNumber { get; private set; }

        public frm_OR()
        {
            InitializeComponent();
        }

        private void btn_OR_Confirm_Click(object sender, EventArgs e)
        {
            // --- Step 1: Validation (Example) ---
            if (string.IsNullOrWhiteSpace(txtORNumber.Text)) // Replace txtORNumber with your actual TextBox name
            {
                MessageBox.Show("Please enter the Official Receipt Number.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop processing if validation fails
            }

            // --- Step 2: Store the value (Optional) ---
            this.EnteredORNumber = txtORNumber.Text; // Store if you need it back in the calling form

            // --- Step 3: Signal Confirmation ---
            this.DialogResult = DialogResult.OK; // This signals the calling code that the user confirmed

            // No need for this.Close(); here when using ShowDialog() and setting DialogResult
        }

        // Optional: Add a Cancel button
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Signal cancellation
        }
    }
}
