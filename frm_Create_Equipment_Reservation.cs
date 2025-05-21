using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using pgso_connect;

namespace pgso
{
    public partial class frm_Create_Equipment_Reservation : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private Connection db = new Connection();
        private SqlDataAdapter da;
        private DataTable dt = new DataTable();
        private List<DateTime> reservedDates;
        private List<SelectedEquipment> selectedEquipmentList = new List<SelectedEquipment>();
        private string contactPlaceholder = "09685744...";
        private bool isContactPlaceholderActive = true;

        public class SelectedEquipment
        {
            public int EquipmentID { get; set; }
            public string EquipmentName { get; set; }
            public int Quantity { get; set; }
            public decimal Rate { get; set; }
            public decimal NumDays { get; set; }
            public decimal CalculatedTotal { get; set; }
        }
        public frm_Create_Equipment_Reservation()
        {
    

            InitializeComponent();
            InitializeFormComponents();
            InitializeDataGridView();
            LoadUtilities();
            txt_Control_Num.Text = GenerateControlNumber();
            combo_Origin.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_Utility.DropDownStyle = ComboBoxStyle.DropDownList;
            // Set placeholder for txt_Contact
            SetContactPlaceholder();
            txt_Contact.Enter += Txt_Contact_Enter;
            txt_Contact.Leave += Txt_Contact_Leave;

        }

        private void InitializeFormComponents()
        {
         

            // Set the minimum date to the current date for both Date_Start and Date_End
            Date_Start.MinDate = DateTime.Now.Date;
            Date_End.MinDate = DateTime.Now.Date;



            txt_Contact.TextChanged += txt_Contact_TextChanged;

            combo_Origin.Items.Add("Call");
            combo_Origin.Items.Add("Letter");
            combo_Origin.Items.Add("Walk In");
            combo_Origin.SelectedIndexChanged += combo_Origin_SelectedIndexChanged;

            combo_Utility.SelectedIndexChanged += Combo_Utility_SelectedIndexChanged;
            txt_Quantity.TextChanged += txt_Quantity_TextChanged;

            Date_Start.ValueChanged += Date_ValueChanged;
            Date_End.ValueChanged += Date_ValueChanged;

            Date_Start.Value = DateTime.Now;
            Date_End.Value = DateTime.Now;
           // btn_Remove.Enabled = false;
            CalculateNumberOfDays();
        }

        private void InitializeDataGridView()
        {
 
            dgv_Selected_Equipments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DBConnect()
        {
            try
            {
                Connection dbConnection = new Connection();
                conn = dbConnection.strCon;
                if (conn == null)
                {
                    throw new Exception("Connection string is null.");
                }
                conn.Open();
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

        private void SetContactPlaceholder()
        {
            txt_Contact.Text = contactPlaceholder;
            txt_Contact.ForeColor = System.Drawing.Color.Gray;
            isContactPlaceholderActive = true;
        }

        private void RemoveContactPlaceholder()
        {
            if (isContactPlaceholderActive)
            {
                txt_Contact.Text = "";
                txt_Contact.ForeColor = System.Drawing.Color.Black;
                isContactPlaceholderActive = false;
            }
        }

        private void Txt_Contact_Enter(object sender, EventArgs e)
        {
            RemoveContactPlaceholder();
        }

        private void Txt_Contact_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Contact.Text))
            {
                SetContactPlaceholder();
            }
        }


        private void Date_ValueChanged(object sender, EventArgs e)
        {
           

            // Recalculate the number of days
            CalculateNumberOfDays();
        }



        private void CalculateNumberOfDays()
        {
            TimeSpan difference = Date_End.Value.Date - Date_Start.Value.Date;
            int numberOfDays = (int)difference.TotalDays + 1;
            txt_Days_Of_Use.Text = numberOfDays.ToString();
        }

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

        private void LoadUtilities(string type)
        {/*
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
            }*/
        }

