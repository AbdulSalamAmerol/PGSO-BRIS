using pgso_connect;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Dashboard : Form
    {
        //fields
        private Panel sideMenu;
        private Panel mainContent;
        private TableLayoutPanel tablePanel;
        private Label lblMonthYear;
        private int currentYear;
        private int currentMonth;
        private ComboBox cmbMonth;
        private NumericUpDown numYear;

        //dashboard properties
        public frm_Dashboard()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = true;

            currentYear = DateTime.Now.Year;
            currentMonth = DateTime.Now.Month;
            DisplayCalendar();
            SetupUI();
            this.Load += frm_Dashboard_Load;
        }

        private void SetupUI()
        {
            CreateSideMenu();
          //  CreateMainContent();
            this.Controls.Add(mainContent);
            this.Controls.Add(sideMenu);
           // UpdateCalendar();
        }
        private void DisplayCalendar()
        {
            frm_Calendar calendar = new frm_Calendar();
            calendar.TopLevel = false;
            calendar.FormBorderStyle = FormBorderStyle.None;
            calendar.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(calendar);
            calendar.Show();
        }

        private void CreateSideMenu()
        {
            /*sideMenu = new Panel
            {
                Size = new Size(200, this.ClientSize.Height),
                Dock = DockStyle.Left,
                BackColor = Color.DarkSlateGray,
                Padding = new Padding(10)
            };*/
/*
            Label menuLabel = new Label
            {
                Text = "Select Month & Year",
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            sideMenu.Controls.Add(menuLabel);

            cmbMonth = new ComboBox
            {
                Size = new Size(180, 30),
                Location = new Point(10, 50),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbMonth.Items.AddRange(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Take(12).ToArray());
            cmbMonth.SelectedIndex = currentMonth - 1;
            cmbMonth.SelectedIndexChanged += CmbMonth_SelectedIndexChanged;
            sideMenu.Controls.Add(cmbMonth);

            numYear = new NumericUpDown
            {
                Size = new Size(180, 30),
                Location = new Point(10, 90),
                Minimum = DateTime.Now.Year, // Restrict past years
                Maximum = 2100,
                Value = currentYear
            };
            numYear.ValueChanged += NumYear_ValueChanged;
            sideMenu.Controls.Add(numYear);
*/
            // Button Venue
            /*
            Button Venues = new Button
            {
                Text = "Manage Reservations",
                Size = new Size(180, 30),
                Location = new Point(10, 130),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Font = new Font("Century Gothic", 10, FontStyle.Regular)
            };
            Venues.Click += Venues_Click;
            sideMenu.Controls.Add(Venues);
            */
           

            
        }

        // Event handler for button venues click
        private void Venues_Click(object sender, EventArgs e)
        {
            //uncomment ako later
            frm_mngreservation frm_venues = new frm_mngreservation();
            //frm_venues.DashboardRefreshRequested += Frm_venues_DashboardRefreshRequested;
            frm_venues.ShowDialog();
        }

        private void Frm_venues_DashboardRefreshRequested(object sender, EventArgs e)
        {
           // UpdateCalendar();
        }

        private void frm_Dashboard_Load(object sender, EventArgs e)
        {
            // Display frm_Calendar upon opening
            DisplayCalendar();
        }
        /*

        //button utilities
        private void Activity_Logs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked!", "Notification");
        }

        private void Manage_Reports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked!", "Notification");
        }

        private void CmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMonth = cmbMonth.SelectedIndex + 1;
           // UpdateCalendar();
        }

        private void NumYear_ValueChanged(object sender, EventArgs e)
        {
            currentYear = (int)numYear.Value;
           // UpdateCalendar();
        }*/
        /*
        private DataTable GetReservationsForMonth(int year, int month)
        {
            DataTable reservations = new DataTable();
            try
            {
                Connection db = new Connection();
                db.strCon.Open();

                string query = @"
            SELECT fld_Activity_Name, fld_Start_Date, fld_End_Date, fld_Reservation_Status
            FROM tbl_Reservation
            WHERE ((YEAR(fld_Start_Date) = @Year AND MONTH(fld_Start_Date) = @Month)
               OR (YEAR(fld_End_Date) = @Year AND MONTH(fld_End_Date) = @Month))
              AND fld_Reservation_Status IN ('Confirmed', 'Pending')";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Month", month);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(reservations);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservations: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return reservations;
        }*/
        /*
        private void CreateMainContent()
        {
            mainContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            lblMonthYear = new Label
            {
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.TopLeft,
                Dock = DockStyle.Top,
                Height = 40
            };
            mainContent.Controls.Add(lblMonthYear);

            tablePanel = new TableLayoutPanel
            {
                RowCount = 7,
                ColumnCount = 7,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.LightGray
            };

            for (int i = 0; i < 7; i++)
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));
            for (int i = 0; i < 7; i++)
                tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 7));

            mainContent.Controls.Add(tablePanel);
        }

        private void UpdateCalendar()
        {
            tablePanel.Controls.Clear();
            lblMonthYear.Text = new DateTime(currentYear, currentMonth, 1).ToString("MMMM yyyy");

            string[] dayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            for (int i = 0; i < 7; i++)
            {
                Label lblDay = new Label
                {
                    Text = dayNames[i],
                    TextAlign = ContentAlignment.BottomCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    BackColor = Color.DarkSlateGray,
                    ForeColor = Color.White
                };
                tablePanel.Controls.Add(lblDay, i, 0);
            }

            DateTime firstDayOfMonth = new DateTime(currentYear, currentMonth, 1);
            int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
            int startDay = (int)firstDayOfMonth.DayOfWeek;

            int row = 1;
            int col = startDay;
            DateTime today = DateTime.Today;

            DataTable reservations = GetReservationsForMonth(currentYear, currentMonth);

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime currentDate = new DateTime(currentYear, currentMonth, day);
                bool isPast = currentDate < today;

                // Find reservations for the current date
                var activities = reservations.AsEnumerable()
                    .Where(r => currentDate >= r.Field<DateTime>("fld_Start_Date") && currentDate <= r.Field<DateTime>("fld_End_Date"))
                    .Select(r => new
                    {
                        ActivityName = r.Field<string>("fld_Activity_Name"),
                        Status = r.Field<string>("fld_Reservation_Status")
                    })
                    .ToList();

                // Display the date and activities
                Label lblDayNum = new Label
                {
                    Text = day.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.TopLeft,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = isPast ? Color.Gray : Color.Black, // Gray out past dates
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.WhiteSmoke,
                    AutoSize = false,
                    Cursor = isPast ? Cursors.Default : Cursors.Hand,
                    Enabled = !isPast
                };

                if (activities.Any())
                {
                    lblDayNum.Text += "\n" + string.Join("\n", activities.Select(a => a.ActivityName));
                    if (isPast)
                    {
                        lblDayNum.BackColor = Color.Orange; // Past reservations that are already done
                    }
                    else
                    {
                        lblDayNum.BackColor = activities.Any(a => a.Status == "Pending") ? Color.Red : Color.Green; // Pending is red, Approved is green
                    }
                }

                if (!isPast)
                    lblDayNum.Click += (s, e) => OpenChooseVenuesForm(day);

                tablePanel.Controls.Add(lblDayNum, col, row);
                col++;
                if (col == 7)
                {
                    col = 0;
                    row++;
                }
            }
        }*/

        private void OpenChooseVenuesForm(int day)
        {
            frm_reservation_forms frm = new frm_reservation_forms();
            frm.Text = $"Choose Venue - {currentMonth}/{day}/{currentYear}";
            frm.ShowDialog();
        }

        private void frm_dashboard_Load(object sender, EventArgs e)
        {

        }

        //CREATE RESERVATION START
        private void venueToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            frm_Create_Venuer_Reservation Venue = new frm_Create_Venuer_Reservation();
            Venue.Show();
        }

        private void equipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Create_Equipment_Reservation Utility = new frm_Create_Equipment_Reservation();
            Utility.Show();
        }
        //CREATE RESERVATION END
        //
        //MANAGE RESERVATION START
        private void venueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_Venues Venues = new frm_Venues();
            Venues.TopLevel = false;
            Venues.FormBorderStyle = FormBorderStyle.None;
            Venues.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(Venues);
            Venues.Show();
        }

        private void approvedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Venue_Approved AprVenue = new frm_Venue_Approved();
            AprVenue.TopLevel = false;
            AprVenue.FormBorderStyle = FormBorderStyle.None;
            AprVenue.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(AprVenue);
            AprVenue.Show();
        }
        private void equipmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_Equipment EqApproved = new frm_Equipment();
            EqApproved.TopLevel = false;
            EqApproved.FormBorderStyle = FormBorderStyle.None;
            EqApproved.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(EqApproved);
            EqApproved.Show();
        }

        //MANAGE RESERVATION END

        //Manage FACILITIES START
        private void manageFacilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Manage_Facilities Facilities = new frm_Manage_Facilities();
            Facilities.TopLevel = false;
            Facilities.FormBorderStyle = FormBorderStyle.None;
            Facilities.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(Facilities);
            Facilities.Show();
        }

        private void pendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Venue_Pending PenVenues = new frm_Venue_Pending();
            PenVenues.TopLevel = false;
            PenVenues.FormBorderStyle = FormBorderStyle.None;
            PenVenues.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(PenVenues);
            PenVenues.Show();
        }

        private void cancelledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Venues VenCancelled = new frm_Venues();
            VenCancelled.TopLevel = false;
            VenCancelled.FormBorderStyle = FormBorderStyle.None;
            VenCancelled.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(VenCancelled);
            VenCancelled.Show();
        }

        private void pendingReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Equipment_Pending EqPending = new frm_Equipment_Pending();
            EqPending.TopLevel = false;
            EqPending.FormBorderStyle = FormBorderStyle.None;
            EqPending.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(EqPending);
            EqPending.Show();
        }

        private void approvedReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Equipment EqApproved = new frm_Equipment();
            EqApproved.TopLevel = false;
            EqApproved.FormBorderStyle = FormBorderStyle.None;
            EqApproved.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(EqApproved);
            EqApproved.Show();
        }

        private void cancelledReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Equipment_Cancelled EqCancelled = new frm_Equipment_Cancelled();
            EqCancelled.TopLevel = false;
            EqCancelled.FormBorderStyle = FormBorderStyle.None;
            EqCancelled.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(EqCancelled);
            EqCancelled.Show();
        }

        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Calendar Calendar = new frm_Calendar();
            Calendar.TopLevel = false;
            Calendar.FormBorderStyle = FormBorderStyle.None;
            Calendar.Dock = DockStyle.Fill;
            this.panel_Display.Controls.Clear();
            this.panel_Display.Controls.Add(Calendar);
            Calendar.Show();
        }

        private void panel_Display_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void viewReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        //Manage Facilities End
    }
}
