using FieldAgent.Core;
using FieldAgent.Core.DTOs;
using FieldAgent.Core.Interfaces.DAL;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FieldAgent.DAL.ADO
{
    public class SqlReportsRepository : IReportsRepository
    {
        public DBFactory DbFac { get; set; }

        public SqlReportsRepository(DBFactory dbfac)    
        {
            DbFac = dbfac;
        }
        public Response<List<ClearanceAuditListItem>> AuditClearance(int securityClearanceId, int agencyId)
        {
            Response<List<ClearanceAuditListItem>> response = new Response<List<ClearanceAuditListItem>>();

            var audits = new List<ClearanceAuditListItem>();

            using (var cn = new SqlConnection(DbFac.GetConnectionString()))  
            {

                var cmd = new SqlCommand("AuditClearance", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@securityClearanceId", securityClearanceId);
                cmd.Parameters.AddWithValue("@agencyId", agencyId);

                try
                {
                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())       //can have another try catch, for data corruption
                        {
                            var row = new ClearanceAuditListItem();
                            row.BadgeId = (Guid)dr["BadgeId"];
                            row.NameLastFirst = (string)dr["NameLastFirst"];
                            row.DateOfBirth = (DateTime)dr["DateOfBirth"];
                            row.ActivationDate = (DateTime)dr["ActivationDate"];
                            if (dr["DeactivationDate"] != DBNull.Value)
                            {
                                row.DeactivationDate = (DateTime)dr["DeactivationDate"];
                            }
                            audits.Add(row);
                        }
                        response.Data = audits;
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

        public Response<List<PensionListItem>> GetPensionList(int agencyId)
        {
            Response<List<PensionListItem>> response = new Response<List<PensionListItem>>();
            List<PensionListItem> pensions = new List<PensionListItem>();

            using (var cn = new SqlConnection(DbFac.GetConnectionString()))  
            {
                var cmd = new SqlCommand("PensionListItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@agencyId", agencyId);

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

            using (var cn = new SqlConnection(DbFac.GetConnectionString()))  
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
