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
            this.Size = new Size(950, 650);

        }
        private void DisplayVenueFirst()
        {
            var Venues = new frm_Create_Venuer_Reservation();
            Venues.TopLevel = false;
            Venues.FormBorderStyle = FormBorderStyle.None;
            Venues.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(Venues);

            // Subscribe to the event
            Venues.ReservationSubmitted += (s, e) => this.Close();

            // Set the exact size after scanning
            Venues.Scanned += (s, e) => this.Size = new Size(972, 677);

            Venues.Show();
            this.Size = new Size(697, 650);
        }

        private void equipmetToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frm_Create_Equipment_Reservation Equipment = new frm_Create_Equipment_Reservation();
            //var Equipment = new frm_Create_Equipment_Reservation();
            Equipment.TopLevel = false;
            Equipment.FormBorderStyle = FormBorderStyle.None;
            Equipment.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(Equipment);
            Equipment.Show();
            this .Size = new Size(697, 690);

            // Subscribe to the event
            Equipment.ReservationSubmittedEq += (s, e) => this.Close();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frm_Res_Calendar_Load(object sender, EventArgs e)
        {

        }
    }
}
