
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingEntity.Repositories
{
    public class StateRepository : Repository<WorkflowEngine, State>, IStateRepository
    {
        public StateRepository(WorkflowEngine context) : base(context)
        {
        }
    }
}
