using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_dashboard: Form
    {
        public frm_dashboard()
        {
            InitializeComponent();
        }

        private void btn_venues_Click(object sender, EventArgs e)
        {
            frm_choosevenues frm = new frm_choosevenues();
            frm.ShowDialog();
        }

        private void frm_dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
