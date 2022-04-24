--DROP PROCEDURE [SetKnownGoodState]
--Actually have to run it in Azure

CREATE PROCEDURE [SetKnownGoodState]
AS
BEGIN

ALTER TABLE AgencyAgent DROP CONSTRAINT FK__AgencyAge__Agenc__35BCFE0A
ALTER TABLE AgencyAgent DROP CONSTRAINT FK__AgencyAge__Agent__36B12243
ALTER TABLE AgencyAgent DROP CONSTRAINT FK__AgencyAge__Secur__37A5467C
ALTER TABLE MissionAgent DROP CONSTRAINT FK__MissionAg__Missi__30F848ED
ALTER TABLE MissionAgent DROP CONSTRAINT FK__MissionAg__Agent__31EC6D26
ALTER TABLE Alias DROP CONSTRAINT FK__Alias__AgentId__2E1BDC42
ALTER TABLE Mission DROP CONSTRAINT FK__Mission__AgencyI__29572725
ALTER TABLE [Location] DROP CONSTRAINT FK__Location__Agency__267ABA7A

TRUNCATE TABLE AgencyAgent
TRUNCATE TABLE SecurityClearance
TRUNCATE TABLE MissionAgent
TRUNCATE TABLE Alias
TRUNCATE TABLE Agent
TRUNCATE TABLE Mission
TRUNCATE TABLE [Location]
TRUNCATE TABLE Agency

    ALTER TABLE AgencyAgent add constraint FK__AgencyAge__Agenc__35BCFE0A
	           foreign key (AgencyId)
			   references Agency(AgencyId);
	ALTER TABLE AgencyAgent add constraint FK__AgencyAge__Agent__36B12243
	           foreign key (AgentId)
			   references Agent(AgentId);
	ALTER TABLE AgencyAgent add constraint FK__AgencyAge__Secur__37A5467C
	           foreign key (SecurityClearanceId)
			   references SecurityClearance(SecurityClearanceId);
	ALTER TABLE MissionAgent add constraint FK__MissionAg__Missi__30F848ED
	           foreign key (MissionId)
			   references Mission(MissionId);
	ALTER TABLE MissionAgent add constraint FK__MissionAg__Agent__31EC6D26
	           foreign key (AgentId)
			   references Agent(AgentId);
	ALTER TABLE Alias add constraint FK__Alias__AgentId__2E1BDC42
	           foreign key (AgentId)
			   references Agent(AgentId);
	ALTER TABLE Mission add constraint FK__Mission__AgencyI__29572725
	           foreign key (AgencyId)
			   references Agency(AgencyId);
	ALTER TABLE [Location] add constraint FK__Location__Agency__267ABA7A
	           foreign key (AgencyId)
			   references Agency(AgencyId);

--Agency
SET IDENTITY_INSERT Agency ON;
insert into Agency (AgencyId, ShortName, LongName) values (1, 'W', 'White Inc');
insert into Agency (AgencyId, ShortName, LongName) values (2, 'CCB', 'Cormier, Conroy and Borer');
insert into Agency (AgencyId, ShortName, LongName) values (3, 'LW', 'Lakin-Willms');
insert into Agency (AgencyId, ShortName, LongName) values (4, 'Volk', 'Volkman LLC');
insert into Agency (AgencyId, ShortName, LongName) values (5, 'TS', 'Tromp-Schneider');
insert into Agency (AgencyId, ShortName, LongName) values (6, 'Mur', 'Murazik Group');
insert into Agency (AgencyId, ShortName, LongName) values (7, 'Gut Boys', 'Gutkowski and Sons');
insert into Agency (AgencyId, ShortName, LongName) values (8, 'Lynch', 'Lynch LLC');
insert into Agency (AgencyId, ShortName, LongName) values (9, 'Von', 'VonRueden, Bergnaum and Toy');
insert into Agency (AgencyId, ShortName, LongName) values (10, 'Lang', 'Lang, Muller and Hagenes');
insert into Agency (AgencyId, ShortName, LongName) values (11, 'O', 'Kunze-O''Hara');
insert into Agency (AgencyId, ShortName, LongName) values (12, 'PW', 'Pacocha-Wisozk');
insert into Agency (AgencyId, ShortName, LongName) values (13, 'R', 'Rempel Inc');
insert into Agency (AgencyId, ShortName, LongName) values (14, 'Schu', 'Schuster, Toy and Ritchie');
insert into Agency (AgencyId, ShortName, LongName) values (15, 'Frami', 'Ondricka, Sawayn and Frami');
SET IDENTITY_INSERT Agency OFF;

