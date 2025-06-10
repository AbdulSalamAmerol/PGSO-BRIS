using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using pgso_connect;

namespace pgso
{
    public partial class frm_Equipment : Form
    {
        // Fields
        private Connection db = new Connection(); // Use the Connection class
        private BindingSource bindingSource = new BindingSource();
        public event EventHandler DashboardRefreshRequested;
        private const string SearchPlaceholder = "Search by control number, equipment, or name...";
        private DataTable allData = new DataTable();
        private int currentPage = 1;
        private int pageSize = 30; // Change as needed
        private int totalRecords = 0;
        private int totalPages = 0;
        // Method to raise the event
        protected virtual void OnDashboardRefreshRequested()
        {
            DashboardRefreshRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btn_ToDashboard_Click(object sender, EventArgs e)
        {
            // Raise the event
            OnDashboardRefreshRequested();
            this.Close();
        }
        private void UpdateTextBoxEditability()
        {
            bool isPending = txt_Status.Text.Equals("Pending", StringComparison.OrdinalIgnoreCase);
            txt_Fname.Enabled = isPending;
          
            txt_Requesting_Office.Enabled = isPending;
            txt_Address.Enabled = isPending;
            txt_Contact.Enabled = isPending;
        }
        public frm_Equipment()
        {

            

            InitializeComponent();
            dt_equipment.CellClick += dt_equipment_CellClick; // Handle cell click event
            dt_equipment.RowPostPaint += dt_equipment_RowPostPaint;
           
            // Populate the ComboBox with filter options
            combobox_Filter.Items.AddRange(new string[] { "All", "Pending", "Cancelled", "Confirmed" });
            PopulateEquipmentNamesInFilter(); 

            combobox_Filter.SelectedIndexChanged += combobox_Filter_SelectedIndexChanged; // Add event handler
            txt_Fname.TextChanged += Control_ValueChanged;
           
            txt_Requesting_Office.TextChanged += Control_ValueChanged;
            txt_Address.TextChanged += Control_ValueChanged;
            txt_Status.TextChanged += Control_ValueChanged;
             dt_equipment.CellFormatting += dt_equipment_CellFormatting;
            // Set up placeholder for search box
            textBox1.ForeColor = System.Drawing.Color.Gray;
            textBox1.Text = "Control Number/Venue";
            textBox1.GotFocus += Txt_Search_GotFocus;
            textBox1.LostFocus += Txt_Search_LostFocus;

            btn_Update.Enabled = false; // Disable by default
 

            dt_equipment.CellClick += dt_equipment_CellClick;

            // Only these fields should enable the update button
            txt_Fname.TextChanged += Control_ValueChanged;
          
            txt_Requesting_Office.TextChanged += Control_ValueChanged;
            txt_Address.TextChanged += Control_ValueChanged;
            txt_Contact.TextChanged += Control_ValueChanged;


            //datagridview column header bg color
            dt_equipment.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumAquamarine;
            dt_equipment.EnableHeadersVisualStyles = false;
            dt_equipment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft sans serif", 10, System.Drawing.FontStyle.Bold);
            // Clear and repopulate filter ComboBox
            combobox_Filter.Items.Clear();
            combobox_Filter.Items.Add("All");
            combobox_Filter.Items.Add("Pending");
            combobox_Filter.Items.Add("Cancelled");
            combobox_Filter.Items.Add("Confirmed");
            combobox_Filter.Items.Add("------"); // Separator

            // Add equipment names
            PopulateEquipmentNamesInFilter();

            combobox_Filter.SelectedIndexChanged += combobox_Filter_SelectedIndexChanged;
            combobox_Filter.DrawMode = DrawMode.OwnerDrawFixed;
            combobox_Filter.DrawItem += combobox_Filter_DrawItem;

        }
        private void Txt_Search_GotFocus(object sender, EventArgs e)
        {
            if (textBox1.Text == "Control Number/Venue")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void Txt_Search_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Control Number/Venue";
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
        }
        private void combobox_Filter_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var combo = sender as ComboBox;
            string itemText = combo.Items[e.Index].ToString();

            e.DrawBackground();
            using (var brush = new System.Drawing.SolidBrush(e.ForeColor))
            {
                if (itemText == "------")
                {
                    TextRenderer.DrawText(e.Graphics, itemText, e.Font, e.Bounds, System.Drawing.Color.Gray, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                else
                {
                    e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
                }
            }
            e.DrawFocusRectangle();
        }
        private void dt_equipment_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Find the "Item" column index
            int itemColIndex = dt_equipment.Columns["Item"].Index;
            // Set the value to the row number (1-based)
            dt_equipment.Rows[e.RowIndex].Cells[itemColIndex].Value = (e.RowIndex + 1).ToString();
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            btn_Update.Enabled = true;
        }

        private void frm_Equipment_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void combobox_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_Filter.SelectedItem != null && combobox_Filter.SelectedItem.ToString() == "------")
            {
                combobox_Filter.SelectedIndex = 0;
                return;
            }

