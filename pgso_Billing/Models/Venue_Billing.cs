using System;
using System.Globalization;

namespace pgso.Billing.Models
{
    public class class_Venue_Billing
    {
        public string fld_Control_Number { get; set; }
        public string fld_Payment_Status { get; set; }
        public decimal fld_Amount_Due { get; set; }
        public decimal fld_Amount_Paid { get; set; }
        public string fld_Username { get; set; }
        public DateTime fld_Created_At { get; set; }
        public string fld_Reservation_Type { get; set; }
        public string fld_Activity_Name { get; set; }
        public DateTime fld_Start_Date { get; set; }
        public DateTime fld_End_Date { get; set; }
        public TimeSpan fld_Start_Time { get; set; }
        public TimeSpan fld_End_Time { get; set; }
        public string fld_Full_Name { get; set; }
        public string fld_Venue_Name { get; set; }  // NEW
        public string fld_Venue_Scope_Name { get; set; }  // NEW

        // Calculate total hours between start and end time
        public double Total_Hours => (fld_End_Time - fld_Start_Time).TotalHours;

        // 🔸 Currency Formatting
        public string Formatted_Amount_Due => fld_Amount_Due.ToString("C", new CultureInfo("en-PH"));
        public string Formatted_Amount_Paid => fld_Amount_Paid.ToString("C", new CultureInfo("en-PH"));

        // 🔸 Date Formatting
        public string Formatted_Created_At => fld_Created_At.ToString("MMMM dd, yyyy hh:mm tt");
        public string Formatted_Start_Date => fld_Start_Date.ToString("MMMM dd, yyyy");
        public string Formatted_End_Date => fld_End_Date.ToString("MMMM dd, yyyy");

        // 🔸 Time Formatting
        public string Formatted_Start_Time => DateTime.Today.Add(fld_Start_Time).ToString("hh:mm tt");
        public string FormattedEndTime => DateTime.Today.Add(fld_End_Time).ToString("hh:mm tt");

        // 🔸 Hours Formatting
        public string Formatted_No_Hours => Total_Hours.ToString("0.##") + " hrs";
    }
}
