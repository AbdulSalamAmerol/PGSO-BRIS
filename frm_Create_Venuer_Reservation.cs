using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using pgso_connect;
// Pushing Jaymar_Branch
namespace pgso
{
    public partial class frm_Create_Venuer_Reservation : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private int selectedVenueID;  // Class-level variable to store selected venue ID
        private List<DateTime> reservedDates; // List to store reserved dates

        public frm_Create_Venuer_Reservation()
        {
            InitializeComponent();
            // Set the DateTimePicker format to display only hour, minute, and AM/PM
            TimeStart.Format = DateTimePickerFormat.Custom;
            TimeStart.CustomFormat = "hh:mm tt";
            TimeEnd.Format = DateTimePickerFormat.Custom;
            TimeEnd.CustomFormat = "hh:mm tt";
            LoadVenues();

            LoadUtilities();


            CalculateTotalAmount();
        }
        private void frm_createvenuereservation_Load(object sender, EventArgs e)
        {
            LoadVenues();
            date_of_use_start.ValueChanged += date_of_use_start_ValueChanged;
            date_of_use_end.ValueChanged += date_of_use_end_ValueChanged;
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

        // Load venues and populate combo_venues
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

        // Load venue scope for selected venue
        private void LoadVenueScope(int venueID)
        {
            try
            {
                DBConnect();
                cmd = new SqlCommand(@"
            SELECT DISTINCT vs.pk_Venue_ScopeID, vs.fld_Venue_Scope_Name 
            FROM tbl_Venue_Pricing vp
            INNER JOIN tbl_Venue_Scope vs ON vp.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
            WHERE vp.fk_VenueID = @VenueID", conn);

                cmd.Parameters.AddWithValue("@VenueID", venueID);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                combo_scope.DataSource = dt;
                combo_scope.ValueMember = "pk_Venue_ScopeID";  // Hidden ID
                combo_scope.DisplayMember = "fld_Venue_Scope_Name";  // Display Name

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading venue scope: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }

        // Load reservation types based on selected venue
        private void LoadReservationTypesByVenue(int venueID)
        {
            try
            {
                DBConnect();
                cmd = new SqlCommand("SELECT DISTINCT fld_Rate_Type FROM tbl_Venue_Pricing WHERE fk_VenueID = @VenueID", conn);
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                combo_ReservationType.DataSource = dt;
                combo_ReservationType.ValueMember = "fld_Rate_Type";
                combo_ReservationType.DisplayMember = "fld_Rate_Type";

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservation types: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }

        // When venue selection changes, load reservation types and venue scope accordingly
        private void combo_venues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_venues.SelectedValue != null)
            {
                if (int.TryParse(combo_venues.SelectedValue.ToString(), out selectedVenueID))
                {
                    LoadReservationTypesByVenue(selectedVenueID);
                    LoadVenueScope(selectedVenueID);
                    LoadReservedDates(selectedVenueID); // Load reserved dates for the selected venue
                    // Check if the selected venue is "Ammungan Hall"
                    string selectedVenueName = combo_venues.Text;
                    if (selectedVenueName == "Ammungan Hall")
                    {
                        panel_night_time.Enabled = true;
                    }
                    else
                    {
                        panel_night_time.Enabled = false;
                    }
                }
            }
        }

        // Check if both reservation type and venue scope are selected
        private bool IsReservationTypeAndScopeSelected()
        {
            return combo_ReservationType.SelectedValue != null && combo_scope.SelectedValue != null;
        }

        // Load the facilities
        private void LoadUtilities()
        {
            try
            {
                DBConnect();
                string query = "SELECT pk_EquipmentID, fld_Equipment_Name FROM tbl_Equipment";
                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading utilities: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }

        // Load utility details and set rate
        private void LoadUtilityDetails(int utilityId)
        {
            try
            {
                DBConnect();
                string query = @"
                    SELECT 
                        ep.fld_Equipment_Price
                    FROM 
                        tbl_Equipment e
                    LEFT JOIN 
                        tbl_Equipment_Pricing ep ON e.pk_EquipmentID = ep.fk_EquipmentID
                    WHERE 
                        e.pk_EquipmentID = @UtilityId";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UtilityId", utilityId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() && !reader.IsDBNull(0))
                {
                    txt_rate.Tag = reader["fld_Equipment_Price"].ToString(); // Store price in Tag
                }
                else
                {
                    txt_rate.Tag = null; // No price
                    txt_rate.Text = "0.00";
                }

                reader.Close();
                CalculateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading utility details: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }

        // Calculate total amount
        private void CalculateTotalAmount()
        {
            decimal rate = 0;
            if (txt_rate.Tag != null && decimal.TryParse(txt_rate.Tag.ToString(), out rate))
            {
                txt_rate.Text = rate.ToString("0.00");
            }
            else
            {
                txt_rate.Text = "0.00";
            }
        }



        // Event handlers
        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }

       

        // Load rate based on selected venue, venue scope, reservation type, and aircon selection
        private void LoadRate()
        {
            try
            {
                if (!IsReservationTypeAndScopeSelected())
                {
                    return;
                }

                bool usesAircon = radio_Yes.Checked;

                DBConnect();
                string rateQuery = @"
                SELECT fld_First4Hrs_Rate 
                FROM tbl_Venue_Pricing 
                WHERE fld_Rate_Type = @RateType 
                AND fk_VenueID = @VenueID 
                AND fk_Venue_ScopeID = @VenueScopeID 
                AND fld_Aircon = @UsesAircon";

                using (SqlCommand rateCmd = new SqlCommand(rateQuery, conn))
                {
                    rateCmd.Parameters.AddWithValue("@RateType", combo_ReservationType.SelectedValue.ToString());
                    rateCmd.Parameters.AddWithValue("@VenueID", selectedVenueID);
                    rateCmd.Parameters.AddWithValue("@VenueScopeID", combo_scope.SelectedValue);
                    rateCmd.Parameters.AddWithValue("@UsesAircon", usesAircon);

                    object result = rateCmd.ExecuteScalar();
                    string rate = (result != null) ? result.ToString() : "0.00";
                    txt_rate.Text = rate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rate: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }

        // Submit data to tbl_Reservation
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
                cmd = new SqlCommand("INSERT INTO tbl_Requesting_Person (fld_Surname, fld_First_Name, fld_Requesting_Person_Address, fld_Contact_Number, fld_Request_Origin) OUTPUT INSERTED.pk_Requesting_PersonID VALUES (@Surname, @FirstName, @Address, @ContactNumber, @RequestOrigin)", conn, transaction);

                cmd.Parameters.AddWithValue("@Surname", txt_surname.Text);
                cmd.Parameters.AddWithValue("@FirstName", txt_firstname.Text);
                cmd.Parameters.AddWithValue("@Address", txt_address.Text);


                //insert to equipment


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

                // Step 2: Retrieve fk_VenueID, fk_Venue_PricingID, fk_Venue_ScopeID
                int venueID = selectedVenueID;
                int venueScopeID = (int)combo_scope.SelectedValue;
                string reservationType = combo_ReservationType.SelectedValue.ToString();
                bool usesAircon = radio_Yes.Checked;

                cmd = new SqlCommand(@"
                SELECT pk_Venue_PricingID 
                FROM tbl_Venue_Pricing 
                WHERE fk_VenueID = @VenueID 
                AND fk_Venue_ScopeID = @VenueScopeID 
                AND fld_Rate_Type = @RateType 
                AND fld_Aircon = @UsesAircon", conn, transaction);

                cmd.Parameters.AddWithValue("@VenueID", venueID);
                cmd.Parameters.AddWithValue("@VenueScopeID", venueScopeID);
                cmd.Parameters.AddWithValue("@RateType", reservationType);
                cmd.Parameters.AddWithValue("@UsesAircon", usesAircon);

                int venuePricingID = (int)cmd.ExecuteScalar();

                // Step 3: Insert into Reservations
                cmd = new SqlCommand(@"
                INSERT INTO tbl_Reservation 
                (fld_Control_Number, fld_Start_Date, fld_End_Date, fld_Start_Time, fld_End_Time, fld_Activity_Name, fld_Number_Of_Participants, fld_Reservation_Status, fld_Reservation_Type, fld_Total_Amount, fk_Requesting_PersonID, fk_VenueID, fk_Venue_PricingID, fk_Venue_ScopeID) 
                OUTPUT INSERTED.pk_ReservationID 
                VALUES (@fld_Control_Number, @fld_Start_Date, @fld_End_Date, @fld_Start_Time, @fld_End_Time, @fld_Activity_Name, @fld_Number_Of_Participants, @fld_Reservation_Status, @fld_Reservation_Type, @Total_Amount, @Requesting_PersonID, @VenueID, @VenuePricingID, @VenueScopeID)", conn, transaction);

                cmd.Parameters.AddWithValue("@fld_Control_Number", txt_controlnum.Text);
                cmd.Parameters.AddWithValue("@fld_Start_Date", date_of_use_start.Value);
                cmd.Parameters.AddWithValue("@fld_End_Date", date_of_use_end.Value);
                cmd.Parameters.AddWithValue("@fld_Start_Time", TimeStart.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@fld_End_Time", TimeEnd.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@fld_Activity_Name", txt_activity.Text);
                cmd.Parameters.AddWithValue("@fld_Reservation_Type", "Venue");
                cmd.Parameters.AddWithValue("@fld_Number_Of_Participants", num_participants.Value);
                cmd.Parameters.AddWithValue("@Total_Amount", txt_rate.Text);
                cmd.Parameters.AddWithValue("@fld_Reservation_Status", "Pending");
                cmd.Parameters.AddWithValue("@Requesting_PersonID", personID);
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                cmd.Parameters.AddWithValue("@VenuePricingID", venuePricingID);
                cmd.Parameters.AddWithValue("@VenueScopeID", venueScopeID);

                int reservationID = (int)cmd.ExecuteScalar();




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
                    MessageBox.Show("Error: " + ex.Message + " Please ensure all data meets the required constraints.", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void combo_ReservationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsReservationTypeAndScopeSelected())
            {
                LoadRate();
            }
        }

        private void combo_scope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsReservationTypeAndScopeSelected())
            {
                LoadRate();
            }
        }

        private void TimeStart_ValueChanged(object sender, EventArgs e)
        {
            if (IsReservationTypeAndScopeSelected())
            {
                LoadRate();
            }
        }

        private void TimeEnd_ValueChanged(object sender, EventArgs e)
        {
            if (IsReservationTypeAndScopeSelected())
            {
                LoadRate();
            }
        }

        private void radio_aircon_CheckedChanged(object sender, EventArgs e)
        {
            if (IsReservationTypeAndScopeSelected())
            {
                LoadRate();
            }
        }

        // Helper method to validate the contact number
        private bool IsValidContactNumber(string contactNumber)
        {
            // validation
            // Ensure the contact number is 10-15 digits long and may contain spaces, dashes, and parentheses
            string cleanedContactNumber = new string(contactNumber.Where(char.IsDigit).ToArray());
            return cleanedContactNumber.Length >= 10 && cleanedContactNumber.Length <= 15;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void panel_faci_Paint(object sender, PaintEventArgs e) { }

        private void txt_controlnum_TextChanged(object sender, EventArgs e) { }

        private void btn_clearform_Click(object sender, EventArgs e)
        {
            // Clear textboxes
            txt_surname.Clear();
            txt_firstname.Clear();
            txt_address.Clear();
            txt_contact.Clear();
            txt_requestorigin.Clear();
            txt_controlnum.Clear();
            txt_activity.Clear();
            txt_rate.Clear();

            // Reset DateTimePickers to current date and time
            date_of_use_start.Value = DateTime.Now;
            date_of_use_end.Value = DateTime.Now;
            TimeStart.Value = DateTime.Now;
            TimeEnd.Value = DateTime.Now;

            // Reset ComboBoxes to default selection
            if (combo_venues.Items.Count > 0)
                combo_venues.SelectedIndex = 0;
            if (combo_scope.Items.Count > 0)
                combo_scope.SelectedIndex = 0;
            if (combo_ReservationType.Items.Count > 0)
                combo_ReservationType.SelectedIndex = 0;

            // Reset RadioButtons
            radio_Yes.Checked = false;
            radio_No.Checked = false;

            // Optionally, reset any other controls as needed
        }

        // Load reserved dates from the database
        private void LoadReservedDates(int venueID)
        {
            reservedDates = new List<DateTime>();
            try
            {
                DBConnect();
                cmd = new SqlCommand("SELECT fld_Start_Date, fld_End_Date FROM tbl_Reservation WHERE fk_VenueID = @VenueID", conn);
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime startDate = reader.GetDateTime(0);
                    DateTime endDate = reader.GetDateTime(1);
                    for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                    {
                        reservedDates.Add(date);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reserved dates: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }

        private void date_of_use_start_ValueChanged(object sender, EventArgs e)
        {
            // Check if the selected date is reserved
            if (reservedDates.Contains(date_of_use_start.Value.Date))
            {
                MessageBox.Show("The selected start date is already reserved for this venue. Please choose another date.", "Date Reserved", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Temporarily unsubscribe from the event
                date_of_use_start.ValueChanged -= date_of_use_start_ValueChanged;
                date_of_use_start.Value = DateTime.Now; // Reset to current date
                // Re-subscribe to the event
                date_of_use_start.ValueChanged += date_of_use_start_ValueChanged;
            }
        }

        private void date_of_use_end_ValueChanged(object sender, EventArgs e)
        {
            // Check if the selected date is reserved
            if (reservedDates.Contains(date_of_use_end.Value.Date))
            {
                MessageBox.Show("The selected end date is already reserved for this venue. Please choose another date.", "Date Reserved", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Temporarily unsubscribe from the event
                date_of_use_end.ValueChanged -= date_of_use_end_ValueChanged;
                date_of_use_end.Value = DateTime.Now; // Reset to current date
                // Re-subscribe to the event
                date_of_use_end.ValueChanged += date_of_use_end_ValueChanged;
            }
        }
       /* private void LoadReservationTypes()
        {
            combo_Reservation_Type.Items.Add("Venue");
            combo_Reservation_Type.Items.Add("Equipment");
            combo_Reservation_Type.SelectedIndexChanged += combo_Reservation_Type_SelectedIndexChanged;
        }
       */
       /* private void combo_Reservation_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Reservation_Type.SelectedItem != null)
            {
                string selectedType = combo_Reservation_Type.SelectedItem.ToString();
                if (selectedType == "Equipment")
                {
                    panel_Rev_Type.Enabled = true;
                    panel_Venue.Enabled = false;
                }
                else
                {
                    panel_Rev_Type.Enabled = false;
                    panel_Venue.Enabled = true;


                }
            }
        }*/

        private void txt_rate_TextChanged(object sender, EventArgs e)
        {

        }



        private void combo_Utility_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel_Rev_Type_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Venue_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Reservation_Type_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
