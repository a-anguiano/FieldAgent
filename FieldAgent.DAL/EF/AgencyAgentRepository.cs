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

        public Response Delete(int agencyId, int agentId)
        {
            Response<AgencyAgent> response = new Response<AgencyAgent>();

            using (var db = DbFac.GetDbContext())
            {
                AgencyAgent aa = db.AgenciesAgents.Find(agencyId, agentId);
                db.AgenciesAgents.Remove(aa);
                db.SaveChanges();
                response.Success = true;
                response.Message = "";
            }
            return response;
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
            Response<List<AgencyAgent>> response = new Response<List<AgencyAgent>>();

            using (var db = DbFac.GetDbContext())
            {
                List<AgencyAgent> results = db.AgenciesAgents
                    .Where(aa => aa.AgencyId == agencyId).ToList();
                response.Data = results;
            }
            return response;
        }

        public Response<List<AgencyAgent>> GetByAgent(int agentId)
        {
            Response<List<AgencyAgent>> response = new Response<List<AgencyAgent>>();
            
            using (var db = DbFac.GetDbContext())
            {
                List<AgencyAgent> results = db.AgenciesAgents
                    .Where(aa => aa.AgentId == agentId).ToList();
                response.Data = results;
            }
            return response;
        }

        public Response<AgencyAgent> Insert(AgencyAgent agencyAgent)
        {
            Response<AgencyAgent> response = new Response<AgencyAgent>();
            using (var db = DbFac.GetDbContext())
            {
                db.AgenciesAgents.Add(agencyAgent);
                db.SaveChanges();                       //!!!!!!
                
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