        private void LoadUtilityDetails(int utilityId)
        {
            try
            {
                DBConnect();
                string query = @"
            SELECT 
                ep.fld_Equipment_Price, ep.fld_Equipment_Price_Subsequent
            FROM 
                tbl_Equipment e
            LEFT JOIN 
                tbl_Equipment_Pricing ep ON e.pk_EquipmentID = ep.fk_EquipmentID
            WHERE 
                e.pk_EquipmentID = @UtilityId";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UtilityId", utilityId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txt_Total.Tag = reader["fld_Equipment_Price"].ToString();
                    txt_Total.Text = reader["fld_Equipment_Price"].ToString();

                    txt_Price_Subsequent.Tag = reader["fld_Equipment_Price_Subsequent"].ToString();
                    txt_Price_Subsequent.Text = reader["fld_Equipment_Price_Subsequent"].ToString();
                }
                else
                {
                    txt_Total.Tag = "0.00";
                    txt_Total.Text = "0.00";

                    txt_Price_Subsequent.Tag = "0.00";
                    txt_Price_Subsequent.Text = "0.00";
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

        private void CalculateTotalAmount()
        {
            // Check if the tags for total and subsequent price are null
            if (txt_Total.Tag == null || txt_Price_Subsequent.Tag == null)
            {
                txt_Total.Text = "0.00";
                return;
            }

            // Try to parse the rate and subsequent rate from the tags
            if (decimal.TryParse(txt_Total.Tag.ToString(), out decimal rate) &&
                decimal.TryParse(txt_Price_Subsequent.Tag.ToString(), out decimal subsequentRate))
            {
                // Try to parse the quantity and number of days from the text boxes
                if (int.TryParse(txt_Quantity.Text, out int quantity) && quantity > 0 &&
                    int.TryParse(txt_Days_Of_Use.Text, out int numberOfDays) && numberOfDays > 0)
                {


                    // Calculate the total amount by adding the rate and subsequent total, then multiplying by the quantity
                    decimal totalAmount = ((rate * quantity) + (subsequentRate * quantity * (numberOfDays - 1)));
                    txt_Total.Text = totalAmount.ToString("0.00");
                }
                else
                {
                    // If quantity or number of days is invalid, set the total to the rate
                    txt_Total.Text = rate.ToString("0.00");
                }
            }
            else
            {
                // If parsing fails, set the total to 0.00
                txt_Total.Text = "0.00";
            }
        }

        private void btn_AddEquipment_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateSelectedEquipmentDisplay()
        {
            dgv_Selected_Equipments.Rows.Clear();

            int itemNumber = 1;
            foreach (var item in selectedEquipmentList)
            {
                dgv_Selected_Equipments.Rows.Add(
                    itemNumber, // Item number
                    item.EquipmentName,
                    item.Quantity,
                    item.NumDays,
                    item.CalculatedTotal.ToString("N2")
                );
                itemNumber++;
            }
        }


        private void btn_RemoveEquipment_Click(object sender, EventArgs e)
        {
            if (dgv_Selected_Equipments.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_Selected_Equipments.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < selectedEquipmentList.Count)
                {
                    selectedEquipmentList.RemoveAt(selectedIndex);
                    UpdateSelectedEquipmentDisplay();
                }
            }
        }

        private void btn_submit_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to submit?",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return; // Cancel submission if user selects No
            }
            // First check all equipment for zero stock
            foreach (var equipment in selectedEquipmentList)
            {
                int remainingStock = GetRemainingStock(equipment.EquipmentID);
                if (remainingStock == 0)
                {
                    MessageBox.Show($"Cannot submit reservation. {equipment.EquipmentName} now has zero remaining stock.");
                    return;
                }

                if (equipment.Quantity > remainingStock)
                {
                    MessageBox.Show($"Cannot submit reservation. The quantity for {equipment.EquipmentName} exceeds the remaining stock of {remainingStock}.");
                    return;
                }
            }
            if (selectedEquipmentList.Count == 0)
            {
                MessageBox.Show("Please add at least one equipment");
                return;
            }

