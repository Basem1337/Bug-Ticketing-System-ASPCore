using BugTicketingSystem.DAL;
using College.BL;

namespace BugTicketingSystem.BL
{
    public interface IUserBugManager
    {
        Task<GeneralResult> AddAsync(UserBugsAddDTO userBugDTO);
        Task DeleteAsync(UserBug userBugDTO);
    }
}
