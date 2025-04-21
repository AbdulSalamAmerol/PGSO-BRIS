using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using pgso_connect;

namespace pgso
{
    public partial class frm_ReservationDetails : Form
    {
        public frm_ReservationDetails()
        {
            InitializeComponent();
        }

        private void frm_ReservationDetails_Load(object sender, EventArgs e)
        {

        }


        public void SetReservationDetails(string controlNumber, string type)
        {
            string reservationDetails = GetReservationDetailsFromDatabase(controlNumber, type);
            lblReservationType.Text = $"Type: {type}";
            lblReservationDetails.Text = reservationDetails;
        }


        private string GetReservationDetailsFromDatabase(string controlNumber, string type)
        {
            string details = "No details found.";
            try
            {
                Connection db = new Connection();
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = type == "Venue"
                    ? @"SELECT
                v.fld_Venue_Name,
                vs.fld_Venue_Scope_Name,
                r.fld_Activity_Name,
                r.fld_Reservation_Status
               FROM tbl_Reservation r
               LEFT JOIN tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
               LEFT JOIN tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
               WHERE r.fld_Control_Number = @controlNumber"
                    : @"SELECT
                e.fld_Equipment_Name,
                r.fld_Activity_Name,
                r.fld_Reservation_Status
               FROM tbl_Reservation_Equipment re
               INNER JOIN tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
               INNER JOIN tbl_Reservation r ON re.fk_ReservationID = r.pk_ReservationID
               WHERE r.fld_Control_Number = @controlNumber";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@controlNumber", controlNumber);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            details = type == "Venue"
                                ? $"Control Number: {controlNumber}\n" + // Include control number
                                  $"Venue: {reader["fld_Venue_Name"]}\n" +
                                  $"Scope: {reader["fld_Venue_Scope_Name"]}\n" +
                                  $"Activity: {reader["fld_Activity_Name"]}\n" +
                                  $"Status: {reader["fld_Reservation_Status"]}"
                                : $"Control Number: {controlNumber}\n" + // Include control number
                                  $"Equipment: {reader["fld_Equipment_Name"]}\n" +
                                  $"Activity: {reader["fld_Activity_Name"]}\n" +
                                  $"Status: {reader["fld_Reservation_Status"]}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return details;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_ReservationDetails_Load_1(object sender, EventArgs e)
        {

        }
    }
}