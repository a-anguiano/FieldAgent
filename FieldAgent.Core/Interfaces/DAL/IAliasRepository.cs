using FieldAgent.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Interfaces.DAL
{
    public interface IAliasRepository
    {
        Response<Alias> Insert(Alias alias);
        Response Update(Alias alias);
        Response Delete(int aliasId);
        Response<Alias> Get(int aliasId);
        Response<List<Alias>> GetByAgent(int agentId);
    }
}
