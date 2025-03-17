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
            frm_createutilityreservation frm_createutilityreservation = new frm_createutilityreservation();
            frm_createutilityreservation.ShowDialog();
        }
    }
}
