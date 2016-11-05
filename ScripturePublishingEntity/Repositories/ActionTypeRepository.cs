
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingEntity.Repositories
{
    public class ActionTypeRepository : Repository<WorkflowEngine, ActionType>, IActionTypeRepository
    {
        public ActionTypeRepository(WorkflowEngine context) : base(context)
        {
        }
    }
}
