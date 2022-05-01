using FieldAgent.Web.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace FieldAgent.Web.Models
{
    public class AgentModel
    {
        public int AgentId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [PastDate]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [PositiveDecimal]
        public decimal Height { get; set; }
    }
}
