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
    public class AliasRepository : IAliasRepository
    {
        public Response Delete(int aliasId)
        {
            throw new NotImplementedException();
        }

        public Response<Alias> Get(int aliasId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Alias>> GetByAgent(int agentId)
        {
            throw new NotImplementedException();
        }

        public Response<Alias> Insert(Alias alias)
        {
            throw new NotImplementedException();
        }

        public Response Update(Alias alias)
        {
            throw new NotImplementedException();
        }
    }
}
