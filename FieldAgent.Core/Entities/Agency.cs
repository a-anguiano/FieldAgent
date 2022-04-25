using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    [Table("Agency")]
    public class Agency
    {
        [Key]
        public int AgencyId { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }

        public List<Location> Locations { get; set; }
        public List<Mission> Missions { get; set; }
        public override bool Equals(object obj)
        {
            return obj is Agency agency &&
                   AgencyId == agency.AgencyId &&
                   ShortName == agency.ShortName &&
                   LongName == agency.LongName &&
                   EqualityComparer<List<Location>>.Default.Equals(Locations, agency.Locations) &&
                   EqualityComparer<List<Mission>>.Default.Equals(Missions, agency.Missions);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(AgencyId, ShortName, LongName, Locations, Missions);
        }
    }
}
