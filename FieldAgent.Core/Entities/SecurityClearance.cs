using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    [Table("SecurityClearance")]
    public class SecurityClearance
    {
        [Key]
        public int SecurityClearanceId { get; set; }
        public string SecurityClearanceName { get; set; }

        public List<SecurityClearance> SecurityClearances { get; set; }
    }
}
