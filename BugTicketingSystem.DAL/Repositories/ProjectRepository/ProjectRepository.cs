namespace BugTicketingSystem.DAL
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly DatabaseContext _ctx;

        public ProjectRepository(DatabaseContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
