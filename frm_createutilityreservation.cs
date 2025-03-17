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
using pgso_connect;//pinalitan ko namespaces. From pgso to pgso_connect$T(sa Connection.cs ito)

namespace pgso
{
    public partial class frm_createutilityreservation: Form
    {
        private Connection db = new Connection(); // Use the Connection class
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt = new DataTable();
        public frm_createutilityreservation()
        {
            InitializeComponent();
            RefreshData();

        }
        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open(); // Open the database connection if not already open

                // Queries to retrieve records based on their status

                //para sa cancel
                string query = "SELECT FacilityName, FacilityPricePerUnit, FacilityTotalQuantity, FacilityAvailableQuantity FROM Facilities ";
                                       //"FROM Facilities WHERE status = 'Canceled'";

                // Load data into respective DataGridViews
                
                LoadData(query, dt_Utilities, "");
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

        // Helper method to execute a query and bind data to a DataGridView
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

                dataGridView.DataSource = tempDt;
                dataGridView.Refresh();

                // Ensure at least one column is visible
                if (dataGridView.Columns.Count > 0)
                    dataGridView.Columns[0].Visible = true;

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dt_Utilities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_createutilityreservation_Load(object sender, EventArgs e)
        {

        }
    }
}
