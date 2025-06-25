
using pgso_connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Client_Info : Form
    {
        private SqlConnection conn;
        private readonly Connection db = new Connection();

        private int currentPage = 1;
        private int pageSize = 40; // You can adjust this as needed
        private int totalRecords = 0;
        private int totalPages = 0;

        private int currentPage1 = 1;
        private int pageSize1 = 15; // You can adjust this as needed
        private int totalRecords1 = 0;
        private int totalPages1 = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frm_Client_Info()
        {
            InitializeComponent();
            dgv_Client.AutoGenerateColumns = false;
            dgv_Client.ReadOnly = true;

            // Set search cue banner if you have a search box
            if (txt_Search != null)
                SendMessage(txt_Search.Handle, EM_SETCUEBANNER, 0, "Search Name");

            LoadRequestingPersonData();


            dgv_Client.CellClick += dgv_Client_CellClick;
            dgv_Client.CellDoubleClick += dgv_Client_CellDoubleClick;
            btn_Update.Enabled = false;
            LoadOfficeFilter();
            // Example: Enable word wrap for all columns in your DataGridView named dataGridView1
            dgv_Additional_Info.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_Additional_Info.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void DBConnect()
        {
            try
            {
                conn = new SqlConnection(db.strCon.ConnectionString);
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
        // Class‑level fields to hold the original name values
        private string originalFirst, originalMiddle, originalSurname;

        private void dgv_Client_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Avoid header row

            DataGridViewRow row = dgv_Client.Rows[e.RowIndex];

            originalFirst = row.Cells["fld_First_Name"]?.Value?.ToString() ?? "";
            originalMiddle = row.Cells["fld_Middle_Name"]?.Value?.ToString() ?? "";
            originalSurname = row.Cells["fld_Surname"]?.Value?.ToString() ?? "";

            // Assign text boxes — you likely already have:
            txt_Fname_Edit.Text = originalFirst;
            txt_MiddleName_Edit.Text = originalMiddle;
            txt_Surname_Edit.Text = originalSurname;
            // ... contact, office, address, etc.

            // **Important**: trigger loading reservations by name here:
            LoadReservationInfoByName(originalFirst, originalMiddle, originalSurname);

            btn_Update.Enabled = false;
            txt_Fname_Edit.ReadOnly = true;
            txt_MiddleName_Edit.ReadOnly = true;
            txt_Surname_Edit.ReadOnly = true;
            txt_Contact_Edit.ReadOnly = true;
            txt_Office_Edit.ReadOnly = true;
            txt_Address_Edit.ReadOnly = true;
        }


        private void dgv_Client_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txt_Fname_Edit.ReadOnly = false;
            txt_MiddleName_Edit.ReadOnly = false;
            txt_Surname_Edit.ReadOnly = false;
            txt_Contact_Edit.ReadOnly = false;
            txt_Office_Edit.ReadOnly = false;
            txt_Address_Edit.ReadOnly = false;

            btn_Update.Enabled = true;
        }
        private void LoadRequestingPersonData(string searchTerm = "", string office = "All Offices")
        {
            try
            {
                DBConnect();

                // Prepare WHERE clause
                string whereClause = "";
                var parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    whereClause += @"(fld_First_Name LIKE @search OR 
                              fld_Middle_Name LIKE @search OR 
                              fld_Surname LIKE @search)";
                    parameters.Add(new SqlParameter("@search", "%" + searchTerm + "%"));
                }

                if (!string.IsNullOrWhiteSpace(office) && office != "All Offices")
                {
                    if (!string.IsNullOrEmpty(whereClause)) whereClause += " AND ";
                    whereClause += "fld_Requesting_Office = @office";
                    parameters.Add(new SqlParameter("@office", office));
                }

                if (!string.IsNullOrEmpty(whereClause))
                    whereClause = "WHERE " + whereClause;

                // Get total record count (with filters)
                string countQuery = $"SELECT COUNT(*) FROM tbl_Requesting_Person {whereClause}";
                using (SqlCommand countCmd = new SqlCommand(countQuery, conn))
                {
                    // Use new parameter objects for countCmd
                    foreach (var p in parameters)
                        countCmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                    totalRecords = (int)countCmd.ExecuteScalar();
                }

                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                if (currentPage > totalPages) currentPage = totalPages == 0 ? 1 : totalPages;
                int offset = (currentPage - 1) * pageSize;

                // In LoadRequestingPersonData, update the SELECT part of your query:
                string query = $@"
                    SELECT 
                        MIN(pk_Requesting_PersonID) AS pk_Requesting_PersonID,
                        fld_First_Name,
                        fld_Middle_Name,
                        fld_Surname,
                        fld_Requesting_Office AS [Office],
                        MIN(fld_Contact_Number) AS [Contact],
                        MIN(fld_Requesting_Person_Address) AS [Address],
                        MIN(fld_Request_Origin) AS [Origin]
                    FROM tbl_Requesting_Person
                    {whereClause}
                    GROUP BY fld_Surname, fld_First_Name, fld_Middle_Name, fld_Requesting_Office
                    ORDER BY fld_Surname, fld_First_Name
                    OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY";

                SqlDataAdapter adapter = new SqlDataAdapter();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Use new parameter objects for cmd
                    foreach (var p in parameters)
                        cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                    adapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv_Client.DataSource = dt;
                }

                UpdatePageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requesting person data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBClose();
            }
        }

        private void txt_Fname_Edit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_MiddleName_Edit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Surname_Edit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Contact_Edit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Office_Edit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Address_Edit_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dgv_Client.CurrentRow == null) return;
            int personId = Convert.ToInt32(dgv_Client.CurrentRow.Cells["pk_Requesting_PersonID"].Value);

            // Validate:
            if (string.IsNullOrWhiteSpace(txt_Fname_Edit.Text) ||
                string.IsNullOrWhiteSpace(txt_Surname_Edit.Text) ||
                string.IsNullOrWhiteSpace(txt_Contact_Edit.Text)) { /* show error */ return; }

            DBConnect();
            using (var tran = conn.BeginTransaction())
            {
                // 1️⃣ Update single selected row
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = tran;
                    cmd.CommandText = @"
                UPDATE tbl_Requesting_Person
                SET fld_First_Name = @FirstName,
                    fld_Middle_Name = @MiddleName,
                    fld_Surname = @Surname,
                    fld_Contact_Number = @Contact,
                    fld_Requesting_Office = @Office,
                    fld_Requesting_Person_Address = @Address
                WHERE pk_Requesting_PersonID = @PersonID;";
                    cmd.Parameters.AddWithValue("@FirstName", txt_Fname_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@MiddleName", txt_MiddleName_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@Surname", txt_Surname_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@Contact", txt_Contact_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@Office", txt_Office_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txt_Address_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@PersonID", personId);
                    cmd.ExecuteNonQuery();
                }

                // 2️⃣ Bulk-update all entries sharing the original full name
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = tran;
                    cmd.CommandText = @"
                UPDATE tbl_Requesting_Person
                SET fld_First_Name = @NewFirst,
                    fld_Middle_Name = @NewMiddle,
                    fld_Surname = @NewSurname,
                    fld_Contact_Number = @NewContact,
                    fld_Requesting_Office = @NewOffice,
                    fld_Requesting_Person_Address = @NewAddress
                WHERE fld_First_Name = @OldFirst
                  AND fld_Middle_Name = @OldMiddle
                  AND fld_Surname = @OldSurname;";
                    cmd.Parameters.AddWithValue("@NewFirst", txt_Fname_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@NewMiddle", txt_MiddleName_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@NewSurname", txt_Surname_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@NewContact", txt_Contact_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@NewOffice", txt_Office_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@NewAddress", txt_Address_Edit.Text.Trim());
                    cmd.Parameters.AddWithValue("@OldFirst", originalFirst);
                    cmd.Parameters.AddWithValue("@OldMiddle", originalMiddle);
                    cmd.Parameters.AddWithValue("@OldSurname", originalSurname);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
            }

            MessageBox.Show("All matching client records updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadRequestingPersonData();
            btn_Update.Enabled = false;
            DBClose();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadRequestingPersonData(txt_Search.Text.Trim(), combo_Filter.SelectedItem?.ToString() ?? "All Offices");
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadRequestingPersonData(txt_Search.Text.Trim(), combo_Filter.SelectedItem?.ToString() ?? "All Offices");
            }
        }

        private void lblPageInfo_Click(object sender, EventArgs e)
        {

        }
        private void UpdatePageInfo()
        {
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";
            btnPrevPage.Enabled = currentPage > 1;
            btnNextPage.Enabled = currentPage < totalPages;
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadRequestingPersonData(txt_Search.Text.Trim(), combo_Filter.SelectedItem?.ToString() ?? "All Offices");
        }

        private void combo_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadRequestingPersonData(txt_Search.Text.Trim(), combo_Filter.SelectedItem?.ToString() ?? "All Offices");
        }

        private void LoadOfficeFilter()
        {
            try
            {
                DBConnect();
                string query = "SELECT DISTINCT fld_Requesting_Office FROM tbl_Requesting_Person ORDER BY fld_Requesting_Office";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    combo_Filter.Items.Clear();
                    combo_Filter.Items.Add("All Offices");
                    while (reader.Read())
                    {
                        string office = reader["fld_Requesting_Office"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(office))
                            combo_Filter.Items.Add(office);
                    }
                }
                combo_Filter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading office filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBClose();
            }
        }

        private void LoadReservationInfo(int personId)
        {
            try
            {
                DBConnect();

                // Count total records for pagination
                string countQuery = @"
                    SELECT COUNT(*) 
                    FROM tbl_Reservation
                    WHERE fk_Requesting_PersonID = @PersonID";

                using (SqlCommand countCmd = new SqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@PersonID", personId);
                    totalRecords1 = (int)countCmd.ExecuteScalar();
                }

                totalPages1 = (int)Math.Ceiling((double)totalRecords1 / pageSize1);
                if (currentPage1 > totalPages1) currentPage1 = totalPages1 == 0 ? 1 : totalPages1;
                int offset = (currentPage1 - 1) * pageSize1;

                // Count reservations by status (unchanged)
                string statusQuery = @"
                    SELECT 
                        SUM(CASE WHEN fld_Reservation_Status = 'Pending' THEN 1 ELSE 0 END) AS PendingCount,
                        SUM(CASE WHEN fld_Reservation_Status = 'Cancelled' THEN 1 ELSE 0 END) AS CancelledCount,
                        SUM(CASE WHEN fld_Reservation_Status = 'Confirmed' THEN 1 ELSE 0 END) AS ConfirmedCount,
                        COUNT(*) AS TotalCount
                    FROM tbl_Reservation
                    WHERE fk_Requesting_PersonID = @PersonID";

                using (SqlCommand countCmd = new SqlCommand(statusQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@PersonID", personId);
                    using (SqlDataReader reader = countCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbl_Pending.Text = reader["PendingCount"].ToString();
                            lbl_Cancelled.Text = reader["CancelledCount"].ToString();
                            lbl_Confirmed.Text = reader["ConfirmedCount"].ToString();
                            lbl_Total.Text = reader["TotalCount"].ToString();
                        }
                    }
                }

                // Load reservation details with pagination
                string detailsQuery = $@"
                    SELECT 
                        fld_Control_Number AS [Control Number],
                        fld_Created_At AS [Request Date],
                        fld_Reservation_Type AS [Reservation Type],
                        fld_Reservation_Status AS [Status]
                    FROM tbl_Reservation
                    WHERE fk_Requesting_PersonID = @PersonID
                    ORDER BY CAST(RIGHT(fld_Control_Number, 4) AS INT) DESC
                    OFFSET {offset} ROWS FETCH NEXT {pageSize1} ROWS ONLY";
                using (SqlCommand detailsCmd = new SqlCommand(detailsQuery, conn))
                {
                    detailsCmd.Parameters.AddWithValue("@PersonID", personId);
                    SqlDataAdapter adapter = new SqlDataAdapter(detailsCmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv_Additional_Info.DataSource = dt;
                }

                UpdateInfoPageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservation info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBClose();
            }
        }
        private int selectedPersonId = 0;
        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (currentPage1 > 1)
            {
                currentPage1--;
                LoadReservationInfo(selectedPersonId);
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (currentPage1 < totalPages1)
            {
                currentPage1++;
                LoadReservationInfo(selectedPersonId);
            }
        }

        private void UpdateInfoPageInfo()
        {
            lbl_paging.Text = $"Page {currentPage1} of {totalPages1}";
            btn_Prev.Enabled = currentPage1 > 1;
            btn_Next.Enabled = currentPage1 < totalPages1;
        }
        private void lbl_paging_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadReservationInfoByName(string firstName, string middleName, string surname)
        {
            try
            {
                DBConnect();

                // 1. Get all person IDs with the same name
                string idQuery = @"
            SELECT pk_Requesting_PersonID 
            FROM tbl_Requesting_Person
            WHERE fld_First_Name = @FirstName
              AND fld_Middle_Name = @MiddleName
              AND fld_Surname = @Surname";

                List<int> personIds = new List<int>();
                using (SqlCommand idCmd = new SqlCommand(idQuery, conn))
                {
                    idCmd.Parameters.AddWithValue("@FirstName", firstName);
                    idCmd.Parameters.AddWithValue("@MiddleName", middleName);
                    idCmd.Parameters.AddWithValue("@Surname", surname);
                    using (SqlDataReader reader = idCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            personIds.Add(reader.GetInt32(0));
                        }
                    }
                }

                if (personIds.Count == 0)
                {
                    dgv_Additional_Info.DataSource = null;
                    lbl_Pending.Text = "0";
                    lbl_Cancelled.Text = "0";
                    lbl_Confirmed.Text = "0";
                    lbl_Total.Text = "0";
                    UpdateInfoPageInfo();
                    return;
                }

                // 2. Build a comma-separated list of IDs for the IN clause
                string idList = string.Join(",", personIds);

                // 3. Count reservations by status for all IDs
                string statusQuery = $@"
            SELECT 
                SUM(CASE WHEN fld_Reservation_Status = 'Pending' THEN 1 ELSE 0 END) AS PendingCount,
                SUM(CASE WHEN fld_Reservation_Status = 'Cancelled' THEN 1 ELSE 0 END) AS CancelledCount,
                SUM(CASE WHEN fld_Reservation_Status = 'Confirmed' THEN 1 ELSE 0 END) AS ConfirmedCount,
                COUNT(*) AS TotalCount
            FROM tbl_Reservation
            WHERE fk_Requesting_PersonID IN ({idList})";

                using (SqlCommand countCmd = new SqlCommand(statusQuery, conn))
                {
                    using (SqlDataReader reader = countCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbl_Pending.Text = reader["PendingCount"].ToString();
                            lbl_Cancelled.Text = reader["CancelledCount"].ToString();
                            lbl_Confirmed.Text = reader["ConfirmedCount"].ToString();
                            lbl_Total.Text = reader["TotalCount"].ToString();
                        }
                    }
                }

                // 4. Load reservation details with pagination
                // (Pagination is optional here; you can add it if needed)
                string detailsQuery = $@"
                SELECT 
                    fld_Control_Number AS [Control Number],
                    fld_Created_At AS [Request Date],
                    fld_Reservation_Type AS [Reservation Type],
                    fld_Reservation_Status AS [Status]
                FROM tbl_Reservation
                WHERE fk_Requesting_PersonID IN ({idList})
                ORDER BY CAST(RIGHT(fld_Control_Number, 4) AS INT) DESC";

                using (SqlCommand detailsCmd = new SqlCommand(detailsQuery, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(detailsCmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv_Additional_Info.DataSource = dt;
                }

                UpdateInfoPageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservation info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBClose();
            }
        }

        private void dgv_Additional_Info_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}