-- Insert Venues
INSERT INTO tbl_Venue (fld_Venue_Name) 
VALUES 
    ('Convention Center'),
	('Ammungan Hall'),
    ('Pasalubong Center'),
    ('Nueva Vizcaya Sports Complex'),
    ('FTM'),
    ('People Stage'),
    ('ARTC')
;

-- Insert Venue Scopes
INSERT INTO tbl_Venue_Scope (fld_Venue_Scope_Name) 
VALUES 
    ('CS_Whole_Building'),
    ('CS_Main_Hall_And_Mezzanine'),
    ('CS_Main_Hall'),
    ('CS_Lobby'),
    ('PS_Room_ABC'),
    ('PS_Room_A'),
    ('PS_Room_BC'),
	('AH_Whole_Building')
;

-- INSERT Convention Hall Venue Prices
INSERT INTO tbl_Venue_Pricing (fk_VenueID, fk_Venue_ScopeID, fld_Aircon, fld_Rate_Type, fld_First4Hrs_Rate, fld_Hourly_Rate, fld_Additional_Charge)
VALUES 
    -- Regular Rates (With Aircon)
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Whole_Building'), 1, 'Regular', 50000, 12000, 2000),
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Main_Hall_And_Mezzanine'), 1, 'Regular', 34000, 10000, 1500),
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Main_Hall'), 1, 'Regular', 32000, 8000, 1000),
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Lobby'), 1, 'Regular', 8000, 2000, 500),

    -- Regular Rates (Without Aircon)
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Whole_Building'), 0, 'Regular', 6000, 1500, 2000),
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Main_Hall_And_Mezzanine'), 0, 'Regular', 4000, 1100, 1500),
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Main_Hall'), 0, 'Regular', 2000, 700, 1000),
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Lobby'), 0, 'Regular', 1500, 300, 500),

    -- Special Rates (Only for With Aircon)
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Whole_Building'), 1, 'Special', 41200, 2200, 2000),
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Main_Hall_And_Mezzanine'), 1, 'Special', 32400, 2000, 1500),
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Main_Hall'), 1, 'Special', 26400, 1800, 1000),
    (1, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'CS_Lobby'), 1, 'Special', 4400, 400, 500)
;
	
-- INSERT Ammungan Hall Venue Prices
INSERT INTO tbl_Venue_Pricing (fk_VenueID, fk_Venue_ScopeID, fld_Aircon, fld_Rate_Type, fld_First4Hrs_Rate, fld_Hourly_Rate,fld_Additional_Charge)
VALUES
    -- Regular Rates (With Aircon)
    (2, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'AH_Whole_Building'), 1, 'Regular', 7000, 1500,0), 

    -- Regular Rate (Without Aircon)
    (2, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'AH_Whole_Building'), 0, 'Regular', 3500, 500,0),

    -- Special Rate (With Aircon)
    (2, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'AH_Whole_Building'), 1, 'Special', 6000, 1000,0),

    -- Special Rate (Without Aircon)
    (2, (SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'AH_Whole_Building'), 0, 'Special', 3000, 500,0)
;

-- INSERT PASALUONG CENTER
INSERT INTO tbl_Venue_Pricing (fk_VenueID, fk_Venue_ScopeID, fld_Aircon, fld_Rate_Type, fld_First4Hrs_Rate, fld_Hourly_Rate,fld_Additional_Charge)
VALUES
	--Regular Rates (With Aircon) 
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_ABC'), 1, 'Regular', 11500, 1800,0),
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_A'), 1, 'Regular', 4000, 800,0),
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_BC'), 1, 'Regular', 7500,1000,0),

	--Regular Rates (Without Aircon)
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_ABC'), 0, 'Regular', 7000,1300,0),
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_A'), 0, 'Regular', 2500, 500,0),
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_BC'), 0, 'Regular', 4500, 800,0),

	--Special Rate (With Aircon)
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_ABC'), 1, 'Special', 10000, 1500,0),
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_A'), 1, 'Special', 3500, 700,0),
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_BC'), 1, 'Special', 6500, 800,0),

	--Special Rate (Without Aircon)
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_ABC'), 0, 'Special', 6200, 1100,0),
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_A'), 0, 'Special', 2200, 500,0),
	(3,(SELECT pk_Venue_ScopeID FROM tbl_Venue_Scope WHERE fld_Venue_Scope_Name = 'PS_Room_BC'), 0, 'Special', 4000, 600,0)
;

INSERT INTO tbl_Venue_Markup (fk_VenueID, fld_Markup_Type, fld_Markup_Value)
VALUES (2, 'Nighttime', 1.20);

-- Insert Equipment Items
INSERT INTO tbl_Equipment (fld_Equipment_Name)
VALUES 
    ('Collapsible Tent 1'),
	('Collapsible Tent 2'),
    ('Chair'),
	('Seat Cover'),
    ('Long Table'),
    ('Round Table'),
	('Square Table'),
    ('Tablecloth'),
    ('Parachute'),
    ('Industrial Fan'),
    ('Sound System'),
    ('Caterer Fee'),
    ('Others')
;

-- Insert Initial Equipment Pricing with Effective Date Today
INSERT INTO tbl_Equipment_Pricing (fk_EquipmentID, fld_Equipment_Price, fld_Equipment_Price_Subsequent)
VALUES
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Collapsible Tent 1'), 500.00, 100.00 ), 
	((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Collapsible Tent 2'), 300.00, 100.00 ), 
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Chair'), 10.00, 10.00 ), 
	((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Seat Cover'), 20.00, 20.00 ),
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Long Table'), 50.00, 50.00),
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Round Table'), 50.00, 50.00),
	((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Square Table'), 50.00, 50.00),
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Tablecloth'), 0.00, 0.00),
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Parachute'), 0.00, 0.00),
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Industrial Fan'), 0.00, 0.00),
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Sound System'), 0.00, 0.00),
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Caterer Fee'), 1000.00, 0.00),
    ((SELECT pk_EquipmentID FROM tbl_Equipment WHERE fld_Equipment_Name = 'Others'), 0.00, 0.00 ) -- Admin inputs custom rate for 'Others'
;