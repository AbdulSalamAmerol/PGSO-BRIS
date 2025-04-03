using System;
using System.Globalization;

namespace pgso.Billing.Models
{
    public class class_Equipment_Billing
    {
        public string fld_Full_Name { get; set; }

        // From tbl_Equipment
        public string fld_Equipment_Name { get; set; }

        // From tbl_Equipment_Pricing
        public decimal fld_Equipment_Price { get; set; }
        public decimal fld_Equipment_Price_Subsequent { get; set; }

        // From tbl_Reservation_Equipment
        public string fld_Control_Number { get; set; }
        public int fld_Quantity { get; set; }
        public int fld_Number_Of_Days { get; set; }
        public decimal fld_Total_Equipment_Cost { get; set; }

        // Optional: Formatted Display Properties
        public string Formatted_Equipment_Price => fld_Equipment_Price.ToString("C", new CultureInfo("en-PH"));
        public string Formatted_Equipment_Price_Subsequent => fld_Equipment_Price_Subsequent.ToString("C", new CultureInfo("en-PH"));
        public string Formatted_Total_Equipment_Cost => fld_Total_Equipment_Cost.ToString("C", new CultureInfo("en-PH"));

        // Calculate the total cost of equipment based on quantity and number of days
        public decimal CalculateTotalCost()
        {
            // Using the correct formula:
            // ((fld_Equipment_Price * fld_Quantity) + (fld_Equipment_Price_Subsequent * fld_Quantity * (fld_Number_Of_Days - 1)))
            return (fld_Equipment_Price * fld_Quantity) +
                   (fld_Equipment_Price_Subsequent * fld_Quantity * (fld_Number_Of_Days - 1));
        }
    }
}
