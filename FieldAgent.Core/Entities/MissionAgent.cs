using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    [Table("MissionAgent")]
    public class MissionAgent
    {
        public int MissionId { get; set; }
        public int AgentId { get; set; }

        public Mission Mission { get; set; }
        public Agent Agent { get; set; }
    }
}
