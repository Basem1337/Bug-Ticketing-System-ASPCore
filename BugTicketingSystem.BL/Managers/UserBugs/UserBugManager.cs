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

        public Task<GeneralResult> AddAsync(UserBugsAddDTO userBugDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserBug userBugDTO)
        {
            throw new NotImplementedException();
        }
    }
}
