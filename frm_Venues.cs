using pgso_connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
namespace pgso
{
    public partial class frm_Venues : Form
    {
        private readonly Connection db = new Connection();
        private readonly BindingSource bindingSource = new BindingSource();
        private bool hasChanges = false;
        private string currentControlNumber = string.Empty;
        private int currentPage = 1;
        private int pageSize = 35; // You can change this to your preferred page size
        private int totalRecords = 0;
        private int totalPages = 1;
        private DataTable fullDataTable = null;

        private Image lastDisplayedImage = null;
        // declarations at the top with other controls

        private ComboBox combo_RateType;
        private string currentSort = ""; // Add this at the top of your class
        public frm_Venues()
        {
            InitializeComponent();
            InitializeControls();
            SetupEventHandlers();
            dt_all.RowPostPaint += dt_all_RowPostPaint;

        }

        //The BindingSource is set as the DataSource of the DataGridView here
        private void InitializeControls()
        {
            dt_all.AutoGenerateColumns = false;

            // In InitializeControls() or after InitializeComponent()
            txt_Search.ForeColor = System.Drawing.Color.Gray;
            txt_Search.Text = "Control Number/Venue";
            txt_Search.GotFocus += Txt_Search_GotFocus;
            txt_Search.LostFocus += Txt_Search_LostFocus;

            dt_all.AutoGenerateColumns = false;
            dt_all.DataSource = bindingSource;
            combobox_Filter.Items.Clear();
            combobox_Filter.SelectedIndexChanged += combobox_Filter_SelectedIndexChanged_1;
            btn_Update.Enabled = false;



            // Rate Type ComboBox
            combo_RateType = new ComboBox();
            combo_RateType.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_RateType.Items.AddRange(new[] { "All", "PGNV", "Special", "Regular" });
            combo_RateType.SelectedIndex = 0;
            combo_RateType.SelectedIndexChanged += ComboBox_FilterChanged;
            //this.Controls.Add(combo_RateType);


            // Add this in InitializeControls(), after other ComboBox initializations
            combo_Sort.Items.Clear();
            combo_Sort.Items.AddRange(new[] { "Highest Price", "Lowest Price" });
            combo_Sort.SelectedIndex = 0;
            combo_Sort.SelectedIndexChanged += combo_Sort_SelectedIndexChanged;
        }

        private void SetupEventHandlers()
        {
            dt_all.CellClick += Dt_all_CellClick;
            dt_all.CellFormatting += Dt_all_CellFormatting;
            combobox_Filter.SelectedIndexChanged += Combobox_Filter_SelectedIndexChanged;
            txt_Search.TextChanged += Txt_Search_TextChanged;

            txt_FName.TextChanged += Control_ValueChanged;

            txt_Address.TextChanged += Control_ValueChanged;
            txt_Office.TextChanged += Control_ValueChanged;
            txt_Status.TextChanged += Control_ValueChanged;
            txt_Activity.TextChanged += Control_ValueChanged;
            txt_Participants.TextChanged += Control_ValueChanged;
            txt_Contact.TextChanged += Control_ValueChanged;
            //dt_all.CellFormatting += dt_all_CellFormatting;
            //datagridview column header bg color
            dt_all.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumAquamarine;
            dt_all.EnableHeadersVisualStyles = false;

            picturebox_IMG.Click += picturebox_IMG_Click;
        }

