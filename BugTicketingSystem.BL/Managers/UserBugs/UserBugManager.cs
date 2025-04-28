using BugTicketingSystem.DAL;
using College.BL;

namespace BugTicketingSystem.BL
{
    public class UserBugManager : IUserBugManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBugManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralResult> AddAsync(Guid bugId,UserBugsAddDTO userBugDTO)
        {
            var newUserBug = new UserBug()
            {
                BugId = bugId,
                UserId = userBugDTO.UserId,
            };

            _unitOfWork.UserBugRepository.Add(newUserBug);
            await _unitOfWork.SaveChangesAsync();

            return new GeneralResult
            {
                Success = true,
                Errors = []
            };
        }

        public async Task<GeneralResult> DeleteAsync(Guid userId, Guid bugId)
        {
            var delUser = await _unitOfWork.UserBugRepository.getByCompositeIdAsync(userId, bugId);
            if (delUser != null)
            {
                _unitOfWork.UserBugRepository.Delete(delUser);
                await _unitOfWork.SaveChangesAsync();
            }

            return new GeneralResult
            {
                Success = true,
                Errors = []
            };
        }

        public async Task<List<UserBugReadDTO>> GetAllAsync()
        {
            var getUsers = await _unitOfWork.UserBugRepository.getAllAsync();

            return getUsers.Select(u => new UserBugReadDTO
            {
                UserId = u.UserId,
                BugId = u.BugId,
            }).ToList();
        }
    }
}
