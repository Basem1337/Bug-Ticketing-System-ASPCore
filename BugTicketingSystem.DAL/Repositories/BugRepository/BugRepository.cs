namespace BugTicketingSystem.DAL
{
    public class BugRepository : GenericRepository<Bug>, IBugRepository
    {
        private readonly DatabaseContext _ctx;

        public BugRepository(DatabaseContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
