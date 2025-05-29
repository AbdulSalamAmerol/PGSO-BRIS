using pgso_connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Venue_Edit : Form
    {
        private readonly Connection db = new Connection();
        private readonly BindingSource bindingSource = new BindingSource();
        private bool hasChanges = false;
        private string currentControlNumber = string.Empty;
        private DateTime selectedDate;

        // Main constructor with date parameter
        public frm_Venue_Edit(DateTime date)
        {
            InitializeComponent();

            // Validate and set the date
            if (date < new DateTime(1753, 1, 1) || date > new DateTime(9999, 12, 31))
                selectedDate = DateTime.Today;
            else
                selectedDate = date;

            InitializeControls();
            SetupEventHandlers();
            dt_all.RowPostPaint += dt_all_RowPostPaint;

            // Load data immediately
            LoadReservationData(selectedDate);
        }

        // Default constructor (if needed)
        public frm_Venue_Edit() : this(DateTime.Today) { }

        private void InitializeControls()
        {
            dt_all.AutoGenerateColumns = false;

            // Search box setup
            txt_Search.ForeColor = System.Drawing.Color.Gray;
            txt_Search.Text = "Control Number/Venue";
            txt_Search.GotFocus += Txt_Search_GotFocus;
            txt_Search.LostFocus += Txt_Search_LostFocus;

            // DataGridView setup
            dt_all.AutoGenerateColumns = false;
            dt_all.DataSource = bindingSource;

            // Filter combobox setup
            combobox_Filter.Items.AddRange(new[] { "All", "Pending", "Cancelled", "Confirmed" });
            combobox_Filter.SelectedIndex = 0;

            // Initial button state
            btn_Update.Enabled = false;
        }

        private void SetupEventHandlers()
        {
            // DataGridView events
            dt_all.CellClick += Dt_all_CellClick;
            dt_all.CellFormatting += Dt_all_CellFormatting;

            // Filter and search events
            combobox_Filter.SelectedIndexChanged += Combobox_Filter_SelectedIndexChanged;
            txt_Search.TextChanged += Txt_Search_TextChanged;

            // TextBox change events
            txt_FName.TextChanged += Control_ValueChanged;
            txt_LName.TextChanged += Control_ValueChanged;
            txt_Address.TextChanged += Control_ValueChanged;
            txt_Office.TextChanged += Control_ValueChanged;
            txt_Status.TextChanged += Control_ValueChanged;
            txt_Activity.TextChanged += Control_ValueChanged;
            txt_Participants.TextChanged += Control_ValueChanged;

            // Styling
            dt_all.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumAquamarine;
            dt_all.EnableHeadersVisualStyles = false;
            dt_all.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, System.Drawing.FontStyle.Bold);
        }

        private void LoadReservationData(DateTime date)
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
                        r.fld_Created_At,
                        r.fld_Total_Amount,
                        '₱' + CONVERT(VARCHAR, CAST(r.fld_Total_Amount AS MONEY), 1) AS fld_Total_Amount,
                        (SELECT TOP 1 v.fld_Venue_Name 
                         FROM tbl_Reservation_Venues rv 
                         JOIN tbl_Venue v ON rv.fk_VenueID = v.pk_VenueID 
                         WHERE rv.fk_ReservationID = r.pk_ReservationID) AS fld_Venue_Name,
                        rp.fld_First_Name,
                        rp.fld_Surname,
                        Date = STUFF((
                            SELECT CHAR(10) +
                                CASE
                                    WHEN rv2.fld_Start_Date = rv2.fld_End_Date THEN
                                        FORMAT(rv2.fld_Start_Date, 'MM/dd/yyyy')
                                    ELSE
                                        FORMAT(rv2.fld_Start_Date, 'MM/dd/yyyy') + ' - ' + FORMAT(rv2.fld_End_Date, 'MM/dd/yyyy')
                                END
                            FROM tbl_Reservation_Venues rv2
                            WHERE rv2.fk_ReservationID = r.pk_ReservationID
                            FOR XML PATH(''), TYPE
                        ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
                    FROM tbl_Reservation r
                    LEFT JOIN tbl_Requesting_Person rp 
                        ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    INNER JOIN tbl_Reservation_Venues rv ON r.pk_ReservationID = rv.fk_ReservationID
                    WHERE r.fld_Reservation_Type = 'Venue'
                      AND @SelectedDate BETWEEN rv.fld_Start_Date AND rv.fld_End_Date
                    ORDER BY r.fld_Created_At DESC";

                    var dataTable = new DataTable();
                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@SelectedDate", date.Date);
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

        private void Dt_all_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dt_all.Rows[e.RowIndex];
                currentControlNumber = row.Cells["fld_Control_number"].Value?.ToString() ?? "";
                txt_CN.Text = currentControlNumber;
                txt_Status.Text = row.Cells["fld_Reservation_Status"].Value?.ToString() ?? "";

                if (decimal.TryParse(row.Cells["fld_Total_Amount"].Value?.ToString(), out decimal totalAmount))
                {
                    txt_Total.Text = "₱" + totalAmount.ToString("N2");
                }
                else
                {
                    txt_Total.Text = "₱0.00";
                }

                if (!string.IsNullOrEmpty(currentControlNumber))
                {
                    LoadReservationDetails(currentControlNumber);
                }

                btn_Update.Enabled = false;
                hasChanges = false;
                UpdateTextBoxEditability();
            }
        }

        private void LoadReservationDetails(string controlNumber)
        {
            try
            {
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT 
                        r.fld_Reservation_Status AS Status,
                        rp.fld_First_Name AS FirstName, 
                        rp.fld_Surname AS LastName,
                        rp.fld_Requesting_Person_Address AS Address,
                        rp.fld_Requesting_Office AS Office,
                        r.fld_Activity_Name AS ActivityName,
                        rv.fld_Participants AS Participants,
                        v.fld_Venue_Name AS VenueName,
                        vs.fld_Venue_Scope_Name AS Scope,
                        vp.fld_Rate_Type AS RateType,
                        rv.fld_Start_Date AS StartDate,
                        rv.fld_End_Date AS EndDate,
                        rv.fld_Start_Time AS StartTime,
                        rv.fld_End_Time AS EndTime
                    FROM tbl_Reservation r
                    LEFT JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    LEFT JOIN tbl_Reservation_Venues rv ON r.pk_ReservationID = rv.fk_ReservationID
                    LEFT JOIN tbl_Venue v ON rv.fk_VenueID = v.pk_VenueID
                    LEFT JOIN tbl_Venue_Scope vs ON rv.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
                    LEFT JOIN tbl_Venue_Pricing vp ON (rv.fk_VenueID = vp.fk_VenueID AND rv.fk_Venue_ScopeID = vp.fk_Venue_ScopeID)
                    WHERE r.fld_Control_number = @ControlNumber";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ControlNumber", controlNumber);

                        using (var reader = command.ExecuteReader())
                        {
                            HashSet<string> formattedEntries = new HashSet<string>();

                            while (reader.Read())
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

                                string startDate = reader["StartDate"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["StartDate"]).ToString("MM/dd/yyyy")
                                    : null;

                                string startTime = reader["StartTime"] != DBNull.Value
                                    ? DateTime.Today.Add(TimeSpan.Parse(reader["StartTime"].ToString())).ToString("hh:mmtt")
                                    : null;

                                string endTime = reader["EndTime"] != DBNull.Value
                                    ? DateTime.Today.Add(TimeSpan.Parse(reader["EndTime"].ToString())).ToString("hh:mmtt")
                                    : null;

                                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                                {
                                    formattedEntries.Add($"{startTime} - {endTime} {startDate}");
                                }
                            }

                            txt_Date_Start.Text = formattedEntries.Count > 0
                                ? string.Join(Environment.NewLine, formattedEntries)
                                : "N/A";
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

        private void UpdateTextBoxEditability()
        {
            bool isPending = txt_Status.Text.Equals("Pending", StringComparison.OrdinalIgnoreCase);
            txt_FName.Enabled = isPending;
            txt_LName.Enabled = isPending;
            txt_Office.Enabled = isPending;
            txt_Address.Enabled = isPending;
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
            var result = MessageBox.Show(
                "Are you sure you want to update?",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

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

                    // Update reservation status
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

                    // Update requesting person details
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

                    MessageBox.Show("Reservation updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReservationData(selectedDate);
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
            LoadReservationData(selectedDate);
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
            // Format total amount columns
            if (dt_all.Columns[e.ColumnIndex].Name == "fld_Total_Amount" ||
                dt_all.Columns[e.ColumnIndex].Name == "fld_Total")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = "₱" + value.ToString("N2");
                    e.FormattingApplied = true;
                }
            }

            // Color rows based on status
            if (dt_all.Columns.Contains("fld_Reservation_Status"))
            {
                var statusCell = dt_all.Rows[e.RowIndex].Cells["fld_Reservation_Status"];
                if (statusCell.Value != null)
                {
                    string status = statusCell.Value.ToString();
                    if (status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
                    {
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 235, 245);
                    }
                    else if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(242, 239, 231);
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                    {
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 228, 225);
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
        }

        private void dt_all_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int itemColIndex = dt_all.Columns["Item"].Index;
            dt_all.Rows[e.RowIndex].Cells[itemColIndex].Value = (e.RowIndex + 1).ToString();
        }

        private void Txt_Search_GotFocus(object sender, EventArgs e)
        {
            if (txt_Search.Text == "Control Number/Venue")
            {
                txt_Search.Text = "";
                txt_Search.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void Txt_Search_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Search.Text))
            {
                txt_Search.Text = "Control Number/Venue";
                txt_Search.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void dt_all_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dt_all.Columns[e.ColumnIndex].Name == "fld_Total_Amount" ||
                dt_all.Columns[e.ColumnIndex].Name == "fld_Total")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = "₱" + value.ToString("N2");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btn_Update_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to update?",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return; // Cancel submission if user selects No
            }
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

                    // Optionally use a transaction
                    using (var transaction = connection.BeginTransaction())
                    {
                        // Update tbl_Reservation for the status
                        string reservationQuery = @"
                    UPDATE tbl_Reservation 
                    SET fld_Reservation_Status = @Status
                    WHERE fld_Control_number = @ControlNumber";

                        using (var command = new SqlCommand(reservationQuery, connection, transaction))
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

                        using (var command = new SqlCommand(personQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@FirstName", txt_FName.Text.Trim());
                            command.Parameters.AddWithValue("@LastName", txt_LName.Text.Trim());
                            command.Parameters.AddWithValue("@Address", txt_Address.Text.Trim());
                            command.Parameters.AddWithValue("@ControlNumber", currentControlNumber);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }

                    MessageBox.Show("Reservation updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReservationData(selectedDate); // <-- Corrected
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
    }
}