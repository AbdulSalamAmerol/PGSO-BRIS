using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace pgso
{

    public partial class frm_Login : Form
    {
        public static string LoggedInUsername { get; private set; } // Static variable to store the logged-in username
        public static string UserType { get; private set; } // Static variable to store the user type

        static string mycon = ConfigurationManager.ConnectionStrings["pgso.Properties.Settings.strCon"]?.ConnectionString ?? "";


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


            this.StartPosition = FormStartPosition.CenterScreen; // Ensure this is set

            if (string.IsNullOrEmpty(mycon))
            {
                MessageBox.Show("Error: Database connection string is not initialized. Check App.config settings.",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            checkBox1.Checked = false;

            // Set password text visibility based on the checkbox state
            txtpassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            // Logic to execute when the form loads
           // MessageBox.Show("Login form is loading...");
        }

       

        private void LogAuditAction(string username, string action, string userType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(mycon))
                {
                    con.Open();

                    // Update the table name if necessary
                    string getUserIdQuery = "SELECT pk_UserID FROM tbl_User WHERE fld_Username = @Username";
                    SqlCommand getUserIdCmd = new SqlCommand(getUserIdQuery, con);
                    getUserIdCmd.Parameters.AddWithValue("@Username", username);

                    object userIdObj = getUserIdCmd.ExecuteScalar();
                    if (userIdObj == null)
                    {
                        MessageBox.Show("User not found.");
                        return;
                    }

                    int userId = Convert.ToInt32(userIdObj);

                    string insertAuditLogQuery = "INSERT INTO tbl_Audit_Log (fk_UserID, fld_ActionType, fld_Changed_By, fld_Changed_At) " +
                                                 "VALUES (@UserID, @Action, @ChangedBy, @ChangedAt)";

                    SqlCommand insertAuditLogCmd = new SqlCommand(insertAuditLogQuery, con);
                    insertAuditLogCmd.Parameters.AddWithValue("@UserID", userId);
                    insertAuditLogCmd.Parameters.AddWithValue("@Action", action);
                    insertAuditLogCmd.Parameters.AddWithValue("@ChangedBy", userType);
                    insertAuditLogCmd.Parameters.AddWithValue("@ChangedAt", DateTime.Now);

                    insertAuditLogCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging action: " + ex.Message);
            }
        }

        private void combouname1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(combouname1.Text) || string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(mycon))
                {
                    string query = "SELECT * FROM tbl_User WHERE fld_Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS AND fld_PasswordHash = @Password COLLATE SQL_Latin1_General_CP1_CS_AS AND fld_Role = @Role COLLATE SQL_Latin1_General_CP1_CS_AS";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@Username", combouname1.Text);
                    sda.SelectCommand.Parameters.AddWithValue("@Password", txtpassword.Text);
                    sda.SelectCommand.Parameters.AddWithValue("@Role", combousertype.Text);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        DataRow row = dt.Rows[0];
                        LoggedInUsername = combouname1.Text; // Set the logged-in username
                        UserType = row["fld_Role"].ToString().Trim(); // Set the user type

                        // Check if the user is an admin
                        if (UserType == "Admin")
                        {
                            // Log the login action
                            LogAuditAction(LoggedInUsername, "Logged In", UserType);

                            // Show the dashboard
                            this.Hide();
                            frm_Dashboard dashboard = new frm_Dashboard();
                            dashboard.ShowDialog();
                            this.Close();
                        }
                        else if (UserType == "Staff")
                        {
                            // Log the login action
                            LogAuditAction(LoggedInUsername, "Logged In", UserType);

                            // Show the dashboard for staff
                            this.Hide();
                            frm_Dashboard dashboard = new frm_Dashboard();
                            dashboard.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Access denied. Only admins and staff can log in.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void combouname1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
