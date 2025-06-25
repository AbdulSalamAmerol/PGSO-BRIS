using pgso.Billing.Repositories;
using pgso.Billing.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;
using pgso.pgso_Billing.Forms;
using System.Drawing;
using pgso.Properties;
using System.IO;
using System.Threading.Tasks;
using pgso.pgso_Billing.User_Control;
using pgso.pgso_Billing;

namespace pgso
{
    public partial class frm_Billing : Form
    {
        private List<Model_Billing> all_billing_model = new List<Model_Billing>(); // Global list to hold all billing records
        private List<Model_Billing> groupedBillingData; // Store grouped data globally
        private Repo_Billing repo_billing = new Repo_Billing();
        private BindingSource dgv_billing_binding_source = new BindingSource();// Binding source for DataGridView
        
        public frm_Billing()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Margin ~99px margin around
            pb_Logo.Size = new Size(500, 500);
            pb_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Logo.BackColor = Color.Transparent;
            // Center it inside the panel
            pb_Logo.Location = new Point(
                (pnl_Billing_Details.Width - pb_Logo.Width) / 2,
                (pnl_Billing_Details.Height - pb_Logo.Height) / 2
            );
            pb_Logo.BringToFront();
        }

        private void frm_Billing_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1920, 1080);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;
            dgv_Billing_Records.Columns["col_Amount_Due"].DefaultCellStyle.Format = "C2";
            dgv_Billing_Records.Columns["col_Amount_Due"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-PH");
            try
            {
                all_billing_model = repo_billing.GetAllBillingRecords() ?? new List<Model_Billing>(); // Get all billing records

                if (all_billing_model.Count == 0)
                {
                    dgv_Billing_Records.DataSource = null; // Clear DataGridView if no data
                    MessageBox.Show("No billing records found.");
                    return;
                }
                // Group and format the billing data using the GroupAndFormatBillingData method
                groupedBillingData = GroupAndFormatBillingData(all_billing_model);
                // Bind the grouped data to the DataGridView
                dgv_billing_binding_source.DataSource = groupedBillingData;
                dgv_Billing_Records.DataSource = dgv_billing_binding_source;
                SetIconColumns(); // Set icons for the columns
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load billing records: " + ex.Message);
            }
            ////FILTERING
            cmb_Billing_Filter.Items.Clear();
            cmb_Billing_Filter.Items.AddRange(new string[] { "All", "Pending", "Confirmed", "Cancelled", "Completed" });
            cmb_Billing_Filter.SelectedIndexChanged += cmb_Billing_Filter_SelectedIndexChanged;
            cmb_Billing_Filter.SelectedIndex = 1; // Default to "Pending"
            //SORTING
            cmb_Billing_Sort.Items.Clear();
            cmb_Billing_Sort.Items.AddRange(new string[] { "Control Number", "Reservation Date", "Requesting Person", "Reservation Type", "Reservation Status", "Amount Due" });
            cmb_Billing_Sort.SelectedIndex = 0; // Default selection
            cmb_Billing_Sort.SelectedIndexChanged += cmb_Billing_Sort_SelectedIndexChanged;
            ApplySearchFilter(""); // ✅ This will apply default filter + sort on load
        }
        // Filter and Sort Events
        private void cmb_Billing_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySearchFilter(sb_Billing_Search_Bar.Text.Trim().ToLower());
        }

        private void cmb_Billing_Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySearchFilter(sb_Billing_Search_Bar.Text.Trim().ToLower());
        }

        private void ApplySearchFilter(string searchTerm)
        {
            IEnumerable<Model_Billing> filtered = groupedBillingData;

            if (groupedBillingData == null)
                return;

            // Apply filter
            string filterValue = cmb_Billing_Filter.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(filterValue) && filterValue != "All")
            {
                filtered = filtered.Where(b => b.fld_Reservation_Status.Equals(filterValue, StringComparison.OrdinalIgnoreCase));
            }

            // Apply search
            if (!string.IsNullOrEmpty(searchTerm))
            {
                filtered = filtered.Where(item =>
                    (item.fld_Control_Number?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Full_Name?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Venue_Name?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Reservation_Type?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.fld_Reservation_Status?.ToLower().Contains(searchTerm) ?? false) ||
                    (item.EquipmentNames.Any(equipment => equipment.ToLower().Contains(searchTerm)))
                );
            }

            // Apply sort
            string sortBy = cmb_Billing_Sort.SelectedItem?.ToString();
            switch (sortBy)
            {
                case "Control Number":
                    filtered = filtered.OrderByDescending(b => b.pk_ReservationID);
                    break;
                case "Reservation Date":
                    filtered = filtered.OrderByDescending(b => b.fld_Start_Date);
                    break;
                case "Requesting Person":
                    filtered = filtered.OrderByDescending(b => b.fld_Full_Name);
                    break;
                case "Reservation Type":
                    filtered = filtered.OrderByDescending(b => b.fld_Reservation_Type);
                    break;
                case "Reservation Status":
                    filtered = filtered.OrderByDescending(b => b.fld_Reservation_Status);
                    break;
                case "Amount Due":
                    filtered = filtered.OrderByDescending(b => b.fld_Total_Amount);
                    break;
            }

            dgv_billing_binding_source.DataSource = filtered.ToList();
            dgv_Billing_Records.DataSource = dgv_billing_binding_source;
        }

        //Search Bar
        private void sb_Billing_Search_Bar_TextChanged(object sender, EventArgs e)
        {
            ApplySearchFilter(sb_Billing_Search_Bar.Text.Trim().ToLower());
        }

        // Datagrid Cell Content Click
        private async void dgv_Billing_Records_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            // Check if the clicked cell is not a header row
            if (e.RowIndex >= 0)
            {
                // You can use e.RowIndex and e.ColumnIndex to get the clicked cell's data
                var clickedCellValue = dgv_Billing_Records[e.ColumnIndex, e.RowIndex].Value;
            }

            string columnName = dgv_Billing_Records.Columns[e.ColumnIndex].Name;

            int reservationID = Convert.ToInt32(dgv_Billing_Records.Rows[e.RowIndex].Cells["pk_ReservationID"].Value);
            string currentStatus = dgv_Billing_Records.Rows[e.RowIndex].Cells["col_Reservation_Status"].Value.ToString();

            if (reservationID <= 0)
            {
                MessageBox.Show("Invalid Reservation ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Load billing details
            Model_Billing billing = repo_billing.GetBillingDetailsByReservationID(reservationID);

            if (billing == null)
            {
                MessageBox.Show("Billing details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Dynamically load correct UserControl
            pnl_Billing_Details.Controls.Clear(); // my panel to host the control
            UserControl billingControl = null;

            switch (billing.fld_Reservation_Type)
            {
                case "Venue":
                    var venueControl = new Venue_User_Control(billing, repo_billing);
                    venueControl.Dock = DockStyle.Fill;
                    venueControl.LoadBillingDetails(billing);
                    venueControl.OnRequestVenueExtension += (reservationID, status) =>
                    {
                        OpenExtendVenueForm(reservationID); // Your existing logic
                    };
                    billingControl = venueControl;
                    venueControl.RequestBillingRefresh += RefreshBillingRecords;
                    pnl_Billing_Details.Controls.Clear();
                    pnl_Billing_Details.Controls.Add(venueControl);
                   
                    break;

                case "Equipment":
                    var equipmentControl = new Equipment_User_Control(billing, repo_billing);
                    equipmentControl.Dock = DockStyle.Fill;
                    equipmentControl.LoadBillingDetails(billing);
                    // Subscribe to the event when the Equipment User Control is loaded
                    equipmentControl.EquipmentBillingUpdated += (s, e) =>
                    {
                        // When the equipment billing is updated, refresh the billing records
                        RefreshBillingRecords(highlightReservationID: reservationID);
                    };
                    billingControl = equipmentControl;
                    equipmentControl.RequestBillingRefresh += RefreshBillingRecords;
                    pnl_Billing_Details.Controls.Clear();
                    pnl_Billing_Details.Controls.Add(equipmentControl);

                    break;

                default:
                    MessageBox.Show("Unsupported reservation type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            if (billingControl != null)
            {
                pnl_Billing_Details.Controls.Add(billingControl);
                pnl_Billing_Details.Visible = true;
            }

            // Handle Specific Column Actions
            switch (columnName)
            {
                case "col_Print":
                    await PrintBilling(reservationID, currentStatus);
                    break;
                    /* Removed Feature
                case "col_Approved":
                    await HandleApprovalAsync(reservationID, currentStatus);
                    break;

                case "col_Cancel":
                    await HandleCancellationAsync(reservationID, currentStatus);
                    break;

                case "col_Extend":
                    HandleExtension(reservationID, e.RowIndex);
                    break;
                    */
            }
        }

        // Datagridview Color Format
        private void dgv_Billing_Records_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_Billing_Records.Rows.Count && !dgv_Billing_Records.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgv_Billing_Records.Rows[e.RowIndex];
                string statusColumnName = "col_Reservation_Status";

                try
                {
                    object cellValue = row.Cells[statusColumnName].Value;
                    var billing = row.DataBoundItem as Model_Billing;

                    if (billing != null && billing.fld_Created_At != null)
                    {
                        TimeSpan timeSinceCreated = DateTime.Now - billing.fld_Created_At;

                        if (cellValue?.ToString() == "Pending" && timeSinceCreated.TotalHours >= 72)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 228, 225); // RED
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else if (cellValue?.ToString() == "Cancelled")
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(200, 220, 255); // BLUE
                        }
                        else if (cellValue?.ToString() == "Confirmed")
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(225, 255, 225); // GREEN
                        }
                        else if (cellValue?.ToString() == "Pending")
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        // Logic for Reservation Venue Completion
                        if (billing.fld_Reservation_Status == "Confirmed" //The reservation must be in the "Confirmed" status.
                            && billing.fld_Reservation_Type == "Venue" //  It must be a venue reservation, not equipment.
                            && billing.fld_Confirmation_Date.HasValue //  There must be a confirmation date (i.e. it’s not null).
                            && (DateTime.Now - billing.fld_Confirmation_Date.Value).TotalDays >= 5 // The reservation has been confirmed for 5 or more days.
                            && DateTime.Now > billing.fld_End_Date // The reservation’s end date has passed (i.e. it's already finished).
                            && (billing.fld_OR != null && billing.fld_OR > 0)) // There is a valid OR (Official Receipt) number (not null, not zero).
                        {
                            row.DefaultCellStyle.BackColor = Color.Orange;
                            row.DefaultCellStyle.ForeColor = Color.White;

                            Repo_Billing repo = new Repo_Billing();
                            repo.MarkReservationAsCompleted(billing.pk_ReservationID);
                        }


                        // Color rows that are already Completed
                        if (billing.fld_Reservation_Status == "Completed")
                        {
                            row.DefaultCellStyle.BackColor = Color.Orange;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during cell formatting: {ex.Message}");
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                // Alignment logic
                string columnName = dgv_Billing_Records.Columns[e.ColumnIndex].Name;
                if (columnName == "fld_Control_Number" || columnName == "col_Print" || columnName == "fld_Full_Name")
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                else
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }


        // SOA RDLC
        private async Task PrintBilling(int reservationID, string currentStatus) // Print Collection Slip
        {
            // Check if the reservation status is "Pending"
            if (currentStatus != "Pending")
            {
                MessageBox.Show("Only 'Pending' reservations can be printed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frm_Print_Billing printBillingForm = new frm_Print_Billing(reservationID);
            printBillingForm.ShowDialog();
        }

        // Button is Hidden for now, but implement it later (approved report printing from Ordinance)
        private void btn_Reports_Click(object sender, EventArgs e)
        {
            frm_Report_Billing_Main reportBillingForm = new frm_Report_Billing_Main();
            reportBillingForm.ShowDialog(); // Opens the form as a modal dialog

        }

        // Refresh Billing Records
        private void RefreshBillingRecords(int? highlightReservationID = null)
        {
            try
            {
                all_billing_model = repo_billing.GetAllBillingRecords() ?? new List<Model_Billing>();

                if (all_billing_model.Count == 0)
                {
                    dgv_Billing_Records.DataSource = null;
                    MessageBox.Show("No billing records found.");
                    return;
                }

                // Update grouped data
                groupedBillingData = GroupAndFormatBillingData(all_billing_model);

                // Re-apply filter, search, and sort
                ApplySearchFilter(sb_Billing_Search_Bar.Text.Trim().ToLower());

                // Highlight row if needed
                if (highlightReservationID.HasValue)
                {
                    bool rowFound = false;
                    foreach (DataGridViewRow row in dgv_Billing_Records.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["pk_ReservationID"].Value) == highlightReservationID.Value)
                        {
                            row.Selected = true;

                            dgv_Billing_Records.CurrentCell = row.Cells
                                .Cast<DataGridViewCell>()
                                .FirstOrDefault(c => c.Visible);

                            rowFound = true;
                            break;
                        }
                    }

                    if (rowFound)
                    {
                        var selectedRow = dgv_Billing_Records.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => r.Selected);

                        if (selectedRow != null)
                        {
                            dgv_Billing_Records.FirstDisplayedScrollingRowIndex = selectedRow.Index;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to refresh billing records: " + ex.Message);
            }
        }

        // DGV Grouping and Formatting
        private List<Model_Billing> GroupAndFormatBillingData(List<Model_Billing> billingData)
        {
            try
            {
                var groupedData = billingData
                    .GroupBy(item => new
                    {
                        item.fld_Control_Number,
                        item.fld_Reservation_Type,
                        item.fld_Start_Date,
                        item.fld_Total_Amount,
                        item.fld_Reservation_Status,
                        item.fld_Created_At
                    })
                    .Select(group =>
                    {
                        var billingRecord = group.First(); // Keep the first record per group

                        // Combine equipment names into a list
                        billingRecord.EquipmentNames = group
                            .Select(x => x.fld_Equipment_Name)
                            .Where(name => !string.IsNullOrEmpty(name))
                            .Distinct()
                            .ToList();

                        return billingRecord;
                    })
                    .ToList();

                dgv_Billing_Records.AutoGenerateColumns = false;// Disable auto-generated columns

                // Re-assign the data source
                dgv_billing_binding_source.DataSource = groupedData;
                dgv_Billing_Records.DataSource = dgv_billing_binding_source;

                SetIconColumns();// Refresh icon 

                // Adjust column order if needed
                if (!dgv_Billing_Records.Columns.Contains("col_Reservation_Name"))
                {
                    dgv_Billing_Records.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "col_Reservation_Name",
                        HeaderText = "RESERVATION",
                        DataPropertyName = "DisplayReservationName",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    });
                }
                if (dgv_Billing_Records.Columns.Contains("col_Reservation_Name"))
                {
                    dgv_Billing_Records.Columns["col_Reservation_Name"].DisplayIndex = 2;
                }
                return groupedData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to group and format billing records: " + ex.Message);
                return new List<Model_Billing>(); // Return empty list in case of error
            }
        }

        // Extend Venue Form
        public void OpenExtendVenueForm(int reservationID)
        {
            frm_Extend_Venue extendForm = new frm_Extend_Venue(reservationID);

            // Subscribe to the event BEFORE showing the form
            extendForm.OnExtensionSuccessful += () =>
            {

                // Ensure we get the updated details of the reservation after it is extended
                Model_Billing updatedDetails = all_billing_model.FirstOrDefault(r => r.pk_ReservationID == reservationID);
                if (updatedDetails != null)
                {
                    // Dynamically load the correct UserControl based on the reservation type
                    UserControl billingControl = null;
                    switch (updatedDetails.fld_Reservation_Type)
                    {
                        case "Venue":
                            var venueControl = new Venue_User_Control(updatedDetails, repo_billing); // Pass updated details to the constructor
                            venueControl.Dock = DockStyle.Fill;
                            billingControl = venueControl;
                            break;

                        case "Equipment":
                            var equipmentControl = new Equipment_User_Control(updatedDetails, repo_billing); // Pass updated details to the constructor
                            equipmentControl.Dock = DockStyle.Fill;
                            billingControl = equipmentControl;
                            break;

                        default:
                            MessageBox.Show("Unsupported reservation type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                    }

                    if (billingControl != null)
                    {
                        pnl_Billing_Details.Controls.Clear(); // Clear existing controls
                        pnl_Billing_Details.Controls.Add(billingControl); // Add the new control
                        pnl_Billing_Details.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Updated billing details not found for the reservation.");
                }
            };

            extendForm.ShowDialog();
            // Refresh the billing records after closing the form
            RefreshBillingRecords(reservationID);
        }

        // Set icons for specific columns
        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap resizedImg = new Bitmap(img, new Size(width, height));
            return resizedImg;
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        // Block all resizes
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int WM_NCLBUTTONDBLCLK = 0xA3; // <- THIS blocks double-click resize
            const int HTCAPTION = 0x2;

            if ((m.Msg == WM_NCLBUTTONDOWN || m.Msg == WM_NCLBUTTONDBLCLK) && m.WParam.ToInt32() == HTCAPTION)
                return; // ignore both drag and double-click maximize

            base.WndProc(ref m);
        }


        // Icons Formatting For DGV (print/cancel/approve/extend)
        private void SetIconColumns()
        {
            if (dgv_Billing_Records.Columns["col_Print"] is DataGridViewImageColumn imgCol)
            {
                Image rawImage = ByteArrayToImage(Properties.Resources.Printer_Icon);
                Image resized = ResizeImage(rawImage, 20, 20); // smaller icon
                Image padded = AddMarginToImage(resized, 30, 30); // add transparent padding
                imgCol.Image = padded;
            }
        }
        //Margin for Icons Formatting
        private Image AddMarginToImage(Image original, int totalWidth, int totalHeight)
        {
            Bitmap bmp = new Bitmap(totalWidth, totalHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent); // or set to match DataGridView background
                int x = (totalWidth - original.Width) / 2;
                int y = (totalHeight - original.Height) / 2;
                g.DrawImage(original, x, y, original.Width, original.Height);
            }
            return bmp;
        }
    }

}