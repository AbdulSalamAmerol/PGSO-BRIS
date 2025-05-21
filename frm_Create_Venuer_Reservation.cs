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
        private string contactPlaceholder = "09685744...";
        private bool isContactPlaceholderActive = true;
        public frm_Create_Venuer_Reservation()
        {
            InitializeComponent();
            txt_contact.MaxLength = 11; // Limit to 12 characters
            txt_rate.TextChanged += FormatDecimalWithCommas;
            txt_Succeeding_Hour.TextChanged += FormatDecimalWithCommas;
            txt_Total.TextChanged += FormatDecimalWithCommas;
            SetContactPlaceholder();
            txt_contact.Enter += Txt_Contact_Enter;
            txt_contact.Leave += Txt_Contact_Leave;

            // Set up time pickers
            TimeStart.Format = DateTimePickerFormat.Custom;
            TimeStart.CustomFormat = "hh:mm tt";
            TimeStart.Value = DateTime.Today.AddHours(8); // 8:00 AM

            TimeEnd.Format = DateTimePickerFormat.Custom;
            TimeEnd.CustomFormat = "hh:mm tt";
            TimeEnd.Value = DateTime.Today.AddHours(17); // 5:00 PM

            // Wire up events
            TimeStart.ValueChanged += TimeStart_ValueChanged;
            TimeEnd.ValueChanged += TimeEnd_ValueChanged;


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
            txt_Succeeding_Hour.TextChanged += (sender, e) => CalculateTotalAmount();
            combo_Request.Items.Add("Call");
            combo_Request.Items.Add("Letter");
            combo_Request.Items.Add("Walk In");
            CalculateTotalAmount();
            txt_controlnum.Text = GenerateControlNumber();

            // Set MinDate to prevent selecting past dates
            date_of_use_start.MinDate = DateTime.Now.Date;
            date_of_use_end.MinDate = DateTime.Now.Date;

            // Set DropDownStyle to DropDownList during initialization
            combo_Request.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void frm_createvenuereservation_Load(object sender, EventArgs e)
        {
            LoadVenues();
             date_of_use_start.ValueChanged += date_of_use_start_ValueChanged;
            date_of_use_end.ValueChanged += date_of_use_end_ValueChanged;
            TimeStart.ValueChanged += TimeStart_ValueChanged;
            TimeEnd.ValueChanged += TimeEnd_ValueChanged;
            txt_controlnum.Text = GenerateControlNumber();

            DisableManualInput(date_of_use_start);
            DisableManualInput(date_of_use_end);
            DisableManualInput(TimeStart);
            DisableManualInput(TimeEnd);
        
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

        private void SetContactPlaceholder()
        {
            txt_contact.Text = contactPlaceholder;
            txt_contact.ForeColor = System.Drawing.Color.Gray;
            isContactPlaceholderActive = true;
        }

        private void RemoveContactPlaceholder()
        {
            if (isContactPlaceholderActive)
            {
                txt_contact.Text = "";
                txt_contact.ForeColor = System.Drawing.Color.Black;
                isContactPlaceholderActive = false;
            }
        }

        private void Txt_Contact_Enter(object sender, EventArgs e)
        {
            RemoveContactPlaceholder();
        }

        private void Txt_Contact_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_contact.Text))
            {
                SetContactPlaceholder();
            }
        }

        private void DisableManualInput(DateTimePicker dateTimePicker)
        {
            dateTimePicker.ShowUpDown = false; // Ensure dropdown calendar is shown
            dateTimePicker.KeyPress += (s, e) => e.Handled = true; // Suppress key presses
            dateTimePicker.KeyDown += (s, e) => e.Handled = true; // Suppress key down events
        }
        private void FormatDecimalWithCommas(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (txt == null) return;

            // Remove commas for parsing
            string raw = txt.Text.Replace(",", "");
            if (decimal.TryParse(raw, out decimal value))
            {
                // Only reformat if the value actually changes to avoid cursor jump
                string formatted = value.ToString("N2");
                if (txt.Text != formatted)
                {
                    int selStart = txt.SelectionStart;
                    txt.Text = formatted;
                    // Try to keep the cursor at the right place
                    txt.SelectionStart = Math.Min(selStart + (txt.Text.Length - raw.Length), txt.Text.Length);
                }
            }
            else if (!string.IsNullOrEmpty(txt.Text))
            {
                // If not a valid decimal, remove non-numeric characters except dot
                txt.Text = new string(txt.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());
                txt.SelectionStart = txt.Text.Length;
            }
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

                // Insert placeholder row at the top with pk_VenueID = -1
                DataRow placeholderRow = dt.NewRow();
                placeholderRow["pk_VenueID"] = -1; // Use -1 as a placeholder value
                placeholderRow["fld_Venue_Name"] = "Choose venue";
                dt.Rows.InsertAt(placeholderRow, 0);

                combo_venues.DataSource = dt;
                combo_venues.ValueMember = "pk_VenueID";
                combo_venues.DisplayMember = "fld_Venue_Name";
                combo_venues.SelectedIndex = 0; // Show placeholder by default

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

                object result = cmd.ExecuteScalar();
                string lastControlNumber = result != DBNull.Value && result != null ? result.ToString() : null;

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
            combo_venues.DropDownStyle = ComboBoxStyle.DropDownList;

            if (combo_venues.SelectedValue != null)
            {
                if (int.TryParse(combo_venues.SelectedValue.ToString(), out selectedVenueID))
                {
                    LoadReservationTypesByVenue(selectedVenueID);
                    LoadVenueScope(selectedVenueID);
                    LoadReservedDates(selectedVenueID);

                    // Check aircon status after loading scope and reservation type
                    if (IsReservationTypeAndScopeSelected())
                    {
                        CheckAirconPanelStatus();
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
            if (decimal.TryParse(txt_rate.Text.Replace(",", ""), out decimal initialRate) &&
                double.TryParse(txtx_Num_Hours.Text.Replace(",", ""), out double numberOfHours) &&
                decimal.TryParse(txt_Succeeding_Hour.Text.Replace(",", ""), out decimal hourlyRate))
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

                txt_Total.Text = totalAmount.ToString("N2");
            }
            else
            {
                txt_Total.Text = "0.00";
            }
        }


        //ilagaya yung sinend

        // Load rate(from db) based on selected venue, venue scope, reservation type, and aircon selection
        private void LoadRate()
        {
            try
            {
                if (!IsReservationTypeAndScopeSelected()) return;

                string rateQuery = @"
            SELECT fld_First4Hrs_Rate, fld_Hourly_Rate 
            FROM tbl_Venue_Pricing 
            WHERE fld_Rate_Type = @RateType 
            AND fk_VenueID = @VenueID 
            AND fk_Venue_ScopeID = @VenueScopeID ";

                bool? usesAircon = null;
                if (radio_Yes.Checked)
                    usesAircon = true;
                else if (radio_No.Checked)
                    usesAircon = false;

                if (usesAircon.HasValue)
                {
                    rateQuery += "AND fld_Aircon = @UsesAircon";
                }

                else
                {
                    rateQuery += "AND fld_Aircon IS NULL";
                }

                DBConnect();
                using (SqlCommand rateCmd = new SqlCommand(rateQuery, conn))
                {
                    rateCmd.Parameters.AddWithValue("@RateType", combo_ReservationType.SelectedValue.ToString());
                    rateCmd.Parameters.AddWithValue("@VenueID", selectedVenueID);
                    rateCmd.Parameters.AddWithValue("@VenueScopeID", combo_scope.SelectedValue);
                    if (usesAircon.HasValue)
                        rateCmd.Parameters.AddWithValue("@UsesAircon", usesAircon.Value);

                    using (SqlDataReader reader = rateCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_rate.Text = reader["fld_First4Hrs_Rate"].ToString();
                            txt_Succeeding_Hour.Text = reader["fld_Hourly_Rate"].ToString();
                        }
                        else
                        {
                            txt_rate.Text = "0.00";
                            txt_Succeeding_Hour.Text = "0.00";
                        }
                    }
                }

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
        private void CheckAirconPanelStatus()
        {
            // Default to disabled if selections are invalid
            if (combo_venues.SelectedValue == null || combo_scope.SelectedValue == null || combo_ReservationType.SelectedValue == null)
            {
                panel_Aircon.Enabled = false;
                return;
            }

            try
            {
                DBConnect();
                int venueID = Convert.ToInt32(combo_venues.SelectedValue);
                int scopeID = Convert.ToInt32(combo_scope.SelectedValue);
                string rateType = combo_ReservationType.SelectedValue.ToString();

                string query = @"
        SELECT fld_Aircon 
        FROM tbl_Venue_Pricing
        WHERE fk_VenueID = @VenueID
          AND fk_Venue_ScopeID = @VenueScopeID
          AND fld_Rate_Type = @RateType";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VenueID", venueID);
                    cmd.Parameters.AddWithValue("@VenueScopeID", scopeID);
                    cmd.Parameters.AddWithValue("@RateType", rateType);

                    object result = cmd.ExecuteScalar();
                    panel_Aircon.Enabled = (result != null && result != DBNull.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking aircon: " + ex.Message);
                panel_Aircon.Enabled = false;
            }
            finally
            {
                DBClose();
            }
        }


        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;

            

            // Update the txt_Total with the aggregated total amount
            txt_Total.Text = totalAmount.ToString("0.00");
        }
        // Submit data to tbl_Reservation/tbl_Reservation_Venue/tbl_Requesting_Person
        private void btn_submit_Click(object sender, EventArgs e)
        {
            // Get values directly from form controls
            DateTime startDate = date_of_use_start.Value.Date;
            DateTime endDate = date_of_use_end.Value.Date;
            TimeSpan startTime = TimeStart.Value.TimeOfDay;
            TimeSpan endTime = TimeEnd.Value.TimeOfDay;
            var result = MessageBox.Show(
                "Are you sure you want to submit?",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return; // Cancel submission if user selects No
            }
            // Validate time conflict
            if (HasTimeConflict(startDate, endDate, startTime, endTime, selectedVenueID))
            {
                MessageBox.Show("The selected date/time conflicts with an existing reservation.",
                              "Reservation Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate required fields
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

            // Validate contact number
            string contactNumber = txt_contact.Text;
            if (string.IsNullOrEmpty(contactNumber) || !IsValidContactNumber(contactNumber))
            {
                MessageBox.Show("Contact number is invalid. Please enter a valid contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculate total amount
            CalculateTotalAmount();

            decimal initialRate, hourlyRate, totalAmount;

            bool isTotalValid = decimal.TryParse(txt_Total.Text.Replace(",", ""), out totalAmount);
            bool isRateValid = decimal.TryParse(txt_rate.Text.Replace(",", ""), out initialRate);
            bool isHourlyValid = decimal.TryParse(txt_Succeeding_Hour.Text.Replace(",", ""), out hourlyRate);

            if (!isTotalValid)
            {
                MessageBox.Show("Invalid total amount. Please check the input values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlTransaction transaction = null;

            try
            {
                DBConnect();
                transaction = conn.BeginTransaction();

                // Step 1: Insert into tbl_Requesting_Person
                cmd = new SqlCommand(@"
        INSERT INTO tbl_Requesting_Person 
        (fld_Surname, fld_First_Name, fld_Middle_Name, fld_Requesting_Person_Address, fld_Contact_Number, fld_Request_Origin, fld_Requesting_Office) 
        OUTPUT INSERTED.pk_Requesting_PersonID 
        VALUES (@Surname, @FirstName, @MiddleName, @Address, @ContactNumber, @RequestOrigin, @Requesting_Office)", conn, transaction);

                cmd.Parameters.AddWithValue("@Surname", txt_surname.Text);
                cmd.Parameters.AddWithValue("@FirstName", txt_firstname.Text);
                cmd.Parameters.AddWithValue("@MiddleName", txt_Middle_Name.Text);
                cmd.Parameters.AddWithValue("@Address", txt_address.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@RequestOrigin", combo_Request.Text);
                cmd.Parameters.AddWithValue("@Requesting_Office", txt_Requesting_Office.Text);

                int personID = (int)cmd.ExecuteScalar();

                // Step 2: Get venue pricing ID
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

                // Step 3: Insert into tbl_Reservation
                cmd = new SqlCommand(@"
        INSERT INTO tbl_Reservation 
        (fld_Control_Number, fld_Start_Date, fld_End_Date, fld_Start_Time, fld_End_Time, fld_Activity_Name, 
        fld_Number_Of_Participants, fld_Reservation_Status, fld_Reservation_Type, fld_Total_Amount, 
        fk_Requesting_PersonID, fk_VenueID, fk_Venue_PricingID, fk_Venue_ScopeID, fld_Created_At) 
        OUTPUT INSERTED.pk_ReservationID 
        VALUES (@ControlNumber, @StartDate, @EndDate, @StartTime, @EndTime, @ActivityName, 
        @NumberOfParticipants, @ReservationStatus, @ReservationType, @TotalAmount, 
        @RequestingPersonID, @VenueID, @VenuePricingID, @VenueScopeID, @CreatedAt)", conn, transaction);

                cmd.Parameters.AddWithValue("@ControlNumber", txt_controlnum.Text);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@EndTime", endTime);
                cmd.Parameters.AddWithValue("@ActivityName", txt_activity.Text);
                cmd.Parameters.AddWithValue("@NumberOfParticipants", num_participants.Value);
                cmd.Parameters.AddWithValue("@ReservationStatus", "Pending");
                cmd.Parameters.AddWithValue("@ReservationType", "Venue");
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@RequestingPersonID", personID);
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                cmd.Parameters.AddWithValue("@VenuePricingID", venuePricingID);
                cmd.Parameters.AddWithValue("@VenueScopeID", venueScopeID);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                int reservationID = (int)cmd.ExecuteScalar();

                // Step 4: Insert into tbl_Reservation_Venues
                using (SqlCommand venueCmd = new SqlCommand(@"
        INSERT INTO tbl_Reservation_Venues 
        (fk_ReservationID, fk_VenueID, fk_Venue_ScopeID, fld_Start_Date, fld_End_Date, 
        fld_Start_Time, fld_End_Time, fld_Total_Amount, fld_Participants) 
        VALUES (@ReservationID, @VenueID, @ScopeID, @StartDate, @EndDate, 
                @StartTime, @EndTime, @TotalAmount, @Participants)", conn, transaction))
                {
                    venueCmd.Parameters.AddWithValue("@ReservationID", reservationID);
                    venueCmd.Parameters.AddWithValue("@VenueID", venueID);
                    venueCmd.Parameters.AddWithValue("@ScopeID", venueScopeID);
                    venueCmd.Parameters.AddWithValue("@StartDate", startDate);
                    venueCmd.Parameters.AddWithValue("@EndDate", endDate);
                    venueCmd.Parameters.AddWithValue("@StartTime", startTime);
                    venueCmd.Parameters.AddWithValue("@EndTime", endTime);
                    venueCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    venueCmd.Parameters.AddWithValue("@Participants", num_participants.Value);

                    venueCmd.ExecuteNonQuery();
                }

                // Commit transaction
                transaction.Commit();

                MessageBox.Show("Reservation submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                // Refresh control number and clear form
                txt_controlnum.Text = GenerateControlNumber();
                btn_clearform_Click(sender, e);
                RefreshCalendarView();
            }
            catch (SqlException ex)
            {
                transaction?.Rollback();

                if (ex.Message.Contains("CK_ValidDate"))
                {
                    MessageBox.Show("The selected date must be from the current date to future dates.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBClose();
            }
        }

        private void RefreshCalendarView()
        {
            // Find all open calendar forms and refresh them
            foreach (Form form in Application.OpenForms)
            {
                if (form is frm_Calendar calendarForm)
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
            combo_ReservationType.DropDownStyle = ComboBoxStyle.DropDownList;

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
            // Force AM time
            if (TimeStart.Value.Hour >= 12)
            {
                TimeStart.Value = TimeStart.Value.Date.AddHours(TimeStart.Value.Hour - 12);
            }
            if (IsReservationTypeAndScopeSelected())
            {
                LoadRate();
            }
        }
        private void TimeEnd_ValueChanged(object sender, EventArgs e)
        {
            // Force PM time
            if (TimeEnd.Value.Hour < 12)
            {
                TimeEnd.Value = TimeEnd.Value.Date.AddHours(TimeEnd.Value.Hour + 12);
            }
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
                txt_Middle_Name.Clear(); // Clear Middle Name
                txt_address.Clear();
                txt_contact.Clear();
                txt_activity.Clear();
                txt_Requesting_Office.Clear(); // Clear Requesting Office
                txt_rate.Clear();
                txt_Succeeding_Hour.Clear(); // Clear Hourly Rate
                txtx_Num_Hours.Text = "0.00"; // Reset Number of Hours

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
                if (combo_Request.Items.Count > 0)
                    combo_Request.SelectedIndex = -1; // Reset Request Origin

                // Reset RadioButtons
                radio_Yes.Checked = false;
                radio_No.Checked = false;


                // Reload Venues and Scope
                LoadVenues();
                if (combo_venues.SelectedValue != null && int.TryParse(combo_venues.SelectedValue.ToString(), out int venueID))
                {
                    LoadVenueScope(venueID);
                }
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
            combo_Request.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txt_firstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txt_surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void combo_scope_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            combo_scope.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        
        private bool HasTimeConflict(DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime, int venueID)
        {
            try
            {
                DBConnect();
                string query = @"
            SELECT 1 
            FROM tbl_Reservation r
            JOIN tbl_Reservation_Venues rv ON r.pk_ReservationID = rv.fk_ReservationID
            WHERE r.fk_VenueID = @VenueID
            AND r.fld_Reservation_Status IN ('Confirmed', 'Pending')
            AND (
                -- Existing reservation starts during new reservation
                (rv.fld_Start_Date <= @EndDate AND rv.fld_End_Date >= @StartDate)
                AND (
                    -- Time overlap conditions
                    (rv.fld_Start_Time < @EndTime AND rv.fld_End_Time > @StartTime)
                    OR -- Multi-day reservation that covers our time window
                    (rv.fld_Start_Date < rv.fld_End_Date)
                )
            )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VenueID", venueID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Parameters.AddWithValue("@StartTime", startTime);
                    cmd.Parameters.AddWithValue("@EndTime", endTime);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows; // Returns true if conflicts exist
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking time conflicts: " + ex.Message);
                return true; // Assume conflict exists if error occurs
            }
            finally
            {
                DBClose();
            }
        }
        private bool ValidateSelectedDates()
        {
            if (combo_venues.SelectedValue == null || !int.TryParse(combo_venues.SelectedValue.ToString(), out int venueID))
            {
                MessageBox.Show("Please select a venue first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime startDate = date_of_use_start.Value.Date;
            DateTime endDate = date_of_use_end.Value.Date;
            TimeSpan startTime = TimeStart.Value.TimeOfDay;
            TimeSpan endTime = TimeEnd.Value.TimeOfDay;

            // Basic date validation
            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (startDate == endDate && startTime >= endTime)
            {
                MessageBox.Show("Start time must be earlier than end time for the same day.", "Invalid Time Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check for time conflicts
            if (HasTimeConflict(startDate, endDate, startTime, endTime, venueID))
            {
                MessageBox.Show("The selected date/time range conflicts with an existing reservation. Please choose different dates/times.",
                               "Reservation Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void panel_Aircon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Total_TextChanged(object sender, EventArgs e)
        {

        }
    }
}