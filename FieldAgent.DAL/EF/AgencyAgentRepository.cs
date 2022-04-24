using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;

namespace FieldAgent.DAL
{
    public class AgencyAgentRepository : IAgencyAgentRepository
    {

        public DBFactory DbFac { get; set; }

        public AgencyAgentRepository(DBFactory dbfac)
        {
            DbFac = dbfac;
        }

        public Response Delete(int agencyid, int agentid)
        {
            throw new NotImplementedException();
        }

        public Response<AgencyAgent> Get(int agencyid, int agentid)
        {
            Response<AgencyAgent> response = new Response<AgencyAgent>();

            using (var db = DbFac.GetDbContext())
            {               
                response.Data = db.AgenciesAgents.Find(agencyid, agentid);
                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = "It failed";
                }
                else
                {
                    response.Success = true;
                    response.Message = "It's a success";
                }
            }
            return response;
        }

        public Response<List<AgencyAgent>> GetByAgency(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Response<List<AgencyAgent>> GetByAgent(int agentId)
        {
            throw new NotImplementedException();
        }

        public Response<AgencyAgent> Insert(AgencyAgent agencyAgent)
        {
            Response<AgencyAgent> response = new Response<AgencyAgent>();
            using (var db = DbFac.GetDbContext())
            {
                db.AgenciesAgents.Add(agencyAgent);
                db.SaveChanges();
                
                response.Success = true;
                //agent name, agency name?
                response.Message = $"Successfully inserted Agent {agencyAgent.AgentId}" +
                    $"in Agency {agencyAgent.AgencyId}";
                response.Data = agencyAgent;
            }

            return response;
        }

        public Response Update(AgencyAgent agencyAgent)
        {
            Response<AgencyAgent> response = new Response<AgencyAgent>();

            using (var db = DbFac.GetDbContext())
            {
                db.AgenciesAgents.Update(agencyAgent);
                db.SaveChanges();
                response.Success = true;
                response.Message = "";
                response.Data = agencyAgent;               
            }
            return response;
        }
    }
}