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
        private bool allowCustomScopeEntry = false;
        public event EventHandler ScopeAdded;

        private void OnScopeAdded()
        {
            ScopeAdded?.Invoke(this, EventArgs.Empty);
        }
        public frm_Add_Scope()
        {
            InitializeComponent();
            LoadVenues();
            LoadRateTypes();

            // Set up the combo box properties
            combo_Scope.DropDownStyle = ComboBoxStyle.DropDown;
            combo_Scope.KeyPress += Combo_Scope_KeyPress;
            combo_Scope.SelectedIndexChanged += Combo_Scope_SelectedIndexChanged;
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
                combo_Venue.SelectedIndexChanged += Combo_Venue_SelectedIndexChanged;

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

        private void LoadScopesForVenue(int venueId)
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = @"SELECT DISTINCT vs.fld_Venue_Scope_Name 
                                FROM tbl_Venue_Scope vs
                                INNER JOIN tbl_Venue_Pricing vp ON vs.pk_Venue_ScopeID = vp.fk_Venue_ScopeID
                                WHERE vp.fk_VenueID = @venueId
                                ORDER BY vs.fld_Venue_Scope_Name";

                SqlCommand cmd = new SqlCommand(query, db.strCon);
                cmd.Parameters.AddWithValue("@venueId", venueId);
                SqlDataReader reader = cmd.ExecuteReader();

                combo_Scope.Items.Clear();
                while (reader.Read())
                {
                    combo_Scope.Items.Add(reader["fld_Venue_Scope_Name"].ToString());
                }

                // Add an empty item at the beginning
                if (combo_Scope.Items.Count > 0)
                {
                    combo_Scope.SelectedIndex = 0;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading scopes: " + ex.Message);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }

        private void Combo_Venue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Venue.SelectedValue != null && combo_Venue.SelectedValue is int)
            {
                int venueId = (int)combo_Venue.SelectedValue;
                LoadScopesForVenue(venueId);
            }
        }

        private void Combo_Scope_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When a scope is selected from the dropdown, disable custom entry mode
            allowCustomScopeEntry = false;
        }

        private void Combo_Scope_KeyPress(object sender, KeyPressEventArgs e)
        {
            // When user starts typing, enable custom entry mode
            allowCustomScopeEntry = true;
        }

        private void tbn_Save_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (combo_Venue.SelectedValue == null || string.IsNullOrEmpty(combo_Scope.Text))
            {
                MessageBox.Show("Please select a venue and enter/select a scope.");
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
            string scopeName = combo_Scope.Text; // Get the text from combo box
            string rateType = combo_Rate_Type.SelectedItem.ToString();

            // Determine aircon value: null if neither radio is checked
            object airconValue;
            if (radio_Aircon_Yes.Checked)
                airconValue = true;
            else if (radio_Aircon_YNo.Checked)
                airconValue = false;
            else
                airconValue = DBNull.Value;

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
                        pricingCmd.Parameters.AddWithValue("@aircon", airconValue);
                        pricingCmd.Parameters.AddWithValue("@rateType", rateType);
                        pricingCmd.Parameters.AddWithValue("@first4HrsRate", first4HrsRate);
                        pricingCmd.Parameters.AddWithValue("@hourlyRate", hourlyRate);
                        pricingCmd.Parameters.AddWithValue("@additionalCharge", additionalCharge);

                        pricingCmd.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Scope and pricing added successfully!");
                        OnScopeAdded();
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

        private void frm_Add_Scope_Load(object sender, EventArgs e)
        {
            // You can initialize additional controls here if needed
        }

        private void radio_Aircon_YNo_CheckedChanged(object sender, EventArgs e)
        {
            // Handle radio button changes if needed
        }
    }
}