--Delete from tbl_Reservation_Equipment first (dependent on Reservation ID)
DELETE FROM dbo.tbl_Reservation_Equipment
WHERE fk_ReservationID IN (
    SELECT pk_ReservationID 
    FROM dbo.tbl_Reservation 
    WHERE fk_Requesting_PersonID IN (SELECT pk_Requesting_PersonID FROM dbo.tbl_Requesting_Person WHERE fld_Surname LIKE 'Surname%')
);

-- Delete from tbl_Reservation
DELETE FROM dbo.tbl_Reservation
WHERE fk_Requesting_PersonID IN (SELECT pk_Requesting_PersonID FROM dbo.tbl_Requesting_Person WHERE fld_Surname LIKE 'Surname%');

-- Delete from tbl_Requesting_Person
DELETE FROM dbo.tbl_Requesting_Person
WHERE fld_Surname LIKE 'Surname%';
