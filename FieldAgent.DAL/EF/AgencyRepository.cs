using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;

namespace FieldAgent.DAL.EF
{
    public class AgencyRepository : IAgencyRepository
    {
        public DBFactory DbFac { get; set; }

        public AgencyRepository(DBFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response Delete(int agencyId)
        {
            Response<Agency> response = new Response<Agency>();

            using (var db = DbFac.GetDbContext())
            {

                var agencies = db.Agencies
                    .Include(a => a.AgenciesAgents)
                    .Include(a => a.Locations)
                    .Include(a => a.Missions)
                    .ThenInclude(a => a.MissionAgents).ToList();

                Agency agency = db.Agencies.Find(agencyId);
                db.Agencies.Remove(agency);
                db.SaveChanges();
                response.Data = agency;
                response.Success = true;
                return response;
            }
        }

        public Response<Agency> Get(int agencyId)
        {
            int id = agencyId;
            Response<Agency> response = new Response<Agency>();

            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Agencies.Find(id);
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

        public Response<List<Agency>> GetAll()
        {
            Response<List<Agency>> response = new Response<List<Agency>>();
            List<Agency> listAgencies = new List<Agency>();

            using (var db = DbFac.GetDbContext())
            {
                listAgencies = db.Agencies.ToList();
            }
            response.Data = listAgencies;

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

            return response;
        }

        public Response<Agency> Insert(Agency agency)
        {
            Response<Agency> response = new Response<Agency>();

            using (var db = DbFac.GetDbContext())
            {
                db.Agencies.Add(agency);
                db.SaveChanges();
                response.Data = agency;
                return response;
            }
        }

        public Response Update(Agency agency)
        {
            Response<Agency> response = new Response<Agency>();

            using (var db = DbFac.GetDbContext())  
            {
                db.Agencies.Update(agency);
                db.SaveChanges();
                response.Data = agency;
                return response;
            }
        }
    }
}
