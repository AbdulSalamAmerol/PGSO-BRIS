SELECT 
    r.fld_Control_Number,
    CONCAT(rp.fld_First_Name, ' ', rp.fld_Middle_Name, ' ', rp.fld_Surname) AS fld_Full_Name,
    e.fld_Equipment_Name,
    re.fld_Quantity,
    ep.fld_Equipment_Price,
    ep.fld_Equipment_Price_Subsequent,
    re.fld_Number_Of_Days,  -- Added fld_Number_Of_Days here
    (ep.fld_Equipment_Price * re.fld_Quantity) + 
    (ep.fld_Equipment_Price_Subsequent * re.fld_Quantity * (re.fld_Number_Of_Days - 1)) AS fld_Total_Equipment_Cost
FROM tbl_Reservation_Equipment re
JOIN tbl_Reservation r ON re.fk_ReservationID = r.pk_ReservationID
JOIN tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
JOIN tbl_Equipment e ON re.fk_EquipmentID = e.pk_EquipmentID
JOIN tbl_Equipment_Pricing ep ON re.fk_Equipment_PricingID = ep.pk_Equipment_PricingID
