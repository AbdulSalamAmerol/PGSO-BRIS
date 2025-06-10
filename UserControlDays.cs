using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pgso_connect;

namespace pgso
{
    public partial class UserControlDays : UserControl
    {
        public event EventHandler<DateClickedEventArgs> DateClicked;
        private DateTime date;
        public DateTime Date { get; set; }
        private bool isClickable = false; // Track if the day is clickable
        private bool hasReservations = false;

        public UserControlDays()
        {

            InitializeComponent();

            // Remove previous click handlers
            this.Click -= UserControlDays_Click;
            lblDays.Click -= UserControlDays_Click;
            lbl_Reservations.Click -= UserControlDays_Click;

            // Add new click handlers
            lbl_Reservations.Click += lbl_Reservations_Click;
            lbl_Equipment.Click += Lbl_Equipment_Click;
            this.Click += UserControlDays_Click;


            lbl_Reservations.MouseEnter += (s, e) => lbl_Reservations.BackColor = Color.LightGray;
            lbl_Reservations.MouseLeave += (s, e) => lbl_Reservations.BackColor = Color.Transparent;

            lbl_Equipment.MouseEnter += (s, e) => lbl_Equipment.BackColor = Color.LightGray;
            lbl_Equipment.MouseLeave += (s, e) => lbl_Equipment.BackColor = Color.Transparent;
        }

        public void days(int numday, int month, int year)
        {
            lblDays.Text = numday.ToString();
            date = new DateTime(year, month, numday);
            this.Date = date;
            LoadReservationSummary();
        }

        private void lbl_Reservations_Click(object sender, EventArgs e)
        {
            if (lbl_Reservations.Visible)
            {
                using (var editForm = new frm_Venue_Edit(this.Date))
                {
                    editForm.ShowDialog();
                }
            }
        }

        private void Lbl_Equipment_Click(object sender, EventArgs e)
        {
            if (lbl_Equipment.Visible)
            {
                using (var equipmentForm = new frm_Equipment_Edit(this.Date))
                {
                    equipmentForm.ShowDialog();
                }
            }
        }



        private void UserControlDays_Click(object sender, EventArgs e)
        {
            if (!hasReservations)
            {
                using (var calendarForm = new frm_Res_Calendar())
                {
                    calendarForm.ShowDialog();
                }
            }
            else
            {
                using (var calendarForm = new frm_Res_Calendar())
                {
                    calendarForm.ShowDialog();
                }
            }
        }




        //count  the number of reservations
        private void LoadReservationSummary()
        {
            try
            {
                lbl_Equipment.Text = string.Empty;
                lbl_Equipment.Visible = false;

                Connection db = new Connection();
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                // Venue counts
                int venuePending = 0, venueConfirmed = 0;
                string venueQuery = @"
                SELECT r.fld_Reservation_Status, COUNT(DISTINCT r.fld_Control_Number) AS TotalCount
                FROM tbl_Reservation r
                LEFT JOIN tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
                WHERE @SelectedDate BETWEEN r.fld_Start_Date AND r.fld_End_Date
                AND r.fld_Reservation_Status IN ('Pending', 'Confirmed')
                AND r.fld_Reservation_Type IN ('Venue', 'Both')
                GROUP BY r.fld_Reservation_Status";
                using (SqlCommand venueCmd = new SqlCommand(venueQuery, db.strCon))
                {
                    venueCmd.Parameters.AddWithValue("@SelectedDate", date);
                    using (var reader = venueCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader["fld_Reservation_Status"].ToString();
                            int count = Convert.ToInt32(reader["TotalCount"]);
                            if (status == "Pending") venuePending = count;
                            else if (status == "Confirmed") venueConfirmed = count;
                        }
                    }
                }

                // Equipment counts
                int equipmentPending = 0, equipmentConfirmed = 0;
                string equipmentQuery = @"
                SELECT fld_Reservation_Status, COUNT(*) AS TotalCount
                FROM tbl_Reservation
                WHERE fld_Reservation_Status IN ('Pending', 'Confirmed')
                  AND fld_Reservation_Type IN ('Equipment', 'Both')
                  AND @SelectedDate BETWEEN fld_Start_Date AND fld_End_Date
                GROUP BY fld_Reservation_Status";
                using (SqlCommand equipmentCmd = new SqlCommand(equipmentQuery, db.strCon))
                {
                    equipmentCmd.Parameters.AddWithValue("@SelectedDate", date);
                    using (var reader = equipmentCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader["fld_Reservation_Status"].ToString();
                            int count = Convert.ToInt32(reader["TotalCount"]);
                            if (status == "Pending") equipmentPending = count;
                            else if (status == "Confirmed") equipmentConfirmed = count;
                        }
                    }
                }

