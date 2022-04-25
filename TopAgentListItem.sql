--DROP PROCEDURE [TopAgentListItem]

CREATE PROCEDURE [TopAgentListItem]

AS
BEGIN
SELECT top(3)
	CONCAT(a.LastName,', ', a.FirstName) NameLastFirst, a.DateOfBirth, COUNT(*) CompletedMissionCount
FROM Agent a
	INNER JOIN MissionAgent ma on a.AgentId = ma.AgentId
	INNER JOIN Mission m on ma.MissionId = m.MissionId
WHERE m.ActualEndDate IS NOT NULL
GROUP BY a.LastName, a.FirstName, a.DateOfBirth
ORDER BY CompletedMissionCount DESC

END;

--Returns top three agents by number of missions completed (ActualEndDate not null)
-- SELECT top(3)
-- 	CONCAT(a.LastName,', ', a.FirstName) NameLastFirst, a.DateOfBirth, COUNT(*) CompletedMissionCount
-- FROM Agent a
-- 	INNER JOIN MissionAgent ma on a.AgentId = ma.AgentId
-- 	INNER JOIN Mission m on ma.MissionId = m.MissionId
-- WHERE m.ActualEndDate IS NOT NULL
-- GROUP BY a.LastName, a.FirstName, a.DateOfBirth
-- ORDER BY CompletedMissionCount DESC;