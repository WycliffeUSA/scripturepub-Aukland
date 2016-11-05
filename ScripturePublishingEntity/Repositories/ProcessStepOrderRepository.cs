
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingEntity.Repositories
{
    public class ProcessStepOrderRepository : Repository<WorkflowEngine, ProcessStepOrder>, IProcessStepOrderRepository
    {
        public ProcessStepOrderRepository(WorkflowEngine context) : base(context)
        {
        }
    }
}