--[Location]
SET IDENTITY_INSERT [Location] ON;
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (1, 1, 'Ward', 'Everett', 'Melvin', 'Tampa', '33680', 'US');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (2, 2, 'Avenger', 'Judy', 'East', 'Novokuz’minki', '171658', 'RU');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (3, 3, 'Phantom', 'Fairview', 'Monterey', 'Luz de Tavira', '8800-114', 'PT');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (4, 4, 'Supermarket', 'Stone Corner', 'American Ash', 'Uppsala', '751 30', 'SE');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (5, 5, 'Truce', 'Nobel', 'Doe Crossing', 'General Pico', '6360', 'AR');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (6, 6, 'Tempest', 'Delladonna', 'Atwood', 'Krajan Dukuhseti', '6360', 'ID');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (7, 7, 'Boca', 'Del Sol', 'Cordelia', 'Ros’', '6360', 'BY');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (8, 8, 'Super Mario', 'Butternut', 'Homewood', 'Columbeira', '2540-593', 'PT');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (9, 9, 'Young', 'Elmside', 'Colorado', 'Panorama', '17980-000', 'BR');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (10, 10, 'Shiri', '4th', 'Nevada', 'Beichengqu', '6360', 'CN');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (11, 11, 'Clown', 'Brentwood', 'Express', 'San Francisco', '8501', 'PH');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (12, 12, 'Down', 'Moulton', 'Toban', 'Mikumi', '6360', 'TZ');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (13, 13, 'Gion', 'Crownhardt', 'Holy Cross', 'Banjarjo', '6360', 'ID');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (14, 14, 'Sugar Cane Alley', 'Marquette', 'Charing Cross', 'Frederiksberg', '1812', 'DK');
insert into [Location] (LocationId, AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (15, 15, 'Resident', '1st', 'Charing Cross', 'Pandak', '6360', 'ID');
SET IDENTITY_INSERT [Location] OFF;

--Mission
SET IDENTITY_INSERT Mission ON;
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (1, 1, 'Ring-tailed lemur', 'Engineer IV', '6/11/1987', '4/3/2008', '11/30/2008', '49301805.93');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (2, 2, 'Lizard Liar', 'Product Engineer', '3/11/2000', '3/7/2002', '9/12/2002', '98285307.19');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (3, 3, 'Red Beast', 'Internal Auditor', '2/9/2003', '9/17/2009', '5/13/2014', '12631425.75');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (4, 4, 'Sungazer', 'Programmer I', '7/16/2004', '5/31/2007', '6/8/2009', '61726819.71');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (5, 5, 'Goldeneye', 'Environmental Tech', '11/27/1980', '1/18/2011', '4/24/2017', '84974465.98');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (6, 6, 'Onager', 'Quality Control Specialist', '1/17/1999', '4/13/2000', '9/20/2000', '23421683.85');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (7, 7, 'Catfish', 'Chief Design Engineer', '3/19/2001', '4/18/2018', '4/25/2018', '83304317.53');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (8, 8, 'Roller', 'Senior Cost Accountant', '12/10/1985', '5/31/2016', '10/28/2001', '5444424.36');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (9, 9, 'Mongoose', 'Product Engineer', '9/3/1998', '6/22/2011', '3/23/2004', '80174721.17');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (10, 10, 'Arctic ground squirrel', 'Project Manager', '9/29/1976', '10/11/2018', '9/8/2014', '8134377.51');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (11, 11, 'Egret', 'Quality Control Specialist', '2/13/2001', '5/7/2013', '9/22/2001', '92130591.10');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (12, 12, 'Neotropic', 'Quality Engineer', '12/29/1970', '2/20/2017', '11/14/2008', '34263689.31');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (13, 13, 'Parakeet', 'Programmer III', '5/27/1991', '5/27/2020', '5/18/2007', '76087274.06');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (14, 14, 'Squirrel, grey-footed', 'Senior Developer', '3/22/2000', '11/21/2003', '3/28/2010', '5421651.29');
insert into Mission (MissionId, AgencyId, CodeName, Notes, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost) values (15, 15, 'Caracara', 'Recruiter', '6/12/1991', '6/21/2005', '5/1/2007', '6170905.40');
SET IDENTITY_INSERT Mission OFF;

-- Agent
SET IDENTITY_INSERT Agent ON;
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (1, 'Aube', 'Daouze', '2/13/1991', 198.77);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (2, 'Truda', 'Coleby', '12/6/1980', 159.93);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (3, 'Kirk', 'McIlvenna', '8/15/1993', 209.53);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (4, 'Osbourn', 'Sapson', '8/13/1981', 133.31);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (5, 'James', 'Bond', '1/1/1980', 183.13);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (6, 'Jon', 'Alderson', '3/4/1990', 152.22);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (7, 'Cart', 'Iacovazzi', '8/20/1999', 125.47);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (8, 'Papagena', 'Saiz', '7/23/1995', 167.0);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (9, 'Odelinda', 'Alexsandrovich', '12/3/1980', 137.43);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (10, 'Loralie', 'Diggell', '5/9/1980', 134.92);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (11, 'Darby', 'Harridge', '12/31/1984', 218.84);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (12, 'Felix', 'Calliss', '4/4/1993', 206.06);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (13, 'Deb', 'Pagin', '12/18/1998', 169.49);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (14, 'Zacharias', 'Twamley', '1/29/1981', 224.71);
insert into Agent (AgentId, FirstName, LastName, DateOfBirth, Height) values (15, 'Brigid', 'Jeannequin', '2/26/1998', 209.98);
SET IDENTITY_INSERT Agent OFF;

--Alias
SET IDENTITY_INSERT Alias ON;
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (1, 1, 'Branched Blackberry', '3206f261-94f9-4d47-9a31-275473d659b3', 'Diverse even-keeled alliance');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (2, 2, 'Albizia', '4a4cb62c-3121-4961-a21a-22ef3f106ed0', 'Integrated dedicated paradigm');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (3, 3, 'San Pedro River Sandmat', '926d1da0-5059-4329-9b6b-18c4f1b1520d', 'Profound grid-enabled portal');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (4, 4, 'Ostrich Fern', '8b554af2-f64c-4158-9a04-093121bc5ed9', 'Organic client-driven monitoring');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (5, 5, 'Saltmarsh Dodder', '690a56d9-029c-42e1-8340-11fbf1e46de7', 'Cross-platform empowering migration');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (6, 6, 'Pringle''s Giant Hyssop', 'b21dd045-2165-4215-85f9-f1b9616701ac', 'Cross-platform responsive middleware');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (7, 7, 'Big Red Sage', 'f52c0e56-7816-49f3-83fe-64bd526177f2', 'Customer-focused dedicated migration');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (8, 8, 'Adansonia', '5beb4617-0f0b-4355-842b-cabad1b771af', 'Future-proofed responsive matrix');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (9, 9, 'Graceful Peperomia', 'bf67bb3b-f00f-4594-a312-aae7985b09e4', 'Optional high-level migration');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (10, 10, 'Campylopus Moss', '777da1ee-ccf4-4878-9f36-def00a82ffcf', 'Ergonomic empowering local area network');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (11, 11, 'Clasmatodon Moss', 'c8737690-3aff-47fb-87c1-0e2df7ad29b9', 'Assimilated content-based solution');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (12, 12, 'Hummock Honeymyrtle', 'acd09c46-04ae-47ef-99cd-e2a30bda154b', 'Focused zero tolerance infrastructure');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (13, 13, 'Emory Oak', '9abb97f1-beda-4a9d-a0f8-a4e615f5a4d0', 'Multi-channelled heuristic conglomeration');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (14, 14, 'Saltwater Cress', '470f2f6b-9bfd-447a-b4ee-69d2a05f6c2b', 'Programmable local database');
insert into Alias (AliasId, AgentId, AliasName, InterpolId, Persona) values (15, 15, 'Lavenderleaf Sundrops', '37434980-fa98-4c9c-af83-ae91bf216bb7', 'Devolved systemic framework');
SET IDENTITY_INSERT Alias OFF;

--SecurityClearance
insert into SecurityClearance (SecurityClearanceName) values ('None');	--1
insert into SecurityClearance (SecurityClearanceName) values ('Retired');
insert into SecurityClearance (SecurityClearanceName) values ('Secret');
insert into SecurityClearance (SecurityClearanceName) values ('TopSecret');
insert into SecurityClearance (SecurityClearanceName) values ('Black Ops');

TRUNCATE TABLE AgencyAgent
--AgencyAgent
insert into AgencyAgent 
    (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive)
        select
            Agency.AgencyId,                             -- AgencyId
            Agent.AgentId,                               -- AgentId
            1,                                           -- SecurityClearanceId
			'c4c0537d-6b12-4d0d-92dd-d71bb6e03f04',			--BadgeId
            dateadd(year, 10, Agent.DateOfBirth),                 -- ActivationDate
			dateadd(year, 20, Agent.DateOfBirth),			--DeactivationDate
			1												--IsActive
        from Agency
        cross join Agent
		WHERE Agent.AgentId = Agency.AgencyId;	--maybe change

UPDATE AgencyAgent SET
	SecurityClearanceId = 2,
	IsActive = 0
WHERE AgencyId BETWEEN 6 AND 10;

UPDATE AgencyAgent SET
	SecurityClearanceId = 3,
	IsActive = 0
WHERE AgencyId BETWEEN 11 AND 12;

UPDATE AgencyAgent SET
	SecurityClearanceId = 4
WHERE AgencyId BETWEEN 13 AND 15;

UPDATE AgencyAgent SET
	SecurityClearanceId = 5
WHERE AgencyId =5;

--MissionAgent
insert into MissionAgent 
    (MissionId, AgentId)
        select
            m.MissionId,                         
            a.AgentId                           									
        from Mission m
		Cross JOIN Agent a
		WHERE m.MissionId = a.AgentId;

END;