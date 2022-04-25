using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    [Table("AgencyAgent")]
    public class AgencyAgent
    {
        public int AgencyId { get; set; }
        public int AgentId { get; set; }

        public Guid BadgeId { get; set; }
        
        public DateTime ActivationDate { get; set; }
        public DateTime DeactivationDate { get; set; }
        public bool IsActive { get; set; }   

        public int SecurityClearanceId { get; set; }
        public SecurityClearance SecurityClearance { get; set; }

        public Agency Agency { get; set; }
        public Agent Agent { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AgencyAgent aa &&
                   AgencyId == aa.AgencyId &&
                   AgentId == aa.AgentId &&
                   BadgeId == aa.BadgeId &&
                   ActivationDate == aa.ActivationDate &&
                   DeactivationDate == aa.DeactivationDate &&
                   IsActive == aa.IsActive &&
                   SecurityClearanceId == aa.SecurityClearanceId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(AgencyId, AgentId, BadgeId, ActivationDate, DeactivationDate, IsActive, SecurityClearanceId);
        }
    }
}
