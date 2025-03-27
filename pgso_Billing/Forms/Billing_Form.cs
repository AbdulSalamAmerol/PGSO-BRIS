using pgso.Billing.Repositories;
using pgso.Billing.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Globalization;
using System.Linq;
using pgso.pgso_Billing.Repositories;
using System.Drawing.Drawing2D;
using System.Drawing;
using Microsoft.Reporting.WinForms;


namespace pgso
{
    public partial class Billing_Form : Form
    {
        private Venue_Repository venueRepo = new Venue_Repository();
        private Equipment_Repo equipmentRepo = new Equipment_Repo();

        // 🔹 Add global lists to hold all billing records
        private List<class_Venue_Billing> allVenueBillings = new List<class_Venue_Billing>();
        private List<class_Equipment_Billing> allEquipmentBillings = new List<class_Equipment_Billing>();

        // Binding sources for DataGridViews
        private BindingSource venueBillingBindingSource = new BindingSource();
        private BindingSource equipmentBillingBindingSource = new BindingSource();

        public Billing_Form()
        {
            InitializeComponent(); // Initialize first

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

            // 🔹 BIND REPORT VIEWER DATA SOURCES
            reportViewer1.LocalReport.DataSources.Clear();  // Clear old data

            if (allVenueBillings.Count > 0)
            {
                ReportDataSource venueDataSource = new ReportDataSource("VenueBillingDataSet", allVenueBillings);
                reportViewer1.LocalReport.DataSources.Add(venueDataSource);
            }

            if (allEquipmentBillings.Count > 0)
            {
                ReportDataSource equipmentDataSource = new ReportDataSource("EquipmentBillingDataSet", allEquipmentBillings);
                reportViewer1.LocalReport.DataSources.Add(equipmentDataSource);
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

            // 🔹 Refresh DataGridView
            equipmentBillingBindingSource.ResetBindings(false);
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


        // Store selected billing data
        private object selectedBillingData = null;

        private void dgv_Venue_Billing_Records_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Venue_Billing_Records.Focused && dgv_Venue_Billing_Records.SelectedRows.Count > 0)
            {
                dgv_Equipment_Billing_Records.ClearSelection();
                selectedBillingData = dgv_Venue_Billing_Records.SelectedRows[0].DataBoundItem;
                flowLayoutPanel2.Invalidate(); // Trigger repaint
            }
        }

        private void dgv_Equipment_Billing_Records_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Equipment_Billing_Records.Focused && dgv_Equipment_Billing_Records.SelectedRows.Count > 0)
            {
                dgv_Venue_Billing_Records.ClearSelection();
                selectedBillingData = dgv_Equipment_Billing_Records.SelectedRows[0].DataBoundItem;
                flowLayoutPanel2.Invalidate(); // Trigger repaint
            }
        }

        private void LoadReport()
{
    reportViewer1.LocalReport.DataSources.Clear(); // Clear previous data sources
    
    // 🔹 Set the correct RDLC file path
    reportViewer1.LocalReport.ReportPath = @"C:\Users\amero\source\repos\pgso\Report1.rdlc";

    if (dgv_Venue_Billing_Records.SelectedRows.Count > 0) // Venue selected
    {
        var venueBilling = dgv_Venue_Billing_Records.SelectedRows[0].DataBoundItem as class_Venue_Billing;
        if (venueBilling != null)
        {
            List<class_Venue_Billing> venueBillingList = new List<class_Venue_Billing> { venueBilling };
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("VenueBillingDataSet", venueBillingList));
        }
    }
    else if (dgv_Equipment_Billing_Records.SelectedRows.Count > 0) // Equipment selected
    {
        var equipmentBilling = dgv_Equipment_Billing_Records.SelectedRows[0].DataBoundItem as class_Equipment_Billing;
        if (equipmentBilling != null)
        {
            List<class_Equipment_Billing> equipmentBillingList = new List<class_Equipment_Billing> { equipmentBilling };
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("EquipmentBillingDataSet", equipmentBillingList));
        }
    }
    else
    {
        MessageBox.Show("Please select a billing record first.");
        return;
    }

    reportViewer1.LocalReport.Refresh(); // Ensure the local report is updated
    reportViewer1.RefreshReport(); // Force UI refresh
}



        private void Venue_Search_Bar_TextChanged_1(object sender, EventArgs e)
        {
            // Filter filter feature
        }


        private void dgv_Venue_Billing_Records_CellContentClick(object sender, DataGridViewCellEventArgs e){}
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e){}
        private void flowLayoutPanel3_Paint_1(object sender, PaintEventArgs e){}
        private void panel4_Paint(object sender, PaintEventArgs e){}
        private void panel5_Paint(object sender, PaintEventArgs e) {}
        private void btn_Generate_Billing_Click(object sender, EventArgs e)
        {
            LoadReport();
            reportViewer1.RefreshReport();
        }
    }
}
