using pgso_connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Venues : Form
    {
        private readonly Connection db = new Connection();
        private readonly BindingSource bindingSource = new BindingSource();
        private bool hasChanges = false;
        private string currentControlNumber = string.Empty;

        public frm_Venues()
        {
            InitializeComponent();
            InitializeControls();
            SetupEventHandlers();
        }

        //The BindingSource is set as the DataSource of the DataGridView here
        private void InitializeControls()
        {
            dt_all.AutoGenerateColumns = false;
            dt_all.DataSource = bindingSource;
            combobox_Filter.Items.AddRange(new[] { "All", "Pending", "Cancelled", "Confirmed" });
            combobox_Filter.SelectedIndex = 0;
            btn_Update.Enabled = false;
        }

        private void SetupEventHandlers()
        {
            dt_all.CellClick += Dt_all_CellClick;
            dt_all.CellFormatting += Dt_all_CellFormatting;
            combobox_Filter.SelectedIndexChanged += Combobox_Filter_SelectedIndexChanged;
            txt_Search.TextChanged += Txt_Search_TextChanged;

            txt_FName.TextChanged += Control_ValueChanged;
            txt_LName.TextChanged += Control_ValueChanged;
            txt_Address.TextChanged += Control_ValueChanged;
            txt_Status.TextChanged += Control_ValueChanged;
            txt_Activity.TextChanged += Control_ValueChanged;
            txt_Participants.TextChanged += Control_ValueChanged;
            //Date_Start.ValueChanged += Control_ValueChanged;
            //Date_End.ValueChanged += Control_ValueChanged;
            //Time_Start.ValueChanged += Control_ValueChanged;
            // Time_End.ValueChanged += Control_ValueChanged;

            // btn_Update.Click += btn_Update_Click;
            //btn_Refresh.Click += Btn_Refresh_Click;
            dt_all.CellFormatting += dt_all_CellFormatting;
            //datagridview column header bg color
            dt_all.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dt_all.EnableHeadersVisualStyles = false;
            dt_all.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, System.Drawing.FontStyle.Bold);

        }

        private void frm_Venues_Load(object sender, EventArgs e)
        {
            LoadReservationData();
        }

        private void dt_all_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the column is one of the numeric columns
            if (dt_all.Columns[e.ColumnIndex].Name == "fld_Total")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("N0"); // Format as comma-separated with no decimal places
                    e.FormattingApplied = true;
                }

            }
        }
        //Fetches dat from database and binds it to the binding source
        //datagridvuew
        private void LoadReservationData()
        {
            try
            {
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT DISTINCT
                        r.fld_Control_number, 
                        r.fld_Reservation_Status,
                        r.fld_Total_Amount,
                        (SELECT TOP 1 v.fld_Venue_Name 
                         FROM tbl_Reservation_Venues rv 
                         JOIN tbl_Venue v ON rv.fk_VenueID = v.pk_VenueID 
                         WHERE rv.fk_ReservationID = r.pk_ReservationID) AS fld_Venue_Name,
                        rp.fld_First_Name,
                        rp.fld_Surname
                    FROM tbl_Reservation r
                    LEFT JOIN tbl_Requesting_Person rp 
                        ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    WHERE r.fld_Reservation_Type = 'Venue'";

                    var dataTable = new DataTable();
                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                    }

                    bindingSource.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //pag napindot, magpapkita muna tong mga to bago si LoadReservationDetails
        private void Dt_all_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dt_all.Rows[e.RowIndex];
                currentControlNumber = row.Cells["fld_Control_number"].Value?.ToString() ?? "";
                txt_CN.Text = currentControlNumber;
                txt_Status.Text = row.Cells["fld_Reservation_Status"].Value?.ToString() ?? "";

                // Format the Total Amount with commas
                if (decimal.TryParse(row.Cells["fld_Total_Amount"].Value?.ToString(), out decimal totalAmount))
                {
                    txt_Total.Text = totalAmount.ToString("N0"); // Format as comma-separated with no decimal places
                }
                else
                {
                    txt_Total.Text = "0"; // Default value if parsing fails
                }

                if (!string.IsNullOrEmpty(currentControlNumber))
                {
                    LoadReservationDetails(currentControlNumber);
                }

                btn_Update.Enabled = false;
                hasChanges = false;
            }
        }



        //display niya ito sa mga text boxes
        private void LoadReservationDetails(string controlNumber)
        {
            try
            {
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT TOP 1
                    r.fld_Reservation_Status AS Status,
                    rp.fld_First_Name AS FirstName, 
                    rp.fld_Surname AS LastName,
                    rp.fld_Requesting_Person_Address AS Address,
                    rp.fld_Requesting_Office AS Office,
                    r.fld_Activity_Name AS ActivityName,
                    rv.fld_Participants AS Participants,
                    v.fld_Venue_Name AS VenueName,
                    rv.fld_Start_Date AS StartDate,
                    rv.fld_End_Date AS EndDate,
                    rv.fld_Start_Time AS StartTime,
                    rv.fld_End_Time AS EndTime,
                    vs.fld_Venue_Scope_Name AS Scope,
                    vp.fld_Rate_Type AS RateType
                FROM tbl_Reservation r
                LEFT JOIN tbl_Requesting_Person rp 
                    ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                LEFT JOIN tbl_Reservation_Venues rv 
                    ON r.pk_ReservationID = rv.fk_ReservationID
                LEFT JOIN tbl_Venue v 
                    ON rv.fk_VenueID = v.pk_VenueID
                LEFT JOIN tbl_Venue_Scope vs 
                    ON rv.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
                LEFT JOIN tbl_Venue_Pricing vp 
                    ON (rv.fk_VenueID = vp.fk_VenueID AND rv.fk_Venue_ScopeID = vp.fk_Venue_ScopeID)
                WHERE r.fld_Control_number = @ControlNumber";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ControlNumber", controlNumber);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_FName.Text = reader["FirstName"]?.ToString() ?? "N/A";
                                txt_LName.Text = reader["LastName"]?.ToString() ?? "N/A";
                                txt_Address.Text = reader["Address"]?.ToString() ?? "N/A";
                                txt_Office.Text = reader["Office"]?.ToString() ?? "N/A";
                                txt_Activity.Text = reader["ActivityName"]?.ToString() ?? "N/A";
                                txt_Participants.Text = reader["Participants"]?.ToString() ?? "0";
                                txt_Venue.Text = reader["VenueName"]?.ToString() ?? "N/A";
                                txt_Scope.Text = reader["Scope"]?.ToString() ?? "N/A";
                                txt_Type.Text = reader["RateType"]?.ToString() ?? "N/A";

                                // Display date in MM/dd/yyyy format
                                txt_Date_Start.Text = reader["StartDate"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["StartDate"]).ToString("MM/dd/yyyy")
                                    : "N/A";
                                txt_Date_End.Text = reader["EndDate"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["EndDate"]).ToString("MM/dd/yyyy")
                                    : "N/A";

                                // Display time in 12-hour format with AM/PM
                                txt_Hour_Start.Text = reader["StartTime"] != DBNull.Value
                                    ? DateTime.Today.Add(TimeSpan.Parse(reader["StartTime"].ToString())).ToString("hh:mm tt")
                                    : "N/A";
                                txt_Hour_End.Text = reader["EndTime"] != DBNull.Value
                                    ? DateTime.Today.Add(TimeSpan.Parse(reader["EndTime"].ToString())).ToString("hh:mm tt")
                                    : "N/A";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Control_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentControlNumber))
            {
                hasChanges = true;
                btn_Update.Enabled = true;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentControlNumber))
            {
                MessageBox.Show("Please select a reservation first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();

                    // Update tbl_Reservation for the status
                    string reservationQuery = @"
                UPDATE tbl_Reservation 
                SET fld_Reservation_Status = @Status
                WHERE fld_Control_number = @ControlNumber";

                    using (var command = new SqlCommand(reservationQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Status", txt_Status.Text.Trim());
                        command.Parameters.AddWithValue("@ControlNumber", currentControlNumber);
                        command.ExecuteNonQuery();
                    }

                    // Update tbl_Requesting_Person for the first name, last name, and address
                    string personQuery = @"
                        UPDATE tbl_Requesting_Person
                        SET fld_First_Name = @FirstName,
                            fld_Surname = @LastName,
                            fld_Requesting_Person_Address = @Address
                        WHERE pk_Requesting_PersonID = 
                            (SELECT fk_Requesting_PersonID 
                             FROM tbl_Reservation 
                             WHERE fld_Control_number = @ControlNumber)";

                    using (var command = new SqlCommand(personQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", txt_FName.Text.Trim());
                        command.Parameters.AddWithValue("@LastName", txt_LName.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txt_Address.Text.Trim());
                        command.Parameters.AddWithValue("@ControlNumber", currentControlNumber);
                        command.ExecuteNonQuery();
                    }

                    // Display success message only once after both updates
                    MessageBox.Show("Reservation updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReservationData();
                    btn_Update.Enabled = false;
                    hasChanges = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating reservation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadReservationData();
            btn_Update.Enabled = false;
            hasChanges = false;
        }

        private void Combobox_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filter = combobox_Filter.SelectedItem.ToString();
            bindingSource.Filter = filter == "All" ? "" : $"fld_Reservation_Status = '{filter}'";
        }

        private void Txt_Search_TextChanged(object sender, EventArgs e)
        {
            var searchText = txt_Search.Text.Trim();
            bindingSource.Filter = string.IsNullOrEmpty(searchText) ? "" :
                $"fld_Control_number LIKE '%{searchText}%' OR " +
                $"fld_Venue_Name LIKE '%{searchText}%' OR " +
                $"fld_First_Name LIKE '%{searchText}%' OR " +
                $"fld_Surname LIKE '%{searchText}%'";
        }

        private void Dt_all_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.Value != null)
            {
                var columnName = dt_all.Columns[e.ColumnIndex].Name;
                if (columnName.Contains("Amount") && decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = amount.ToString("N2");
                    e.FormattingApplied = true;
                }
            }
        }

        // Empty event handlers
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void txt_Update_TextChanged(object sender, EventArgs e) { }

        private void dt_all_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_Scope_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Venue_TextChanged(object sender, EventArgs e)
        {

        }

        private void combo_Venue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel_Information_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}