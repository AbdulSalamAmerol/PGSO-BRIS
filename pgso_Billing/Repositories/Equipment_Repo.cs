using pgso.Billing.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace pgso.pgso_Billing.Repositories
{
    internal class Equipment_Repo
    {
        private string connectionString = "Data Source=KIMABZ\\SQL;Initial Catalog=BRIS_EXPERIMENT_3.0;Persist Security Info=True;User ID=sa;Password=abz123;Encrypt=False;";

        public List<class_Equipment_Billing> GetAllEquipmentBillingRecords()
        {
            List<class_Equipment_Billing> equipmentBillings = new List<class_Equipment_Billing>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        r.fld_Control_Number,
                        CONCAT(rp.fld_First_Name, ' ', rp.fld_Middle_Name, ' ', rp.fld_Surname) AS fld_Full_Name,
                        e.fld_Equipment_Name,
                        re.fld_Quantity,
                        ep.fld_Equipment_Price,  -- Correct reference from tbl_Equipment_Pricing
                        ep.fld_Equipment_Price_Subsequent,  -- Correct reference from tbl_Equipment_Pricing
                        re.fld_Number_Of_Days,
                        -- Calculating the total equipment cost based on pricing and quantity
                        (ep.fld_Equipment_Price * re.fld_Quantity) + 
                        (ep.fld_Equipment_Price_Subsequent * re.fld_Quantity * (re.fld_Number_Of_Days - 1)) AS fld_Total_Equipment_Cost
                    FROM tbl_Reservation_Equipment re
                    JOIN tbl_Reservation r ON re.fk_ReservationID = r.pk_ReservationID
                    JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    JOIN tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                    JOIN tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
                    ORDER BY r.fld_Control_Number DESC";  // Show latest first

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        class_Equipment_Billing equipmentBilling = new class_Equipment_Billing
                        {
                            fld_Control_Number = reader["fld_Control_Number"].ToString(),
                            fld_Full_Name = reader["fld_Full_Name"].ToString(),
                            fld_Equipment_Name = reader["fld_Equipment_Name"].ToString(),
                            fld_Quantity = Convert.ToInt32(reader["fld_Quantity"]),
                            fld_Equipment_Price = Convert.ToDecimal(reader["fld_Equipment_Price"]),
                            fld_Equipment_Price_Subsequent = Convert.ToDecimal(reader["fld_Equipment_Price_Subsequent"]),
                            fld_Number_Of_Days = Convert.ToInt32(reader["fld_Number_Of_Days"]),
                            fld_Total_Equipment_Cost = Convert.ToDecimal(reader["fld_Total_Equipment_Cost"])
                        };

                        equipmentBillings.Add(equipmentBilling);
                    }
                }
            }

            return equipmentBillings;
        }
    }
}
