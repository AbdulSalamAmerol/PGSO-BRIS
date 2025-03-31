using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using pgso_connect; // Ensure this namespace is correct

namespace pgso
{
    public partial class frm_Create_Utility_Reservation : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private Connection db = new Connection(); // Use the Connection class
        private SqlDataAdapter da;
        private DataTable dt = new DataTable();
        private List<DateTime> reservedDates; // List to store reserved dates
        private int selectedEquipmetID;

        public frm_Create_Utility_Reservation()
        {
            InitializeComponent();
            // Set the DateTimePicker format to display only hour, minute, and AM/PM
            Time_Start.Format = DateTimePickerFormat.Custom;
            Time_Start.CustomFormat = "hh:mm tt";
            Time_End.Format = DateTimePickerFormat.Custom;
            Time_End.CustomFormat = "hh:mm tt";
            // Add items to comboBox1
            combo_Type.Items.Add("Equipment");
            combo_Type.Items.Add("Venue");
            combo_Type.SelectedIndexChanged += comboBox1_SelectedIndexChanged; // Add event handler
            combo_Origin.Items.Add("Call");
            combo_Origin.Items.Add("Letter");
            combo_Origin.Items.Add("Walk-In");
            combo_Origin.SelectedIndexChanged += combo_Origin_SelectedIndexChanged; // Add event handler

            LoadUtilities();
            combo_Utility.SelectedIndexChanged += Combo_Utility_SelectedIndexChanged; // Add event handler
            txt_Quantity.TextChanged += txt_Quantity_TextChanged; // Ensure quantity change recalculates
         // Add event handlers for DateTimePickers
            Date_Start.ValueChanged += Date_ValueChanged;
            Date_End.ValueChanged += Date_ValueChanged;
        }

        private void DBConnect()
        {
            try
            {
                Connection dbConnection = new Connection(); // Create new instance of connection class
                conn = dbConnection.strCon; // Get connection
                if (conn == null)
                {
                    throw new Exception("Connection string is null.");
                }
                conn.Open(); // Open connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connection: " + ex.Message);
            }
        }

        private void DBClose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        // Event handler to calculate the number of days
        private void Date_ValueChanged(object sender, EventArgs e)
        {
            CalculateNumberOfDays();
        }
        // Method to calculate the number of days and update the textbox
        private void CalculateNumberOfDays()
        {
            TimeSpan difference = Date_End.Value.Date - Date_Start.Value.Date;
            int numberOfDays = (int)difference.TotalDays + 1; // Include the start date
            txt_Days_Of_Use.Text = numberOfDays.ToString();
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

                combo_Utility.DataSource = dt;
                combo_Utility.ValueMember = "pk_EquipmentID";
                combo_Utility.DisplayMember = "fld_Equipment_Name";

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
                    txt_Total.Tag = reader["fld_Equipment_Price"].ToString(); // Store price in Tag
                    txt_Total.Text = reader["fld_Equipment_Price"].ToString();
                }
                else
                {
                    txt_Total.Tag = "0.00";
                    txt_Total.Text = "0.00";
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
            if (txt_Total.Tag == null)
            {
                txt_Total.Text = "0.00";
                return;
            }

            if (decimal.TryParse(txt_Total.Tag.ToString(), out decimal rate))
            {
                if (int.TryParse(txt_Quantity.Text, out int quantity) && quantity > 0)
                {
                    decimal totalAmount = rate * quantity;
                    txt_Total.Text = totalAmount.ToString("0.00");
                }
                else
                {
                    txt_Total.Text = rate.ToString("0.00");
                }
            }
            else
            {
                txt_Total.Text = "0.00";
            }
        }

