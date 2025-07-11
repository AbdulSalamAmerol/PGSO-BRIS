﻿using pgso_connect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso
{
   
    public partial class frm_Add_Equipment: Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private readonly Connection db = new Connection();
        public event EventHandler EquipmentAdded;
        public frm_Add_Equipment()
        {
            InitializeComponent();
            txt_Quantity.TextChanged += txt_Quantity_TextChanged;
            txt_Stock.ReadOnly = true; // Make sure this is set
        }
        private void frm_Add_Equipment_Load(object sender, EventArgs e)
        {
            // Add your load event logic here
        }

        private void DBConnect()
        {
            try
            {
                conn = db.strCon;
                if (conn == null)
                {
                    throw new Exception("Connection string is null.");
                }
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connection: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void DBClose()
        {
            try
            {
                if (conn?.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing connection: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Submit_Add_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txt_Equipment_Name_Add.Text))
            {
                MessageBox.Show("Please enter equipment name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_Price_Add.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_Price_Subsequent_Add.Text, out decimal subsequentPrice) || subsequentPrice < 0)
            {
                MessageBox.Show("Please enter a valid subsequent price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlTransaction transaction = null;
            if (!int.TryParse(txt_Quantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DBConnect();
                transaction = conn.BeginTransaction();


                // 1. Insert into Equipment table and get the new ID
                cmd = new SqlCommand(
                @"INSERT INTO tbl_Equipment (fld_Equipment_Name, fld_Total_Stock, fld_Remaining_Stock) 
                          OUTPUT INSERTED.pk_EquipmentID 
                          VALUES (@EquipmentName, @TotalStock, @RemainingStock)",
                conn, transaction);

                cmd.Parameters.AddWithValue("@EquipmentName", txt_Equipment_Name_Add.Text);
                cmd.Parameters.AddWithValue("@TotalStock", quantity);
                cmd.Parameters.AddWithValue("@RemainingStock", quantity);
                int newEquipmentId = (int)cmd.ExecuteScalar();


                // 2. Insert into Equipment Pricing with the foreign key
                cmd = new SqlCommand(
                    @"INSERT INTO tbl_Equipment_Pricing 
                      (fld_Equipment_Price, fld_Equipment_Price_Subsequent, fk_EquipmentID) 
                      VALUES (@Price, @SubsequentPrice, @EquipmentID)",
                    conn, transaction);

                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@SubsequentPrice", subsequentPrice);
                cmd.Parameters.AddWithValue("@EquipmentID", newEquipmentId);
                cmd.ExecuteNonQuery();


                // auditlog start
                string affectedTable = "tbl_Equipment";
                string affectedRecordPk = newEquipmentId.ToString();
                string actionType = "Added Equipment";

                string changedBy = frm_login.LoggedInUserRole;
                DateTime changedAt = DateTime.Now;
                int userId = frm_login.LoggedInUserId;

                // Serialize new equipment data for audit log
                string newDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    EquipmentName = txt_Equipment_Name_Add.Text,
                    Price = price,
                    SubsequentPrice = subsequentPrice,
                    Quantity = quantity
                });

                using (SqlCommand auditCmd = new SqlCommand(@"
                INSERT INTO tbl_Audit_Log
                (fk_UserID, fld_Affected_Table, fld_Affected_Record_PK, fld_ActionType, fld_Previous_Data_Json, fld_New_Data_Json, fld_Changed_By, fld_Changed_At)
                VALUES (@UserID, @Table, @RecordPK, @ActionType, @PrevJson, @NewJson, @ChangedBy, @ChangedAt)", conn, transaction))
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

                MessageBox.Show("Equipment added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Raise the event so the parent can refresh
                EquipmentAdded?.Invoke(this, EventArgs.Empty);

                // Clear form after successful submission
                ClearForm();
            }
            catch (SqlException sqlEx)
            {
                transaction?.Rollback();
                MessageBox.Show($"Database error: {sqlEx.Message}\nError Number: {sqlEx.Number}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                transaction?.Dispose();
                DBClose();
            }
        }

        private void ClearForm()
        {
            
                txt_Equipment_Name_Add.Clear();
                txt_Price_Add.Clear();
                txt_Price_Subsequent_Add.Clear();
                txt_Quantity.Clear();
                txt_Stock.Clear();
                txt_Equipment_Name_Add.Focus();
            }

        private void btn_Cancel_Add_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Input validation for price fields
        private void txt_Price_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox)?.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_Price_Subsequent_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_Price_Add_KeyPress(sender, e); // Reuse the same validation
        }

        private void panel_Add_Equipment_Paint(object sender, PaintEventArgs e)
        {
            // Handle panel paint event if needed
        }

        private void txt_Equipment_Name_Add_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Price_Add_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Price_Subsequent_Add_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            txt_Stock.Text = txt_Quantity.Text;
        }


    }


}
