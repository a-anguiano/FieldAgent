--DROP PROCEDURE [AuditClearance]
--Actually have to run it in Azure
--Return agent information given a security clearance value and agency id	securityClearanceId, agencyId
--list???

-- CREATE PROCEDURE [AuditClearance] (
--         @AgencyId AS int,
--         @SecurityClearanceId AS int,
--         @AgentId AS int OUTPUT
-- )
-- AS
-- BEGIN
-- SELECT
--     a.AgentId, a.FirstName, a.LastName, a.DateOfBirth, a.Height, sc.SecurityClearanceId
-- FROM Agent a
--     INNER JOIN AgencyAgent aa on a.AgentId = aa.AgentId
--     INNER JOIN SecurityClearance sc on aa.SecurityClearanceId = sc.SecurityClearanceId
--     INNER JOIN Agency ac on aa.AgencyId = ac.AgencyId
-- WHERE ac.AgencyId = @AgencyId AND sc.SecurityClearanceId = @SecurityClearaanceId

-- END;

--using TestFieldAgent;

-- SELECT
--     a.AgentId, a.FirstName, a.LastName, a.DateOfBirth, a.Height, sc.SecurityClearanceId
-- FROM Agent a
--     INNER JOIN AgencyAgent aa on a.AgentId = aa.AgentId
--     INNER JOIN SecurityClearance sc on aa.SecurityClearanceId = sc.SecurityClearanceId
--     INNER JOIN Agency ac on aa.AgencyId = ac.AgencyId
-- WHERE ac.AgencyId = 2 AND sc.SecurityClearanceId = 2;
