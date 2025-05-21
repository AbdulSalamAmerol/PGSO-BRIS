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
    public partial class frm_Manage_Facilities : Form
    {
        private Connection db = new Connection();
        private SqlConnection dbConnection;
        private SqlCommand cmd;

        public frm_Manage_Facilities()
        {
            InitializeComponent();
            dt_Equipments.CellContentClick += dt_Equipments_CellContentClick;
            dt_Equipments.CellClick += dt_Equipments_CellClick;
            dt_Venues.CellClick += dt_Venues_CellClick;
            dt_Venues.RowPostPaint += dt_Venues_RowPostPaint;
            dt_Equipments.RowPostPaint += dt_Equipments_RowPostPaint;
            dt_Venues.Columns["DeleteVenue"].Visible = false;
            dt_Equipments.Columns["Delete"].Visible = false;

            // Attach CellFormatting event
            dt_Venues.CellFormatting += dt_Venues_CellFormatting;
            dt_Equipments.CellFormatting += dt_Equipments_CellFormatting;

            //datagridview column header bg color
            dt_Equipments.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dt_Equipments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, System.Drawing.FontStyle.Bold); 
            dt_Equipments.EnableHeadersVisualStyles = false;

            dt_Venues.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dt_Venues.EnableHeadersVisualStyles = false;
            dt_Venues.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, System.Drawing.FontStyle.Bold);
        }


        private void frm_Manage_Facilities_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void dt_Venues_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int itemColIndex = dt_Venues.Columns["Item"].Index;
            dt_Venues.Rows[e.RowIndex].Cells[itemColIndex].Value = (e.RowIndex + 1).ToString();
        }
        private void dt_Equipments_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int itemColIndex = dt_Equipments.Columns["Items"].Index;
            dt_Equipments.Rows[e.RowIndex].Cells[itemColIndex].Value = (e.RowIndex + 1).ToString();
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
                    v.fld_Venue_Name, 
                    vs.fld_Venue_Scope_Name,
                    vp.fld_Aircon,
                    vp.fld_Rate_Type,
                    vp.fld_First4Hrs_Rate,
                    vp.fld_Hourly_Rate,
                    vp.fld_Additional_Charge
                 FROM 
                     tbl_Venue v
                 JOIN 
                    tbl_Venue_Pricing vp ON v.pk_VenueID = vp.fk_VenueID
                 JOIN 
                    tbl_Venue_Scope vs ON vs.pk_Venue_ScopeID = vp.fk_Venue_ScopeID";

                //EQUIPMENT
                string queryEquipment = @"

                SELECT 
                    e.fld_Equipment_Name, 
                    ep.fld_Equipment_Price,
                    ep.fld_Equipment_Price_Subsequent,
                    e.fld_Total_Stock,
                    e.fld_Remaining_Stock
                FROM 
                    tbl_Equipment e
                JOIN 
                    tbl_Equipment_Pricing ep ON e.pk_EquipmentID = ep.fk_EquipmentID";


                LoadData(queryEquipment, dt_Equipments, "equipment");
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



        private void dt_Equipments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string colName = dt_Equipments.Columns[e.ColumnIndex].Name;

            if (colName == "fld_Equipment_Price" || colName == "fld_Equipment_Price_Subsequent")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = "₱" + value.ToString("N2"); // Peso sign, 2 decimal places
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "fld_Total_Stock" || colName == "fld_Remaining_Stock")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("N0"); // No Peso sign, no decimal places
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
            frm_Add_Venues frm_Add_Venues = new frm_Add_Venues();
            frm_Add_Venues.Show();
        }
        //sa datagridview click for venues
        private void dt_Venues_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dt_Venues.Rows[e.RowIndex];

            if (e.ColumnIndex == dt_Venues.Columns["EditVenue"].Index)
            {
                string venueName = row.Cells["fld_Venue_Name"].Value.ToString();
                string venueScopeName = row.Cells["fld_Venue_Scope_Name"].Value.ToString();
                bool aircon = Convert.ToBoolean(row.Cells["fld_Aircon"].Value);
                string rateType = row.Cells["fld_Rate_Type"].Value.ToString();
                decimal first4HrsRate = Convert.ToDecimal(row.Cells["fld_First4Hrs_Rate"].Value);
                decimal hourlyRate = Convert.ToDecimal(row.Cells["fld_Hourly_Rate"].Value);
                decimal additionalCharge = Convert.ToDecimal(row.Cells["fld_Additional_Charge"].Value);

                ShowEditForm(venueName, venueScopeName, aircon, rateType, first4HrsRate, hourlyRate, additionalCharge);


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


        //Click the data grid view for Equipments para ma-edit or delete
        private void dt_Equipments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dt_Equipments.Rows[e.RowIndex];

                if (e.ColumnIndex == dt_Equipments.Columns["Edit"].Index)
                {
                    string equipmentName = row.Cells["fld_Equipment_Name"].Value.ToString();
                    string equipmentPrice = row.Cells["fld_Equipment_Price"].Value.ToString();
                    string equipmentPriceSubsequent = row.Cells["fld_Equipment_Price_Subsequent"].Value.ToString();

                   

                    ShowEditForm(equipmentName, equipmentPrice, equipmentPriceSubsequent, row.Cells["fld_Total_Stock"].Value.ToString());


                }
                else if (e.ColumnIndex == dt_Equipments.Columns["Delete"].Index)
                {
                    string equipmentName = row.Cells["fld_Equipment_Name"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete the equipment '{equipmentName}'?\n\nWARNING: This will also delete all reservations associated with this equipment.",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            if (db.strCon.State == ConnectionState.Closed)
                                db.strCon.Open();

                            using (SqlTransaction transaction = db.strCon.BeginTransaction())
                            {
                                try
                                {
                                    int equipmentId = GetEquipmentId(equipmentName, transaction);
                                    if (equipmentId == 0)
                                    {
                                        MessageBox.Show("Equipment not found in database!");
                                        return;
                                    }

                                    DeleteEquipmentReservations(equipmentId, transaction);
                                    DeleteEquipmentPricing(equipmentId, transaction);
                                    DeleteEquipment(equipmentId, transaction);

                                    transaction.Commit();
                                    MessageBox.Show("Equipment and all associated reservations deleted successfully!");
                                    RefreshData();
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show($"Error deleting equipment: {ex.Message}",
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

        private void DeleteEquipmentPricing(int equipmentId, SqlTransaction transaction)
        {
            string deletePricingQuery = "DELETE FROM tbl_Equipment_Pricing WHERE fk_EquipmentID = @equipmentId";
            using (SqlCommand cmd = new SqlCommand(deletePricingQuery, db.strCon, transaction))
            {
                cmd.Parameters.AddWithValue("@equipmentId", equipmentId);
                cmd.ExecuteNonQuery();
            }
        }

        private void DeleteEquipment(int equipmentId, SqlTransaction transaction)
        {
            string deleteEquipmentQuery = "DELETE FROM tbl_Equipment WHERE pk_EquipmentID = @equipmentId";
            using (SqlCommand cmd = new SqlCommand(deleteEquipmentQuery, db.strCon, transaction))
            {
                cmd.Parameters.AddWithValue("@equipmentId", equipmentId);
                cmd.ExecuteNonQuery();
            }
        }

        //Edit form for EQUIPMENTS
        private void ShowEditForm(string equipmentName, string equipmentPrice, string equipmentPriceSubsequent, string equipmentQuantity)
        {
            Form editForm = new Form();
            editForm.Text = "Edit Equipment";
            editForm.Size = new Size(400, 300);

            // Create and add controls
            Label lblName = new Label() { Text = "Equipment Name", Left = 10, Top = 20 };
            TextBox txtName = new TextBox() { Left = 150, Top = 20, Width = 200, Text = equipmentName };

            Label lblPrice = new Label() { Text = "Equipment Price", Left = 10, Top = 60 };
            TextBox txtPrice = new TextBox() { Left = 150, Top = 60, Width = 200, Text = equipmentPrice };

            Label lblPriceSubsequent = new Label() { Text = "Subsequent Price", Left = 10, Top = 100 };
            TextBox txtPriceSubsequent = new TextBox() { Left = 150, Top = 100, Width = 200, Text = equipmentPriceSubsequent };

            Label lblQuantity = new Label() { Text = "Quantity", Left = 10, Top = 140 };
            TextBox txtQuantity = new TextBox() { Left = 150, Top = 140, Width = 200, Text = equipmentQuantity };

            Button btnSave = new Button() { Text = "Save", Left = 150, Top = 180, Width = 100 };
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
                            string getIdQuery = @"
                        SELECT 
                            e.pk_EquipmentID,
                            ep.pk_Equipment_PricingID
                        FROM tbl_Equipment e
                        JOIN tbl_Equipment_Pricing ep ON e.pk_EquipmentID = ep.fk_EquipmentID
                        WHERE e.fld_Equipment_Name = @originalName";

                            int equipmentId = 0;
                            int pricingId = 0;

                            using (SqlCommand cmdGetId = new SqlCommand(getIdQuery, db.strCon, transaction))
                            {
                                cmdGetId.Parameters.AddWithValue("@originalName", equipmentName);
                                using (SqlDataReader reader = cmdGetId.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        equipmentId = reader.GetInt32(0);
                                        pricingId = reader.GetInt32(1);
                                    }
                                }
                            }

                            if (equipmentId == 0 || pricingId == 0)
                            {
                                MessageBox.Show("Equipment not found in database!");
                                return;
                            }

                            // Update equipment name and quantity if changed
                            if (txtName.Text != equipmentName || txtQuantity.Text != equipmentQuantity)
                            {
                                string updateEquipmentQuery = @"
                        UPDATE tbl_Equipment
                        SET fld_Equipment_Name = @newName, fld_Remaining_Stock = @newQuantity
                        WHERE pk_EquipmentID = @equipmentId";

                                using (SqlCommand cmdUpdate = new SqlCommand(updateEquipmentQuery, db.strCon, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@newName", txtName.Text);
                                    cmdUpdate.Parameters.AddWithValue("@newQuantity", txtQuantity.Text);
                                    cmdUpdate.Parameters.AddWithValue("@equipmentId", equipmentId);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                            }

                            // Update pricing if changed
                            bool priceChanged = txtPrice.Text != equipmentPrice;
                            bool subsequentPriceChanged = txtPriceSubsequent.Text != equipmentPriceSubsequent;

                            if (priceChanged || subsequentPriceChanged)
                            {
                                string updatePriceQuery = @"
                        UPDATE tbl_Equipment_Pricing
                        SET " +
                                    (priceChanged ? "fld_Equipment_Price = @price" : "") +
                                    (priceChanged && subsequentPriceChanged ? ", " : "") +
                                    (subsequentPriceChanged ? "fld_Equipment_Price_Subsequent = @priceSubsequent" : "") +
                                    " WHERE pk_Equipment_PricingID = @pricingId";

                                using (SqlCommand cmdPrice = new SqlCommand(updatePriceQuery, db.strCon, transaction))
                                {
                                    if (priceChanged)
                                        cmdPrice.Parameters.AddWithValue("@price", txtPrice.Text);
                                    if (subsequentPriceChanged)
                                        cmdPrice.Parameters.AddWithValue("@priceSubsequent", txtPriceSubsequent.Text);
                                    cmdPrice.Parameters.AddWithValue("@pricingId", pricingId);
                                    cmdPrice.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Equipment updated successfully!");
                            editForm.Close();
                            RefreshData();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error updating equipment: {ex.Message}\n\nPlease check if the equipment name already exists.",
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

            editForm.Controls.Add(lblName);
            editForm.Controls.Add(txtName);
            editForm.Controls.Add(lblPrice);
            editForm.Controls.Add(txtPrice);
            editForm.Controls.Add(lblPriceSubsequent);
            editForm.Controls.Add(txtPriceSubsequent);
            editForm.Controls.Add(lblQuantity);
            editForm.Controls.Add(txtQuantity);
            editForm.Controls.Add(btnSave);

            editForm.Show();
        }

        //Edit form for Venues
        private void ShowEditForm(string venueName, string venueScopeName, bool aircon, string rateType,
    decimal first4HrsRate, decimal hourlyRate, decimal additionalCharge)
        {
            Form editForm = new Form();
            editForm.Text = "Edit Venue";
            editForm.Size = new Size(400, 380);

            // Create and add controls
            Label lblVenueName = new Label() { Text = "Venue Name", Left = 10, Top = 20, Font = new Font("Century Gothic", 11, FontStyle.Bold) };
            TextBox txtVenueName = new TextBox() { Left = 150, Top = 20, MinimumSize = new Size(200, 25), Font = new Font("Century Gothic", 11, FontStyle.Regular), Text = venueName };

            Label lblVenueScopeName = new Label() { Text = "Venue Scope Name", Left = 10, Top = 60, Font = new Font("Century Gothic", 11, FontStyle.Bold) };
            TextBox txtVenueScopeName = new TextBox() { Left = 150, Top = 60, MinimumSize = new Size(200, 25), Font = new Font("Century Gothic", 11, FontStyle.Regular), Text = venueScopeName };

            Label lblAircon = new Label() { Text = "Aircon", Left = 10, Top = 100, Font = new Font("Century Gothic", 11, FontStyle.Bold) };
            CheckBox chkAircon = new CheckBox() { Left = 150, Top = 100, Checked = aircon};

            Label lblRateType = new Label() { Text = "Rate Type", Left = 10, Top = 140, Font = new Font("Century Gothic", 11, FontStyle.Bold) };
            TextBox txtRateType = new TextBox() { Left = 150, Top = 140, MinimumSize = new Size(200, 25), Font = new Font("Century Gothic", 11, FontStyle.Regular), Text = rateType };

            Label lblFirst4HrsRate = new Label() { Text = "First 4 Hrs Rate", Left = 10, Top = 180, Font = new Font("Century Gothic", 11, FontStyle.Bold) };
            TextBox txtFirst4HrsRate = new TextBox() { Left = 150, Top = 180, MinimumSize = new Size(200, 25), Font = new Font("Century Gothic", 11, FontStyle.Regular), Text = first4HrsRate.ToString() };

            Label lblHourlyRate = new Label() { Text = "Hourly Rate", Left = 10, Top = 220, Font = new Font("Century Gothic", 11, FontStyle.Bold) };
            TextBox txtHourlyRate = new TextBox() { Left = 150, Top = 220, MinimumSize = new Size(200, 25), Font = new Font("Century Gothic", 11, FontStyle.Regular), Text = hourlyRate.ToString() };

            Label lblAdditionalCharge = new Label() { Text = "Additional Charge", Left = 10, Top = 260, Font = new Font("Century Gothic", 11, FontStyle.Bold) };
            TextBox txtAdditionalCharge = new TextBox() { Left = 150, Top = 260, MinimumSize = new Size(200, 25), Font = new Font("Century Gothic", 11, FontStyle.Regular), Text = additionalCharge.ToString() };

            Button btnSave = new Button() { Text = "Save", Left = 150, Top = 300, MinimumSize = new Size(200, 30), Font = new Font("Century Gothic", 11, FontStyle.Regular) };
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
                            string getIdQuery = @"
                            SELECT 
                                v.pk_VenueID
                            FROM tbl_Venue v
                            WHERE v.fld_Venue_Name = @originalName";

                            int venueId = 0;

                            using (SqlCommand cmdGetId = new SqlCommand(getIdQuery, db.strCon, transaction))
                            {
                                cmdGetId.Parameters.AddWithValue("@originalName", venueName);
                                using (SqlDataReader reader = cmdGetId.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        venueId = reader.GetInt32(0);
                                    }
                                }
                            }

                            if (venueId == 0)
                            {
                                MessageBox.Show("Venue not found in database!");
                                return;
                            }

                            // Track if any changes were made
                            bool changesMade = false;

                            // Update pricing if changed
                            bool airconChanged = chkAircon.Checked != aircon;
                            bool rateTypeChanged = txtRateType.Text != rateType;
                            bool first4HrsRateChanged = decimal.Parse(txtFirst4HrsRate.Text) != first4HrsRate;
                            bool hourlyRateChanged = decimal.Parse(txtHourlyRate.Text) != hourlyRate;
                            bool additionalChargeChanged = decimal.Parse(txtAdditionalCharge.Text) != additionalCharge;

                            if (airconChanged || rateTypeChanged || first4HrsRateChanged || hourlyRateChanged || additionalChargeChanged)
                            {
                                changesMade = true;

                                string updatePriceQuery = @"
                                UPDATE tbl_Venue_Pricing
                                SET " +
                                (airconChanged ? "fld_Aircon = @aircon" : "") +
                                (airconChanged && rateTypeChanged ? ", " : "") +
                                (rateTypeChanged ? "fld_Rate_Type = @rateType" : "") +
                                ((airconChanged || rateTypeChanged) && first4HrsRateChanged ? ", " : "") +
                                (first4HrsRateChanged ? "fld_First4Hrs_Rate = @first4HrsRate" : "") +
                                ((airconChanged || rateTypeChanged || first4HrsRateChanged) && hourlyRateChanged ? ", " : "") +
                                (hourlyRateChanged ? "fld_Hourly_Rate = @hourlyRate" : "") +
                                ((airconChanged || rateTypeChanged || first4HrsRateChanged || hourlyRateChanged) && additionalChargeChanged ? ", " : "") +
                                (additionalChargeChanged ? "fld_Additional_Charge = @additionalCharge" : "") +
                                " WHERE fk_VenueID = @venueId AND fk_Venue_ScopeID = (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = @scopeName) " +
                                "AND fld_Rate_Type = @originalRateType AND fld_Aircon = @originalAircon " +
                                "AND fld_Hourly_Rate = @originalHourlyRate AND fld_Additional_Charge = @originalAdditionalCharge";

                                using (SqlCommand cmdPrice = new SqlCommand(updatePriceQuery, db.strCon, transaction))
                                {
                                    if (airconChanged)
                                        cmdPrice.Parameters.AddWithValue("@aircon", chkAircon.Checked);
                                    if (rateTypeChanged)
                                        cmdPrice.Parameters.AddWithValue("@rateType", txtRateType.Text);
                                    if (first4HrsRateChanged)
                                        cmdPrice.Parameters.AddWithValue("@first4HrsRate", decimal.Parse(txtFirst4HrsRate.Text));
                                    if (hourlyRateChanged)
                                        cmdPrice.Parameters.AddWithValue("@hourlyRate", decimal.Parse(txtHourlyRate.Text));
                                    if (additionalChargeChanged)
                                        cmdPrice.Parameters.AddWithValue("@additionalCharge", decimal.Parse(txtAdditionalCharge.Text));

                                    cmdPrice.Parameters.AddWithValue("@originalRateType", rateType);
                                    cmdPrice.Parameters.AddWithValue("@originalAircon", aircon);
                                    cmdPrice.Parameters.AddWithValue("@originalHourlyRate", hourlyRate);
                                    cmdPrice.Parameters.AddWithValue("@originalAdditionalCharge", additionalCharge);

                                    cmdPrice.Parameters.AddWithValue("@scopeName", txtVenueScopeName.Text);
                                    cmdPrice.Parameters.AddWithValue("@venueId", venueId);
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

                            // Update venue scope if changed
                            if (txtVenueScopeName.Text != venueScopeName)
                            {
                                changesMade = true;

                                string updateScopeQuery = @"
                                UPDATE tbl_Venue_Scope
                                SET fld_Venue_Scope_Name = @newScopeName
                                WHERE pk_Venue_ScopeID = (
                                    SELECT fk_Venue_ScopeID
                                    FROM tbl_Venue_Pricing
                                    WHERE fk_VenueID = @venueId
                                )";

                                using (SqlCommand cmdUpdateScope = new SqlCommand(updateScopeQuery, db.strCon, transaction))
                                {
                                    cmdUpdateScope.Parameters.AddWithValue("@newScopeName", txtVenueScopeName.Text);
                                    cmdUpdateScope.Parameters.AddWithValue("@venueId", venueId);
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
            editForm.Controls.Add(lblAircon);
            editForm.Controls.Add(chkAircon);
            editForm.Controls.Add(lblRateType);
            editForm.Controls.Add(txtRateType);
            editForm.Controls.Add(lblFirst4HrsRate);
            editForm.Controls.Add(txtFirst4HrsRate);
            editForm.Controls.Add(lblHourlyRate);
            editForm.Controls.Add(txtHourlyRate);
            editForm.Controls.Add(lblAdditionalCharge);
            editForm.Controls.Add(txtAdditionalCharge);
            editForm.Controls.Add(btnSave);

            editForm.Show();
        }



        // Other existing methods
        private void dt_Equipments_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btn_Edit_Equipment_Click(object sender, EventArgs e) { }
        private void btn_Delete_Equipment_Click(object sender, EventArgs e) { }
        private void dt_Venues_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void btn_AddScope_Click(object sender, EventArgs e)
        {
            frm_Add_Scope frm_Add_Scope = new frm_Add_Scope();
            frm_Add_Scope.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}