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
    public partial class frm_Approved_Venue : Form
    {
        //fields
        private Connection db = new Connection(); // Use the Connection class
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt = new DataTable();
      


        public frm_Approved_Venue()
        {
            InitializeComponent();
        }


        //methods 
        private void frm_Approved_Venue_Load(object sender, EventArgs e)
        {
            RefreshData();
            // Subscribe to the CellFormatting event for each DataGridView
            //dt_approved.CellFormatting += DataGridView_CellFormatting;
           
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
                string queryApproved = @"
        SELECT 
            r.fld_Control_number, 
            r.fld_Start_Date, 
            r.fld_End_Date, 
            r.fld_Start_Time, 
            r.fld_End_Time,
            r.fld_Reservation_Status,
            r.fld_Activity_Name,
            r.fld_Total_Amount,
            rp.fld_First_Name,
            rp.fld_Surname,
            rp.fld_Contact_Number
        FROM 
            tbl_Reservation r
        LEFT JOIN 
            tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
        WHERE 
            r.fld_Reservation_Status = 'Confirmed' AND
            r.fld_Reservation_Type = 'Venue'";

              

                // Load data into DataGridViews
                LoadData(queryApproved, dt_approved, "Confirmed");
                
                // Check if there are no pending reservations
                if (dt_approved.Rows.Count == 0)
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

        



        


        
    }
}
