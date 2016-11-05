
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingEntity.Repositories
{
    public class ParameterRepository : Repository<WorkflowEngine, Parameter>, IParameterRepository
    {
        public ParameterRepository(WorkflowEngine context) : base(context)
        {
        }
    }
}
