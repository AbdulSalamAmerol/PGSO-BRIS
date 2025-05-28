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
    public partial class frm_Res_Calendar : Form
    {
        public frm_Res_Calendar()
        {
            InitializeComponent();
            DisplayVenueFirst();
        }

        private void venueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Create_Venuer_Reservation Venues = new frm_Create_Venuer_Reservation();
            Venues.TopLevel = false;
            Venues.FormBorderStyle = FormBorderStyle.None;
            Venues.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(Venues);
            Venues.Show();
        }
        private void DisplayVenueFirst()
        {
            frm_Create_Venuer_Reservation Venues = new frm_Create_Venuer_Reservation();
            Venues.TopLevel = false;
            Venues.FormBorderStyle = FormBorderStyle.None;
            Venues.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(Venues);
            Venues.Show();
        }
        private void equipmetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Create_Equipment_Reservation Venues = new frm_Create_Equipment_Reservation();
            Venues.TopLevel = false;
            Venues.FormBorderStyle = FormBorderStyle.None;
            Venues.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(Venues);
            Venues.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frm_Res_Calendar_Load(object sender, EventArgs e)
        {

        }
    }
}
