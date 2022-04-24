using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Entities
{
    [Table("Alias")]
    public class Alias
    {
        [Key]
        public int AliasId { get; set; }
        public string AliasName { get; set; }
        public Guid InterpolId { get; set; }
        public string Persona { get; set; } //??

        public int AgentId { get; set; }
        public Agent Agent { get; set; }

    }
}
