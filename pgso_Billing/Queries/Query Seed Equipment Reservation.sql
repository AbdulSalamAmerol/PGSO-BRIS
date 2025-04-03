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
    'Lorema',
    'Batawang',
    'Abz',
    '99C, Lara Street, Calaocan Bambong, Nueva Vizcaya',
    '09554602474',
    'Walk In'
);

DECLARE @NewRequestingPersonID INT = SCOPE_IDENTITY();

-- Insert Equipment Reservation (with 0 participants)
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
    'CN-20250324-021',
    'Equipment',
    '2025-04-10',
    '2025-04-11',
    '08:00:00',
    '17:00:00',
    'My Abz Equipment Party',
    0,                      -- Dummy value for participants
    'Pending'
);

DECLARE @NewReservationID INT = SCOPE_IDENTITY();
DECLARE @Days INT = 2;

-------------------------------
-- Insert Chairs (EquipmentID 3, PricingID 3)
DECLARE @QtyChairs INT = 50;
DECLARE @PriceChairs DECIMAL(10,2), @PriceSubChairs DECIMAL(10,2);
SELECT @PriceChairs = fld_Equipment_Price, @PriceSubChairs = fld_Equipment_Price_Subsequent
FROM dbo.tbl_Equipment_Pricing WHERE pk_Equipment_PricingID = 3;

DECLARE @TotalChairsCost DECIMAL(10,2) = 
  (@PriceChairs * @QtyChairs) + (@PriceSubChairs * @QtyChairs * (@Days - 1));

INSERT INTO dbo.tbl_Reservation_Equipment (
    fk_ReservationID, fk_EquipmentID, fk_Equipment_PricingID,
    fld_Quantity, fld_Number_Of_Days, fld_Total_Equipment_Cost
)
VALUES (
    @NewReservationID, 3, 3,
    @QtyChairs, @Days, @TotalChairsCost
);

-------------------------------
-- Insert Long Tables (EquipmentID 5, PricingID 5)
DECLARE @QtyTables INT = 10;
DECLARE @PriceTables DECIMAL(10,2), @PriceSubTables DECIMAL(10,2);
SELECT @PriceTables = fld_Equipment_Price, @PriceSubTables = fld_Equipment_Price_Subsequent
FROM dbo.tbl_Equipment_Pricing WHERE pk_Equipment_PricingID = 5;

DECLARE @TotalTablesCost DECIMAL(10,2) = 
  (@PriceTables * @QtyTables) + (@PriceSubTables * @QtyTables * (@Days - 1));

INSERT INTO dbo.tbl_Reservation_Equipment (
    fk_ReservationID, fk_EquipmentID, fk_Equipment_PricingID,
    fld_Quantity, fld_Number_Of_Days, fld_Total_Equipment_Cost
)
VALUES (
    @NewReservationID, 5, 5,
    @QtyTables, @Days, @TotalTablesCost
);

-------------------------------
-- Insert Collapsible Tent (EquipmentID 1, PricingID 1)
DECLARE @QtyTent INT = 1;
DECLARE @PriceTent DECIMAL(10,2), @PriceSubTent DECIMAL(10,2);
SELECT @PriceTent = fld_Equipment_Price, @PriceSubTent = fld_Equipment_Price_Subsequent
FROM dbo.tbl_Equipment_Pricing WHERE pk_Equipment_PricingID = 1;

DECLARE @TotalTentCost DECIMAL(10,2) = 
  (@PriceTent * @QtyTent) + (@PriceSubTent * @QtyTent * (@Days - 1));

INSERT INTO dbo.tbl_Reservation_Equipment (
    fk_ReservationID, fk_EquipmentID, fk_Equipment_PricingID,
    fld_Quantity, fld_Number_Of_Days, fld_Total_Equipment_Cost
)
VALUES (
    @NewReservationID, 1, 1,
    @QtyTent, @Days, @TotalTentCost
);
