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
        public DBFactory DbFac { get; set; }

        public AliasRepository(DBFactory dbfac)
        {
            DbFac = dbfac;
        }

        public Response Delete(int aliasId)
        {
            Response<Alias> response = new Response<Alias>();

            using (var db = DbFac.GetDbContext())
            {
                foreach (Alias a in db.Aliases.Where(a => a.AliasId == aliasId).ToList())
                {
                    db.Aliases.Remove(a);
                }

                Alias alias = db.Aliases.Find(aliasId);
                db.Aliases.Remove(alias);
                db.SaveChanges();
                response.Data = alias;
                response.Success = true;
                return response;
            }
        }

        public Response<Alias> Get(int aliasId)
        {
            int id = aliasId;
            Response<Alias> response = new Response<Alias>();

            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Aliases.Find(id);
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

        public Response<List<Alias>> GetByAgent(int agentId)
        {
            Response<List<Alias>> response = new Response<List<Alias>>();

            using (var db = DbFac.GetDbContext())
            {
                List<Alias> results = db.Aliases
                    .Where(at => at.AgentId == agentId).ToList();
                response.Data = results;
            }
            return response;
        }

        public Response<Alias> Insert(Alias alias)
        {
            Response<Alias> response = new Response<Alias>();

            using (var db = DbFac.GetDbContext())
            {
                db.Aliases.Add(alias);
                db.SaveChanges();
                response.Data = alias;
                response.Success = true;
                return response;
            }
        }

        public Response Update(Alias alias)
        {
            Response<Alias> response = new Response<Alias>();

            using (var db = DbFac.GetDbContext())   //here
            {
                db.Aliases.Update(alias);
                db.SaveChanges();
                response.Data = alias;
                return response;
            }
        }
    }
}
