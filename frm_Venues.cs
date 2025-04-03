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
    public partial class frm_Venues : Form
    {
        //fields
        private Connection db = new Connection(); // Use the Connection class
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt = new DataTable();
        public event EventHandler DashboardRefreshRequested;
        private bool isProcessingApproval = false; // Flag to prevent re-entry


        // Method to raise the event
        


        public frm_Venues()
        {
            InitializeComponent();
            // dt_pendings.CellContentClick += dt_pendings_CellContentClick;
            //dt_pendings.CellClick += dt_pendings_CellClick; // Handle button click event properly
            dt_all.CellClick += dt_all_CellClick; // Handle cell click event

        }


        //methods 
        private void frm_Venues_Load(object sender, EventArgs e)
        {
            RefreshData();
            // Subscribe to the CellFormatting event for each DataGridView
            dt_all.CellFormatting += DataGridView_CellFormatting;

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
                r.fld_Start_Date,
                r.fld_End_Date,
                r.fld_Start_Time,
                r.fld_End_Time,
                r.fld_Activity_Name,
                r.fld_Number_Of_Participants
            FROM 
                tbl_Reservation r
            LEFT JOIN 
                tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
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
            v.fld_Venue_Name
        FROM 
            tbl_Reservation r
        LEFT JOIN
            tbl_Venue v ON r.fk_VenueID = v.pk_VenueID                
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

        //methods



     

        




        


        private void panel1_Paint(object sender, PaintEventArgs e){}
        //approval of reservations
 
        //method
        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }


        //btn reschedule
        //NOTE!! IDAGDAG ANG VENEu
        /*
        private void btn_Reschedule_Click(object sender, EventArgs e)
        {
            // Input Control Number
            string controlNumber = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter Control Number:", "Search Control Number", "");

            if (!string.IsNullOrEmpty(controlNumber))
            {
                Connection db = new Connection();
                try
                {
                    // Retrieve Data from db
                    string query = @"
            SELECT 
                r.fld_Start_Date,
                r.fld_End_Date,
                r.fld_Start_Time,
                r.fld_End_Time,
                r.fld_Activity_Name,
                rp.fld_First_Name,
                rp.fld_Surname,
                r.fld_Total_Amount
            FROM 
                tbl_Reservation r
            LEFT JOIN 
                tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
            WHERE 
                r.fld_Control_Number = @ControlNumber";

                    using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                    {
                        cmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                        db.strCon.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // Create Data Dialog
                            Form dataDialog = new Form()
                            {
                                Text = "Record Details",
                                Size = new System.Drawing.Size(500, 400),
                                StartPosition = FormStartPosition.CenterScreen
                            };

                            DataGridView dgv = new DataGridView()
                            {
                                DataSource = dt,
                                Dock = DockStyle.Top,
                                ReadOnly = true,
                                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                                Height = 150
                            };

                            // New Date and Time Pickers
                            DateTimePicker dtpStartDate = new DateTimePicker()
                            {
                                Format = DateTimePickerFormat.Short,
                                Value = (DateTime)dt.Rows[0]["fld_Start_Date"],
                                Dock = DockStyle.Top
                            };

                            DateTimePicker dtpEndDate = new DateTimePicker()
                            {
                                Format = DateTimePickerFormat.Short,
                                Value = (DateTime)dt.Rows[0]["fld_End_Date"],
                                Dock = DockStyle.Top
                            };

                            DateTimePicker dtpStartTime = new DateTimePicker()
                            {
                                Format = DateTimePickerFormat.Time,
                                ShowUpDown = true,
                                Value = DateTime.Today.Add((TimeSpan)dt.Rows[0]["fld_Start_Time"]),
                                Dock = DockStyle.Top
                            };

                            DateTimePicker dtpEndTime = new DateTimePicker()
                            {
                                Format = DateTimePickerFormat.Time,
                                ShowUpDown = true,
                                Value = DateTime.Today.Add((TimeSpan)dt.Rows[0]["fld_End_Time"]),
                                Dock = DockStyle.Top
                            };

                            Button btnUpdate = new Button()
                            {
                                Text = "Update Reservation",
                                Dock = DockStyle.Bottom
                            };

                            // Update Button Click Event (Update Dates and Times)
                            btnUpdate.Click += (s, ev) =>
                            {
                                DialogResult result = MessageBox.Show(
                                    "Are you sure you want to update this reservation?",
                                    "Confirm Update",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning
                                );

                                if (result == DialogResult.Yes)
                                {
                                    // Update Dates and Times
                                    string updateQuery = @"
                            UPDATE tbl_Reservation 
                            SET fld_Start_Date = @StartDate, fld_End_Date = @EndDate, fld_Start_Time = @StartTime, fld_End_Time = @EndTime 
                            WHERE fld_Control_Number = @ControlNumber";

                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, db.strCon))
                                    {
                                        updateCmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                                        updateCmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                                        updateCmd.Parameters.AddWithValue("@StartTime", dtpStartTime.Value.TimeOfDay);
                                        updateCmd.Parameters.AddWithValue("@EndTime", dtpEndTime.Value.TimeOfDay);
                                        updateCmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                                        updateCmd.ExecuteNonQuery();
                                    }

                                    MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dataDialog.Close(); // Close the dialog after updating
                                }
                            };

                            dataDialog.Controls.Add(dtpEndTime);
                            dataDialog.Controls.Add(dtpStartTime);
                            dataDialog.Controls.Add(dtpEndDate);
                            dataDialog.Controls.Add(dtpStartDate);
                            dataDialog.Controls.Add(dgv);
                            dataDialog.Controls.Add(btnUpdate);
                            dataDialog.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Control number not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
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
        }*/

        

        private void lbl_canceled_Click(object sender, EventArgs e)
        {

        }

        private void dt_canceled_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
            // Get the control number from the displayed data
            string controlNumber = txt_CN.Text;

            if (!string.IsNullOrEmpty(controlNumber))
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
        }


        private void ApproveReservation(string controlNumber)
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = @"
            UPDATE tbl_Reservation
            SET fld_Reservation_Status = 'Confirmed'
            WHERE fld_Control_number = @ControlNumber";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Reservation approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData(); // Refresh the data to reflect the changes
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }

        private void CancelReservation(string controlNumber)
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open();

                string query = @"
            UPDATE tbl_Reservation
            SET fld_Reservation_Status = 'Cancelled'
            WHERE fld_Control_number = @ControlNumber";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Reservation cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData(); // Refresh the data to reflect the changes
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (db.strCon.State == ConnectionState.Open)
                    db.strCon.Close();
            }
        }

        private void btn_Cancel_Click_1(object sender, EventArgs e)
        {
            // Get the control number from the displayed data
            string controlNumber = txt_CN.Text;

            if (!string.IsNullOrEmpty(controlNumber))
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
