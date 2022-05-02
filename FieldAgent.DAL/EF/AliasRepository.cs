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
                try
                {
                    db.SaveChanges();
                    response.Data = alias;
                    response.Success = true;
                    response.Message = $"Deleting Alias ID: {aliasId}";
                }
                catch
                {
                    response.Success = false;
                    response.Message = $"Could not remove Alias ID: {aliasId}";
                }
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
                    response.Message = $"Could not find Alias ID: {id}";
                }
                else
                {
                    response.Success = true;
                    response.Message = $"Alias ID: {id}";
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
                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = $"Could not get Alias(es) by Agent ID: {agentId}";
                }
                else
                {
                    response.Success = true;
                    response.Message = $"Aliases of Agent ID: {agentId}";
                }
            }
            return response;
        }

        public Response<Alias> Insert(Alias alias)
        {
            Response<Alias> response = new Response<Alias>();

            using (var db = DbFac.GetDbContext())
            {
                db.Aliases.Add(alias);
                try
                {
                    db.SaveChanges();
                    response.Data = alias;
                    response.Success = true;
                    response.Message = $"Inserted Alias ID: {response.Data.AliasId}";
                    return response;
                }
                catch
                {
                    response.Success = false;
                    response.Message = "Could not insert Alias";
                    return response;
                }
            }
        }

        public Response Update(Alias alias)
        {
            Response<Alias> response = new Response<Alias>();

            using (var db = DbFac.GetDbContext())   
            {
                db.Aliases.Update(alias);
                try
                {
                    db.SaveChanges();
                    response.Data = alias;
                    response.Success = true;
                    response.Message = $"Updating Alias ID: {response.Data.AliasId}";
                    return response;
                }
                catch
                {
                    response.Success = false;
                    response.Message = "Could not update Alias";
                    return response;
                }
            }
        }
    }
}
