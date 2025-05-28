using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using pgso_connect;

namespace pgso
{
    public partial class frm_ReservationDetails : Form
    {
        private DateTime selectedDate;

        public frm_ReservationDetails(DateTime date)
        {
            InitializeComponent();
            selectedDate = date;
            dt_equipment.RowPostPaint += dt_equipment_RowPostPaint;
            dt_venue.RowPostPaint += dt_venue_RowPostPaint;
            dt_venue.CellFormatting += dt_venue_CellFormatting;
            dt_equipment.CellFormatting += dt_equipment_CellFormatting;
            // Place this in your form's constructor after InitializeComponent();
            label_Reservation.Font = new Font("Consolas", 10); // or "Courier New"


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

        private void dt_equipment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dt_equipment.Columns.Contains("fld_Reservation_StatusE"))
            {
                var statusCell = dt_equipment.Rows[e.RowIndex].Cells["fld_Reservation_StatusE"];
                if (statusCell.Value != null)
                {
                    string status = statusCell.Value.ToString();
                    if (status == "Pending")
                    {
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(242, 239, 231);
                    }
                    else if (status == "Confirmed")
                    {
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(225, 235, 245);
                    }
                    else
                    {
                        dt_equipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
        private void frm_ReservationDetails_Load(object sender, EventArgs e)
        {
            lbl_Date.Text = selectedDate.ToShortDateString();
            LoadReservationDetails();
        }
        private void dt_venue_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int itemColIndex = dt_venue.Columns["Item"].Index;
            dt_venue.Rows[e.RowIndex].Cells[itemColIndex].Value = (e.RowIndex + 1).ToString();
        }
        private void dt_equipment_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int itemColIndex = dt_equipment.Columns["Items"].Index;
            dt_equipment.Rows[e.RowIndex].Cells[itemColIndex].Value = (e.RowIndex + 1).ToString();
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
                dt_equipment.DataSource = equipmentTable;

                // Logic
                // Logic
                // Logic
                bool hasVenue = venueTable.Rows.Count > 0;
                bool hasEquipment = equipmentTable.Rows.Count > 0;

                // Hide/show grids
                dt_venue.Visible = hasVenue;
                dt_equipment.Visible = hasEquipment;

                // Hide headers & borders when invisible
                dt_venue.ColumnHeadersVisible = hasVenue;
                dt_venue.BorderStyle = hasVenue ? BorderStyle.FixedSingle : BorderStyle.None;

                dt_equipment.ColumnHeadersVisible = hasEquipment;
                dt_equipment.BorderStyle = hasEquipment ? BorderStyle.FixedSingle : BorderStyle.None;

                // Panel logic
                panel_Information.Visible = hasVenue || hasEquipment;
                if (!panel_Information.Visible)
                {
                    label_Reservation.Text = "";
                    label_Des.Text = "";
                }

                if (hasVenue && hasEquipment)
                {
                    this.Size = new Size(1340, 526); // Both shown
                   lbl_Venue.Location = new Point(10, 33);         // <-- Set Y to 30
                    lbl_Equipment.Location = new Point(465, 33);   // <-- Set Y to 30
                    lbl_Venue.Visible = true;
                    lbl_Equipment.Visible = true;
                   /*
                    panel_Information.Location = new Point(1054, 46); // Move panel closer
                    panel_Information.Size = new Size(313, 400);    // Adjust width
                    dt_venue.Size = new Size(516, 400); // Adjust as needed
                    dt_equipment.Size = new Size(516, 400); // Adjust as needed
                    dt_equipment.Location = new Point(534, 46);
                    dt_venue.Location = new Point(12, 46);*/

                    // Do NOT set anchors here (keep default layout)
                }
                else if (hasVenue) // Venue only
                {
                    this.Size = new Size(962, 514); // Further reduced width
                    dt_venue.Location = new Point(12, 50);
                    dt_venue.Size = new Size(550, 400); // Adjust as needed
                    dt_venue.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lbl_Venue.Location = new Point(9, 30);
                    lbl_Venue.Visible = true;
                    lbl_Equipment.Visible = false;

                    dt_equipment.Visible = false;
                    panel_Information.Location = new Point(570, 50); // Move panel closer
                    panel_Information.Size = new Size(370, 400);    // Adjust width
                    panel_Information.Visible = true;

                   
                }
                else if (hasEquipment) // Equipment only
                {
                    this.Size = new Size(962, 514); // Further reduced width
                    dt_equipment.Location = new Point(12, 50);
                    dt_equipment.Size = new Size(550, 400); // Adjust as needed
                    dt_equipment.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lbl_Equipment.Location = new Point(9, 30);
                    lbl_Equipment.Visible = true;
                    lbl_Venue.Visible = false;

                    dt_venue.Visible = false;
                    panel_Information.Location = new Point(570, 50); // Move panel closer
                    panel_Information.Size = new Size(370, 400);    // Adjust width
                    panel_Information.Visible = true;

                }
                else
                {
                    this.Size = new Size(489, 417);
                    lbl_Venue.Visible = false;
                    lbl_Equipment.Visible = false;
                    MessageBox.Show("No reservations found for the selected date.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation details: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dt_venue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dt_venue.Rows[e.RowIndex];
            var controlNumber = row.Cells["Venue_Control"].Value?.ToString();

            label_Des.Text = "VENUE";
            label_Reservation.Text = string.IsNullOrEmpty(controlNumber)
                ? "No reservation selected."
                : DisplayReservationDetails(controlNumber);
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

                                // Inside DisplayReservationDetails, replace the return ... block with:
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

        private void dt_equipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dt_equipment.Rows[e.RowIndex];
            var controlNumber = row.Cells["frm_Control_NumberE"].Value?.ToString();

            label_Des.Text = "EQUIPMENT";
            label_Reservation.Text = string.IsNullOrEmpty(controlNumber)
                ? "No reservation selected."
                : DisplayEquipmentReservationDetails(controlNumber);


        }
        private string DisplayEquipmentReservationDetails(string controlNumber)
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
                    rp.fld_First_Name,
                    rp.fld_Middle_Name,
                    rp.fld_Surname,
                    rp.fld_Requesting_Office,
                    rp.fld_Contact_Number,
                    r.fld_Reservation_Type,
                    r.fld_Activity_Name,
                    r.fld_Total_Amount,
                    e.fld_Equipment_Name,
                    re.fld_Quantity,
                    re.fld_Equipment_Status,
                    re.fld_Start_Date_Eq,
                    re.fld_End_Date_Eq,
                    re.fld_Total_Equipment_Cost
                FROM tbl_Reservation r
                LEFT JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                LEFT JOIN tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
                LEFT JOIN tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                WHERE r.fld_Control_Number = @ControlNumber";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ControlNumber", controlNumber);
                        using (var reader = command.ExecuteReader())
                        {
                            string equipmentList = "";
                            string firstName = "", middleName = "", lastName = "", office = "", contact = "", type = "", purpose = "", dateOfUse = "";
                            decimal totalAmount = 0;
                            bool first = true;
                            string firstStartDate = null, firstEndDate = null;
                            bool multipleDates = false;

                            while (reader.Read())
                            {
                                if (first)
                                {
                                    firstName = reader["fld_First_Name"]?.ToString() ?? "";
                                    middleName = reader["fld_Middle_Name"]?.ToString() ?? "";
                                    lastName = reader["fld_Surname"]?.ToString() ?? "";
                                    office = reader["fld_Requesting_Office"]?.ToString() ?? "N/A";
                                    contact = reader["fld_Contact_Number"]?.ToString() ?? "N/A";
                                    type = reader["fld_Reservation_Type"]?.ToString() ?? "N/A";
                                    purpose = reader["fld_Activity_Name"]?.ToString() ?? "N/A";
                                    totalAmount = reader["fld_Total_Amount"] != DBNull.Value ? Convert.ToDecimal(reader["fld_Total_Amount"]) : 0;
                                    firstStartDate = reader["fld_Start_Date_Eq"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["fld_Start_Date_Eq"]).ToString("MM/dd/yyyy")
                                        : null;
                                    firstEndDate = reader["fld_End_Date_Eq"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["fld_End_Date_Eq"]).ToString("MM/dd/yyyy")
                                        : null;
                                    first = false;
                                }
                                else
                                {
                                    string thisStartDate = reader["fld_Start_Date_Eq"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["fld_Start_Date_Eq"]).ToString("MM/dd/yyyy")
                                        : null;
                                    string thisEndDate = reader["fld_End_Date_Eq"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["fld_End_Date_Eq"]).ToString("MM/dd/yyyy")
                                        : null;
                                    if (thisStartDate != firstStartDate || thisEndDate != firstEndDate)
                                        multipleDates = true;
                                }

                                string eqName = reader["fld_Equipment_Name"]?.ToString() ?? "N/A";
                                string qty = reader["fld_Quantity"]?.ToString() ?? "0";
                                string eqStatus = reader["fld_Equipment_Status"]?.ToString() ?? "N/A";
                                decimal eqPrice = reader["fld_Total_Equipment_Cost"] != DBNull.Value ? Convert.ToDecimal(reader["fld_Total_Equipment_Cost"]) : 0;

                                equipmentList += $"{eqName}:\n" +
                                                 $"    Qty: {qty}\n" +
                                                 $"    Status: {eqStatus}\n" +
                                                 $"    Price: ₱{eqPrice:N2}\n";
                            }

                            // Date of use
                            if (multipleDates)
                                dateOfUse = "Multiple";
                            else if (!string.IsNullOrEmpty(firstStartDate) && !string.IsNullOrEmpty(firstEndDate))
                                dateOfUse = firstStartDate == firstEndDate ? firstStartDate : $"{firstStartDate} - {firstEndDate}";
                            else
                                dateOfUse = "N/A";

                            int labelWidth = 18;
                            string FormatLine(string label, string value) => $"{label.ToUpper().PadRight(labelWidth)}: {value}";

                            string fullName = $"{firstName} {(!string.IsNullOrWhiteSpace(middleName) ? middleName + " " : "")}{lastName}".Trim();

                            if (!string.IsNullOrEmpty(fullName))
                            {
                                return
                                    FormatLine("Control Number", controlNumber) + "\n" +
                                    FormatLine("Name", fullName) + "\n" +
                                    FormatLine("Requesting Office", office) + "\n" +
                                    FormatLine("Contact", contact) + "\n" +
                                    FormatLine("Type", type) + "\n" +
                                    FormatLine("Date", dateOfUse) + "\n" +
                                    "EQUIPMENT:\n" + equipmentList.TrimEnd() + "\n" +
                                    FormatLine("Purpose", purpose) + "\n" +
                                    FormatLine("Total", $"₱{totalAmount:N2}");
                            }
                            else
                            {
                                return "Reservation details not found.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error loading details: {ex.Message}";
            }
        }

        private void createVenueResToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Create_Venuer_Reservation frmVenue = new frm_Create_Venuer_Reservation();
            frmVenue.ShowDialog();
        }

        private void createEquipmentResToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Create_Equipment_Reservation frm_Equipment = new frm_Create_Equipment_Reservation();
            frm_Equipment.ShowDialog();
        }

        private void panel_Information_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}