namespace BugTicketingSystem.DAL
{
    public class UserBugRepository : GenericRepository<UserBug>, IUserBugRepository
    {
        private readonly DatabaseContext _ctx;

        public UserBugRepository(DatabaseContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
