using pgso_connect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Equipment_Res : Form
    {
        // Declare selectedDate as a private field
        private DateTime selectedDate;

        public frm_Equipment_Res()
        {
            InitializeComponent();
            selectedDate = DateTime.Today;
            dt_equipment.RowPostPaint += dt_equipment_RowPostPaint;
            dt_equipment.CellFormatting += dt_equipment_CellFormatting;
            label_Equipment.Font = new Font("Consolas", 10);
        }

        public frm_Equipment_Res(DateTime date)
        {
            InitializeComponent();
            selectedDate = date;
            dt_equipment.RowPostPaint += dt_equipment_RowPostPaint;
            dt_equipment.CellFormatting += dt_equipment_CellFormatting;
            label_Equipment.Font = new Font("Consolas", 10);
            LoadReservationDetails();
            

        }

        private void frm_Equipment_Res_Load(object sender, EventArgs e)
        {
            LoadReservationDetails();
        }

        private void LoadReservationDetails()
        {
            try
            {
                Connection db = new Connection();
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                // Load equipment reservations
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation details: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dt_equipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dt_equipment.Rows[e.RowIndex];
            var controlNumber = row.Cells["fld_Control_Number"].Value?.ToString();

            label_Des.Text = "EQUIPMENT";
            label_Equipment.Text = string.IsNullOrEmpty(controlNumber)
                ? "No reservation selected."
                : DisplayEquipmentReservationDetails(controlNumber);
        }

        private void dt_equipment_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int itemColIndex = dt_equipment.Columns["Items"].Index;
            dt_equipment.Rows[e.RowIndex].Cells[itemColIndex].Value = (e.RowIndex + 1).ToString();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dt_equipment_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dt_equipment.Rows[e.RowIndex];
            var controlNumber = row.Cells["frm_Control_NumberE"].Value?.ToString();

            label_Des.Text = "EQUIPMENT";
            label_Equipment.Text = string.IsNullOrEmpty(controlNumber)
                ? "No reservation selected."
                : DisplayEquipmentReservationDetails(controlNumber);

        }

        private void frm_Equipment_Res_Load_1(object sender, EventArgs e)
        {

        }
    }
}