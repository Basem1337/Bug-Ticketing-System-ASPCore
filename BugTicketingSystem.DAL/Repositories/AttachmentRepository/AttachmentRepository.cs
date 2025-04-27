namespace BugTicketingSystem.DAL
{
    public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
    {
        private readonly DatabaseContext _ctx;

        public AttachmentRepository(DatabaseContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
