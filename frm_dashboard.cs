using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_dashboard : Form
    {
        private Panel sideMenu;
        private Panel mainContent;
        private TableLayoutPanel tablePanel;
        private Label lblMonthYear;
        private int currentYear;
        private int currentMonth;
        private ComboBox cmbMonth;
        private NumericUpDown numYear;

        public frm_dashboard()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            currentYear = DateTime.Now.Year;
            currentMonth = DateTime.Now.Month;

            SetupUI();
        }

        private void SetupUI()
        {
            CreateSideMenu();
            CreateMainContent();
            this.Controls.Add(mainContent);
            this.Controls.Add(sideMenu);
            UpdateCalendar();
        }

        private void CreateSideMenu()
        {
            sideMenu = new Panel
            {
                Size = new Size(200, this.ClientSize.Height),
                Dock = DockStyle.Left,
                BackColor = Color.DarkSlateGray,
                Padding = new Padding(10)
            };

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
        }

        private void CmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMonth = cmbMonth.SelectedIndex + 1;
            UpdateCalendar();
        }

        private void NumYear_ValueChanged(object sender, EventArgs e)
        {
            currentYear = (int)numYear.Value;
            UpdateCalendar();
        }

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
                TextAlign = ContentAlignment.MiddleCenter,
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
                    TextAlign = ContentAlignment.MiddleCenter,
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

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime currentDate = new DateTime(currentYear, currentMonth, day);
                bool isPast = currentDate < today;

                Label lblDayNum = new Label
                {
                    Text = day.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = isPast ? Color.Gray : Color.Black, // Gray out past dates
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.WhiteSmoke,
                    AutoSize = false,
                    Cursor = isPast ? Cursors.Default : Cursors.Hand,
                    Enabled = !isPast
                };

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
        }

        private void OpenChooseVenuesForm(int day)
        {
            frm_choosevenues frm = new frm_choosevenues();
            frm.Text = $"Choose Venue - {currentMonth}/{day}/{currentYear}";
            frm.ShowDialog();
        }
    }
}
