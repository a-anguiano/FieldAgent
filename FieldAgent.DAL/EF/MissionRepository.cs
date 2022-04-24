using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public Response<Mission> Get(int missionId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Mission>> GetByAgency(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Mission>> GetByAgent(int agentId)
        {
            throw new NotImplementedException();
        }

        public Response<Mission> Insert(Mission mission)
        {
            throw new NotImplementedException();
        }

        public Response Update(Mission mission)
        {
            throw new NotImplementedException();
        }
    }
}
