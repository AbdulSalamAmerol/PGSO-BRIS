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
    public partial class frm_mngreservation: Form
    {
        public frm_mngreservation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Venues frm_venues = new frm_Venues();
            frm_venues.ShowDialog();
        }

        private void frm_mngreservation_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Activate();
        }

        private void btn_rentals_Click(object sender, EventArgs e)
        {
            frm_Equipment frm_Equipment = new frm_Equipment();
            frm_Equipment.ShowDialog();
        }

        private void btn_Manage_Facilities_Click(object sender, EventArgs e)
        {
            frm_Manage_Facilities frm_Manage_Facilities = new frm_Manage_Facilities();
            frm_Manage_Facilities.ShowDialog();
        }
    }
}
