-- select CONSTRAINT_NAME
-- from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
-- where TABLE_NAME = 'Agency'

SELECT * from AgencyAgent;	--badgeId constant
select * from Mission;
select * from Agent;
select * from SecurityClearance;	
select * from Agency;
select * from MissionAgent;	--null
select * from [Location]; 
select * from Alias;

-- Select * from Mission
-- INCLUDE 
--                     .Include(ma => ma.MissionAgents
--                     .Where(ma => ma.AgentId == agentId)).ToList(); 
--PensionList
--Return agent information for only retired agents (security clearance retired)	agencyId
-- SELECT
--     a.AgentId, a.FirstName, a.LastName, a.DateOfBirth, a.Height, sc.SecurityClearanceName
-- FROM Agent a
--     INNER JOIN AgencyAgent aa on a.AgentId = aa.AgentId
--     INNER JOIN SecurityClearance sc on aa.SecurityClearanceId = sc.SecurityClearanceId
--		INNER JOIN Agency ac on aa.AgencyId = ac.AgencyId
-- WHERE ac.AgencyId = 1 AND sc.SecurityClearanceName = 'Retired';