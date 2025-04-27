namespace BugTicketingSystem.DAL
{
    public class Bug
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public BugRisk Risk { get; set; }
        public Guid? ProjectID { get; set; }
        public Project Projects { get; set; } = null!;
        public virtual ICollection<Attachment> Attachments { get; set; } = new HashSet<Attachment>();
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }

    public enum BugRisk
    {
        Low,
        Normal,
        Medium,
        High,
        Critical
    }
}
