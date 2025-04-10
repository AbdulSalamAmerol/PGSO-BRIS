using pgso.Billing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso.pgso_Billing.User_Control
{
    public partial class Equipment_User_Control : UserControl
    {
        public Equipment_User_Control(Model_Billing billingDetails)
        {
            InitializeComponent();
            LoadBillingDetails(billingDetails);
        }

        public void LoadBillingDetails(Model_Billing billingDetails)
        {
        }
    }
}