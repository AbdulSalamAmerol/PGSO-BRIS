using pgso.Billing.Models;
using pgso.Billing.Repositories;
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
    public partial class frm_Edit_Venue_Reservation_Info : Form
    {
        
        private TimeSpan _initialStartTime;
        private TimeSpan _initialEndTime;
        private TimeSpan _initialStartDate; // Store initial date duration for validation
        private TimeSpan _initialEndDate; // Store initial date duration for validation
        private TimeSpan _initialDuration;
        private TimeSpan _initialDateDuration; // Store initial date duration for validation
        // Use the specific reservation ID passed in
        private int _reservationID;
        private Model_Billing _originalBillingInfo; // Store original details
        private Repo_Billing _repo = new Repo_Billing();

        // Constants for Rate Types (Recommended)
        private const string RATE_TYPE_REGULAR = "Regular";
        private const string RATE_TYPE_SPECIAL = "Special";
        private const string RATE_TYPE_PGNV = "PGNV";

        // Update the screen when reservation is updated
        public event EventHandler ReservationUpdated;

        public frm_Edit_Venue_Reservation_Info(Model_Billing billing)
        {
            InitializeComponent();
            

            if (billing == null || billing.pk_ReservationID <= 0)
            {
                MessageBox.Show("Invalid reservation information provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => this.Close();
                return;
            }

            _reservationID = billing.pk_ReservationID;

            // Load dropdowns first (without triggering SelectedIndexChanged events initially)
            LoadVenueDropdown();
            // Load all scopes initially might be okay, or load empty and let venue selection populate it
            LoadVenueScopeDropdown(null); // Load empty or all initially

            // Then load specific data for this reservation
            LoadReservationDetails();
        }

        private void LoadVenueDropdown()
        {
            try
            {
                var venueList = _repo.GetAllVenue();
                // Temporarily remove handler to prevent firing during load
                cmb_Venue.SelectedIndexChanged -= cmb_Venue_SelectedIndexChanged;
                cmb_Venue.DataSource = null;
                cmb_Venue.DisplayMember = "Value";
                cmb_Venue.ValueMember = "Key";
                cmb_Venue.DataSource = venueList;
                cmb_Venue.SelectedIndex = -1;
                // Re-attach handler
                cmb_Venue.SelectedIndexChanged += cmb_Venue_SelectedIndexChanged;
            }
            catch (Exception ex) { /* ... handle error ... */ }
        }

        // Modified to accept venueId for filtering
        private void LoadVenueScopeDropdown(int? venueId)
        {
            try
            {
                List<KeyValuePair<int, string>> scopeList;

                if (venueId.HasValue)
                {
                    var rawList = _repo.GetScopesForVenue(venueId.Value);

                    // Map internal scope names to friendly names
                    scopeList = rawList.Select(kvp => new KeyValuePair<int, string>(
                        kvp.Key,
                        GetFriendlyScopeName(kvp.Value)
                    )).ToList();
                }
                else
                {
                    scopeList = new List<KeyValuePair<int, string>>();
                }
                cmb_Venue_Scope.SelectedIndexChanged -= cmb_Venue_Scope_SelectedIndexChanged;
                cmb_Venue_Scope.DataSource = null;
                cmb_Venue_Scope.DisplayMember = "Value";
                cmb_Venue_Scope.ValueMember = "Key";
                cmb_Venue_Scope.DataSource = scopeList;
                cmb_Venue_Scope.SelectedIndex = -1;
                cmb_Venue_Scope.SelectedIndexChanged += cmb_Venue_Scope_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
            }
        }

        private string GetFriendlyScopeName(string internalScopeName)
        {
            switch (internalScopeName)
            {
                case "AH_Whole_Building":
                case "CS_Whole_Building":
                    return "Entire Venue";
                case "CS_Lobby":
                    return "Lobby Only";
                case "CS_Main_Hall":
                    return "Main Hall Only";
                case "CS_Main_Hall_And_Mezzanine":
                    return "Main Hall and Mezzanine";
                case "PS_Room_A":
                    return "Room A Only";
                case "PS_Room_ABC":
                    return "Room A, B and C";
                case "PS_Room_BC":
                    return "Room B and C";
                default:
                    return internalScopeName;
            }
        }

        private void LoadReservationDetails()
        {
            try
            {
                Model_Billing details = _repo.GetReservationDetails(_reservationID);

                if (details == null)
                {
                    MessageBox.Show("Reservation not found.");
                    return;
                }

                _originalBillingInfo = details; // Store the fetched details

                if (details.fld_Reservation_Status == "Confirmed")
                {
                    cmb_Venue.Enabled = false;
                    cmb_Venue_Scope.Enabled = false;
                    cb_Aircon.Enabled = false;
                }

                // Populate date/time pickers
                dtp_Start_Date.Value = details.fld_Start_Date.Date;
                dtp_End_Date.Value = details.fld_End_Date.Date;
                DateTime baseDate = DateTime.Today;
                dtp_Start_Time.Value = baseDate + details.fld_Start_Time;
                dtp_End_Time.Value = baseDate + details.fld_End_Time;

                _initialStartTime = dtp_Start_Time.Value.TimeOfDay;
                _initialEndTime = dtp_End_Time.Value.TimeOfDay;

                _initialStartDate = dtp_Start_Date.Value.TimeOfDay; // Store initial date duration for validation
                _initialEndDate = dtp_End_Date.Value.TimeOfDay; // Store initial date duration for validation

                _initialDuration = _initialEndTime - _initialStartTime;
                _initialDateDuration = _initialEndDate - _initialStartDate; // Store initial date duration for validation
                // Set venue
                if (cmb_Venue.DataSource != null && details.fk_VenueID.HasValue)
                {
                    cmb_Venue.SelectedIndexChanged -= cmb_Venue_SelectedIndexChanged;
                    cmb_Venue.SelectedValue = details.fk_VenueID.Value;
                    cmb_Venue.SelectedIndexChanged += cmb_Venue_SelectedIndexChanged;
                }

                // Load and set scope
                if (details.fk_VenueID.HasValue)
                {
                    LoadVenueScopeDropdown(details.fk_VenueID.Value);
                }

                if (cmb_Venue_Scope.DataSource != null && details.fk_Venue_ScopeID.HasValue)
                {
                    cmb_Venue_Scope.SelectedIndexChanged -= cmb_Venue_Scope_SelectedIndexChanged;
                    cmb_Venue_Scope.SelectedValue = details.fk_Venue_ScopeID.Value;
                    cmb_Venue_Scope.SelectedIndexChanged += cmb_Venue_Scope_SelectedIndexChanged;
                }

                // ✅ Let this handle visibility and Checked state from DB
                UpdateAirconCheckboxVisibility(details.pk_ReservationID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation: {ex.Message}");
            }
        }


        // --- EVENT HANDLER for Venue Change ---
        private void cmb_Venue_SelectedIndexChanged(object sender, EventArgs e)
        {

            int? selectedVenueId = null;
            if (cmb_Venue.SelectedValue is int venueId) // Safer check
            {
                selectedVenueId = venueId;
            }
           
                // Reload scopes based on the selected venue
                LoadVenueScopeDropdown(selectedVenueId);

            // Update Aircon visibility (might hide if no scopes or no AC options)
            UpdateAirconCheckboxVisibility(_originalBillingInfo.pk_ReservationID);
        }

        // --- EVENT HANDLER for Scope Change ---
        private void cmb_Venue_Scope_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update Aircon checkbox visibility based on the specific scope selected
            UpdateAirconCheckboxVisibility(_originalBillingInfo.pk_ReservationID);
        }

        // --- Helper Method to Show/Hide Aircon Checkbox ---
        private void UpdateAirconCheckboxVisibility(int reservationId)
        {
            int? venueId = cmb_Venue.SelectedValue as int?;
            int? scopeId = cmb_Venue_Scope.SelectedValue as int?;

            if (!venueId.HasValue || !scopeId.HasValue)
            {
                cb_Aircon.Visible = false;
                return;
            }

            bool showAircon = false;

            try
            {
                showAircon = _repo.CheckAirconAvailability(venueId.Value, scopeId.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking Aircon availability: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cb_Aircon.Visible = showAircon;

            if (showAircon)
            {
                cb_Aircon.Checked = _repo.GetAirconUsageForReservation(reservationId);
            }
        }






        // --- Calculation Helper ---
        private decimal CalculateTotalAmount(TimeSpan duration, decimal first4HrsRate, decimal hourlyRate)
        {
            decimal totalAmount = 0;
            double totalHours = duration.TotalHours;

            const double fourHours = 4.0;

            if (totalHours <= fourHours)
            {
                totalAmount = first4HrsRate;
            }
            else
            {
                double excessHours = Math.Ceiling(totalHours - fourHours);
                totalAmount = first4HrsRate + ((decimal)excessHours * hourlyRate);
            }

            return totalAmount;
        }


        // --- SAVE BUTTON CLICK HANDLER ---
        private void btn_Save_Click(object sender, EventArgs e)
        {
            
            if (cmb_Venue.SelectedValue == null || cmb_Venue_Scope.SelectedValue == null)
            {
                MessageBox.Show("Please select a venue and scope.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmb_Venue_Scope.Items.Count == 0 && cmb_Venue.SelectedValue != null)
            {
                MessageBox.Show("Please select a valid scope for the chosen venue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Venue_Scope.Focus();
                return;
            }

            if (dtp_Start_Date.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Start date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_Start_Date.Focus();
                return;
            }
            
            // --- 2. Get Values from Controls ---
            DateTime startDate = dtp_Start_Date.Value.Date;
            DateTime endDate = dtp_End_Date.Value.Date;
            TimeSpan startTime = dtp_Start_Time.Value.TimeOfDay;
            TimeSpan endTime = dtp_End_Time.Value.TimeOfDay;
            TimeSpan newDuration = endTime - startTime;
            TimeSpan newDateDuration = endDate - startDate;
            int venueId = (int)cmb_Venue.SelectedValue;
            int venueScopeId = (int)cmb_Venue_Scope.SelectedValue;
            // Aircon status depends on checkbox visibility and state
            bool aircon = cb_Aircon.Visible && cb_Aircon.Checked;

            DateTime selectedDate = dtp_Start_Date.Value.Date;
            int selectedVenueId = (int)cmb_Venue.SelectedValue;

            if (_originalBillingInfo.fld_Reservation_Status == "Confirmed")
            {
                if (newDuration != _initialDuration)
                {
                    MessageBox.Show("Cannot change the total number of hours.",
                                    "Time Change Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtp_Start_Date.Focus();
                    return;
                }

                if(newDateDuration != _initialDateDuration)
                {
                    MessageBox.Show("Error Changing Reservation Dates.",
                                    "Date Change Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtp_Start_Date.Focus();
                    return;
                }
            }
                try
            {
                bool isVenueReserved = _repo.IsVenueReservedOnDate(selectedVenueId, selectedDate, _reservationID); // Pass current ID to exclude it

                if (isVenueReserved)
                {
                    MessageBox.Show($"Venue '{cmb_Venue.Text}' is already reserved on {selectedDate.ToShortDateString()}.",
                                    "Reservation Conflict",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking for reservation conflicts:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Fetch the rate type that *should* apply to this reservation.
                string rateType = _repo.GetIntendedRateTypeForReservation(_reservationID); // Use repo method
                if (string.IsNullOrEmpty(rateType))
                {
                    MessageBox.Show("Could not determine the applicable rate type for this reservation. Update cancelled.", "Rate Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                decimal totalAmount = 0m;
                Repo_Billing.VenuePricingResult pricing = null;
                int finalPricingId = -1; // Need to store the ID

                // --- Handle PGNV Rate Type ---
                if (rateType == RATE_TYPE_PGNV)
                {
                    totalAmount = 0m;
                    pricing = _repo.GetVenuePricingDetails(venueId, venueScopeId, false, rateType); // Look for PGNV non-AC record
                    if (!pricing.Found)
                    {
                        finalPricingId = -1; 
                                            
                        pricing = new Repo_Billing.VenuePricingResult { Found = true, First4HrsRate = 0, HourlyRate = 0, PricingID = -1 }; // Mock pricing result
                    }
                    else
                    {
                        finalPricingId = pricing.PricingID;
                    }

                    // Force rates to 0 for PGNV regardless of fetched values
                    pricing.First4HrsRate = 0m;
                    pricing.HourlyRate = 0m;

                }
                else // --- Handle Regular / Special Rate Types ---
                {
                    // Fetch pricing based on user selections (including aircon checkbox)
                    pricing = _repo.GetVenuePricingDetails(venueId, venueScopeId, aircon, rateType);

                    if (!pricing.Found)
                    {
                        MessageBox.Show($"No pricing information found for the selected combination:\nVenue: {cmb_Venue.Text}\nScope: {cmb_Venue_Scope.Text}\nAircon: {(aircon ? "Yes" : "No")}\nRate Type: {rateType}\n\nPlease check the pricing configuration.",
                                        "Pricing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Stop execution
                    }
                    finalPricingId = pricing.PricingID;

                    // --- 4. Calculate Total Duration and Amount ---
                    DateTime startDateTime = startDate + startTime;
                    DateTime endDateTime = endDate + endTime;
                    TimeSpan totalDuration = endDateTime - startDateTime;

                    if (totalDuration <= TimeSpan.Zero)
                    {
                        MessageBox.Show("Calculated duration is zero or negative. Please check dates and times.", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Call calculation helper
                    totalAmount = CalculateTotalAmount(totalDuration, pricing.First4HrsRate, pricing.HourlyRate);
                }

                // --- 5. Update the Reservation Record via Repository ---
                bool success = _repo.UpdateVenueReservation(
                    _reservationID,
                    startDate,
                    endDate,
                    startTime,
                    endTime,
                    venueId,
                    venueScopeId,
                    finalPricingId, // Use the determined ID
                    pricing.First4HrsRate, // Use potentially zeroed rate for PGNV
                    pricing.HourlyRate,    // Use potentially zeroed rate for PGNV
                    totalAmount            // Pass calculated amount
                );

                // --- 6. Provide Feedback --- (Keep existing feedback)
                if (success)
                {
                    MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReservationUpdated?.Invoke(this, EventArgs.Empty);
                    this.DialogResult = DialogResult.OK; // 🟢 Important!
                    this.Close(); // optionally close the form or reset fields
                }
                else
                {
                    MessageBox.Show("Failed to update the reservation. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { /* ... handle error ... */ }
        }

        // --- CANCEL BUTTON CLICK HANDLER ---
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            // Ask user if they are sure? (Optional but recommended for edits)
            if (MessageBox.Show("Are you sure you want to cancel editing? Any changes will be lost.",
                               "Confirm Cancel",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel; // Set result if needed
                this.Close();
            }
        }


        // --- Other Recommendations / Optional Code ---

        // Recommendation: Disable form controls during long operations (like DB calls)
        private void SetBusy(bool busy)
        {
            // Example: Disable save/cancel buttons, show a progress indicator
            btn_Save.Enabled = !busy;
            btn_Cancel.Enabled = !busy; // Assuming btn_Cancel exists
            this.Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
            // Consider disabling other controls too
        }

        // Call SetBusy(true) at start of DB operations (e.g., in LoadReservationDetails, btn_Save_Click)
        // Call SetBusy(false) in finally blocks or after operation completes


        // Recommendation: More Specific Error Handling
        // Instead of generic catch (Exception ex), catch specific exceptions like SqlException
        // Log the full exception details (ex.ToString()) for better debugging


        // Recommendation: Consider using async/await for DB operations
        // To keep the UI responsive during database calls, especially loading.
        // Example (conceptual):
        // private async void LoadReservationDetailsAsync() {
        //     SetBusy(true);
        //     try {
        //         Model_Billing details = await Task.Run(() => _repo.GetReservationDetails(_reservationID));
        //         // ... update controls on UI thread ...
        //     } catch (Exception ex) { /* handle */ }
        //     finally { SetBusy(false); }
        // }

    } // End Class frm_Edit_Venue_Reservation_Info
} // End Namespace