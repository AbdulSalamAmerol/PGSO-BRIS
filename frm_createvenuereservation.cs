using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using iText.Forms.Form.Element;
using pgso_connect;

namespace pgso
{
    public partial class frm_createvenuereservation : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public frm_createvenuereservation()
        {
            InitializeComponent();
            // Add A and B directly to combo_chooseset
            //combo_chooseSet.Items.Add("A");
           // combo_chooseSet.Items.Add("B");
            //combo_chooseSet.SelectedIndexChanged += combo_chooseset_SelectedIndexChanged;
            // Set the DateTimePicker format to display only hour, minute, and AM/PM
            TimeStart.Format = DateTimePickerFormat.Custom;
            TimeStart.CustomFormat = "hh:mm tt";
            TimeEnd.Format = DateTimePickerFormat.Custom;
            TimeEnd.CustomFormat = "hh:mm tt";
        
        }

        // Open database connection
        private void DBConnect()
        {
            try
            {
                Connection dbConnection = new Connection(); // Create new instance of connection class
                conn = dbConnection.strCon; // Get connection
                conn.Open(); // Open connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connection: " + ex.Message);
            }
        }

        // Close database connection
        private void DBClose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        // Event: When combo_chooseset changes (A/B)
        /*private void combo_chooseset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_chooseSet.SelectedItem != null)
            {
                string selectedSet = combo_chooseSet.SelectedItem.ToString();
                LoadVenues(selectedSet);

                // Disable panel_faci if "B" is selected
                panel_faci.Enabled = selectedSet != "B";
            }
        }
        */
        // Load venues based on the selected venue_set (A/B)
        private void LoadVenues()
        {
            try
            {
                DBConnect();
                cmd = new SqlCommand("SELECT pk_VenueID, fld_Venue_Name FROM tbl_Venue", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                combo_venues.DataSource = dt;
                combo_venues.ValueMember = "pk_VenueID";
                combo_venues.DisplayMember = "fld_Venue_Name";

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading venues: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }






        // Submit data to tbl_ammungan
        // Submit data to tbl_ammungan
        // Submit data to tbl_ammungan
        private void btn_submit_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;

            try
            {
                DBConnect(); // Connect to Database
                transaction = conn.BeginTransaction(); // Start a transaction

                // Validate the start and end times
                if (TimeStart.Value.TimeOfDay >= TimeEnd.Value.TimeOfDay)
                {
                    MessageBox.Show("Start time must be before end time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 1: Insert into RequestingPerson
                cmd = new SqlCommand("INSERT INTO tbl_RequestingPerson (Surname, FirstName, Address, ContactNumber, RequestOrigin) OUTPUT INSERTED.PersonID VALUES (@Surname, @FirstName, @Address, @ContactNumber, @RequestOrigin)", conn, transaction);
                cmd.Parameters.AddWithValue("@Surname", txt_surname.Text);
                cmd.Parameters.AddWithValue("@FirstName", txt_firstname.Text);
                cmd.Parameters.AddWithValue("@Address", txt_address.Text);

                // Validate the contact number
                string contactNumber = txt_contact.Text;
                if (string.IsNullOrEmpty(contactNumber) || !IsValidContactNumber(contactNumber))
                {
                    MessageBox.Show("Contact number is invalid. Please enter a valid contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@RequestOrigin", txt_requestorigin.Text);

                int personID = (int)cmd.ExecuteScalar();

                // Step 2: Insert into Reservations
                cmd = new SqlCommand("INSERT INTO Reservations (ControlNumber, StartDate, EndDate, StartTime, EndTime, NumberOfParticipants, Status, PersonID) OUTPUT INSERTED.ReservationID VALUES (@ControlNumber, @StartDate, @EndDate, @StartTime, @EndTime, @NumberOfParticipants, @Status, @PersonID)", conn, transaction);
                cmd.Parameters.AddWithValue("@ControlNumber", txt_controlnum.Text);
                cmd.Parameters.AddWithValue("@StartDate", date_of_use_start.Value);
                cmd.Parameters.AddWithValue("@EndDate", date_of_use_end.Value);
                cmd.Parameters.AddWithValue("@StartTime", TimeStart.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@EndTime", TimeEnd.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@NumberOfParticipants", num_participants.Value);
                cmd.Parameters.AddWithValue("@Status", "Pending");
                cmd.Parameters.AddWithValue("@PersonID", personID);

                int reservationID = (int)cmd.ExecuteScalar();

                // Step 3: Insert into VenueReservations
                cmd = new SqlCommand("INSERT INTO VenueReservations (ReservationID, UsesAircon) VALUES (@ReservationID, @UsesAircon)", conn, transaction);
                cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                //cmd.Parameters.AddWithValue("@VenueID", combo_venues.SelectedValue);
                cmd.Parameters.AddWithValue("@UsesAircon", radio_Yes.Checked);
                cmd.ExecuteNonQuery();

                // Commit the transaction
                transaction.Commit();

                MessageBox.Show("Reservation submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                // Rollback the transaction if any error occurs
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                if (ex.Number == 547) // Check constraint violation
                {
                    MessageBox.Show("Error: " + ex.Message + "\nPlease ensure all data meets the required constraints.", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Rollback the transaction if any error occurs
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBClose(); // Close Connection
            }
        }



        // Helper method to validate the contact number
        private bool IsValidContactNumber(string contactNumber)
        {
            // Example validation: Ensure the contact number is 10-15 digits long and may contain spaces, dashes, and parentheses
            string cleanedContactNumber = new string(contactNumber.Where(char.IsDigit).ToArray());
            return cleanedContactNumber.Length >= 10 && cleanedContactNumber.Length <= 15;
        }








        private void combo_venues_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Add any specific logic when venues change if needed
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel_faci_Paint(object sender, PaintEventArgs e)
        {
            // Some code (probably empty)
        }

        private void txt_controlnum_TextChanged(object sender, EventArgs e)
        {

        }

        private void TimeStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedTime = TimeStart.Value;
            string hourAndMinute = selectedTime.ToString("HH:mm tt");
            // You can now use the hourAndMinute variable as needed
           // MessageBox.Show("Selected Time: " + hourAndMinute);
        }


    }
}
