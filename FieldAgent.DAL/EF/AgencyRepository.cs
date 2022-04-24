using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
