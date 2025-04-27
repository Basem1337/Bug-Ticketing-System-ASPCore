using BugTicketingSystem.DAL;
using College.BL;

namespace BugTicketingSystem.BL
{
    public interface IAttachmentManager
    {
        Task<List<AttachmentReadDTO>> GetAllAsync();
        Task<GeneralResult> AddAsync(AttachmentAddDTO attDTO);
        Task DeleteAsync(Attachment attDTO);
    }
}
