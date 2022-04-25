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
        public DBFactory DbFac { get; set; }

        public SecurityClearanceRepository(DBFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response<SecurityClearance> Get(int securityClearanceId)
        {
            Response<SecurityClearance> response = new Response<SecurityClearance>();

            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.SecurityClearances.Find(securityClearanceId);
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

        public Response<List<SecurityClearance>> GetAll()
        {
            Response<List<SecurityClearance>> response = new Response<List<SecurityClearance>>();

            using (var db = DbFac.GetDbContext())
            {
                List<SecurityClearance> scList = new List<SecurityClearance>();

                scList = db.SecurityClearances.ToList();

                response.Data = scList;

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
    }
}
