namespace BugTicketingSystem.DAL
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public string ImgLink { get; set; } = string.Empty;
        public Guid? BugID { get; set; }
        public virtual Bug Bugs { get; set; } = null!;
    }
}
