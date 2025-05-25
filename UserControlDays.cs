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

        public UserControlDays()
        {
            InitializeComponent();
            this.Click += UserControlDays_Click;
            lblDays.Click += UserControlDays_Click;
            lbl_Reservations.Click += UserControlDays_Click;

        }

        public void days(int numday, int month, int year)
        {
            lblDays.Text = numday.ToString();
            date = new DateTime(year, month, numday); // full date is stored here
            this.Date = date; //  Set the public property
            LoadReservationSummary();
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            if (!isClickable)
                return; // Ignore clicks if not clickable

            using (var detailsForm = new frm_ReservationDetails(this.Date))
            {
                detailsForm.ShowDialog();
            }

            //using (var createReservationForm = new frm_Create_Venuer_Reservation())
            //{
             //   createReservationForm.ShowDialog();
            //}
        }

        //count  the number of reservations
        private void LoadReservationSummary()
        {
            try
            {
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
            SELECT r.fld_Reservation_Status, COUNT(DISTINCT r.fld_Control_Number) AS TotalCount
            FROM tbl_Reservation r
            INNER JOIN tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
            WHERE @SelectedDate BETWEEN re.fld_Start_Date_Eq AND re.fld_End_Date_Eq
            AND r.fld_Reservation_Status IN ('Pending', 'Confirmed')
            AND r.fld_Reservation_Type IN ('Equipment', 'Both')
            GROUP BY r.fld_Reservation_Status";
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

                // Set clickability and update label
                bool hasReservations = (venuePending + venueConfirmed + equipmentPending + equipmentConfirmed) > 0;
                isClickable = hasReservations;
                this.BackColor = hasReservations ? Color.LightBlue : SystemColors.Control;

                // Updated display format
                lbl_Reservations.Text =
                    $"Venue: Pending: {venuePending} Confirmed: {venueConfirmed}\n" +
                    $"Equipment: Pending: {equipmentPending} Confirmed: {equipmentConfirmed}";
                lbl_Reservations.Visible = hasReservations;
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

        public void SetReservations(List<(string DisplayName, string ControlNumber, string Status)> venueReservations,
                         List<(string DisplayName, string ControlNumber, string Status)> equipmentReservations)
        {
            venueReservations = venueReservations ?? new List<(string, string, string)>();
            equipmentReservations = equipmentReservations ?? new List<(string, string, string)>();

            // Count pending/confirmed for each type
            var venuePending = venueReservations.Count(v => v.Status == "Pending");
            var venueConfirmed = venueReservations.Count(v => v.Status == "Confirmed");

            var equipmentPending = equipmentReservations.Count(e => e.Status == "Pending");
            var equipmentConfirmed = equipmentReservations.Count(e => e.Status == "Confirmed");

            bool hasVenueReservations = (venuePending + venueConfirmed) > 0;
            bool hasEquipmentReservations = (equipmentPending + equipmentConfirmed) > 0;
            isClickable = hasVenueReservations || hasEquipmentReservations;

            this.BackColor = isClickable ? Color.LightBlue : SystemColors.Control;

            // Build the display text conditionally
            var displayText = new StringBuilder();

            if (hasVenueReservations)
            {
                displayText.AppendLine($"Venue: Request: {venuePending}");
                displayText.Append($"          Approved: {venueConfirmed}");
            }

            if (hasEquipmentReservations)
            {
                // Add a newline only if we already have venue reservations
                if (hasVenueReservations)
                {
                    displayText.AppendLine(); // This adds the newline at the end of venue section
                }
                displayText.AppendLine($"Equipment: Request: {equipmentPending}");
                displayText.Append($"              Approved: {equipmentConfirmed}");
            }

            lbl_Reservations.Text = displayText.ToString();
            lbl_Reservations.Visible = isClickable;
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