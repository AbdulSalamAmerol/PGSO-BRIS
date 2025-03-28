SELECT 
    r.fld_Control_Number,
    p.fld_Payment_Status,
    p.fld_Amount_Due,
    p.fld_Amount_Paid,
    u.fld_Username,
    p.fld_Created_At,
    r.fld_Reservation_Type,
    CONCAT(rp.fld_First_Name, ' ', rp.fld_Middle_Name, ' ', rp.fld_Surname) AS fld_Full_Name,
    r.fld_Activity_Name,
    r.fld_Start_Date,
    r.fld_End_Date,
    r.fld_Start_Time,
    r.fld_End_Time,
    v.fld_Venue_Name,
    s.fld_Venue_Scope_Name
FROM tbl_Payment p
JOIN tbl_Reservation r ON p.fk_ReservationID = r.pk_ReservationID
JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
JOIN tbl_User u ON p.fk_UserID = u.pk_UserID
LEFT JOIN tbl_Venue v ON r.fk_VenueID = v.pk_VenueID
LEFT JOIN tbl_Venue_Scope s ON r.fk_Venue_ScopeID = s.pk_Venue_ScopeID
ORDER BY r.fld_Control_Number DESC;
