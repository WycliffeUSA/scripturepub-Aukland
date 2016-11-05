
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingEntity.Repositories
{
    public class UserRepository : Repository<WorkflowEngine, User>, IUserRepository
    {
        public UserRepository(WorkflowEngine context) : base(context)
        {
        }
    }
}
