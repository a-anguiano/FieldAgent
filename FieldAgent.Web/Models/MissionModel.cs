using FieldAgent.Web.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace FieldAgent.Web.Models
{
    public class MissionModel
    {
        public int MissionId { get; set; }

        [Required(ErrorMessage = "Code Name is required")]
        [StringLength(50, ErrorMessage = "Code Name cannot exceed 50 characters")]
        public string CodeName { get; set; }
        public string Notes { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [Date]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Projected End Date is required")]
        [Date]
        public DateTime ProjectedEndDate { get; set; }

        [Date]
        public DateTime ActualEndDate { get; set; }

        [PositiveDecimal]
        public decimal OperationalCost { get; set; }

        [Required(ErrorMessage = "Agent Id is required")]
        public int AgentId { get; set; } //consider MissionAgent table
        public int AgencyId { get; set; }   //FK
        //public Agency Agency { get; set; }
    }
}
