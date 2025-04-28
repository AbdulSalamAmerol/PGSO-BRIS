using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using pgso_connect;

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

            CalculateNumberOfHour();

            TimeStart.ValueChanged += Time_ValueChanged;
            TimeEnd.ValueChanged += Time_ValueChanged;
            txt_rate.TextChanged += (sender, e) => CalculateTotalAmount();
            txtx_Num_Hours.TextChanged += (sender, e) => CalculateTotalAmount();
            txt_Hourly_Rate.TextChanged += (sender, e) => CalculateTotalAmount();
            combo_Request.Items.Add("Call");
            combo_Request.Items.Add("Letter");
            combo_Request.Items.Add("Walk In");
            CalculateTotalAmount();
            txt_controlnum.Text = GenerateControlNumber();

            // Set MinDate to prevent selecting past dates
            date_of_use_start.MinDate = DateTime.Now.Date;
            date_of_use_end.MinDate = DateTime.Now.Date;

        }
        private void frm_createvenuereservation_Load(object sender, EventArgs e)
        {
            LoadVenues();
            //  date_of_use_start.ValueChanged += date_of_use_start_ValueChanged;
            //date_of_use_end.ValueChanged += date_of_use_end_ValueChanged;
            TimeStart.ValueChanged += TimeStart_ValueChanged;
            TimeEnd.ValueChanged += TimeEnd_ValueChanged;
            txt_controlnum.Text = GenerateControlNumber();
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

        // Calculate the number of hours
        private void Time_ValueChanged(object sender, EventArgs e)
        {
            CalculateNumberOfHour();
        }

        

        private void CalculateNumberOfHour()
        {
            DateTime startDateTime = date_of_use_start.Value.Date + TimeStart.Value.TimeOfDay;
            DateTime endDateTime = date_of_use_end.Value.Date + TimeEnd.Value.TimeOfDay;

            TimeSpan difference = endDateTime - startDateTime;
            double numberOfHours = difference.TotalHours;

            // Check if the number of hours is negative
            if (numberOfHours < 0)
            {
                MessageBox.Show("The number of hours must not be negative. Please adjust the start and end times.",
                                "Invalid Number of Hours", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reset the number of hours to 0
                txtx_Num_Hours.Text = "0.00";
                return; // Exit the method
            }

            txtx_Num_Hours.Text = numberOfHours.ToString("0.00");

            // Force calculation after updating hours
            CalculateTotalAmount();
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

        //Auto generate control number
        private string GenerateControlNumber()
        {
            try
            {
                DBConnect();

                int currentYear = DateTime.Now.Year;

                // Query to get the MAX control number for current year
                cmd = new SqlCommand(
                    "SELECT MAX(fld_Control_Number) FROM tbl_Reservation " +
                    "WHERE fld_Control_Number LIKE 'CN-___-" + currentYear + "'", conn);

                string lastControlNumber = (string)cmd.ExecuteScalar();

                int nextNumber = 1; // Default if no records exist

                if (!string.IsNullOrEmpty(lastControlNumber))
                {
                    // Extract the numeric part (positions 3-5: CN-001-2025 → 001)
                    string numberPart = lastControlNumber.Substring(3, 3);
                    if (int.TryParse(numberPart, out int lastNumber))
                    {
                        nextNumber = lastNumber + 1;

                        // Reset to 1 if we exceed 999
                        if (nextNumber > 999)
                        {
                            nextNumber = 1;
                        }
                    }
                }

                return $"CN-{nextNumber:D3}-{currentYear}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating control number: " + ex.Message);
                return $"CN-001-{DateTime.Now.Year}"; // Fallback
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

        // Calculate total amount
        private void CalculateTotalAmount()
        {
            if (decimal.TryParse(txt_rate.Text, out decimal initialRate) &&
                double.TryParse(txtx_Num_Hours.Text, out double numberOfHours) &&
                decimal.TryParse(txt_Hourly_Rate.Text, out decimal hourlyRate))
            {
                decimal totalAmount;

                if (numberOfHours > 4)
                {
                    totalAmount = initialRate + (hourlyRate * (decimal)(numberOfHours - 4));
                }
                else
                {
                    totalAmount = initialRate;
                }

                // Update the txt_Total with the calculated total amount
                txt_Total.Text = totalAmount.ToString("0.00");
            }
            else
            {
                txt_Total.Text = "0.00";
            }
        }

        // Load rate(from db) based on selected venue, venue scope, reservation type, and aircon selection
        private void LoadRate()
        {
            try
            {
                if (!IsReservationTypeAndScopeSelected()) return;

                bool usesAircon = radio_Yes.Checked;

                DBConnect();
                string rateQuery = @"
                    SELECT fld_First4Hrs_Rate, fld_Hourly_Rate 
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

                    using (SqlDataReader reader = rateCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_rate.Text = reader["fld_First4Hrs_Rate"].ToString();
                            txt_Hourly_Rate.Text = reader["fld_Hourly_Rate"].ToString();
                        }
                        else
                        {
                            txt_rate.Text = "0.00";
                            txt_Hourly_Rate.Text = "0.00";
                        }
                    }
                }

                // Force calculation after updating rates
                CalculateTotalAmount();
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

        // Submit data to tbl_Reservation/tbl_Reservation_Venue/tbl_Requesting_Person
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

                // Step 1: Validate the input
                if (string.IsNullOrWhiteSpace(txt_controlnum.Text))
                {
                    MessageBox.Show("Control number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_activity.Text))
                {
                    MessageBox.Show("Activity name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (combo_venues.SelectedValue == null || combo_scope.SelectedValue == null || combo_ReservationType.SelectedValue == null)
                {
                    MessageBox.Show("Please select a venue, scope, and reservation type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate the contact number
                string contactNumber = txt_contact.Text;
                if (string.IsNullOrEmpty(contactNumber) || !IsValidContactNumber(contactNumber))
                {
                    MessageBox.Show("Contact number is invalid. Please enter a valid contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Insert into tbl_Requesting_Person
                cmd = new SqlCommand(@"
                    INSERT INTO tbl_Requesting_Person 
                    (fld_Surname, fld_First_Name, fld_Requesting_Person_Address, fld_Contact_Number, fld_Request_Origin, fld_Requesting_Office) 
                    OUTPUT INSERTED.pk_Requesting_PersonID 
                    VALUES (@Surname, @FirstName, @Address, @ContactNumber, @RequestOrigin, @Requesting_Office)", conn, transaction);

                cmd.Parameters.AddWithValue("@Surname", txt_surname.Text);
                cmd.Parameters.AddWithValue("@FirstName", txt_firstname.Text);
                cmd.Parameters.AddWithValue("@Address", txt_address.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@RequestOrigin", combo_Request.Text);
                cmd.Parameters.AddWithValue("@Requesting_Office", txt_Requesting_Office.Text);

                int personID = (int)cmd.ExecuteScalar();

                // Step 3: Retrieve fk_VenueID, fk_Venue_PricingID, fk_Venue_ScopeID
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

                // Step 4: Insert into tbl_Reservation
                cmd = new SqlCommand(@"
                    INSERT INTO tbl_Reservation 
                    (fld_Control_Number, fld_Start_Date, fld_End_Date, fld_Start_Time, fld_End_Time, fld_Activity_Name, 
                    fld_Number_Of_Participants, fld_Reservation_Status, fld_Reservation_Type, fld_Total_Amount, 
                    fk_Requesting_PersonID, fk_VenueID, fk_Venue_PricingID, fk_Venue_ScopeID) 
                    OUTPUT INSERTED.pk_ReservationID 
                    VALUES (@ControlNumber, @StartDate, @EndDate, @StartTime, @EndTime, @ActivityName, 
                    @NumberOfParticipants, @ReservationStatus, @ReservationType, @TotalAmount, 
                    @RequestingPersonID, @VenueID, @VenuePricingID, @VenueScopeID)", conn, transaction);

                cmd.Parameters.AddWithValue("@ControlNumber", txt_controlnum.Text);
                cmd.Parameters.AddWithValue("@StartDate", date_of_use_start.Value);
                cmd.Parameters.AddWithValue("@EndDate", date_of_use_end.Value);
                cmd.Parameters.AddWithValue("@StartTime", TimeStart.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@EndTime", TimeEnd.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@ActivityName", txt_activity.Text);
                cmd.Parameters.AddWithValue("@NumberOfParticipants", num_participants.Value);
                cmd.Parameters.AddWithValue("@ReservationStatus", "Pending");
                cmd.Parameters.AddWithValue("@ReservationType", "Venue");
                cmd.Parameters.AddWithValue("@TotalAmount", decimal.Parse(txt_Total.Text));
                cmd.Parameters.AddWithValue("@RequestingPersonID", personID);
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                cmd.Parameters.AddWithValue("@VenuePricingID", venuePricingID);
                cmd.Parameters.AddWithValue("@VenueScopeID", venueScopeID);

                int reservationID = (int)cmd.ExecuteScalar();

                // Step 5: Insert into tbl_Reservation_Venues
                cmd = new SqlCommand(@"
                INSERT INTO tbl_Reservation_Venues 
                (fk_ReservationID, fk_VenueID, fk_Venue_ScopeID, fld_Start_Date, fld_End_Date, fld_Start_Time, fld_End_Time, fld_Total_Amount, fld_Participants) 
                VALUES (@ReservationID, @VenueID, @ScopeID, @StartDate, @EndDate, @StartTime, @EndTime, @TotalAmount, @Participants)", conn, transaction);

                cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                cmd.Parameters.AddWithValue("@ScopeID", venueScopeID);
                cmd.Parameters.AddWithValue("@StartDate", date_of_use_start.Value);
                cmd.Parameters.AddWithValue("@EndDate", date_of_use_end.Value);
                cmd.Parameters.AddWithValue("@StartTime", TimeStart.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@EndTime", TimeEnd.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@TotalAmount", decimal.Parse(txt_Total.Text));
                cmd.Parameters.AddWithValue("@Participants", num_participants.Value);

                cmd.ExecuteNonQuery();

                // Commit the transaction
                transaction.Commit();

                MessageBox.Show("Venue Reservation submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh the control number
                txt_controlnum.Text = GenerateControlNumber();
                RefreshCalendarView();
                btn_clearform_Click(sender, e);
            }
            catch (SqlException ex)
            {
                // Rollback the transaction if any error occurs
                transaction?.Rollback();

                // Check for specific SQL error numbers or messages
                if (ex.Message.Contains("CK_ValidDate")) // Example: Check constraint for valid dates
                {
                    MessageBox.Show("The selected date must be from the current date to future dates.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Rollback the transaction if any error occurs
                transaction?.Rollback();
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBClose(); // Close Connection
            }
        }

        private void RefreshCalendarView()
        {
            // Find all open calendar forms and refresh them
            foreach (Form form in Application.OpenForms)
            {
                if (form is frm_Calendar_Venue calendarForm)
                {
                    if (calendarForm.InvokeRequired)
                    {
                        calendarForm.Invoke(new Action(() =>
                        {
                            calendarForm.RefreshCalendar();
                            calendarForm.BringToFront();
                        }));
                    }
                    else
                    {
                        calendarForm.RefreshCalendar();
                        calendarForm.BringToFront();
                    }
                }
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
      
            // Ensure the contact number is 10-15 digits long and may contain spaces, dashes, and parentheses
            string cleanedContactNumber = new string(contactNumber.Where(char.IsDigit).ToArray());
            return cleanedContactNumber.Length >= 10 && cleanedContactNumber.Length <= 15;
        }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void panel_faci_Paint(object sender, PaintEventArgs e) { }

        private void txt_controlnum_TextChanged(object sender, EventArgs e) { }

        private void btn_clearform_Click(object sender, EventArgs e)
        {
            // Temporarily unsubscribe from ValueChanged events
            date_of_use_start.ValueChanged -= date_of_use_start_ValueChanged;
            date_of_use_end.ValueChanged -= date_of_use_end_ValueChanged;
            TimeStart.ValueChanged -= Time_ValueChanged;
            TimeEnd.ValueChanged -= Time_ValueChanged;

            try
            {
                // Clear textboxes
                txt_surname.Clear();
                txt_firstname.Clear();
                txt_address.Clear();
                txt_contact.Clear();
                txt_activity.Clear();
                txt_rate.Clear();

                // Refresh the control number
                txt_controlnum.Text = GenerateControlNumber();

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
            finally
            {
                // Re-subscribe to ValueChanged events
                date_of_use_start.ValueChanged += date_of_use_start_ValueChanged;
                date_of_use_end.ValueChanged += date_of_use_end_ValueChanged;
                TimeStart.ValueChanged += Time_ValueChanged;
                TimeEnd.ValueChanged += Time_ValueChanged;
            }
        }



        // Load reserved dates from the database
        private void LoadReservedDates(int venueID)
        {
            reservedDates = new List<DateTime>();
            try
            {
                DBConnect();
                cmd = new SqlCommand(@"
            SELECT fld_Start_Date, fld_End_Date 
            FROM tbl_Reservation 
            WHERE fk_VenueID = @VenueID 
              AND fld_Reservation_Status IN ('Confirmed', 'Pending')", conn);
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1)) // Ensure dates are not null
                    {
                        DateTime startDate = reader.GetDateTime(0);
                        DateTime endDate = reader.GetDateTime(1);
                        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                        {
                            reservedDates.Add(date);
                        }
                    }
                }

                reader.Close();

                // Debugging: Log reserved dates
                Console.WriteLine("Reserved Dates:");
                foreach (var date in reservedDates)
                {
                    Console.WriteLine(date.ToShortDateString());
                }
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
            // Ensure reservedDates is initialized
            if (reservedDates == null)
            {
                reservedDates = new List<DateTime>();
            }

            // Check if the selected date is reserved
            if (reservedDates.Contains(date_of_use_start.Value.Date))
            {
                MessageBox.Show("The selected start date is already reserved for this venue. Please choose another date.",
                                "Date Reserved", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Temporarily unsubscribe from the event
                date_of_use_start.ValueChanged -= date_of_use_start_ValueChanged;
                date_of_use_start.Value = DateTime.Now.Date; // Reset to the current date
                                                             // Re-subscribe to the event
                date_of_use_start.ValueChanged += date_of_use_start_ValueChanged;
            }
        }





        private void txt_rate_TextChanged(object sender, EventArgs e) { }
        private void combo_Utility_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void panel_Rev_Type_Paint(object sender, PaintEventArgs e) { }
        private void panel_Venue_Paint(object sender, PaintEventArgs e) { }
        private void txt_Reservation_Type_TextChanged(object sender, EventArgs e) { }
        private void txtx_Num_Hours_TextChanged(object sender, EventArgs e)
        { }

        private void combo_Request_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Request.SelectedItem == null)
            {
                return;
            }

            switch (combo_Request.SelectedItem.ToString())
            {
                case "Call":
                    break;
                case "Letter":
                    break;
                case "Walk In":
                    break;
                default:
                    break;
            }
        }

        private void num_participants_ValueChanged(object sender, EventArgs e)
        {
            this.num_participants.Maximum = 50000; // Set to 50,000 or any desired value

        }

        private void date_of_use_end_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"date_of_use_end_ValueChanged triggered. Selected Date: {date_of_use_end.Value.Date}");

            // Ensure reservedDates is initialized
            if (reservedDates == null)
            {
                reservedDates = new List<DateTime>();
            }

            // Check if the selected date is the current date
            if (date_of_use_end.Value.Date == DateTime.Now.Date)
            {
                MessageBox.Show("The selected end date cannot be the current date. Please choose another date.",
                                "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Temporarily unsubscribe from the event
                date_of_use_end.ValueChanged -= date_of_use_end_ValueChanged;
                date_of_use_end.Value = DateTime.Now.AddDays(1); // Reset to the next day
                                                                 // Re-subscribe to the event
                date_of_use_end.ValueChanged += date_of_use_end_ValueChanged;

                return; // Exit the method
            }

            // Check if the selected date is in the past
            if (date_of_use_end.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("The selected end date cannot be in the past. Please choose a valid date.",
                                "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Temporarily unsubscribe from the event
                date_of_use_end.ValueChanged -= date_of_use_end_ValueChanged;
                date_of_use_end.Value = DateTime.Now.AddDays(1); // Reset to the next day
                                                                 // Re-subscribe to the event
                date_of_use_end.ValueChanged += date_of_use_end_ValueChanged;

                return; // Exit the method
            }

            // Check if the selected date is reserved
            if (reservedDates.Contains(date_of_use_end.Value.Date))
            {
                MessageBox.Show("The selected end date is already reserved for this venue. Please choose another date.",
                                "Date Reserved", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Temporarily unsubscribe from the event
                date_of_use_end.ValueChanged -= date_of_use_end_ValueChanged;
                date_of_use_end.Value = DateTime.Now.AddDays(1); // Reset to the next day
                                                                 // Re-subscribe to the event
                date_of_use_end.ValueChanged += date_of_use_end_ValueChanged;
            }
        }

        private void TimeEnd_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}