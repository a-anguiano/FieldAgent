using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{

    [Table("Agent")]
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }

        public List<Alias> Aliases { get; set; }
        public List<MissionAgent> MissionAgents { get; set; }
        public List<AgencyAgent> AgenciesAgents { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Agent agent &&
                   AgentId == agent.AgentId &&
                   FirstName == agent.FirstName &&
                   LastName == agent.LastName &&
                   DateOfBirth == agent.DateOfBirth &&
                   Height == agent.Height &&
                   EqualityComparer<List<Alias>>.Default.Equals(Aliases, agent.Aliases);
                   //&& EqualityComparer<List<Mission>>.Default.Equals(Missions, agent.Missions);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AgentId, FirstName, LastName, DateOfBirth, Height, Aliases);
        }
    }
}
