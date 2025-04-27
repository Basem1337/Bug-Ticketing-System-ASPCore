using BugTicketingSystem.DAL;
using College.BL;

namespace BugTicketingSystem.BL
{
    public interface IUserManager
    {
        Task<List<UserReadDTO>> GetAllAsync();
        Task<GeneralResult> AddAsync(UserRegisterDTO userDTO);
        Task UpdateAsync(UserUpdateDTO userDTO);
        Task ManagerUpdateAsync(UserManagerUpdateDTO userDTO);
        Task DeleteAsync(User userDTO);
    }
}
