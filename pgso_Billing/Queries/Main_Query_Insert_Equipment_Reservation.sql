-- Equipment Query

-- Insert Requesting Person
INSERT INTO dbo.tbl_Requesting_Person (
    fld_Surname,
    fld_First_Name,
    fld_Middle_Name,
    fld_Requesting_Person_Address,
    fld_Contact_Number,
    fld_Request_Origin
)
VALUES (
    'Amerol 45',
    'Abdul Salam 45',
    'M',
    'Main Street, City 45',
    '09123456045',
    'Walk In'
);

DECLARE @NewRequestingPersonID INT = SCOPE_IDENTITY();

-- Insert Equipment Reservation
INSERT INTO dbo.tbl_Reservation (
    fk_Requesting_PersonID,
    fk_UserID,
    fld_Control_Number,
    fld_Reservation_Type,
    fld_Start_Date,
    fld_End_Date,
    fld_Start_Time,
    fld_End_Time,
    fld_Activity_Name,
    fld_Number_Of_Participants,
    fld_Reservation_Status
)
VALUES (
    @NewRequestingPersonID,
    1,
    'CN-20250401-0045',
    'Equipment',
    '2025-05-20',
    '2025-05-21',
    '08:00:00',
    '17:00:00',
    'Equipment Rental Event 0013',
    0, -- Dummy value for participants
    'Confirmed'
);

DECLARE @NewReservationID INT = SCOPE_IDENTITY();
DECLARE @Days INT = 2;

-- Change the Equipment Pricing ID here
DECLARE @pk_Equipment_PricingID INT = 3; -- Change this value to auto-match related data ##

DECLARE @EquipmentID INT, @EquipmentPrice DECIMAL(10,2), @EquipmentPriceSubsequent DECIMAL(10,2);

-- Fetch Equipment details based on selected Equipment Pricing ID
SELECT 
    @EquipmentID = fk_EquipmentID,
    @EquipmentPrice = fld_Equipment_Price,
    @EquipmentPriceSubsequent = fld_Equipment_Price_Subsequent
FROM dbo.tbl_Equipment_Pricing
WHERE pk_Equipment_PricingID = @pk_Equipment_PricingID;

-- Define quantity (can be changed manually)
DECLARE @Quantity INT = 5;

-- Compute total cost
DECLARE @TotalCost DECIMAL(10,2) = 
  (@EquipmentPrice * @Quantity) + (@EquipmentPriceSubsequent * @Quantity * (@Days - 1));

-- Insert into Reservation Equipment
INSERT INTO dbo.tbl_Reservation_Equipment (
    fk_ReservationID, fk_EquipmentID, fk_Equipment_PricingID,
    fld_Quantity, fld_Number_Of_Days, fld_Total_Equipment_Cost
)
VALUES (
    @NewReservationID, @EquipmentID, @pk_Equipment_PricingID,
    @Quantity, @Days, @TotalCost
);

