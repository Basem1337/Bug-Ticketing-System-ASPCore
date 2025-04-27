using BugTicketingSystem.DAL;
using College.BL;

namespace BugTicketingSystem.BL
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GeneralResult> AddAsync(UserRegisterDTO userDTO)
        {
            var newUser = new User()
            {
                Name = userDTO.Name,
                Age = userDTO.Age,
                Email = userDTO.Email,
                Password = userDTO.Password
            };

            _unitOfWork.UserRepository.Add(newUser);
            await _unitOfWork.SaveChangesAsync();

            return new GeneralResult
            {
                Success = true,
                Errors = []
            };
        }

        public async Task DeleteAsync(User userDTO)
        {
            var delUser = await _unitOfWork.UserRepository.getByIdAsync(userDTO.Id);
            if (delUser != null)
            {
                _unitOfWork.UserRepository.Delete(userDTO);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<List<UserReadDTO>> GetAllAsync()
        {
            var getUsers = await _unitOfWork.UserRepository.getAllAsync();

            return getUsers.Select(u => new UserReadDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
            }).ToList();
        }

        public async Task ManagerUpdateAsync(UserManagerUpdateDTO userDTO)
        {
            var updateUser = await _unitOfWork.UserRepository.getByIdAsync(userDTO.Id);

            if (updateUser is null)
            {
                return;
            }
            else
            {
                updateUser.Name = userDTO.Name;
                updateUser.Email = userDTO.Email;
                updateUser.Age = userDTO.Age;
                updateUser.Salary = userDTO.Salary;
                updateUser.Role = userDTO.Role;

                _unitOfWork.UserRepository.Update(updateUser);

                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(UserUpdateDTO userDTO)
        {
            var updateUser = await _unitOfWork.UserRepository.getByIdAsync(userDTO.Id);

            if (updateUser is null)
            {
                return;
            }
            else
            {
                updateUser.Name = userDTO.Name;
                updateUser.Email = userDTO.Email;
                updateUser.Age = userDTO.Age;
                updateUser.Password = userDTO.Password;

                _unitOfWork.UserRepository.Update(updateUser);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
