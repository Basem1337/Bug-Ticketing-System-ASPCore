using BugTicketingSystem.DAL;
using College.BL;

namespace BugTicketingSystem.BL
{
    public class ProjectManager : IProjectManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GeneralResult> AddAsync(ProjectAddDTO prjDTO)
        {
            var newPrj = new Project()
            {
                Name = prjDTO.Name,
                Status = prjDTO.Status
            };

            _unitOfWork.ProjectRepository.Add(newPrj);
            await _unitOfWork.SaveChangesAsync();

            return new GeneralResult
            {
                Success = true,
                Errors = []
            };
        }

        public async Task<List<ProjectReadDTO>> GetAllAsync()
        {
            var getPrjs = await _unitOfWork.ProjectRepository.getAllAsync();

            return getPrjs.Select(p => new ProjectReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Status = p.Status
            }).ToList();
        }

        public async Task<ProjectReadDTO?> GetProjectByIDAsync(Guid id)
        {
            var prj = await _unitOfWork.ProjectRepository.getByIdAsync(id);
            if (prj is null)
            {
                return null;
            }

            return new ProjectReadDTO
            {
                Id = prj.Id,
                Name = prj.Name,
                Status = prj.Status,
                Bugs = prj.Bugs.Select(b => new BugReadDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Risk = b.Risk,
                }).ToList() ?? new List<BugReadDTO>()
            };
        }
    }
}
