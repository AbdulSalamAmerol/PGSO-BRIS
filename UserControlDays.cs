using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pgso_connect;


namespace pgso
{
    public partial class UserControlDays : UserControl
    {
        public event EventHandler<DateClickedEventArgs> DateClicked;

        public UserControlDays()
        {
            InitializeComponent();

            // Set combo box styles
            combo_Venues.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_Equipments.DropDownStyle = ComboBoxStyle.DropDownList;

            // Event subscriptions
            combo_Venues.SelectedIndexChanged += Combo_Venues_SelectedIndexChanged;
            combo_Equipments.SelectedIndexChanged += Combo_Equipments_SelectedIndexChanged;

            // Prevent click events from bubbling up
            combo_Venues.Click += (s, e) => { /* Consume the click */ };
            combo_Equipments.Click += (s, e) => { /* Consume the click */ };
        }

        public void days(int numday)
        {
            lblDays.Text = numday.ToString();
        }

        public void SetReservations(List<(string DisplayName, string ControlNumber)> venueReservations,
                             List<(string DisplayName, string ControlNumber)> equipmentReservations)
        {
            venueReservations = venueReservations ?? new List<(string, string)>();
            equipmentReservations = equipmentReservations ?? new List<(string, string)>();

            // Set combo box data sources
            combo_Venues.DataSource = venueReservations.Select(v => v.DisplayName).ToList();
            combo_Equipments.DataSource = equipmentReservations.Select(e => e.DisplayName).ToList();

            // Handle duplicates in equipmentReservations
            combo_Venues.Tag = venueReservations.ToDictionary(v => v.DisplayName, v => v.ControlNumber);
            combo_Equipments.Tag = equipmentReservations
                .GroupBy(e => e.DisplayName)
                .ToDictionary(g => g.Key, g => g.First().ControlNumber);

            // Set visibility and other properties as before
            bool hasVenueReservations = venueReservations.Any();
            bool hasEquipmentReservations = equipmentReservations.Any();

            combo_Venues.Visible = hasVenueReservations;
            combo_Equipments.Visible = hasEquipmentReservations;

            this.BackColor = hasVenueReservations || hasEquipmentReservations ? Color.Salmon : SystemColors.ControlDark;

            combo_Venues.ForeColor = hasVenueReservations ? Color.Green : Color.Black;
            combo_Equipments.ForeColor = hasEquipmentReservations ? Color.Blue : Color.Black;
        }

        private void Combo_Venues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Venues.SelectedItem != null && combo_Venues.Focused)
            {
                var selectedName = combo_Venues.SelectedItem.ToString();
                var controlNumbers = (Dictionary<string, string>)combo_Venues.Tag;
                if (controlNumbers.TryGetValue(selectedName, out var controlNumber))
                {
                    ShowReservationDetails(controlNumber, "Venue");
                }
            }
        }

        private void Combo_Equipments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Equipments.SelectedItem != null && combo_Equipments.Focused)
            {
                var selectedName = combo_Equipments.SelectedItem.ToString();
                var controlNumbers = (Dictionary<string, string>)combo_Equipments.Tag;
                if (controlNumbers.TryGetValue(selectedName, out var controlNumber))
                {
                    ShowReservationDetails(controlNumber, "Equipment");
                }
            }
        }

        private void ShowReservationDetails(string controlNumber, string type)
        {
            using (var detailsForm = new frm_ReservationDetails())
            {
                detailsForm.SetReservationDetails(controlNumber, type);

                // Ensure the parent form is set as the owner
                var parentForm = this.FindForm();
                if (parentForm != null)
                {
                    detailsForm.Owner = parentForm;
                }

                // Show the form as a modal dialog
                detailsForm.ShowDialog();
            }
        }




        // These can remain empty as we're handling visibility in SetReservations
        private void lblReservations_Click(object sender, EventArgs e) { }
        private void lblEquipmentReservations_Click(object sender, EventArgs e) { }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        private void UserControlDays_Load_1(object sender, EventArgs e)
        {

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
