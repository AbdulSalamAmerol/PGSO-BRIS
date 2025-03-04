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
// IGNORE THIS MESSAGE
namespace pgso
{
    public partial class frm_login: Form
    {
        Connection con = new Connection();

        SqlCommand cmd;
        string strSQL;
        SqlDataAdapter da;
        DataTable dt;
        //taetae
        public frm_login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

                frm_dashboard frm = new frm_dashboard();
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
            frm_register frm = new frm_register();
            frm.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        //private void timer1_Tick(object sender, EventArgs e)
        /*{
            int HH = DateTime.Now.Hour;
            int MM = DateTime.Now.Minute;
            int SS = DateTime.Now.Second;
            string TIME = $"{HH:D2}:{MM:D2}:{SS:D2}";
            lbl_dateandtime.Text = TIME;

            if (HH < 10)
            {
                TIME = "0" + HH;
            }
            else
            {
                if (HH > 12)
                {
                    HH -= 12;
                }
                TIME = HH.ToString();
            }
            TIME += ":";
            if (MM < 10)
            {
                TIME += "0" + MM;
            }
            else
            {
                TIME += MM.ToString();
            }
            TIME += ":";
            if (SS < 10)
            {
                TIME += "0" + SS;
            }
            else
            {
                TIME += SS.ToString();
            }
            lbl_dateandtime.Text = TIME;*/
       // }

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
    }
}
