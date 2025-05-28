using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using pgso_connect;

namespace pgso
{
    public partial class frm_Login: Form
    {
        Connection con = new Connection();

        SqlCommand cmd;
        string strSQL;
        SqlDataAdapter da;
        DataTable dt;
        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            // SKIPS LOGIN in DEBUG MODE / Auto-login when running inside Visual Studio Debug Mode
            /*if (Debugger.IsAttached)
            {
                this.Hide();
                frm_Dashboard dashboard = new frm_Dashboard();
                dashboard.ShowDialog();
                this.Close();
            }*/
        }
        //improve ito soon.Pansamantala muna to. basta makalogin muna
        private void button1_Click(object sender, EventArgs e)
        {
          

            strSQL = "SELECT * FROM users WHERE name='" + combouname.Text + "' AND password='" + txtpassword.Text + "'";

            cmd = new SqlCommand(strSQL, con.strCon);
            cmd.CommandTimeout = 360;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

           if (dt.Rows.Count != 0)

            {
                DataRow row = dt.Rows[0];
                this.Hide();

                frm_Dashboard frm = new frm_Dashboard();
                frm.ShowDialog();

            }


            else
            {
                MessageBox.Show("Invalid username or password");

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        

        private void lbl_register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // frm_register frm = new frm_register();
           // frm.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void lbl_dateandtime_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btneye_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
