using pgso.Billing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso.Billing.Repositories
{
    internal class Repo_Billing
    {
        private string connectionString = "Data Source=KIMABZ\\SQL;Initial Catalog=BRIS_EXPERIMENT_3.0;Persist Security Info=True;User ID=sa;Password=abz123;Encrypt=False;";


        public List<Billing_Model> GetAllBillingRecords()
        {
            List<Billing_Model> billings = new List<Billing_Model>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("✅ Connected to Database");

                    string query = @"
                                SELECT 
                                   
                                    rp.pk_Requesting_PersonID,
                                    rp.fld_Surname,
                                    rp.fld_First_Name,
                                    rp.fld_Middle_Name,
                                    rp.fld_Requesting_Person_Address,
                                    rp.fld_Contact_Number,

                                    
                                    r.pk_ReservationID,
                                    r.fld_Control_Number,
                                    r.fld_Reservation_Type,
                                    r.fld_Start_Date,
                                    r.fld_End_Date,
                                    r.fld_Start_Time,
                                    r.fld_End_Time,
                                    r.fld_Activity_Name,
                                    r.fld_Number_Of_Participants,
                                    r.fld_Reservation_Status,
                                    r.fld_Total_Amount,

                                    
                                    v.pk_VenueID,
                                    v.fld_Venue_Name,
                                    vs.pk_Venue_ScopeID,
                                    vs.fld_Venue_Scope_Name,

                                    
                                    vp.pk_Venue_PricingID,
                                    vp.fld_First4Hrs_Rate,
                                    vp.fld_Hourly_Rate,

                                   
                                    re.fk_EquipmentID,
                                    e.fld_Equipment_Name,
                                    re.fk_Equipment_PricingID,
                                    ep.fld_Equipment_Price,
                                    ep.fld_Equipment_Price_Subsequent,
                                    re.fld_Quantity,
                                    re.fld_Number_Of_Days,
                                    re.fld_Total_Equipment_Cost,

                                   
                                    p.pk_PaymentID,
                                    p.fld_Created_At,
                                    p.fld_Amount_Due,
                                    p.fld_Amount_Paid,
                                    p.fld_Payment_Status,
                                    p.fld_Payment_Date,
                                    r.fld_OT_Hours

                                FROM dbo.tbl_Reservation r
                                LEFT JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                                LEFT JOIN dbo.tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
                                LEFT JOIN dbo.tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
                                LEFT JOIN dbo.tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
                                LEFT JOIN dbo.tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
                                LEFT JOIN dbo.tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                                LEFT JOIN dbo.tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
                                LEFT JOIN dbo.tbl_Payment p ON r.pk_ReservationID = p.fk_ReservationID
                                ORDER BY  r.pk_ReservationID DESC";


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int reservationId = reader.GetInt32(0);
                            string controlNumber = reader.GetString(1);

                            Console.WriteLine($"📝 Fetched Reservation: {reservationId}, {controlNumber}");

                            Billing_Model billing = new Billing_Model
                            {
                                // Requesting Person Details
                                pk_Requesting_PersonID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                fld_Surname = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                fld_First_Name = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                fld_Middle_Name = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                fld_Requesting_Person_Address = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                fld_Contact_Number = reader.IsDBNull(5) ? "" : reader.GetString(5),

                                // Reservation Details
                                pk_ReservationID = reader.GetInt32(6),
                                fld_Control_Number = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                fld_Reservation_Type = reader.IsDBNull(8) ? "" : reader.GetString(8),
                                fld_Start_Date = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9),
                                fld_End_Date = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10),
                                fld_Start_Time = reader.IsDBNull(11) ? TimeSpan.Zero : reader.GetTimeSpan(11),
                                fld_End_Time = reader.IsDBNull(12) ? TimeSpan.Zero : reader.GetTimeSpan(12),
                                fld_Activity_Name = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                fld_Number_Of_Participants = reader.IsDBNull(14) ? 0 : reader.GetInt32(14),
                                fld_Reservation_Status = reader.IsDBNull(15) ? "" : reader.GetString(15),
                                fld_Total_Amount = reader.IsDBNull(16) ? 0 : reader.GetDecimal(16),

                                // Venue Details
                                pk_VenueID = reader.IsDBNull(17) ? 0 : reader.GetInt32(17),
                                fld_Venue_Name = reader.IsDBNull(18) ? "N/A" : reader.GetString(18),
                                pk_Venue_ScopeID = reader.IsDBNull(19) ? 0 : reader.GetInt32(19),
                                fld_Venue_Scope_Name = reader.IsDBNull(20) ? "" : reader.GetString(20),

                                // Venue Pricing
                                pk_Venue_PricingID = reader.IsDBNull(21) ? 0 : reader.GetInt32(21),
                                fld_First4Hrs_Rate = reader.IsDBNull(22) ? 0 : reader.GetDecimal(22),
                                fld_Hourly_Rate = reader.IsDBNull(23) ? 0 : reader.GetDecimal(23),

                                // Reserved Equipment Details
                                fk_EquipmentID = reader.IsDBNull(24) ? 0 : reader.GetInt32(24),
                                fld_Equipment_Name = reader.IsDBNull(25) ? "N/A" : reader.GetString(25),
                                fk_Equipment_PricingID = reader.IsDBNull(26) ? 0 : reader.GetInt32(26),
                                fld_Equipment_Price = reader.IsDBNull(27) ? 0 : reader.GetDecimal(27),
                                fld_Equipment_Price_Subsequent = reader.IsDBNull(28) ? 0 : reader.GetDecimal(28),
                                fld_Quantity = reader.IsDBNull(29) ? 0 : reader.GetInt32(29),
                                fld_Number_Of_Days = reader.IsDBNull(30) ? 0 : reader.GetInt32(30),
                                fld_Total_Equipment_Cost = reader.IsDBNull(31) ? 0 : reader.GetDecimal(31),

                                // Payment Details
                                pk_PaymentID = reader.IsDBNull(32) ? 0 : reader.GetInt32(32),
                                fld_Created_At = reader.IsDBNull(33) ? DateTime.MinValue : reader.GetDateTime(33),
                                fld_Amount_Due = reader.IsDBNull(34) ? 0 : reader.GetDecimal(34),
                                fld_Amount_Paid = reader.IsDBNull(35) ? 0 : reader.GetDecimal(35),
                                fld_Payment_Status = reader.IsDBNull(36) ? "" : reader.GetString(36),
                                fld_Payment_Date = reader.IsDBNull(37) ? DateTime.MinValue : reader.GetDateTime(37),
                                fld_OT_Hours = reader.IsDBNull(38) ? 0 : reader.GetInt32(38)   
                            };


                            billings.Add(billing);
                        }
                    }
                }

                Console.WriteLine("✅ Total Records Retrieved: " + billings.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Database error: " + ex.Message);
            }

            return billings;
        }

        // Get Billing Records by Reservation ID (RDLC of frm_Print_Billing)
        public List<Billing_Model> GetBillingRecordsByReservationId(int reservationId)
        {
            List<Billing_Model> billingRecords = new List<Billing_Model>();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine($"✅ Fetching billing data for Reservation ID: {reservationId}");

                    string query = @"
                    SELECT 
                        rp.pk_Requesting_PersonID,
                        rp.fld_Surname,
                        rp.fld_First_Name,
                        rp.fld_Middle_Name,
                        rp.fld_Requesting_Person_Address,
                        rp.fld_Contact_Number,

                        r.pk_ReservationID,
                        r.fld_Control_Number,
                        r.fld_Reservation_Type,
                        r.fld_Start_Date,
                        r.fld_End_Date,
                        r.fld_Start_Time,
                        r.fld_End_Time,
                        r.fld_Activity_Name,
                        r.fld_Number_Of_Participants,
                        r.fld_Reservation_Status,
                        r.fld_Total_Amount,

                        v.pk_VenueID,
                        v.fld_Venue_Name,
                        vs.pk_Venue_ScopeID,
                        vs.fld_Venue_Scope_Name,

                        vp.pk_Venue_PricingID,
                        vp.fld_First4Hrs_Rate,
                        vp.fld_Hourly_Rate,

                        re.fk_EquipmentID,
                        e.fld_Equipment_Name,
                        re.fk_Equipment_PricingID,
                        ep.fld_Equipment_Price,
                        ep.fld_Equipment_Price_Subsequent,
                        re.fld_Quantity,
                        re.fld_Number_Of_Days,
                        re.fld_Total_Equipment_Cost,

                        p.pk_PaymentID,
                        p.fld_Created_At,
                        p.fld_Amount_Due,
                        p.fld_Amount_Paid,
                        p.fld_Payment_Status,
                        p.fld_Payment_Date,
                        r.fld_OT_Hours  
                        

                    FROM dbo.tbl_Reservation r
                    LEFT JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    LEFT JOIN dbo.tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
                    LEFT JOIN dbo.tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
                    LEFT JOIN dbo.tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
                    LEFT JOIN dbo.tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
                    LEFT JOIN dbo.tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                    LEFT JOIN dbo.tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
                    LEFT JOIN dbo.tbl_Payment p ON r.pk_ReservationID = p.fk_ReservationID
                    WHERE r.pk_ReservationID = @reservationId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@reservationId", reservationId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Billing_Model billing = new Billing_Model
                                {

                                    pk_Requesting_PersonID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    fld_Surname = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                    fld_First_Name = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    fld_Middle_Name = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    fld_Requesting_Person_Address = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    fld_Contact_Number = reader.IsDBNull(5) ? "" : reader.GetString(5),

                                    pk_ReservationID = reader.GetInt32(6),
                                    fld_Control_Number = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                    fld_Reservation_Type = reader.IsDBNull(8) ? "" : reader.GetString(8),
                                    fld_Start_Date = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9),
                                    fld_End_Date = reader.IsDBNull(10) ? DateTime.MinValue : reader.GetDateTime(10),
                                    fld_Start_Time = reader.IsDBNull(11) ? TimeSpan.Zero : reader.GetTimeSpan(11),
                                    fld_End_Time = reader.IsDBNull(12) ? TimeSpan.Zero : reader.GetTimeSpan(12),
                                    fld_Activity_Name = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                    fld_Number_Of_Participants = reader.IsDBNull(14) ? 0 : reader.GetInt32(14),
                                    fld_Reservation_Status = reader.IsDBNull(15) ? "" : reader.GetString(15),
                                    fld_Total_Amount = reader.IsDBNull(16) ? 0 : reader.GetDecimal(16),

                                    pk_VenueID = reader.IsDBNull(17) ? 0 : reader.GetInt32(17),
                                    fld_Venue_Name = reader.IsDBNull(18) ? "" : reader.GetString(18),
                                    pk_Venue_ScopeID = reader.IsDBNull(19) ? 0 : reader.GetInt32(19),
                                    fld_Venue_Scope_Name = reader.IsDBNull(20) ? "" : reader.GetString(20),

                                    pk_Venue_PricingID = reader.IsDBNull(21) ? 0 : reader.GetInt32(21),
                                    fld_First4Hrs_Rate = reader.IsDBNull(22) ? 0 : reader.GetDecimal(22),
                                    fld_Hourly_Rate = reader.IsDBNull(23) ? 0 : reader.GetDecimal(23),

                                    fk_EquipmentID = reader.IsDBNull(24) ? 0 : reader.GetInt32(24),
                                    fld_Equipment_Name = reader.IsDBNull(25) ? "" : reader.GetString(25),
                                    fk_Equipment_PricingID = reader.IsDBNull(26) ? 0 : reader.GetInt32(26),
                                    fld_Equipment_Price = reader.IsDBNull(27) ? 0 : reader.GetDecimal(27),
                                    fld_Equipment_Price_Subsequent = reader.IsDBNull(28) ? 0 : reader.GetDecimal(28),
                                    fld_Quantity = reader.IsDBNull(29) ? 0 : reader.GetInt32(29),
                                    fld_Number_Of_Days = reader.IsDBNull(30) ? 0 : reader.GetInt32(30),
                                    fld_Total_Equipment_Cost = reader.IsDBNull(31) ? 0 : reader.GetDecimal(31),

                                    pk_PaymentID = reader.IsDBNull(32) ? 0 : reader.GetInt32(32),
                                    fld_Created_At = reader.IsDBNull(33) ? DateTime.MinValue : reader.GetDateTime(33),
                                    fld_Amount_Due = reader.IsDBNull(34) ? 0 : reader.GetDecimal(34),
                                    fld_Amount_Paid = reader.IsDBNull(35) ? 0 : reader.GetDecimal(35),
                                    fld_Payment_Status = reader.IsDBNull(36) ? "" : reader.GetString(36),
                                    fld_Payment_Date = reader.IsDBNull(37) ? DateTime.MinValue : reader.GetDateTime(37),
                                    fld_OT_Hours = reader.IsDBNull(38) ? 0 : reader.GetInt32(38) 
                                };

                                billingRecords.Add(billing);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Database error: " + ex.Message);
            }

            return billingRecords;
        }

        // Get Revenue Data by Filters (RDLC of frm_Report_Revenue_By_Reservation_Type)
        public List<Billing_Model> GetRevenueByFilters(DateTime startDate, DateTime endDate, string paymentStatus, string reservationType)
        {
            List<Billing_Model> revenueData = new List<Billing_Model>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("✅ Fetching Revenue Data");

                    string query = @"
                        SELECT 
                            rp.pk_Requesting_PersonID,
                            rp.fld_Surname,
                            rp.fld_First_Name,
                            rp.fld_Middle_Name,
                            rp.fld_Requesting_Person_Address,
                            rp.fld_Contact_Number,
                            

                            r.pk_ReservationID,
                            r.fld_Control_Number,
                            r.fld_Reservation_Type,
                            r.fld_Start_Date,
                            r.fld_End_Date,
                            r.fld_Start_Time,
                            r.fld_End_Time,
                            r.fld_Activity_Name,
                            r.fld_Number_Of_Participants,
                            r.fld_Reservation_Status,
                            r.fld_Total_Amount,

                            v.pk_VenueID,
                            v.fld_Venue_Name,
                            vs.pk_Venue_ScopeID,
                            vs.fld_Venue_Scope_Name,

                            vp.pk_Venue_PricingID,
                            vp.fld_First4Hrs_Rate,
                            vp.fld_Hourly_Rate,
                            

                            re.fk_EquipmentID,
                            e.fld_Equipment_Name,
                            re.fk_Equipment_PricingID,
                            ep.fld_Equipment_Price,
                            ep.fld_Equipment_Price_Subsequent,
                            re.fld_Quantity,
                            re.fld_Number_Of_Days,
                            re.fld_Total_Equipment_Cost,

                            p.pk_PaymentID,
                            p.fld_Created_At,
                            p.fld_Amount_Due,
                            p.fld_Amount_Paid,
                            p.fld_Payment_Status,
                            p.fld_Payment_Date,
                            rp.fld_Request_Origin,
                            vp.fld_Aircon,
                            vp.fld_Rate_Type,
                            vp.fld_Additional_Charge,
                            r.fld_OT_Hours

                        FROM dbo.tbl_Reservation r
                        LEFT JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                        LEFT JOIN dbo.tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
                        LEFT JOIN dbo.tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
                        LEFT JOIN dbo.tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
                        LEFT JOIN dbo.tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
                        LEFT JOIN dbo.tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                        LEFT JOIN dbo.tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
                        LEFT JOIN dbo.tbl_Payment p ON r.pk_ReservationID = p.fk_ReservationID

                        WHERE r.fld_Start_Date >= @StartDate
                          AND r.fld_End_Date < DATEADD(day, 1, @EndDate)
                          AND (@PaymentStatus = 'All' OR LTRIM(RTRIM(p.fld_Payment_Status)) = LTRIM(RTRIM(@PaymentStatus)))
                          AND (@ReservationType = 'All' OR LTRIM(RTRIM(r.fld_Reservation_Type)) = LTRIM(RTRIM(@ReservationType)))

                        ORDER BY r.fld_Control_Number DESC";


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // ✅ Add parameters
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);
                        cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                        cmd.Parameters.AddWithValue("@ReservationType", reservationType);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                revenueData.Add(new Billing_Model
                                {
                                    pk_Requesting_PersonID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    fld_Surname = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                    fld_First_Name = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    fld_Middle_Name = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    fld_Requesting_Person_Address = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    fld_Contact_Number = reader.IsDBNull(5) ? "" : reader.GetString(5),

                                    pk_ReservationID = reader.GetInt32(6),
                                    fld_Control_Number = reader.GetString(7),
                                    fld_Reservation_Type = reader.GetString(8),
                                    fld_Start_Date = reader.GetDateTime(9),
                                    fld_End_Date = reader.GetDateTime(10),
                                    fld_Start_Time = reader.IsDBNull(11) ? TimeSpan.Zero : reader.GetTimeSpan(11),
                                    fld_End_Time = reader.IsDBNull(12) ? TimeSpan.Zero : reader.GetTimeSpan(12),
                                    fld_Activity_Name = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                    fld_Number_Of_Participants = reader.IsDBNull(14) ? 0 : reader.GetInt32(14),
                                    fld_Reservation_Status = reader.IsDBNull(15) ? "Unknown" : reader.GetString(15),
                                    fld_Total_Amount = reader.IsDBNull(16) ? 0 : reader.GetDecimal(16),

                                    pk_VenueID = reader.IsDBNull(17) ? 0 : reader.GetInt32(17),
                                    fld_Venue_Name = reader.IsDBNull(18) ? "N/A" : reader.GetString(18),
                                    pk_Venue_ScopeID = reader.IsDBNull(19) ? 0 : reader.GetInt32(19),
                                    fld_Venue_Scope_Name = reader.IsDBNull(20) ? "N/A" : reader.GetString(20),

                                    pk_Venue_PricingID = reader.IsDBNull(21) ? 0 : reader.GetInt32(21),
                                    fld_First4Hrs_Rate = reader.IsDBNull(22) ? 0 : reader.GetDecimal(22),
                                    fld_Hourly_Rate = reader.IsDBNull(23) ? 0 : reader.GetDecimal(23),

                                    fk_EquipmentID = reader.IsDBNull(24) ? 0 : reader.GetInt32(24),
                                    fld_Equipment_Name = reader.IsDBNull(25) ? "N/A" : reader.GetString(25),
                                    fk_Equipment_PricingID = reader.IsDBNull(26) ? 0 : reader.GetInt32(26),
                                    fld_Equipment_Price = reader.IsDBNull(27) ? 0 : reader.GetDecimal(27),
                                    fld_Equipment_Price_Subsequent = reader.IsDBNull(28) ? 0 : reader.GetDecimal(28),
                                    fld_Quantity = reader.IsDBNull(29) ? 0 : reader.GetInt32(29),
                                    fld_Number_Of_Days = reader.IsDBNull(30) ? 0 : reader.GetInt32(30),
                                    fld_Total_Equipment_Cost = reader.IsDBNull(31) ? 0 : reader.GetDecimal(31),

                                    pk_PaymentID = reader.IsDBNull(32) ? 0 : reader.GetInt32(32),
                                    fld_Created_At = reader.IsDBNull(33) ? DateTime.MinValue : reader.GetDateTime(33),
                                    fld_Amount_Due = reader.IsDBNull(34) ? 0 : reader.GetDecimal(34),
                                    fld_Amount_Paid = reader.IsDBNull(35) ? 0 : reader.GetDecimal(35),
                                    fld_Payment_Status = reader.IsDBNull(36) ? "Unknown" : reader.GetString(36),
                                    fld_Payment_Date = reader.IsDBNull(37) ? DateTime.MinValue : reader.GetDateTime(37),
                                    fld_Request_Origin = reader.IsDBNull(38) ? " " : reader.GetString(38),
                                    fld_Aircon = reader.IsDBNull(39) ? false : reader.GetBoolean(39),
                                    fld_Rate_Type = reader.IsDBNull(40) ? " " : reader.GetString(40),
                                    fld_Additional_Charge = reader.IsDBNull(41) ? 0 : reader.GetDecimal(41),
                                    fld_OT_Hours = reader.IsDBNull(42) ? 0 : reader.GetInt32(42)
                                });
                            }
                        }
                    }
                }
                Console.WriteLine($"✅ Total Revenue Records Retrieved: {revenueData.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Database error: " + ex.Message);
            }

            return revenueData;
        }



        // Fetch billing details for a specific reservation
        public Billing_Model GetBillingDetailsByReservationID(int reservationID)
        {
            Billing_Model billingDetails = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
        SELECT 
            rp.pk_Requesting_PersonID,
            rp.fld_Surname,
            rp.fld_First_Name,
            rp.fld_Middle_Name,
            rp.fld_Requesting_Person_Address,
            rp.fld_Contact_Number,
            r.pk_ReservationID,
            r.fld_Control_Number,
            r.fld_Reservation_Type,
            r.fld_Start_Date,
            r.fld_End_Date,
            r.fld_Start_Time,
            r.fld_End_Time,
            r.fld_Activity_Name,
            r.fld_Number_Of_Participants,
            r.fld_Reservation_Status,
            r.fld_Total_Amount,
            v.pk_VenueID,
            v.fld_Venue_Name,
            vs.pk_Venue_ScopeID,
            vs.fld_Venue_Scope_Name,
            vp.pk_Venue_PricingID,
            vp.fld_First4Hrs_Rate,
            vp.fld_Hourly_Rate,
            re.fk_EquipmentID,
            e.fld_Equipment_Name,
            re.fk_Equipment_PricingID,
            ep.fld_Equipment_Price,
            ep.fld_Equipment_Price_Subsequent,
            re.fld_Quantity,
            re.fld_Number_Of_Days,
            re.fld_Total_Equipment_Cost,
            p.pk_PaymentID,
            p.fld_Created_At,
            p.fld_Amount_Due,
            p.fld_Amount_Paid,
            p.fld_Payment_Status,
            p.fld_Payment_Date,
            rp.fld_Request_Origin,
            vp.fld_Aircon,
            vp.fld_Rate_Type,
            vp.fld_Additional_Charge,
            r.fld_OT_Hours
        FROM dbo.tbl_Reservation r
        LEFT JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
        LEFT JOIN dbo.tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
        LEFT JOIN dbo.tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
        LEFT JOIN dbo.tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
        LEFT JOIN dbo.tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
        LEFT JOIN dbo.tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
        LEFT JOIN dbo.tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
        LEFT JOIN dbo.tbl_Payment p ON r.pk_ReservationID = p.fk_ReservationID
        WHERE r.pk_ReservationID = @ReservationID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReservationID", reservationID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                billingDetails = new Billing_Model
                                {
                                    pk_Requesting_PersonID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    fld_Surname = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                    fld_First_Name = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    fld_Middle_Name = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    fld_Requesting_Person_Address = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    fld_Contact_Number = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    pk_ReservationID = reader.GetInt32(6),
                                    fld_Control_Number = reader.GetString(7),
                                    fld_Reservation_Type = reader.GetString(8),
                                    fld_Start_Date = reader.GetDateTime(9),
                                    fld_End_Date = reader.GetDateTime(10),
                                    fld_Start_Time = reader.IsDBNull(11) ? TimeSpan.Zero : reader.GetTimeSpan(11),
                                    fld_End_Time = reader.IsDBNull(12) ? TimeSpan.Zero : reader.GetTimeSpan(12),
                                    fld_Activity_Name = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                    fld_Number_Of_Participants = reader.IsDBNull(14) ? 0 : reader.GetInt32(14),
                                    fld_Reservation_Status = reader.IsDBNull(15) ? "Unknown" : reader.GetString(15),
                                    fld_Total_Amount = reader.IsDBNull(16) ? 0 : reader.GetDecimal(16),
                                    pk_VenueID = reader.IsDBNull(17) ? 0 : reader.GetInt32(17),
                                    fld_Venue_Name = reader.IsDBNull(18) ? "" : reader.GetString(18),
                                    pk_Venue_ScopeID = reader.IsDBNull(19) ? 0 : reader.GetInt32(19),
                                    fld_Venue_Scope_Name = reader.IsDBNull(20) ? "" : reader.GetString(20),
                                    pk_Venue_PricingID = reader.IsDBNull(21) ? 0 : reader.GetInt32(21),
                                    fld_First4Hrs_Rate = reader.IsDBNull(22) ? 0 : reader.GetDecimal(22),
                                    fld_Hourly_Rate = reader.IsDBNull(23) ? 0 : reader.GetDecimal(23),
                                    fk_EquipmentID = reader.IsDBNull(24) ? 0 : reader.GetInt32(24),
                                    fld_Equipment_Name = reader.IsDBNull(25) ? "" : reader.GetString(25),
                                    fk_Equipment_PricingID = reader.IsDBNull(26) ? 0 : reader.GetInt32(26),
                                    fld_Equipment_Price = reader.IsDBNull(27) ? 0 : reader.GetDecimal(27),
                                    fld_Equipment_Price_Subsequent = reader.IsDBNull(28) ? 0 : reader.GetDecimal(28),
                                    fld_Quantity = reader.IsDBNull(29) ? 0 : reader.GetInt32(29),
                                    fld_Number_Of_Days = reader.IsDBNull(30) ? 0 : reader.GetInt32(30),
                                    fld_Total_Equipment_Cost = reader.IsDBNull(31) ? 0 : reader.GetDecimal(31),
                                    pk_PaymentID = reader.IsDBNull(32) ? 0 : reader.GetInt32(32),
                                    fld_Created_At = reader.IsDBNull(33) ? DateTime.MinValue : reader.GetDateTime(33),
                                    fld_Amount_Due = reader.IsDBNull(34) ? 0 : reader.GetDecimal(34),
                                    fld_Amount_Paid = reader.IsDBNull(35) ? 0 : reader.GetDecimal(35),
                                    fld_Payment_Status = reader.IsDBNull(36) ? "Unknown" : reader.GetString(36),
                                    fld_Payment_Date = reader.IsDBNull(37) ? (DateTime?)null : reader.GetDateTime(37),
                                    fld_Request_Origin = reader.IsDBNull(38) ? "" : reader.GetString(38),
                                    fld_Aircon = reader.IsDBNull(39) ? false : reader.GetBoolean(39),
                                    fld_Rate_Type = reader.IsDBNull(40) ? "" : reader.GetString(40),
                                    fld_Additional_Charge = reader.IsDBNull(41) ? 0 : reader.GetDecimal(41),
                                    fld_OT_Hours = reader.IsDBNull(42) ? 0 : reader.GetInt32(42)    
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error fetching billing details: " + ex.Message);
            }

            return billingDetails;
        }

        public bool UpdateReservationStatus(int reservationID, string newStatus)
        {
            // Ensure newStatus is valid as per the constraint
            if (newStatus != "Cancelled" && newStatus != "Confirmed" && newStatus != "Pending")
            {
                MessageBox.Show("Invalid status value. Only 'Cancelled', 'Confirmed', or 'Pending' are allowed.");
                return false;
            }

            // SQL query to update reservation status
            string query = "UPDATE tbl_Reservation SET fld_Reservation_Status = @Status WHERE pk_ReservationID = @ReservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Define the parameter types explicitly
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = newStatus;
                cmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;

                // Open connection and execute query
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                // If the reservation status update was successful and the status is "Confirmed"
                if (rowsAffected > 0 && newStatus == "Confirmed")
                {
                    // Fetch the total amount from tbl_Reservation
                    string amountQuery = "SELECT fld_Total_Amount FROM tbl_Reservation WHERE pk_ReservationID = @ReservationID";

                    using (SqlCommand amountCmd = new SqlCommand(amountQuery, conn))
                    {
                        amountCmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;

                        decimal totalAmount = (decimal)amountCmd.ExecuteScalar();

                        // Update the payment details in tbl_Payment
                        if (totalAmount > 0)
                        {
                            string paymentQuery = @"
                        INSERT INTO tbl_Payment (fk_ReservationID, fld_Payment_Status, fld_Amount_Due, fld_Amount_Paid, fld_Payment_Date, fld_Created_At)
                        VALUES (@ReservationID, 'Confirmed', @AmountDue, @AmountPaid, @PaymentDate, @CreatedAt)";

                            using (SqlCommand paymentCmd = new SqlCommand(paymentQuery, conn))
                            {
                                paymentCmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;
                                paymentCmd.Parameters.Add("@AmountDue", SqlDbType.Decimal).Value = totalAmount;
                                paymentCmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = totalAmount; // Paid amount is the same as the total amount
                                paymentCmd.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = DateTime.Today; // Payment Date is today's date
                                paymentCmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = DateTime.Now; // Created At is the current date and time

                                paymentCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                return rowsAffected > 0; // Returns true if at least one row is affected
            }
        }


        // When status = Cancelled apply deduction of 5% to the total amount
        public bool ApplyCancellationDeduction(int reservationID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            UPDATE tbl_Reservation
            SET fld_Total_Amount = fld_Total_Amount * 0.05
            WHERE pk_ReservationID = @ReservationID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        //////

        public async Task<bool> UpdateReservationExtension(int reservationID, int otHours)
        {
            try
            {
                // Step 1: Get current total amount and hourly rate in parallel to improve efficiency
                var hourlyRateTask = GetHourlyRate(reservationID);
                var currentTotalAmountTask = GetCurrentTotalAmount(reservationID);
                var currentOTHoursTask = GetCurrentOvertimeHours(reservationID);  // Get current OT hours

                // Wait for all tasks to complete
                await Task.WhenAll(hourlyRateTask, currentTotalAmountTask, currentOTHoursTask);

                // Step 2: Calculate new total amount and accumulate overtime hours
                decimal hourlyRate = hourlyRateTask.Result;
                decimal currentTotalAmount = currentTotalAmountTask.Result;
                decimal currentOTHours = currentOTHoursTask.Result;  // Existing overtime hours
                decimal newTotalAmount = currentTotalAmount + (hourlyRate * otHours);
                decimal newOTHours = currentOTHours + otHours;  // Accumulate overtime hours

                // Step 3: Update the database with the new overtime hours and total amount
                var query = "UPDATE tbl_Reservation SET fld_OT_Hours = @newOTHours, fld_Total_Amount = @newTotalAmount WHERE pk_ReservationID = @reservationID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@newOTHours", newOTHours);  // Updated OT hours
                    cmd.Parameters.AddWithValue("@newTotalAmount", newTotalAmount);  // Updated total amount
                    cmd.Parameters.AddWithValue("@reservationID", reservationID);

                    conn.Open();
                    return await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error appropriately
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        private async Task<decimal> GetHourlyRate(int reservationID)
        {
            var query = "SELECT vp.fld_Hourly_Rate FROM tbl_Venue_Pricing vp " +
                        "JOIN tbl_Reservation r ON vp.pk_Venue_PricingID = r.fk_Venue_PricingID " +
                        "WHERE r.pk_ReservationID = @reservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                conn.Open();

                var result = await cmd.ExecuteScalarAsync();
                // Ensure DBNull is handled
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            }
        }

        private async Task<decimal> GetCurrentTotalAmount(int reservationID)
        {
            var query = "SELECT fld_Total_Amount FROM tbl_Reservation WHERE pk_ReservationID = @reservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                conn.Open();

                var result = await cmd.ExecuteScalarAsync();
                // Ensure DBNull is handled
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            }
        }

        private async Task<decimal> GetCurrentOvertimeHours(int reservationID)
        {
            var query = "SELECT fld_OT_Hours FROM tbl_Reservation WHERE pk_ReservationID = @reservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                conn.Open();

                var result = await cmd.ExecuteScalarAsync();
                // Ensure DBNull is handled
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            }
        }

        private async Task<string> GetReservationStatus(int reservationID)
        {
            var query = "SELECT fld_Reservation_Status FROM tbl_Reservation WHERE pk_ReservationID = @reservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                conn.Open();

                var result = await cmd.ExecuteScalarAsync();
                // Ensure DBNull is handled and return the status as string
                return result != DBNull.Value ? result.ToString() : string.Empty;
            }
        }


        ////



    }




}