        private void frm_Venues_Load(object sender, EventArgs e)
        {
            LoadReservationData();
            LoadVenueNames();
            PopulateStatusAndVenueFilter();
        }
        private void Txt_Search_GotFocus(object sender, EventArgs e)
        {
            if (txt_Search.Text == "Control Number/Venue")
            {
                txt_Search.Text = "";
                txt_Search.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void Txt_Search_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Search.Text))
            {
                txt_Search.Text = "Control Number/Venue";
                txt_Search.ForeColor = System.Drawing.Color.Gray;
            }
        }
        private void dt_all_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the column is the total amount column
            if (dt_all.Columns[e.ColumnIndex].Name == "fld_Total_Amount" ||
                dt_all.Columns[e.ColumnIndex].Name == "fld_Total")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = "₱" + value.ToString("N2"); // New line with peso sign
                    e.FormattingApplied = true;
                }
            }
        }


        private void dt_all_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int itemColIndex = dt_all.Columns["Item"].Index;
            int globalIndex = (currentPage - 1) * pageSize + e.RowIndex + 1;
            dt_all.Rows[e.RowIndex].Cells[itemColIndex].Value = globalIndex.ToString();

        }


        //Fetches dat from database and binds it to the binding source
        //filter
        //datagridvuew
        private void LoadReservationData()
        {
            try
            {
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT
                        r.fld_Control_number, 
                        r.fld_Reservation_Status,
                        r.fld_Created_At,
                        r.fld_Total_Amount,
                        v.fld_Venue_Name AS fld_Venue_Name,
                        rp.fld_First_Name,
                        (SELECT TOP 1 vp.fld_Rate_Type 
                         FROM tbl_Venue_Pricing vp 
                         WHERE vp.fk_VenueID = r.fk_VenueID AND vp.fk_Venue_ScopeID = r.fk_Venue_ScopeID) AS fld_Rate_Type,
                        r.fld_Scanned_Document AS fld_Scanned_Document,
                        FORMAT(r.fld_Start_Date, 'M/d/yyyy') AS [Date]
                    FROM tbl_Reservation r
                    LEFT JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    LEFT JOIN tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
                    WHERE r.fld_Reservation_Type = 'Venue'
                    ORDER BY r.fld_Created_At DESC";
                    var dataTable = new DataTable();
                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Add a placeholder image for rows with no image data
                    // Add a placeholder image for rows with no image data
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["fld_Scanned_Document"] == DBNull.Value)
                        {
                            using (Bitmap bmp = new Bitmap(100, 100))
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.Clear(Color.LightGray);
                                g.DrawString("No Image", new Font("Arial", 8), Brushes.Black, 10, 45);
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Use JPEG here
                                    row["fld_Scanned_Document"] = ms.ToArray();
                                }
                            }
                        }
                    }
                    fullDataTable = dataTable;
                    totalRecords = fullDataTable.Rows.Count;
                    totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
                    currentPage = 1;
                    UpdatePagedData();

                    bindingSource.DataSource = dataTable;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadVenueNames()
        {
            try
            {
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();
                    var venueNames = new List<string>();
                    using (var cmd = new SqlCommand(@"
                        SELECT DISTINCT v.fld_Venue_Name
                        FROM tbl_Reservation r
                        INNER JOIN tbl_Reservation_Venues rv ON r.pk_ReservationID = rv.fk_ReservationID
                        INNER JOIN tbl_Venue v ON rv.fk_VenueID = v.pk_VenueID
                        WHERE r.fld_Reservation_Type = 'Venue'
                        ORDER BY v.fld_Venue_Name", connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader.GetString(0);
                            if (!string.IsNullOrEmpty(name))
                                venueNames.Add(name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading venue names: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateStatusAndVenueFilter()
        {
            combobox_Filter.Items.Clear();
            combobox_Filter.Items.Add("All");
            combobox_Filter.Items.Add("Pending");
            combobox_Filter.Items.Add("Cancelled");
            combobox_Filter.Items.Add("Confirmed");
            combobox_Filter.Items.Add("------");
            combobox_Filter.Items.Add("PGNV");
            combobox_Filter.Items.Add("Regular");
            combobox_Filter.Items.Add("Special");
            combobox_Filter.Items.Add("------");
            combobox_Filter.Items.Add("With Pricing"); 
            combobox_Filter.Items.Add("No Price");     
            combobox_Filter.Items.Add("------");

            /// Add venues (existing code)
            try
            {
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(@"
                SELECT DISTINCT v.fld_Venue_Name
                FROM tbl_Reservation r
                INNER JOIN tbl_Reservation_Venues rv ON r.pk_ReservationID = rv.fk_ReservationID
                INNER JOIN tbl_Venue v ON rv.fk_VenueID = v.pk_VenueID
                WHERE r.fld_Reservation_Type = 'Venue'
                ORDER BY v.fld_Venue_Name", connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader.GetString(0);
                            if (!string.IsNullOrEmpty(name))
                                combobox_Filter.Items.Add(name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading venue names: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            combobox_Filter.SelectedIndex = 0;
        }

        //pag napindot, magpapkita muna tong mga to bago si LoadReservationDetails
        private void Dt_all_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks

            // Debug output to verify row selection
            Debug.WriteLine($"Row {e.RowIndex} clicked");

            var row = dt_all.Rows[e.RowIndex];
            currentControlNumber = row.Cells["fld_Control_number"].Value?.ToString() ?? "";

            // Debug output for control number
            Debug.WriteLine($"Selected control number: {currentControlNumber}");

            txt_CN.Text = currentControlNumber;
            txt_Status.Text = row.Cells["fld_Reservation_Status"].Value?.ToString() ?? "";

            if (decimal.TryParse(row.Cells["fld_Total_Amount"].Value?.ToString(), out decimal totalAmount))
            {
                txt_Total.Text = "₱" + totalAmount.ToString("N2");
            }
            else
            {
                txt_Total.Text = "₱0.00";
            }

            if (!string.IsNullOrEmpty(currentControlNumber))
            {
                LoadReservationDetails(currentControlNumber);
            }

            btn_Update.Enabled = false;
            hasChanges = false;

            // Handle image display
            var dataRowView = dt_all.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                var imageData = dataRowView["fld_Scanned_Document"] as byte[];
                if (imageData != null && imageData.Length > 0)
                {
                    using (var ms = new MemoryStream(imageData))
                    {
                        using (var img = Image.FromStream(ms))
                        {
                            var clonedImg = new Bitmap(img);
                            picturebox_IMG.Image = clonedImg;
                            lastDisplayedImage = clonedImg;
                        }
                    }
                }
                else
                {
                    picturebox_IMG.Image = null;
                }
            }
        }



        //display niya ito sa mga text boxes
        private void LoadReservationDetails(string controlNumber)
        {
            try
            {
                Debug.WriteLine($"Loading details for: {controlNumber}");

                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();

                    string query = @"
SELECT 
    r.fld_Reservation_Status AS Status,
    rp.fld_First_Name AS FirstName, 
    rp.fld_Middle_Name AS MiddleName,      -- Add this
    rp.fld_Surname AS LastName,          -- Add this
    rp.fld_Requesting_Person_Address AS Address,
    rp.fld_Requesting_Office AS Office,
    rp.fld_Contact_Number AS ContactNumber,
    r.fld_Activity_Name AS ActivityName,
    r.fld_Number_Of_Participants AS Participants,
    v.fld_Venue_Name AS VenueName,
    vs.fld_Venue_Scope_Name AS Scope,
    vp.fld_Rate_Type AS RateType,
    r.fld_Start_Date AS StartDate,
    r.fld_End_Date AS EndDate,
    r.fld_Start_Time AS StartTime,
    r.fld_End_Time AS EndTime
FROM tbl_Reservation r
LEFT JOIN tbl_Requesting_Person rp 
    ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
LEFT JOIN tbl_Venue v 
    ON r.fk_VenueID = v.pk_VenueID
LEFT JOIN tbl_Venue_Scope vs 
    ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
LEFT JOIN tbl_Venue_Pricing vp 
    ON (r.fk_VenueID = vp.fk_VenueID AND r.fk_Venue_ScopeID = vp.fk_Venue_ScopeID)
WHERE r.fld_Control_number = @ControlNumber";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ControlNumber", controlNumber);

                        using (var reader = command.ExecuteReader())
                        {
                            HashSet<string> formattedEntries = new HashSet<string>();

                            if (reader.Read())
                            {
                                // Combine first, middle, and last name
                                string firstName = reader["FirstName"]?.ToString() ?? "";
                                string middleName = reader["MiddleName"]?.ToString() ?? "";
                                string lastName = reader["LastName"]?.ToString() ?? "";
                                string fullName = $"{firstName} {middleName} {lastName}".Replace("  ", " ").Trim();

                                txt_FName.Text = string.IsNullOrWhiteSpace(fullName) ? "N/A" : fullName;

                                // Debug output for contact number
                                var contactNumber = reader["ContactNumber"]?.ToString() ?? "N/A";
                                Debug.WriteLine($"Setting contact number to: {contactNumber}");
                                txt_Contact.Text = contactNumber;

                                txt_Address.Text = reader["Address"]?.ToString() ?? "N/A";
                                txt_Office.Text = reader["Office"]?.ToString() ?? "N/A";
                                txt_Activity.Text = reader["ActivityName"]?.ToString() ?? "N/A";
                                txt_Participants.Text = reader["Participants"]?.ToString() ?? "0";
                                txt_Venue.Text = reader["VenueName"]?.ToString() ?? "N/A";
                                txt_Scope.Text = reader["Scope"]?.ToString() ?? "N/A";
                                txt_Type.Text = reader["RateType"]?.ToString() ?? "N/A";

                                // Date/time aggregation for all rows
                                do
                                {
                                    string startDate = reader["StartDate"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["StartDate"]).ToString("MM/dd/yyyy")
                                        : null;

                                    string startTime = reader["StartTime"] != DBNull.Value
                                        ? DateTime.Today.Add(TimeSpan.Parse(reader["StartTime"].ToString())).ToString("hh:mmtt")
                                        : null;

                                    string endTime = reader["EndTime"] != DBNull.Value
                                        ? DateTime.Today.Add(TimeSpan.Parse(reader["EndTime"].ToString())).ToString("hh:mmtt")
                                        : null;

                                    if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                                    {
                                        formattedEntries.Add($"{startTime} - {endTime} {startDate}");
                                    }
                                } while (reader.Read());

                                txt_Date_Start.Text = formattedEntries.Count > 0
                                    ? string.Join(Environment.NewLine, formattedEntries)
                                    : "N/A";
                            }
                            else
                            {
                                // No data found, clear fields
                                Debug.WriteLine("No data found for control number");
                                txt_FName.Text = "N/A";
                                // txt_LName.Text = "N/A";
                                txt_Contact.Text = "N/A";
                                txt_Address.Text = "N/A";
                                txt_Office.Text = "N/A";
                                txt_Activity.Text = "N/A";
                                txt_Participants.Text = "0";
                                txt_Venue.Text = "N/A";
                                txt_Scope.Text = "N/A";
                                txt_Type.Text = "N/A";
                                txt_Date_Start.Text = "N/A";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading details: {ex.Message}");
                MessageBox.Show($"Error loading reservation details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdatePagedData()
        {
            if (fullDataTable == null) return;

            DataRow[] sortedRows;
            if (!string.IsNullOrEmpty(currentSort))
                sortedRows = fullDataTable.Select("", currentSort);
            else
                sortedRows = fullDataTable.Select();

            var pagedTable = fullDataTable.Clone();
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, sortedRows.Length);

            for (int i = startIndex; i < endIndex; i++)
            {
                pagedTable.ImportRow(sortedRows[i]);
            }

            bindingSource.DataSource = pagedTable;
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";
            btnPrevPage.Enabled = currentPage > 1;
            btnNextPage.Enabled = currentPage < totalPages;
        }





        private void Control_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentControlNumber))
            {
                hasChanges = true;
                btn_Update.Enabled = true;
            }
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show(
                "Are you sure you want to update?",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {

                return; // Cancel submission if user selects No
            }
            if (string.IsNullOrEmpty(currentControlNumber))
            {
                MessageBox.Show("Please select a reservation first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new SqlConnection(db.strCon.ConnectionString))
                {
                    connection.Open();

                    // Update tbl_Reservation for the status
                    string reservationQuery = @"
                UPDATE tbl_Reservation 
                SET fld_Reservation_Status = @Status
                WHERE fld_Control_number = @ControlNumber";

                    using (var command = new SqlCommand(reservationQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Status", txt_Status.Text.Trim());
                        command.Parameters.AddWithValue("@ControlNumber", currentControlNumber);
                        command.ExecuteNonQuery();
                    }

                    // Update tbl_Requesting_Person for the first name, last name, and address
                    string personQuery = @"
                    UPDATE tbl_Requesting_Person
                    SET fld_First_Name = @FirstName,
                        fld_Requesting_Person_Address = @Address,
                        fld_Contact_Number = @ContactNumber
                    WHERE pk_Requesting_PersonID = 
                        (SELECT fk_Requesting_PersonID 
                         FROM tbl_Reservation 
                         WHERE fld_Control_number = @ControlNumber)";

                    using (var command = new SqlCommand(personQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", txt_FName.Text.Trim());
                        // command.Parameters.AddWithValue("@LastName", txt_LName.Text.Trim());
                        command.Parameters.AddWithValue("@ContactNumber", txt_Contact.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txt_Address.Text.Trim());
                        command.Parameters.AddWithValue("@ControlNumber", currentControlNumber);
                        command.ExecuteNonQuery();
                    }

                    // Display success message only once after both updates
                    MessageBox.Show("Reservation updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReservationData();
                    btn_Update.Enabled = false;
                    hasChanges = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating reservation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadReservationData();
            btn_Update.Enabled = false;
            hasChanges = false;
        }

        private void Combobox_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters(); // Use the unified filtering approach
        }

        private void Txt_Search_TextChanged(object sender, EventArgs e)
        {
            var searchText = txt_Search.Text.Trim();
            bindingSource.Filter = string.IsNullOrEmpty(searchText) ? "" :
                $"fld_Control_number LIKE '%{searchText}%' OR " +
                $"fld_Venue_Name LIKE '%{searchText}%' OR " +
                $"fld_First_Name LIKE '%{searchText}%'";

        }

        private void Dt_all_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Handle total amount formatting
            if (dt_all.Columns[e.ColumnIndex].Name == "fld_Total_Amount" ||
                 dt_all.Columns[e.ColumnIndex].Name == "fld_Total")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = "₱" + value.ToString("N2");
                    e.FormattingApplied = true;
                }
            }

            // Color the entire row based on the status value
            if (dt_all.Columns.Contains("fld_Reservation_Status"))
            {
                var statusCell = dt_all.Rows[e.RowIndex].Cells["fld_Reservation_Status"];
                if (statusCell.Value != null)
                {
                    string status = statusCell.Value.ToString();
                    if (status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
                    {
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 235, 245);
                    }
                    else if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(242, 239, 231);
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                    {
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 228, 225);
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        dt_all.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
        }

        // Empty event handlers
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void txt_Update_TextChanged(object sender, EventArgs e) { }

        private void dt_all_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_Scope_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Venue_TextChanged(object sender, EventArgs e)
        {

        }

        private void combo_Venue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel_Information_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txt_Search_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void ComboBox_FilterChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void combobox_Filter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var selected = combobox_Filter.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selected) || selected == "All" || selected == "------")
            {
                bindingSource.Filter = "";
            }
            else if (selected == "Pending" || selected == "Cancelled" || selected == "Confirmed")
            {
                bindingSource.Filter = $"fld_Reservation_Status = '{selected.Replace("'", "''")}'";
            }
            else if (selected == "PGNV" || selected == "Regular" || selected == "Special")
            {
                bindingSource.Filter = $"fld_Rate_Type = '{selected.Replace("'", "''")}'";
            }
            else if (selected == "With Pricing")
            {
                bindingSource.Filter = "fld_Total_Amount > 0";
            }
            else if (selected == "No Price")
            {
                bindingSource.Filter = "fld_Total_Amount IS NULL OR fld_Total_Amount = 0";
            }
            else
            {
                // Assume it's a venue name
                bindingSource.Filter = $"fld_Venue_Name = '{selected.Replace("'", "''")}'";
            }
        }

        private void ApplyFilters()
        {
            if (bindingSource.DataSource == null)
            {
                Debug.WriteLine("No data loaded.");
                return;
            }

            var dt = bindingSource.DataSource as DataTable;
            if (dt == null)
            {
                Debug.WriteLine("DataSource is not a DataTable.");
                return;
            }

            Debug.WriteLine($"Rows loaded: {dt.Rows.Count}");

            var filters = new List<string>();

            // Only one filter: status, rate type, or venue
            var selected = combobox_Filter.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selected) && selected != "All")
            {
                if (selected == "Pending" || selected == "Cancelled" || selected == "Confirmed")
                {
                    filters.Add($"fld_Reservation_Status = '{selected.Replace("'", "''")}'");
                }
                else if (selected == "PGNV" || selected == "Regular" || selected == "Special")
                {
                    filters.Add($"fld_Rate_Type = '{selected.Replace("'", "''")}'");
                }
                else if (selected == "With Pricing")
                {
                    filters.Add("fld_Total_Amount > 0");
                }
                else if (selected == "No Price")
                {
                    filters.Add("fld_Total_Amount IS NULL OR fld_Total_Amount = 0");
                }
                else
                {
                    // It's a venue name
                    filters.Add($"fld_Venue_Name = '{selected.Replace("'", "''")}'");
                }
            }

            // Search Text
            var searchText = txt_Search.Text.Trim();
            if (!string.IsNullOrEmpty(searchText) && searchText != "Control Number/Venue")
            {
                filters.Add(
                    $"(fld_Control_number LIKE '%{searchText.Replace("'", "''")}%' OR " +
                    $"fld_Venue_Name LIKE '%{searchText.Replace("'", "''")}%' OR " +
                    $"fld_First_Name LIKE '%{searchText.Replace("'", "''")}%')");
            }

            var filterString = filters.Any() ? string.Join(" AND ", filters) : "";
            Debug.WriteLine("Filter: " + filterString);

            bindingSource.Filter = filterString;

            Debug.WriteLine("Rows after filter: " + bindingSource.List.Count);

            if (bindingSource.List.Count == 0)
            {
                Debug.WriteLine("No data matches the current filter.");
            }
        }
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txt_Office_TextChanged(object sender, EventArgs e)
        {

        }

        private void picturebox_IMG_Click(object sender, EventArgs e)
        {
            if (lastDisplayedImage != null)
            {
                try
                {
                    string tempFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.jpg");
                    lastDisplayedImage.Save(tempFile, System.Drawing.Imaging.ImageFormat.Jpeg);

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = tempFile,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening image: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No image to open.");
            }
        }

        private void combo_Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (combo_Sort.SelectedItem?.ToString())
            {
                case "Highest Price":
                    currentSort = "fld_Total_Amount DESC";
                    break;
                case "Lowest Price":
                    currentSort = "fld_Total_Amount ASC";
                    break;
                default:
                    currentSort = "";
                    break;
            }
            UpdatePagedData();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                UpdatePagedData();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                UpdatePagedData();
            }
        }

        private void lblPageInfo_Click(object sender, EventArgs e)
        {

        }
    }
}