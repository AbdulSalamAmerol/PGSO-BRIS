using System;

namespace pgso.Billing.Models
{
    public class BillingRecord
    {
        public string fld_Control_Number { get; set; }
        public string fld_Payment_Status { get; set; }
        public decimal fld_Amount_Due { get; set; }
        public decimal fld_Amount_Paid { get; set; }
        public string fld_Username { get; set; }
        public DateTime fld_Created_At { get; set; }
        public string fld_Reservation_Type { get; set; }
        public string fld_First_Name { get; set; }
        public string fld_Middle_Name { get; set; }
        public string fld_Surname { get; set; }
        public string fld_Activity_Name { get; set; }
        public DateTime fld_Start_Date { get; set; }
        public DateTime fld_End_Date { get; set; }
        public TimeSpan fld_Start_Time { get; set; }
        public TimeSpan fld_End_Time { get; set; }
    }
}
