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
    public partial class frm_convention: Form
    {
        public frm_convention()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerStart.Format = DateTimePickerFormat.Time;
            dateTimePickerStart.ShowUpDown = true; // Removes calendar dropdown
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerEnd.Format = DateTimePickerFormat.Time;
            dateTimePickerEnd.ShowUpDown = true; // Removes calendar dropdown
        }
    }
}
