using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using pgso_connect; //pinalitan ko namespaces. From pgso to pgso_connect

namespace pgso
{
    //NAKA LOCAL HOST LANG YUNG DATABASE KO. PALITAN LATUR.
    public partial class frm_Equipment : Form
    {
        //fields
        private Connection db = new Connection(); // Use the Connection class
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt = new DataTable();
        private BindingSource bindingSource = new BindingSource();
        public event EventHandler DashboardRefreshRequested;

        // Method to raise the event
        protected virtual void OnDashboardRefreshRequested()
        {
            DashboardRefreshRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btn_ToDashboard_Click(object sender, EventArgs e)
        {
            // Raise the event
            OnDashboardRefreshRequested();
            // Close the form
            this.Close();
        }

        public frm_Equipment()
        {
            InitializeComponent();
            dt_equipment.CellClick += dt_equipment_CellClick; // Handle cell click event

            // Populate the ComboBox with filter options
            combobox_Filter.Items.AddRange(new string[] { "All", "Pending", "Cancelled", "Confirmed" });
            combobox_Filter.SelectedIndexChanged += combobox_Filter_SelectedIndexChanged; // Add event handler
        }

        private void frm_Equipment_Load(object sender, EventArgs e)
        {
            RefreshData();
            // Subscribe to the CellFormatting event for each DataGridView
            //dt_pendings.CellFormatting += DataGridView_CellFormatting;
        }

        // ComboBox selection change event handler
        private void combobox_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                string selectedStatus = comboBox.SelectedItem.ToString();
                if (selectedStatus == "All")
                {
                    bindingSource.RemoveFilter();
                }
                else
                {
                    bindingSource.Filter = $"fld_Reservation_Status = '{selectedStatus}'";
                }
            }
        }

        private void dt_equipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = dt_equipment.Rows[e.RowIndex];

                // Populate the basic information
                txt_CN.Text = row.Cells["fld_Control_number"].Value.ToString();
                txt_Status.Text = row.Cells["fld_Reservation_Status"].Value.ToString();
                txt_Total.Text = row.Cells["fld_Total_Amount"].Value.ToString();
                txt_Equipment_Name.Text = row.Cells["fld_Equipment_Name"].Value.ToString();

                // Fetch and display additional information
                string controlNumber = row.Cells["fld_Control_number"].Value.ToString();
                FetchAndDisplayAdditionalInfo(controlNumber);
            }
        }

        private void FetchAndDisplayAdditionalInfo(string controlNumber)
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = @"
        SELECT 
            rp.fld_First_Name, 
            rp.fld_Surname,
            rp.fld_Requesting_Office,
            rp.fld_Requesting_Person_Address,
            r.fld_Start_Date,
            r.fld_End_Date,
            r.fld_Start_Time,
            r.fld_End_Time,
            r.fld_Activity_Name,
            r.fld_Reservation_Type,
            r.fld_Number_Of_Participants,
            e.fld_Equipment_Name,
            rpe.fld_Number_Of_Days,
            rpe.fld_Quantity
        FROM 
            tbl_Reservation r
        LEFT JOIN 
            tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
        LEFT JOIN 
            tbl_Reservation_Equipment rpe ON r.pk_ReservationID = rpe.fk_ReservationID
        LEFT JOIN
            tbl_Equipment e ON rpe.fk_EquipmentID = e.pk_EquipmentID
        WHERE 
            r.fld_Control_number = @ControlNumber";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_Fname.Text = reader["fld_First_Name"].ToString();
                            txt_Sname.Text = reader["fld_Surname"].ToString();
                            txt_Address.Text = reader["fld_Requesting_Person_Address"].ToString();
                            txt_Date_Start.Text = Convert.ToDateTime(reader["fld_Start_Date"]).ToString("yyyy-MM-dd");
                            txt_DateEnd.Text = Convert.ToDateTime(reader["fld_End_Date"]).ToString("yyyy-MM-dd");
                            txt_HourStart.Text = TimeSpan.Parse(reader["fld_Start_Time"].ToString()).ToString(@"hh\:mm");
                            txt_HourEnd.Text = TimeSpan.Parse(reader["fld_End_Time"].ToString()).ToString(@"hh\:mm");
                            txt_Purpose.Text = reader["fld_Activity_Name"].ToString();
                            txt_Quantity.Text = reader["fld_Number_Of_Participants"].ToString();
                            txt_Equipment_Name.Text = reader["fld_Equipment_Name"].ToString();
                            txt_Number_of_Days.Text = reader["fld_Number_Of_Days"].ToString();
                            txt_Quantity.Text = reader["fld_Quantity"].ToString();
                            txt_Requesting_Office.Text = reader["fld_Requesting_Office"].ToString();
                            txt_Reservation_type.Text = reader["fld_Reservation_Type"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching additional information: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }

        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open(); // Open the database connection if not already open

                // Query for pending reservations
                string queryApproved = @"
                    SELECT 
                        r.fld_Control_number, 
                        r.fld_Reservation_Status,
                        r.fld_Total_Amount,
                        e.fld_Equipment_Name,
                        rpe.fld_Number_Of_Days,
                        rpe.fld_Quantity,
                        rp.fld_First_Name,
                        rp.fld_Surname
                    FROM 
                        tbl_Reservation r
                    LEFT JOIN
                        tbl_Reservation_Equipment rpe ON r.pk_ReservationID = rpe.fk_ReservationID
                    LEFT JOIN
                        tbl_Equipment e ON rpe.fk_EquipmentID = e.pk_EquipmentID
                    LEFT JOIN
                        tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    WHERE  
                        r.fld_Reservation_Type = 'Equipment'";

                LoadData(queryApproved, dt_equipment, "Approved");
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

        // Helper METHOD to execute a query and bind data to a DataGridView
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

                // Set AutoGenerateColumns to false
                dataGridView.AutoGenerateColumns = false;

                // Bind the data to the BindingSource
                bindingSource.DataSource = tempDt;
                dataGridView.DataSource = bindingSource;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(filterText))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                bindingSource.Filter = $"fld_Control_number LIKE '%{filterText}%' OR fld_Equipment_Name LIKE '%{filterText}%' OR fld_First_Name LIKE '%{filterText}%' OR fld_Surname LIKE '%{filterText}%'";
            }
        }
    }
}
