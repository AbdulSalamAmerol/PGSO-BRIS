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

        }

        private void InitializeFormComponents()
        {
            Time_Start.Format = DateTimePickerFormat.Custom;
            Time_Start.CustomFormat = "hh:mm tt";
            Time_End.Format = DateTimePickerFormat.Custom;
            Time_End.CustomFormat = "hh:mm tt";

           

            combo_Origin.Items.Add("Call");
            combo_Origin.Items.Add("Letter");
            combo_Origin.Items.Add("Walk-In");
            combo_Origin.SelectedIndexChanged += combo_Origin_SelectedIndexChanged;

            combo_Utility.SelectedIndexChanged += Combo_Utility_SelectedIndexChanged;
            txt_Quantity.TextChanged += txt_Quantity_TextChanged;

            Date_Start.ValueChanged += Date_ValueChanged;
            Date_End.ValueChanged += Date_ValueChanged;

            Date_Start.Value = DateTime.Now;
            Date_End.Value = DateTime.Now;

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


        private void Date_ValueChanged(object sender, EventArgs e)
        {
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

            foreach (var item in selectedEquipmentList)
            {
                dgv_Selected_Equipments.Rows.Add(
                    item.EquipmentName,
                    item.Quantity,
                    item.NumDays,
                   // item.Rate.ToString("0.00"),
                    item.CalculatedTotal.ToString("0.00")
                );
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

                if (Time_Start.Value.TimeOfDay >= Time_End.Value.TimeOfDay)
                {
                    MessageBox.Show("Start time must be before end time.");
                    return;
                }

                // Calculate the total amount from the DataGridView
                decimal totalAmount = 0;
                foreach (DataGridViewRow row in dgv_Selected_Equipments.Rows)
                {
                    if (row.Cells["Total"].Value != null)
                    {
                        totalAmount += Convert.ToDecimal(row.Cells["Total"].Value);
                    }
                }

                // Insert Requesting Person
                cmd = new SqlCommand(@"
        INSERT INTO tbl_Requesting_Person 
        (fld_Surname, fld_First_Name, fld_Requesting_Person_Address, fld_Contact_Number, fld_Request_Origin, fld_Requesting_Office) 
        OUTPUT INSERTED.pk_Requesting_PersonID 
        VALUES (@Surname, @FirstName, @Address, @ContactNumber, @RequestOrigin, @RequestingOffice)",
                    conn, transaction);

                cmd.Parameters.AddWithValue("@Surname", txt_Surname.Text);
                cmd.Parameters.AddWithValue("@FirstName", txt_First_Name.Text);
                cmd.Parameters.AddWithValue("@Address", txt_Address.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", txt_Contact.Text);
                cmd.Parameters.AddWithValue("@RequestOrigin", combo_Origin.Text);
                cmd.Parameters.AddWithValue("@RequestingOffice", txt_Requesting_Office.Text);

                int personID = (int)cmd.ExecuteScalar();

                // Insert Reservation with the total amount from the DataGridView
                cmd = new SqlCommand(@"
        INSERT INTO tbl_Reservation 
        (fld_Control_Number, fld_Reservation_Type, fld_Start_Date, fld_End_Date, fld_Start_Time, fld_End_time, fld_Activity_Name, fld_Number_Of_Participants, fld_Reservation_Status, fld_Total_Amount, fk_Requesting_PersonID) 
        OUTPUT INSERTED.pk_ReservationID 
        VALUES (@fld_Control_Number, @fld_Reservation_Type, @fld_Start_Date, @fld_End_Date, @fld_Start_Time, @fld_End_time, @fld_Activity_Name, @fld_Number_Of_Participants, @fld_Reservation_Status, @fld_Total_Amount, @Requesting_PersonID)",
                    conn, transaction);

                cmd.Parameters.AddWithValue("@fld_Control_Number", txt_Control_Num.Text);
                cmd.Parameters.AddWithValue("@fld_Reservation_Type", "Equipment");
                cmd.Parameters.AddWithValue("@fld_Start_Date", Date_Start.Value);
                cmd.Parameters.AddWithValue("@fld_End_Date", Date_End.Value);
                cmd.Parameters.AddWithValue("@fld_Start_Time", Time_Start.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@fld_End_time", Time_End.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@fld_Activity_Name", txt_Activity.Text);
                cmd.Parameters.AddWithValue("@fld_Number_Of_Participants", "00");
                cmd.Parameters.AddWithValue("@fld_Reservation_Status", "Pending");
                cmd.Parameters.AddWithValue("@fld_Total_Amount", totalAmount); // Use the total amount from the DataGridView
                cmd.Parameters.AddWithValue("@Requesting_PersonID", personID);

                int reservationID = (int)cmd.ExecuteScalar();

                // Insert each equipment reservation and update available quantity
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

                    // Insert equipment reservation
                    cmd = new SqlCommand(@"

            INSERT INTO tbl_Reservation_Equipment 
            (fk_ReservationID, fk_EquipmentID, fk_Equipment_PricingID, fld_Quantity, fld_Number_Of_Days, fld_Total_Equipment_Cost) 
            VALUES (@fk_ReservationID, @fk_EquipmentID, @fk_Equipment_PricingID, @fld_Quantity, @fld_Number_Of_Days, @fld_Total_Equipment_Cost)",

                        conn, transaction);

                    cmd.Parameters.AddWithValue("@fk_ReservationID", reservationID);
                    cmd.Parameters.AddWithValue("@fk_EquipmentID", equipment.EquipmentID);
                    cmd.Parameters.AddWithValue("@fk_Equipment_PricingID", venuePricingID);
                    cmd.Parameters.AddWithValue("@fld_Quantity", equipment.Quantity);
                    cmd.Parameters.AddWithValue("@fld_Number_Of_Days", txt_Days_Of_Use.Text);

                    cmd.Parameters.AddWithValue("@fld_Total_Equipment_Cost", equipment.CalculatedTotal); // Include total cost


                    cmd.ExecuteNonQuery();

                    // Update available quantity in tbl_Equipment
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

                // Clear form after successful submission
                selectedEquipmentList.Clear();
                UpdateSelectedEquipmentDisplay();
                ClearForm();
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




        private void ClearForm()
        {
            txt_Surname.Text = "";
            txt_First_Name.Text = "";
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
            Time_Start.Value = DateTime.Now;
            Time_End.Value = DateTime.Now;
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
        }

        private void btn_AddEquipment_Click_1(object sender, EventArgs e)
        {
            if (combo_Utility.SelectedValue == null || string.IsNullOrEmpty(txt_Quantity.Text))
            {
                MessageBox.Show("Please select equipment and enter quantity");
                return;
            }

            if (!int.TryParse(combo_Utility.SelectedValue.ToString(), out int equipmentId))
            {
                MessageBox.Show("Invalid equipment selected");
                return;
            }

            if (!int.TryParse(txt_Quantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Invalid quantity");
                return;
            }

            string equipmentName = combo_Utility.Text;
            decimal rate = decimal.Parse(txt_Total.Tag.ToString());
            decimal totalAmount = decimal.Parse(txt_Total.Text);

            selectedEquipmentList.Add(new SelectedEquipment
            {
                EquipmentID = equipmentId,
                EquipmentName = equipmentName,
                Quantity = quantity,
                //Rate = rate,
                NumDays = decimal.Parse(txt_Days_Of_Use.Text),
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
            CalculateTotalAmount();
        }
    }
}