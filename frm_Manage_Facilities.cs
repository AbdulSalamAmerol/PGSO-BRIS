﻿using pgso_connect;
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

        }


        private void frm_Manage_Facilities_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

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

                string queryEquipment = @"
                     SELECT 
                         e.fld_Equipment_Name, 
                         ep.fld_Equipment_Price,
                         ep.fld_Equipment_Price_Subsequent
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

                    ShowEditForm(equipmentName, equipmentPrice, equipmentPriceSubsequent);
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
        {
            // Delete reservations that are specifically for this venue
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

        // Edit forms (remain unchanged from previous version)
        // Edit forms
        private void ShowEditForm(string equipmentName, string equipmentPrice, string equipmentPriceSubsequent)
        {
            Form editForm = new Form();
            editForm.Text = "Edit Equipment";
            editForm.Size = new Size(400, 250);

            // Create and add controls
            Label lblName = new Label() { Text = "Equipment Name", Left = 10, Top = 20 };
            TextBox txtName = new TextBox() { Left = 150, Top = 20, Width = 200, Text = equipmentName };

            Label lblPrice = new Label() { Text = "Equipment Price", Left = 10, Top = 60 };
            TextBox txtPrice = new TextBox() { Left = 150, Top = 60, Width = 200, Text = equipmentPrice };

            Label lblPriceSubsequent = new Label() { Text = "Subsequent Price", Left = 10, Top = 100 };
            TextBox txtPriceSubsequent = new TextBox() { Left = 150, Top = 100, Width = 200, Text = equipmentPriceSubsequent };

            Button btnSave = new Button() { Text = "Save", Left = 150, Top = 140, Width = 100 };
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

                            // Update equipment name if changed
                            if (txtName.Text != equipmentName)
                            {
                                string updateNameQuery = @"
                            UPDATE tbl_Equipment
                            SET fld_Equipment_Name = @newName
                            WHERE pk_EquipmentID = @equipmentId";

                                using (SqlCommand cmdName = new SqlCommand(updateNameQuery, db.strCon, transaction))
                                {
                                    cmdName.Parameters.AddWithValue("@newName", txtName.Text);
                                    cmdName.Parameters.AddWithValue("@equipmentId", equipmentId);
                                    cmdName.ExecuteNonQuery();
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
            editForm.Controls.Add(btnSave);

            editForm.Show();
        }

        private void ShowEditForm(string venueName, string venueScopeName, bool aircon, string rateType,
    decimal first4HrsRate, decimal hourlyRate, decimal additionalCharge)
        {
            Form editForm = new Form();
            editForm.Text = "Edit Venue";
            editForm.Size = new Size(400, 350);

            // Create and add controls
            Label lblVenueName = new Label() { Text = "Venue Name", Left = 10, Top = 20 };
            TextBox txtVenueName = new TextBox() { Left = 150, Top = 20, Width = 200, Text = venueName };

            Label lblVenueScopeName = new Label() { Text = "Venue Scope Name", Left = 10, Top = 60 };
            TextBox txtVenueScopeName = new TextBox() { Left = 150, Top = 60, Width = 200, Text = venueScopeName };

            Label lblAircon = new Label() { Text = "Aircon", Left = 10, Top = 100 };
            CheckBox chkAircon = new CheckBox() { Left = 150, Top = 100, Checked = aircon };

            Label lblRateType = new Label() { Text = "Rate Type", Left = 10, Top = 140 };
            TextBox txtRateType = new TextBox() { Left = 150, Top = 140, Width = 200, Text = rateType };

            Label lblFirst4HrsRate = new Label() { Text = "First 4 Hrs Rate", Left = 10, Top = 180 };
            TextBox txtFirst4HrsRate = new TextBox() { Left = 150, Top = 180, Width = 200, Text = first4HrsRate.ToString() };

            Label lblHourlyRate = new Label() { Text = "Hourly Rate", Left = 10, Top = 220 };
            TextBox txtHourlyRate = new TextBox() { Left = 150, Top = 220, Width = 200, Text = hourlyRate.ToString() };

            Label lblAdditionalCharge = new Label() { Text = "Additional Charge", Left = 10, Top = 260 };
            TextBox txtAdditionalCharge = new TextBox() { Left = 150, Top = 260, Width = 200, Text = additionalCharge.ToString() };

            Button btnSave = new Button() { Text = "Save", Left = 150, Top = 300, Width = 100 };
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

                            // Update venue name if changed
                            if (txtVenueName.Text != venueName)
                            {
                                string updateNameQuery = @"
                            UPDATE tbl_Venue
                            SET fld_Venue_Name = @newName
                            WHERE pk_VenueID = @venueId";

                                using (SqlCommand cmdName = new SqlCommand(updateNameQuery, db.strCon, transaction))
                                {
                                    cmdName.Parameters.AddWithValue("@newName", txtVenueName.Text);
                                    cmdName.Parameters.AddWithValue("@venueId", venueId);
                                    cmdName.ExecuteNonQuery();
                                }
                            }

                            // Update venue scope name if changed
                            if (txtVenueScopeName.Text != venueScopeName)
                            {
                                string updateScopeNameQuery = @"
                            UPDATE tbl_Venue_Scope
                            SET fld_Venue_Scope_Name = @newScopeName
                            WHERE pk_Venue_ScopeID = 
                                (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = @originalScopeName)";

                                using (SqlCommand cmdScopeName = new SqlCommand(updateScopeNameQuery, db.strCon, transaction))
                                {
                                    cmdScopeName.Parameters.AddWithValue("@newScopeName", txtVenueScopeName.Text);
                                    cmdScopeName.Parameters.AddWithValue("@originalScopeName", venueScopeName);
                                    cmdScopeName.ExecuteNonQuery();
                                }
                            }

                            // Update pricing if changed
                            bool airconChanged = chkAircon.Checked != aircon;
                            bool rateTypeChanged = txtRateType.Text != rateType;
                            bool first4HrsRateChanged = decimal.Parse(txtFirst4HrsRate.Text) != first4HrsRate;
                            bool hourlyRateChanged = decimal.Parse(txtHourlyRate.Text) != hourlyRate;
                            bool additionalChargeChanged = decimal.Parse(txtAdditionalCharge.Text) != additionalCharge;

                            if (airconChanged || rateTypeChanged || first4HrsRateChanged || hourlyRateChanged || additionalChargeChanged)
                            {
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
                                    " WHERE fk_VenueID = @venueId";

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
                                    cmdPrice.Parameters.AddWithValue("@venueId", venueId);
                                    cmdPrice.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Venue updated successfully!");
                            editForm.Close();
                            RefreshData();
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
    }
}