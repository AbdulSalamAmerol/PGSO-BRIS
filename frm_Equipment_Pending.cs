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
    public partial class frm_Equipment_Pending : Form
    {
        //fields
        private Connection db = new Connection(); // Use the Connection class
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt = new DataTable();
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

        public frm_Equipment_Pending()
        {
            InitializeComponent();
            //dt_pendings.CellContentClick += dt_pendings_CellContentClick; // Add event handler
        }

        //methods 
        private void frm_Equipment_Pending_Load(object sender, EventArgs e)
        {
            RefreshData();
            // Subscribe to the CellFormatting event for each DataGridView
            //dt_pendings.CellFormatting += DataGridView_CellFormatting;
        }

        private void RefreshData()
        {
            try
            {
                if (db.strCon.State == ConnectionState.Closed)
                    db.strCon.Open(); // Open the database connection if not already open

                // Query for pending reservations
                string queryPending = @"
                    SELECT 
                        r.fld_Control_number, 
                        r.fld_Start_Date,  
                        r.fld_Reservation_Status,
                        r.fld_Total_Amount,
                        r.fld_Activity_Name,
                        r.fld_Total_Amount,
                        r.fld_Reservation_Status,
                        rp.fld_First_Name,             
                        rp.fld_Surname,     
                        rp.fld_Requesting_Person_Address,
                        rp.fld_Contact_Number,
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
                        r.fld_Reservation_Status = 'Pending' AND
                        r.fld_Reservation_Type = 'Equipment'";

               
                LoadData(queryPending, dt_pendings, "Pending");

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

        //Approved ito
        /*
        private void btn_ApprovedReservation_Click(object sender, EventArgs e)
        {
            if (dt_pendings.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dt_pendings.SelectedRows[0];
                string controlNumber = row.Cells["fld_Control_number"].Value.ToString();
                string startDate = row.Cells["fld_Start_Date"].Value.ToString();
                string reservationStatus = row.Cells["fld_Reservation_Status"].Value.ToString();
                string totalAmount = row.Cells["fld_Total_Amount"].Value.ToString();
                string activityName = row.Cells["fld_Activity_Name"].Value.ToString();
                string firstName = row.Cells["fld_First_Name"].Value.ToString();
                string surname = row.Cells["fld_Surname"].Value.ToString();
                string address = row.Cells["fld_Requesting_Person_Address"].Value.ToString();
                string contactNumber = row.Cells["fld_Contact_Number"].Value.ToString();
                string equipmentName = row.Cells["fld_Equipment_Name"].Value.ToString();
                string numberOfDays = row.Cells["fld_Number_Of_Days"].Value.ToString();
                string quantity = row.Cells["fld_Quantity"].Value.ToString();

                ShowApprovedForm(controlNumber, startDate, "Confirmed", totalAmount, activityName, firstName, surname, address, contactNumber, equipmentName, numberOfDays, quantity);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        */
        /*private void dt_pendings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dt_pendings.Rows[e.RowIndex];
                string controlNumber = row.Cells["fld_Control_number"].Value.ToString();
                string startDate = row.Cells["fld_Start_Date"].Value.ToString();
                string reservationStatus = row.Cells["fld_Reservation_Status"].Value.ToString();
                string totalAmount = row.Cells["fld_Total_Amount"].Value.ToString();
                string activityName = row.Cells["fld_Activity_Name"].Value.ToString();
                string firstName = row.Cells["fld_First_Name"].Value.ToString();
                string surname = row.Cells["fld_Surname"].Value.ToString();
                string address = row.Cells["fld_Requesting_Person_Address"].Value.ToString();
                string contactNumber = row.Cells["fld_Contact_Number"].Value.ToString();
                string equipmentName = row.Cells["fld_Equipment_Name"].Value.ToString();
                string numberOfDays = row.Cells["fld_Number_Of_Days"].Value.ToString();
                string quantity = row.Cells["fld_Quantity"].Value.ToString();

                ShowApprovedForm(controlNumber, startDate, reservationStatus, totalAmount, activityName, firstName, surname, address, contactNumber, equipmentName, numberOfDays, quantity);
            }
        }*/

        
        /*private async void ShowApprovedForm(string controlNumber, string startDate, string reservationStatus, string totalAmount, string activityName, string firstName, string surname, string address, string contactNumber, string equipmentName, string numberOfDays, string quantity)
        {
            // Create a new form dynamically
            Form editForm = new Form();
            editForm.Text = "Edit Reservation";
            editForm.Size = new Size(600, 600); // Set the size of the form

            // Create and add controls to the form
            Label lblControlNumber = new Label() { Text = "Control Number", Left = 10, Top = 20 };
            TextBox txtControlNumber = new TextBox() { Left = 150, Top = 20, Width = 200, Text = controlNumber };

            Label lblStartDate = new Label() { Text = "Start Date", Left = 10, Top = 60 };
            TextBox txtStartDate = new TextBox() { Left = 150, Top = 60, Width = 200, Text = startDate };

            Label lblReservationStatus = new Label() { Text = "Reservation Status", Left = 10, Top = 100 };
            TextBox txtReservationStatus = new TextBox() { Left = 150, Top = 100, Width = 200, Text = reservationStatus };

            Label lblTotalAmount = new Label() { Text = "Total Amount", Left = 10, Top = 140 };
            TextBox txtTotalAmount = new TextBox() { Left = 150, Top = 140, Width = 200, Text = totalAmount };

            Label lblActivityName = new Label() { Text = "Activity Name", Left = 10, Top = 180 };
            TextBox txtActivityName = new TextBox() { Left = 150, Top = 180, Width = 200, Text = activityName };

            Label lblFirstName = new Label() { Text = "First Name", Left = 10, Top = 220 };
            TextBox txtFirstName = new TextBox() { Left = 150, Top = 220, Width = 200, Text = firstName };

            Label lblSurname = new Label() { Text = "Surname", Left = 10, Top = 260 };
            TextBox txtSurname = new TextBox() { Left = 150, Top = 260, Width = 200, Text = surname };

            Label lblAddress = new Label() { Text = "Address", Left = 10, Top = 300 };
            TextBox txtAddress = new TextBox() { Left = 150, Top = 300, Width = 200, Text = address };

            Label lblContactNumber = new Label() { Text = "Contact Number", Left = 10, Top = 340 };
            TextBox txtContactNumber = new TextBox() { Left = 150, Top = 340, Width = 200, Text = contactNumber };

            Label lblEquipmentName = new Label() { Text = "Equipment Name", Left = 10, Top = 380 };
            TextBox txtEquipmentName = new TextBox() { Left = 150, Top = 380, Width = 200, Text = equipmentName };

            Label lblNumberOfDays = new Label() { Text = "Number of Days", Left = 10, Top = 420 };
            TextBox txtNumberOfDays = new TextBox() { Left = 150, Top = 420, Width = 200, Text = numberOfDays };

            Label lblQuantity = new Label() { Text = "Quantity", Left = 10, Top = 460 };
            TextBox txtQuantity = new TextBox() { Left = 150, Top = 460, Width = 200, Text = quantity };

            Button btnSave = new Button() { Text = "Approve", Left = 150, Top = 500, Width = 100 };
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
                            // Update only the reservation status
                            string updateQuery = @"
                                UPDATE tbl_Reservation
                                SET fld_Reservation_Status = @reservationStatus
                                WHERE fld_Control_number = @controlNumber";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, db.strCon, transaction))
                            {
                                cmd.Parameters.AddWithValue("@reservationStatus", txtReservationStatus.Text);
                                cmd.Parameters.AddWithValue("@controlNumber", txtControlNumber.Text);
                                await cmd.ExecuteNonQueryAsync();
                            }

                            transaction.Commit();
                            MessageBox.Show("Reservation status updated to Confirmed!");
                            editForm.Close();
                            RefreshData();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error updating reservation status: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (db.strCon.State == ConnectionState.Open)
                        db.strCon.Close();
                }
            };

            editForm.Controls.Add(lblControlNumber);
            editForm.Controls.Add(txtControlNumber);
            editForm.Controls.Add(lblStartDate);
            editForm.Controls.Add(txtStartDate);
            editForm.Controls.Add(lblReservationStatus);
            editForm.Controls.Add(txtReservationStatus);
            editForm.Controls.Add(lblTotalAmount);
            editForm.Controls.Add(txtTotalAmount);
            editForm.Controls.Add(lblActivityName);
            editForm.Controls.Add(txtActivityName);
            editForm.Controls.Add(lblFirstName);
            editForm.Controls.Add(txtFirstName);
            editForm.Controls.Add(lblSurname);
            editForm.Controls.Add(txtSurname);
            editForm.Controls.Add(lblAddress);
            editForm.Controls.Add(txtAddress);
            editForm.Controls.Add(lblContactNumber);
            editForm.Controls.Add(txtContactNumber);
            editForm.Controls.Add(lblEquipmentName);
            editForm.Controls.Add(txtEquipmentName);
            editForm.Controls.Add(lblNumberOfDays);
            editForm.Controls.Add(txtNumberOfDays);
            editForm.Controls.Add(lblQuantity);
            editForm.Controls.Add(txtQuantity);
            editForm.Controls.Add(btnSave);

            // Show the form immediately
            editForm.Show();

            // Perform any additional operations asynchronously
            await Task.Run(() =>
            {
                // Simulate a delay for demonstration purposes
                System.Threading.Thread.Sleep(1000);
            });
        }*/

        //END OF APPROVED


        //CANCELLED START
        /*
        private void btn_Cancel_Reservation_Click(object sender, EventArgs e)
        {
            if (dt_pendings.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dt_pendings.SelectedRows[0];
                string controlNumber = row.Cells["fld_Control_number"].Value.ToString();
                string startDate = row.Cells["fld_Start_Date"].Value.ToString();
                string reservationStatus = row.Cells["fld_Reservation_Status"].Value.ToString();
                string totalAmount = row.Cells["fld_Total_Amount"].Value.ToString();
                string activityName = row.Cells["fld_Activity_Name"].Value.ToString();
                string firstName = row.Cells["fld_First_Name"].Value.ToString();
                string surname = row.Cells["fld_Surname"].Value.ToString();
                string address = row.Cells["fld_Requesting_Person_Address"].Value.ToString();
                string contactNumber = row.Cells["fld_Contact_Number"].Value.ToString();
                string equipmentName = row.Cells["fld_Equipment_Name"].Value.ToString();
                string numberOfDays = row.Cells["fld_Number_Of_Days"].Value.ToString();
                string quantity = row.Cells["fld_Quantity"].Value.ToString();

                ShowCancelForm(controlNumber, startDate, "Cancelled", totalAmount, activityName, firstName, surname, address, contactNumber, equipmentName, numberOfDays, quantity);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void ShowCancelForm(string controlNumber, string startDate, string reservationStatus, string totalAmount, string activityName, string firstName, string surname, string address, string contactNumber, string equipmentName, string numberOfDays, string quantity)
        {
            // Create a new form dynamically
            Form editForm = new Form();
            editForm.Text = "Edit Reservation";
            editForm.Size = new Size(600, 600); // Set the size of the form

            // Create and add controls to the form
            Label lblControlNumber = new Label() { Text = "Control Number", Left = 10, Top = 20 };
            TextBox txtControlNumber = new TextBox() { Left = 150, Top = 20, Width = 200, Text = controlNumber };

            Label lblStartDate = new Label() { Text = "Start Date", Left = 10, Top = 60 };
            TextBox txtStartDate = new TextBox() { Left = 150, Top = 60, Width = 200, Text = startDate };

            Label lblReservationStatus = new Label() { Text = "Reservation Status", Left = 10, Top = 100 };
            TextBox txtReservationStatus = new TextBox() { Left = 150, Top = 100, Width = 200, Text = reservationStatus };

            Label lblTotalAmount = new Label() { Text = "Total Amount", Left = 10, Top = 140 };
            TextBox txtTotalAmount = new TextBox() { Left = 150, Top = 140, Width = 200, Text = totalAmount };

            Label lblActivityName = new Label() { Text = "Activity Name", Left = 10, Top = 180 };
            TextBox txtActivityName = new TextBox() { Left = 150, Top = 180, Width = 200, Text = activityName };

            Label lblFirstName = new Label() { Text = "First Name", Left = 10, Top = 220 };
            TextBox txtFirstName = new TextBox() { Left = 150, Top = 220, Width = 200, Text = firstName };

            Label lblSurname = new Label() { Text = "Surname", Left = 10, Top = 260 };
            TextBox txtSurname = new TextBox() { Left = 150, Top = 260, Width = 200, Text = surname };

            Label lblAddress = new Label() { Text = "Address", Left = 10, Top = 300 };
            TextBox txtAddress = new TextBox() { Left = 150, Top = 300, Width = 200, Text = address };

            Label lblContactNumber = new Label() { Text = "Contact Number", Left = 10, Top = 340 };
            TextBox txtContactNumber = new TextBox() { Left = 150, Top = 340, Width = 200, Text = contactNumber };

            Label lblEquipmentName = new Label() { Text = "Equipment Name", Left = 10, Top = 380 };
            TextBox txtEquipmentName = new TextBox() { Left = 150, Top = 380, Width = 200, Text = equipmentName };

            Label lblNumberOfDays = new Label() { Text = "Number of Days", Left = 10, Top = 420 };
            TextBox txtNumberOfDays = new TextBox() { Left = 150, Top = 420, Width = 200, Text = numberOfDays };

            Label lblQuantity = new Label() { Text = "Quantity", Left = 10, Top = 460 };
            TextBox txtQuantity = new TextBox() { Left = 150, Top = 460, Width = 200, Text = quantity };

            Button btnCancel = new Button() { Text = "Cancel", Left = 150, Top = 500, Width = 100 };
            btnCancel.Click += async (s, args) =>
            {
                try
                {
                    if (db.strCon.State == ConnectionState.Closed)
                        db.strCon.Open();

                    using (SqlTransaction transaction = db.strCon.BeginTransaction())
                    {
                        try
                        {
                            // Update only the reservation status
                            string updateQuery = @"
                        UPDATE tbl_Reservation
                        SET fld_Reservation_Status = @reservationStatus
                        WHERE fld_Control_number = @controlNumber";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, db.strCon, transaction))
                            {
                                cmd.Parameters.AddWithValue("@reservationStatus", txtReservationStatus.Text);
                                cmd.Parameters.AddWithValue("@controlNumber", txtControlNumber.Text);
                                await cmd.ExecuteNonQueryAsync();
                            }

                            transaction.Commit();
                            MessageBox.Show("Reservation status updated to Cancel!");
                            editForm.Close();
                            RefreshData();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error updating reservation status: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (db.strCon.State == ConnectionState.Open)
                        db.strCon.Close();
                }
            };

            editForm.Controls.Add(lblControlNumber);
            editForm.Controls.Add(txtControlNumber);
            editForm.Controls.Add(lblStartDate);
            editForm.Controls.Add(txtStartDate);
            editForm.Controls.Add(lblReservationStatus);
            editForm.Controls.Add(txtReservationStatus);
            editForm.Controls.Add(lblTotalAmount);
            editForm.Controls.Add(txtTotalAmount);
            editForm.Controls.Add(lblActivityName);
            editForm.Controls.Add(txtActivityName);
            editForm.Controls.Add(lblFirstName);
            editForm.Controls.Add(txtFirstName);
            editForm.Controls.Add(lblSurname);
            editForm.Controls.Add(txtSurname);
            editForm.Controls.Add(lblAddress);
            editForm.Controls.Add(txtAddress);
            editForm.Controls.Add(lblContactNumber);
            editForm.Controls.Add(txtContactNumber);
            editForm.Controls.Add(lblEquipmentName);
            editForm.Controls.Add(txtEquipmentName);
            editForm.Controls.Add(lblNumberOfDays);
            editForm.Controls.Add(txtNumberOfDays);
            editForm.Controls.Add(lblQuantity);
            editForm.Controls.Add(txtQuantity);
            editForm.Controls.Add(btnCancel);

            // Show the form immediately
            editForm.Show();

            // Perform any additional operations asynchronously
            await Task.Run(() =>
            {
                // Simulate a delay for demonstration purposes
                System.Threading.Thread.Sleep(1000);
            });
        }


        //CANCEL END
        */

        

    }
}
