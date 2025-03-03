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
    public partial class frm_choosevenues: Form
    {
        public frm_choosevenues()
        {
            InitializeComponent();
        }
        //button ammungan hall
        private void button1_Click(object sender, EventArgs e)
        {
            frm_ammunganhall frm = new frm_ammunganhall();
            this.Hide();
            frm.FormClosed += (s, args) => this.Show();
            frm.ShowDialog();
        }
        private void venuesmodal_Load(object sender, EventArgs e)
        {

        }

        //button convention
        private void button2_Click(object sender, EventArgs e)
        {
            frm_convention frm = new frm_convention();
            this.Hide();
            frm.FormClosed += (s, args) => this.Show();
            frm.ShowDialog();
        }

        private void btn_pasalubong_Click(object sender, EventArgs e)
        {
            frm_pasalubong frm = new frm_pasalubong();
            this.Hide();
            frm.FormClosed += (s, args) => this.Show();
            frm.ShowDialog();
        }
    }
}
