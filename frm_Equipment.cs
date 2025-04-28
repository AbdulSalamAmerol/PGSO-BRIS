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

        public frm_Equipment()
        {
            InitializeComponent();
            dt_equipment.CellClick += dt_equipment_CellClick; // Handle cell click event

            // Populate the ComboBox with filter options
            combobox_Filter.Items.AddRange(new string[] { "All", "Pending", "Cancelled", "Confirmed" });
            combobox_Filter.SelectedIndexChanged += combobox_Filter_SelectedIndexChanged; // Add event handler
            txt_Fname.TextChanged += Control_ValueChanged;
            txt_Sname.TextChanged += Control_ValueChanged;
            txt_Requesting_Office.TextChanged += Control_ValueChanged;
            txt_Address.TextChanged += Control_ValueChanged;
            txt_Status.TextChanged += Control_ValueChanged;
             dt_equipment.CellFormatting += dt_equipment_CellFormatting;

            //datagridview column header bg color
            dt_equipment.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dt_equipment.EnableHeadersVisualStyles = false;
            dt_equipment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, System.Drawing.FontStyle.Bold);
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
            if (sender is ComboBox comboBox)
            {
                string selectedStatus = comboBox.SelectedItem.ToString();
                if (selectedStatus == "All")
                {
                    bindingSource.RemoveFilter();
                }
                else
                {
                    bindingSource.Filter = $"fld_Reservation_Status = '{selectedStatus}'";
                }
            }
        }
        private void dt_equipment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the column is one of the numeric columns
            if (dt_equipment.Columns[e.ColumnIndex].Name == "fld_Total_Amount")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("N0"); // Format as comma-separated with no decimal places
                    e.FormattingApplied = true;
                }

            }
        }
        private void dt_equipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = dt_equipment.Rows[e.RowIndex];

                // Populate the basic information
                txt_CN.Text = row.Cells["fld_Control_number"].Value.ToString();
                txt_Status.Text = row.Cells["fld_Reservation_Status"].Value.ToString();
                txt_Equipment_Name.Text = row.Cells["fld_Equipment_Name"].Value.ToString(); // Display only the selected equipment
                txt_Quantity.Text = row.Cells["fld_Quantity"].Value.ToString(); // Display the quantity for the selected equipment

                // Fetch and display additional information
                string controlNumber = row.Cells["fld_Control_number"].Value.ToString();
                string equipmentName = row.Cells["fld_Equipment_Name"].Value.ToString();
                FetchAndDisplayAdditionalInfo(controlNumber, equipmentName);
            }

        }

        private void FetchAndDisplayAdditionalInfo(string controlNumber, string equipmentName)
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = @"
                    SELECT 
                        rp.fld_First_Name, 
                        rp.fld_Surname,
                        rp.fld_Requesting_Office,
                        rp.fld_Requesting_Person_Address,
                        r.fld_Start_Date,
                        r.fld_End_Date,
                        r.fld_Start_Time,
                        r.fld_End_Time,
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
                            // Populate the fields with the specific equipment details
                            txt_Fname.Text = reader["fld_First_Name"].ToString();
                            txt_Sname.Text = reader["fld_Surname"].ToString();
                            txt_Address.Text = reader["fld_Requesting_Person_Address"].ToString();

                            txt_Date_Start.Text = Convert.ToDateTime(reader["fld_Start_Date"]).ToString("MM/dd/yyyy");
                            txt_DateEnd.Text = Convert.ToDateTime(reader["fld_End_Date"]).ToString("MM/dd/yyyy");

                            txt_HourStart.Text = DateTime.Today.Add(TimeSpan.Parse(reader["fld_Start_Time"].ToString())).ToString("hh:mm tt");
                            txt_HourEnd.Text = DateTime.Today.Add(TimeSpan.Parse(reader["fld_End_Time"].ToString())).ToString("hh:mm tt");

                            txt_Purpose.Text = reader["fld_Activity_Name"].ToString();
                            txt_Quantity.Text = reader["fld_Quantity"].ToString();

                            // Format the total cost with commas
                            if (decimal.TryParse(reader["fld_Total_Equipment_Cost"].ToString(), out decimal totalCost))
                            {
                                txt_Total.Text = totalCost.ToString("N0"); // Format as comma-separated with no decimal places
                            }
                            else
                            {
                                txt_Total.Text = "0"; // Default to 0 if parsing fails
                            }

                            txt_Reservation_type.Text = reader["fld_Reservation_Type"].ToString();
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
                r.fld_Reservation_Status,
                e.fld_Equipment_Name,
                rpe.fld_Quantity,
                r.fld_Total_Amount,
                rp.fld_First_Name,
                rp.fld_Surname
            FROM 
                tbl_Reservation r
            LEFT JOIN
                tbl_Reservation_Equipment rpe ON r.pk_ReservationID = rpe.fk_ReservationID
            LEFT JOIN
                tbl_Equipment e ON rpe.fk_EquipmentID = e.pk_EquipmentID
            LEFT JOIN
                tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
            WHERE  
                r.fld_Reservation_Type = 'Equipment'";

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {status} data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(filterText))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                bindingSource.Filter = $"fld_Control_number LIKE '%{filterText}%' OR fld_Equipment_Name LIKE '%{filterText}%' OR fld_First_Name LIKE '%{filterText}%' OR fld_Surname LIKE '%{filterText}%'";
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
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

                    string reservationQuery = @"
                        UPDATE tbl_Reservation 
                        SET fld_Reservation_Status = @Status
                        WHERE fld_Control_number = @ControlNumber";

                    using (var command = new SqlCommand(reservationQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Status", txt_Status.Text.Trim());
                        command.Parameters.AddWithValue("@ControlNumber", txt_CN.Text.Trim());
                        command.ExecuteNonQuery();
                    }

                    string personQuery = @"
                        UPDATE tbl_Requesting_Person
                        SET fld_First_Name = @FirstName,
                            fld_Surname = @LastName,
                            fld_Requesting_Office = @RequestingOffice,
                            fld_Requesting_Person_Address = @Address
                        WHERE pk_Requesting_PersonID = 
                            (SELECT fk_Requesting_PersonID 
                             FROM tbl_Reservation 
                             WHERE fld_Control_number = @ControlNumber)";

                    using (var command = new SqlCommand(personQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", txt_Fname.Text.Trim());
                        command.Parameters.AddWithValue("@LastName", txt_Sname.Text.Trim());
                        command.Parameters.AddWithValue("@RequestingOffice", txt_Requesting_Office.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txt_Address.Text.Trim());
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
    }
}
