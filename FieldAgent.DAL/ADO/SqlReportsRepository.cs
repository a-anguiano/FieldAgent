using FieldAgent.Core;
using FieldAgent.Core.DTOs;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL.ADO
{
    public class SqlReportsRepository : IReportsRepository
    {
        private readonly IConfigurationRoot Config;
        private readonly FactoryMode Mode;

        public SqlReportsRepository(IConfigurationRoot config, FactoryMode mode = FactoryMode.PROD)
        {
            Config = config;
            Mode = mode;
        }
        public Response<List<ClearanceAuditListItem>> AuditClearance(int securityClearanceId, int agencyId)
        {
            throw new NotImplementedException();

            Response<List<ClearanceAuditListItem>> response = new Response<List<ClearanceAuditListItem>>();

            var agents = new List<Agent>();

            using (var cn = new SqlConnection(DBFactory.GetConnectionString(Config, Mode)))  //?get cn string
            {

                var cmd = new SqlCommand("AuditClearance", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@securityClearanceId", "@agencyId");

                //var id = new SqlParameter("@AgentId", SqlDbType.Int);   //gather more from output
                //id.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(id);

                cn.Open();

                using (var reader = cmd.ExecuteReader())
                {                  
                    while (reader.Read())
                    {
                        //var row = new Agent();
                        //row.AgentId = (int)reader["AgentId"];
                        //row.FirstName = (string)reader["FirstName"];
                        //row.LastName = (string)reader["LastName"];
                        //row.DateOfBirth = (DateTime)reader["DateOfBirth"];
                        //row.Height = (decimal)reader["Height"];
                        //agents.Add(row);
                    }                   
                }
                //List<ClearanceAuditListItem> list = 
//Guid BadgeId, string NameLastFirst, DateTime DateOfBirth, DateTime ActivationDate, DateTime? DeactivationDate
        //response.Data = agents;
    }

            //return Response<List<ClearanceAuditListItem>>
        }

        public Response<List<PensionListItem>> GetPensionList(int agencyId)
        {
            throw new NotImplementedException();
            //agencyId

        }

        public Response<List<TopAgentListItem>> GetTopAgents()
        {
            throw new NotImplementedException();
            //no input
        }
    }
}
