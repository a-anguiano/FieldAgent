using System.ComponentModel.DataAnnotations;

namespace FieldAgent.Web.Models
{
    public class AliasModel
    {
        public int AliasId { get; set; }

        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string AliasName { get; set; }
        public Guid InterpolId { get; set; }
        public string Persona { get; set; }

        [Required(ErrorMessage = "Agent Id is required")]
        public int AgentId { get; set; }
        //public Agent Agent { get; set; }
    }
}
