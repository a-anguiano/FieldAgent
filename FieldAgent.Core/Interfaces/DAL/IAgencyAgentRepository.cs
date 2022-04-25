using FieldAgent.Core.Entities;

namespace FieldAgent.Core.Interfaces.DAL
{
    public interface IAgencyAgentRepository
    {
        Response<AgencyAgent> Insert(AgencyAgent agencyAgent);
        Response Update(AgencyAgent agencyAgent);
        Response Delete(int agencyid, int agentid);
        Response<AgencyAgent> Get(int agencyid, int agentid);
        Response<List<AgencyAgent>> GetByAgency(int agencyId);
        Response<List<AgencyAgent>> GetByAgent(int agentId);
    }
}
