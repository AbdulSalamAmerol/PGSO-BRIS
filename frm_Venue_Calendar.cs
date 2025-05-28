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
    public partial class frm_Venue_Calendar : Form
    {
        private DateTime? _selectedDate;

        public frm_Venue_Calendar()
        {
            InitializeComponent();
            this.Size = new Size(549, 532); // Set default size on open

        }
        public frm_Venue_Calendar(DateTime selectedDate) : this()
        {
            _selectedDate = selectedDate;
            ShowVenueReservationsForDate();
            this.Size = new Size(549, 532); // Ensure size on open with date

        }
        private void ShowVenueReservationsForDate()
        {
            frm_Venue_Res venueres = _selectedDate.HasValue
                ? new frm_Venue_Res(_selectedDate.Value)
                : new frm_Venue_Res();

            venueres.TopLevel = false;
            venueres.FormBorderStyle = FormBorderStyle.None;
            venueres.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(venueres);
            venueres.Show();

        }
        private void venueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Venue_Res venueres = _selectedDate.HasValue
           ? new frm_Venue_Res(_selectedDate.Value)
           : new frm_Venue_Res();

            venueres.TopLevel = false;
            venueres.FormBorderStyle = FormBorderStyle.None;
            venueres.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(venueres);
            venueres.Show();
            // Set the form size for venue view
            this.Size = new Size(549, 532);

        }

        private void createReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Create_Venuer_Reservation createres = new frm_Create_Venuer_Reservation();
            createres.TopLevel = false;
            createres.FormBorderStyle = FormBorderStyle.None;
            createres.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(createres);
            createres.Show();
            // Set the form size for create reservation
            this.Size = new Size(675, 650);

        }

        private void frm_Venue_Calendar_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Venue_Edit vedit = new frm_Venue_Edit();
            vedit.TopLevel = false;
            vedit.FormBorderStyle = FormBorderStyle.None;
            vedit.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(vedit);
            vedit.Show();
            this.Size = new Size(1386, 700);
        }
    }
}
