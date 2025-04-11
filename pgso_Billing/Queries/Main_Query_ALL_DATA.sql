SELECT 
    -- Requesting Person Details
    r.pk_ReservationID,
    re.pk_Reservation_EquipmentID,
        r.fld_Total_Amount,
        re.fld_Total_Equipment_Cost,
    r.fld_Control_Number,
    r.fld_Reservation_Status,
    p.fld_Payment_Status,
    r.fld_Reservation_Type,
    rp.pk_Requesting_PersonID,

    p.fld_Amount_Paid,
    p.fld_Final_Amount_Paid,
    r.fld_OT_Hours,
    p.fld_Overtime_Fee,
    p.fld_Refund_Amount,
    p.fld_Cancellation_Fee,
    vp.fld_Hourly_Rate,
    vp.fld_First4Hrs_Rate,
    rp.fld_Surname,
    rp.fld_First_Name,
    rp.fld_Middle_Name,
    rp.fld_Requesting_Person_Address,
    rp.fld_Contact_Number,

    
    -- Reservation Details



    r.fld_Start_Date,
    r.fld_End_Date,
    r.fld_Start_Time,
    r.fld_End_Time,
    r.fld_Activity_Name,
    r.fld_Number_Of_Participants,

    
    
    
    -- Venue Details (if applicable)
    v.pk_VenueID,
    v.fld_Venue_Name,
    vs.pk_Venue_ScopeID,
    vs.fld_Venue_Scope_Name,
    
    -- Venue Pricing (if applicable)
    vp.pk_Venue_PricingID,
    
    

    -- Reserved Equipment Details (if applicable)
    re.fk_EquipmentID,
    e.fld_Equipment_Name,
    re.fk_Equipment_PricingID,
    ep.fld_Equipment_Price,
    ep.fld_Equipment_Price_Subsequent,
    re.fld_Quantity,
    re.fld_Number_Of_Days,


    -- Payment Details
    p.pk_PaymentID,
    p.fld_Created_At,
    p.fld_Amount_Due,
    p.fld_Amount_Paid,
    p.fld_Payment_Status,
    p.fld_Payment_Date

FROM dbo.tbl_Reservation r
-- Join Requesting Person
LEFT JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID

-- Join Venue and Venue Pricing (if applicable)
LEFT JOIN dbo.tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
LEFT JOIN dbo.tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
LEFT JOIN dbo.tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID

-- Join Reservation Equipment (if applicable)
LEFT JOIN dbo.tbl_Reservation_Equipment re ON r.pk_ReservationID = re.fk_ReservationID
LEFT JOIN dbo.tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
LEFT JOIN dbo.tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID

-- Join Payment Information
LEFT JOIN dbo.tbl_Payment p ON r.pk_ReservationID = p.fk_ReservationID;

