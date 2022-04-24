using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces;
using FieldAgent.DAL.EF;
using FieldAgent.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                db.Agents.Remove(agent);
                db.SaveChanges();
                response.Data = agent;
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
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            throw new NotImplementedException();
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
