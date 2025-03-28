DECLARE @i INT = 1;

WHILE @i <= 1000
BEGIN
    -- Insert Requesting Person with dynamic data
    INSERT INTO dbo.tbl_Requesting_Person (
        fld_Surname,
        fld_First_Name,
        fld_Middle_Name,
        fld_Requesting_Person_Address,
        fld_Contact_Number,
        fld_Request_Origin
    )
    VALUES (
        'Surname' + CAST(@i AS VARCHAR(10)),  -- Dynamic surname
        'FirstName' + CAST(@i AS VARCHAR(10)), -- Dynamic first name
        'MiddleName' + CAST(@i AS VARCHAR(10)),-- Dynamic middle name
        'Address ' + CAST(@i AS VARCHAR(10)) + ' Street, City', -- Dynamic address
        '09' + CAST(100000000 + @i AS VARCHAR(10)), -- Dynamic contact number
        CASE WHEN @i % 2 = 0 THEN 'Walk In' ELSE 'Phone' END -- Alternating request origin
    );

    -- Get the newly inserted Requesting Person ID
    DECLARE @NewRequestingPersonID INT = SCOPE_IDENTITY();

    -- Get the correct Venue Pricing ID based on random VenueID and Scope
    DECLARE @VenuePricingID INT;
    DECLARE @VenueID INT;

    -- Randomly select a VenueID from tbl_Venue
    SELECT TOP 1 @VenueID = v.pk_VenueID
    FROM dbo.tbl_Venue v
    ORDER BY NEWID();  -- Random selection

    -- Select the appropriate VenuePricingID based on the randomly selected VenueID and ScopeID
    SELECT @VenuePricingID = vp.pk_Venue_PricingID
    FROM dbo.tbl_Venue_Pricing vp
    JOIN dbo.tbl_Venue_Scope s ON s.pk_Venue_ScopeID = vp.fk_Venue_ScopeID
    WHERE vp.fk_VenueID = @VenueID  -- Use the randomly selected VenueID
    AND vp.fld_Aircon = 1  -- Aircon = True (Assuming you want air-conditioned venues)

    -- Insert Reservation (using the new Requesting Person ID and selected VenuePricingID)
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
        @VenueID,  -- Use the randomly selected VenueID
        @VenuePricingID,  -- Correct VenuePricingID
        (SELECT TOP 1 fk_Venue_ScopeID FROM dbo.tbl_Venue_Pricing WHERE fk_VenueID = @VenueID),  -- Select a random scope
        1,  -- Assuming UserID 1 is valid
        'CN-20250324-' + RIGHT('300' + CAST(@i AS VARCHAR(3)), 3),  -- Dynamic control number
        'Venue',  -- Reservation type
        '2025-04-05',  -- Start date
        '2025-04-05',  -- End date
        '10:00:00',  -- Start time
        '17:00:00',  -- End time
        'Event ' + CAST(@i AS VARCHAR(10)),  -- Dynamic activity name
        10,  -- Dummy participants count
        'Pending'  -- Reservation status
    );

    -- Move to the next iteration
    SET @i = @i + 1;
END;
