﻿using pgso.Billing.Models;
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

        private string connectionString = "Data Source=172.17.16.125;Initial Catalog=RBIS;User ID=RBIS;Password=Nvsuojt_2025;Encrypt=False;TrustServerCertificate=True";
        // private string connectionString = "Data Source=DESKTOP-DG6NT1C;Initial Catalog=gso;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

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
                                    r.fld_Created_At,
                                    p.fld_Amount_Due,
                                    p.fld_Amount_Paid,
                                    p.fld_Payment_Status,
                                    p.fld_Payment_Date,
                                    r.fld_OT_Hours,
                                    p.fld_Refund_Amount,
                                    p.fld_Cancellation_Fee,
                                    p.fld_Final_Amount_Paid, 
                                    p.fld_Overtime_Fee,
                                    
                                    re.fld_OT_Days,
                                    re.fld_Start_Date_Eq,                      
                                    re.fld_End_Date_Eq,
                                    re.fld_Equipment_Status,
                                    re.fld_Date_Returned,
                                    re.fld_Quantity_Returned,
                                    re.fld_Quantity_Damaged,
                                    p.fld_Amount_Paid_Overtime,
                                    r.fld_OT_Payment_Status,
                                    u.fld_Username,
                                    r.fld_Caterer_Fee,
                                    r.fld_Confirmation_Date

                                    FROM dbo.tbl_Reservation r
                                    LEFT JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                                    LEFT JOIN dbo.tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
                                    LEFT JOIN dbo.tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
                                    LEFT JOIN dbo.tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
                                    LEFT JOIN dbo.tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
                                    LEFT JOIN dbo.tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                                    LEFT JOIN dbo.tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
                                    LEFT JOIN dbo.tbl_Payment p ON r.pk_ReservationID = p.fk_ReservationID
                                    LEFT JOIN dbo.tbl_User u ON r.fk_UserID = u.pk_UserID
                                    ORDER BY r.pk_ReservationID DESC";


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int reservationId = reader.GetInt32(0);
                            string controlNumber = reader.GetString(1);

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
                                fld_Overtime_Fee = reader.IsDBNull(42) ? 0 : reader.GetDecimal(42),
                                fld_OT_Days = reader.IsDBNull(43) ? 0 : reader.GetInt32(43),
                                fld_Start_Date_Eq = reader.IsDBNull(44) ? DateTime.MinValue : reader.GetDateTime(44),
                                fld_End_Date_Eq = reader.IsDBNull(45) ? DateTime.MinValue : reader.GetDateTime(45),
                                fld_Equipment_Status = reader.IsDBNull(46) ? "" : reader.GetString(46),
                                fld_Date_Returned = reader.IsDBNull(47) ? DateTime.MinValue : reader.GetDateTime(47),
                                fld_Quantity_Returned = reader.IsDBNull(48) ? 0 : reader.GetInt32(48),
                                fld_Quantity_Damaged = reader.IsDBNull(49) ? 0 : reader.GetInt32(49),
                                fld_Amount_Paid_Overtime = reader.IsDBNull(50) ? 0 : reader.GetDecimal(50),
                                fld_OT_Payment_Status = reader.IsDBNull(51) ? "" : reader.GetString(51),
                                fld_Username = reader.IsDBNull(52) ? "" : reader.GetString(52),

                                // Caterer Fee
                                fld_Caterer_Fee = reader.IsDBNull(53) ? 0 : reader.GetDecimal(53),
                                // Confirmation Date
                                fld_Confirmation_Date = reader.IsDBNull(54) ? DateTime.MinValue : reader.GetDateTime(54)
                            };


                            billings.Add(billing);
                        }
                    }
                }

                Console.WriteLine(" Total Records Retrieved: " + billings.Count);
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
                    Console.WriteLine($" Fetching billing data for Reservation ID: {reservationId}");

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
                        r.fld_Created_At,
                        p.fld_Amount_Due,
                        p.fld_Amount_Paid,
                        p.fld_Payment_Status,
                        p.fld_Payment_Date,
                        r.fld_OT_Hours,
                        p.fld_Refund_Amount,        
                        p.fld_Cancellation_Fee,
                        p.fld_Final_Amount_Paid,
                        p.fld_Overtime_Fee,
                        re.fld_Start_Date_Eq,
                        re.fld_End_Date_Eq,
                        p.fld_Amount_Paid_Overtime,
                        r.fld_OT_Payment_Status,
                        r.fld_Cancellation_Reason,
                        u.fld_Username,
                        vp.fld_Additional_Charge,
                        r.fld_Caterer_Fee 
                        

                    FROM dbo.tbl_Reservation r
                    LEFT JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                    LEFT JOIN dbo.tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
                    LEFT JOIN dbo.tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
                    LEFT JOIN dbo.tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
                    LEFT JOIN dbo.tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
                    LEFT JOIN dbo.tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
                    LEFT JOIN dbo.tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
                    LEFT JOIN dbo.tbl_Payment p ON r.pk_ReservationID = p.fk_ReservationID
                    LEFT JOIN dbo.tbl_User u ON r.fk_UserID = u.pk_UserID
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
                                    fld_Overtime_Fee = reader.IsDBNull(42) ? 0 : reader.GetDecimal(42),
                                    fld_Start_Date_Eq = reader.IsDBNull(43) ? DateTime.MinValue : reader.GetDateTime(43),
                                    fld_End_Date_Eq = reader.IsDBNull(44) ? DateTime.MinValue : reader.GetDateTime(44),
                                    fld_Amount_Paid_Overtime = reader.IsDBNull(45) ? 0 : reader.GetDecimal(45),
                                    fld_OT_Payment_Status = reader.IsDBNull(46) ? "" : reader.GetString(46),
                                    fld_Cancellation_Reason = reader.IsDBNull(47) ? "" : reader.GetString(47),
                                    fld_Username = reader.IsDBNull(48) ? frm_login.username : reader.GetString(48),
                                    fld_Additional_Charge = reader.IsDBNull(49) ? 0 : reader.GetDecimal(49),
                                    fld_Caterer_Fee = reader.IsDBNull(50) ? 0 : reader.GetDecimal(50)

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
                    Console.WriteLine(" Fetching Revenue Data");

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
                            p.fld_Overtime_Fee,
                            r.fld_Caterer_Fee 

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
                        //  Add parameters
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
                                    fld_Overtime_Fee = reader.IsDBNull(46) ? 0 : reader.GetDecimal(46),
                                    fld_Caterer_Fee = reader.IsDBNull(50) ? 0 : reader.GetDecimal(50)

                                });
                            }
                        }
                    }
                }
                Console.WriteLine($" Total Revenue Records Retrieved: {revenueData.Count}");
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
                            p.fld_Overtime_Fee,
                            rp.fld_Requesting_Office,
                            r.fld_OR,
                            p.fld_Amount_Paid_Overtime,
                            r.fld_OT_Payment_Status,
                            r.fld_OR_Extension,
                            r.fld_Extension_Status,
                            r.fld_Caterer_Fee,
                            r.fld_Confirmation_Date,
                            re.fld_Quantity_Returned,
                            re.fld_Quantity_Damaged

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
                                    fld_Overtime_Fee = reader.IsDBNull(46) ? 0 : reader.GetDecimal(46),
                                    fld_Requesting_Office = reader.IsDBNull(47) ? "" : reader.GetString(47),
                                    fld_OR = reader.IsDBNull(48) ? 0 : reader.GetInt32(48),
                                    fld_Amount_Paid_Overtime = reader.IsDBNull(49) ? 0 : reader.GetDecimal(49),
                                    fld_OT_Payment_Status = reader.IsDBNull(50) ? "" : reader.GetString(50),
                                    fld_OR_Extension = reader.IsDBNull(51) ? 0 : reader.GetInt32(51),
                                    fld_Extension_Status = reader.IsDBNull(52) ? "" : reader.GetString(52),
                                    fld_Caterer_Fee = reader.IsDBNull(53) ? 0 : reader.GetDecimal(53),
                                    fld_Confirmation_Date = reader.IsDBNull(54) ? (DateTime?)null : reader.GetDateTime(54),
                                    fld_Quantity_Returned = reader.IsDBNull(55) ? 0 : reader.GetInt32(55),
                                    fld_Quantity_Damaged = reader.IsDBNull(56) ? 0 : reader.GetInt32(56)
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

        public async Task<bool> UpdateReservationStatusAsync(int reservationID, string newStatus)
        {
            if (newStatus != "Cancelled" && newStatus != "Confirmed" && newStatus != "Pending")
            {
                MessageBox.Show("Invalid status value. Only 'Cancelled', 'Confirmed', or 'Pending' are allowed.");
                return false;
            }

            string query = "UPDATE tbl_Reservation SET fld_Reservation_Status = @Status WHERE pk_ReservationID = @ReservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = newStatus;
                cmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;

                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();

                if (rowsAffected > 0 && newStatus == "Confirmed")
                {
                    // Fetch the total amount
                    string amountQuery = "SELECT fld_Total_Amount FROM tbl_Reservation WHERE pk_ReservationID = @ReservationID";
                    using (SqlCommand amountCmd = new SqlCommand(amountQuery, conn))
                    {
                        amountCmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;
                        object result = await amountCmd.ExecuteScalarAsync();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal totalAmount) && totalAmount > 0)
                        {
                            string paymentQuery = @"
                    INSERT INTO tbl_Payment (fk_ReservationID, fld_Payment_Status, fld_Amount_Due, fld_Amount_Paid, fld_Payment_Date, fld_Created_At, fld_Final_Amount_Paid)
                    VALUES (@ReservationID, 'Confirmed', @AmountDue, @AmountPaid, @PaymentDate, @CreatedAt, @FinalAmountPaid)";

                            using (SqlCommand paymentCmd = new SqlCommand(paymentQuery, conn))
                            {
                                paymentCmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;
                                paymentCmd.Parameters.Add("@AmountDue", SqlDbType.Decimal).Value = totalAmount;
                                paymentCmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = totalAmount;
                                paymentCmd.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = DateTime.Today;
                                paymentCmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = DateTime.Now;
                                paymentCmd.Parameters.Add("@FinalAmountPaid", SqlDbType.Decimal).Value = totalAmount;

                                await paymentCmd.ExecuteNonQueryAsync();
                            }
                        }
                    }
                }

                return rowsAffected > 0;
            }
        }


        public bool SaveCancellationReason(int reservationID, string reason)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE tbl_Reservation SET fld_Cancellation_Reason = @reason WHERE pk_ReservationID = @reservationID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reason", reason);
                    cmd.Parameters.AddWithValue("@reservationID", reservationID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
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
            p.fld_Refund_Amount = r.fld_Total_Amount ,
            p.fld_Cancellation_Fee = r.fld_Total_Amount * 0,
            p.fld_Final_Amount_Paid = r.fld_Total_Amount * 0
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
        public async Task<bool> UpdateReservationExtension(int reservationID, int otHours, int orExtension)
        {
            try
            {
                bool otUpdateSuccess = await HandleOvertimeExtension(reservationID, otHours);
                if (!otUpdateSuccess) return false;

                bool orUpdateSuccess = await HandleORExtension(reservationID, orExtension);
                return orUpdateSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error updating reservation {reservationID}: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> HandleOvertimeExtension(int reservationID, int otHours)
        {
            try
            {
                string checkQuery = "SELECT fld_OT_Hours FROM tbl_Reservation WHERE pk_ReservationID = @reservationID";
                int existingOT = 0;

                using (SqlConnection checkConn = new SqlConnection(connectionString))
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, checkConn))
                {
                    checkCmd.Parameters.AddWithValue("@reservationID", reservationID);
                    await checkConn.OpenAsync();
                    object result = await checkCmd.ExecuteScalarAsync();
                    existingOT = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }

                if (existingOT > 0 && otHours != existingOT)
                {
                    MessageBox.Show("Overtime Hours Already Exist in the Database", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                decimal hourlyRate = await GetHourlyRate(reservationID);
                decimal baseAmount = await GetBaseAmount(reservationID);

                decimal newOvertimeFee = otHours * hourlyRate;
                decimal newFinalAmountPaid = baseAmount + newOvertimeFee;
                decimal newTotalAmount = baseAmount + newOvertimeFee;

                string query = @"
            UPDATE p
            SET
                p.fld_Final_Amount_Paid = @newFinalAmountPaid,
                p.fld_Overtime_Fee = @newOvertimeFee
            FROM tbl_Payment p
            JOIN tbl_Reservation r ON r.pk_ReservationID = p.fk_ReservationID
            WHERE r.pk_ReservationID = @reservationID;

            UPDATE tbl_Reservation
            SET
                fld_Total_Amount = @totalAmount,
                fld_OT_Hours = @otHours
            WHERE pk_ReservationID = @reservationID;
        ";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@newFinalAmountPaid", newFinalAmountPaid);
                    cmd.Parameters.AddWithValue("@newOvertimeFee", newOvertimeFee);
                    cmd.Parameters.AddWithValue("@totalAmount", newTotalAmount);
                    cmd.Parameters.AddWithValue("@otHours", otHours);
                    cmd.Parameters.AddWithValue("@reservationID", reservationID);

                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OT Update Error: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> HandleORExtension(int reservationID, int orExtension)
        {
            if (orExtension <= 0) return true; // Nothing to update

            try
            {
                string query = @"
        -- Update Amount Paid for Overtime
        UPDATE p
        SET p.fld_Amount_Paid_Overtime = (
            SELECT fld_Overtime_Fee
            FROM tbl_Payment p2
            JOIN tbl_Reservation r2 ON r2.pk_ReservationID = p2.fk_ReservationID
            WHERE r2.pk_ReservationID = @reservationID
        )
        FROM tbl_Payment p
        JOIN tbl_Reservation r ON r.pk_ReservationID = p.fk_ReservationID
        WHERE r.pk_ReservationID = @reservationID;

        -- Update OR Extension
        UPDATE tbl_Reservation
        SET fld_OR_Extension = @orExtension
        WHERE pk_ReservationID = @reservationID;

        -- Only update fld_Extension_Status to 'Confirmed' if fld_Overtime_Fee is not null and greater than 0
        UPDATE tbl_Reservation
        SET fld_Extension_Status = 'Confirmed'
        WHERE pk_ReservationID = @reservationID
        AND EXISTS (
            SELECT 1
            FROM tbl_Payment p
            WHERE p.fk_ReservationID = @reservationID
            AND p.fld_Overtime_Fee IS NOT NULL
            AND p.fld_Overtime_Fee > 0
        );
        ";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationID", reservationID);
                    cmd.Parameters.AddWithValue("@orExtension", orExtension);

                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OR Update Error: {ex.Message}");
                return false;
            }
        }





        public async Task<decimal> GetBaseAmount(int reservationID)
        {
            var query = @"
        SELECT r.fld_Total_Amount, p.fld_Overtime_Fee
        FROM tbl_Reservation r
        JOIN tbl_Payment p ON p.fk_ReservationID = r.pk_ReservationID
        WHERE r.pk_ReservationID = @reservationID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        decimal totalAmount = reader["fld_Total_Amount"] != DBNull.Value ? Convert.ToDecimal(reader["fld_Total_Amount"]) : 0m;
                        decimal overtimeFee = reader["fld_Overtime_Fee"] != DBNull.Value ? Convert.ToDecimal(reader["fld_Overtime_Fee"]) : 0m;

                        return totalAmount - overtimeFee;
                    }
                }
            }

            return 0m;
        }



        public async Task<Model_Billing> GetCurrentExtensionDetails(int reservationID)
        {
            var query = @"
        SELECT fld_OR_Extension, fld_OT_Hours
        FROM tbl_Reservation
        WHERE pk_ReservationID = @reservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Model_Billing
                        {
                            fld_OR_Extension = reader["fld_OR_Extension"] != DBNull.Value ? Convert.ToInt32(reader["fld_OR_Extension"]) : 0,
                            fld_OT_Hours = reader["fld_OT_Hours"] != DBNull.Value ? Convert.ToInt32(reader["fld_OT_Hours"]) : 0
                        };
                    }
                }
            }

            return null;
        }




        public async Task<bool> CheckIfAlreadyExtended(int reservationID)
        {
            string query = @"SELECT fld_OT_Hours, fld_OR_Extension 
                     FROM tbl_Reservation 
                     WHERE pk_ReservationID = @reservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                await conn.OpenAsync();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        decimal otHours = reader["fld_OT_Hours"] != DBNull.Value ? Convert.ToDecimal(reader["fld_OT_Hours"]) : 0;
                        string orExtension = reader["fld_OR_Extension"] != DBNull.Value ? reader["fld_OR_Extension"].ToString() : null;
                        return otHours > 0 || !string.IsNullOrEmpty(orExtension);
                    }
                }
            }
            return false;
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
                //Delete this after testing
                Console.WriteLine("GetHourlyRate: " + result);
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
            re.fld_Quantity_Returned,
            re.fld_Quantity_Damaged,
            r.fld_OR

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
                                    fld_Quantity_Returned = reader.IsDBNull(41) ? 0 : reader.GetInt32(41),
                                    fld_Quantity_Damaged = reader.IsDBNull(42) ? 0 : reader.GetInt32(42),
                                    fld_OR = reader.IsDBNull(43) ? 0 : reader.GetInt32(43)
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

        // Returning equipment (damaged or not)
        public async Task<bool> UpdateEquipmentReturnAsync(int? reservationEquipmentID, int returnNow, int damaged)
        {
            if (reservationEquipmentID == null)
                return false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"
                        -- Step 1: Update tbl_Reservation_Equipment
                        UPDATE tbl_Reservation_Equipment
                        SET 
                            fld_Quantity_Returned = ISNULL(fld_Quantity_Returned, 0) + @ReturnNow,
                            fld_Quantity_Damaged = ISNULL(fld_Quantity_Damaged, 0) + @Damaged,
                            fld_Date_Returned = GETDATE(),
                            fld_Equipment_Status = 
                                CASE 
                                    WHEN (ISNULL(fld_Quantity_Returned, 0) + @ReturnNow + ISNULL(fld_Quantity_Damaged, 0) + @Damaged) >= fld_Quantity THEN
                                        CASE 
                                            WHEN (ISNULL(fld_Quantity_Damaged, 0) + @Damaged) >= fld_Quantity THEN 'ALL Damaged'
                                            WHEN (ISNULL(fld_Quantity_Damaged, 0) + @Damaged) > 0 THEN 'Partially Damaged'
                                            ELSE 'Returned'
                                        END
                                    ELSE 
                                        CASE 
                                            WHEN (ISNULL(fld_Quantity_Damaged, 0) + @Damaged) > 0 THEN 'Partially Damaged'
                                            ELSE 'Partially Returned'
                                        END
                                END
                        WHERE pk_Reservation_EquipmentID = @ReservationEquipmentID;

                        UPDATE E
                        SET 
                            E.fld_Remaining_Stock = ISNULL(E.fld_Remaining_Stock, 0) + @ReturnNow,
                            E.fld_Total_Stock = ISNULL(E.fld_Total_Stock, 0) - @Damaged
                        FROM tbl_Equipment E
                        INNER JOIN tbl_Reservation_Equipment RE ON RE.fk_EquipmentID = E.pk_EquipmentID
                        WHERE RE.pk_Reservation_EquipmentID = @ReservationEquipmentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReturnNow", returnNow);
                    cmd.Parameters.AddWithValue("@Damaged", damaged);
                    cmd.Parameters.AddWithValue("@ReservationEquipmentID", reservationEquipmentID.Value);

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }




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
                    } //  reader is closed here
                }
            }

            return equipmentList;
        }

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
                    } //  reader is closed here
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


        // Does not Delete from tbl_Reservation ( Only in tbl_Reservation_Equipment )
        // Error : When deleting all data from tbl_Reservation_Equipment, the dashboard gives an error:
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
                    reader.Close(); //  close it before next command

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
                    reader2.Close(); // 

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
                        if (string.IsNullOrWhiteSpace(orNumber))
                        {
                            // If orNumber is empty, default to "00000"
                            cmd.Parameters.AddWithValue("@ORNumber", "00000"); // CHANGED FROM "PLGU"
                        }
                        else
                        {
                            // Otherwise, use the provided orNumber (which would be "00000" in the PGNV case from btn_OR_Confirm_Click)
                            cmd.Parameters.AddWithValue("@ORNumber", orNumber);
                        }

                        cmd.Parameters.AddWithValue("@ReservationID", reservationID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        // Consider logging here for debugging:
                        // Console.WriteLine($"UpdateReservationORNumber: ID={reservationID}, OR='{cmd.Parameters["@ORNumber"].Value}', RowsAffected={rowsAffected}");
                        return rowsAffected == 1;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error updating OR Number: " + ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General Error updating OR Number: " + ex.Message);
                    return false;
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
            public decimal? AdditionalCharge { get; set; }  // ⬅️ This is the new line
            public bool Found { get; set; } = false; // Flag to indicate if found
        }

        public VenuePricingResult GetVenuePricingDetails(int venueId, int scopeId, bool aircon, string rateType)
        {
            VenuePricingResult result = new VenuePricingResult();
            string sql = @"
    SELECT pk_Venue_PricingID, fld_First4Hrs_Rate, fld_Hourly_Rate, fld_Additional_Charge
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
                cmd.Parameters.AddWithValue("@RateType", rateType ?? (object)DBNull.Value);

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
                            result.AdditionalCharge = reader.IsDBNull(reader.GetOrdinal("fld_Additional_Charge"))
                                ? (decimal?)null
                                : reader.GetDecimal(reader.GetOrdinal("fld_Additional_Charge"));
                            result.Found = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching pricing details: " + ex.Message);
                    throw;
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
        public bool UpdateVenueReservation(
    int reservationID,
    DateTime startDate,
    DateTime endDate,
    TimeSpan startTime,
    TimeSpan endTime,
    int venueId,
    int scopeId,
    int venuePricingId,
    decimal first4HrsRate,
    decimal hourlyRate,
    decimal? cateringFee,
    decimal totalAmount)
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
        fld_Hourly_Rate = @HourlyRate,
        fld_Caterer_Fee = @CateringFee,
        fld_Total_Amount = @TotalAmount
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
                cmd.Parameters.Add("@CateringFee", SqlDbType.Decimal).Value = (object)cateringFee ?? DBNull.Value;
                cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = totalAmount;
                cmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating reservation: " + ex.Message);
                    return false;
                }
            }
        }


        // Modify to accept optional venueId
        public List<KeyValuePair<int, string>> GetAllVenueScopes(int? venueId = null)
        {
            var list = new List<KeyValuePair<int, string>>();
            // Base SQL query - select scopes linked to venue pricing entries
            // DISTINCT ensures we only get each scope once per venue
            string sql = @"SELECT DISTINCT vs.pk_Venue_ScopeID, vs.fld_Venue_Scope_Name
                   FROM tbl_Venue_Scope vs
                   INNER JOIN tbl_Venue_Pricing vp ON vs.pk_Venue_ScopeID = vp.fk_Venue_ScopeID";

            // Add WHERE clause if venueId is provided
            if (venueId.HasValue)
            {
                sql += " WHERE vp.fk_VenueID = @VenueID";
            }
            sql += " ORDER BY vs.fld_Venue_Scope_Name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (venueId.HasValue)
                {
                    cmd.Parameters.AddWithValue("@VenueID", venueId.Value);
                }
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
                    Console.WriteLine("Error fetching venue scopes: " + ex.Message); // Log error
                }
            }
            return list;
        }

        // Helper method for clarity
        public List<KeyValuePair<int, string>> GetScopesForVenue(int venueId)
        {
            return GetAllVenueScopes(venueId);
        }

        public bool GetAirconUsage(int venueId, int scopeId)
        {
            bool isAirconUsed = false;

            using (SqlConnection conn = new SqlConnection(connectionString)) // Replace with your actual connection string variable
            {
                string query = @"
            SELECT TOP 1 fld_Aircon
            FROM tbl_Venue_Pricing
            WHERE fk_VenueID = @VenueID AND fk_Venue_ScopeID = @ScopeID
            ORDER BY fld_Aircon DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VenueID", venueId);
                    cmd.Parameters.AddWithValue("@ScopeID", scopeId);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        isAirconUsed = Convert.ToBoolean(result);
                    }
                }
            }

            return isAirconUsed;
        }

        public bool GetAirconUsageForReservation(int reservationId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT vp.fld_Aircon
            FROM tbl_Reservation r
            JOIN tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
            WHERE r.pk_ReservationID = @ReservationID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value && Convert.ToBoolean(result);
                }
            }
        }

        public bool CheckAirconAvailability(int venueId, int scopeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(*)
            FROM tbl_Venue_Pricing
            WHERE fk_VenueID = @VenueID AND fk_Venue_ScopeID = @ScopeID AND fld_Aircon = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VenueID", venueId);
                    cmd.Parameters.AddWithValue("@ScopeID", scopeId);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        // Method to check if Aircon option exists for a Venue/Scope
        public bool CheckAirconAvailability(int venueId, int? scopeId)
        {
            // Only check if scopeId is provided, otherwise, it's too broad
            if (!scopeId.HasValue)
            {
                return false; // Or query if *any* scope for the venue has AC? Let's require scope.
            }

            bool hasAirconOption = false;
            // Check if any pricing entry exists with Aircon=1 for this venue/scope
            string sql = @"SELECT TOP 1 1
                   FROM tbl_Venue_Pricing
                   WHERE fk_VenueID = @VenueID
                     AND fk_Venue_ScopeID = @ScopeID
                     AND fld_Aircon = 1"; // Check for entries where Aircon is explicitly TRUE

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@VenueID", venueId);
                cmd.Parameters.AddWithValue("@ScopeID", scopeId.Value); // Scope must have value here

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    // If ExecuteScalar returns anything (even 1), it means a record was found
                    if (result != null && result != DBNull.Value)
                    {
                        hasAirconOption = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking aircon availability: " + ex.Message); // Log error
                }
            }
            return hasAirconOption;
        }

        // *** IMPORTANT ***
        // Method to determine the ACTUAL Rate Type ('Regular', 'Special', 'PGNV')
        // This logic depends HEAVILY on your business rules.
        // Does it come from the Requesting Person type? Original booking flags?
        // This is a placeholder - IMPLEMENT YOUR ACTUAL LOGIC HERE.
        public string GetIntendedRateTypeForReservation(int reservationId)
        {
            // --- Placeholder Logic ---
            // Example: Fetch Requesting Person details linked to reservation, check their type
            // Example: Check a flag on the original reservation record
            // For now, just returning the stored one from original load for consistency
            // BUT THIS MIGHT NOT BE CORRECT IF RATE TYPE CAN CHANGE OR IS CONTEXTUAL
            Model_Billing details = GetReservationDetails(reservationId); // Reuse existing method
            if (details != null && !string.IsNullOrEmpty(details.fld_Rate_Type)) // Assuming you add this property
            {
                return details.fld_Rate_Type;
            }

            // Fallback - THIS IS LIKELY WRONG, fix the logic above
            return "Regular";
            // --- End Placeholder ---
        }


        // Modify UpdateVenueReservation to accept totalAmount and update the field
        // frm_Edit_Reservation_Info.cs
        public bool UpdateVenueReservation
        (
            int reservationID,
            DateTime startDate,
            DateTime endDate,
            TimeSpan startTime,
            TimeSpan endTime,
            int venueId,
            int scopeId,
            int venuePricingId,
            decimal first4HrsRate,
            decimal hourlyRate,
            decimal totalAmount // base amount before additional charge
        )
        {
            decimal additionalCharge = 0;

            // Step 1: Fetch fld_Additional_Charge from tbl_Venue_Pricing
            string getChargeSql = "SELECT fld_Additional_Charge FROM tbl_Venue_Pricing WHERE pk_Venue_PricingID = @PricingID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand getChargeCmd = new SqlCommand(getChargeSql, conn))
                {
                    getChargeCmd.Parameters.Add("@PricingID", SqlDbType.Int).Value = venuePricingId;
                    conn.Open();
                    object result = getChargeCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        additionalCharge = Convert.ToDecimal(result);
                    }
                    conn.Close();
                }

                // Add the additional charge to the total amount
                totalAmount += additionalCharge;

                // Step 2: Update the reservation with new total
                string updateSql = @"
                                                UPDATE tbl_Reservation SET
                                                    fld_Start_Date = @StartDate,
                                                    fld_End_Date = @EndDate,
                                                    fld_Start_Time = @StartTime,
                                                    fld_End_Time = @EndTime,
                                                    fk_VenueID = @VenueID,
                                                    fk_Venue_ScopeID = @ScopeID,
                                                    fk_Venue_PricingID = @VenuePricingID,
                                                    fld_First4Hrs_Rate = @First4HrsRate,
                                                    fld_Hourly_Rate = @HourlyRate,
                                                    fld_Total_Amount = @TotalAmount
                                                WHERE pk_ReservationID = @ReservationID";

                using (SqlCommand updateCmd = new SqlCommand(updateSql, conn))
                {
                    updateCmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                    updateCmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
                    updateCmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = startTime;
                    updateCmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = endTime;
                    updateCmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = venueId;
                    updateCmd.Parameters.Add("@ScopeID", SqlDbType.Int).Value = scopeId;
                    updateCmd.Parameters.Add("@VenuePricingID", SqlDbType.Int).Value = venuePricingId;
                    updateCmd.Parameters.Add("@First4HrsRate", SqlDbType.Decimal).Value = first4HrsRate;
                    updateCmd.Parameters.Add("@HourlyRate", SqlDbType.Decimal).Value = hourlyRate;
                    updateCmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = totalAmount;
                    updateCmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = reservationID;

                    try
                    {
                        conn.Open();
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error updating reservation: " + ex.Message);
                        return false;
                    }
                }
            }
        }


        // Make sure your GetReservationDetails fetches the fld_Rate_Type from tbl_Venue_Pricing
        // You might need to JOIN tbl_Venue_Pricing in GetReservationDetails
        public Model_Billing GetReservationDetails(int reservationID)
        {
            Model_Billing details = null;
            // JOIN with tbl_Venue_Pricing to get the RateType
            string sql = @"SELECT
                       r.pk_ReservationID, r.fk_VenueID, r.fk_Venue_ScopeID,
                       r.fld_Start_Date, r.fld_End_Date, r.fld_Start_Time, r.fld_End_Time,
                       r.fk_Venue_PricingID, r.fld_Reservation_Type, r.fld_Caterer_Fee,
                       vp.fld_Rate_Type, -- Fetch Rate Type from Pricing Table
                       r.fld_Reservation_Status
                   FROM tbl_Reservation r
                   LEFT JOIN tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID -- Use LEFT JOIN in case pricing ID is null
                   WHERE r.pk_ReservationID = @ReservationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ReservationID", reservationID);

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
                                fld_Reservation_Type = reader.GetString(reader.GetOrdinal("fld_Reservation_Type")),
                                fld_Rate_Type = reader.IsDBNull(reader.GetOrdinal("fld_Rate_Type")) ? null : reader.GetString(reader.GetOrdinal("fld_Rate_Type")),
                                fld_Reservation_Status = reader.IsDBNull(reader.GetOrdinal("fld_Reservation_Status")) ? null : reader.GetString(reader.GetOrdinal("fld_Reservation_Status")),
                                fld_Caterer_Fee = reader.IsDBNull(reader.GetOrdinal("fld_Caterer_Fee"))? 0m: reader.GetDecimal(reader.GetOrdinal("fld_Caterer_Fee"))


                            };
                        }
                    }
            }
            return details;
        }

        public bool IsVenueReservedOnDate(int venueId, DateTime date, int? excludeReservationId = null)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM tbl_Reservation
        WHERE fk_VenueID = @VenueId
          AND CAST(fld_Start_Date AS DATE) = @DateOnly
          " + (excludeReservationId.HasValue ? "AND pk_ReservationID != @ReservationId" : "") + ";";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@VenueId", venueId);
                cmd.Parameters.AddWithValue("@DateOnly", date.Date); // Strip time component

                if (excludeReservationId.HasValue)
                    cmd.Parameters.AddWithValue("@ReservationId", excludeReservationId.Value);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // true = conflict
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error checking reservation conflict: {ex.Message}");
                    throw new Exception("Database error during venue conflict check.", ex);
                }
            }
        }

        // FOR PGNV or any rate type that skips OR number 
        public string GetRateTypeForReservation(int reservationId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
            SELECT vp.fld_Rate_Type
            FROM tbl_Reservation r
            INNER JOIN tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
            WHERE r.pk_ReservationID = @ReservationId", conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString(); // Return null if not found
                }
            }
        }


    public Model_Billing GetEquipmentReservationByID(int reservationEquipmentID)
        {
            Model_Billing result = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
            SELECT 
                re.pk_Reservation_EquipmentID,
                re.fk_ReservationID,
                re.fk_EquipmentID,
                re.fk_Equipment_PricingID,
                re.fld_Quantity,
                re.fld_Number_Of_Days,
                re.fld_Total_Equipment_Cost,
                re.fld_Start_Date_Eq,
                re.fld_End_Date_Eq,
                eq.fld_Equipment_Name
            FROM tbl_Reservation_Equipment re
            INNER JOIN tbl_Equipment eq ON eq.pk_EquipmentID = re.fk_EquipmentID
            WHERE re.pk_Reservation_EquipmentID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", reservationEquipmentID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = new Model_Billing
                            {
                                pk_Reservation_EquipmentID = reader.GetInt32(reader.GetOrdinal("pk_Reservation_EquipmentID")),
                                fk_EquipmentID = reader.GetInt32(reader.GetOrdinal("fk_EquipmentID")),
                                fk_Equipment_PricingID = reader.GetInt32(reader.GetOrdinal("fk_Equipment_PricingID")),
                                fld_Quantity = reader.GetInt32(reader.GetOrdinal("fld_Quantity")),
                                fld_Number_Of_Days = reader.GetInt32(reader.GetOrdinal("fld_Number_Of_Days")),
                                fld_Total_Equipment_Cost = reader.GetDecimal(reader.GetOrdinal("fld_Total_Equipment_Cost")),
                                fld_Start_Date_Eq = reader.GetDateTime(reader.GetOrdinal("fld_Start_Date_Eq")),
                                fld_End_Date_Eq = reader.GetDateTime(reader.GetOrdinal("fld_End_Date_Eq")),
                                fld_Equipment_Name = reader.GetString(reader.GetOrdinal("fld_Equipment_Name"))
                            };
                        }
                    }
                }
            }

            return result;
        }

        public bool UpdateEditEquipmentReservation(
    int pk_Reservation_EquipmentID,
    int fk_EquipmentID,
    int fk_Equipment_PricingID,
    int fld_Quantity,
    int fld_Number_Of_Days,
    decimal fld_Total_Equipment_Cost,
    DateTime fld_Start_Date_Eq,
    DateTime fld_End_Date_Eq)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
            UPDATE tbl_Reservation_Equipment
            SET 
                fk_EquipmentID = @fk_EquipmentID,
                fk_Equipment_PricingID = @fk_Equipment_PricingID,
                fld_Quantity = @fld_Quantity,
                fld_Number_Of_Days = @fld_Number_Of_Days,
                fld_Total_Equipment_Cost = @fld_Total_Equipment_Cost,
                fld_Start_Date_Eq = @fld_Start_Date_Eq,
                fld_End_Date_Eq = @fld_End_Date_Eq
            WHERE pk_Reservation_EquipmentID = @pk_Reservation_EquipmentID", conn))
                {
                    cmd.Parameters.AddWithValue("@fk_EquipmentID", fk_EquipmentID);
                    cmd.Parameters.AddWithValue("@fk_Equipment_PricingID", fk_Equipment_PricingID);
                    cmd.Parameters.AddWithValue("@fld_Quantity", fld_Quantity);
                    cmd.Parameters.AddWithValue("@fld_Number_Of_Days", fld_Number_Of_Days);
                    cmd.Parameters.AddWithValue("@fld_Total_Equipment_Cost", fld_Total_Equipment_Cost);
                    cmd.Parameters.AddWithValue("@fld_Start_Date_Eq", fld_Start_Date_Eq);
                    cmd.Parameters.AddWithValue("@fld_End_Date_Eq", fld_End_Date_Eq);
                    cmd.Parameters.AddWithValue("@pk_Reservation_EquipmentID", pk_Reservation_EquipmentID);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public int GetReservationIDFromEquipmentReservation(int pk_Reservation_EquipmentID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
            SELECT fk_ReservationID
            FROM tbl_Reservation_Equipment
            WHERE pk_Reservation_EquipmentID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", pk_Reservation_EquipmentID);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // Method to get all equipment for a reservation for edit equipment reservation form

        public List<Model_Billing> GetAllEquipmentInventory()
        {
            List<Model_Billing> equipmentList = new List<Model_Billing>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT pk_EquipmentID, fld_Equipment_Name, fld_Total_Stock, fld_Remaining_Stock FROM tbl_Equipment ORDER BY pk_EquipmentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        equipmentList.Add(new Model_Billing
                        {
                            pk_EquipmentID = reader.GetInt32(0),
                            fld_Equipment_Name = reader.GetString(1),
                            fld_Total_Stock = reader.GetInt32(2),
                            fld_Remaining_Stock = reader.GetInt32(3)
                        });
                    }
                }
            }

            return equipmentList;
        }

        // Method to check if all equipment is returned
        public bool IsAllEquipmentReturnedOrDamaged(int reservationID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(*)
            FROM tbl_Reservation_Equipment
            WHERE fk_ReservationID = @ReservationID
              AND (ISNULL(fld_Quantity_Returned, 0) + ISNULL(fld_Quantity_Damaged, 0)) < fld_Quantity";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                    conn.Open();
                    int notFullyReturned = (int)cmd.ExecuteScalar();
                    return notFullyReturned == 0; //  true = all returned or damaged
                }
            }
        }

        // Method to set DateTimeNow for fld_Confirmation_Date
        public bool UpdateConfirmationDate(int reservationId, DateTime confirmationDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE tbl_Reservation SET fld_Confirmation_Date = @ConfirmationDate WHERE pk_ReservationID = @ReservationID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ConfirmationDate", confirmationDate.Date);
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Venue Completed Reservation Method
        public bool MarkReservationAsCompleted(int reservationId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            UPDATE tbl_Reservation
            SET fld_Reservation_Status = 'Completed'
            WHERE pk_ReservationID = @ReservationID
              AND fld_Reservation_Status NOT IN ('Completed', 'Cancelled')";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool AreAllEquipmentReturnedOrDamaged(int reservationId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) // connectionString is defined here
            {
                conn.Open();
                string checkQuery = @"
            SELECT fld_Quantity, fld_Quantity_Returned, fld_Quantity_Damaged
            FROM tbl_Reservation_Equipment
            WHERE fk_ReservationID = @ReservationID";

                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int qty = Convert.ToInt32(reader["fld_Quantity"]);
                            int returned = Convert.ToInt32(reader["fld_Quantity_Returned"]);
                            int damaged = Convert.ToInt32(reader["fld_Quantity_Damaged"]);
                            int remaining = qty - (returned + damaged);

                            if (remaining != 0)
                                return false;
                        }
                    }
                }
            }
            return true;
        }

    }
}


