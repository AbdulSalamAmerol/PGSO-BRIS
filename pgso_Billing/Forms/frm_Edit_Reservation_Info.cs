using pgso.Billing.Models;
using pgso.Billing.Repositories; // Correct namespace for Repo_Billing
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Assuming your form namespace is correct
namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Edit_Venue_Reservation_Info : Form
    {
        // Use the specific reservation ID passed in
        private int _reservationID;
        private Model_Billing _originalBillingInfo; // Store original details if needed
        private Repo_Billing _repo = new Repo_Billing();

        public frm_Edit_Venue_Reservation_Info(Model_Billing billing) // Pass the specific ID model
        {
            InitializeComponent();

            if (billing == null || billing.pk_ReservationID <= 0)
            {
                MessageBox.Show("Invalid reservation information provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally disable form controls or close
                this.Load += (s, e) => this.Close(); // Close form if invalid data
                return;
            }

            _reservationID = billing.pk_ReservationID;
            //_originalBillingInfo = billing; // Keep if needed for comparison or reset

            // Load dropdowns first
            LoadVenueDropdown();
            LoadVenueScopeDropdown(); // Load all scopes initially

            // Then load specific data for this reservation
            LoadReservationDetails();
        }

        private void LoadVenueDropdown()
        {
            try
            {
                var venueList = _repo.GetAllVenue(); // Returns List<KeyValuePair<int, string>>
                cmb_Venue.DataSource = null; // Clear previous binding
                cmb_Venue.DisplayMember = "Value"; // The Name part of KeyValuePair
                cmb_Venue.ValueMember = "Key";   // The ID part of KeyValuePair
                cmb_Venue.DataSource = venueList;
                cmb_Venue.SelectedIndex = -1; // Ensure nothing is selected initially
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading venues: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVenueScopeDropdown()
        {
            try
            {
                // Note: You might want to filter scopes based on selected venue later
                var scopeList = _repo.GetAllVenueScopes(); // Returns List<KeyValuePair<int, string>>
                cmb_Venue_Scope.DataSource = null; // Clear previous binding
                cmb_Venue_Scope.DisplayMember = "Value"; // The Name part of KeyValuePair
                cmb_Venue_Scope.ValueMember = "Key";   // The ID part of KeyValuePair
                cmb_Venue_Scope.DataSource = scopeList;
                cmb_Venue_Scope.SelectedIndex = -1; // Ensure nothing is selected initially
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading venue scopes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadReservationDetails()
        {
            try
            {
                Model_Billing details = _repo.GetReservationDetails(_reservationID);

                if (details != null)
                {
                    // Store details if needed elsewhere
                    _originalBillingInfo = details;

                    // Populate Date/Time Pickers
                    dtp_Start_Date.Value = details.fld_Start_Date.Date;
                    dtp_End_Date.Value = details.fld_End_Date.Date;
                    // Set time: Need to combine a base date (like today) with the TimeSpan
                    DateTime baseDate = DateTime.Today;
                    dtp_Start_Time.Value = baseDate + details.fld_Start_Time;
                    dtp_End_Time.Value = baseDate + details.fld_End_Time;

                    // Select items in ComboBoxes (check if DataSource is set first)
                    if (cmb_Venue.DataSource != null && details.fk_VenueID.HasValue)
                    {
                        cmb_Venue.SelectedValue = details.fk_VenueID.Value;
                    }
                    if (cmb_Venue_Scope.DataSource != null && details.fk_Venue_ScopeID.HasValue)
                    {
                        cmb_Venue_Scope.SelectedValue = details.fk_Venue_ScopeID.Value;
                    }

                    // Set CheckBox (requires fetching Aircon status)
                    bool? airconStatus = _repo.GetAirconStatusFromPricing(details.fk_Venue_PricingID);
                    if (airconStatus.HasValue)
                    {
                        cb_Aircon.Checked = airconStatus.Value;
                    }
                    else
                    {
                        cb_Aircon.Checked = false; // Default or indicate unknown?
                                                   // Consider disabling if pricing ID was null or status couldn't be fetched
                    }

                    // Store other needed info if necessary (like ReservationType)
                    // this.Tag = details.fld_Reservation_Type; // Example: store type for later use
                }
                else
                {
                    MessageBox.Show("Could not load reservation details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Disable controls or close form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation details: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Disable controls or close form
            }
        }

        // --- SAVE BUTTON CLICK HANDLER ---
        private void btn_Save_Click(object sender, EventArgs e)
        {
            // --- 1. Input Validation ---
            if (cmb_Venue.SelectedValue == null)
            {
                MessageBox.Show("Please select a Venue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Venue.Focus();
                return;
            }
            if (cmb_Venue_Scope.SelectedValue == null)
            {
                MessageBox.Show("Please select a Venue Scope.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Venue_Scope.Focus();
                return;
            }
            if (dtp_End_Date.Value.Date < dtp_Start_Date.Value.Date)
            {
                MessageBox.Show("End Date cannot be earlier than Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_End_Date.Focus();
                return;
            }
            if (dtp_End_Date.Value.Date == dtp_Start_Date.Value.Date && dtp_End_Time.Value.TimeOfDay <= dtp_Start_Time.Value.TimeOfDay)
            {
                MessageBox.Show("End Time must be later than Start Time on the same day.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_End_Time.Focus();
                return;
            }

            // --- 2. Get Values from Controls ---
            DateTime startDate = dtp_Start_Date.Value.Date;
            DateTime endDate = dtp_End_Date.Value.Date;
            TimeSpan startTime = dtp_Start_Time.Value.TimeOfDay;
            TimeSpan endTime = dtp_End_Time.Value.TimeOfDay;
            int venueId = (int)cmb_Venue.SelectedValue;
            int venueScopeId = (int)cmb_Venue_Scope.SelectedValue;
            bool aircon = cb_Aircon.Checked;

            try
            {
                // --- 3. Determine Rate Type (CRUCIAL STEP - NEEDS YOUR LOGIC) ---
                // Fetch the original reservation type IF needed to determine RateType
                string reservationType = _originalBillingInfo?.fld_Reservation_Type; // Use stored type
                string rateType = null;

                if (string.IsNullOrEmpty(reservationType))
                {
                    MessageBox.Show("Could not determine the original reservation type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Cannot proceed without type if it determines rate type
                }

                // --- EXAMPLE Rate Type Logic (REPLACE WITH YOUR ACTUAL RULES) ---
                if (reservationType == "Venue")
                {
                    // Is it always "Regular"? Or based on requesting person? Or another field?
                    // For now, ASSUME "Regular". Change this!
                    rateType = "Regular";
                }
                else
                {
                    // Handle other types or show error if only Venue type uses these pricings
                    MessageBox.Show($"Pricing lookup logic not defined for reservation type: {reservationType}", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // --- End of EXAMPLE Rate Type Logic ---


                // --- 4. Fetch Corresponding Venue Pricing Info via Repository ---
                Repo_Billing.VenuePricingResult pricing = _repo.GetVenuePricingDetails(venueId, venueScopeId, aircon, rateType);

                if (!pricing.Found)
                {
                    MessageBox.Show($"No pricing information found for the selected combination:\nVenue: {cmb_Venue.Text}\nScope: {cmb_Venue_Scope.Text}\nAircon: {(aircon ? "Yes" : "No")}\nRate Type: {rateType}\n\nPlease check the pricing configuration.",
                                    "Pricing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Stop execution
                }

                // --- 5. Update the Reservation Record via Repository ---
                // TODO: Add calculation logic for Total Amount / OT Hours if needed before calling update
                // decimal calculatedTotal = CalculateTotalAmount(...);
                // int calculatedOT = CalculateOTHours(...);

                bool success = _repo.UpdateVenueReservation(
                    _reservationID,
                    startDate,
                    endDate,
                    startTime,
                    endTime,
                    venueId,
                    venueScopeId,
                    pricing.PricingID,
                    pricing.First4HrsRate,
                    pricing.HourlyRate
                // Pass calculated total/OT here if implemented
                );

                // --- 6. Provide Feedback ---
                if (success)
                {
                    MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Set dialog result
                    this.Close(); // Close the form
                }
                else
                {
                    MessageBox.Show("Failed to update reservation. Please check logs or try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Log ex.ToString() for detailed diagnostics
                MessageBox.Show($"An error occurred during the save process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Optional: Add event handlers for cmb_Venue changing if scope depends on it
        // private void cmb_Venue_SelectedIndexChanged(object sender, EventArgs e)
        // {
        //     // Reload/filter cmb_Venue_Scope based on cmb_Venue.SelectedValue
        // }

        // --- TODO: Implement Calculation Logic if needed ---
        // private decimal CalculateTotalAmount(...) { ... }
        // private int CalculateOTHours(...) { ... }

    }
}