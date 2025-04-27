namespace BugTicketingSystem.DAL
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? Salary { get; set; }
        public int? Age { get; set; }
        public UserRole Role { get; set; }
        public virtual ICollection<Bug> Bugs { get; set; } = new HashSet<Bug>();

    }

    public enum UserRole
    {
        Manager,
        Developer,
        Tester
    }
}
