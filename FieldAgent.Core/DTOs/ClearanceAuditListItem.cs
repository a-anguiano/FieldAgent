namespace FieldAgent.Core
{
    public class ClearanceAuditListItem
    {
        public Guid BadgeId { get; set; }
        public string NameLastFirst { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime? DeactivationDate { get; set; }
    }
}