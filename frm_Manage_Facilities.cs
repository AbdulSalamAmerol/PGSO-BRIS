using pgso_connect;
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

namespace pgso
{
    public partial class frm_Manage_Venue : Form
    {
        private Connection db = new Connection();
        private SqlConnection dbConnection;
        private SqlCommand cmd;

        private DataTable venuesTable;

        private int currentPage = 1;
        private int pageSize = 30;
        private int totalPages = 1;
        private int rateTypeStartIndex = -1;
        private int airconStartIndex = -1;
        public frm_Manage_Venue()
        {
            InitializeComponent();
           
            dt_Venues.CellClick += dt_Venues_CellClick;
            dt_Venues.RowPostPaint += dt_Venues_RowPostPaint;
           
           dt_Venues.Columns["DeleteVenue"].Visible = false;
            

            // Attach CellFormatting event
            dt_Venues.CellFormatting += dt_Venues_CellFormatting;
           

          

            dt_Venues.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dt_Venues.EnableHeadersVisualStyles = false;
            dt_Venues.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, System.Drawing.FontStyle.Bold);
            // In InitializeControls() or after InitializeComponent()
            txt_Search_Venue.ForeColor = System.Drawing.Color.Gray;
            txt_Search_Venue.Text = "Search Venue";
            txt_Search_Venue.GotFocus += Txt_Search_GotFocus;
            txt_Search_Venue.LostFocus += Txt_Search_LostFocus;
            // In InitializeControls() or after InitializeComponent()


            // Always show frm_Add_Venues in the panel on form creation
            ShowAddVenueForm();

            // Always show frm_Add_Scope in the panel on form creation
            ShowAddScopeForm();

            // Panels are disabled by default
            panel_Add_Venue.Enabled = false;
            panel_AddScope.Enabled = false;

            combo_Filter.SelectedIndexChanged += combo_Filter_SelectedIndexChanged;
            combo_Sort.SelectedIndexChanged += combo_Sort_SelectedIndexChanged;

            // Add filter options
            combo_Filter.Items.Clear();
            combo_Filter.Items.Add("All");
            combo_Filter.Items.Add("Venue");
            combo_Filter.Items.Add("Airconditioned Yes");
            combo_Filter.Items.Add("Airconditioned No");
            combo_Filter.Items.Add("Rate Type");
            combo_Filter.SelectedIndex = 0; // Default selection

            // Add sort options
            combo_Sort.Items.Clear();
            combo_Sort.Items.Add("ASC");
            combo_Sort.Items.Add("DESC");
            combo_Sort.Items.Add("Lowest Rate4");
            combo_Sort.Items.Add("Highest Rate4");
            combo_Sort.SelectedIndex = 0; // Default selection

            combo_Filter.SelectedIndexChanged += combo_Filter_SelectedIndexChanged;
            combo_Sort.SelectedIndexChanged += combo_Sort_SelectedIndexChanged;

            combo_Filter.DrawMode = DrawMode.OwnerDrawFixed;
            combo_Filter.DrawItem += combo_Filter_DrawItem;
        }


