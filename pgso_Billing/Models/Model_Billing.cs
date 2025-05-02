using System;
using System.Collections.Generic;
using System.Globalization;

namespace pgso.Billing.Models
{
    public class Model_Billing
    {
        // Full Name 
        public string fld_Full_Name => $"{fld_First_Name} {(string.IsNullOrEmpty(fld_Middle_Name) ? "" : fld_Middle_Name + " ")}{fld_Surname}".Trim();

        // Requesting Person Details
        public int pk_Requesting_PersonID { get; set; }
        public string fld_Surname { get; set; }
        public string fld_First_Name { get; set; }
        public string fld_Middle_Name { get; set; }
        public string fld_Requesting_Person_Address { get; set; }
        public string fld_Contact_Number { get; set; }
        public string fld_Request_Origin { get; set; }
        public string fld_Requesting_Office { get; set; }

        // Reservation Details
        public int pk_ReservationID { get; set; }
        public string fld_Control_Number { get; set; }
        public string fld_Reservation_Type { get; set; }
        public DateTime fld_Start_Date { get; set; }
        public DateTime fld_End_Date { get; set; }
        public TimeSpan fld_Start_Time { get; set; }
        public TimeSpan fld_End_Time { get; set; }
        public string fld_Activity_Name { get; set; }
        public int fld_Number_Of_Participants { get; set; }
        public string fld_Reservation_Status { get; set; }
        public decimal fld_Total_Amount { get; set; }
        public int fld_OT_Hours { get; set; }
        public int fld_OR { get; set; }
        public string fld_OT_Payment_Status { get;set; }
        public string fld_Cancellation_Reason { get; set; }

        // Venue Details
        public int? pk_VenueID { get; set; }
        public string fld_Venue_Name { get; set; }
        public int? pk_Venue_ScopeID { get; set; }
        public string fld_Venue_Scope_Name { get; set; }
        public int? fk_VenueID { get; set; } // Foreign key for VenueID in the Venue Pricing table
        public int? fk_Venue_ScopeID { get; set; } // Foreign key for Venue Scope ID in the Venue Pricing table
        public int? fk_Venue_PricingID { get; set; } // Foreign key for Venue Pricing ID in the Venue Pricing table

        // Venue Pricing
        public int? pk_Venue_PricingID { get; set; }
        public decimal fld_First4Hrs_Rate { get; set; }
        public decimal fld_Hourly_Rate { get; set; }
        public bool fld_Aircon { get; set; }
        public string fld_Rate_Type { get; set; }
        public decimal fld_Additional_Charge { get; set; }
        public int fld_OR_Extension { get; set; }

        // Reserved Equipment Details
        public int? pk_Reservation_EquipmentID { get; set; }
        public int? fk_EquipmentID { get; set; }
        public string fld_Equipment_Name { get; set; }
        public int? fk_Equipment_PricingID { get; set; }
        public decimal fld_Equipment_Price { get; set; }
        public decimal fld_Equipment_Price_Subsequent { get; set; }
        public int fld_Quantity { get; set; }
        public int fld_Number_Of_Days { get; set; }
        public decimal fld_Total_Equipment_Cost { get; set; }
        public int fld_OT_Days { get; set; }
        public int pk_Equipment_PricingID { get; set; }
        public DateTime fld_Start_Date_Eq { get; set; }
        public DateTime fld_End_Date_Eq { get; set; }
        public int fld_Total_Stock { get; set; }
        public int fld_Remaining_Stock { get; set; }
        public string fld_Equipment_Status { get; set; }
        public DateTime fld_Date_Returned { get; set; }
        public int fld_Quantity_Returned { get; set; }
        public int fld_Quantity_Damaged { get; set; }


        // Payment Details
        public int? pk_PaymentID { get; set; }
        public DateTime fld_Created_At { get; set; }
        public decimal fld_Amount_Due { get; set; }
        public decimal fld_Amount_Paid { get; set; }
        public string fld_Payment_Status { get; set; }
        public DateTime? fld_Payment_Date { get; set; }
      
        public decimal fld_Refund_Amount { get; set; }
        public decimal fld_Cancellation_Fee { get; set; }
        public decimal fld_Final_Amount_Paid { get; set; }
        public  decimal fld_Overtime_Fee { get; set; }
        public decimal fld_Amount_Paid_OT { get; set; }
        public decimal fld_Amount_Paid_Overtime { get; set; }

        // 🔸 Computed Properties
        public double Total_Hours => Math.Max(0, (fld_End_Time - fld_Start_Time).TotalHours);

        // 🔸 Formatting Properties
        public string Formatted_Amount_Due => fld_Amount_Due.ToString("C", new CultureInfo("en-PH"));
        public string Formatted_Amount_Paid => fld_Amount_Paid.ToString("C", new CultureInfo("en-PH"));
        public string Formatted_Created_At => fld_Created_At.ToString("MMMM dd, yyyy hh:mm tt");
        public string Formatted_Start_Date => fld_Start_Date.ToString("MMMM dd, yyyy");
        public string Formatted_End_Date => fld_End_Date.ToString("MMMM dd, yyyy");
        public string Formatted_Start_Time => DateTime.Today.Add(fld_Start_Time).ToString("hh:mm tt");
        public string Formatted_End_Time => DateTime.Today.Add(fld_End_Time).ToString("hh:mm tt");
        public string Formatted_No_Hours => Total_Hours.ToString("0.##") + " hrs";
        public string Formatted_Start_Date_Eq => fld_Start_Date_Eq.ToString("MMMM dd, yyyy");
        public string Formatted_End_Date_Eq => fld_End_Date_Eq.ToString("MMMM dd, yyyy");

        // Add a new property to store merged equipment names ( show sa datagridview as 1 liner when many eq reservation)
        public List<string> EquipmentNames { get; set; } = new List<string>();

        // Datagridview display name for reservation with multiple equipment 
        // This property will return the name of the venue if fld_Reservation_Type is "Venue"
        // Otherwise, it will return the names of the equipment in a comma-separated format
        // (WHAT IF DALAWA VENUE) NEED FIXING!
        public string DisplayReservationName 
        {
            get
            {
                // Ensure it checks for venue and returns fld_Venue_Name, otherwise return equipment names
                return fld_Reservation_Type == "Venue"
                    ? fld_Venue_Name
                    : string.Join(", ", EquipmentNames); // Merge equipment names if it's equipment type
            }
        }
    }
}
