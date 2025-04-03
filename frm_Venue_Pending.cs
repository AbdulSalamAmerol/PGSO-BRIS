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
using pgso_connect;//pinalitan ko namespaces. From pgso to pgso_connect

namespace pgso
{

    //NAKA LOCAL HOST LANG YUNG DATABASE KO. PALITAN LATUR.
    public partial class frm_Venue_Pending : Form
    {
        //fields
        private Connection db = new Connection(); // Use the Connection class
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt = new DataTable();
        public event EventHandler DashboardRefreshRequested;
        private bool isProcessingApproval = false; // Flag to prevent re-entry


        // Method to raise the event
        protected virtual void OnDashboardRefreshRequested()
        {
            DashboardRefreshRequested?.Invoke(this, EventArgs.Empty);
        }

       

        public frm_Venue_Pending()
        {
            InitializeComponent();
            // dt_pendings.CellContentClick += dt_pendings_CellContentClick;
            dt_pendings.CellClick += dt_pendings_CellClick; // Handle button click event properly
        }
        

        //methods 
        private void frm_Pending_Venues_Load(object sender, EventArgs e)
        {
            RefreshData();
            // Subscribe to the CellFormatting event for each DataGridView
           
            dt_pendings.CellFormatting += DataGridView_CellFormatting;
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // List of columns to format
            string[] targetColumns = { "fld_Total_Amount2" };

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

                // Queries to fetch dat

                string queryPending = @"
                    SELECT 
                        r.fld_Control_number, 
                        r.fld_Start_Date, 
                        r.fld_End_Date, 
                        r.fld_Start_Time, 
                        r.fld_End_Time, 
                        r.fld_Number_Of_Participants, 
                        r.fld_Reservation_Status,
                        r.fld_Total_Amount,
                        r.fld_Activity_Name,
                        r.fld_Total_Amount,
                        rp.fld_First_Name,             
                        rp.fld_Surname,     
                        rp.fld_Requesting_Person_Address,
                        rp.fld_Contact_Number,
                        v.fld_Venue_Name
                    FROM 
                        tbl_Reservation r
                    LEFT JOIN 
                        tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    LEFT JOIN
                        tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
                    WHERE 
                        r.fld_Reservation_Status = 'Pending' AND
                        r.fld_Reservation_Type = 'Venue'";

               

                // Load data into DataGridViews
               
                LoadData(queryPending, dt_pendings, "Pending");
                

                // Check if there are no pending reservations
                if (dt_pendings.Rows.Count == 0)
                {
                    MessageBox.Show("No more pending reservations.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

     
        //FOR APPROVE RESERRVATION BUTTON W/I THE DATAGRIDVIEW START
        private void dt_pendings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is within a valid row and on the image column
            if (e.RowIndex >= 0)
            {
                var controlNumberCell = dt_pendings.Rows[e.RowIndex].Cells["Control_Number"].Value;
                if (controlNumberCell != null)
                {
                    var controlNumber = controlNumberCell.ToString();

                    if (dt_pendings.Columns[e.ColumnIndex].Name == "Approve")
                    {
                        // Show confirmation dialog for approval
                        DialogResult result = MessageBox.Show(
                            "Are you sure you want to approve this reservation?",
                            "Confirm Approval",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.Yes)
                        {
                            ApproveReservation(controlNumber);
                        }
                    }
                    else if (dt_pendings.Columns[e.ColumnIndex].Name == "Cancel")
                    {
                        // Show confirmation dialog for cancellation
                        DialogResult result = MessageBox.Show(
                            "Are you sure you want to cancel this reservation?",
                            "Confirm Cancellation",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.Yes)
                        {
                            CancelReservation(controlNumber);
                        }
                    }
                }
            }
        }
        private void ApproveReservation(string controlNumber)
        {
            if (!string.IsNullOrEmpty(controlNumber))
            {
                Connection db = new Connection();
                try
                {
                    string updateQuery = "UPDATE tbl_Reservation SET fld_Reservation_Status = 'Confirmed' WHERE fld_Control_Number = @ControlNumber";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, db.strCon))
                    {
                        cmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                        db.strCon.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record marked as Approved/Confirmed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the data to reflect changes
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (db.strCon.State == ConnectionState.Open)
                    {
                        db.strCon.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a control number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CancelReservation(string controlNumber)
        {
            if (!string.IsNullOrEmpty(controlNumber))
            {
                Connection db = new Connection();
                try
                {
                    string updateQuery = "UPDATE tbl_Reservation SET fld_Reservation_Status = 'Cancelled' WHERE fld_Control_Number = @ControlNumber";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, db.strCon))
                    {
                        cmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                        db.strCon.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record marked as Cancelled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the data to reflect changes
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (db.strCon.State == ConnectionState.Open)
                    {
                        db.strCon.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a control number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
    }
}