                hasReservations = (venuePending + venueConfirmed + equipmentPending + equipmentConfirmed) > 0;
                this.BackColor = hasReservations ? Color.LightBlue : SystemColors.Control;

                // Update labels
                lbl_Reservations.Text = $"Venue:\n\tPending: {venuePending}\n\tConfirmed: {venueConfirmed}\n";
                lbl_Equipment.Text = $"\nEquipment:\n\tPending: {equipmentPending}\n\tConfirmed: {equipmentConfirmed}";

                lbl_Reservations.Visible = (venuePending + venueConfirmed) > 0;
                lbl_Equipment.Visible = (equipmentPending + equipmentConfirmed) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation summary: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }









        public void ClearReservations()
        {

            lbl_Reservations.Text = string.Empty;
            this.BackColor = SystemColors.Control;
        }

        public void SetReservations(
    List<(string DisplayName, string ControlNumber, string Status)> venueReservations,
    List<(string DisplayName, string ControlNumber, string Status)> equipmentReservations)
        {
            venueReservations = venueReservations ?? new List<(string, string, string)>();
            equipmentReservations = equipmentReservations ?? new List<(string, string, string)>();

            // Venue counts
            var venuePending = venueReservations.Count(v => v.Status == "Pending");
            var venueConfirmed = venueReservations.Count(v => v.Status == "Confirmed");
            bool hasVenueReservations = (venuePending + venueConfirmed) > 0;

            // Equipment counts
            var equipmentPending = equipmentReservations.Count(e => e.Status == "Pending");
            var equipmentConfirmed = equipmentReservations.Count(e => e.Status == "Confirmed");
            bool hasEquipmentReservations = (equipmentPending + equipmentConfirmed) > 0;
            // Set label text and visibility
            lbl_Reservations.Text = $"Venue: Pending: {venuePending}\nConfirmed: {venueConfirmed}";
            lbl_Reservations.Visible = hasVenueReservations;

            lbl_Equipment.Text = $"Equipment: Pending: {equipmentPending}\nConfirmed: {equipmentConfirmed}";
            lbl_Equipment.Visible = hasEquipmentReservations;
            // Set background color
            isClickable = hasVenueReservations || hasEquipmentReservations;
            this.BackColor = isClickable ? Color.LightBlue : SystemColors.Control;
        }















        private void ShowReservationDetails(string controlNumber, string type)
        {
            using (var detailsForm = new frm_ReservationDetails(date))
            {
                var parentForm = this.FindForm();
                if (parentForm != null)
                {
                    detailsForm.Owner = parentForm;
                }
                detailsForm.ShowDialog();
            }
        }


        private void UserControlDays_Load(object sender, EventArgs e)
        {
            // Initialization code if needed
        }

        private void lbl_Reservations_Click_1(object sender, EventArgs e)
        {

        }
    }

    public class DateClickedEventArgs : EventArgs
    {
        public DateTime SelectedDate { get; }

        public DateClickedEventArgs(DateTime selectedDate)
        {
            SelectedDate = selectedDate;
        }
    }
}