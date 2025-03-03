using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
          

            strSQL = "SELECT * FROM users WHERE name='" + txtuname.Text + "' AND password='" + txtpassword.Text + "'";

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
                MessageBox.Show("walang nahanap");

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_register frm = new frm_register();
            frm.ShowDialog();
        }
    }
    }
