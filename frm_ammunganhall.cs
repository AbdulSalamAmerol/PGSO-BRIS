using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using pgso;

namespace pgso
{
    public partial class frm_ammunganhall : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        public frm_ammunganhall()
        {

            InitializeComponent();
        }

        private void frm_ammunganhall_Load(object sender, EventArgs e)
        {

        }
        private void DBConnect()
        {
            try
            {
                Connection dbConnection = new Connection(); //create new instance of connection class
                conn = dbConnection.strCon; //get connection
                conn.Open(); //open connection
            }
            catch (Exception ex)
            {
            //error pag di nagkonek
                MessageBox.Show("Error Connection: " + ex.Message);
                MessageBoxButtons.OKCancel.ToString();
            }
        }
        //method closing database connection
        private void DBClose()
        {
            conn.Close(); //close connection
            conn.Dispose(); //dispose connection
        }
//Button SUBMIT
        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect(); //open DB connection
                cmd = new SqlCommand("INSERT INTO tbl_ammungan (requesting_person, address, activity, contact, participants, date_of_use, time_start, time_end) VALUES (@requesting_person, @address, @activity, @contact, @participants, @date_of_use, @time_start, @time_end)", conn);
                cmd.Parameters.AddWithValue("requesting_person", txt_requestingperson.Text);
                cmd.Parameters.AddWithValue("address", txt_address.Text);
                cmd.Parameters.AddWithValue("activity", txt_activity.Text);
                cmd.Parameters.AddWithValue("contact", txt_contact.Text);
                cmd.Parameters.AddWithValue("participants", num_participants.Value);
                cmd.Parameters.AddWithValue("date_of_use", date_of_use.Value);
                cmd.Parameters.AddWithValue("time_start", TimeStart.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("time_end", TimeEnd.Value.TimeOfDay);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Submitted Successfully");
                DBClose(); //close connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                MessageBoxButtons.OKCancel.ToString();
            }
            finally
            {
                cmd.Dispose();
                DBClose();
            }

            //to submit data in the database

        }
    }
}
