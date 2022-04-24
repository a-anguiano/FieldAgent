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
    public class LocationRepository : ILocationRepository
    {
        public DBFactory DbFac { get; set; }

        public LocationRepository(DBFactory dbfac)
        {
            DbFac = dbfac;
        }

        public Response Delete(int locationId)
        {
            Response<Location> response = new Response<Location>();

            using (var db = DbFac.GetDbContext())
            {
                foreach (Location l in db.Locations.Where(l => l.LocationId == locationId).ToList())
                {
                    db.Locations.Remove(l);
                }

                Location location = db.Locations.Find(locationId);
                db.Locations.Remove(location);
                db.SaveChanges();
                response.Data = location;
                response.Success = true;
                return response;
            }
        }

        public Response<Location> Get(int locationId)
        {
            Response<Location> response = new Response<Location>();

            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Locations.Find(locationId);
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

        public Response<List<Location>> GetByAgency(int agencyId)
        {
            Response<List<Location>> response = new Response<List<Location>>();

            using (var db = DbFac.GetDbContext())
            {
                List<Location> results = db.Locations
                    .Where(ac => ac.AgencyId == agencyId).ToList();
                response.Data = results;
            }
            return response;
        }

        public Response<Location> Insert(Location location)
        {
            Response<Location> response = new Response<Location>();

            using (var db = DbFac.GetDbContext())
            {
                db.Locations.Add(location);
                db.SaveChanges();
                response.Data = location;
                response.Success = true;
                return response;
            }
        }

        public Response Update(Location location)
        {
            Response<Location> response = new Response<Location>();

            using (var db = DbFac.GetDbContext())   //here
            {
                db.Locations.Update(location);
                db.SaveChanges();
                response.Data = location;
                return response;
            }
        }
    }
}
