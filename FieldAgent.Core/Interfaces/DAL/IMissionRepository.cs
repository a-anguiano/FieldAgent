using FieldAgent.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Interfaces
{
    public interface IMissionRepository
    {
        Response<Mission> Insert(Mission mission);
        Response Update(Mission mission);
        Response Delete(int missionId);
        Response<Mission> Get(int missionId);
        Response<List<Mission>> GetByAgency(int agencyId);
        Response<List<Mission>> GetByAgent(int agentId);
    }
}
