
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingEntity.Repositories
{
    public class ResultTypeRepository : Repository<WorkflowEngine, ResultType>, IResultTypeRepository
    {
        public ResultTypeRepository(WorkflowEngine context) : base(context)
        {
        }
    }
}
