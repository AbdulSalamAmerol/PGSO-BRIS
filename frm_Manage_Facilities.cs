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
        //fields
        private Connection db = new Connection(); // Use the Connection class
        private SqlConnection dbConnection; // Rename the field to avoid ambiguity
        private SqlCommand cmd;

        public frm_Manage_Facilities()
        {
            InitializeComponent();
            dt_Equipments.CellContentClick += dt_Equipments_CellContentClick; // Add event handler
        }

        private void frm_Manage_Facilities_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void DBConnect()
        {
            try
            {
                Connection dbConn = new Connection(); // Create new instance of connection class
                dbConnection = dbConn.strCon; // Get connection
                dbConnection.Open(); // Open connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connection: " + ex.Message);
            }
        }

        // Close database connection
        private void DBClose()
        {
            if (dbConnection != null && dbConnection.State == ConnectionState.Open)
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }
        }

        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open(); // Open the database connection if not already open
                string queryEquipment = @"
                     SELECT 
                         e.fld_Equipment_Name, 
                         ep.fld_Equipment_Price,
                         ep.fld_Equipment_Price_Subsequent
                     FROM 
                         tbl_Equipment e
                     JOIN 
                        tbl_Equipment_Pricing ep ON e.pk_EquipmentID = ep.fk_EquipmentID ";

                LoadData(queryEquipment, dt_Equipments, "equipment");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close(); // Close the database connection
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

                // Set AutoGenerateColumns to true
                dataGridView.AutoGenerateColumns = true;

                // Bind the data
                dataGridView.DataSource = tempDt;

                // Display a message if no data is found
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

        private void dt_Equipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dt_Equipments.Rows[e.RowIndex];
                string equipmentName = row.Cells["fld_Equipment_Name"].Value.ToString();
                string equipmentPrice = row.Cells["fld_Equipment_Price"].Value.ToString();
                string equipmentPriceSubsequent = row.Cells["fld_Equipment_Price_Subsequent"].Value.ToString();

                ShowEditForm(equipmentName, equipmentPrice, equipmentPriceSubsequent);
            }
        }

        private void btn_Edit_Equipment_Click(object sender, EventArgs e)
        {
            if (dt_Equipments.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dt_Equipments.SelectedRows[0];
                string equipmentName = row.Cells["fld_Equipment_Name"].Value.ToString();
                string equipmentPrice = row.Cells["fld_Equipment_Price"].Value.ToString();
                string equipmentPriceSubsequent = row.Cells["fld_Equipment_Price_Subsequent"].Value.ToString();

                ShowEditForm(equipmentName, equipmentPrice, equipmentPriceSubsequent);
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async void ShowEditForm(string equipmentName, string equipmentPrice, string equipmentPriceSubsequent)
        {
            // Create a new form dynamically
            Form editForm = new Form();
            editForm.Text = "Edit Equipment";
            editForm.Size = new Size(400, 250); // Set the size of the form

            // Create and add controls to the form
            Label lblName = new Label() { Text = "Equipment Name", Left = 10, Top = 20 };
            TextBox txtName = new TextBox() { Left = 150, Top = 20, Width = 200, Text = equipmentName };

            Label lblPrice = new Label() { Text = "Equipment Price", Left = 10, Top = 60 };
            TextBox txtPrice = new TextBox() { Left = 150, Top = 60, Width = 200, Text = equipmentPrice };

            Label lblPriceSubsequent = new Label() { Text = "Subsequent Price", Left = 10, Top = 100 };
            TextBox txtPriceSubsequent = new TextBox() { Left = 150, Top = 100, Width = 200, Text = equipmentPriceSubsequent };

            Button btnSave = new Button() { Text = "Save", Left = 150, Top = 140, Width = 100 };
            btnSave.Click += async (s, args) =>
            {
                try
                {
                    if (db.strCon.State == ConnectionState.Closed)
                        db.strCon.Open();

                    using (SqlTransaction transaction = db.strCon.BeginTransaction())
                    {
                        try
                        {
                            // 1. First get both the EquipmentID and PricingID
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
                                using (SqlDataReader reader = await cmdGetId.ExecuteReaderAsync())
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

                            // 2. Update equipment name if changed
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
                                    await cmdName.ExecuteNonQueryAsync();
                                }
                            }

                            // 3. Update pricing if changed
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
                                    await cmdPrice.ExecuteNonQueryAsync();
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

            // Show the form immediately
            editForm.Show();

            // Perform any additional operations asynchronously
            await Task.Run(() =>
            {
                // Simulate a delay for demonstration purposes
                System.Threading.Thread.Sleep(1000);
            });
        }
    }
}
