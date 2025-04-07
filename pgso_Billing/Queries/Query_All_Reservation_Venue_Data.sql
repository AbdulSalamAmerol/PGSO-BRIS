SELECT 
    rp.pk_Requesting_PersonID, 
    rp.fld_Surname, 
    rp.fld_First_Name, 
    rp.fld_Middle_Name, 
    rp.fld_Requesting_Person_Address, 
    rp.fld_Contact_Number, 
    rp.fld_Request_Origin,

    r.pk_ReservationID, 
    r.fk_Requesting_PersonID, 
    r.fk_VenueID, 
    v.fld_Venue_Name,  
    r.fk_Venue_PricingID, 
    vp.fld_First4Hrs_Rate,  
    vp.fld_Hourly_Rate,  
    vp.fld_Additional_Charge,
    r.fk_Venue_ScopeID, 
    vs.fld_Venue_Scope_Name,  
    r.fk_UserID, 
    r.fld_Control_Number, 
    r.fld_Reservation_Type, 
    r.fld_Start_Date, 
    r.fld_End_Date, 
    r.fld_Start_Time, 
    r.fld_End_Time, 
    r.fld_Activity_Name, 
    r.fld_Number_Of_Participants, 
    r.fld_Reservation_Status
FROM dbo.tbl_Reservation r
JOIN dbo.tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
JOIN dbo.tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
JOIN dbo.tbl_Venue_Pricing vp ON r.fk_Venue_PricingID = vp.pk_Venue_PricingID
JOIN dbo.tbl_Venue_Scope vs ON r.fk_Venue_ScopeID = vs.pk_Venue_ScopeID
ORDER BY rp.pk_Requesting_PersonID;