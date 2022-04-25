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
        //private readonly IConfigurationRoot Config;
        ////private readonly FactoryMode Mode;
        public DBFactory DbFac { get; set; }

        public SqlReportsRepository(DBFactory dbfac)    //IConfigurationRoot config, 
        {
            //Config = config;
            DbFac = dbfac;
        }
        public Response<List<ClearanceAuditListItem>> AuditClearance(int securityClearanceId, int agencyId)
        {
            throw new NotImplementedException();

            Response<List<ClearanceAuditListItem>> response = new Response<List<ClearanceAuditListItem>>();

            var agents = new List<Agent>();

            using (var cn = new SqlConnection(DbFac.GetConnectionString()))  
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
            Response<List<PensionListItem>> response = new Response<List<PensionListItem>>();
            List<PensionListItem> pensions = new List<PensionListItem>();

            using (var cn = new SqlConnection(DbFac.GetConnectionString()))  
            {
                var cmd = new SqlCommand("PensionListItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var row = new PensionListItem();
                            row.AgencyName = (string)dr["AgencyName"];
                            row.BadgeId = (Guid)dr["BadgeId"];
                            row.NameLastFirst = (string)dr["NameLastFirst"];
                            row.DateOfBirth = (DateTime)dr["DateOfBirth"];
                            row.DeactivationDate = (DateTime)dr["DeactivationDate"];
                            pensions.Add(row);
                        }
                        response.Data = pensions;
                        response.Success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    response.Success = false;
                }
            }
            return response;

        }

        public Response<List<TopAgentListItem>> GetTopAgents()
        {
            Response<List<TopAgentListItem>> response = new Response<List<TopAgentListItem>>();
            List<TopAgentListItem> topAgents = new List<TopAgentListItem>();

            using (var cn = new SqlConnection(DbFac.GetConnectionString()))  //?get cn string
            {
                var cmd = new SqlCommand("TopAgentListItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var row = new TopAgentListItem();
                            row.NameLastFirst = (string)dr["NameLastFirst"];
                            row.DateOfBirth = (DateTime)dr["DateOfBirth"];
                            row.CompletedMissionCount = (int)dr["CompletedMissionCount"];
                            topAgents.Add(row);
                        }
                        response.Data = topAgents;
                        response.Success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    response.Success= false;
                }
            }
            return response;
        }
    }
}
