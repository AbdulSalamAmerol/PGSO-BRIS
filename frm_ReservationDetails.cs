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

                if (hasVenue && hasEquipment)
                {
                    this.Size = new Size(946, 400); // Both shown
                    dt_venue.Location = new Point(12, 50);
                    dt_equipment.Location = new Point(480, 50);
                    lbl_Venue.Location = new Point(9, 30);         // <-- Set Y to 30
                    lbl_Equipment.Location = new Point(480, 30);   // <-- Set Y to 30
                    lbl_Venue.Visible = true;
                    lbl_Equipment.Visible = true;
                }

                else if (hasVenue) // Venue only
                {
                    this.Size = new Size(489, 380);
                    dt_venue.Location = new Point((this.ClientSize.Width - dt_venue.Width) / 2, 50);
                    button1.Location = new Point(385, 340);
                    lbl_Venue.Location = new Point((this.ClientSize.Width - lbl_Venue.Width) / 2, 25);
                    lbl_Venue.Visible = true;
                    lbl_Equipment.Visible = false;
                }
                else if (hasEquipment) // Equipment only
                {
                    button1.Location = new Point(385, 340);
                    this.Size = new Size(489, 380);
                    dt_equipment.Location = new Point((this.ClientSize.Width - dt_equipment.Width) / 2, 50);
                    lbl_Equipment.Location = new Point((this.ClientSize.Width - lbl_Equipment.Width) / 2, 25);
                    lbl_Venue.Visible = false;
                    lbl_Equipment.Visible = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dt_venue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dt_equipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}