        // Event handlers
        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }

        private void Combo_Utility_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Utility.SelectedValue == null)
            {
                MessageBox.Show("No utility selected. Please select a utility.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(combo_Utility.SelectedValue.ToString(), out int selectedUtilityId))
            {
                selectedEquipmetID = selectedUtilityId; // Set the selectedEquipmetID
                LoadUtilityDetails(selectedUtilityId);
            }
            else
            {
                MessageBox.Show("Invalid utility selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_createutilityreservation_Load(object sender, EventArgs e)
        {
            // Handle form load event if needed
        }

        private bool IsValidContactNumber(string contactNumber)
        {
            // validation
            // Ensure the contact number is 10-15 digits long and may contain spaces, dashes, and parentheses
            string cleanedContactNumber = new string(contactNumber.Where(char.IsDigit).ToArray());
            return cleanedContactNumber.Length >= 10 && cleanedContactNumber.Length <= 15;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Handle panel paint event if needed
        }

        private void dt_Utilities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle DataGridView cell content click event if needed
        }

        private void combo_Utility_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Handle ComboBox selected index changed event if needed
        }

        private void btn_submit_Click_1(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;

            try
            {
                DBConnect(); // Connect to Database
                transaction = conn.BeginTransaction(); // Start a transaction

                // Validate the start and end times
                if (Time_Start.Value.TimeOfDay >= Time_End.Value.TimeOfDay)
                {
                    MessageBox.Show("Start time must be before end time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure selectedEquipmetID is set
                if (selectedEquipmetID == 0)
                {
                    MessageBox.Show("No equipment selected. Please select an equipment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 1: Insert into RequestingPerson
                cmd = new SqlCommand("INSERT INTO tbl_Requesting_Person (fld_Surname, fld_First_Name, fld_Requesting_Person_Address, fld_Contact_Number, fld_Request_Origin) OUTPUT INSERTED.pk_Requesting_PersonID VALUES (@Surname, @FirstName, @Address, @ContactNumber, @RequestOrigin)", conn, transaction);

                cmd.Parameters.AddWithValue("@Surname", txt_Surname.Text);
                cmd.Parameters.AddWithValue("@FirstName", txt_First_Name.Text);
                cmd.Parameters.AddWithValue("@Address", txt_Address.Text);

                // Validate the contact number
                string contactNumber = txt_Contact.Text;
                if (string.IsNullOrEmpty(contactNumber) || !IsValidContactNumber(contactNumber))
                {
                    MessageBox.Show("Contact number is invalid. Please enter a valid contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@RequestOrigin", combo_Origin.Text);

                int personID = (int)cmd.ExecuteScalar();

                // Step 2: Retrieve fk_FacilityID, fk_Facility_PricingID, fk_Facility_ScopeID
                int facilityID = selectedEquipmetID;
                int facilityScopeID = (int)combo_Utility.SelectedValue;

                cmd = new SqlCommand(@"
        SELECT pk_Equipment_PricingID 
        FROM tbl_Equipment_Pricing 
        WHERE fk_EquipmentID = @FacilityID ", conn, transaction);

                cmd.Parameters.AddWithValue("@FacilityID", facilityID);

                int venuePricingID = (int)cmd.ExecuteScalar();

                // Step 3: Insert into Reservations
                cmd = new SqlCommand(@"
        INSERT INTO tbl_Reservation 
        (fld_Control_Number, fld_Reservation_Type, fld_Start_Date, fld_End_Date, fld_Start_Time, fld_End_time, fld_Activity_Name, fld_Number_Of_Participants, fld_Reservation_Status, fld_Total_Amount, fk_Requesting_PersonID) OUTPUT INSERTED.pk_ReservationID 
        VALUES (@fld_Control_Number, @fld_Reservation_Type, @fld_Start_Date, @fld_End_Date, @fld_Start_Time, @fld_End_time, @fld_Activity_Name, @fld_Number_Of_Participants, @fld_Reservation_Status, @fld_Total_Amount, @Requesting_PersonID)", conn, transaction);

                cmd.Parameters.AddWithValue("@fld_Control_Number", txt_Control_Num.Text);
                cmd.Parameters.AddWithValue("@fld_Reservation_Type", combo_Type.Text);
                cmd.Parameters.AddWithValue("@fld_Start_Date", Date_Start.Value);
                cmd.Parameters.AddWithValue("@fld_End_Date", Date_End.Value);
                cmd.Parameters.AddWithValue("@fld_Start_Time", Time_Start.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@fld_End_time", Time_End.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@fld_Activity_Name", txt_Activity.Text);
                cmd.Parameters.AddWithValue("@fld_Number_Of_Participants", "00");
                cmd.Parameters.AddWithValue("@fld_Reservation_Status", "Pending");
                cmd.Parameters.AddWithValue("@fld_Total_Amount", txt_Total.Text);
                cmd.Parameters.AddWithValue("@Requesting_PersonID", personID);

                int reservationID = (int)cmd.ExecuteScalar();

                // Step 4: Insert into Reservation_Equipment
                cmd = new SqlCommand(@"
        INSERT INTO tbl_Reservation_Equipment 
        (fk_ReservationID, fk_EquipmentID, fk_Equipment_PricingID, fld_Quantity, fld_Number_Of_Days, fld_Total_Equipment_Cost, fld_Rate_Per_Day) OUTPUT INSERTED.pk_Reservation_EquipmentID 
        VALUES (@fk_ReservationID, @fk_EquipmentID, @fk_Equipment_PricingID, @fld_Quantity, @fld_Number_Of_Days, @fld_Total_Equipment_Cost, @fld_Rate_Per_Day)", conn, transaction);

                cmd.Parameters.AddWithValue("@fk_ReservationID", reservationID);
                cmd.Parameters.AddWithValue("@fk_EquipmentID", facilityID);
                cmd.Parameters.AddWithValue("@fk_Equipment_PricingID", venuePricingID);
                cmd.Parameters.AddWithValue("@fld_Quantity", txt_Quantity.Text);
                //sample to
                cmd.Parameters.AddWithValue("@fld_Rate_Per_Day", "00");
                cmd.Parameters.AddWithValue("@fld_Number_Of_Days", txt_Days_Of_Use.Text);
                cmd.Parameters.AddWithValue("@fld_Total_Equipment_Cost", txt_Total.Text);

                int reservationEquipmentID = (int)cmd.ExecuteScalar();

                // Commit the transaction
                if (transaction != null)
                {
                    transaction.Commit();
                }

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

        private void combo_Origin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Origin.SelectedItem == null)
            {
                return;
            }

            switch (combo_Origin.SelectedItem.ToString())
            {
                case "Call":
                    break;
                case "Letter":
                    break;
                case "Walk-In":
                    break;
                default:
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Type.SelectedItem.ToString() == "Equipment")
            {
                LoadUtilities("Equipment");
            }
            else if (combo_Type.SelectedItem.ToString() == "Venue")
            {
                LoadUtilities("Venue");
            }
        }
        private void LoadUtilities(string type)
        {
            try
            {
                DBConnect();
                string query = "";

                if (type == "Equipment")
                {
                    query = "SELECT pk_EquipmentID, fld_Equipment_Name FROM tbl_Equipment";
                }
                else if (type == "Venue")
                {
                    query = "SELECT pk_VenueID, fld_Venue_Name FROM tbl_Venue";
                }

                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                combo_Utility.DataSource = dt;

                if (type == "Equipment")
                {
                    combo_Utility.ValueMember = "pk_EquipmentID";
                    combo_Utility.DisplayMember = "fld_Equipment_Name";
                }
                else if (type == "Venue")
                {
                    combo_Utility.ValueMember = "pk_VenueID";
                    combo_Utility.DisplayMember = "fld_Venue_Name";
                }

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
        private void label7_Click(object sender, EventArgs e)
        {

        }


    }
}