            if (!IsValidContactNumber(txt_Contact.Text))
            {
                MessageBox.Show("Contact number is invalid. Please enter a valid contact number.");
                return;
            }

            SqlTransaction transaction = null;

            try
            {
                DBConnect();
                transaction = conn.BeginTransaction();


                // Calculate total amount from DataGridView
                decimal totalAmount = 0;
                foreach (DataGridViewRow row in dgv_Selected_Equipments.Rows)
                {
                    if (row.Cells["Total"].Value != null)
                    {
                        // Remove commas before converting
                        string value = row.Cells["Total"].Value.ToString().Replace(",", "");
                        totalAmount += Convert.ToDecimal(value);
                    }
                }

                // Insert Requesting Person
                cmd = new SqlCommand(@"
                    INSERT INTO tbl_Requesting_Person 
                    (fld_Surname, fld_First_Name, fld_Middle_Name, fld_Requesting_Person_Address, fld_Contact_Number, fld_Request_Origin, fld_Requesting_Office) 
                    OUTPUT INSERTED.pk_Requesting_PersonID 
                    VALUES (@Surname, @FirstName, @MiddleName, @Address, @ContactNumber, @RequestOrigin, @RequestingOffice)",
                  conn, transaction);

                cmd.Parameters.AddWithValue("@Surname", txt_Surname.Text);
                cmd.Parameters.AddWithValue("@FirstName", txt_First_Name.Text);
                cmd.Parameters.AddWithValue("@MiddleName", txt_Middle_Name.Text);
                cmd.Parameters.AddWithValue("@Address", txt_Address.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", txt_Contact.Text);
                cmd.Parameters.AddWithValue("@RequestOrigin", combo_Origin.Text);
                cmd.Parameters.AddWithValue("@RequestingOffice", txt_Requesting_Office.Text);

                int personID = (int)cmd.ExecuteScalar();

                // Insert Reservation (without start date, end date, status)
                cmd = new SqlCommand(@"
                INSERT INTO tbl_Reservation 
                (fld_Control_Number, fld_Reservation_Type, fld_Activity_Name, fld_Number_Of_Participants, fld_Created_At, fld_Total_Amount, fk_Requesting_PersonID) 
                OUTPUT INSERTED.pk_ReservationID 
                VALUES (@fld_Control_Number, @fld_Reservation_Type, @fld_Activity_Name, @fld_Number_Of_Participants, @Created_At, @fld_Total_Amount, @Requesting_PersonID)",
                    conn, transaction);

                cmd.Parameters.AddWithValue("@fld_Control_Number", txt_Control_Num.Text);
                cmd.Parameters.AddWithValue("@fld_Reservation_Type", "Equipment");

                cmd.Parameters.AddWithValue("@fld_Activity_Name", txt_Activity.Text);
                cmd.Parameters.AddWithValue("@fld_Number_Of_Participants", "00");
                cmd.Parameters.AddWithValue("@fld_Total_Amount", totalAmount);
                cmd.Parameters.AddWithValue("@Requesting_PersonID", personID);
                cmd.Parameters.AddWithValue("@Created_At", DateTime.Now); // <-- Current Date and Time

                int reservationID = (int)cmd.ExecuteScalar();

                // Insert equipment reservation and update stock
                foreach (var equipment in selectedEquipmentList)
                {
                    // Get pricing ID
                    cmd = new SqlCommand(@"

                SELECT pk_Equipment_PricingID 
                FROM tbl_Equipment_Pricing 
                WHERE fk_EquipmentID = @FacilityID",
                        conn, transaction);

                    cmd.Parameters.AddWithValue("@FacilityID", equipment.EquipmentID);
                    int venuePricingID = (int)cmd.ExecuteScalar();
                    // ABZ - AKO NAG ADD NITO TO 
                    // Check remaining stock
                    cmd = new SqlCommand(@"
                    SELECT fld_Remaining_Stock 
                    FROM tbl_Equipment 
                    WHERE pk_EquipmentID = @EquipmentID", conn, transaction);

                    cmd.Parameters.AddWithValue("@EquipmentID", equipment.EquipmentID);
                    int remainingStock = (int)cmd.ExecuteScalar();

                    if (equipment.Quantity > remainingStock)
                    {
                        // Handle the case when not enough stock is available
                        throw new InvalidOperationException($"? Not enough stock for equipment ID {equipment.EquipmentID}. Requested: {equipment.Quantity}, Available: {remainingStock}");
                        // OR: Show MessageBox / log and continue
                        // MessageBox.Show($"Not enough stock for equipment {equipment.EquipmentID}.");
                        // continue;
                    }


                    // Insert into tbl_Reservation_Equipment with dates and status
                    cmd = new SqlCommand(@"
                INSERT INTO tbl_Reservation_Equipment 
                (fk_ReservationID, fk_EquipmentID, fk_Equipment_PricingID, fld_Quantity, fld_Number_Of_Days, fld_Total_Equipment_Cost, fld_Start_Date_Eq, fld_End_Date_Eq, fld_Equipment_Status) 
                VALUES (@fk_ReservationID, @fk_EquipmentID, @fk_Equipment_PricingID, @fld_Quantity, @fld_Number_Of_Days, @fld_Total_Equipment_Cost, @fld_Start_Date_Eq, @fld_End_Date_Eq, @fld_Equipment_Status)",

                        conn, transaction);

                    cmd.Parameters.AddWithValue("@fk_ReservationID", reservationID);
                    cmd.Parameters.AddWithValue("@fk_EquipmentID", equipment.EquipmentID);
                    cmd.Parameters.AddWithValue("@fk_Equipment_PricingID", venuePricingID);
                    cmd.Parameters.AddWithValue("@fld_Quantity", equipment.Quantity);
                    cmd.Parameters.AddWithValue("@fld_Number_Of_Days", txt_Days_Of_Use.Text);

                    cmd.Parameters.AddWithValue("@fld_Total_Equipment_Cost", equipment.CalculatedTotal);
                    cmd.Parameters.AddWithValue("@fld_Start_Date_Eq", Date_Start.Value);
                    cmd.Parameters.AddWithValue("@fld_End_Date_Eq", Date_End.Value);
                    cmd.Parameters.AddWithValue("@fld_Equipment_Status", "Pending");



                    cmd.ExecuteNonQuery();

                    // Update available quantity
                    cmd = new SqlCommand(@"

                UPDATE tbl_Equipment 
                SET fld_Remaining_Stock = fld_Remaining_Stock - @Quantity 
                WHERE pk_EquipmentID = @EquipmentID",

                        conn, transaction);

                    cmd.Parameters.AddWithValue("@Quantity", equipment.Quantity);
                    cmd.Parameters.AddWithValue("@EquipmentID", equipment.EquipmentID);

                    cmd.ExecuteNonQuery();
                }


                transaction.Commit();
                MessageBox.Show("Reservation submitted successfully!");
                this.Close();
                // Clear form
                selectedEquipmentList.Clear();
                UpdateSelectedEquipmentDisplay();
                ClearForm();
                RefreshCalendarView();
                txt_Control_Num.Text = GenerateControlNumber();
            }
            catch (SqlException ex)
            {
                transaction?.Rollback();
                if (ex.Number == 547)
                {
                    MessageBox.Show("Error: " + ex.Message + " Please ensure all data meets the required constraints.", "Constraint Error");
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message, "Error");
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Error: " + ex.Message, "Error");
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

        private void ClearForm()
        {
            txt_Surname.Text = "";
            txt_First_Name.Text = "";
            txt_Address.Text = "";
            txt_Middle_Name.Text = "";
            txt_Contact.Text = "";
            txt_Requesting_Office.Text = "";
            txt_Activity.Text = "";
            txt_Control_Num.Text = "";
            txt_Quantity.Text = "1";
            txt_Total.Text = "0.00";
            
            combo_Origin.SelectedIndex = -1;
            combo_Utility.SelectedIndex = -1;
            Date_Start.Value = DateTime.Now;
            Date_End.Value = DateTime.Now;

        }

        private bool IsValidContactNumber(string contactNumber)
        {
            string cleanedContactNumber = new string(contactNumber.Where(char.IsDigit).ToArray());
            return cleanedContactNumber.Length >= 10 && cleanedContactNumber.Length <= 15;
        }

        private void Combo_Utility_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Utility.SelectedValue == null) return;

            if (int.TryParse(combo_Utility.SelectedValue.ToString(), out int selectedUtilityId))
            {
                LoadUtilityDetails(selectedUtilityId);
            }
        }

        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }

        

