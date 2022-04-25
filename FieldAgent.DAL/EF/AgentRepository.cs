using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces;
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

            using (var db = DbFac.GetDbContext())
            {
                foreach (Agent a in db.Agents.Where(a => a.AgentId == agentId).ToList())
                {
                    db.Agents.Remove(a);
                }

                Agent agent = db.Agents.Find(agentId);
                //cascade delete??
                db.Agents.Remove(agent);
                //
                db.SaveChanges();
                response.Data = agent;
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

        public Response<List<Mission>> GetMissions(int agentId)
        {
            Response<Agent> responseA = Get(agentId);
            Response<List<Mission>> responseB = new Response<List<Mission>>();

            if (responseA.Success)
            {
                List<Mission> missions = new List<Mission>();
                using (var db = DbFac.GetDbContext())
                {
                    var agents = db.Agents      //agentmission instead of ma
                        .Include(at => at.Missions)
                        .Where(at => at.AgentId == agentId)
                        .ToList();

                    foreach (var at in agents)
                    {
                        foreach (var mission in at.Missions)
                        {
                            missions.Add(mission);
                        }
                    }
                    responseB.Data = missions;
                    responseB.Success = true;
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
                return response;
            }
        }
    }
}
