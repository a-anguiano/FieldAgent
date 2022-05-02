using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;

namespace FieldAgent.DAL.EF
{
    public class MissionRepository : IMissionRepository
    {
        public DBFactory DbFac { get; set; }

        public MissionRepository(DBFactory dbfac)
        {
            DbFac = dbfac;
        }

        public Response Delete(int missionId)
        {
            Response<Mission> response = new Response<Mission>();

            using (var db = DbFac.GetDbContext())
            {
                var missions = db.Missions
                    .Include(a => a.MissionAgents).ToList();

                Mission mission = db.Missions.Find(missionId);
                db.Missions.Remove(mission);
                try
                {
                    db.SaveChanges();
                    response.Data = mission;
                    response.Success = true;
                    response.Message = $"Deleting Mission ID: {missionId}";
                }
                catch
                {
                    response.Success = false;
                    response.Message = $"Could not delete Mission ID: {missionId}";
                }

                return response;
            }
        }

        public Response<Mission> Get(int missionId)
        {
            Response<Mission> response = new Response<Mission>();

            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Missions.Find(missionId);
                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = $"Could not find Mission ID: {missionId}";
                }
                else
                {
                    response.Success = true;
                    response.Message = $"Mission ID: {missionId}";
                }
            }
            return response;
        }

        public Response<List<Mission>> GetByAgency(int agencyId)
        {
            Response<List<Mission>> response = new Response<List<Mission>>();

            using (var db = DbFac.GetDbContext())
            {
                List<Mission> results = db.Missions
                    .Where(ac => ac.AgencyId == agencyId).ToList();
                response.Data = results;
                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = $"Could not get mission(s) by Agency ID: {agencyId}";
                }
                else
                {
                    response.Success = true;
                    response.Message = $"Mission(s) at Agency ID: {agencyId}";
                }
            }
            return response;
        }

        public Response<List<Mission>> GetByAgent(int agentId)  //I dont trust this
        {
            Response<List<Mission>> response = new Response<List<Mission>>();

            using (var db = DbFac.GetDbContext())
            {
                List<Mission> results = db.Missions
                    .Include(ma => ma.MissionAgents)
                    .Where(ma => ma.MissionAgents.Any(m => m.AgentId == agentId)).ToList();  //Understand this

                response.Data = results;
                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = $"Could not get mission(s) by Agent ID: {agentId}";
                }
                else
                {
                    response.Success = true;
                    response.Message = $"Mission(s) of Agent ID: {agentId}";
                }
            }
            return response;
        }

        public Response<Mission> Insert(Mission mission)
        {
            Response<Mission> response = new Response<Mission>();

            using (var db = DbFac.GetDbContext())
            {
                db.Missions.Add(mission);
                try
                {
                    db.SaveChanges();
                    response.Data = mission;
                    response.Success = true;
                    response.Message = $"Inserting Mission ID: {response.Data.MissionId}";
                }
                catch
                {
                    response.Success = false;
                    response.Message = "Could not insert mission";
                }

                return response;
            }
        }

        public Response Update(Mission mission)
        {
            Response<Mission> response = new Response<Mission>();

            using (var db = DbFac.GetDbContext())   
            {
                db.Missions.Update(mission);
                try
                {
                    db.SaveChanges();
                    response.Data = mission;
                    response.Success = true;
                    response.Message = $"Updating Mission ID: {response.Data.MissionId}";
                }
                catch
                {
                    response.Success = false;
                    response.Message = "Could not update mission";
                }

                return response;
            }
        }
    }
}
