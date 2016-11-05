using ScripturePublishingEntity.Entities;

namespace ScripturePublishingEntity.Repositories
{
    public class ProcessStepRepository : Repository<WorkflowEngine, ProcessStep>, IProcessStepRepository
    {
        public ProcessStepRepository(WorkflowEngine context) : base(context)
        {
        }
    }
}
