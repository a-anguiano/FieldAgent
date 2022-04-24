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
    public class SecurityClearanceRepository : ISecurityClearanceRepository
    {
        public Response<SecurityClearance> Get(int securityClearanceId)
        {
            throw new NotImplementedException();
        }

        public Response<List<SecurityClearance>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
