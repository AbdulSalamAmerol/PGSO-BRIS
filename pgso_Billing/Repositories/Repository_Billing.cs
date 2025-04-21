using pgso.Billing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso.Billing.Repositories
{
    // I CHANGED THIS TO PUBLIC FROM INTERNAL
    public class Repo_Billing
    {
     
        private string connectionString = "Data Source=KIMABZ\\SQL;Initial Catalog=BRIS_EXPERIMENT_3.0;Persist Security Info=True;User ID=sa;Password=abz123;Encrypt=False;";


        public List<Model_Billing> GetAllBillingRecords()
        {
            List<Model_Billing> billings = new List<Model_Billing>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connected to Database");

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
                                    r.fld_OT_Hours,
                                    p.fld_Refund_Amount,
                                    p.fld_Cancellation_Fee,
                                    p.fld_Final_Amount_Paid, 
                                    p.fld_Overtime_Fee     

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

                            Model_Billing billing = new Model_Billing
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
                                fld_OT_Hours = reader.IsDBNull(38) ? 0 : reader.GetInt32(38),
                                fld_Refund_Amount = reader.IsDBNull(39) ? 0 : reader.GetDecimal(39),
                                fld_Cancellation_Fee = reader.IsDBNull(40) ? 0 : reader.GetDecimal(40),
                                fld_Final_Amount_Paid = reader.IsDBNull(41) ? 0 : reader.GetDecimal(41),
                                fld_Overtime_Fee = reader.IsDBNull(42) ? 0 : reader.GetDecimal(42)
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
        public List<Model_Billing> GetBillingRecordsByReservationId(int reservationId)
        {
            List<Model_Billing> billingRecords = new List<Model_Billing>();


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
                        r.fld_OT_Hours,
                        p.fld_Refund_Amount,        
                        p.fld_Cancellation_Fee,
                        p.fld_Final_Amount_Paid,
                        p.fld_Overtime_Fee
                        

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
                                Model_Billing billing = new Model_Billing
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
                                    fld_OT_Hours = reader.IsDBNull(38) ? 0 : reader.GetInt32(38),
                                    fld_Refund_Amount = reader.IsDBNull(39) ? 0 : reader.GetDecimal(39),
                                    fld_Cancellation_Fee = reader.IsDBNull(40) ? 0 : reader.GetDecimal(40),
                                    fld_Final_Amount_Paid = reader.IsDBNull(41) ? 0 : reader.GetDecimal(41),
                                    fld_Overtime_Fee = reader.IsDBNull(42) ? 0 : reader.GetDecimal(42)
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
        public List<Model_Billing> GetRevenueByFilters(DateTime startDate, DateTime endDate, string paymentStatus, string reservationType)
        {
            List<Model_Billing> revenueData = new List<Model_Billing>();

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
                            r.fld_OT_Hours,
                            p.fld_Refund_Amount,
                            p.fld_Cancellation_Fee,
                            p.fld_Final_Amount_Paid,
                            p.fld_Overtime_Fee

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
                                revenueData.Add(new Model_Billing
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
                                    fld_OT_Hours = reader.IsDBNull(42) ? 0 : reader.GetInt32(42),
                                    fld_Refund_Amount = reader.IsDBNull(43) ? 0 : reader.GetDecimal(43),
                                    fld_Cancellation_Fee = reader.IsDBNull(44) ? 0 : reader.GetDecimal(44),
                                    fld_Final_Amount_Paid = reader.IsDBNull(45) ? 0 : reader.GetDecimal(45),
                                    fld_Overtime_Fee = reader.IsDBNull(46) ? 0 : reader.GetDecimal(46)

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



        // Fetch billing details for a specific reservation (used by Venue User Control and frm_Billing)
        public Model_Billing GetBillingDetailsByReservationID(int reservationID)
        {
            Model_Billing billingDetails = null;

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
                            r.fld_OT_Hours,
                            p.fld_Refund_Amount,
                            p.fld_Cancellation_Fee,
                            p.fld_Final_Amount_Paid,
                            p.fld_Overtime_Fee
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
                                billingDetails = new Model_Billing
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
                                    fld_Payment_Status = reader.IsDBNull(36) ? "Pending" : reader.GetString(36),
                                    fld_Payment_Date = reader.IsDBNull(37) ? (DateTime?)null : reader.GetDateTime(37),
                                    fld_Request_Origin = reader.IsDBNull(38) ? "" : reader.GetString(38),
                                    fld_Aircon = reader.IsDBNull(39) ? false : reader.GetBoolean(39),
                                    fld_Rate_Type = reader.IsDBNull(40) ? "" : reader.GetString(40),
                                    fld_Additional_Charge = reader.IsDBNull(41) ? 0 : reader.GetDecimal(41),
                                    fld_OT_Hours = reader.IsDBNull(42) ? 0 : reader.GetInt32(42),
                                    fld_Refund_Amount = reader.IsDBNull(43) ? 0 : reader.GetDecimal(43),
                                    fld_Cancellation_Fee = reader.IsDBNull(44) ? 0 : reader.GetDecimal(44),
                                    fld_Final_Amount_Paid = reader.IsDBNull(45) ? 0 : reader.GetDecimal(45),
                                    fld_Overtime_Fee = reader.IsDBNull(46) ? 0 : reader.GetDecimal(46)
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
                        INSERT INTO tbl_Payment (fk_ReservationID, fld_Payment_Status, fld_Amount_Due, fld_Amount_Paid, fld_Payment_Date, fld_Created_At, fld_Final_Amount_Paid)
                        VALUES (@ReservationID, 'Confirmed', @AmountDue, @AmountPaid, @PaymentDate, @CreatedAt, @FinalAmountPaid)";

                            using (SqlCommand paymentCmd = new SqlCommand(paymentQuery, conn))
                            {
                                paymentCmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;
                                paymentCmd.Parameters.Add("@AmountDue", SqlDbType.Decimal).Value = totalAmount;
                                paymentCmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = totalAmount; // Paid amount is the same as the total amount
                                paymentCmd.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = DateTime.Today; // Payment Date is today's date
                                paymentCmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = DateTime.Now; // Created At is the current date and time
                                paymentCmd.Parameters.Add("@FinalAmountPaid", SqlDbType.Decimal).Value = totalAmount; // Final Amount Paid is the same as the total amount  
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
        UPDATE p
        SET 
            p.fld_Refund_Amount = r.fld_Total_Amount * 0.95,
            p.fld_Cancellation_Fee = r.fld_Total_Amount * 0.05,
            p.fld_Final_Amount_Paid = r.fld_Total_Amount * 0.05
        FROM tbl_Payment p
        JOIN tbl_Reservation r ON r.pk_ReservationID = p.fk_ReservationID
        WHERE p.fk_ReservationID = @ReservationID";

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
                decimal newFinalAmountPaid = currentTotalAmount + (hourlyRate * otHours);
                decimal newOTHours = currentOTHours + otHours;  // Accumulate overtime hours
                decimal newOvertimeFee = otHours * hourlyRate;

                // Step 3: Update the database with the new overtime hours and total amount
                var query = @"
                    
                    UPDATE p
                    SET 
                        p.fld_Final_Amount_Paid = @newFinalAmountPaid,
                        p.fld_Overtime_Fee = @newOvertimeFee
                    FROM tbl_Payment p
                    JOIN tbl_Reservation r ON r.pk_ReservationID = p.fk_ReservationID
                    WHERE r.pk_ReservationID = @reservationID;

                   
                    UPDATE r
                    SET 
                        r.fld_OT_Hours = @newOTHours
                    FROM tbl_Reservation r
                    WHERE r.pk_ReservationID = @reservationID;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@newOTHours", newOTHours);  // Updated OT hours
                    cmd.Parameters.AddWithValue("@newFinalAmountPaid", newFinalAmountPaid);  // Updated Final Amount Paid
                    cmd.Parameters.AddWithValue("@newOvertimeFee", newOvertimeFee);
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
  
        // Currently Not in Use
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

        // Equipment User Control Datagridview
        public List<Model_Billing> GetEquipmentBillingDetailsByReservationID(int reservationID)
        {
            List<Model_Billing> billingDetailsList = new List<Model_Billing>();

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
            rp.fld_Request_Origin,

            r.pk_ReservationID,
            r.fld_Control_Number,
            r.fld_Reservation_Type,
            r.fld_Start_Date,
            r.fld_End_Date,
            r.fld_Activity_Name,
            r.fld_Total_Amount,

            re.fk_EquipmentID,
            e.fld_Equipment_Name,
            re.fk_Equipment_PricingID,
            ep.fld_Equipment_Price,
            ep.fld_Equipment_Price_Subsequent,
            re.fld_Quantity,
            re.fld_Number_Of_Days,
            re.fld_Total_Equipment_Cost,
            r.fld_OT_Hours,

            p.pk_PaymentID,
            p.fld_Created_At,
            p.fld_Amount_Due,
            p.fld_Amount_Paid,
            p.fld_Payment_Status,
            p.fld_Payment_Date,
            p.fld_Refund_Amount,
            p.fld_Cancellation_Fee,
            p.fld_Final_Amount_Paid,
            p.fld_Overtime_Fee,
            re.pk_Reservation_EquipmentID,
            r.fld_Reservation_Status,
            re.fld_Start_Date_Eq,
            re.fld_End_Date_Eq,
            e.fld_Total_Stock,
            e.fld_Remaining_Stock,
            re.fld_Equipment_Status,
            re.fld_Date_Returned,
            re.fld_Quantity_Returned

        FROM dbo.tbl_Reservation r
        LEFT JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
        LEFT JOIN dbo.tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
        LEFT JOIN dbo.tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
        LEFT JOIN dbo.tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
        LEFT JOIN dbo.tbl_Payment p ON r.pk_ReservationID = p.fk_ReservationID
        WHERE r.pk_ReservationID = @ReservationID
        ORDER BY re.pk_Reservation_EquipmentID DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReservationID", reservationID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var billingDetails = new Model_Billing
                                {
                                    // Requesting Person
                                    pk_Requesting_PersonID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    fld_Surname = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                    fld_First_Name = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    fld_Middle_Name = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    fld_Requesting_Person_Address = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    fld_Contact_Number = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    fld_Request_Origin = reader.IsDBNull(6) ? "" : reader.GetString(6),

                                    // Reservation
                                    pk_ReservationID = reader.GetInt32(7),
                                    fld_Control_Number = reader.GetString(8),
                                    fld_Reservation_Type = reader.GetString(9),
                                    fld_Start_Date = reader.GetDateTime(10),
                                    fld_End_Date = reader.GetDateTime(11),
                                    fld_Activity_Name = reader.IsDBNull(12) ? "" : reader.GetString(12),
                                    fld_Total_Amount = reader.IsDBNull(13) ? 0 : reader.GetDecimal(13),

                                    // Equipment
                                    fk_EquipmentID = reader.IsDBNull(14) ? 0 : reader.GetInt32(14),
                                    fld_Equipment_Name = reader.IsDBNull(15) ? "" : reader.GetString(15),
                                    fk_Equipment_PricingID = reader.IsDBNull(16) ? 0 : reader.GetInt32(16),
                                    fld_Equipment_Price = reader.IsDBNull(17) ? 0 : reader.GetDecimal(17),
                                    fld_Equipment_Price_Subsequent = reader.IsDBNull(18) ? 0 : reader.GetDecimal(18),
                                    fld_Quantity = reader.IsDBNull(19) ? 0 : reader.GetInt32(19),
                                    fld_Number_Of_Days = reader.IsDBNull(20) ? 0 : reader.GetInt32(20),
                                    fld_Total_Equipment_Cost = reader.IsDBNull(21) ? 0 : reader.GetDecimal(21),
                                    fld_OT_Days = reader.IsDBNull(22) ? 0 : reader.GetInt32(22),

                                    // Payment
                                    pk_PaymentID = reader.IsDBNull(23) ? 0 : reader.GetInt32(23),
                                    fld_Created_At = reader.IsDBNull(24) ? DateTime.MinValue : reader.GetDateTime(24),
                                    fld_Amount_Due = reader.IsDBNull(25) ? 0 : reader.GetDecimal(25),
                                    fld_Amount_Paid = reader.IsDBNull(26) ? 0 : reader.GetDecimal(26),
                                    fld_Payment_Status = reader.IsDBNull(27) ? "Unknown" : reader.GetString(27),
                                    fld_Payment_Date = reader.IsDBNull(28) ? (DateTime?)null : reader.GetDateTime(28),
                                    fld_Refund_Amount = reader.IsDBNull(29) ? 0 : reader.GetDecimal(29),
                                    fld_Cancellation_Fee = reader.IsDBNull(30) ? 0 : reader.GetDecimal(30),
                                    fld_Final_Amount_Paid = reader.IsDBNull(31) ? 0 : reader.GetDecimal(31),
                                    fld_Overtime_Fee = reader.IsDBNull(32) ? 0 : reader.GetDecimal(32),
                                    pk_Reservation_EquipmentID = reader.IsDBNull(33) ? 0 : reader.GetInt32(33),
                                    fld_Reservation_Status = reader.IsDBNull(34) ? "" : reader.GetString(34),
                                    fld_Start_Date_Eq = reader.IsDBNull(35) ? DateTime.MinValue : reader.GetDateTime(35),
                                    fld_End_Date_Eq = reader.IsDBNull(36) ? DateTime.MinValue : reader.GetDateTime(36),
                                    fld_Total_Stock = reader.IsDBNull(37) ? 0 : reader.GetInt32(37),
                                    fld_Remaining_Stock = reader.IsDBNull(38) ? 0 : reader.GetInt32(38),
                                    fld_Equipment_Status = reader.IsDBNull(39) ? "" : reader.GetString(39),
                                    fld_Date_Returned = reader.IsDBNull(40) ? DateTime.MinValue : reader.GetDateTime(40),
                                    fld_Quantity_Returned = reader.IsDBNull(41) ? 0 : reader.GetInt32(41)
                                };

                                billingDetailsList.Add(billingDetails);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error fetching billing details: " + ex.Message);
            }

            return billingDetailsList;
        }



        // START Datagrid Equipment User Control CRUD
        /*
        public List<Model_Billing> GetReservationEquipment()
        { 
            var model_Billing_equipment_reservations = new List<Model_Billing>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("✅ Fetching Reservation Equipment Data");
                    string query = @"
                    SELECT 
                        rp.pk_Requesting_PersonID,
                        rp.fld_Surname,
                        rp.fld_First_Name,
                        rp.fld_Middle_Name,
                        rp.fld_Requesting_Person_Address,
                        rp.fld_Contact_Number,
                        rp.fld_Request_Origin,

                        r.pk_ReservationID,
                        r.fld_Control_Number,
                        r.fld_Reservation_Type,
                        r.fld_Start_Date,
                        r.fld_End_Date,
                        r.fld_Activity_Name,
                        r.fld_Total_Amount,

                        re.fk_EquipmentID,
                        e.fld_Equipment_Name,
                        re.fk_Equipment_PricingID,
                        ep.fld_Equipment_Price,
                        ep.fld_Equipment_Price_Subsequent,
                        re.fld_Quantity,
                        re.fld_Number_Of_Days,
                        re.fld_Total_Equipment_Cost,
                        r.fld_OT_Hours,

                        p.pk_PaymentID,
                        p.fld_Created_At,
                        p.fld_Amount_Due,
                        p.fld_Amount_Paid,
                        p.fld_Payment_Status,
                        p.fld_Payment_Date,
                        p.fld_Refund_Amount,
                        p.fld_Cancellation_Fee,
                        p.fld_Final_Amount_Paid,
                        p.fld_Overtime_Fee,
                        re.pk_Reservation_EquipmentID,
                        r.fld_Reservation_Status
        
     

                    FROM dbo.tbl_Reservation r
                    LEFT JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    LEFT JOIN dbo.tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
                    LEFT JOIN dbo.tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                    LEFT JOIN dbo.tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
                    LEFT JOIN dbo.tbl_Payment p ON r.pk_ReservationID = p.fk_ReservationID
                    WHERE r.pk_ReservationID = @ReservationID
                    ORDER BY re.pk_Reservation_EquipmentID DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Model_Billing model_Billing_equipment_reservation = new Model_Billing();

                                // Fill in Requesting Person details
                                model_Billing_equipment_reservation.pk_Requesting_PersonID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                model_Billing_equipment_reservation.fld_Surname = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                model_Billing_equipment_reservation.fld_First_Name = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                model_Billing_equipment_reservation.fld_Middle_Name = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                model_Billing_equipment_reservation.fld_Requesting_Person_Address = reader.IsDBNull(4) ? "" : reader.GetString(4);
                                model_Billing_equipment_reservation.fld_Contact_Number = reader.IsDBNull(5) ? "" : reader.GetString(5);
                                model_Billing_equipment_reservation.fld_Request_Origin = reader.IsDBNull(6) ? "" : reader.GetString(6);

                                // Fill in Reservation details
                                model_Billing_equipment_reservation.pk_ReservationID = reader.GetInt32(7);
                                model_Billing_equipment_reservation.fld_Control_Number = reader.GetString(8);
                                model_Billing_equipment_reservation.fld_Reservation_Type = reader.GetString(9);
                                model_Billing_equipment_reservation.fld_Start_Date = reader.GetDateTime(10);
                                model_Billing_equipment_reservation.fld_End_Date = reader.GetDateTime(11);
                                model_Billing_equipment_reservation.fld_Activity_Name = reader.IsDBNull(12) ? "" : reader.GetString(12);
                                model_Billing_equipment_reservation.fld_Total_Amount = reader.IsDBNull(13) ? 0 : reader.GetDecimal(13);

                                // Fill in Equipment details
                                model_Billing_equipment_reservation.fk_EquipmentID = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);
                                model_Billing_equipment_reservation.fld_Equipment_Name = reader.IsDBNull(15) ? "" : reader.GetString(15);
                                model_Billing_equipment_reservation.fk_Equipment_PricingID = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
                                model_Billing_equipment_reservation.fld_Equipment_Price = reader.IsDBNull(17) ? 0 : reader.GetDecimal(17);
                                model_Billing_equipment_reservation.fld_Equipment_Price_Subsequent = reader.IsDBNull(18) ? 0 : reader.GetDecimal(18);
                                model_Billing_equipment_reservation.fld_Quantity = reader.IsDBNull(19) ? 0 : reader.GetInt32(19);
                                model_Billing_equipment_reservation.fld_Number_Of_Days = reader.IsDBNull(20) ? 0 : reader.GetInt32(20);
                                model_Billing_equipment_reservation.fld_Total_Equipment_Cost = reader.IsDBNull(21) ? 0 : reader.GetDecimal(21);
                                model_Billing_equipment_reservation.fld_OT_Days = reader.IsDBNull(22) ? 0 : reader.GetInt32(22);

                                // Fill in Payment details
                                model_Billing_equipment_reservation.pk_PaymentID = reader.IsDBNull(23) ? 0 : reader.GetInt32(23);
                                model_Billing_equipment_reservation.fld_Created_At = reader.IsDBNull(24) ? DateTime.MinValue : reader.GetDateTime(24);
                                model_Billing_equipment_reservation.fld_Amount_Due = reader.IsDBNull(25) ? 0 : reader.GetDecimal(25);
                                model_Billing_equipment_reservation.fld_Amount_Paid = reader.IsDBNull(26) ? 0 : reader.GetDecimal(26);
                                model_Billing_equipment_reservation.fld_Payment_Status = reader.IsDBNull(27) ? "Unknown" : reader.GetString(27);
                                model_Billing_equipment_reservation.fld_Payment_Date = reader.IsDBNull(28) ? (DateTime?)null : reader.GetDateTime(28);
                                model_Billing_equipment_reservation.fld_Refund_Amount = reader.IsDBNull(29) ? 0 : reader.GetDecimal(29);
                                model_Billing_equipment_reservation.fld_Cancellation_Fee = reader.IsDBNull(30) ? 0 : reader.GetDecimal(30);
                                model_Billing_equipment_reservation.fld_Final_Amount_Paid = reader.IsDBNull(31) ? 0 : reader.GetDecimal(31);
                                model_Billing_equipment_reservation.fld_Overtime_Fee = reader.IsDBNull(32) ? 0 : reader.GetDecimal(32);

                                // Additional Equipment Reservation details
                                model_Billing_equipment_reservation.pk_Reservation_EquipmentID = reader.IsDBNull(33) ? 0 : reader.GetInt32(33);
                                model_Billing_equipment_reservation.fld_Reservation_Status = reader.IsDBNull(34) ? "" : reader.GetString(34);

                                // Add the filled model to the list
                                model_Billing_equipment_reservations.Add(model_Billing_equipment_reservation);



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Database error: " + ex.Message);
            }

            return model_Billing_equipment_reservations; 
        }
        */




        /// END
        /// 

        /// START OF CHAT GPT CRUD

        // Repository_Billing.cs



        // Method to fetch all equipment
        public List<dynamic> GetAllEquipments()
        {
            List<dynamic> equipmentList = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT pk_EquipmentID, fld_Equipment_Name FROM tbl_Equipment ORDER BY fld_Equipment_Name";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            equipmentList.Add(new
                            {
                                pk_EquipmentID = reader.GetInt32(0),
                                fld_Equipment_Name = reader.GetString(1)
                            });
                        }
                    } // ✅ reader is closed here
                }
            }

            return equipmentList;
        }

        // Duplicate so i commented it out

        // Method to fetch Venue equipment
        /*
        public List<dynamic> GetAllVenue()
        {
            List<dynamic> venueList = new List<dynamic>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT pk_VenueID, fld_Venue_Name FROM tbl_Venue ORDER BY fld_Venue_Name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            venueList.Add(new
                            {
                                pk_VenueID = reader.GetInt32(0),
                                fld_Venue_Name = reader.GetString(1)
                            });
                        }
                    } // ✅ reader is closed here
                }
            }
            return venueList;
        }
        */

        // Method to fetch equipment pricing by equipment ID
        public dynamic GetEquipmentPricingByEquipmentID(int equipmentID)
        {
            dynamic pricing = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT pk_Equipment_PricingID, fld_Equipment_Price, fld_Equipment_Price_Subsequent
        FROM tbl_Equipment_Pricing
        WHERE fk_EquipmentID = @EquipmentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EquipmentID", equipmentID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pricing = new
                            {
                                pk_Equipment_PricingID = reader.GetInt32(0),
                                fld_Equipment_Price = reader.GetDecimal(1),
                                fld_Equipment_Price_Subsequent = reader.GetDecimal(2)
                            };
                        }
                    } // ✅ reader is closed here
                }
            }

            return pricing;
        }


        // Method to add equipment reservation
        public bool AddEquipmentReservation(int reservationID, int equipmentID, int pricingID, int quantity, int numberOfDays, decimal totalCost, DateTime Start_Date_Eq, DateTime End_Date_Eq)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO tbl_Reservation_Equipment
                (fk_ReservationID, fk_EquipmentID, fk_Equipment_PricingID, fld_Quantity, fld_Number_Of_Days, fld_Total_Equipment_Cost, fld_Start_Date_Eq, fld_End_Date_Eq)
            VALUES
                (@ReservationID, @EquipmentID, @PricingID, @Quantity, @Days, @TotalCost, @StartDateEq, @EndDateEq)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                cmd.Parameters.AddWithValue("@EquipmentID", equipmentID);
                cmd.Parameters.AddWithValue("@PricingID", pricingID);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Days", numberOfDays);
                cmd.Parameters.AddWithValue("@TotalCost", totalCost);
                cmd.Parameters.AddWithValue("@StartDateEq", Start_Date_Eq);
                cmd.Parameters.AddWithValue("@EndDateEq", End_Date_Eq);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // Method to fetch all equipment pricing
        /*public List<dynamic> GetAllEquipmentPricing()
        {
            List<dynamic> pricingList = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT pk_Equipment_PricingID, fld_Equipment_Price, fld_Equipment_Price_Subsequent
        FROM tbl_Equipment_Pricing";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    decimal basePrice = reader.GetDecimal(1);
                    decimal subsequentPrice = reader.GetDecimal(2);

                    pricingList.Add(new
                    {
                        pk_Equipment_PricingID = id,
                        DisplayName = $"Base: ₱{basePrice:0.00}, Next: ₱{subsequentPrice:0.00}"
                    });
                }
            }

            return pricingList;
        }*/

        // Method to calculate the equipment cost
        /*public decimal CalculateEquipmentCost(int pricingID, int quantity, int days)
        {
            decimal basePrice = 0;
            decimal subsequentPrice = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT fld_Equipment_Price, fld_Equipment_Price_Subsequent FROM tbl_Equipment_Pricing WHERE pk_Equipment_PricingID = @PricingID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PricingID", pricingID);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    basePrice = reader.GetDecimal(0);
                    subsequentPrice = reader.GetDecimal(1);
                }
            }

            // First day uses base price, subsequent days use subsequent price
            decimal totalCost = (basePrice * quantity) + (subsequentPrice * (days - 1) * quantity);
            return totalCost;
        }*/




        // Method to get billing details by reservation ID
        /*public Model_Billing GetBillingDetailsByReservationID2(int reservationID)
        {
            var model = new Model_Billing();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Get reservation details
                string reservationQuery = "SELECT * FROM tbl_Reservation WHERE pk_ReservationID = @ReservationID";
                using (var command = new SqlCommand(reservationQuery, connection))
                {
                    command.Parameters.AddWithValue("@ReservationID", reservationID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.pk_ReservationID = Convert.ToInt32(reader["pk_ReservationID"]);
                            model.fld_Control_Number = reader["fld_Control_Number"].ToString();
                            model.fld_First_Name = reader["fld_First_Name"].ToString();
                            model.fld_Middle_Name = reader["fld_Middle_Name"].ToString();
                            model.fld_Surname = reader["fld_Surname"].ToString();
                            model.fld_Requesting_Person_Address = reader["fld_Requesting_Person_Address"].ToString();
                            model.fld_Request_Origin = reader["fld_Request_Origin"].ToString();
                            model.fld_Contact_Number = reader["fld_Contact_Number"].ToString();
                            model.fld_Start_Date = Convert.ToDateTime(reader["fld_Start_Date"]);
                            model.fld_End_Date = Convert.ToDateTime(reader["fld_End_Date"]);
                            model.fld_Reservation_Status = reader["fld_Reservation_Status"].ToString();
                            model.fld_Total_Amount = Convert.ToDecimal(reader["fld_Total_Amount"]);
                            model.fld_OT_Hours = Convert.ToInt32(reader["fld_OT_Hours"]);
                        }
                    }
                }

                // Get equipment reservation details
                string equipmentQuery = "SELECT * FROM tbl_Reservation_Equipment WHERE pk_ReservationID = @ReservationID";
                using (var command = new SqlCommand(equipmentQuery, connection))
                {
                    command.Parameters.AddWithValue("@ReservationID", reservationID);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var equipmentName = reader["fld_Equipment_Name"].ToString();
                            model.EquipmentNames.Add(equipmentName);

                            int equipmentID = Convert.ToInt32(reader["fk_EquipmentID"]);
                            int pricingID = Convert.ToInt32(reader["fk_Equipment_PricingID"]);

                            // Fetch pricing details
                            string pricingQuery = "SELECT * FROM tbl_Equipment_Pricing WHERE pk_Equipment_PricingID = @PricingID";
                            using (var pricingCommand = new SqlCommand(pricingQuery, connection))
                            {
                                pricingCommand.Parameters.AddWithValue("@PricingID", pricingID);
                                using (var pricingReader = pricingCommand.ExecuteReader())
                                {
                                    if (pricingReader.Read())
                                    {
                                        model.fld_Equipment_Price = Convert.ToDecimal(pricingReader["fld_Equipment_Price"]);
                                        model.fld_Equipment_Price_Subsequent = Convert.ToDecimal(pricingReader["fld_Equipment_Price_Subsequent"]);
                                        model.fld_Total_Equipment_Cost = model.fld_Equipment_Price * Convert.ToInt32(reader["fld_Quantity"]) * Convert.ToInt32(reader["fld_Number_Of_Days"]);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return model;
        }*/

        // Method to get equipment pricing by pricing ID
        /*public Model_Billing GetEquipmentPricingByPricingID(int pricingID)
        {
            var model = new Model_Billing();

            string query = "SELECT * FROM tbl_Equipment_Pricing WHERE pk_Equipment_PricingID = @PricingID";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PricingID", pricingID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.pk_Equipment_PricingID = Convert.ToInt32(reader["pk_Equipment_PricingID"]);
                            model.fld_Equipment_Price = Convert.ToDecimal(reader["fld_Equipment_Price"]);
                            model.fld_Equipment_Price_Subsequent = Convert.ToDecimal(reader["fld_Equipment_Price_Subsequent"]);
                        }
                    }
                }
            }

            return model;
        }*/


        public bool UpdateReservationTotalAmount(int reservationID)
        {
            try
            {
                // Calculate the total equipment cost for the given reservation
                decimal totalEquipmentCost = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
            SELECT SUM(fld_Total_Equipment_Cost) 
            FROM tbl_Reservation_Equipment 
            WHERE fk_ReservationID = @ReservationID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ReservationID", reservationID);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    totalEquipmentCost = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                }

                // Update the fld_Total_Amount in tbl_Reservation
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string updateQuery = @"
            UPDATE tbl_Reservation
            SET fld_Total_Amount = @TotalAmount
            WHERE pk_ReservationID = @ReservationID";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalEquipmentCost);
                    cmd.Parameters.AddWithValue("@ReservationID", reservationID);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
                return false;
            }
        }


        public bool DeleteEquipmentReservation(int reservationEquipmentID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Step 1: Get EquipmentID and Quantity
                    SqlCommand cmd = new SqlCommand(@"
                SELECT fk_EquipmentID, fld_Quantity 
                FROM tbl_Reservation_Equipment 
                WHERE pk_Reservation_EquipmentID = @ReservationEquipmentID", conn, transaction);

                    cmd.Parameters.AddWithValue("@ReservationEquipmentID", reservationEquipmentID);

                    int equipmentID = 0;
                    int quantityToReturn = 0;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        equipmentID = reader.GetInt32(0);
                        quantityToReturn = reader.GetInt32(1);
                    }
                    else
                    {
                        reader.Close();
                        transaction.Rollback();
                        return false;
                    }
                    reader.Close(); // ✅ close it before next command

                    // Step 2: Check current remaining and total stock
                    cmd = new SqlCommand(@"
                SELECT fld_Remaining_Stock, fld_Total_Stock 
                FROM tbl_Equipment 
                WHERE pk_EquipmentID = @EquipmentID", conn, transaction);

                    cmd.Parameters.AddWithValue("@EquipmentID", equipmentID);

                    int remainingStock = 0;
                    int totalStock = 0;

                    SqlDataReader reader2 = cmd.ExecuteReader();  // ⚠️ different name
                    if (reader2.Read())
                    {
                        remainingStock = reader2.IsDBNull(0) ? 0 : reader2.GetInt32(0);
                        totalStock = reader2.IsDBNull(1) ? 0 : reader2.GetInt32(1);
                    }
                    else
                    {
                        reader2.Close();
                        transaction.Rollback();
                        return false;
                    }
                    reader2.Close(); // ✅

                    // Step 3: Check if adding back the quantity would exceed total stock
                    if (remainingStock + quantityToReturn > totalStock)
                    {
                        transaction.Rollback();
                        throw new InvalidOperationException("❌ Adding back the equipment would exceed total stock. Check for stock consistency.");
                    }

                    // Step 4: Add back quantity to Remaining Stock
                    cmd = new SqlCommand(@"
                UPDATE tbl_Equipment 
                SET fld_Remaining_Stock = fld_Remaining_Stock + @Quantity 
                WHERE pk_EquipmentID = @EquipmentID", conn, transaction);

                    cmd.Parameters.AddWithValue("@Quantity", quantityToReturn);
                    cmd.Parameters.AddWithValue("@EquipmentID", equipmentID);
                    cmd.ExecuteNonQuery();

                    // Step 5: Delete the reservation
                    cmd = new SqlCommand(@"
                DELETE FROM tbl_Reservation_Equipment 
                WHERE pk_Reservation_EquipmentID = @ReservationEquipmentID", conn, transaction);

                    cmd.Parameters.AddWithValue("@ReservationEquipmentID", reservationEquipmentID);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }



        public bool DeductStockAfterReservation(int equipmentID, int quantityToDeduct)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check current stock
                string checkQuery = "SELECT fld_Remaining_Stock FROM tbl_Equipment WHERE pk_EquipmentID = @id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@id", equipmentID);
                int remainingStock = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (remainingStock < quantityToDeduct)
                    return false;

                // Deduct stock
                string updateQuery = "UPDATE tbl_Equipment SET fld_Remaining_Stock = fld_Remaining_Stock - @qty WHERE pk_EquipmentID = @id";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@qty", quantityToDeduct);
                updateCmd.Parameters.AddWithValue("@id", equipmentID);

                int rows = updateCmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public bool UpdateReservationORNumber(int reservationID, string orNumber)
        {
            // Basic validation for the input OR number (optional but recommended)
            if (string.IsNullOrWhiteSpace(orNumber))
            {
                // Decide how to handle invalid input - maybe return false or throw exception
                return false; // Can't update with an empty OR number
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    UPDATE tbl_Reservation
                    SET fld_OR = @ORNumber
                    WHERE pk_ReservationID = @ReservationID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@ORNumber", orNumber);
                        cmd.Parameters.AddWithValue("@ReservationID", reservationID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Return true if one row was updated, false otherwise
                        return rowsAffected == 1;
                    }
                }
                catch (SqlException ex)
                {
                    // Log the exception (using your preferred logging mechanism)
                    Console.WriteLine("SQL Error updating OR Number: " + ex.Message);
                    // Consider more specific error handling or logging here
                    return false; // Indicate failure
                }
                catch (Exception ex)
                {
                    // Log unexpected errors
                    Console.WriteLine("General Error updating OR Number: " + ex.Message);
                    return false; // Indicate failure
                }
            }
        }


        public bool CheckORExists(string orNumber)
        {
            // Trim the input OR number to avoid issues with leading/trailing spaces
            string trimmedOrNumber = orNumber?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(trimmedOrNumber))
            {
                return false; // Or throw an exception, as an empty OR shouldn't be checked? Depends on requirements.
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Query to count how many times this OR number appears.
                    // Replace [YourCorrectORColumnName] with the actual column name.
                    // Consider using UPPER() for case-insensitive comparison if needed:
                    // WHERE UPPER([YourCorrectORColumnName]) = UPPER(@ORNumber)
                    string query = $@"
                    SELECT COUNT(*)
                    FROM tbl_Reservation
                    WHERE fld_OR = @ORNumber";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Use parameter to prevent SQL injection
                        cmd.Parameters.AddWithValue("@ORNumber", trimmedOrNumber);

                        // ExecuteScalar returns the first column of the first row (our count)
                        object result = cmd.ExecuteScalar();

                        // Convert the result to an integer
                        int count = Convert.ToInt32(result);

                        // If count > 0, the OR number already exists
                        return count > 0;
                    }
                }
                catch (SqlException ex)
                {
                    // Log the error
                    Console.WriteLine("SQL Error checking OR Number existence: " + ex.Message);
                    // Decide how to handle DB errors during check. Returning false might be misleading.
                    // Throwing an exception might be better, or returning a nullable bool (true, false, null for error).
                    // For now, we'll return false to avoid blocking unnecessarily, but log the error.
                    return false; // Indicate check failed or doesn't exist (ambiguous on error)
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General Error checking OR Number existence: " + ex.Message);
                    return false;
                }
            }
        }


        /// END OF CHAT GPT CRUD
        /// 

        /// START OF GEMINI EDIT RESERVATION INFO

        // Method to get full details for one reservation
        public Model_Billing GetReservationDetails(int reservationID)
        {
            Model_Billing details = null;
            // SQL to select all necessary fields from tbl_Reservation JOINED with others if needed
            string sql = @"SELECT
                           pk_ReservationID, fk_VenueID, fk_Venue_ScopeID,
                           fld_Start_Date, fld_End_Date, fld_Start_Time, fld_End_Time,
                           fk_Venue_PricingID, fld_Reservation_Type -- Add other fields as needed
                       FROM tbl_Reservation
                       WHERE pk_ReservationID = @ReservationID";

            using (SqlConnection conn = new SqlConnection(connectionString)) 
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            details = new Model_Billing
                            {
                                pk_ReservationID = reader.GetInt32(reader.GetOrdinal("pk_ReservationID")),
                                fk_VenueID = reader.IsDBNull(reader.GetOrdinal("fk_VenueID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("fk_VenueID")),
                                fk_Venue_ScopeID = reader.IsDBNull(reader.GetOrdinal("fk_Venue_ScopeID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("fk_Venue_ScopeID")),
                                fld_Start_Date = reader.GetDateTime(reader.GetOrdinal("fld_Start_Date")),
                                fld_End_Date = reader.GetDateTime(reader.GetOrdinal("fld_End_Date")),
                                fld_Start_Time = reader.GetTimeSpan(reader.GetOrdinal("fld_Start_Time")),
                                fld_End_Time = reader.GetTimeSpan(reader.GetOrdinal("fld_End_Time")),
                                fk_Venue_PricingID = reader.IsDBNull(reader.GetOrdinal("fk_Venue_PricingID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("fk_Venue_PricingID")),
                                fld_Reservation_Type = reader.GetString(reader.GetOrdinal("fld_Reservation_Type"))
                                // Map other properties from Model_Billing if needed
                            };

                            // We need to infer Aircon status from fk_Venue_PricingID if not stored directly
                            // This requires another lookup or JOIN in the initial query
                            // For simplicity, let's assume we determine it later or add it to Model_Billing
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log error
                    Console.WriteLine("Error fetching reservation details: " + ex.Message);
                    throw; // Re-throw or handle as appropriate
                }
            }
            return details;
        }


        // Method to get Venue List (assuming it returns ID and Name)
        public List<KeyValuePair<int, string>> GetAllVenue()
        {
            var list = new List<KeyValuePair<int, string>>();
            string sql = "SELECT pk_VenueID, fld_Venue_Name FROM tbl_Venue ORDER BY fld_Venue_Name";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log error
                    Console.WriteLine("Error fetching venues: " + ex.Message);
                }
            }
            return list;
        }


       
        // Method to get Venue Scope List
        public List<KeyValuePair<int, string>> GetAllVenueScopes() // Add filtering by VenueID if needed
        {
            var list = new List<KeyValuePair<int, string>>();
            // Consider filtering by VenueID if scopes are venue-specific
            string sql = "SELECT pk_Venue_ScopeID, fld_Venue_Scope_Name FROM tbl_Venue_Scope ORDER BY fld_Venue_Scope_Name";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // If filtering: cmd.Parameters.AddWithValue("@VenueID", venueId);
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log error
                    Console.WriteLine("Error fetching venue scopes: " + ex.Message);
                }
            }
            return list;
        }
       

        // Method to get Pricing Details
        // Returning a simple class or tuple might be cleaner than object[]
        public class VenuePricingResult
        {
            public int PricingID { get; set; }
            public decimal First4HrsRate { get; set; }
            public decimal HourlyRate { get; set; }
            public bool Found { get; set; } = false; // Flag to indicate if found
        }

        public VenuePricingResult GetVenuePricingDetails(int venueId, int scopeId, bool aircon, string rateType)
        {
            VenuePricingResult result = new VenuePricingResult();
            string sql = @"
            SELECT pk_Venue_PricingID, fld_First4Hrs_Rate, fld_Hourly_Rate
            FROM tbl_Venue_Pricing
            WHERE fk_VenueID = @VenueID
              AND fk_Venue_ScopeID = @ScopeID
              AND fld_Aircon = @Aircon
              AND fld_Rate_Type = @RateType";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@VenueID", venueId);
                cmd.Parameters.AddWithValue("@ScopeID", scopeId);
                cmd.Parameters.AddWithValue("@Aircon", aircon);
                cmd.Parameters.AddWithValue("@RateType", rateType ?? (object)DBNull.Value); // Handle null rateType

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.PricingID = reader.GetInt32(reader.GetOrdinal("pk_Venue_PricingID"));
                            result.First4HrsRate = reader.GetDecimal(reader.GetOrdinal("fld_First4Hrs_Rate"));
                            result.HourlyRate = reader.GetDecimal(reader.GetOrdinal("fld_Hourly_Rate"));
                            result.Found = true;
                        }
                        // No else needed, Found defaults to false
                    }
                }
                catch (Exception ex)
                {
                    // Log error
                    Console.WriteLine("Error fetching pricing details: " + ex.Message);
                    throw; // Re-throw or handle
                }
            }
            return result;
        }

        // Method to get Aircon status based on PricingID (if needed)
        public bool? GetAirconStatusFromPricing(int? pricingId)
        {
            if (!pricingId.HasValue) return null;

            bool? airconStatus = null;
            string sql = "SELECT fld_Aircon FROM tbl_Venue_Pricing WHERE pk_Venue_PricingID = @PricingID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PricingID", pricingId.Value);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        airconStatus = Convert.ToBoolean(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching aircon status: " + ex.Message);
                    // Handle error appropriately
                }
            }
            return airconStatus;
        }

        // Method to update the reservation
        public bool UpdateVenueReservation(int reservationID, DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime, int venueId, int scopeId, int venuePricingId, decimal first4HrsRate, decimal hourlyRate)
        {
            string sql = @"
            UPDATE tbl_Reservation SET
                fld_Start_Date = @StartDate,
                fld_End_Date = @EndDate,
                fld_Start_Time = @StartTime,
                fld_End_Time = @EndTime,
                fk_VenueID = @VenueID,
                fk_Venue_ScopeID = @ScopeID,
                fk_Venue_PricingID = @VenuePricingID,
                fld_First4Hrs_Rate = @First4HrsRate,
                fld_Hourly_Rate = @HourlyRate
                -- Add fld_Total_Amount, fld_OT_Hours updates here if calculated
            WHERE pk_ReservationID = @ReservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
                cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = startTime;
                cmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = endTime;
                cmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = venueId;
                cmd.Parameters.Add("@ScopeID", SqlDbType.Int).Value = scopeId;
                cmd.Parameters.Add("@VenuePricingID", SqlDbType.Int).Value = venuePricingId;
                cmd.Parameters.Add("@First4HrsRate", SqlDbType.Decimal).Value = first4HrsRate;
                cmd.Parameters.Add("@HourlyRate", SqlDbType.Decimal).Value = hourlyRate;
                cmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;

                // Add parameters for TotalAmount, OTHours if needed

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if update was successful
                }
                catch (Exception ex)
                {
                    // Log error
                    Console.WriteLine("Error updating reservation: " + ex.Message);
                    return false; // Indicate failure
                }
            }
        }


        /// END OF GEMINI EDIT RESERVATION INFO


    }
}

