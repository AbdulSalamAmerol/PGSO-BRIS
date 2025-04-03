-- Step 1: Delete dependent records first
DELETE FROM dbo.tbl_Payment;
DBCC CHECKIDENT ('dbo.tbl_Payment', RESEED, 0);

DELETE FROM dbo.tbl_Reservation_Equipment;
DBCC CHECKIDENT ('dbo.tbl_Reservation_Equipment', RESEED, 0);

DELETE FROM dbo.tbl_Reservation;
DBCC CHECKIDENT ('dbo.tbl_Reservation', RESEED, 0);

-- Step 2: Delete mapping & markup tables first
DELETE FROM dbo.tbl_Venue_Scope_Mapping;
DBCC CHECKIDENT ('dbo.tbl_Venue_Scope_Mapping', RESEED, 0);

DELETE FROM dbo.tbl_Venue_Markup;
DBCC CHECKIDENT ('dbo.tbl_Venue_Markup', RESEED, 0);

-- Step 3: Delete from referenced tables
DELETE FROM dbo.tbl_Requesting_Person;
DBCC CHECKIDENT ('dbo.tbl_Requesting_Person', RESEED, 0);

DELETE FROM dbo.tbl_Venue_Pricing;
DBCC CHECKIDENT ('dbo.tbl_Venue_Pricing', RESEED, 0);

DELETE FROM dbo.tbl_Venue_Scope;
DBCC CHECKIDENT ('dbo.tbl_Venue_Scope', RESEED, 0);

DELETE FROM dbo.tbl_Venue;
DBCC CHECKIDENT ('dbo.tbl_Venue', RESEED, 0);

DELETE FROM dbo.tbl_Equipment_Pricing;
DBCC CHECKIDENT ('dbo.tbl_Equipment_Pricing', RESEED, 0);

DELETE FROM dbo.tbl_Equipment;
DBCC CHECKIDENT ('dbo.tbl_Equipment', RESEED, 0);
