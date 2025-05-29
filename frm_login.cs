using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace pgso
{
    public partial class frm_Login : Form
    {
        public static string LoggedInUsername { get; private set; }
        public static string UserType { get; private set; }
            
        static string mycon = ConfigurationManager.ConnectionStrings["BRIS_EXPERIMENT_3.0.Properties.Settings.strCon"]?.ConnectionString ?? "";

        private const string usernamePlaceholder = "Enter username"; // Placeholder text for username
        private const string passwordPlaceholder = "Enter password";
        private const string userTypePlaceholder = "Select user type"; // Placeholder text for user type

        public frm_Login()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            if (string.IsNullOrEmpty(mycon))
            {
                MessageBox.Show("Error: Database connection string is not initialized. Check App.config settings.",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            checkBox1.Checked = false;
            txtpassword.UseSystemPasswordChar = !checkBox1.Checked;

            // Set initial placeholder for username
            SetUsernamePlaceholder();

            // Set initial placeholder for password
            SetPasswordPlaceholder();

            // Only add real choices
            combousertype.Items.Clear();
            combousertype.Items.Add("Admin");
            combousertype.Items.Add("Staff");

            // Set placeholder as the displayed text
            combousertype.Text = userTypePlaceholder;
            combousertype.ForeColor = System.Drawing.Color.Gray;

            // Wire up events if not done in designer
            combouname1.Enter += combouname1_Enter;
            combouname1.Leave += combouname1_Leave;
            txtpassword.Enter += txtpassword_Enter;
            txtpassword.Leave += txtpassword_Leave;
            combousertype.SelectedIndexChanged += combousertype_SelectedIndexChanged;
            combousertype.DropDown += combousertype_DropDown;
            combousertype.Leave += combousertype_Leave;
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            LBdatetime.Text = DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt");

            // Load saved username and user type if RememberMe is true
            if (Properties.Settings.Default.RememberMe)
            {
                combouname1.Text = Properties.Settings.Default.SavedUsername;
                combousertype.Text = Properties.Settings.Default.SavedUserType;
                checkBox1.Checked = true;
                combouname1.ForeColor = System.Drawing.Color.Black;
                combousertype.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void SetUsernamePlaceholder()
        {
            if (string.IsNullOrWhiteSpace(combouname1.Text))
            {
                combouname1.Text = usernamePlaceholder;
                combouname1.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void combouname1_Enter(object sender, EventArgs e)
        {
            if (combouname1.Text == usernamePlaceholder)
            {
                combouname1.Text = "";
                combouname1.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void combouname1_Leave(object sender, EventArgs e)
        {
            SetUsernamePlaceholder();
        }

        private void SetPasswordPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                txtpassword.UseSystemPasswordChar = false;
                txtpassword.Text = passwordPlaceholder;
                txtpassword.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == passwordPlaceholder)
            {
                txtpassword.Text = "";
                txtpassword.UseSystemPasswordChar = !checkBox1.Checked; // Respect show/hide password
                txtpassword.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            SetPasswordPlaceholder();
        }

        private void LogAuditAction(string username, string action, string userType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(mycon))
                {
                    con.Open();

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

        private void combousertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            combousertype.ForeColor = System.Drawing.Color.Black;
        }

        private void combousertype_DropDown(object sender, EventArgs e)
        {
            // If the placeholder is showing, clear it when the dropdown opens
            if (combousertype.Text == userTypePlaceholder)
            {
                combousertype.Text = "";
                combousertype.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void combousertype_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(combousertype.Text))
            {
                combousertype.Text = userTypePlaceholder;
                combousertype.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(combouname1.Text) || combouname1.Text == usernamePlaceholder || string.IsNullOrWhiteSpace(txtpassword.Text) || txtpassword.Text == passwordPlaceholder)
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (combousertype.Text == userTypePlaceholder || string.IsNullOrWhiteSpace(combousertype.Text))
            {
                MessageBox.Show("Please select a user type.");
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
                        LoggedInUsername = combouname1.Text;
                        UserType = row["fld_Role"].ToString().Trim();

                        if (UserType == "Admin" || UserType == "Staff")
                        {
                            LogAuditAction(LoggedInUsername, "Logged In", UserType);

                            if (checkBox1.Checked)
                            {
                                Properties.Settings.Default.RememberMe = true;
                                Properties.Settings.Default.SavedUsername = combouname1.Text;
                                Properties.Settings.Default.SavedUserType = combousertype.Text;
                            }
                            else
                            {
                                Properties.Settings.Default.RememberMe = false;
                                Properties.Settings.Default.SavedUsername = "";
                                Properties.Settings.Default.SavedUserType = "";
                            }
                            Properties.Settings.Default.Save();

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
            // Only toggle password masking if the placeholder is NOT showing
            if (txtpassword.Text != passwordPlaceholder)
            {
                txtpassword.UseSystemPasswordChar = !checkBox1.Checked;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void combouname1_TextChanged(object sender, EventArgs e)
        {
        }

        private void combousertype_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Only toggle if the placeholder is not showing
            if (txtpassword.Text != passwordPlaceholder)
            {
                txtpassword.UseSystemPasswordChar = !txtpassword.UseSystemPasswordChar;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