        private void combo_Origin_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Origin selection changed logic if needed
        }

        private void frm_createutilityreservation_Load(object sender, EventArgs e)
        {
            // Form load logic if needed
            DisableManualInput(Date_Start);
            DisableManualInput(Date_End);
        }
        private void DisableManualInput(DateTimePicker dateTimePicker)
        {
            dateTimePicker.ShowUpDown = false; // Ensure dropdown calendar is shown
            dateTimePicker.KeyPress += (s, e) => e.Handled = true; // Suppress key presses
            dateTimePicker.KeyDown += (s, e) => e.Handled = true; // Suppress key down events
        }
        private void btn_AddEquipment_Click_1(object sender, EventArgs e)
        {
            // Validate equipment selection
            if (combo_Utility.SelectedValue == null || string.IsNullOrEmpty(txt_Quantity.Text))
            {
                MessageBox.Show("Please select equipment and enter quantity");
                return;
            }

            // Parse equipment ID
            if (!int.TryParse(combo_Utility.SelectedValue.ToString(), out int equipmentId))
            {
                MessageBox.Show("Invalid equipment selected");
                return;
            }

            // Parse quantity (this was missing in your code)
            if (!int.TryParse(txt_Quantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (must be a positive number)");
                return;
            }

            // Check remaining stock
            int remainingStock = GetRemainingStock(equipmentId);
            if (remainingStock <= 0)
            {
                MessageBox.Show("This equipment has no remaining stock and cannot be reserved.");
                return;
            }

            // Validate quantity against remaining stock
            if (quantity > remainingStock)
            {
                MessageBox.Show($"The quantity exceeds the remaining stock of this equipment. Only {remainingStock} items are available.");
                return;
            }

            // Parse numeric values safely
            if (!decimal.TryParse(txt_Total.Tag.ToString(), out decimal rate) ||
                !decimal.TryParse(txt_Total.Text, out decimal totalAmount) ||
                !decimal.TryParse(txt_Days_Of_Use.Text, out decimal numDays))
            {
                MessageBox.Show("Invalid numeric values detected");
                return;
            }

            // Add to selected equipment list
            selectedEquipmentList.Add(new SelectedEquipment
            {
                EquipmentID = equipmentId,
                EquipmentName = combo_Utility.Text,
                Quantity = quantity,
                NumDays = numDays,
                CalculatedTotal = totalAmount
            });

            UpdateSelectedEquipmentDisplay();

            // Reset selection controls
            combo_Utility.SelectedIndex = -1;
            txt_Quantity.Text = "1";
            txt_Total.Text = "0.00";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Price_Subsequent_TextChanged(object sender, EventArgs e)
        {
            txt_Price_Subsequent.TextChanged -= txt_Price_Subsequent_TextChanged;
            FormatCurrencyTextBox(txt_Price_Subsequent);
            txt_Price_Subsequent.TextChanged += txt_Price_Subsequent_TextChanged;

            CalculateTotalAmount();
        }

        private void Date_Start_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btn_clearform_Click(object sender, EventArgs e)
        {

            // Clear textboxes
            txt_Surname.Clear();
            txt_First_Name.Clear();
            txt_Address.Clear();
            txt_Contact.Clear();
            txt_Requesting_Office.Clear();
            txt_Activity.Clear();
            txt_Quantity.Text = "1";
            txt_Total.Text = "0.00";

            // Reset ComboBoxes to default selection
            combo_Origin.SelectedIndex = -1;
            combo_Utility.SelectedIndex = -1;

            // Reset DateTimePickers to current date and time
            Date_Start.Value = DateTime.Now;
            Date_End.Value = DateTime.Now;


            // Refresh the control number
            txt_Control_Num.Text = GenerateControlNumber();

            // Optionally, reset any other controls as needed
        }

        private int GetRemainingStock(int equipmentId)
        {
            try
            {
                DBConnect();
                string query = "SELECT fld_Remaining_Stock FROM tbl_Equipment WHERE pk_EquipmentID = @EquipmentID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EquipmentID", equipmentId);

                object result = cmd.ExecuteScalar();
                int stock = result != null ? Convert.ToInt32(result) : 0;
                return stock > 0 ? stock : 0; // Return 0 if stock is negative
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking remaining stock: " + ex.Message);
                return 0;
            }
            finally
            {
                DBClose();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_Quantity_TextChanged_1(object sender, EventArgs e)
        {
            CalculateTotalAmount();

            if (combo_Utility.SelectedValue != null && !string.IsNullOrEmpty(txt_Quantity.Text))
            {
                if (int.TryParse(combo_Utility.SelectedValue.ToString(), out int equipmentId) &&
                    int.TryParse(txt_Quantity.Text, out int quantity))
                {
                    int remainingStock = GetRemainingStock(equipmentId);

                    if (quantity > remainingStock)
                    {
                        string availableStock = remainingStock > 0 ? remainingStock.ToString() : "0";
                        MessageBox.Show($"The quantity exceeds the remaining stock of this equipment. Only {availableStock} items are available.");
                        txt_Quantity.Text = availableStock;
                        txt_Quantity.SelectAll();
                        txt_Quantity.Focus();
                    }
                }
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void combo_Origin_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            combo_Origin.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void combo_Utility_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            combo_Utility.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        //remove the selected row in the datagridview
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (dgv_Selected_Equipments.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_Selected_Equipments.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < selectedEquipmentList.Count)
                {
                    selectedEquipmentList.RemoveAt(selectedIndex);
                    dgv_Selected_Equipments.Rows.RemoveAt(selectedIndex);

                    // Disable Remove button if no rows are left
                    btn_Remove.Enabled = dgv_Selected_Equipments.Rows.Count > 0;
                }
            }
            else
            {
                MessageBox.Show("Please select a row to remove.");
            }
        }

        //enable the btnremove after clicking the cell
        private void dgv_Selected_Equipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Enable the Remove button if any row is selected
            //btn_Remove.Enabled = dgv_Selected_Equipments.SelectedRows.Count > 0;
        }


        private void txt_Total_TextChanged(object sender, EventArgs e)
        {
            txt_Total.TextChanged -= txt_Total_TextChanged;
            FormatCurrencyTextBox(txt_Total);
            txt_Total.TextChanged += txt_Total_TextChanged;
        }
        private void FormatCurrencyTextBox(TextBox textBox)
        {
            // Remove commas and try to parse the value
            if (decimal.TryParse(textBox.Text.Replace(",", ""), out decimal value))
                textBox.Text = value.ToString("N2");
            textBox.SelectionStart = textBox.Text.Length; // Keep caret at end
        }

        private void txt_Contact_TextChanged(object sender, EventArgs e)
        {
            if (txt_Contact.Text.Length > 11)
            {
                MessageBox.Show("Only 11 characters are allowed for the contact number.", "Input Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Contact.Text = txt_Contact.Text.Substring(0, 11);
                txt_Contact.SelectionStart = txt_Contact.Text.Length; // Keep caret at end
            }
        }
    }
}