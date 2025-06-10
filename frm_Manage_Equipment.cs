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
    public partial class frm_Manage_Equipment : Form
    {
        private Connection db = new Connection();
        private DataTable equipmentsTable;
        public event EventHandler EquipmentAdded;
        //pagination variables
        private int pageSize = 30;
        private int currentPage = 1;
        private int totalPages = 1;

        public frm_Manage_Equipment()
        {
            InitializeComponent();

            dt_Equipments.CellContentClick += dt_Equipments_CellContentClick;
            dt_Equipments.CellClick += dt_Equipments_CellClick;
            dt_Equipments.RowPostPaint += dt_Equipments_RowPostPaint;
            dt_Equipments.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dt_Equipments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, System.Drawing.FontStyle.Bold);
            dt_Equipments.EnableHeadersVisualStyles = false;
            dt_Equipments.Columns["Delete"].Visible = false;
            dt_Equipments.CellFormatting += dt_Equipments_CellFormatting;

            txt_Search_Equipmet.ForeColor = System.Drawing.Color.Gray;
            txt_Search_Equipmet.Text = "Search Equipment";
            txt_Search_Equipmet.GotFocus += Txt_Search_GotFocus2;
            txt_Search_Equipmet.LostFocus += Txt_Search_LostFocus2;

            ShowAddEquipmentForm();

            combo_Sort.Items.Clear();
            combo_Sort.Items.AddRange(new object[] {
                "ASC",         // Equipment Name Ascending
                "DESC",        // Equipment Name Descending
                "With price",  // Price > 0
                "No Price",    // Price = 0
                "Has stock",   // Remaining Stock > 0
                "No stock"     // Remaining Stock = 0
});
            combo_Sort.SelectedIndex = 0;
            combo_Sort.SelectedIndexChanged += combo_Sort_SelectedIndexChanged;
        }

        private void frm_Manage_Equipment_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dt_Equipments_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int itemColIndex = dt_Equipments.Columns["Items"].Index;
            dt_Equipments.Rows[e.RowIndex].Cells[itemColIndex].Value = (e.RowIndex + 1).ToString();
        }

        private void Txt_Search_GotFocus2(object sender, EventArgs e)
        {
            if (txt_Search_Equipmet.Text == "Search Equipment")
            {
                txt_Search_Equipmet.Text = "";
                txt_Search_Equipmet.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void Txt_Search_LostFocus2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Search_Equipmet.Text))
            {
                txt_Search_Equipmet.Text = "Search Equipment";
                txt_Search_Equipmet.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed) db.strCon.Open();
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

            currentPage = 1;
            // Re-apply filter/sort here if needed
            UpdatePagination();
        }


        private void dt_Equipments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string colName = dt_Equipments.Columns[e.ColumnIndex].Name;

            if (colName == "fld_Equipment_Price" || colName == "fld_Equipment_Price_Subsequent")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = "₱" + value.ToString("N2");
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "fld_Total_Stock" || colName == "fld_Remaining_Stock")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("N0");
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

                if (dataGridView == dt_Equipments)
                    equipmentsTable = tempDt;

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

        private int GetEquipmentId(string equipmentName, SqlTransaction transaction)
        {
            string getIdQuery = @"SELECT e.pk_EquipmentID FROM tbl_Equipment e WHERE e.fld_Equipment_Name = @equipmentName";

            using (SqlCommand cmdGetId = new SqlCommand(getIdQuery, db.strCon, transaction))
            {
                cmdGetId.Parameters.AddWithValue("@equipmentName", equipmentName);
                return Convert.ToInt32(cmdGetId.ExecuteScalar() ?? 0);
            }
        }

        private void DeleteEquipmentReservations(int equipmentId, SqlTransaction transaction)
        {
            string deleteQuery = "DELETE FROM tbl_Reservation_Equipment WHERE fk_EquipmentID = @equipmentId";

            using (SqlCommand cmd = new SqlCommand(deleteQuery, db.strCon, transaction))
            {
                cmd.Parameters.AddWithValue("@equipmentId", equipmentId);
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

        private void ShowEditForm(string equipmentName, string equipmentPrice, string equipmentPriceSubsequent, string equipmentQuantity)
        {
            Form editForm = new Form();
            editForm.Text = "Edit Equipment";
            editForm.Size = new Size(400, 300);

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

        private void dt_Equipments_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btn_Edit_Equipment_Click(object sender, EventArgs e) { }
        private void btn_Delete_Equipment_Click(object sender, EventArgs e) { }

        private void txt_Search_Equipmet_TextChanged(object sender, EventArgs e)
        {
            if (equipmentsTable == null) return;
            string filter = txt_Search_Equipmet.Text.Replace("'", "''");
            (dt_Equipments.DataSource as DataTable).DefaultView.RowFilter =
                $"[fld_Equipment_Name] LIKE '%{filter}%'";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowAddEquipmentForm()
        {
            panel2.Controls.Clear();

            frm_Add_Equipment frmAddEquipment = new frm_Add_Equipment();
            frmAddEquipment.TopLevel = false;
            frmAddEquipment.FormBorderStyle = FormBorderStyle.None;
            frmAddEquipment.Dock = DockStyle.Fill;

            // If you have an EquipmentAdded event in frm_Add_Equipment, you can subscribe here
            frmAddEquipment.EquipmentAdded += (s, args) => {
                RefreshData();
                EquipmentAdded?.Invoke(this, EventArgs.Empty);
                panel2.Enabled = false; // Disable the panel after successful add
            };

            panel2.Controls.Add(frmAddEquipment);
            frmAddEquipment.Show();
        }

        private void combo_Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (equipmentsTable == null) return;

            string sortOption = combo_Sort.SelectedItem?.ToString();
            var view = (dt_Equipments.DataSource as DataTable).DefaultView;

            switch (sortOption)
            {
                case "ASC":
                    view.Sort = "[fld_Equipment_Name] ASC";
                    view.RowFilter = ""; // Clear filter
                    break;
                case "DESC":
                    view.Sort = "[fld_Equipment_Name] DESC";
                    view.RowFilter = "";
                    break;
                case "With price":
                    view.Sort = "";
                    view.RowFilter = "[fld_Equipment_Price] > 0";
                    break;
                case "No Price":
                    view.Sort = "";
                    view.RowFilter = "[fld_Equipment_Price] = 0";
                    break;
                case "Has stock":
                    view.Sort = "";
                    view.RowFilter = "[fld_Remaining_Stock] > 0";
                    break;
                case "No stock":
                    view.Sort = "";
                    view.RowFilter = "[fld_Remaining_Stock] = 0";
                    break;
                default:
                    view.Sort = "";
                    view.RowFilter = "";
                    break;
            }
        }

        //pagination methods
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                UpdatePagination();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                UpdatePagination();
            }
        }
        // Call this after loading or filtering data:
        private void UpdatePagination()
        {
            if (equipmentsTable == null) return;

            int rowCount = (dt_Equipments.DataSource as DataTable)?.DefaultView.Count ?? 0;
            totalPages = (int)Math.Ceiling(rowCount / (double)pageSize);
            if (currentPage > totalPages) currentPage = totalPages;
            if (currentPage < 1) currentPage = 1;

            lblPageInfo.Text = $"Page {currentPage} of {Math.Max(totalPages, 1)}";
            PaginateData();
        }

        // This method displays only the current page's rows:
        private void PaginateData()
        {
            if (equipmentsTable == null) return;

            var view = (dt_Equipments.DataSource as DataTable).DefaultView;
            DataTable pageTable = equipmentsTable.Clone();

            int startIdx = (currentPage - 1) * pageSize;
            int endIdx = Math.Min(startIdx + pageSize, view.Count);

            for (int i = startIdx; i < endIdx; i++)
                pageTable.ImportRow(view[i].Row);

            dt_Equipments.DataSource = pageTable;
        }
        // Call this after any filter/sort/search:
        private void RefreshAndPaginate()
        {
            // Re-apply filter/sort logic here if needed
            UpdatePagination();
        }

        private void btn_Add_Equipment_Click_1(object sender, EventArgs e)
        {
            panel2.Enabled = true; // Enable the panel when Add is clicked
            ShowAddEquipmentForm();
        }
    }
}