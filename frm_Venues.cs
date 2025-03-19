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


        public frm_Venues()
        {
            InitializeComponent();
        }
        
        //methods 
        private void frm_Venues_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open(); // Open the database connection if not already open


                //ididsplay nito yung mga approved na reservation
                //++ NAME NG NARESERVE NA VENUE AND YUNG SCOPE NIYA (MAIN HALL, LOBBY...). PATI CANCEL AT PENDING
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
                    rp.fld_Contact_Number
                FROM 
                    tbl_Reservation r
                LEFT JOIN 
                    tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                WHERE 
                    r.fld_Reservation_Status = 'Confirmed'";


                //para sa pendings
                //Dagdagan, para maipakita yung reserved venues. pero mamaya na
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
                    rp.fld_Requesting_Person_Address,
                    rp.fld_Contact_Number
                FROM 
                    tbl_Reservation r
                LEFT JOIN 
                    tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                WHERE 
                    r.fld_Reservation_Status = 'Pending'";




                //=======================================END==========================================
                //PARA SA CANCEL
                string queryCanceled = @"
                SELECT 
                    r.fld_Control_number, 
                    r.fld_Number_Of_Participants, 
                    r.fld_Reservation_Status,
                    r.fld_Total_Amount,
                    r.fld_Activity_Name,
                   
                    rp.fld_First_Name,
                    rp.fld_Requesting_Person_Address
                FROM 
                    tbl_Reservation r
                LEFT JOIN 
                    tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                WHERE 
                    r.fld_Reservation_Status = 'Cancelled'";

                
                LoadData(queryApproved, dt_approved, "Confirmed");
                LoadData(queryPending, dt_pendings, "Pending");
                LoadData(queryCanceled, dt_canceled, "Cancelled");
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
        private void Btn_Create_Click(object sender, EventArgs e)
        {
            frm_createvenuereservation frm_Create = new frm_createvenuereservation();
            frm_Create.Show();
        }
        private void Btn_Pending_Click(object sender, EventArgs e)
        {
            //frm_create frm_Create = new frm_create();
            //frm_Create.Show();
            /*dt_approved.Visible = false;
            dt_canceled.Visible = false;
            lbl_pending.Visible = true;
            dt_pendings.Visible = true;
            //label
            lbl_canceled.Visible = false;
            lbl_approved.Visible = false;*/



        }


        private void dtvenuereservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void dt_pendings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Your existing code here
        }


        private void Btn_Approved_Click(object sender, EventArgs e)
        {
            /*dt_pendings.Visible = false;
            dt_canceled.Visible = false;
            dt_approved.Visible = true;
            lbl_approved.Visible = true;
            lbl_canceled.Visible = false;
            lbl_pending.Visible = false;*/

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
           /* dt_pendings.Visible=false;
            dt_canceled.Visible=true;
            lbl_canceled.Visible = true;
            dt_approved.Visible=false;
            lbl_pending.Visible = false;
            lbl_approved.Visible = false;*/
        }


        //method cancellation of reservation using dialog box
        private void Btn_Cancel_Click_1(object sender, EventArgs e)
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
                                Size = new System.Drawing.Size(500, 300),
                                StartPosition = FormStartPosition.CenterScreen
                            };

                            DataGridView dgv = new DataGridView()
                            {
                                DataSource = dt,
                                Dock = DockStyle.Top,
                                ReadOnly = true,
                                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                                Height = 90
                            };

                            Button btnCancel = new Button()
                            {
                                Text = "Cancel Record",
                                Dock = DockStyle.Bottom
                            };

                            // Cancel Button Click Event (Update Status)
                            btnCancel.Click += (s, ev) =>
                            {
                                // Confirm Cancellation
                                DialogResult result = MessageBox.Show(
                                    "Are you sure you want to mark this record as canceled?",
                                    "Confirm Cancellation",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning
                                );

                                if (result == DialogResult.Yes)
                                {
                                    // Update Status to "Canceled"
                                    string updateQuery = "UPDATE tbl_Reservation SET fld_Reservation_Status = 'Cancelled' WHERE fld_Control_Number = @ControlNumber";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, db.strCon))
                                    {
                                        updateCmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                                        updateCmd.ExecuteNonQuery();
                                    }

                                    MessageBox.Show("Record marked as canceled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dataDialog.Close(); // Close the dialog after marking
                                }
                            };

                            dataDialog.Controls.Add(dgv);
                            dataDialog.Controls.Add(btnCancel);
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
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //approval of reservations
        private void btn_approvependings_Click(object sender, EventArgs e)
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
                            //Create Data Dialog
                            Form dataDialog = new Form()
                            {
                                Text = "Record Details",
                                Size = new System.Drawing.Size(500, 200),
                                StartPosition = FormStartPosition.CenterScreen
                            };

                            DataGridView dgv = new DataGridView()
                            {
                                DataSource = dt,
                                Dock = DockStyle.Top,
                                ReadOnly = true,
                                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                                Height = 90
                            };

                            Button btnApprove = new Button()
                            {
                                Text = "Approved Reservation",
                                Dock = DockStyle.Bottom
                            };

                            //approve Button Click Event (Update Status)
                            btnApprove.Click += (s, ev) =>
                            {
                                DialogResult result = MessageBox.Show(
                                    "Are you sure you want to approved this reservation?",
                                    "Confirm Cancellation",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning
                                );

                                if (result == DialogResult.Yes)
                                {
                                    // approve Status to "Approved"
                                    string updateQuery = "UPDATE tbl_Reservation SET fld_Reservation_Status = 'Confirmed' WHERE fld_Control_Number = @ControlNumber";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, db.strCon))
                                    {
                                        updateCmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                                        updateCmd.ExecuteNonQuery();
                                    }

                                    MessageBox.Show("Record marked as Approved/Confirmed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dataDialog.Close(); // Close the dialog after marking
                                }
                            };

                            dataDialog.Controls.Add(dgv);
                            dataDialog.Controls.Add(btnApprove);
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
        }

        //methods
        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
