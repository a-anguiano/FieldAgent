using FieldAgent.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Interfaces.DAL
{
    public interface ILocationRepository
    {
        Response<Location> Insert(Location location);
        Response Update(Location location);
        Response Delete(int locationId);
        Response<Location> Get(int locationId);
        Response<List<Location>> GetByAgency(int agencyId);
    }
}
