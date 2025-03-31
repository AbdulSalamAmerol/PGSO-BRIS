using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Report_Billing : Form
    {
        public frm_Report_Billing()
        {
            InitializeComponent();
            
        }

        private void cmb_Include_Columns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_Venue_Or_Equipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected value
            string selectedType = cmb_Venue_Or_Equipment.SelectedItem.ToString();

            // Define the valid items for each selection
            string[] venueItems = { "Control Number", "Venue", "Name of Requesting Party", "Date Requested",
                            "Purpose", "Duration", "Origin of Reservation", "In Charge",
                            "Total Amount", "Payment Status" };
              
            string[] equipmentItems = { "Control Number", "Equipment", "Equipment Quantity", "Name of Requesting Party",
                                "Date Requested", "Duration", "In Charge",
                                "Payment Status", "Total Amount" };

            // Loop through all items in the CheckedListBox
            for (int i = 0; i < clb_Include_Columns.Items.Count; i++)
            {
                string itemText = clb_Include_Columns.Items[i].ToString();

                // Determine if the item should be shown
                bool shouldShow = (selectedType == "Venue" && venueItems.Contains(itemText)) ||
                                  (selectedType == "Equipment" && equipmentItems.Contains(itemText)) ||
                                  (selectedType == "ALL"); // Show everything when "ALL" is selected

                // Set visibility (Indeterminate = hidden, Unchecked = visible)
                clb_Include_Columns.SetItemCheckState(i, shouldShow ? CheckState.Unchecked : CheckState.Indeterminate);
            }
        }

    }

}

