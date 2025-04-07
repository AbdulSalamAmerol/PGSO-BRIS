using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pgso_connect;

namespace pgso
{
    public partial class frm_Calendar : Form
    {
        int month, year;
        private Connection db = new Connection(); // Use the Connection class

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
            days_Container.Controls.Clear();

            // Create blank user controls for days before the start of the month
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                days_Container.Controls.Add(ucblank);
            }

            // Create user controls for each day of the month
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucday = new UserControlDays();
                ucday.days(i);
                ucday.DateClicked += Ucday_DateClicked;

                // Find reservations for the current day
                DateTime currentDate = new DateTime(year, month, i);
                var venueReservations = reservations.AsEnumerable()
                    .Where(r => currentDate >= r.Field<DateTime>("fld_Start_Date") && currentDate <= r.Field<DateTime>("fld_End_Date") && r.Field<string>("fld_Reservation_Type") == "Venue")
                    .Select(r => r.Field<string>("fld_Venue_Name"))
                    .ToList();

                var equipmentReservations = reservations.AsEnumerable()
                    .Where(r => currentDate >= r.Field<DateTime>("fld_Start_Date") && currentDate <= r.Field<DateTime>("fld_End_Date") && r.Field<string>("fld_Reservation_Type") == "Equipment")
                    .Select(r => r.Field<string>("fld_Equipment_Name"))
                    .ToList();

                ucday.SetReservations(venueReservations, equipmentReservations);
                days_Container.Controls.Add(ucday);
            }
        }

        // Display the Reservation Information in the Panel
        private void Ucday_DateClicked(object sender, DateClickedEventArgs e)
        {
            int day = int.Parse(e.Day);
            DateTime selectedDate = new DateTime(year, month, day);
            DataTable reservations = GetReservationsForDay(selectedDate);

            if (reservations.Rows.Count > 0)
            {
                panel_Info.Visible = true;

                var venueReservations = reservations.AsEnumerable()
                    .Where(r => r.Field<string>("fld_Reservation_Type") == "Venue")
                    .Select(r => new
                    {
                        Name = r.Field<string>("fld_Venue_Name"),
                        RequestingPerson = r.Field<string>("fld_First_Name") + " " + r.Field<string>("fld_Surname"),
                        StartTime = r.Field<TimeSpan>("fld_Start_Time"),
                        EndTime = r.Field<TimeSpan>("fld_End_Time"),
                        Activity = r.Field<string>("fld_Activity_Name")
                    })
                    .ToList();

                var equipmentReservations = reservations.AsEnumerable()
                    .Where(r => r.Field<string>("fld_Reservation_Type") == "Equipment")
                    .Select(r => new
                    {
                        Name = r.Field<string>("fld_Equipment_Name"),
                        RequestingPerson = r.Field<string>("fld_First_Name") + " " + r.Field<string>("fld_Surname"),
                        StartTime = r.Field<TimeSpan>("fld_Start_Time"),
                        EndTime = r.Field<TimeSpan>("fld_End_Time"),
                        Activity = r.Field<string>("fld_Activity_Name")
                    })
                    .ToList();

                if (venueReservations.Any())
                {
                    lbl_Venue.Text = string.Join("\n", venueReservations.Select(v => v.Name));
                    lbl_Requestor1.Text = string.Join("\n", venueReservations.Select(v => v.RequestingPerson));
                    lbl_Date_And_Time.Text = string.Join("\n", venueReservations.Select(v => $"{v.StartTime} - {v.EndTime}"));
                    lbl_Activity.Text = string.Join("\n", venueReservations.Select(v => v.Activity));
                }
                else
                {
                    lbl_Venue.Text = "No Reservation Yet";
                    lbl_Requestor1.Text = "No Reservation Yet";
                    lbl_Date_And_Time.Text = "No Reservation Yet";
                    lbl_Activity.Text = "No Reservation Yet";
                }

                if (equipmentReservations.Any())
                {
                    lbl_Equipment.Text = string.Join("\n", equipmentReservations.Select(E => E.Name));
                    lbl_Requestor2.Text = string.Join("\n", equipmentReservations.Select(E => E.RequestingPerson));
                    lbl_Date_And_Time2.Text = string.Join("\n", equipmentReservations.Select(E => $"{E.StartTime} - {E.EndTime}"));
                    lbl_Activity1.Text = string.Join("\n", equipmentReservations.Select(E => E.Activity));
                }
                else
                {
                    lbl_Equipment.Text = "No Reservation Yet";
                    lbl_Requestor2.Text = "No Reservation Yet";
                    lbl_Date_And_Time2.Text = "No Reservation Yet";
                    lbl_Activity1.Text = "No Reservation Yet";
                }
            }
            else
            {
                panel_Info.Visible = true;
                lbl_Venue.Text = "No Reservation Yet";
                lbl_Requestor1.Text = "No Reservation Yet";
                lbl_Date_And_Time.Text = "No Reservation Yet";
                lbl_Activity.Text = "No Reservation Yet";
                lbl_Equipment.Text = "No Reservation Yet";
                lbl_Requestor2.Text = "No Reservation Yet";
                lbl_Date_And_Time2.Text = "No Reservation Yet";
                lbl_Activity1.Text = "No Reservation Yet";
            }
        }

        // Decrement month
        private void btn_Previous_Click(object sender, EventArgs e)
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

        // Increment month
        private void btn_Next_Click(object sender, EventArgs e)
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

        private DataTable GetReservationsForMonth(int year, int month)
        {
            DataTable reservations = new DataTable();
            try
            {
                string query = @"
        SELECT r.fld_Control_Number, v.fld_Venue_Name, r.fld_Start_Date, r.fld_End_Date, 
               r.fld_Reservation_Type, r.fld_Activity_Name, e.fld_Equipment_Name, 
               rp.fld_First_Name, rp.fld_Surname, r.fld_Start_Time, r.fld_End_Time
        FROM tbl_Reservation r
        LEFT JOIN tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
        LEFT JOIN tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
        LEFT JOIN tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
        LEFT JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
        WHERE (YEAR(r.fld_Start_Date) = @Year AND MONTH(r.fld_Start_Date) = @Month)
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

        private DataTable GetReservationsForDay(DateTime date)
        {
            DataTable reservations = new DataTable();
            try
            {
                string query = @"
        SELECT r.fld_Control_Number, v.fld_Venue_Name, r.fld_Start_Date, r.fld_End_Date, 
               r.fld_Reservation_Type, r.fld_Activity_Name, e.fld_Equipment_Name, 
               rp.fld_First_Name, rp.fld_Surname, r.fld_Start_Time, r.fld_End_Time
        FROM tbl_Reservation r
        LEFT JOIN tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
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
