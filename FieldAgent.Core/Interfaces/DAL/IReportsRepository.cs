using FieldAgent.Core.DTOs;

namespace FieldAgent.Core.Interfaces.DAL
{
    public interface IReportsRepository
    {
        Response<List<TopAgentListItem>> GetTopAgents();
        Response<List<PensionListItem>> GetPensionList(int agencyId);
        Response<List<ClearanceAuditListItem>> AuditClearance(int securityClearanceId, int agencyId);
    }
}
