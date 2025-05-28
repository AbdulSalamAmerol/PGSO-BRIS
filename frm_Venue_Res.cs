using pgso_connect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Venue_Res : Form
    {
        // Declare selectedDate as a private field
        private DateTime selectedDate;

        public frm_Venue_Res()
        {
            InitializeComponent();

            // Initialize selectedDate (change as needed, e.g., from a DateTimePicker)
            selectedDate = DateTime.Today;

            // Event handlers
            dt_venue.RowPostPaint += dt_venue_RowPostPaint;
            dt_venue.CellFormatting += dt_venue_CellFormatting;

            // Set font for reservation label
            label_Venue.Font = new Font("Consolas", 10); // or "Courier New"
           

        }

        private void frm_Venue_Res_Load(object sender, EventArgs e)
        {
            // Optionally call LoadReservationDetails() here if you want to load data on form load
             LoadReservationDetails();
        }
        public frm_Venue_Res(DateTime date)
        {
            InitializeComponent();
            selectedDate = date;
            dt_venue.RowPostPaint += dt_venue_RowPostPaint;
            dt_venue.CellFormatting += dt_venue_CellFormatting;
            label_Venue.Font = new Font("Consolas", 10);
            LoadReservationDetails(); // Load data for the selected date immediately
        }
        private void LoadReservationDetails()
        {
            try
            {
                Connection db = new Connection();
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                // Load venue reservations (no filtering)
                string venueQuery = @"
                    SELECT 
                        r.fld_Control_Number,
                        ISNULL(v.fld_Venue_Name, 'N/A') AS fld_Venue_Name,
                        ISNULL(vs.fld_Venue_Scope_Name, 'N/A') AS fld_Venue_Scope_Name,
                        r.fld_Reservation_Status
                    FROM tbl_Reservation r
                    INNER JOIN tbl_Reservation_Venues rv ON r.pk_ReservationID = rv.fk_ReservationID
                    LEFT JOIN tbl_Venue v ON rv.fk_VenueID = v.pk_VenueID
                    LEFT JOIN tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
                    WHERE 
                        @SelectedDate BETWEEN rv.fld_Start_Date AND rv.fld_End_Date
                        AND r.fld_Reservation_Type IN ('Venue', 'Both')
                        AND r.fld_Reservation_Status IN ('Pending', 'Confirmed')";

                SqlCommand venueCmd = new SqlCommand(venueQuery, db.strCon);
                venueCmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);

                SqlDataAdapter venueAdapter = new SqlDataAdapter(venueCmd);
                DataTable venueTable = new DataTable();
                venueAdapter.Fill(venueTable);
                dt_venue.DataSource = venueTable;

                // Load equipment reservations (no filtering)
                string equipmentQuery = @"
                    SELECT 
                        r.fld_Control_Number,
                        e.fld_Equipment_Name,
                        re.fld_Quantity,
                        re.fld_Equipment_Status
                    FROM tbl_Reservation r
                    INNER JOIN tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
                    INNER JOIN tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                    WHERE 
                        @SelectedDate BETWEEN re.fld_Start_Date_Eq AND re.fld_End_Date_Eq
                        AND r.fld_Reservation_Type IN ('Equipment', 'Both')
                        AND re.fld_Equipment_Status IN ('Pending', 'Confirmed')";

                SqlCommand equipmentCmd = new SqlCommand(equipmentQuery, db.strCon);
                equipmentCmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);

                SqlDataAdapter equipmentAdapter = new SqlDataAdapter(equipmentCmd);
                DataTable equipmentTable = new DataTable();
                equipmentAdapter.Fill(equipmentTable);
                // dt_equipment.DataSource = equipmentTable; // Uncomment if you have a dt_equipment DataGridView

                // You can use hasVenue and hasEquipment as needed
                bool hasVenue = venueTable.Rows.Count > 0;
                bool hasEquipment = equipmentTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation details: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dt_venue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dt_venue.Rows[e.RowIndex];
            var controlNumber = row.Cells["fld_Control_Number"].Value?.ToString();

            label_Des.Text = "VENUE";
            label_Venue.Text = string.IsNullOrEmpty(controlNumber)
                ? "No reservation selected."
                : DisplayReservationDetails(controlNumber);
        }

        private void dt_venue_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Only set the "Item" column if it exists
            if (dt_venue.Columns.Contains("Item"))
            {
                int itemColIndex = dt_venue.Columns["Item"].Index;
                dt_venue.Rows[e.RowIndex].Cells[itemColIndex].Value = (e.RowIndex + 1).ToString();
            }
        }

        private string DisplayReservationDetails(string controlNumber)
        {
            try
            {
                Connection db = new Connection();
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    r.fld_Control_Number,
                    rp.fld_First_Name + ' ' + rp.fld_Surname AS Name,
                    rp.fld_Requesting_Office,
                    rp.fld_Requesting_Person_Address,
                    v.fld_Venue_Name,
                    vs.fld_Venue_Scope_Name,
                    vp.fld_Rate_Type,
                    r.fld_Activity_Name,
                    rv.fld_Start_Date,
                    rv.fld_End_Date,
                    rv.fld_Start_Time,
                    rv.fld_End_Time,
                    rv.fld_Participants,
                    r.fld_Reservation_Status,
                    r.fld_Total_Amount
                FROM tbl_Reservation r
                LEFT JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                LEFT JOIN tbl_Reservation_Venues rv ON r.pk_ReservationID = rv.fk_ReservationID
                LEFT JOIN tbl_Venue v ON rv.fk_VenueID = v.pk_VenueID
                LEFT JOIN tbl_Venue_Scope vs ON rv.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
                LEFT JOIN tbl_Venue_Pricing vp ON (rv.fk_VenueID = vp.fk_VenueID AND rv.fk_Venue_ScopeID = vp.fk_Venue_ScopeID)
                WHERE r.fld_Control_Number = @ControlNumber";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ControlNumber", controlNumber);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string date = "";
                                if (reader["fld_Start_Date"] != DBNull.Value && reader["fld_End_Date"] != DBNull.Value)
                                {
                                    var startDate = Convert.ToDateTime(reader["fld_Start_Date"]).ToString("MM/dd/yyyy");
                                    var endDate = Convert.ToDateTime(reader["fld_End_Date"]).ToString("MM/dd/yyyy");
                                    date = startDate == endDate ? startDate : $"{startDate} - {endDate}";
                                }

                                string hourOfUse = "";
                                if (reader["fld_Start_Time"] != DBNull.Value && reader["fld_End_Time"] != DBNull.Value)
                                {
                                    var startTime = TimeSpan.Parse(reader["fld_Start_Time"].ToString());
                                    var endTime = TimeSpan.Parse(reader["fld_End_Time"].ToString());
                                    hourOfUse = $"{DateTime.Today.Add(startTime):hh:mm tt} - {DateTime.Today.Add(endTime):hh:mm tt}";
                                }

                                decimal totalAmount = reader["fld_Total_Amount"] != DBNull.Value
                                    ? Convert.ToDecimal(reader["fld_Total_Amount"])
                                    : 0;

                                int labelWidth = 18; // Adjust as needed for your longest label

                                string FormatLine(string label, string value)
                                {
                                    return $"{label.ToUpper().PadRight(labelWidth)}: {value}";
                                }

                                return
                                    FormatLine("Control Number", reader["fld_Control_Number"]?.ToString() ?? "N/A") + "\n" +
                                    FormatLine("Name", reader["Name"]?.ToString() ?? "N/A") + "\n" +
                                    FormatLine("Requesting Office", reader["fld_Requesting_Office"]?.ToString() ?? "N/A") + "\n" +
                                    FormatLine("Address", reader["fld_Requesting_Person_Address"]?.ToString() ?? "N/A") + "\n" +
                                    FormatLine("Venue", reader["fld_Venue_Name"]?.ToString() ?? "N/A") + "\n" +
                                    FormatLine("Venue Scope", reader["fld_Venue_Scope_Name"]?.ToString() ?? "N/A") + "\n" +
                                    FormatLine("Type", reader["fld_Rate_Type"]?.ToString() ?? "N/A") + "\n" +
                                    FormatLine("Activity", reader["fld_Activity_Name"]?.ToString() ?? "N/A") + "\n" +
                                    FormatLine("Date", date) + "\n" +
                                    FormatLine("Hour of Use", hourOfUse) + "\n" +
                                    FormatLine("Participants", reader["fld_Participants"]?.ToString() ?? "0") + "\n" +
                                    FormatLine("Status", reader["fld_Reservation_Status"]?.ToString() ?? "N/A") + "\n" +
                                    FormatLine("Total", $"₱{totalAmount:N2}");
                            }
                            return "Reservation details not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Consider logging the full exception here
                return $"Error loading details: {ex.Message}";
            }
        }

        private void dt_venue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dt_venue.Columns.Contains("fld_Reservation_Status"))
            {
                var statusCell = dt_venue.Rows[e.RowIndex].Cells["fld_Reservation_Status"];
                if (statusCell.Value != null)
                {
                    string status = statusCell.Value.ToString();
                    if (status == "Pending")
                    {
                        dt_venue.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(242, 239, 231);
                    }
                    else if (status == "Confirmed")
                    {
                        dt_venue.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(225, 235, 245);
                    }
                    else
                    {
                        dt_venue.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        private void dt_venue_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dt_venue.Rows[e.RowIndex];
            var controlNumber = row.Cells["Venue_Control"].Value?.ToString();

            label_Des.Text = "VENUE";
            label_Venue.Text = string.IsNullOrEmpty(controlNumber)
                ? "No reservation selected."
                : DisplayReservationDetails(controlNumber);
        }
    }
}