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
    public partial class UserControlDaysEquipment : UserControl
    {
        public event EventHandler<DateClickedEventArgs> DateClicked;

        public UserControlDaysEquipment()
        {
            InitializeComponent();
            this.Click += UserControlDaysEquipment_Click;
            lblDays_Equipment.Click += UserControlDaysEquipment_Click;
           // walato.Click += UserControlDays_Click;
            lblEquipmentReservations.Click += UserControlDaysEquipment_Click;
        }


        private void UserControlDaysEquipment_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            lblDays_Equipment.Text = numday.ToString();
        }

        public void SetReservations(List<string> venueReservations, List<string> equipmentReservations)
        {
            // Ensure null checks are performed before accessing the collections
            bool hasVenueReservations = venueReservations?.Any() ?? false;
            bool hasEquipmentReservations = equipmentReservations?.Any() ?? false;

            lblEquipmentReservations.Text = string.Join(Environment.NewLine, equipmentReservations ?? new List<string>());

            if (hasVenueReservations || hasEquipmentReservations)
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control; // Default background color
            }

           

            if (hasEquipmentReservations)
            {
                lblEquipmentReservations.ForeColor = Color.Blue;
            }
            else
            {
                lblEquipmentReservations.ForeColor = Color.Black;
            }
        }




        private void UserControlDaysEquipment_Click(object sender, EventArgs e)
        {
            //DateClicked?.Invoke(this, new DateClickedEventArgs(lblDays.Text));

        }

        private void lblReservations_Equipment_Click(object sender, EventArgs e)
        {

        }
    }

    /*public class DateClickedEventArgs : EventArgs
    {
        public string Day { get; }

        public DateClickedEventArgs(string day)
        {
            Day = day;
        }
    }*/
}


