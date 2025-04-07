using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso
{
    public partial class UserControlDays : UserControl
    {
        public event EventHandler<DateClickedEventArgs> DateClicked;

        public UserControlDays()
        {
            InitializeComponent();
            this.Click += UserControlDays_Click;
            lblDays.Click += UserControlDays_Click;
            lblReservations.Click += UserControlDays_Click;
            lblEquipmentReservations.Click += UserControlDays_Click;
        }


        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            lblDays.Text = numday.ToString();
        }

        public void SetReservations(List<string> venueReservations, List<string> equipmentReservations)
        {
            lblReservations.Text = string.Join(Environment.NewLine, venueReservations);
            lblEquipmentReservations.Text = string.Join(Environment.NewLine, equipmentReservations);

            if (venueReservations.Any() || equipmentReservations.Any())
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control; // Default background color
            }

            if (venueReservations.Any())
            {
                lblReservations.ForeColor = Color.Green;
            }
            else
            {
                lblReservations.ForeColor = Color.Black;
            }

            if (equipmentReservations.Any())
            {
                lblEquipmentReservations.ForeColor = Color.Blue;
            }
            else
            {
                lblEquipmentReservations.ForeColor = Color.Black;
            }
        }



        private void UserControlDays_Click(object sender, EventArgs e)
        {
            DateClicked?.Invoke(this, new DateClickedEventArgs(lblDays.Text));
        
        }
    }

    public class DateClickedEventArgs : EventArgs
    {
        public string Day { get; }

        public DateClickedEventArgs(string day)
        {
            Day = day;
        }
    }
}


