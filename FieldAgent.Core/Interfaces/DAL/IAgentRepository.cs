using FieldAgent.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Interfaces
{
    public interface IAgentRepository
    {
        Response<Agent> Insert(Agent agent);
        Response Update(Agent agent);
        Response Delete(int agentId);
        Response<Agent> Get(int agentId);
        Response<List<Mission>> GetMissions(int agentId);
    }
}
