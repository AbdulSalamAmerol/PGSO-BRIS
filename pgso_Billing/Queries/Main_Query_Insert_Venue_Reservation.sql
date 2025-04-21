-- VENUE QUERY

DECLARE @NewRequestingPersonID INT;
DECLARE @VenuePricingID INT = 28;  -- Change this value only!
DECLARE @VenueID INT;
DECLARE @VenueScopeID INT;

-- Retrieve the VenueID and VenueScopeID automatically based on the VenuePricingID
SELECT 
    @VenueID = fk_VenueID,
    @VenueScopeID = fk_Venue_ScopeID
FROM dbo.tbl_Venue_Pricing
WHERE pk_Venue_PricingID = @VenuePricingID;

-- Insert a single requesting person
INSERT INTO dbo.tbl_Requesting_Person (
    fld_Surname,
    fld_First_Name,
    fld_Middle_Name,
    fld_Requesting_Person_Address,
    fld_Contact_Number,
    fld_Request_Origin
)
VALUES (
    'Amerol 28',  
    'Abdul Salam 28',
    'M',
    'Main Street, City 28',
    '09123456028',
    'Walk In'
);

-- Get the newly inserted Requesting Person ID
SET @NewRequestingPersonID = SCOPE_IDENTITY();

-- Insert a reservation using the selected VenuePricingID and its corresponding VenueID and ScopeID
INSERT INTO dbo.tbl_Reservation (
    fk_Requesting_PersonID,
    fk_VenueID,
    fk_Venue_PricingID,
    fk_Venue_ScopeID,
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
    @VenueID, 
    @VenuePricingID,  
    @VenueScopeID,
    1,  -- Assuming User ID 1 exists
    'CN-20250324-0028',  -- Example control number
    'Venue',
    '2025-04-28',
    '2025-04-28',
    '10:00:00',
    '17:00:00',
    'Sample Event 0028',
    100,
    'Confirmed'
);