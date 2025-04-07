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
    public partial class frm_Venues : Form
    {
        //fields
        private Connection db = new Connection(); // Use the Connection class
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt = new DataTable();
        private BindingSource bindingSource = new BindingSource();
        public event EventHandler DashboardRefreshRequested;
        private bool isProcessingApproval = false; // Flag to prevent re-entry

        // Method to raise the event
        protected virtual void OnDashboardRefreshRequested()
        {
            DashboardRefreshRequested?.Invoke(this, EventArgs.Empty);
        }

        public frm_Venues()
        {
            InitializeComponent();
            // dt_pendings.CellContentClick += dt_pendings_CellContentClick;
            //dt_pendings.CellClick += dt_pendings_CellClick; // Handle button click event properly
            dt_all.CellClick += dt_all_CellClick; // Handle cell click event

            // Populate the ComboBox with filter options
            combobox_Filter.Items.AddRange(new string[] { "All", "Pending", "Cancelled", "Confirmed" });
            combobox_Filter.SelectedIndexChanged += combobox_Filter_SelectedIndexChanged;
        }

        private void frm_Venues_Load(object sender, EventArgs e)
        {
            RefreshData();
            // Subscribe to the CellFormatting event for each DataGridView
            dt_all.CellFormatting += DataGridView_CellFormatting;
        }

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

        private void dt_all_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = dt_all.Rows[e.RowIndex];

                // Populate the basic information
                txt_CN.Text = row.Cells["fld_Control_number"].Value.ToString();
                txt_Status.Text = row.Cells["fld_Reservation_Status"].Value.ToString();
                txt_Total.Text = row.Cells["fld_Total_Amount"].Value.ToString();
                txt_Venue_Name.Text = row.Cells["fld_Venue_Name"].Value.ToString();

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
                rp.fld_Requesting_Person_Address,
                rp.fld_Requesting_Office,
                r.fld_Start_Date,
                r.fld_End_Date,
                r.fld_Start_Time,
                r.fld_End_Time,
                r.fld_Activity_Name,
                vp.fld_Rate_Type,
                vs.fld_Venue_Scope_Name,
                r.fld_Number_Of_Participants
            FROM 
                tbl_Reservation r
            LEFT JOIN 
                tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
            LEFT JOIN
                tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
            LEFT JOIN
            tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
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
                            txt_Activity_Name.Text = reader["fld_Activity_Name"].ToString();
                            txt_Rate_Type.Text = reader["fld_Rate_Type"].ToString();
                            txt_Venue_Scope.Text = reader["fld_Venue_Scope_Name"].ToString();
                            txt_Requesting_Office.Text = reader["fld_Requesting_Office"].ToString();
                            txt_Num_Participants.Text = reader["fld_Number_Of_Participants"].ToString();
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

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // List of columns to format
            string[] targetColumns = { "fld_Total_Amount1", "fld_Total_Amount2", "fld_Total_Amount3" };

            DataGridView gridView = (DataGridView)sender;

            foreach (string columnName in targetColumns)
            {
                if (e.ColumnIndex == GetColumnIndexByName(gridView, columnName) && e.Value != null)
                {
                    // Format the value with commas as thousand separators
                    if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                    {
                        e.Value = amount.ToString("N2"); // "N2" formats with commas and 2 decimal places
                        e.FormattingApplied = true;
                    }
                    break;
                }
            }
        }

        // Helper method to get the column index by name
        private int GetColumnIndexByName(DataGridView dataGridView, string columnName)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Name == columnName)
                {
                    return column.Index;
                }
            }
            return -1; // Column not found
        }

        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open(); // Open the database connection if not already open

                // Queries to fetch data    
                string queryAll = @"
        SELECT 
            r.fld_Control_number, 
            r.fld_Reservation_Status,
            r.fld_Total_Amount,
            v.fld_Venue_Name,
            rp.fld_First_Name,
            rp.fld_Surname
        FROM 
            tbl_Reservation r
        LEFT JOIN
            tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
        LEFT JOIN
            tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
        WHERE 
            r.fld_Reservation_Type = 'Venue'";

                // Load data into DataGridViews
                LoadData(queryAll, dt_all, "Reservations");

                // Check if there are no pending reservations
                if (dt_all.Rows.Count == 0)
                {
                    MessageBox.Show("No Reservation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        //=====================END===============================

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

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            string filterText = txt_Search.Text.Trim();
            if (string.IsNullOrEmpty(filterText))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                bindingSource.Filter = $"fld_Control_number LIKE '%{filterText}%' OR fld_Venue_Name LIKE '%{filterText}%' OR fld_First_Name LIKE '%{filterText}%' OR fld_Surname LIKE '%{filterText}%'";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void lbl_canceled_Click(object sender, EventArgs e) { }

        private void dt_canceled_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btn_Approve_Click(object sender, EventArgs e) { }

        private void ApproveReservation(string controlNumber) { }

        private void CancelReservation(string controlNumber) { }

        private void btn_Cancel_Click_1(object sender, EventArgs e) { }

        private void panel_Information_Paint(object sender, PaintEventArgs e) { }
    }
}
