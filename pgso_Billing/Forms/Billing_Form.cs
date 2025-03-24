using pgso.Billing.Repositories;
using pgso.Billing.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Globalization;
using System.Linq;
using pgso.pgso_Billing.Repositories;

namespace pgso
{
    public partial class Billing_Form : Form
    {
        private Venue_Repository venueRepo = new Venue_Repository();
        private Equipment_Repo equipmentRepo = new Equipment_Repo();

        // 🔹 Add global lists to hold all billing records
        private List<class_Venue_Billing> allVenueBillings = new List<class_Venue_Billing>();
        private List<class_Equipment_Billing> allEquipmentBillings = new List<class_Equipment_Billing>();

        // 🔹 ADD THIS LINE HERE 👇
        private BindingSource venueBillingBindingSource = new BindingSource();
        private BindingSource equipmentBillingBindingSource = new BindingSource();

        public Billing_Form()
        {
            InitializeComponent();
        }

        private void Billing_Form_Load(object sender, EventArgs e)
        {
            try
            {
                // Get all billing records
                allVenueBillings = venueRepo.GetAllBillingRecords();
                allEquipmentBillings = equipmentRepo.GetAllEquipmentBillingRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load billing records: " + ex.Message);
                return; // Exit early if there's an error
            }

            // Set up DataGridView for Venue Billing Records
            dgv_Venue_Billing_Records.AutoGenerateColumns = false;
            venueBillingBindingSource.DataSource = allVenueBillings;
            dgv_Venue_Billing_Records.DataSource = venueBillingBindingSource;

            // Set up DataGridView for Equipment Billing Records
            dgv_Equipment_Billing_Records.AutoGenerateColumns = false;
            equipmentBillingBindingSource.DataSource = allEquipmentBillings;
            dgv_Equipment_Billing_Records.DataSource = equipmentBillingBindingSource;

            // Show a message if no records are found
            if (allVenueBillings.Count == 0 && allEquipmentBillings.Count == 0)
            {
                MessageBox.Show("No billing records found.");
            }

            // Attach event handlers for both search bars
            Equipment_Search_Bar.TextChanged += Equipment_Search_Bar_TextChanged;  // Equipment search
            Venue_Search_Bar.TextChanged += Venue_Search_Bar_TextChanged;  // Venue search
        }

        // 🔹 Equipment search/filter method
        private void Equipment_Search_Bar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = Equipment_Search_Bar.Text.Trim().ToLower();

            var filteredEquipmentList = allEquipmentBillings.Where(b =>
                b.fld_Control_Number.ToLower().Contains(searchTerm) ||
                b.fld_Equipment_Name.ToLower().Contains(searchTerm) ||
                b.fld_Full_Name.ToLower().Contains(searchTerm) ||
                b.fld_Total_Equipment_Cost.ToString().ToLower().Contains(searchTerm)
            ).ToList();

            // Conditionally set the data source based on the search term
            if (string.IsNullOrEmpty(searchTerm))
                equipmentBillingBindingSource.DataSource = allEquipmentBillings;
            else
                equipmentBillingBindingSource.DataSource = filteredEquipmentList;
        }

        // 🔹 Venue search/filter method
        private void Venue_Search_Bar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = Venue_Search_Bar.Text.Trim().ToLower();

            var filteredVenueList = allVenueBillings.Where(b =>
                b.fld_Control_Number.ToLower().Contains(searchTerm) ||
                b.fld_Venue_Name.ToLower().Contains(searchTerm) ||
                b.fld_Full_Name.ToLower().Contains(searchTerm) ||
                b.fld_Payment_Status.ToLower().Contains(searchTerm)
            ).ToList();

            // Conditionally set the data source based on the search term
            if (string.IsNullOrEmpty(searchTerm))
                venueBillingBindingSource.DataSource = allVenueBillings;
            else
                venueBillingBindingSource.DataSource = filteredVenueList;
        }
    }
}
