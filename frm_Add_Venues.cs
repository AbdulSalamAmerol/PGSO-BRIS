using pgso_connect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Add_Venues : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private readonly Connection db = new Connection();
        private CheckBox chk_Aircon; // Add this line

        public frm_Add_Venues()
        {
            InitializeComponent();
            chk_Aircon = new CheckBox(); // Initialize the CheckBox
        }

        private void frm_Add_Venues_Load(object sender, EventArgs e)
        {
            // Add your load event logic here
        }

        private void DBConnect()
        {
            try
            {
                conn = db.strCon;
                if (conn == null)
                {
                    throw new Exception("Connection string is null.");
                }
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connection: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void DBClose()
        {
            try
            {
                if (conn?.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing connection: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Submit_Add_Venue_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txt_Venue_Name.Text))
            {
                MessageBox.Show("Please enter venue name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_First_Four_Hours_Rate.Text, out decimal firstFourHoursRate) || firstFourHoursRate < 0)
            {
                MessageBox.Show("Please enter a valid first four hours rate.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_Hourly_Rate.Text, out decimal hourlyRate) || hourlyRate < 0)
            {
                MessageBox.Show("Please enter a valid hourly rate.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_Additional_Charges.Text, out decimal additionalCharge) || additionalCharge < 0)
            {
                MessageBox.Show("Please enter a valid additional charge.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlTransaction transaction = null;

            try
            {
                DBConnect();
                transaction = conn.BeginTransaction();

                // 1. Insert into Venue table and get the new ID
                cmd = new SqlCommand(
                    @"INSERT INTO tbl_Venue (fld_Venue_Name) 
              OUTPUT INSERTED.pk_VenueID 
              VALUES (@VenueName)",
                    conn, transaction);

                cmd.Parameters.AddWithValue("@VenueName", txt_Venue_Name.Text);
                int newVenueId = (int)cmd.ExecuteScalar();

                // 2. Insert into Venue Scope table and get the new ID
                cmd = new SqlCommand(
                    @"INSERT INTO tbl_Venue_Scope (fld_Venue_Scope_Name) 
              OUTPUT INSERTED.pk_Venue_ScopeID 
              VALUES (@ScopeName)",
                    conn, transaction);

                cmd.Parameters.AddWithValue("@ScopeName", txt_Venue_Scope_Name.Text); // Assuming you have a TextBox for Scope Name
                int newVenueScopeId = (int)cmd.ExecuteScalar();

                // 3. Insert into Venue Pricing with the foreign keys
                cmd = new SqlCommand(
                    @"INSERT INTO tbl_Venue_Pricing 
              (fld_Aircon, fld_Rate_type, fld_First4Hrs_Rate, fld_Hourly_Rate, fld_Additional_Charge, fk_VenueID, fk_Venue_ScopeID) 
              VALUES (@Aircon, @RateType, @FirstFourHoursRate, @HourlyRate, @AdditionalCharge, @VenueID, @VenueScopeID)",
                    conn, transaction);

                cmd.Parameters.AddWithValue("@Aircon", chk_Aircon.Checked);
                cmd.Parameters.AddWithValue("@RateType", txt_RT1.Text);
                cmd.Parameters.AddWithValue("@FirstFourHoursRate", firstFourHoursRate);
                cmd.Parameters.AddWithValue("@HourlyRate", hourlyRate);
                cmd.Parameters.AddWithValue("@AdditionalCharge", additionalCharge);
                cmd.Parameters.AddWithValue("@VenueID", newVenueId);
                cmd.Parameters.AddWithValue("@VenueScopeID", newVenueScopeId);
                cmd.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Venue added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form after successful submission
                ClearForm();
            }
            catch (SqlException sqlEx)
            {
                transaction?.Rollback();
                MessageBox.Show($"Database error: {sqlEx.Message}\nError Number: {sqlEx.Number}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                transaction?.Dispose();
                DBClose();
            }
        }

        private void ClearForm()
        {
            txt_Venue_Name.Clear();
            txt_First_Four_Hours_Rate.Clear();
            txt_Hourly_Rate.Clear();
            txt_Additional_Charges.Clear();
            
            chk_Aircon.Checked = false;
            txt_Venue_Name.Focus();
        }

        private void btn_Cancel_Add_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Input validation for price fields
        private void txt_First_Four_Hours_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox)?.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_Hourly_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_First_Four_Hours_Rate_KeyPress(sender, e); // Reuse the same validation
        }

        private void txt_Additional_Charge_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_First_Four_Hours_Rate_KeyPress(sender, e); // Reuse the same validation
        }

        private void radio_Yes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel_Venue_Add_Paint(object sender, PaintEventArgs e)
        {

        }

        private void combo_Rate_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_Venue_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Venue_Scope_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_RT1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radio_No1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_First_Four_Hours_Rate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Hourly_Rate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
