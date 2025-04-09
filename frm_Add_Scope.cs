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
            LoadRateTypes();
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

        private void LoadRateTypes()
        {
            combo_Rate_Type.Items.Add("Regular");
            combo_Rate_Type.Items.Add("Special");
            combo_Rate_Type.Items.Add("PGNV");
            combo_Rate_Type.SelectedIndex = 0; // Default to "Regular"
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
           
        }

        private void tbn_Save_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (combo_Venue.SelectedValue == null || string.IsNullOrEmpty(txt_Scope_Name.Text))
            {
                MessageBox.Show("Please select a venue and enter a scope name.");
                return;
            }

            if (!decimal.TryParse(txt_First4Hrs_Rate.Text, out decimal first4HrsRate) || first4HrsRate < 0)
            {
                MessageBox.Show("Please enter a valid first 4 hours rate.");
                return;
            }

            if (!decimal.TryParse(txt_Hourly_Rate.Text, out decimal hourlyRate) || hourlyRate < 0)
            {
                MessageBox.Show("Please enter a valid hourly rate.");
                return;
            }

            if (!decimal.TryParse(txt_Additional_Charge.Text, out decimal additionalCharge) || additionalCharge < 0)
            {
                MessageBox.Show("Please enter a valid additional charge.");
                return;
            }

            int venueId = (int)combo_Venue.SelectedValue;
            string scopeName = txt_Scope_Name.Text;
            string rateType = combo_Rate_Type.SelectedItem.ToString();
            bool aircon = radio_Aircon_Yes.Checked; // True if "Yes" is selected, False if "No" is selected

            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                using (SqlTransaction transaction = db.strCon.BeginTransaction())
                {
                    try
                    {
                        // Insert the new scope if it doesn't already exist
                        int scopeId;
                        string scopeQuery = "SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = @scopeName";
                        SqlCommand scopeCmd = new SqlCommand(scopeQuery, db.strCon, transaction);
                        scopeCmd.Parameters.AddWithValue("@scopeName", scopeName);
                        object result = scopeCmd.ExecuteScalar();

                        if (result == null)
                        {
                            string insertScopeQuery = "INSERT INTO tbl_Venue_Scope (fld_Venue_Scope_Name) OUTPUT INSERTED.pk_Venue_ScopeID VALUES (@scopeName)";
                            SqlCommand insertScopeCmd = new SqlCommand(insertScopeQuery, db.strCon, transaction);
                            insertScopeCmd.Parameters.AddWithValue("@scopeName", scopeName);
                            scopeId = (int)insertScopeCmd.ExecuteScalar();
                        }
                        else
                        {
                            scopeId = (int)result;
                        }

                        // Insert the pricing details
                        string pricingQuery = @"
                            INSERT INTO tbl_Venue_Pricing (
                                fk_VenueID, fk_Venue_ScopeID, fld_Aircon, fld_Rate_Type, 
                                fld_First4Hrs_Rate, fld_Hourly_Rate, fld_Additional_Charge
                            ) 
                            VALUES (
                                @venueId, @scopeId, @aircon, @rateType, 
                                @first4HrsRate, @hourlyRate, @additionalCharge
                            )";
                        SqlCommand pricingCmd = new SqlCommand(pricingQuery, db.strCon, transaction);
                        pricingCmd.Parameters.AddWithValue("@venueId", venueId);
                        pricingCmd.Parameters.AddWithValue("@scopeId", scopeId);
                        pricingCmd.Parameters.AddWithValue("@aircon", aircon);
                        pricingCmd.Parameters.AddWithValue("@rateType", rateType);
                        pricingCmd.Parameters.AddWithValue("@first4HrsRate", first4HrsRate);
                        pricingCmd.Parameters.AddWithValue("@hourlyRate", hourlyRate);
                        pricingCmd.Parameters.AddWithValue("@additionalCharge", additionalCharge);

                        pricingCmd.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Scope and pricing added successfully!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error adding scope and pricing: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }
    }
}
