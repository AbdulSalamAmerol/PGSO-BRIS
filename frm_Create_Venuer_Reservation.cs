//using Interop.WIA;
using pgso_connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WIA;


namespace pgso
{
    public partial class frm_Create_Venuer_Reservation : Form
    {
        private byte[] scannedImageBytes;

        private SqlConnection conn;
        private SqlCommand cmd;
        private int selectedVenueID;  // Class-level variable to store selected venue ID
        private List<DateTime> reservedDates; // List to store reserved dates

        private bool isContactPlaceholderActive = true;
        private decimal additionalCharge = 0m;
        private decimal currentCatererFee = 0m;

        // Add at the top of your class
        private DataTable clientInfoTable;
        private DataTable requestingPersonTable;
        private readonly string comboNamePlaceholder = "Surname, First Name Middle Name";
        private Color comboNamePlaceholderColor = Color.Gray;
        private Color comboNameNormalColor = SystemColors.WindowText;

        public frm_Create_Venuer_Reservation()
        {
            InitializeComponent();


            radio_Yes.Checked = false;
            radio_No.Checked = false;
            txt_contact.MaxLength = 11; // Limit to 12 characters
            txt_rate.TextChanged += FormatDecimalWithCommas;
            txt_Succeeding_Hour.TextChanged += FormatDecimalWithCommas;
            txt_Total.TextChanged += FormatDecimalWithCommas;
            combo_Name.Validating += combo_Name_Validating;

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
            this.Size = new Size(680, 643); // Initial form size

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
            combo_Special.Items.AddRange(new[] { "PWD", "SENIOR CITIZEN", "OTHERS" });
            combo_Special.DropDownStyle = ComboBoxStyle.DropDownList;
            // Set MinDate to prevent selecting past dates
            date_of_use_start.MinDate = DateTime.Now.Date;
            date_of_use_end.MinDate = DateTime.Now.Date;

            // Set DropDownStyle to DropDownList during initialization
            combo_Request.DropDownStyle = ComboBoxStyle.DropDownList;
            // combo_Special.Enabled = false;
            combo_Name.AutoCompleteMode = AutoCompleteMode.None;
            combo_Name.AutoCompleteSource = AutoCompleteSource.None;

            // Allow typing and dropdown selection
            combo_Name.DropDownStyle = ComboBoxStyle.DropDown;

            combo_Name.SelectionChangeCommitted += combo_Name_SelectionChangeCommitted;
            InitializeRequestingPersonAutocomplete();
            combo_Name.TextUpdate += combo_Name_TextUpdate;
            combo_Name.SelectedIndexChanged += combo_Name_SelectedIndexChanged;

            // Set placeholder initially
            SetComboNamePlaceholder();

            // Wire up events
            combo_Name.GotFocus += Combo_Name_GotFocus;
            combo_Name.LostFocus += Combo_Name_LostFocus;

        }
        private void frm_createvenuereservation_Load(object sender, EventArgs e)
        {
            radio_Yes.Checked = true;   // Auto-check Yes
            radio_No.Checked = false;   // Ensure No is unchecked

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
        private void InitializeRequestingPersonAutocomplete()
        {
            try
            {
                DBConnect();
                string query = @"SELECT pk_Requesting_PersonID, fld_Surname, fld_First_Name, fld_Middle_Name, fld_Requesting_Person_Address, fld_Contact_Number, fld_Requesting_Office FROM tbl_Requesting_Person";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    requestingPersonTable = new DataTable();
                    adapter.Fill(requestingPersonTable);
                }

                combo_Name.Items.Clear();

                // Group by all name fields and office for uniqueness
                var groups = requestingPersonTable.AsEnumerable()
                    .GroupBy(row => new
                    {
                        Surname = (row["fld_Surname"]?.ToString().Trim() ?? ""),
                        FirstName = (row["fld_First_Name"]?.ToString().Trim() ?? ""),
                        MiddleName = (row["fld_Middle_Name"]?.ToString().Trim() ?? ""),
                        Office = (row["fld_Requesting_Office"]?.ToString().Trim() ?? "")
                    });

                foreach (var group in groups)
                {
                    string display = group.Key.Surname;
                    if (!string.IsNullOrEmpty(group.Key.FirstName))
                        display += ", " + group.Key.FirstName;
                    if (!string.IsNullOrEmpty(group.Key.MiddleName))
                        display += " " + group.Key.MiddleName;
                    display = display.Trim();

                    if (!string.IsNullOrEmpty(group.Key.Office))
                        display += $" ({group.Key.Office})";

                    combo_Name.Items.Add(display);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requesting person info: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }
        private void InitializeClientInfoAutocomplete()
        {
            try
            {
                DBConnect();
                // Fetch all client info
                string query = @"SELECT pk_ClientID, fld_Fname, fld_Street, fld_Barangay, fld_Municipality, fld_Province, fld_Contact, fld_Office 
                 FROM tbl_Client_Info";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    clientInfoTable = new DataTable();
                    adapter.Fill(clientInfoTable);
                }

                // Prepare autocomplete source
                var autoCompleteCollection = new AutoCompleteStringCollection();
                foreach (DataRow row in clientInfoTable.Rows)
                {
                    string fullName = row["fld_Fname"].ToString().Trim();
                    autoCompleteCollection.Add(fullName);
                }

                combo_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combo_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;
                combo_Name.AutoCompleteCustomSource = autoCompleteCollection;

                // Also set as dropdown items for selection
                combo_Name.Items.Clear();
                foreach (string name in autoCompleteCollection)
                {
                    combo_Name.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading client info: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }
        // Calculate the number of hours
        private void Time_ValueChanged(object sender, EventArgs e)
        {
            CalculateNumberOfHour();
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
        private double _unroundedTotalHours = 0;

        private void CalculateNumberOfHour()
        {    // Remove seconds and milliseconds from TimeStart and TimeEnd
            DateTime startDateTime = date_of_use_start.Value.Date
       + new TimeSpan(TimeStart.Value.TimeOfDay.Hours, TimeStart.Value.TimeOfDay.Minutes, 0);
            DateTime endDateTime = date_of_use_end.Value.Date
                + new TimeSpan(TimeEnd.Value.TimeOfDay.Hours, TimeEnd.Value.TimeOfDay.Minutes, 0);

            TimeSpan difference = endDateTime - startDateTime;

            if (difference.TotalMinutes < 0)
            {
                MessageBox.Show("The number of hours must not be negative. Please adjust the start and end times.",
                                "Invalid Number of Hours", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtx_Num_Hours.Text = "0.00";
                _unroundedTotalHours = 0;
                return;
            }

            _unroundedTotalHours = difference.TotalHours;
            txtx_Num_Hours.Text = _unroundedTotalHours.ToString(); // show full precision. for display

            CalculateTotalAmount();
        }




        // Load venues and populate combo_venues
        private void LoadVenues()
        {
            string query = "SELECT pk_VenueID, fld_Venue_Name FROM tbl_Venue";
            try
            {
                var db = new Connection();
                using (var conn = db.strCon)
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        DataRow placeholderRow = dt.NewRow();
                        placeholderRow["pk_VenueID"] = -1;
                        placeholderRow["fld_Venue_Name"] = "Choose venue";
                        dt.Rows.InsertAt(placeholderRow, 0);

                        combo_venues.DataSource = dt;
                        combo_venues.ValueMember = "pk_VenueID";
                        combo_venues.DisplayMember = "fld_Venue_Name";
                        combo_venues.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading venues: " + ex.Message);
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
                cmd = new SqlCommand(
                    "SELECT DISTINCT fld_Rate_Type FROM tbl_Venue_Pricing WHERE fk_VenueID = @VenueID AND fld_Rate_Type IN ('Regular', 'Special')", conn);
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                reader.Close();
                // Add placeholder at the top
                DataRow placeholderRow = dt.NewRow();
                placeholderRow["fld_Rate_Type"] = "--Select--";
                dt.Rows.InsertAt(placeholderRow, 0);

                // Ensure the column exists before adding PGNV
                if (!dt.Columns.Contains("fld_Rate_Type"))
                {
                    dt.Columns.Add("fld_Rate_Type", typeof(string));
                }


                // Manually add PGNV as an extra option
                DataRow pgnvRow = dt.NewRow();
                pgnvRow["fld_Rate_Type"] = "PGNV";
                dt.Rows.Add(pgnvRow);

                // Only assign if there are rows
                if (dt.Rows.Count > 0)
                {
                    combo_ReservationType.DataSource = dt;
                    combo_ReservationType.ValueMember = "fld_Rate_Type";
                    combo_ReservationType.DisplayMember = "fld_Rate_Type";
                }
                else
                {
                    combo_ReservationType.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservation types: " + ex.Message);
                combo_ReservationType.DataSource = null;
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

                cmd = new SqlCommand(
                    "SELECT MAX(fld_Control_Number) FROM tbl_Reservation WHERE fld_Control_Number LIKE @pattern", conn);
                cmd.Parameters.AddWithValue("@pattern", $"CN-{currentYear}-____");

                object result = cmd.ExecuteScalar();
                string lastControlNumber = result != DBNull.Value && result != null ? result.ToString() : null;

                int nextNumber = 1; // Default if no records exist

                if (!string.IsNullOrEmpty(lastControlNumber))
                {
                    string numberPart = lastControlNumber.Substring(8, 4);
                    if (int.TryParse(numberPart, out int lastNumber))
                    {
                        nextNumber = lastNumber + 1;
                        if (nextNumber > 9999)
                        {
                            nextNumber = 1;
                        }
                    }
                }

                return $"CN-{currentYear}-{nextNumber:D4}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating control number: " + ex.Message);
                return $"CN-{DateTime.Now.Year}-0001"; // Fallback
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

            if (combo_venues.SelectedValue != null &&
                int.TryParse(combo_venues.SelectedValue.ToString(), out selectedVenueID))
            {
                // Load reservation types and scope for the new venue
                LoadReservationTypesByVenue(selectedVenueID);
                LoadVenueScope(selectedVenueID);
                LoadReservedDates(selectedVenueID);
                // Load caterer fee for the selected venue
                LoadCatererFee(selectedVenueID);


                // Reset panel state until scope is selected
                panel_Aircon.Enabled = false;
                radio_Yes.Checked = false;
                radio_No.Checked = false;

                // If a scope is already selected, reload rates
                if (combo_scope.SelectedValue != null)
                {
                    LoadRate();
                }
            }
        }


        // Check if both reservation type and venue scope are selected
        private bool IsReservationTypeAndScopeSelected()
        {
            return combo_ReservationType.SelectedValue != null
                && combo_ReservationType.SelectedValue.ToString() != "-- Select Rate Type --"
                && combo_scope.SelectedValue != null;
        }

        // Calculate total amount
        private void CalculateTotalAmount()
        {
            if (decimal.TryParse(txt_rate.Text.Replace(",", ""), out decimal first4HrsRate) &&
                decimal.TryParse(txt_Succeeding_Hour.Text.Replace(",", ""), out decimal hourlyRate))
            {
                decimal totalAmount = first4HrsRate;

                if (_unroundedTotalHours > 4)
                {
                    double succeedingHours = Math.Ceiling(_unroundedTotalHours - 4);
                    totalAmount += hourlyRate * (decimal)succeedingHours;
                }

                totalAmount += additionalCharge;

                decimal catererFee = 0m;
                decimal.TryParse(txt_Caterer_Fee.Text.Replace(",", ""), out catererFee);
                totalAmount += catererFee;

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
                if (!IsReservationTypeAndScopeSelected())
                    return;

                // Handle PGNV case - set rates to zero but keep aircon enabled
                if (combo_ReservationType.SelectedValue.ToString().Equals("PGNV", StringComparison.OrdinalIgnoreCase))
                {
                    txt_rate.Text = "0.00";
                    txt_Succeeding_Hour.Text = "0.00";
                    additionalCharge = 0m;
                    panel_Aircon.Enabled = true;  // Keep aircon panel enabled for PGNV
                    CalculateTotalAmount();
                    return;  // Exit early for PGNV
                }

                // Rest of your existing LoadRate logic for non-PGNV cases
                string rateQuery = @"
                    SELECT pk_Venue_PricingID, fld_First4Hrs_Rate, fld_Hourly_Rate, fld_Aircon, fld_Additional_Charge
                    FROM tbl_Venue_Pricing 
                    WHERE fk_VenueID = @VenueID 
                    AND fk_Venue_ScopeID = @VenueScopeID 
                    AND fld_Rate_Type = @RateType";

                DBConnect();
                using (SqlCommand rateCmd = new SqlCommand(rateQuery, conn))
                {
                    rateCmd.Parameters.AddWithValue("@VenueID", selectedVenueID);
                    rateCmd.Parameters.AddWithValue("@VenueScopeID", combo_scope.SelectedValue);
                    rateCmd.Parameters.AddWithValue("@RateType", combo_ReservationType.SelectedValue.ToString());

                    using (SqlDataReader reader = rateCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Update rates
                            txt_rate.Text = reader["fld_First4Hrs_Rate"].ToString();
                            txt_Succeeding_Hour.Text = reader["fld_Hourly_Rate"].ToString();
                            additionalCharge = reader["fld_Additional_Charge"] != DBNull.Value ?
                                Convert.ToDecimal(reader["fld_Additional_Charge"]) : 0m;

                            // Update panel based on fld_Aircon
                            if (reader["fld_Aircon"] == DBNull.Value)
                            {
                                panel_Aircon.Enabled = false;
                                radio_Yes.Checked = false;
                                radio_No.Checked = false;
                            }
                            else
                            {
                                panel_Aircon.Enabled = true;
                                bool airconValue = (bool)reader["fld_Aircon"];
                                radio_Yes.Checked = airconValue;
                                radio_No.Checked = !airconValue;
                            }
                        }
                        else
                        {
                            // No matching record found
                            panel_Aircon.Enabled = false;
                            radio_Yes.Checked = false;
                            radio_No.Checked = false;
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

        public event EventHandler ReservationSubmitted;

        // Call this method after successful DB submission
        private void OnReservationSubmitted()
        {
            ReservationSubmitted?.Invoke(this, EventArgs.Empty);
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

            // Confirm submission
            var result = MessageBox.Show(
                "Are you sure you want to submit?",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return; // Cancel submission if user selects No
            }
            if (combo_Name.Text == comboNamePlaceholder)
            {
                MessageBox.Show("Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            if (combo_ReservationType.SelectedValue == null || combo_ReservationType.SelectedValue.ToString() == "-- Select Rate Type --")
            {
                MessageBox.Show("Please select a valid rate type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validate contact number
            string contactNumber = txt_contact.Text;
            if (string.IsNullOrWhiteSpace(contactNumber) || !IsValidContactNumber(contactNumber))
            {
                MessageBox.Show("Contact number is invalid. Please enter a valid contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculate total amount
            CalculateTotalAmount();
            if (!decimal.TryParse(txt_Total.Text.Replace(",", ""), out decimal totalAmount))
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
                // Parse name in the format: "Surname, Firstname MiddleName"
                string input = combo_Name.Text.Trim();
                string surname = "", firstName = "", middleName = "";

                // Split by comma first
                var parts = input.Split(new[] { ',' }, 2);
                if (parts.Length == 2)
                {
                    surname = parts[0].Trim();
                    var firstAndMiddle = parts[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (firstAndMiddle.Length > 0)
                        firstName = firstAndMiddle[0];
                    if (firstAndMiddle.Length > 1)
                        middleName = string.Join(" ", firstAndMiddle.Skip(1));
                }
                else
                {
                    // fallback: treat the whole as first name
                    firstName = input;
                }

                cmd = new SqlCommand(@"
                INSERT INTO tbl_Requesting_Person 
                (fld_First_Name, fld_Middle_Name, fld_Surname, fld_Requesting_Person_Address, fld_Contact_Number, fld_Request_Origin, fld_Requesting_Office, fld_Is_Special) 
                OUTPUT INSERTED.pk_Requesting_PersonID 
                VALUES (@FirstName, @MiddleName, @Surname, @Address, @ContactNumber, @RequestOrigin, @Requesting_Office, @fld_Is_Special)", conn, transaction);

                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@MiddleName", middleName);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@Address", txt_address.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@RequestOrigin", combo_Request.Text);
                cmd.Parameters.AddWithValue("@Requesting_Office", txt_Requesting_Office.Text);
                cmd.Parameters.AddWithValue("@fld_Is_Special", combo_Special.Text);

                int personID = (int)cmd.ExecuteScalar();
                // Step 2: Get or create venue pricing ID
                int venueID = selectedVenueID;
                int venueScopeID = (int)combo_scope.SelectedValue;
                string reservationType = combo_ReservationType.SelectedValue.ToString();
                int venuePricingID;

                if (reservationType.Equals("PGNV", StringComparison.OrdinalIgnoreCase))
                {
                    string pgnvQuery = @"
                SELECT pk_Venue_PricingID 
                FROM tbl_Venue_Pricing 
                WHERE fk_VenueID = @VenueID 
                AND fk_Venue_ScopeID = @VenueScopeID 
                AND fld_Rate_Type = 'PGNV'";

                    cmd = new SqlCommand(pgnvQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@VenueID", venueID);
                    cmd.Parameters.AddWithValue("@VenueScopeID", venueScopeID);

                    object pgnvResult = cmd.ExecuteScalar();

                    if (pgnvResult != null)
                    {
                        venuePricingID = (int)pgnvResult;
                    }
                    else
                    {
                        string insertPgnv = @"
                    INSERT INTO tbl_Venue_Pricing 
                    (fk_VenueID, fk_Venue_ScopeID, fld_Rate_Type, fld_First4Hrs_Rate, fld_Hourly_Rate, fld_Aircon)
                    VALUES (@VenueID, @VenueScopeID, 'PGNV', 0, 0, @UsesAircon);
                    SELECT SCOPE_IDENTITY();";

                        cmd = new SqlCommand(insertPgnv, conn, transaction);
                        cmd.Parameters.AddWithValue("@VenueID", venueID);
                        cmd.Parameters.AddWithValue("@VenueScopeID", venueScopeID);
                        cmd.Parameters.AddWithValue("@UsesAircon", radio_Yes.Checked);

                        venuePricingID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    txt_rate.Text = "0.00";
                    txt_Succeeding_Hour.Text = "0.00";
                    additionalCharge = 0m;
                }
                else
                {
                    string pricingQuery = @"
                SELECT pk_Venue_PricingID 
                FROM tbl_Venue_Pricing 
                WHERE fk_VenueID = @VenueID 
                AND fk_Venue_ScopeID = @VenueScopeID 
                AND fld_Rate_Type = @RateType 
                AND (fld_Aircon = @UsesAircon OR (fld_Aircon IS NULL AND @UsesAircon IS NULL))";

                    cmd = new SqlCommand(pricingQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@VenueID", venueID);
                    cmd.Parameters.AddWithValue("@VenueScopeID", venueScopeID);
                    cmd.Parameters.AddWithValue("@RateType", reservationType);

                    if (panel_Aircon.Enabled)
                    {
                        cmd.Parameters.AddWithValue("@UsesAircon", radio_Yes.Checked);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@UsesAircon", DBNull.Value);
                    }

                    object pricingResult = cmd.ExecuteScalar();
                    if (pricingResult == null)
                    {
                        throw new Exception("Could not find matching pricing record for the selected venue, scope, and aircon combination.");
                    }
                    venuePricingID = (int)pricingResult;
                }

                // Step 3: Use personID as clientID (no more tbl_Client_Info)
                int clientID = personID;

                // Step 4: Insert into tbl_Reservation (now includes fk_ClientID)
                cmd = new SqlCommand(@"
            INSERT INTO tbl_Reservation 
            (fld_Control_Number, fld_Start_Date, fld_End_Date, fld_Start_Time, fld_End_Time, fld_Activity_Name, 
             fld_Number_Of_Participants, fld_Reservation_Status, fld_Reservation_Type, fld_First4Hrs_Rate, fld_Hourly_Rate, fld_Total_Amount, 
             fk_Requesting_PersonID, fk_ClientID, fk_VenueID, fk_Venue_PricingID, fk_Venue_ScopeID, fld_Created_At, fld_Scanned_Document, fld_Hours, fld_Caterer_Fee) 
            OUTPUT INSERTED.pk_ReservationID 
            VALUES (@ControlNumber, @StartDate, @EndDate, @StartTime, @EndTime, @ActivityName, 
                    @NumberOfParticipants, @ReservationStatus, @ReservationType, @FirstFourHrs, @SucceedingHrs, @TotalAmount,
                    @RequestingPersonID, @ClientID, @VenueID, @VenuePricingID, @VenueScopeID, @CreatedAt, @ScannedDoc, @fldHours, @CatererFee)", conn, transaction);

                cmd.Parameters.AddWithValue("@ControlNumber", txt_controlnum.Text);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@EndTime", endTime);
                cmd.Parameters.AddWithValue("@ActivityName", txt_activity.Text);
                cmd.Parameters.AddWithValue("@NumberOfParticipants", num_participants.Value);
                cmd.Parameters.AddWithValue("@SucceedingHrs", decimal.Parse(txt_Succeeding_Hour.Text.Replace(",", "")));
                cmd.Parameters.AddWithValue("@FirstFourHrs", decimal.Parse(txt_rate.Text.Replace(",", "")));
                cmd.Parameters.AddWithValue("@ReservationStatus", "Pending");
                cmd.Parameters.AddWithValue("@ReservationType", "Venue");
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@RequestingPersonID", personID);
                cmd.Parameters.AddWithValue("@ClientID", clientID); // This is now the same as personID
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                cmd.Parameters.AddWithValue("@VenuePricingID", venuePricingID);
                cmd.Parameters.AddWithValue("@VenueScopeID", venueScopeID);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.Add("@ScannedDoc", SqlDbType.VarBinary).Value = scannedImageBytes ?? (object)DBNull.Value;
                cmd.Parameters.AddWithValue("@fldHours", int.TryParse(txtx_Num_Hours.Text.Replace(",", ""), out int hours) ? hours : 0);
                cmd.Parameters.AddWithValue("@CatererFee", decimal.Parse(txt_Caterer_Fee.Text.Replace(",", "")));

                int reservationID = (int)cmd.ExecuteScalar();


                //auditlog start
                string affectedTable = "tbl_Reservation";
                string affectedRecordPk = reservationID.ToString();
                string actionType = "Created a Venue Reservation";

                string changedBy = frm_login.LoggedInUserRole;
                string Uname = frm_login.LoggedInUserRole;
                DateTime changedAt = DateTime.Now;
                int userId = frm_login.LoggedInUserId;
                // Optionally, serialize new data as JSON (for simplicity, just key fields here)
                string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    ControlNumber = txt_controlnum.Text,
                    Activity = txt_activity.Text,
                    VenueID = selectedVenueID,
                    StartDate = startDate,
                    EndDate = endDate,
                    StartTime = startTime,
                    EndTime = endTime,
                    TotalAmount = totalAmount
                });

                // Insert audit log
                using (SqlCommand auditCmd = new SqlCommand(@"
                    INSERT INTO tbl_Audit_Log
                    (fk_UserID, fld_Affected_Table, fld_Affected_Record_PK, fld_ActionType, fld_Previous_Data_Json, fld_New_Data_Json, fld_Changed_By, fld_Changed_At)
                    VALUES (@UserID, @Table, @RecordPK, @ActionType, @PrevJson, @NewJson, @ChangedBy, @ChangedAt)", conn, transaction))
                {
                    auditCmd.Parameters.AddWithValue("@UserID", userId);
                    auditCmd.Parameters.AddWithValue("@Table", affectedTable);
                    auditCmd.Parameters.AddWithValue("@RecordPK", affectedRecordPk);
                    auditCmd.Parameters.AddWithValue("@ActionType", actionType);
                    auditCmd.Parameters.AddWithValue("@PrevJson", DBNull.Value); // No previous data for create
                    auditCmd.Parameters.AddWithValue("@NewJson", newDataJson);
                    auditCmd.Parameters.AddWithValue("@ChangedBy", changedBy);

                    auditCmd.Parameters.AddWithValue("@ChangedAt", changedAt);

                    auditCmd.ExecuteNonQuery();
                }

                //end auditlog

                // Commit transaction
                transaction.Commit();

                MessageBox.Show("Reservation submitted successfully!");
              
                var billingForm = new frm_Billing();
                billingForm.ShowDialog();
                OnReservationSubmitted();
                frm_Dashboard.NeedsCalendarRefresh = true;
                this.Close();
                // ...
                RefreshCalendarView();
                // Remove RefreshCalendarView(); -- let Dashboard handle the refresh
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

            string selectedRateType = "";
            if (combo_ReservationType.SelectedValue != null)
                selectedRateType = combo_ReservationType.SelectedValue.ToString();

            if (selectedRateType.Equals("Special", StringComparison.OrdinalIgnoreCase))
            {
                combo_Special.Enabled = true;
                button1.Enabled = true; // Enable scan button
            }
            else
            {
                combo_Special.Enabled = false;
                combo_Special.SelectedIndex = -1;
                button1.Enabled = false; // Disable scan button
            }

            // If PGNV is selected, set rates and caterer fee to zero
            if (selectedRateType.Equals("PGNV", StringComparison.OrdinalIgnoreCase))
            {
                txt_rate.Text = "0.00";
                txt_Succeeding_Hour.Text = "0.00";
                additionalCharge = 0m;
                panel_Aircon.Enabled = true;  // Keep aircon enabled

                // Set caterer fee to zero and uncheck the box
                txt_Caterer_Fee.Text = "0.00";
                chk_UseCatererFee.Checked = false;

                CalculateTotalAmount();
                return;
            }

            if (IsReservationTypeAndScopeSelected())
            {
                LoadRate();
            }
        }

        private void combo_scope_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_scope.DropDownStyle = ComboBoxStyle.DropDownList;

            // Only update the price if both scope and rate type are selected
            if (IsReservationTypeAndScopeSelected())
            {
                LoadRate();
            }
            else
            {
                txt_rate.Text = "0.00";
                txt_Succeeding_Hour.Text = "0.00";
                txt_Total.Text = "0.00";
            }
        
        }
        private void TimeStart_ValueChanged(object sender, EventArgs e)
        {
            // Force AM time
           /* if (TimeStart.Value.Hour >= 12)
            {
                TimeStart.Value = TimeStart.Value.Date.AddHours(TimeStart.Value.Hour - 12);
            }*/
            if (IsReservationTypeAndScopeSelected())
            {
                LoadRate();
            }
        }
        private void TimeEnd_ValueChanged(object sender, EventArgs e)
        {
            // Force PM time
           /* if (TimeEnd.Value.Hour < 12)
            {
                TimeEnd.Value = TimeEnd.Value.Date.AddHours(TimeEnd.Value.Hour + 12);
            }*/
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
                //  txt_surname.Clear();

                //  txt_Middle_Name.Clear(); // Clear Middle Name
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
                SetComboNamePlaceholder();
                // Reset ComboBoxes to default selection
                if (combo_venues.Items.Count > 0)
                    combo_venues.SelectedIndex = 0;
                if (combo_scope.Items.Count > 0)
                    combo_scope.SelectedIndex = 0;
                if (combo_ReservationType.Items.Count > 0)
                    combo_ReservationType.SelectedIndex = 0;
                if (combo_Request.Items.Count > 0)
                    combo_Request.SelectedIndex = -1; // Reset Request Origin
                if (combo_Name.Items.Count > 0)
                    combo_Name.SelectedIndex = -1;
                // Reset RadioButtons
                radio_Yes.Checked = false;
                radio_No.Checked = false;

                this.Size = new Size(680, 643); // Reset form size after clearing
                pictureBox1.Image = null;
                scannedImageBytes = null;

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

            // Always set end date to match start date
            date_of_use_end.Value = date_of_use_start.Value;

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

        //scan
        private void ScanDocument()
        {
            try
            {
                // Show "Please wait" dialog
                Form waitForm = new Form()
                {
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.CenterScreen,
                    Width = 300,
                    Height = 100,
                    TopMost = true,
                    ControlBox = false
                };
                var label = new Label()
                {
                    Text = "Initializing scanner...",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                waitForm.Controls.Add(label);
                waitForm.Show();
                Application.DoEvents();

                // Find scanners
                var deviceManager = new DeviceManager();
                List<DeviceInfo> scanners = new List<DeviceInfo>();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type == WiaDeviceType.ScannerDeviceType)
                    {
                        scanners.Add(deviceManager.DeviceInfos[i]);
                    }
                }

                if (scanners.Count == 0)
                {
                    waitForm.Close();
                    waitForm.Dispose();
                    MessageBox.Show("No scanners found. Please connect a scanner and try again.");
                    return;
                }

                // Select scanner
                DeviceInfo selectedScanner = null;
                if (scanners.Count == 1)
                {
                    selectedScanner = scanners[0];
                    label.Text = $"Using scanner: {selectedScanner.Properties["Name"].get_Value()}";
                }
                else
                {
                    waitForm.Close();
                    waitForm.Dispose();
                    using (var scannerSelectForm = new Form()
                    {
                        Text = "Select Scanner",
                        Width = 350,
                        Height = 220,
                        StartPosition = FormStartPosition.CenterScreen
                    })
                    {
                        ListBox scannerList = new ListBox() { Dock = DockStyle.Fill };
                        foreach (var scanner in scanners)
                        {
                            scannerList.Items.Add(scanner.Properties["Name"].get_Value());
                        }

                        Button selectButton = new Button()
                        {
                            Text = "Select",
                            Dock = DockStyle.Bottom
                        };

                        selectButton.Click += (s, e) =>
                        {
                            if (scannerList.SelectedIndex >= 0)
                            {
                                selectedScanner = scanners[scannerList.SelectedIndex];
                                scannerSelectForm.DialogResult = DialogResult.OK;
                            }
                        };

                        scannerSelectForm.Controls.Add(scannerList);
                        scannerSelectForm.Controls.Add(selectButton);

                        if (scannerSelectForm.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                    }
                    // Recreate waitForm after scanner selection
                    waitForm = new Form()
                    {
                        FormBorderStyle = FormBorderStyle.None,
                        StartPosition = FormStartPosition.CenterScreen,
                        Width = 300,
                        Height = 100,
                        TopMost = true,
                        ControlBox = false
                    };
                    label = new Label()
                    {
                        Text = $"Scanning with {selectedScanner.Properties["Name"].get_Value()}...",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    waitForm.Controls.Add(label);
                    waitForm.Show();
                    Application.DoEvents();
                }

                // Perform scan
                try
                {
                    var device = selectedScanner.Connect();
                    var item = device.Items[1];

                    // Set scan settings: Color, 150 DPI, remove scan quality property
                    try
                    {
                        const string wiaColorMode = "6146";
                        const string wiaResolution = "6147";
                        // Removed wiaScanQuality

                        SetWIAProperty(item.Properties, wiaColorMode, 1); // Color
                        SetWIAProperty(item.Properties, wiaResolution, 150); // 150 DPI
                    }
                    catch { /* Ignore if not supported */ }

                    label.Text = "Scanning document...";
                    Application.DoEvents();

                    // Use JPEG format for smaller files
                    var imageFile = (ImageFile)item.Transfer("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}"); // JPEG GUID.

                    // Save to byte array
                    var imageBytes = (byte[])imageFile.FileData.get_BinaryData();
                    scannedImageBytes = imageBytes;

                    // Display preview and resize form after scan
                    if (pictureBox1.InvokeRequired)
                    {
                        pictureBox1.Invoke(new Action(() =>
                        {
                            pictureBox1.Image?.Dispose();
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            this.Size = new Size(932, 613); // Set form size after scan
                        }));
                    }
                    else
                    {
                        pictureBox1.Image?.Dispose();
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.Size = new Size(932, 613); // Set form size after scan
                    }
                }
                finally
                {
                    // Ensure scanner is properly released
                    Marshal.ReleaseComObject(selectedScanner);
                    waitForm.Close();
                    waitForm.Dispose();
                }
            }
            catch (COMException ex)
            {
                string errorMessage = ex.ErrorCode switch
                {
                    -2145320939 => "Scanner is busy or not responding",
                    -2145320960 => "Paper jam or scanner error",
                    _ => $"Scanner error: {ex.Message} (Error code: {ex.ErrorCode})"
                };
                MessageBox.Show(errorMessage, "Scanning Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Scanned?.Invoke(this, EventArgs.Empty);
        }

        private void SetScannerSettings(IItem item)
        {
            try
            {
                const string wiaColorMode = "6146";
                const string wiaResolution = "6147";

                // Set color mode to color (1)
                SetWIAProperty(item.Properties, wiaColorMode, 1);

                // Set resolution to 300 DPI
                SetWIAProperty(item.Properties, wiaResolution, 300);
            }
            catch { /* Ignore if scanner doesn't support these settings */ }
        }


        private void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        private void panel_Aircon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Total_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Succeeding_Hour_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void combo_Special_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Special.SelectedItem == null)
                return;

            string selected = combo_Special.SelectedItem.ToString();

            switch (selected)
            {
                case "PWD":
                    // Optionally, show a message or enable a textbox for ID number, etc.
                    // Example: MessageBox.Show("PWD selected.");
                    break;
                case "SENIOR CITIZEN":
                    // Optionally, show a message or enable a textbox for ID number, etc.
                    // Example: MessageBox.Show("Senior Citizen selected.");
                    break;
                case "OTHERS":
                    // Optionally, show a textbox or dialog for user to specify details
                    // Example: MessageBox.Show("Please specify the details for 'OTHERS'.");
                    break;
                default:
                    // No action needed
                    break;
            }
        }
        public event EventHandler Scanned;

        private void button1_Click(object sender, EventArgs e)
        {
            ScanDocument();
        }


        //
        // Call this in your constructor or form load
        // Example: InitializeClientInfoAutocomplete();

        private void combo_Name_TextUpdate(object sender, EventArgs e)
        { // Prevent out-of-range access
          //if (combo_Name.SelectedIndex < 0 || combo_Name.SelectedIndex >= combo_Name.Items.Count) return;

            combo_Name.DroppedDown = true;
        }

        private void combo_Name_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {// Prevent out-of-range access
            if (combo_Name.SelectedIndex < 0 || combo_Name.SelectedIndex >= combo_Name.Items.Count)
                return;
            string input = combo_Name.Text.Trim();

            // Remove office part if present
            int idx = input.LastIndexOf(" (");
            if (idx > 0 && input.EndsWith(")"))
            {
                input = input.Substring(0, idx).Trim();
                combo_Name.Text = input;
            }

            // Optionally, reformat to match the correct format from the table
            foreach (DataRow row in requestingPersonTable.Rows)
            {
                string formatted = $"{row["fld_Surname"]}, {row["fld_First_Name"]} {row["fld_Middle_Name"]}".Trim();
                if (string.Equals(input, formatted, StringComparison.OrdinalIgnoreCase))
                {
                    combo_Name.Text = formatted;
                    return;
                }
            }
        }
        private void combo_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prevent out-of-range access
            if (combo_Name.SelectedIndex < 0 || combo_Name.SelectedIndex >= combo_Name.Items.Count)
                return;
            if (requestingPersonTable == null || requestingPersonTable.Rows.Count == 0)
                return;

            string selected = combo_Name.SelectedItem.ToString();

            // Extract name and office if present
            string namePart = selected;
            string officePart = null;
            int idx = selected.LastIndexOf(" (");
            if (idx > 0 && selected.EndsWith(")"))
            {
                namePart = selected.Substring(0, idx);
                officePart = selected.Substring(idx + 2, selected.Length - idx - 3); // remove " (" and ")"
            }

            // Set only the name (no office) in the ComboBox text
            combo_Name.Text = namePart.Trim();
            combo_Name.DroppedDown = false; // Optionally close dropdown

            // Parse name
            var parts = namePart.Split(new[] { ',' }, 2);
            if (parts.Length < 2) return;
            string surname = parts[0].Trim();
            string rest = parts[1].Trim();
            string[] nameParts = rest.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstName = nameParts.Length > 0 ? nameParts[0] : "";
            string middleName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : "";

            // Find the correct row (with office if available)
            DataRow match = requestingPersonTable.AsEnumerable()
                .FirstOrDefault(row =>
                    row["fld_Surname"].ToString().Trim().Equals(surname, StringComparison.OrdinalIgnoreCase) &&
                    row["fld_First_Name"].ToString().Trim().Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    row["fld_Middle_Name"].ToString().Trim().Equals(middleName, StringComparison.OrdinalIgnoreCase) &&
                    (officePart == null || row["fld_Requesting_Office"].ToString().Trim().Equals(officePart, StringComparison.OrdinalIgnoreCase))
                );

            if (match == null) return;

            txt_address.Text = match["fld_Requesting_Person_Address"].ToString();
            txt_contact.Text = match["fld_Contact_Number"].ToString();
            txt_Requesting_Office.Text = match["fld_Requesting_Office"].ToString();
        }

        private void combo_Name_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (combo_Name.SelectedIndex < 0 || requestingPersonTable == null || requestingPersonTable.Rows.Count == 0)
                return;

            string selected = combo_Name.SelectedItem.ToString();

            // Extract name and office if present
            string namePart = selected;
            string officePart = null;
            int idx = selected.LastIndexOf(" (");
            if (idx > 0 && selected.EndsWith(")"))
            {
                namePart = selected.Substring(0, idx);
                officePart = selected.Substring(idx + 2, selected.Length - idx - 3); // remove " (" and ")"
            }

            // Use BeginInvoke to set the text after ComboBox finishes its update
            combo_Name.BeginInvoke(new Action(() =>
            {
                combo_Name.Text = namePart.Trim();
                combo_Name.SelectionStart = combo_Name.Text.Length;
                combo_Name.SelectionLength = 0;
            }));

            // Parse name
            var parts = namePart.Split(new[] { ',' }, 2);
            if (parts.Length < 2) return;
            string surname = parts[0].Trim();
            string rest = parts[1].Trim();
            string[] nameParts = rest.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstName = nameParts.Length > 0 ? nameParts[0] : "";
            string middleName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : "";

            // Find the correct row (with office if available)
            DataRow match = requestingPersonTable.AsEnumerable()
                .FirstOrDefault(row =>
                    row["fld_Surname"].ToString().Trim().Equals(surname, StringComparison.OrdinalIgnoreCase) &&
                    row["fld_First_Name"].ToString().Trim().Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    row["fld_Middle_Name"].ToString().Trim().Equals(middleName, StringComparison.OrdinalIgnoreCase) &&
                    (officePart == null || row["fld_Requesting_Office"].ToString().Trim().Equals(officePart, StringComparison.OrdinalIgnoreCase))
                );

            if (match == null) return;

            txt_address.Text = match["fld_Requesting_Person_Address"].ToString();
            txt_contact.Text = match["fld_Contact_Number"].ToString();
            txt_Requesting_Office.Text = match["fld_Requesting_Office"].ToString();
        }
        private void LoadCatererFee(int venueID)
        {
            try
            {
                DBConnect();
                using (SqlCommand cmd = new SqlCommand("SELECT fld_Caterer_Fee FROM tbl_Venue_Pricing WHERE fk_VenueID = @VenueID", conn))
                {
                    cmd.Parameters.AddWithValue("@VenueID", venueID);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        currentCatererFee = Convert.ToDecimal(result);
                        txt_Caterer_Fee.Text = currentCatererFee.ToString("N2");
                        // Auto-check the checkbox if there is a caterer fee
                        chk_UseCatererFee.Checked = currentCatererFee > 0;
                    }
                    else
                    {
                        currentCatererFee = 0m;
                        txt_Caterer_Fee.Text = "0.00";
                        chk_UseCatererFee.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading caterer fee: " + ex.Message);
                currentCatererFee = 0m;
                txt_Caterer_Fee.Text = "0.00";
                chk_UseCatererFee.Checked = false;
            }
            finally
            {
                DBClose();
            }
        }

        private void chk_UseCatererFee_CheckedChanged(object sender, EventArgs e)
        {
            // If PGNV is selected, always set to zero and uncheck
            if (combo_ReservationType.SelectedValue != null &&
                combo_ReservationType.SelectedValue.ToString().Equals("PGNV", StringComparison.OrdinalIgnoreCase))
            {
                txt_Caterer_Fee.Text = "0.00";
                chk_UseCatererFee.Checked = false;
            }
            else
            {
                if (chk_UseCatererFee.Checked)
                {
                    txt_Caterer_Fee.Text = currentCatererFee.ToString("N2");
                }
                else
                {
                    txt_Caterer_Fee.Text = "0.00";
                }
            }
            CalculateTotalAmount(); // If caterer fee is part of total
        }
        // Helper to set placeholder
        private void SetComboNamePlaceholder()
        {
            if (string.IsNullOrWhiteSpace(combo_Name.Text))
            {
                combo_Name.Text = comboNamePlaceholder;
                combo_Name.ForeColor = comboNamePlaceholderColor;
            }
        }

        // Remove placeholder when focused
        private void Combo_Name_GotFocus(object sender, EventArgs e)
        {
            if (combo_Name.Text == comboNamePlaceholder)
            {
                combo_Name.Text = "";
                combo_Name.ForeColor = comboNameNormalColor;
            }
        }

        // Restore placeholder if empty on losing focus
        private void Combo_Name_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(combo_Name.Text))
            {
                SetComboNamePlaceholder();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }


}