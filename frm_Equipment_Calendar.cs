using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Equipment_Calendar : Form
    {
        private DateTime? _selectedDate;

        public frm_Equipment_Calendar()
        {
            InitializeComponent();
            this.Size = new Size(490, 659);
        }
 
        public frm_Equipment_Calendar(DateTime selectedDate) : this()
        {
            _selectedDate = selectedDate;
            ShowEquipmentReservationsForDate();
            this.Size = new Size(490, 659); // Ensure size on open with date

        }

        private void ShowEquipmentReservationsForDate()
        {
            frm_Equipment_Res equipmentres = _selectedDate.HasValue
                ? new frm_Equipment_Res(_selectedDate.Value)
                : new frm_Equipment_Res();

            equipmentres.TopLevel = false;
            equipmentres.FormBorderStyle = FormBorderStyle.None;
            equipmentres.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(equipmentres);
            equipmentres.Show();
        }
        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Equipment_Res equipmentres = _selectedDate.HasValue
                 ? new frm_Equipment_Res(_selectedDate.Value)
                 : new frm_Equipment_Res();
            equipmentres.TopLevel = false;
            equipmentres.FormBorderStyle = FormBorderStyle.None;
            equipmentres.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(equipmentres);
            equipmentres.Show();
            this.Size = new Size(490, 659);

        }

        private void createEquipmentReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Create_Equipment_Reservation createres = new frm_Create_Equipment_Reservation();
            createres.TopLevel = false;
            createres.FormBorderStyle = FormBorderStyle.None;
            createres.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(createres);
            createres.Show();
            this.Size = new Size(697, 690);


        }

        private void frm_Equipment_Calendar_Load(object sender, EventArgs e)
        {

        }
    }
}
