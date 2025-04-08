using pgso_connect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Add_Scope : Form
    {
        private Connection db = new Connection();

        public frm_Add_Scope()
        {
            InitializeComponent();
            LoadVenues();
        }

        private void LoadVenues()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = "SELECT pk_VenueID, fld_Venue_Name FROM tbl_Venue";
                SqlCommand cmd = new SqlCommand(query, db.strCon);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                combo_Venue.DataSource = dt;
                combo_Venue.ValueMember = "pk_VenueID";
                combo_Venue.DisplayMember = "fld_Venue_Name";

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading venues: " + ex.Message);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            
        }

        private void tbn_Save_Click(object sender, EventArgs e)
        {
            if (combo_Venue.SelectedValue == null || string.IsNullOrEmpty(txt_Scope_Name.Text))
            {
                MessageBox.Show("Please select a venue and enter a scope name.");
                return;
            }

            int venueId = (int)combo_Venue.SelectedValue;
            string scopeName = txt_Scope_Name.Text;

            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = "INSERT INTO tbl_Venue_Scope (fk_VenueID, fld_Venue_Scope_Name) VALUES (@venueId, @scopeName)";
                SqlCommand cmd = new SqlCommand(query, db.strCon);
                cmd.Parameters.AddWithValue("@venueId", venueId);
                cmd.Parameters.AddWithValue("@scopeName", scopeName);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Scope added successfully!");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding scope: " + ex.Message);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }
    }
}
