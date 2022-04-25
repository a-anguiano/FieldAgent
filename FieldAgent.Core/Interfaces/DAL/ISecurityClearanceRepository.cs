using FieldAgent.Core.Entities;

namespace FieldAgent.Core.Interfaces.DAL
{
    public interface ISecurityClearanceRepository
    {
        Response<SecurityClearance> Get(int securityClearanceId);
        Response<List<SecurityClearance>> GetAll();
    }
}
