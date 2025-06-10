using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_login : Form
    {
        public static int LoggedInUserId { get; private set; }
        public static string LoggedInUsername { get; private set; }
        public static string UserType { get; private set; }
        public static string username;
        public static string LoggedInUserRole { get; set; }

        private static string mycon = ConfigurationManager.ConnectionStrings["pgso.Properties.Settings.strCon"]?.ConnectionString ?? "";


        private const string usernamePlaceholder = "Enter username";
        private const string passwordPlaceholder = "Enter password";

        private Timer timer1;

        public frm_login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (string.IsNullOrEmpty(mycon))
            {
                MessageBox.Show("Error: Database connection string is not initialized. Check App.config settings.",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadRememberedCredentials();

            CB_remember.Checked = false;
            TXT_password.UseSystemPasswordChar = !CB_remember.Checked;

            SetUsernamePlaceholder();
            SetPasswordPlaceholder();

            TXT_username.Enter += TXT_username_Enter;
            TXT_username.Leave += TXT_username_Leave;
            TXT_username.TextChanged += TXT_username_TextChanged;

            TXT_password.Enter += TXT_password_Enter;
            TXT_password.Leave += TXT_password_Leave;
            TXT_password.TextChanged += TXT_password_TextChanged;

            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Start();

            LB_datetime.Text = DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt");
        }

        private void LoadRememberedCredentials()
        {
            if (Properties.Settings.Default.RememberMeChecked &&
                !string.IsNullOrWhiteSpace(Properties.Settings.Default.RememberedUsername))
            {
                TXT_username.Text = Properties.Settings.Default.RememberedUsername;
                TXT_username.ForeColor = Color.Black;
                CB_remember.Checked = true;
            }
            else
            {
                SetUsernamePlaceholder();
                CB_remember.Checked = false;
            }
        }

        private void SetUsernamePlaceholder()
        {
            if (string.IsNullOrWhiteSpace(TXT_username.Text))
            {
                TXT_username.Text = usernamePlaceholder;
                TXT_username.ForeColor = Color.Gray;
            }
        }

        private void SetPasswordPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(TXT_password.Text))
            {
                TXT_password.UseSystemPasswordChar = false;
                TXT_password.Text = passwordPlaceholder;
                TXT_password.ForeColor = Color.Gray;
            }
        }

        private void TXT_username_Enter(object sender, EventArgs e)
        {
            if (TXT_username.Text == usernamePlaceholder)
            {
                TXT_username.Text = "";
                TXT_username.ForeColor = Color.Black;
            }
        }

        private void TXT_username_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TXT_username.Text))
            {
                SetUsernamePlaceholder();
            }
        }

        private void TXT_username_TextChanged(object sender, EventArgs e)
        {
            if (TXT_username.Text != usernamePlaceholder && TXT_username.ForeColor == Color.Gray)
            {
                TXT_username.Text = TXT_username.Text.Replace(usernamePlaceholder, "");
                TXT_username.ForeColor = Color.Black;
                TXT_username.SelectionStart = TXT_username.Text.Length;
                TXT_username.SelectionLength = 0;
            }
        }

        private void TXT_password_Enter(object sender, EventArgs e)
        {
            if (TXT_password.Text == passwordPlaceholder)
            {
                TXT_password.Text = "";
                TXT_password.UseSystemPasswordChar = !CB_remember.Checked;
                TXT_password.ForeColor = Color.Black;
            }
        }

        private void TXT_password_Leave(object sender, EventArgs e)
        {
            SetPasswordPlaceholder();
        }

        private void TXT_password_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TXT_password.Text) &&
                TXT_password.Text != passwordPlaceholder &&
                !TXT_password.Multiline)
            {
                TXT_password.UseSystemPasswordChar = true;
                TXT_password.ForeColor = Color.Black;
            }
            else
            {
                TXT_password.UseSystemPasswordChar = false;
                TXT_password.ForeColor = Color.Gray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (TXT_password.Text != passwordPlaceholder)
            {
                TXT_password.UseSystemPasswordChar = !TXT_password.UseSystemPasswordChar;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (TXT_password.Text != passwordPlaceholder)
            {
                TXT_password.UseSystemPasswordChar = false;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TXT_username.Text) || string.IsNullOrWhiteSpace(TXT_password.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(mycon))
                {
                    string query = "SELECT * FROM tbl_User " +
                                   "WHERE fld_Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS " +
                                   "AND fld_PasswordHash = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@Username", TXT_username.Text);
                    sda.SelectCommand.Parameters.AddWithValue("@Password", TXT_password.Text);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        DataRow row = dt.Rows[0];
                        LoggedInUserId = Convert.ToInt32(row["pk_UserID"]); // Store user ID
                        LoggedInUsername = row["fld_Username"].ToString();  // Store username from DB
                        UserType = row["fld_Role"].ToString().Trim();

                        username = row["fld_Username"].ToString();

                        LoggedInUserRole = UserType;
                        if (CB_remember.Checked)
                        {
                            Properties.Settings.Default.RememberedUsername = TXT_username.Text;
                            Properties.Settings.Default.RememberMeChecked = true;
                        }
                        else
                        {
                            Properties.Settings.Default.RememberedUsername = "";
                            Properties.Settings.Default.RememberMeChecked = false;
                        }

                        Properties.Settings.Default.Save();

                        if (UserType == "Admin" || UserType == "Staff")
                        {
                            LogAuditAction(LoggedInUsername, "Logged In", UserType);

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
                        Properties.Settings.Default.RememberedUsername = "";
                        Properties.Settings.Default.RememberedUserType = "";
                        Properties.Settings.Default.RememberMeChecked = false;
                        Properties.Settings.Default.Save();

                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetPasswordPlaceholder();

            if (string.IsNullOrWhiteSpace(TXT_username.Text))
            {
                SetUsernamePlaceholder();
            }
            else if (TXT_username.Text != usernamePlaceholder)
            {
                TXT_username.SelectionStart = TXT_username.Text.Length;
                TXT_username.SelectionLength = 0;
                TXT_username.ForeColor = Color.Black;
            }
        }
    }
}