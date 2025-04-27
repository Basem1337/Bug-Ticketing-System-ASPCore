using BugTicketingSystem.DAL;
using College.BL;

namespace BugTicketingSystem.BL
{
    public class BugManager : IBugManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public BugManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GeneralResult> AddAsync(BugAddDTO BugDTO)
        {
            var newBug = new Bug()
            {
                Name = BugDTO.Name,
                Risk = BugDTO.Risk,
                ProjectID = BugDTO.ProjectID
            };

            _unitOfWork.BugRepository.Add(newBug);
            await _unitOfWork.SaveChangesAsync();

            return new GeneralResult
            {
                Success = true,
                Errors = []
            };
        }

        public async Task<List<BugReadDTO>> GetAllAsync()
        {
            var getBugs = await _unitOfWork.BugRepository.getAllAsync();

            return getBugs.Select(b => new BugReadDTO
            {
                Id = b.Id,
                Name = b.Name,
                Risk = b.Risk,
                ProjectID = b.ProjectID
            }).ToList();
        }

        public async Task<BugReadDTO?> GetBugByIDAsync(Guid id)
        {
            var bug = await _unitOfWork.BugRepository.getByIdAsync(id);
            if (bug is null)
            {
                return null;
            }

            return new BugReadDTO
            {
                Id = bug.Id,
                Name = bug.Name,
                Risk = bug.Risk,
                ProjectID = bug.ProjectID,
                Attachments = bug.Attachments.Select(a => new AttachmentReadDTO
                {
                    Id = a.Id,
                    ImgLink = a.ImgLink
                }).ToList() ?? new List<AttachmentReadDTO>()
            };
        }
    }
}