            string selected = combobox_Filter.SelectedItem?.ToString();
            if (selected == "All")
            {
                bindingSource.RemoveFilter();
            }
            else if (selected == "Pending" || selected == "Cancelled" || selected == "Confirmed")
            {
                bindingSource.Filter = $"fld_Equipment_Status = '{selected}'";
            }
            else
            {
                // Assume it's an equipment name
                bindingSource.Filter = $"fld_Equipment_Name = '{selected?.Replace("'", "''")}'";
            }
        }
        private void dt_equipment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format the total amount column
            if (dt_equipment.Columns[e.ColumnIndex].Name == "fld_Total_Amount")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = "₱" + value.ToString("N2");
                    e.FormattingApplied = true;
                }
            }

            // Color the entire row based on the equipment status
            if (dt_equipment.Columns.Contains("fld_Equipment_Status"))
            {
                var statusCell = dt_equipment.Rows[e.RowIndex].Cells["fld_Equipment_Status"];
                if (statusCell.Value != null)
                {
                    string status = statusCell.Value.ToString();
                    if (status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
                    {
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 235, 245);
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(242, 239, 231);
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                    {
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 228, 225);
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        // Optional: reset to default for other statuses
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
        }
        private void dt_equipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dt_equipment.Rows[e.RowIndex];

                txt_CN.Text = row.Cells["fld_Control_number"].Value.ToString();
                txt_Status.Text = row.Cells["fld_Equipment_Status"].Value.ToString();
                txt_Equipment_Name.Text = row.Cells["fld_Equipment_Name"].Value.ToString();
                txt_Quantity.Text = row.Cells["fld_Quantity"].Value.ToString();

                string controlNumber = row.Cells["fld_Control_number"].Value.ToString();
                string equipmentName = row.Cells["fld_Equipment_Name"].Value.ToString();
                FetchAndDisplayAdditionalInfo(controlNumber, equipmentName);

                btn_Update.Enabled = false; // Reset after loading data

                UpdateTextBoxEditability(); // <-- Add this line
            }
        }
        //display in the panel
        private void FetchAndDisplayAdditionalInfo(string controlNumber, string equipmentName)
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = @"
    SELECT 
        rp.fld_First_Name, 
        rp.fld_Middle_Name,         -- Add this
        rp.fld_Surname,           -- Add this
        rp.fld_Requesting_Office,
        rp.fld_Requesting_Person_Address,
        rp.fld_Contact_Number,
        rpe.fld_Start_Date_Eq,
        rpe.fld_End_Date_Eq,
        rpe.fld_Number_Of_Days,
        r.fld_Activity_Name,
        r.fld_Reservation_Type,
        rpe.fld_Quantity,
        rpe.fld_Total_Equipment_Cost
    FROM 
        tbl_Reservation r
    LEFT JOIN 
        tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
    LEFT JOIN 
        tbl_Reservation_Equipment rpe ON r.pk_ReservationID = rpe.fk_ReservationID
    LEFT JOIN
        tbl_Equipment e ON rpe.fk_EquipmentID = e.pk_EquipmentID
    WHERE 
        r.fld_Control_number = @ControlNumber AND e.fld_Equipment_Name = @EquipmentName";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                    cmd.Parameters.AddWithValue("@EquipmentName", equipmentName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Combine first, middle, and last name
                            string firstName = reader["fld_First_Name"]?.ToString() ?? "";
                            string middleName = reader["fld_Middle_Name"]?.ToString() ?? "";
                            string lastName = reader["fld_Surname"]?.ToString() ?? "";
                            string fullName = $"{firstName} {middleName} {lastName}".Replace("  ", " ").Trim();

                            txt_Fname.Text = string.IsNullOrWhiteSpace(fullName) ? "N/A" : fullName;

                            txt_Requesting_Office.Text = reader["fld_Requesting_Office"].ToString();
                            txt_Address.Text = reader["fld_Requesting_Person_Address"].ToString();
                            txt_Contact.Text = reader["fld_Contact_Number"].ToString();
                            txt_Number_of_Days.Text = reader["fld_Number_Of_Days"].ToString();
                            txt_Purpose.Text = reader["fld_Activity_Name"].ToString();
                            txt_Quantity.Text = reader["fld_Quantity"].ToString();

                            // Format the total cost with peso sign and commas
                            if (decimal.TryParse(reader["fld_Total_Equipment_Cost"].ToString(), out decimal totalCost))
                            {
                                txt_Total.Text = "₱" + totalCost.ToString("N2");
                            }
                            else
                            {
                                txt_Total.Text = "₱0.00";
                            }

                            // Get the start and end dates
                            string startDate = reader["fld_Start_Date_Eq"] != DBNull.Value
                                ? Convert.ToDateTime(reader["fld_Start_Date_Eq"]).ToString("MM/dd/yyyy")
                                : null;

                            string endDate = reader["fld_End_Date_Eq"] != DBNull.Value
                                ? Convert.ToDateTime(reader["fld_End_Date_Eq"]).ToString("MM/dd/yyyy")
                                : null;

                            // Format the date display
                            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate) && startDate != endDate)
                            {
                                txt_Date_Start.Text = $"{startDate} - {endDate}";
                            }
                            else if (!string.IsNullOrEmpty(startDate))
                            {
                                txt_Date_Start.Text = startDate;
                            }
                            else
                            {
                                txt_Date_Start.Text = "N/A";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching additional information: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }



        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string queryApproved = @"
    SELECT 
        r.fld_Control_number, 
        rpe.fld_Equipment_Status,
        r.fld_Created_At,
        rpe.fld_Equipment_Status,
        e.fld_Equipment_Name,
        rpe.fld_Quantity,
        r.fld_Total_Amount,
        '₱' + CONVERT(VARCHAR, CAST(r.fld_Total_Amount AS MONEY), 1) AS fld_Total_Amount,
        rp.fld_First_Name,
       
        CASE 
            WHEN rpe.fld_Start_Date_Eq = rpe.fld_End_Date_Eq 
                THEN FORMAT(rpe.fld_Start_Date_Eq, 'M/d/yyyy')
            ELSE 
                FORMAT(rpe.fld_Start_Date_Eq, 'M/d/yyyy') + ' - ' + FORMAT(rpe.fld_End_Date_Eq, 'M/d/yyyy')
        END AS Date
    FROM 
        tbl_Reservation r
    LEFT JOIN
        tbl_Reservation_Equipment rpe ON r.pk_ReservationID = rpe.fk_ReservationID
    LEFT JOIN
        tbl_Equipment e ON rpe.fk_EquipmentID = e.pk_EquipmentID
    LEFT JOIN
        tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
    WHERE  
        r.fld_Reservation_Type = 'Equipment'
    ORDER BY r.fld_Created_At DESC"; // Changed to DESC for newest first

                LoadData(queryApproved, dt_equipment, "Approved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }




        private void LoadData(string query, DataGridView dataGridView, string status)
        {
            try
            {
                DataTable tempDt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tempDt);
                    }
                }

                dataGridView.AutoGenerateColumns = false;
                bindingSource.DataSource = tempDt;
                dataGridView.DataSource = bindingSource;

                if (tempDt.Rows.Count == 0)
                {
                    MessageBox.Show($"No {status} records found.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                allData.Clear();
                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(allData);
                }

                totalRecords = allData.Rows.Count;
                totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
                currentPage = 1;
                DisplayPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {status} data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayPage()
        {
            if (allData.Rows.Count == 0)
            {
                bindingSource.DataSource = null;
                dt_equipment.DataSource = bindingSource;
                lblPageInfo.Text = "Page 0 of 0";
                return;
            }

            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, totalRecords);

            DataTable pageTable = allData.Clone();
            for (int i = startIndex; i < endIndex; i++)
            {
                pageTable.ImportRow(allData.Rows[i]);
            }

            bindingSource.DataSource = pageTable;
            dt_equipment.DataSource = bindingSource;
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(filterText) || filterText == "Control Number/Venue")
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                bindingSource.Filter = $"fld_Control_number LIKE '%{filterText}%' OR fld_Equipment_Name LIKE '%{filterText}%' OR fld_First_Name LIKE '%{filterText}%'";
            }
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to update?",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            if (string.IsNullOrEmpty(txt_CN.Text))
            {
                MessageBox.Show("Please select a reservation first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();

                    // Update equipment status in tbl_Reservation_Equipment
                    string equipmentStatusQuery = @"
            UPDATE tbl_Reservation_Equipment
            SET fld_Equipment_Status = @Status
            WHERE fk_ReservationID = (SELECT pk_ReservationID FROM tbl_Reservation WHERE fld_Control_number = @ControlNumber)
              AND fk_EquipmentID = (SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = @EquipmentName)";

                    using (var command = new SqlCommand(equipmentStatusQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Status", txt_Status.Text.Trim());
                        command.Parameters.AddWithValue("@ControlNumber", txt_CN.Text.Trim());
                        command.Parameters.AddWithValue("@EquipmentName", txt_Equipment_Name.Text.Trim());
                        command.ExecuteNonQuery();
                    }

                    // Update requesting person details including contact number
                    string personQuery = @"
            UPDATE tbl_Requesting_Person
            SET fld_First_Name = @FirstName,
                
                fld_Requesting_Office = @RequestingOffice,
                fld_Requesting_Person_Address = @Address,
                fld_Contact_Number = @ContactNumber
            WHERE pk_Requesting_PersonID = 
                (SELECT fk_Requesting_PersonID 
                 FROM tbl_Reservation 
                 WHERE fld_Control_number = @ControlNumber)";

                    using (var command = new SqlCommand(personQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", txt_Fname.Text.Trim());
                        
                        command.Parameters.AddWithValue("@RequestingOffice", txt_Requesting_Office.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txt_Address.Text.Trim());
                        command.Parameters.AddWithValue("@ContactNumber", txt_Contact.Text.Trim());
                        command.Parameters.AddWithValue("@ControlNumber", txt_CN.Text.Trim());
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            btn_Update.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No changes were made.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Total_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void dt_equipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_Number_of_Days_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Address_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Requesting_Office_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayPage();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayPage();
            }
        }

        private void combobox_Filter_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void PopulateEquipmentNamesInFilter()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                using (SqlCommand cmd = new SqlCommand(@"
            SELECT DISTINCT e.fld_Equipment_Name
            FROM tbl_Equipment e
            INNER JOIN tbl_Reservation_Equipment rpe ON e.pk_EquipmentID = rpe.fk_EquipmentID
            INNER JOIN tbl_Reservation r ON rpe.fk_ReservationID = r.pk_ReservationID
            WHERE r.fld_Reservation_Type = 'Equipment'
            ORDER BY e.fld_Equipment_Name", db.strCon))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string equipmentName = reader["fld_Equipment_Name"].ToString();
                        if (!string.IsNullOrWhiteSpace(equipmentName))
                            combobox_Filter.Items.Add(equipmentName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading equipment names: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }

        private void txt_CN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Fname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
