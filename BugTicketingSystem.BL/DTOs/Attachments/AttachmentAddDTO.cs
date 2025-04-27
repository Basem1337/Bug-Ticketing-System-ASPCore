using BugTicketingSystem.DAL;

namespace BugTicketingSystem.BL
{
    public class AttachmentAddDTO
    {
        public string ImgLink { get; set; } = string.Empty;
        public Guid? BugID { get; set; }
    }
}
