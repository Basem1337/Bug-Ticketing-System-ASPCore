using BugTicketingSystem.DAL;
using College.BL;

namespace BugTicketingSystem.BL
{
    public class AttachmentManager : IAttachmentManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttachmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<GeneralResult> AddAsync(AttachmentAddDTO attDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Attachment attDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<AttachmentReadDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
