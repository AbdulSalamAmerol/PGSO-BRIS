using pgso_connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

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

        private DataTable clientInfoTable = new DataTable();
        private bool isClientInfoLoaded = false;
        private DataTable requestingPersonTable = new DataTable();
        private readonly string comboNamePlaceholder = "First Name, Middle Name, Surname";
        private Color comboNamePlaceholderColor = Color.Gray;
        private Color comboNameNormalColor = SystemColors.WindowText;

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

            combo_Name.Validating += combo_Name_Validating;

            InitializeRequestingPersonAutocomplete();
            combo_Name.TextUpdate += combo_Name_TextUpdate;
            combo_Name.SelectedIndexChanged += combo_Name_SelectedIndexChanged;
            // Set placeholder initially
            SetComboNamePlaceholder();

            // Wire up events
            combo_Name.GotFocus += Combo_Name_GotFocus;
            combo_Name.LostFocus += Combo_Name_LostFocus;

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
            if (combo_Name.Text == comboNamePlaceholder)
            {
                MessageBox.Show("Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

            // SPLIT THE NAME HERE
            string[] nameParts = combo_Name.Text.Split(new[] { ',' }, 2);
            string surname = nameParts.Length > 0 ? nameParts[0].Trim() : "";
            string[] firstMiddle = nameParts.Length > 1 ? nameParts[1].Trim().Split(' ') : new string[0];
            string firstName = firstMiddle.Length > 0 ? firstMiddle[0] : "";
            string middleName = firstMiddle.Length > 1 ? string.Join(" ", firstMiddle.Skip(1)) : "";

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
                        string value = row.Cells["Total"].Value.ToString().Replace(",", "");
                        totalAmount += Convert.ToDecimal(value);
                    }
                }

                // Step 1: Check if requesting person exists
                int personID = -1;
                cmd = new SqlCommand(@"
            SELECT pk_Requesting_PersonID 
            FROM tbl_Requesting_Person 
            WHERE fld_Surname = @Surname AND fld_First_Name = @FirstName AND fld_Middle_Name = @MiddleName", conn, transaction);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@MiddleName", middleName);

                object resultPerson = cmd.ExecuteScalar();
                if (resultPerson != null)
                {
                    // Person exists, update their info
                    personID = Convert.ToInt32(resultPerson);
                    cmd = new SqlCommand(@"
                UPDATE tbl_Requesting_Person
                SET fld_Requesting_Person_Address = @Address,
                    fld_Contact_Number = @ContactNumber,
                    fld_Request_Origin = @RequestOrigin,
                    fld_Requesting_Office = @RequestingOffice
                WHERE pk_Requesting_PersonID = @PersonID", conn, transaction);
                    cmd.Parameters.AddWithValue("@Address", txt_Address.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNumber", txt_Contact.Text.Trim());
                    cmd.Parameters.AddWithValue("@RequestOrigin", combo_Origin.Text);
                    cmd.Parameters.AddWithValue("@RequestingOffice", txt_Requesting_Office.Text.Trim());
                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // Person does not exist, insert new
                    cmd = new SqlCommand(@"
                INSERT INTO tbl_Requesting_Person 
                (fld_First_Name, fld_Middle_Name,fld_Surname, fld_Requesting_Person_Address, fld_Contact_Number, fld_Request_Origin, fld_Requesting_Office)
                OUTPUT INSERTED.pk_Requesting_PersonID
                VALUES ( @FirstName, @MiddleName, @Surname, @Address, @ContactNumber, @RequestOrigin, @RequestingOffice)", conn, transaction);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);

                    cmd.Parameters.AddWithValue("@MiddleName", middleName);
                    cmd.Parameters.AddWithValue("@Surname", surname);

                    cmd.Parameters.AddWithValue("@Address", txt_Address.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNumber", txt_Contact.Text.Trim());
                    cmd.Parameters.AddWithValue("@RequestOrigin", combo_Origin.Text);
                    cmd.Parameters.AddWithValue("@RequestingOffice", txt_Requesting_Office.Text.Trim());
                    personID = (int)cmd.ExecuteScalar();
                }

                // Step 2: Insert Reservation
                cmd = new SqlCommand(@"
            INSERT INTO tbl_Reservation
            (fld_Control_Number, fld_Reservation_Type, fld_Activity_Name, fld_Number_Of_Participants, fld_Created_At, fld_Total_Amount, fk_Requesting_PersonID, fld_Start_Date, fld_End_Date, fld_Start_Time, fld_End_Time)
            OUTPUT INSERTED.pk_ReservationID
            VALUES (@fld_Control_Number, @fld_Reservation_Type, @fld_Activity_Name, @fld_Number_Of_Participants, @Created_At, @fld_Total_Amount, @Requesting_PersonID, @fld_Start_Date, @fld_End_Date, @fld_Start_Time, @fld_End_Time)",
                    conn, transaction);

                cmd.Parameters.AddWithValue("@fld_Control_Number", txt_Control_Num.Text);
                cmd.Parameters.AddWithValue("@fld_Reservation_Type", "Equipment");
                cmd.Parameters.AddWithValue("@fld_Activity_Name", txt_Activity.Text);
                cmd.Parameters.AddWithValue("@fld_Number_Of_Participants", "00");
                cmd.Parameters.AddWithValue("@fld_Total_Amount", totalAmount);
                cmd.Parameters.AddWithValue("@Requesting_PersonID", personID);
                cmd.Parameters.AddWithValue("@Created_At", DateTime.Now);
                cmd.Parameters.AddWithValue("@fld_Start_Date", Date_Start.Value);
                cmd.Parameters.AddWithValue("@fld_End_Date", Date_End.Value);
                cmd.Parameters.AddWithValue("@fld_Start_Time", Date_Start.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@fld_End_Time", Date_End.Value.TimeOfDay.Add(TimeSpan.FromSeconds(1)));

                int reservationID = (int)cmd.ExecuteScalar();

                // Step 3: Insert equipment reservation and update stock
                foreach (var equipment in selectedEquipmentList)
                {
                    // Get pricing ID
                    cmd = new SqlCommand(@"
                SELECT pk_Equipment_PricingID 
                FROM tbl_Equipment_Pricing 
                WHERE fk_EquipmentID = @EquipmentID",
                        conn, transaction);

                    cmd.Parameters.AddWithValue("@EquipmentID", equipment.EquipmentID);
                    int equipmentPricingID = (int)cmd.ExecuteScalar();

                    // Insert into tbl_Reservation_Equipment
                    cmd = new SqlCommand(@"
                INSERT INTO tbl_Reservation_Equipment 
                (fk_ReservationID, fk_EquipmentID, fk_Equipment_PricingID, fld_Quantity, fld_Number_Of_Days, fld_Total_Equipment_Cost, fld_Start_Date_Eq, fld_End_Date_Eq, fld_Equipment_Status) 
                VALUES (@fk_ReservationID, @fk_EquipmentID, @fk_Equipment_PricingID, @fld_Quantity, @fld_Number_Of_Days, @fld_Total_Equipment_Cost, @fld_Start_Date_Eq, @fld_End_Date_Eq, @fld_Equipment_Status)",
                        conn, transaction);

                    cmd.Parameters.AddWithValue("@fk_ReservationID", reservationID);
                    cmd.Parameters.AddWithValue("@fk_EquipmentID", equipment.EquipmentID);
                    cmd.Parameters.AddWithValue("@fk_Equipment_PricingID", equipmentPricingID);
                    cmd.Parameters.AddWithValue("@fld_Quantity", equipment.Quantity);
                    cmd.Parameters.AddWithValue("@fld_Number_Of_Days", equipment.NumDays);
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

                //auditlog start
                string affectedTable = "tbl_Reservation";
                string affectedRecordPk = reservationID.ToString();
                string actionType = "Created a Equipment Reservation";

                string changedBy = frm_login.LoggedInUserRole;
                string Uname = frm_login.LoggedInUserRole;
                DateTime changedAt = DateTime.Now;
                int userId = frm_login.LoggedInUserId;
                // Optionally, serialize new data as JSON (for simplicity, just key fields here)
                string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    ControlNumber = txt_Control_Num.Text,
                    Activity = txt_Activity.Text,
                   
                    StartDate = Date_Start,
                    EndDate = Date_End,
           
                    TotalAmount = totalAmount
                });
                MessageBox.Show("Username: " + frm_login.LoggedInUsername);
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
                transaction.Commit();
                MessageBox.Show("Reservation submitted successfully!");
                var billingForm = new frm_Billing();
                billingForm.Show();
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
                MessageBox.Show("Error: " + ex.Message, "Error");
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

            combo_Name.Text = "";
            txt_Address.Text = "";
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
                // Display remaining stock in txt_Remaining
                int remainingStock = GetRemainingStock(selectedUtilityId);
                txt_Remaining.Text = remainingStock.ToString();

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

            
            txt_Address.Clear();
            txt_Contact.Clear();
            txt_Requesting_Office.Clear();
            txt_Activity.Clear();
            txt_Quantity.Text = "1";
            txt_Total.Text = "0.00";

            // Reset ComboBoxes to default selection
            combo_Origin.SelectedIndex = -1;
            combo_Utility.SelectedIndex = -1;
            combo_Name.SelectedIndex = -1;
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

        private void combo_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Defensive: prevent out-of-range access
            if (combo_Name.SelectedIndex < 0 || combo_Name.SelectedIndex >= combo_Name.Items.Count)
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
            combo_Name.DroppedDown = false;

            // Find the correct row (with office if available)
            // Find the correct row (with office if available)
            DataRow match = requestingPersonTable.AsEnumerable()
                .FirstOrDefault(row =>
                    $"{row["fld_Surname"]}, {row["fld_First_Name"]} {row["fld_Middle_Name"]}".Trim().Equals(namePart.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    (
                        (officePart == null && string.IsNullOrEmpty(row["fld_Requesting_Office"]?.ToString().Trim())) ||
                        (officePart != null && (row["fld_Requesting_Office"]?.ToString().Trim().Equals(officePart, StringComparison.OrdinalIgnoreCase) ?? false))
                    )
                );

            if (match != null)
            {
                txt_Address.Text = match["fld_Requesting_Person_Address"]?.ToString();
                txt_Contact.Text = match["fld_Contact_Number"]?.ToString();
                txt_Requesting_Office.Text = match["fld_Requesting_Office"]?.ToString();
            }
        }
        private void combo_Name_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string input = combo_Name.Text.Trim();

            // Remove office part if present
            int idx = input.LastIndexOf(" (");
            if (idx > 0 && input.EndsWith(")"))
            {
                input = input.Substring(0, idx).Trim();
                combo_Name.Text = input;
            }
        }

        /*private void Combo_Name_KeyUp(object sender, KeyEventArgs e)
        {
            string searchText = combo_Name.Text.Trim();

            if (searchText.Length == 0)
            {
                combo_Name.DroppedDown = false;
                return;
            }

            try
            {
                DBConnect();
                string query = @"
            SELECT 
                fld_Fname, fld_Address, fld_Contact, fld_Office
            FROM 
                tbl_Client_Info
            WHERE 
                fld_Fname LIKE @search + '%'
        ";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", searchText);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                combo_Name.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string fullName = row["fld_Fname"].ToString();
                    combo_Name.Items.Add(fullName);
                }

                combo_Name.DroppedDown = combo_Name.Items.Count > 0;
                combo_Name.SelectionStart = combo_Name.Text.Length;
                combo_Name.SelectionLength = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading client names: " + ex.Message);
            }
            finally
            {
                DBClose();
            }
        }*/

        private string GetDisplayName(DataRow row)
        {
            string surname = row["fld_Surname"]?.ToString().Trim() ?? "";
            string firstName = row["fld_First_Name"]?.ToString().Trim() ?? "";
            string middleName = row["fld_Middle_Name"]?.ToString().Trim() ?? "";
            string office = row["fld_Requesting_Office"]?.ToString().Trim();

            string name = $"{surname}, {firstName} {middleName}".Trim();
            if (!string.IsNullOrEmpty(office))
                name += $" ({office})";
            return name;
        }
        private void combo_Name_TextUpdate(object sender, EventArgs e)
        {    // Defensive: prevent out-of-range access
             //if (combo_Name.SelectedIndex < 0 || combo_Name.SelectedIndex >= combo_Name.Items.Count) return;

            combo_Name.DroppedDown = true; // Show suggestions, but don't filter
        }

        private void InitializeRequestingPersonAutocomplete()
        {
            try
            {
                DBConnect();
                string query = @"SELECT pk_Requesting_PersonID, fld_Surname, fld_First_Name, fld_Middle_Name, fld_Requesting_Person_Address, fld_Contact_Number, fld_Requesting_Office 
                         FROM tbl_Requesting_Person";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    requestingPersonTable = new DataTable();
                    adapter.Fill(requestingPersonTable);
                }

                combo_Name.Items.Clear();

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
        private void InitializeRequestingPersonCombo(string field)
        {
            try
            {
                DBConnect();
                string query = @"SELECT pk_Requesting_PersonID, fld_Surname, fld_First_Name, fld_Middle_Name 
                         FROM tbl_Requesting_Person";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    requestingPersonTable = new DataTable();
                    adapter.Fill(requestingPersonTable);
                }

                combo_Name.Items.Clear();
                foreach (DataRow row in requestingPersonTable.Rows)
                {
                    string value = row[field]?.ToString();
                    if (!string.IsNullOrWhiteSpace(value) && !combo_Name.Items.Contains(value))
                    {
                        combo_Name.Items.Add(value);
                    }
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
    }
}