using System;
using System.Globalization;

namespace pgso.Billing.Models
{
    public class Billing_Model
    {
        // 🔸 Computed Full Name (Not in Database)
        public string fld_Full_Name => $"{fld_First_Name} {(string.IsNullOrEmpty(fld_Middle_Name) ? "" : fld_Middle_Name + " ")}{fld_Surname}".Trim();

        // Requesting Person Details
        public int pk_Requesting_PersonID { get; set; }
        public string fld_Surname { get; set; }
        public string fld_First_Name { get; set; }
        public string fld_Middle_Name { get; set; }
        public string fld_Requesting_Person_Address { get; set; }
        public string fld_Contact_Number { get; set; }
        public string fld_Request_Origin { get; set; }

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
        

        // Venue Details
        public int? pk_VenueID { get; set; }
        public string fld_Venue_Name { get; set; }
        public int? pk_Venue_ScopeID { get; set; }
        public string fld_Venue_Scope_Name { get; set; }
        

        // Venue Pricing
        public int? pk_Venue_PricingID { get; set; }
        public decimal fld_First4Hrs_Rate { get; set; }
        public decimal fld_Hourly_Rate { get; set; }

        // Reserved Equipment Details
        public int? fk_EquipmentID { get; set; }
        public string fld_Equipment_Name { get; set; }
        public int? fk_Equipment_PricingID { get; set; }
        public decimal fld_Equipment_Price { get; set; }
        public decimal fld_Equipment_Price_Subsequent { get; set; }
        public int fld_Quantity { get; set; }
        public int fld_Number_Of_Days { get; set; }
        public decimal fld_Total_Equipment_Cost { get; set; }

        // Payment Details
        public int? pk_PaymentID { get; set; }
        public DateTime fld_Created_At { get; set; }
        public decimal fld_Amount_Due { get; set; }
        public decimal fld_Amount_Paid { get; set; }
        public string fld_Payment_Status { get; set; }
        public DateTime? fld_Payment_Date { get; set; }

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

        public string Formatted_Payment_Status => fld_Payment_Status switch
        {
            "Confirmed" => "✅ Confirmed",
            "Pending" => "❌ Pending",
            "Cancelled" => "🟡 Cancelled",
            _ => fld_Payment_Status
        };
    }
}
