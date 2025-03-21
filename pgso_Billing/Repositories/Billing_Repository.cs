using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using pgso.Billing.Models;

namespace pgso.Billing.Repositories
{
    internal class BillingRepository
    {
        private string connectionString = "Data Source=KIMABZ\\SQL;Initial Catalog=BRIS_EXPERIMENT_3.0;Persist Security Info=True;User ID=sa;Password=abz123;Encrypt=False;";

        public List<BillingRecord> GetAllBillingRecords()
        {
            List<BillingRecord> billings = new List<BillingRecord>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        r.fld_Control_Number,
                        p.fld_Payment_Status,
                        p.fld_Amount_Due,
                        p.fld_Amount_Paid,
                        u.fld_Username,
                        p.fld_Created_At,
                        r.fld_Reservation_Type,
                        rp.fld_First_Name,
                        rp.fld_Middle_Name,
                        rp.fld_Surname,
                        r.fld_Activity_Name,
                        r.fld_Start_Date,
                        r.fld_End_Date,
                        r.fld_Start_Time,
                        r.fld_End_Time
                    FROM tbl_Payment p
                    JOIN tbl_Reservation r ON p.fk_ReservationID = r.pk_ReservationID
                    JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    JOIN tbl_User u ON p.fk_UserID = u.pk_UserID
                    ORDER BY r.fld_Control_Number DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BillingRecord billing = new BillingRecord
                            {
                                fld_Control_Number = reader.GetString(0),
                                fld_Payment_Status = reader.GetString(1),
                                fld_Amount_Due = reader.GetDecimal(2),
                                fld_Amount_Paid = reader.GetDecimal(3),
                                fld_Username = reader.GetString(4),
                                fld_Created_At = reader.GetDateTime(5),
                                fld_Reservation_Type = reader.GetString(6),
                                fld_First_Name = reader.GetString(7),
                                fld_Middle_Name = reader.IsDBNull(8) ? null : reader.GetString(8),
                                fld_Surname = reader.GetString(9),
                                fld_Activity_Name = reader.GetString(10),
                                fld_Start_Date = reader.GetDateTime(11),
                                fld_End_Date = reader.GetDateTime(12),
                                fld_Start_Time = reader.GetTimeSpan(13),
                                fld_End_Time = reader.GetTimeSpan(14)
                            };

                            billings.Add(billing);
                        }
                    }
                }
            }

            return billings;
        }
    }
}
