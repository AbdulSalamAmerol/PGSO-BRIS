using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pgso_connect;

namespace pgso
{
    public partial class frm_Calendar_Equipments : Form
    {
        int month, year;
        private Connection db = new Connection(); // Use the Connection class

        public frm_Calendar_Equipments()
        {
            InitializeComponent();
        }

        private void frm_Calendar_Equipments_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            displayDays();
        }

        private void displayDays()
        {
            String MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbl_Date.Text = MonthName + " " + year;

            // Get the first day of the month
            DateTime startofthemonth = new DateTime(year, month, 1);
            // Get the count of days of the month
            int days = DateTime.DaysInMonth(year, month);
            // Convert the start of the month to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            // Fetch reservations for the current month
            DataTable reservations = GetReservationsForMonth(year, month);

            // Clear previous controls
            tbale_Calendar.Controls.Clear();

            // Create blank user controls for days before the start of the month
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlDaysEquipment ucblank = new UserControlDaysEquipment();
                tbale_Calendar.Controls.Add(ucblank);
            }

            // Create user controls for each day of the month
            for (int i = 1; i <= days; i++)
            {
                UserControlDaysEquipment ucday = new UserControlDaysEquipment();
                ucday.days(i);

                // Find reservations for the current day
                DateTime currentDate = new DateTime(year, month, i);
                var equipmentReservations = reservations.AsEnumerable()
                    .Where(r => currentDate >= r.Field<DateTime>("fld_Start_Date") && currentDate <= r.Field<DateTime>("fld_End_Date") && r.Field<string>("fld_Reservation_Type") == "Equipment")
                    .Select(r => r.Field<string>("fld_Equipment_Name"))
                    .ToList();

                ucday.SetReservations(null, equipmentReservations); // Only pass equipment reservations
                tbale_Calendar.Controls.Add(ucday);
            }
        }

        // Decrement month
        private void btn_Previous_Click(object sender, EventArgs e)
        {

        }

        // Increment month
        private void btn_Next_Click(object sender, EventArgs e)
        {

        }

        private DataTable GetReservationsForMonth(int year, int month)
        {
            DataTable reservations = new DataTable();
            try
            {
                string query = @"
                SELECT
                    r.fld_Control_Number,
                    r.fld_Start_Date, 
                    r.fld_End_Date, 
                    r.fld_Reservation_Type,
                    r.fld_Activity_Name,
                    e.fld_Equipment_Name,   
                    rp.fld_First_Name,
                    rp.fld_Surname,
                    r.fld_Start_Time,
                    r.fld_End_Time
                FROM
                    tbl_Reservation r
                LEFT JOIN tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
                LEFT JOIN tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                LEFT JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                WHERE 
                    (YEAR(r.fld_Start_Date) = @Year AND MONTH(r.fld_Start_Date) = @Month)
                    OR (YEAR(r.fld_End_Date) = @Year AND MONTH(r.fld_End_Date) = @Month)";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Month", month);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(reservations);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching reservations: " + ex.Message, "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return reservations;
        }
        private void btn_Venues_Click(object sender, EventArgs e)
        {
            frm_Calendar_Venue frm_Calendar_Vanue = new frm_Calendar_Venue();
            frm_Calendar_Vanue.Show();
        }

        private void days_Container_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Previous_Click_1(object sender, EventArgs e)
        {
            // Decrement month to go to previous month
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            displayDays();
        }

        private void btn_Next_Click_1(object sender, EventArgs e)
        {
            // Increment month to go to next month
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            displayDays();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private DataTable GetReservationsForDay(DateTime date)
        {
            DataTable reservations = new DataTable();
            try
            {
                string query = @"
        SELECT r.fld_Control_Number, r.fld_Start_Date, r.fld_End_Date, 
               r.fld_Reservation_Type, r.fld_Activity_Name, e.fld_Equipment_Name, 
               rp.fld_First_Name, rp.fld_Surname, r.fld_Start_Time, r.fld_End_Time
        FROM tbl_Reservation r
        LEFT JOIN tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
        LEFT JOIN tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
        LEFT JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
        WHERE @Date BETWEEN r.fld_Start_Date AND r.fld_End_Date";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@Date", date);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(reservations);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching reservations: " + ex.Message, "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return reservations;
        }
    }
}
