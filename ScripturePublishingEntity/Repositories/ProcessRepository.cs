
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingEntity.Repositories
{
    public class ProcessRepository : Repository<WorkflowEngine, Process>, IProcessRepository
    {
        public ProcessRepository(WorkflowEngine context) : base(context)
        {
        }
    }
}
