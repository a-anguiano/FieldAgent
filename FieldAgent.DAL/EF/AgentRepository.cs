using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;

namespace FieldAgent.DAL.EF
{
    public class AgentRepository : IAgentRepository
    {
        public DBFactory DbFac { get; set; }

        public AgentRepository(DBFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response Delete(int agentId)
        {
            Response<Agent> response = new Response<Agent>();

            using (var db = DbFac.GetDbContext())   //throws an exception
            {

                var agents = db.Agents
                    .Include(a => a.MissionAgents)
                    .ThenInclude(a => a.Mission)
                    .Include(a => a.AgenciesAgents)
                    .Include(a => a.Aliases).ToList();

                Agent agent = db.Agents.Find(agentId);
                db.Agents.Remove(agent);
                //try savechange
                db.SaveChanges();
                response.Data = agent;
                response.Message = $"Deleting Agent ID: {agentId}";
                response.Success = true;
                return response;
            }
        }

        public Response<Agent> Get(int agentId)
        {
            int id = agentId;
            Response<Agent> response = new Response<Agent>();

            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Agents.Find(id);
                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = $"Could not find Agent ID: {id}";
                }
                else
                {
                    response.Success = true;
                    response.Message = $"Agent ID: {id}";
                }
            }
            return response;
        }

        public Response<List<Mission>> GetMissions(int agentId)
        {
            Response<Agent> responseA = Get(agentId);
            Response<List<Mission>> responseB = new Response<List<Mission>>();

            if (responseA.Success)
            {
                List<Mission> missions = new List<Mission>();

                using (var db = DbFac.GetDbContext())
                {
                    List<Mission> results = db.Missions
                        .Include(m => m.MissionAgents
                        .Where(at => at.AgentId == agentId)).ToList();

                    responseB.Data = results;
                    responseB.Success = true;
                    responseB.Message = $"The Mission(s) for Agent ID: {agentId}";
                }
            }
            return responseB;
        }

        public Response<Agent> Insert(Agent agent)
        {            
            Response<Agent> response = new Response<Agent>();

            using (var db = DbFac.GetDbContext())
            {
                db.Agents.Add(agent);
                db.SaveChanges();
                response.Data = agent;
                response.Success = true;
                //response.Message = $"Inserted Agent ID: {agent.AgentId}";
                return response;
            }
        }

        public Response Update(Agent agent)
        {
            Response<Agent> response = new Response<Agent>();

            using (var db = DbFac.GetDbContext())
            {
                db.Agents.Update(agent);
                db.SaveChanges();
                response.Data = agent;
                response.Success = true;
                response.Message = $"Updating Agent ID: {agent.AgentId}";
                return response;
            }
        }
    }
}
