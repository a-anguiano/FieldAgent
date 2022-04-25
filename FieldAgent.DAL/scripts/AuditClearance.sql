CREATE PROCEDURE [AuditClearance] (
        @agencyId AS int,
        @securityClearanceId AS int
)
AS
BEGIN
SELECT
    aa.BadgeId, CONCAT(a.LastName,', ', a.FirstName) NameLastFirst, a.DateOfBirth, aa.ActivationDate, aa.DeactivationDate
FROM Agent a
    INNER JOIN AgencyAgent aa on a.AgentId = aa.AgentId
    INNER JOIN SecurityClearance sc on aa.SecurityClearanceId = sc.SecurityClearanceId
    INNER JOIN Agency ac on aa.AgencyId = ac.AgencyId
WHERE ac.AgencyId = @agencyId AND sc.SecurityClearanceId = @securityClearanceId

END;