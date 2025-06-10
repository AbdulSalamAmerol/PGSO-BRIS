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

            combo_Scope.SelectedIndexChanged += LoadPricingForSelection;
            combo_Rate_Type.SelectedIndexChanged += LoadPricingForSelection;
            combo_Venue.SelectedIndexChanged += LoadPricingForSelection;
        }

        private void LoadVenues()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = "SELECT pk_VenueID, fld_Venue_Name FROM tbl_Venue";
                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Temporarily remove the event handler to avoid reentrancy
                    combo_Venue.SelectedIndexChanged -= Combo_Venue_SelectedIndexChanged;
                    combo_Venue.DataSource = dt;
                    combo_Venue.ValueMember = "pk_VenueID";
                    combo_Venue.DisplayMember = "fld_Venue_Name";
                    combo_Venue.SelectedIndexChanged += Combo_Venue_SelectedIndexChanged;
                }
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

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@venueId", venueId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        combo_Scope.Items.Clear();
                        while (reader.Read())
                        {
                            combo_Scope.Items.Add(reader["fld_Venue_Scope_Name"].ToString());
                        }
                    }
                }

                // Add an empty item at the beginning
                if (combo_Scope.Items.Count > 0)
                {
                    combo_Scope.SelectedIndex = 0;
                }
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

            // Validate Caterer Fee
            if (!decimal.TryParse(txt_Caterer_Fee.Text, out decimal catererFee) || catererFee < 0)
            {
                MessageBox.Show("Please enter a valid caterer fee.");
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

                        // Insert the pricing details, now including Caterer Fee
                        string pricingQuery = @"
                INSERT INTO tbl_Venue_Pricing (
                    fk_VenueID, fk_Venue_ScopeID, fld_Aircon, fld_Rate_Type, 
                    fld_First4Hrs_Rate, fld_Hourly_Rate, fld_Additional_Charge, fld_Caterer_Fee
                ) 
                VALUES (
                    @venueId, @scopeId, @aircon, @rateType, 
                    @first4HrsRate, @hourlyRate, @additionalCharge, @catererFee
                )";
                        SqlCommand pricingCmd = new SqlCommand(pricingQuery, db.strCon, transaction);
                        pricingCmd.Parameters.AddWithValue("@venueId", venueId);
                        pricingCmd.Parameters.AddWithValue("@scopeId", scopeId);
                        pricingCmd.Parameters.AddWithValue("@aircon", airconValue);
                        pricingCmd.Parameters.AddWithValue("@rateType", rateType);
                        pricingCmd.Parameters.AddWithValue("@first4HrsRate", first4HrsRate);
                        pricingCmd.Parameters.AddWithValue("@hourlyRate", hourlyRate);
                        pricingCmd.Parameters.AddWithValue("@additionalCharge", additionalCharge);
                        pricingCmd.Parameters.AddWithValue("@catererFee", catererFee);

                        pricingCmd.ExecuteNonQuery();


                        // auditlog start
                        string affectedTable = "tbl_Venue_Pricing";
                        string actionType = "Added Venue Scope & Pricing";
                        string affectedRecordPk = $"{venueId}-{scopeId}-{rateType}"; // Composite key for uniqueness

                        string changedBy = frm_login.LoggedInUserRole;
                        DateTime changedAt = DateTime.Now;
                        int userId = frm_login.LoggedInUserId;

                        // Serialize new scope/pricing data for audit log
                        string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                        {
                            VenueID = venueId,
                            ScopeID = scopeId,
                            ScopeName = scopeName,
                            RateType = rateType,
                            First4HrsRate = first4HrsRate,
                            HourlyRate = hourlyRate,
                            AdditionalCharge = additionalCharge,
                            CatererFee = catererFee,
                            Aircon = airconValue
                        });

                        using (SqlCommand auditCmd = new SqlCommand(@"
                            INSERT INTO tbl_Audit_Log
                            (fk_UserID, fld_Affected_Table, fld_Affected_Record_PK, fld_ActionType, fld_Previous_Data_Json, fld_New_Data_Json, fld_Changed_By, fld_Changed_At)
                            VALUES (@UserID, @Table, @RecordPK, @ActionType, @PrevJson, @NewJson, @ChangedBy, @ChangedAt)", db.strCon, transaction))
                        {
                            auditCmd.Parameters.AddWithValue("@UserID", userId);
                            auditCmd.Parameters.AddWithValue("@Table", affectedTable);
                            auditCmd.Parameters.AddWithValue("@RecordPK", affectedRecordPk);
                            auditCmd.Parameters.AddWithValue("@ActionType", actionType);
                            auditCmd.Parameters.AddWithValue("@PrevJson", DBNull.Value); // No previous data for create
                            auditCmd.Parameters.AddWithValue("@NewJson", newDataJson);
                            auditCmd.Parameters.AddWithValue("@ChangedBy", changedBy);
                            auditCmd.Parameters.AddWithValue("@ChangedAt", changedAt);

                            auditCmd.ExecuteNonQuery();
                        }
                        // end auditlog

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

        private void LoadPricingForSelection(object sender, EventArgs e)
        {
            if (combo_Venue.SelectedValue == null || combo_Scope.SelectedItem == null || combo_Rate_Type.SelectedItem == null)
                return;

            int venueId = (int)combo_Venue.SelectedValue;
            string scopeName = combo_Scope.Text;
            string rateType = combo_Rate_Type.SelectedItem.ToString();

            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = @"
SELECT vp.fld_First4Hrs_Rate, vp.fld_Hourly_Rate, vp.fld_Additional_Charge, vp.fld_Caterer_Fee, vp.fld_Aircon
FROM tbl_Venue_Pricing vp
INNER JOIN tbl_Venue_Scope vs ON vp.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
WHERE vp.fk_VenueID = @venueId
  AND LTRIM(RTRIM(LOWER(vs.fld_Venue_Scope_Name))) = LTRIM(RTRIM(LOWER(@scopeName)))
  AND LTRIM(RTRIM(LOWER(vp.fld_Rate_Type))) = LTRIM(RTRIM(LOWER(@rateType)))";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@venueId", venueId);
                    cmd.Parameters.AddWithValue("@scopeName", scopeName.Trim().ToLower());
                    cmd.Parameters.AddWithValue("@rateType", rateType.Trim().ToLower());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_First4Hrs_Rate.Text = reader["fld_First4Hrs_Rate"].ToString();
                            txt_Hourly_Rate.Text = reader["fld_Hourly_Rate"].ToString();
                            txt_Additional_Charge.Text = reader["fld_Additional_Charge"].ToString();
                            txt_Caterer_Fee.Text = reader["fld_Caterer_Fee"].ToString();

                            if (reader["fld_Aircon"] != DBNull.Value)
                            {
                                bool aircon = Convert.ToBoolean(reader["fld_Aircon"]);
                                radio_Aircon_Yes.Checked = aircon;
                                radio_Aircon_YNo.Checked = !aircon;
                            }
                            else
                            {
                                radio_Aircon_Yes.Checked = false;
                                radio_Aircon_YNo.Checked = false;
                            }
                        }
                        else
                        {
                            // Clear fields if no pricing found
                            txt_First4Hrs_Rate.Text = "";
                            txt_Hourly_Rate.Text = "";
                            txt_Additional_Charge.Text = "";
                            txt_Caterer_Fee.Text = "";
                            radio_Aircon_Yes.Checked = false;
                            radio_Aircon_YNo.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pricing: " + ex.Message);
            }
            finally
            {
                if (db.strCon.State == System.Data.ConnectionState.Open)
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