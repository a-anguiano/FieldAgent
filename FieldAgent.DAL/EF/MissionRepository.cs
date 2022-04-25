using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces;

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
                foreach (Mission m in db.Missions.Where(m => m.MissionId == missionId).ToList())
                {
                    db.Missions.Remove(m);
                }

                Mission mission = db.Missions.Find(missionId);
                db.Missions.Remove(mission);
                db.SaveChanges();
                response.Data = mission;
                response.Success = true;
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

        public Response<List<Mission>> GetByAgency(int agencyId)
        {
            Response<List<Mission>> response = new Response<List<Mission>>();

            using (var db = DbFac.GetDbContext())
            {
                List<Mission> results = db.Missions
                    .Where(ac => ac.AgencyId == agencyId).ToList();
                response.Data = results;
            }
            return response;
        }

        public Response<List<Mission>> GetByAgent(int agentId)
        {
            throw new NotImplementedException();
            //Response<List<Mission>> response = new Response<List<Mission>>();

            //using (var db = DbFac.GetDbContext())
            //{
            //    List<Mission> results = db.Missions
            //        .Include(m => m.MissionAgent
            //        .Where(at => at.AgentId == agentId)).ToList();
            //    response.Data = results;
            //}
            //return response;
        }

        public Response<Mission> Insert(Mission mission)
        {
            Response<Mission> response = new Response<Mission>();

            using (var db = DbFac.GetDbContext())
            {
                db.Missions.Add(mission);
                db.SaveChanges();
                response.Data = mission;
                response.Success = true;
                return response;
            }
        }

        public Response Update(Mission mission)
        {
            Response<Mission> response = new Response<Mission>();

            using (var db = DbFac.GetDbContext())   
            {
                db.Missions.Update(mission);
                db.SaveChanges();
                response.Data = mission;
                return response;
            }
        }
    }
}
