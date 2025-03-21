using pgso.Billing.Repositories;
using pgso.Billing.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace pgso
{
    public partial class Billing_Form : Form
    {
        private BillingRepository repo = new BillingRepository();

        public Billing_Form()
        {
            InitializeComponent();
        }

        private void Billing_Form_Load(object sender, EventArgs e)
        {
            List<BillingRecord> billings = repo.GetAllBillingRecords();

            dgvBillingRecords.AutoGenerateColumns = true; 

            dgvBillingRecords.DataSource = billings;

            if (billings.Count == 0)
            {
                MessageBox.Show("No billing records found.");
            }
        }
    }
}