        private void frm_Manage_Facilities_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void dt_Venues_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int itemColIndex = dt_Venues.Columns["Item"].Index;
            int globalRowNumber = (currentPage - 1) * pageSize + e.RowIndex + 1;
            dt_Venues.Rows[e.RowIndex].Cells[itemColIndex].Value = globalRowNumber.ToString();
        }
        private void Txt_Search_GotFocus(object sender, EventArgs e)
        {
            if (txt_Search_Venue.Text == "Search Venue")
            {
                txt_Search_Venue.Text = "";
                txt_Search_Venue.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void Txt_Search_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Search_Venue.Text))
            {
                txt_Search_Venue.Text = "Search Venue";
                txt_Search_Venue.ForeColor = System.Drawing.Color.Gray;
            }
        }

        

        
        

        //displays the data in the datagridview
        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                //VENUES
                string queryVenues = @"
                SELECT 
    vp.pk_Venue_PricingID, -- Add this
    v.fld_Venue_Name, 
    vs.fld_Venue_Scope_Name,
    vp.fld_Aircon,
    vp.fld_Rate_Type,
    vp.fld_First4Hrs_Rate,
    vp.fld_Hourly_Rate,
    vp.fld_Additional_Charge,
    vp.fld_Caterer_Fee
 FROM 
     tbl_Venue v
 JOIN 
    tbl_Venue_Pricing vp ON v.pk_VenueID = vp.fk_VenueID
 JOIN 
    tbl_Venue_Scope vs ON vs.pk_Venue_ScopeID = vp.fk_Venue_ScopeID";

                
                LoadData(queryVenues, dt_Venues, "venues");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }
        private void dt_Venues_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the column is the Airconditioned column
            if (dt_Venues.Columns[e.ColumnIndex].Name == "fld_Aircon")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.Value = "No AC In this Venue";
                    e.FormattingApplied = true;
                }
                else if (e.Value is bool)
                {
                    e.Value = (bool)e.Value ? "Yes" : "No"; // Translate True/False to Yes/No
                    e.FormattingApplied = true;
                }
            }
            else if (dt_Venues.Columns[e.ColumnIndex].Name == "fld_Rate_Type")
            {
                if (e.Value == null || e.Value == DBNull.Value || string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    e.Value = "Rates Not Applied";
                    e.FormattingApplied = true;
                }
            }
            else if (dt_Venues.Columns[e.ColumnIndex].Name == "fld_First4Hrs_Rate" ||
                     dt_Venues.Columns[e.ColumnIndex].Name == "fld_Hourly_Rate" ||
                     dt_Venues.Columns[e.ColumnIndex].Name == "fld_Additional_Charge")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = "₱" + value.ToString("N2"); // Add Peso sign and format as currency
                    e.FormattingApplied = true;
                }
            }
        }



        



        private void LoadData(string query, DataGridView dataGridView, string status)
        {
            try
            {
                DataTable tempDt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tempDt);
                    }
                }

                dataGridView.AutoGenerateColumns = true;
                dataGridView.DataSource = tempDt;

                // Store the data for filtering
                if (dataGridView == dt_Venues)
                    venuesTable = tempDt;

                if (dataGridView == dt_Venues)
                    PopulateFilterCombo();

                if (tempDt.Rows.Count == 0)
                {
                    MessageBox.Show($"No {status} records found.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {status} data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Add_Equipment_Click(object sender, EventArgs e)
        {
            frm_Add_Equipment frm_Add_Eq = new frm_Add_Equipment();
            frm_Add_Eq.Show();
        }

        private void btn_Add_Venue_Click(object sender, EventArgs e)
        {
            panel_Add_Venue.Enabled = true;
            panel_AddScope.Enabled = false; // Disable the other panel
            ShowAddVenueForm();
            RefreshData();

        }
        //sa datagridview click for venues
        private void dt_Venues_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            DataGridViewRow row = dt_Venues.Rows[e.RowIndex];

            if (e.ColumnIndex == dt_Venues.Columns["EditVenue"].Index)
            {
                int pricingId = Convert.ToInt32(row.Cells["pk_Venue_PricingID"].Value);
                string venueName = row.Cells["fld_Venue_Name"].Value.ToString();
                string venueScopeName = row.Cells["fld_Venue_Scope_Name"].Value.ToString();
                bool aircon = Convert.ToBoolean(row.Cells["fld_Aircon"].Value);
                string rateType = row.Cells["fld_Rate_Type"].Value.ToString();
                decimal first4HrsRate = Convert.ToDecimal(row.Cells["fld_First4Hrs_Rate"].Value);
                decimal hourlyRate = Convert.ToDecimal(row.Cells["fld_Hourly_Rate"].Value);
                decimal additionalCharge = Convert.ToDecimal(row.Cells["fld_Additional_Charge"].Value);
                decimal catererFee = 0;
                if (row.Cells["fld_Caterer_Fee"] != null && row.Cells["fld_Caterer_Fee"].Value != DBNull.Value)
                    catererFee = Convert.ToDecimal(row.Cells["fld_Caterer_Fee"].Value);

                ShowEditForm(pricingId, venueName, venueScopeName, aircon, rateType, first4HrsRate, hourlyRate, additionalCharge, catererFee);
            }
            else if (e.ColumnIndex == dt_Venues.Columns["DeleteVenue"].Index)
            {
                string venueName = row.Cells["fld_Venue_Name"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the venue '{venueName}'?\n\nWARNING: This will also delete all reservations associated with this venue.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        db.strCon.Open();
                        using (SqlTransaction transaction = db.strCon.BeginTransaction())
                        {
                            try
                            {
                                int venueId = GetVenueId(venueName, transaction);
                                if (venueId == 0)
                                {
                                    MessageBox.Show("Venue not found in database!");
                                    return;
                                }

                                DeleteReservations(venueId, transaction);
                                DeletePricingRecords(venueId, transaction);
                                DeleteScopeRecords(venueId, transaction);
                                DeleteVenues(venueId, transaction);

                                transaction.Commit();
                                MessageBox.Show("Venue and all associated reservations deleted successfully!");
                                RefreshData();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Error deleting venue: {ex.Message}",
                                    "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Database connection error: {ex.Message}",
                            "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (db.strCon.State == ConnectionState.Open)
                            db.strCon.Close();
                    }
                }
            }
        }



        // Helper methods
        private int GetVenueId(string venueName, SqlTransaction transaction)
        {
            string getIdQuery = @"SELECT v.pk_VenueID FROM tbl_Venue v WHERE v.fld_Venue_Name = @venueName";

            using (SqlCommand cmdGetId = new SqlCommand(getIdQuery, db.strCon, transaction))
            {
                cmdGetId.Parameters.AddWithValue("@venueName", venueName);
                return Convert.ToInt32(cmdGetId.ExecuteScalar() ?? 0);
            }
        }

        private int GetEquipmentId(string equipmentName, SqlTransaction transaction)
        {
            string getIdQuery = @"SELECT e.pk_EquipmentID FROM tbl_Equipment e WHERE e.fld_Equipment_Name = @equipmentName";

            using (SqlCommand cmdGetId = new SqlCommand(getIdQuery, db.strCon, transaction))
            {
                cmdGetId.Parameters.AddWithValue("@equipmentName", equipmentName);
                return Convert.ToInt32(cmdGetId.ExecuteScalar() ?? 0);
            }
        }

        private void DeleteReservations(int venueId, SqlTransaction transaction)
        {       // Delete reservations in tbl_Reservation_Venue that reference the venue
       string deleteReservationVenueQuery = @"
       DELETE FROM tbl_Reservation_Venues
       WHERE fk_Venue_ScopeID IN (
           SELECT vs.pk_Venue_ScopeID
           FROM tbl_Venue_Scope vs
           JOIN tbl_Venue_Pricing vp ON vs.pk_Venue_ScopeID = vp.fk_Venue_ScopeID
           WHERE vp.fk_VenueID = @venueId
       )";

       using (SqlCommand cmd = new SqlCommand(deleteReservationVenueQuery, db.strCon, transaction))
       {
           cmd.Parameters.AddWithValue("@venueId", venueId);
           cmd.ExecuteNonQuery();
       }

       // Delete reservations in tbl_Reservation that reference the venue
       string deleteReservationsQuery = @"
       DELETE FROM tbl_Reservation
       WHERE fk_VenueID = @venueId";

       using (SqlCommand cmd = new SqlCommand(deleteReservationsQuery, db.strCon, transaction))
       {
           cmd.Parameters.AddWithValue("@venueId", venueId);
           cmd.ExecuteNonQuery();
       }
        }

        private void DeleteEquipmentReservations(int equipmentId, SqlTransaction transaction)
        {
            // Only delete from equipment reservation junction table
            string deleteQuery = "DELETE FROM tbl_Reservation_Equipment WHERE fk_EquipmentID = @equipmentId";

            using (SqlCommand cmd = new SqlCommand(deleteQuery, db.strCon, transaction))
            {
                cmd.Parameters.AddWithValue("@equipmentId", equipmentId);
                cmd.ExecuteNonQuery();
            }
        }

        private void DeletePricingRecords(int venueId, SqlTransaction transaction)
        {
            string deletePricingQuery = "DELETE FROM tbl_Venue_Pricing WHERE fk_VenueID = @venueId";
            using (SqlCommand cmd = new SqlCommand(deletePricingQuery, db.strCon, transaction))
            {
                cmd.Parameters.AddWithValue("@venueId", venueId);
                cmd.ExecuteNonQuery();
            }
        }

        private void DeleteScopeRecords(int venueId, SqlTransaction transaction)
        {
            string deleteScopeQuery = "DELETE FROM tbl_Venue_Scope WHERE pk_Venue_ScopeID = @venueId";
            using (SqlCommand cmd = new SqlCommand(deleteScopeQuery, db.strCon, transaction))
            {
                cmd.Parameters.AddWithValue("@venueId", venueId);
                cmd.ExecuteNonQuery();
            }
        }

        private void DeleteVenues(int venueId, SqlTransaction transaction)
        {
            string deleteVenueQuery = "DELETE FROM tbl_Venue WHERE pk_VenueID = @venueId";
            using (SqlCommand cmd = new SqlCommand(deleteVenueQuery, db.strCon, transaction))
            {
                cmd.Parameters.AddWithValue("@venueId", venueId);
                cmd.ExecuteNonQuery();
            }
        }



        //Edit form for Venues
        private void ShowEditForm(int pricingId, string venueName, string venueScopeName, bool aircon, string rateType,
            decimal first4HrsRate, decimal hourlyRate, decimal additionalCharge, decimal catererFee = 0)
        {
    Form editForm = new Form();
    editForm.Text = "Edit Venue";
    editForm.Size = new Size(400, 360);

    Font editFont = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
    Font labelFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

    // Venue Name
    Label lblVenueName = new Label() { Text = "Venue Name", Left = 10, Top = 20, Font = labelFont };
    TextBox txtVenueName = new TextBox() { Left = 150, Top = 20, Width = 200, Font = editFont, Text = venueName };

    // Scope Name
    Label lblVenueScopeName = new Label() { Text = "Venue Scope Name", Left = 10, Top = 60, Font = labelFont };
    TextBox txtVenueScopeName = new TextBox() { Left = 150, Top = 60, Width = 200, Font = editFont, Text = venueScopeName };

    // First 4 Hrs Rate
    Label lblFirst4HrsRate = new Label() { Text = "First 4 Hrs Rate", Left = 10, Top = 100, Font = labelFont };
    TextBox txtFirst4HrsRate = new TextBox() { Left = 150, Top = 100, Width = 200, Font = editFont, Text = first4HrsRate.ToString("N2") };

    // Hourly Rate
    Label lblHourlyRate = new Label() { Text = "Hourly Rate", Left = 10, Top = 140, Font = labelFont };
    TextBox txtHourlyRate = new TextBox() { Left = 150, Top = 140, Width = 200, Font = editFont, Text = hourlyRate.ToString("N2") };

    // Additional Charge
    Label lblAdditionalCharge = new Label() { Text = "Additional Charge", Left = 10, Top = 180, Font = labelFont };
    TextBox txtAdditionalCharge = new TextBox() { Left = 150, Top = 180, Width = 200, Font = editFont, Text = additionalCharge.ToString("N2") };

    // Caterer Fee
    Label lblCatererFee = new Label() { Text = "Caterer Fee", Left = 10, Top = 220, Font = labelFont };
    TextBox txtCatererFee = new TextBox() { Left = 150, Top = 220, Width = 200, Font = editFont, Text = catererFee.ToString("N2") };

    // Save Button
    Button btnSave = new Button() { Text = "Save", Left = 150, Top = 270, Width = 200, Height = 35, Font = editFont };
    btnSave.Click += (s, args) =>
    {
        try
        {
            if (db.strCon.State == ConnectionState.Closed)
                db.strCon.Open();

            using (SqlTransaction transaction = db.strCon.BeginTransaction())
            {
                try
                {
                    // Get VenueID and ScopeID
                    int venueId = 0;
                    int scopeId = 0;
                    string getIdQuery = @"
                        SELECT v.pk_VenueID, vs.pk_Venue_ScopeID
                        FROM tbl_Venue v
                        JOIN tbl_Venue_Pricing vp ON v.pk_VenueID = vp.fk_VenueID
                        JOIN tbl_Venue_Scope vs ON vs.pk_Venue_ScopeID = vp.fk_Venue_ScopeID
                        WHERE v.fld_Venue_Name = @originalName AND vs.fld_Venue_Scope_Name = @originalScopeName";

                    using (SqlCommand cmdGetId = new SqlCommand(getIdQuery, db.strCon, transaction))
                    {
                        cmdGetId.Parameters.AddWithValue("@originalName", venueName);
                        cmdGetId.Parameters.AddWithValue("@originalScopeName", venueScopeName);
                        using (SqlDataReader reader = cmdGetId.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                venueId = reader.GetInt32(0);
                                scopeId = reader.GetInt32(1);
                            }
                        }
                    }

                    if (venueId == 0 || scopeId == 0)
                    {
                        MessageBox.Show("Venue or scope not found in database!");
                        return;
                    }

                    bool changesMade = false;

                    // Update pricing if changed
                    decimal newFirst4HrsRate = decimal.Parse(txtFirst4HrsRate.Text);
                    decimal newHourlyRate = decimal.Parse(txtHourlyRate.Text);
                    decimal newAdditionalCharge = decimal.Parse(txtAdditionalCharge.Text);
                    decimal newCatererFee = decimal.Parse(txtCatererFee.Text);

                    if (newFirst4HrsRate != first4HrsRate || newHourlyRate != hourlyRate ||
                        newAdditionalCharge != additionalCharge || newCatererFee != catererFee)
                    {
                        changesMade = true;
                        string updatePriceQuery = @"
    UPDATE tbl_Venue_Pricing
    SET fld_First4Hrs_Rate = @first4HrsRate,
        fld_Hourly_Rate = @hourlyRate,
        fld_Additional_Charge = @additionalCharge,
        fld_Caterer_Fee = @catererFee
    WHERE pk_Venue_PricingID = @pricingId";

                        using (SqlCommand cmdPrice = new SqlCommand(updatePriceQuery, db.strCon, transaction))
                        {
                            cmdPrice.Parameters.AddWithValue("@first4HrsRate", newFirst4HrsRate);
                            cmdPrice.Parameters.AddWithValue("@hourlyRate", newHourlyRate);
                            cmdPrice.Parameters.AddWithValue("@additionalCharge", newAdditionalCharge);
                            cmdPrice.Parameters.AddWithValue("@catererFee", newCatererFee);
                            cmdPrice.Parameters.AddWithValue("@pricingId", pricingId); // <-- THIS IS THE FIX
                            cmdPrice.ExecuteNonQuery();
                        }
                    }

                    // Update venue name if changed
                    if (txtVenueName.Text != venueName)
                    {
                        changesMade = true;
                        string updateVenueQuery = @"
                            UPDATE tbl_Venue
SET fld_Venue_Name = @newVenueName
WHERE pk_VenueID = @venueId";
                        using (SqlCommand cmdUpdateVenue = new SqlCommand(updateVenueQuery, db.strCon, transaction))
                        {
                            cmdUpdateVenue.Parameters.AddWithValue("@newVenueName", txtVenueName.Text);
                            cmdUpdateVenue.Parameters.AddWithValue("@venueId", venueId);
                            cmdUpdateVenue.ExecuteNonQuery();
                        }
                    }

                    // Update scope name for all with the same scopeId under this venue
                    if (txtVenueScopeName.Text != venueScopeName)
                    {
                        changesMade = true;
                        string updateScopeQuery = @"
                            UPDATE tbl_Venue_Scope
SET fld_Venue_Scope_Name = @newScopeName
WHERE pk_Venue_ScopeID = @scopeId";
                        using (SqlCommand cmdUpdateScope = new SqlCommand(updateScopeQuery, db.strCon, transaction))
                        {
                            cmdUpdateScope.Parameters.AddWithValue("@newScopeName", txtVenueScopeName.Text);
                            cmdUpdateScope.Parameters.AddWithValue("@scopeId", scopeId);
                            cmdUpdateScope.ExecuteNonQuery();
                        }
                    }

                    if (changesMade)
                    {
                        transaction.Commit();
                        MessageBox.Show("Updated Successfully!");
                        editForm.Close();
                        RefreshData();
                    }
                    else
                    {
                        MessageBox.Show("No Changes");
                        editForm.Close();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error updating venue: {ex.Message}\n\nPlease check if the venue name already exists.",
                                    "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database connection error: {ex.Message}",
                            "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (db.strCon.State == ConnectionState.Open)
                db.strCon.Close();
        }
    };

    editForm.Controls.Add(lblVenueName);
    editForm.Controls.Add(txtVenueName);
    editForm.Controls.Add(lblVenueScopeName);
    editForm.Controls.Add(txtVenueScopeName);
    editForm.Controls.Add(lblFirst4HrsRate);
    editForm.Controls.Add(txtFirst4HrsRate);
    editForm.Controls.Add(lblHourlyRate);
    editForm.Controls.Add(txtHourlyRate);
    editForm.Controls.Add(lblAdditionalCharge);
    editForm.Controls.Add(txtAdditionalCharge);
    editForm.Controls.Add(lblCatererFee);
    editForm.Controls.Add(txtCatererFee);
    editForm.Controls.Add(btnSave);

    editForm.Show();
}



        // Other existing methods

        private void btn_Edit_Equipment_Click(object sender, EventArgs e) { }
        private void btn_Delete_Equipment_Click(object sender, EventArgs e) { }
        private void dt_Venues_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void btn_AddScope_Click(object sender, EventArgs e)
        {
            panel_AddScope.Enabled = true;
            panel_Add_Venue.Enabled = false; // Disable the other panel
            ShowAddScopeForm();
            RefreshData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Search_Venue_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            if (venuesTable == null) return;
            string filter = txt_Search_Venue.Text.Replace("'", "''");
            (dt_Venues.DataSource as DataTable).DefaultView.RowFilter =
                $"[fld_Venue_Name] LIKE '%{filter}%'";
        }

        private void panel_Add_Venue_Paint(object sender, PaintEventArgs e)
        {

        }

        //show add venue in the panel
        private void ShowAddVenueForm()
        {
            panel_Add_Venue.Controls.Clear();

            frm_Add_Venues frm_Add_Venues = new frm_Add_Venues();
            frm_Add_Venues.TopLevel = false;
            frm_Add_Venues.FormBorderStyle = FormBorderStyle.None;
            frm_Add_Venues.Dock = DockStyle.Fill;

            frm_Add_Venues.VenueAdded += (s, args) => {
                RefreshData();
                panel_Add_Venue.Controls.Clear();
                // Optionally, show the form again after adding
                ShowAddVenueForm();
            };

            panel_Add_Venue.Controls.Add(frm_Add_Venues);
            frm_Add_Venues.Show();
        }

        // Add this method to your class
        private void ShowAddScopeForm()
        {
            panel_AddScope.Controls.Clear();

            frm_Add_Scope frmAddScope = new frm_Add_Scope();
            frmAddScope.TopLevel = false;
            frmAddScope.FormBorderStyle = FormBorderStyle.None;
            frmAddScope.Dock = DockStyle.Fill;

            frmAddScope.ScopeAdded += (s, args) => {
                RefreshData();
                panel_AddScope.Controls.Clear();
                // Optionally, show the form again after adding
                ShowAddScopeForm();
            };

            panel_AddScope.Controls.Add(frmAddScope);
            frmAddScope.Show();
        }



        //filter and sort
        private void ApplyFilterAndSort()
        {
            if (currentPage < 1) currentPage = 1;
            if (venuesTable == null) return;

            string filter = "";
            string sort = "";

            var selected = combo_Filter.SelectedItem?.ToString();

            if (selected == "All" || string.IsNullOrEmpty(selected))
            {
                filter = "";
            }
            else if (selected == "Airconditioned Yes")
            {
                filter = "[fld_Aircon] = True";
            }
            else if (selected == "Airconditioned No")
            {
                filter = "[fld_Aircon] = False";
            }
            else if (venuesTable.AsEnumerable().Any(r => r.Field<string>("fld_Venue_Name") == selected))
            {
                filter = $"[fld_Venue_Name] = '{selected.Replace("'", "''")}'";
            }
            else if (venuesTable.AsEnumerable().Any(r => r.Field<string>("fld_Rate_Type") == selected))
            {
                filter = $"[fld_Rate_Type] = '{selected.Replace("'", "''")}'";
            }

            // Sorting (unchanged)
            switch (combo_Sort.SelectedItem?.ToString())
            {
                case "ASC":
                    sort = "[fld_Venue_Name] ASC";
                    break;
                case "DESC":
                    sort = "[fld_Venue_Name] DESC";
                    break;
                case "Lowest Rate4":
                    sort = "[fld_First4Hrs_Rate] ASC";
                    break;
                case "Highest Rate4":
                    sort = "[fld_First4Hrs_Rate] DESC";
                    break;
                default:
                    sort = "";
                    break;
            }

            DataView dv = venuesTable.DefaultView;
            dv.RowFilter = filter;
            dv.Sort = sort;

            // Pagination logic
            int totalRows = dv.Count;
            totalPages = (int)Math.Ceiling(totalRows / (double)pageSize);
            if (currentPage > totalPages) currentPage = totalPages;
            if (currentPage < 1) currentPage = 1;

            // Get only the rows for the current page
            DataTable pageTable = dv.ToTable().Clone();
            int startIndex = (currentPage - 1) * pageSize;
            for (int i = startIndex; i < startIndex + pageSize && i < totalRows; i++)
            {
                pageTable.ImportRow(dv[i].Row);
            }

            dt_Venues.DataSource = pageTable;

            // Update page info label
            lblPageInfo.Text = $"Page {currentPage} of {Math.Max(totalPages, 1)}";
            btnPrevPage.Enabled = currentPage > 1;
            btnNextPage.Enabled = currentPage < totalPages;
        }
        private void combo_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            ApplyFilterAndSort();
        }

        private void combo_Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            ApplyFilterAndSort();
        }
        private void PopulateFilterCombo()
        {
            combo_Filter.Items.Clear();
            combo_Filter.Items.Add("All");

            if (venuesTable == null) return;

            // Add unique venue names
            var venueNames = venuesTable.AsEnumerable()
                .Select(row => row.Field<string>("fld_Venue_Name"))
                .Distinct()
                .OrderBy(name => name);

            foreach (var name in venueNames)
                combo_Filter.Items.Add(name);

            // Store where rate types start
            rateTypeStartIndex = combo_Filter.Items.Count;

            // Add unique rate types
            var rateTypes = venuesTable.AsEnumerable()
                .Select(row => row.Field<string>("fld_Rate_Type"))
                .Where(rt => !string.IsNullOrWhiteSpace(rt))
                .Distinct()
                .OrderBy(rt => rt);

            foreach (var rateType in rateTypes)
                combo_Filter.Items.Add(rateType);

            // Store where aircon options start
            airconStartIndex = combo_Filter.Items.Count;

            // Add aircon options
            combo_Filter.Items.Add("Airconditioned Yes");
            combo_Filter.Items.Add("Airconditioned No");

            combo_Filter.SelectedIndex = 0;
        }

        private void combo_Filter_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox cb = sender as ComboBox;
            e.DrawBackground();

            // Draw separator line before rate types
            if (e.Index == rateTypeStartIndex && rateTypeStartIndex > 1)
            {
                using (Pen pen = new Pen(Color.Gray, 1))
                {
                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);
                }
            }

            // Draw separator line before aircon options
            if (e.Index == airconStartIndex && airconStartIndex > 1)
            {
                using (Pen pen = new Pen(Color.Gray, 1))
                {
                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);
                }
            }

            // Draw the item text
            string text = cb.Items[e.Index].ToString();
            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, brush, e.Bounds.Left + 2, e.Bounds.Top + 2);
            }

            e.DrawFocusRectangle();
        }
        //pagionation
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ApplyFilterAndSort();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                ApplyFilterAndSort();
            }
        }

        private void lblPageInfo_Click(object sender, EventArgs e)
        {

        }

        private void panel_AddScope_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}