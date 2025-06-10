
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using pgso_connect;

namespace pgso
{
    public partial class frm_Calendar : Form
    {
       // private Timer refreshTimer;
        int month, year;
        private Connection db = new Connection();

        public frm_Calendar()
        {
            InitializeComponent();
        }

        private void frm_Calendar_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            displayDays();
            // Add this for auto-refresh
           /* refreshTimer = new Timer();
            refreshTimer.Interval = 10000; // 10 seconds, adjust as needed
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();*/
        }
        /*private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Optionally, you can check if data has changed before refreshing
            RefreshCalendar();
        }*/
        private void displayDays()
        {
            String MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbl_Date.Text = MonthName + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            DataTable reservations = GetReservationsForMonth(year, month);

            tbale_Calendars.Controls.Clear();

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlDaysEquipment ucblank = new UserControlDaysEquipment();
                tbale_Calendars.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucday = new UserControlDays();
                ucday.days(i, month, year);

                DateTime currentDate = new DateTime(year, month, i);

                // Filter reservations for the current date
                // Filter reservations for the current date
                var venueReservations = reservations.AsEnumerable()
                    .Where(r =>
                        r.Field<DateTime?>("Venue_Start_Date") != null &&
                        r.Field<DateTime?>("Venue_End_Date") != null &&
                        currentDate.Date >= r.Field<DateTime>("Venue_Start_Date").Date &&
                        currentDate.Date <= r.Field<DateTime>("Venue_End_Date").Date &&
                        (r.Field<string>("fld_Reservation_Type") == "Venue" ||
                         r.Field<string>("fld_Reservation_Type") == "Both"))
                    .Select(r => (
                        DisplayName: r.Field<string>("fld_Venue_Name") ?? "Venue Reservation",
                        ControlNumber: r.Field<string>("fld_Control_Number"),
                        Status: r.Field<string>("fld_Reservation_Status")))
                    .Distinct()
                    .ToList();

                var equipmentReservations = reservations.AsEnumerable()
    .Where(r =>
        r.Field<DateTime?>("fld_Start_Date_Eq") != null &&
        r.Field<DateTime?>("fld_End_Date_Eq") != null &&
        currentDate.Date >= r.Field<DateTime>("fld_Start_Date_Eq").Date &&
        currentDate.Date <= r.Field<DateTime>("fld_End_Date_Eq").Date &&
        (r.Field<string>("fld_Reservation_Type") == "Equipment" ||
         r.Field<string>("fld_Reservation_Type") == "Both"))
    .Select(r => (
        DisplayName: r.Field<string>("fld_Equipment_Name") ?? "Equipment Reservation",
        ControlNumber: r.Field<string>("fld_Control_Number"),
        Status: r.Field<string>("fld_Reservation_Status")))
    .Distinct()
    .ToList();

                ucday.SetReservations(venueReservations, equipmentReservations);



                ucday.SetReservations(venueReservations, equipmentReservations);
                tbale_Calendars.Controls.Add(ucday);
            }


        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            displayDays();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            displayDays();
        }

        private DataTable GetReservationsForMonth(int year, int month)
        {
            DataTable reservations = new DataTable();
            string query = @"
        SELECT 
            r.fld_Control_Number,
            r.fld_Reservation_Type,
            r.fld_Reservation_Status,
            r.fld_Start_Date AS Venue_Start_Date,
            r.fld_End_Date AS Venue_End_Date,
            v.fld_Venue_Name,
            re.fld_Start_Date_Eq,
            re.fld_End_Date_Eq,
            re.fld_Equipment_Status,
            e.fld_Equipment_Name
        FROM tbl_Reservation r
        LEFT JOIN tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
        LEFT JOIN tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
        LEFT JOIN tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
        WHERE 
            (
                (YEAR(r.fld_Start_Date) = @Year AND MONTH(r.fld_Start_Date) = @Month)
                OR
                (YEAR(r.fld_End_Date) = @Year AND MONTH(r.fld_End_Date) = @Month)
            )
            OR
            (
                (YEAR(re.fld_Start_Date_Eq) = @Year AND MONTH(re.fld_Start_Date_Eq) = @Month)
                OR
                (YEAR(re.fld_End_Date_Eq) = @Year AND MONTH(re.fld_End_Date_Eq) = @Month)
            )
            AND (
                (re.fld_Equipment_Status IS NULL)
                OR
                (re.fld_Equipment_Status IN ('Confirmed', 'Pending'))
            )";

            try
            {
                var db = new Connection();
                using (var conn = db.strCon)
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Month", month);

                    conn.Open();
                    using (var da = new SqlDataAdapter(cmd))
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


        public void RefreshCalendar()
        {
            tbale_Calendars.Controls.Clear();
            displayDays();
            tbale_Calendars.PerformLayout();
            this.Refresh();
        }

        private void btn_Equipments_Click(object sender, EventArgs e)
        {
            frm_Calendar_Equipments frm_Calendar_Equipments = new frm_Calendar_Equipments();
            frm_Calendar_Equipments.Show();
        }
        private void RefreshCalendarView()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frm_Calendar calendarForm)
                {
                    if (calendarForm.InvokeRequired)
                    {
                        calendarForm.Invoke(new Action(() =>
                        {
                            calendarForm.RefreshCalendar();
                            calendarForm.BringToFront();
                        }));
                    }
                    else
                    {
                        calendarForm.RefreshCalendar();
                        calendarForm.BringToFront();
                    }
                }
            }
        }
    }
}