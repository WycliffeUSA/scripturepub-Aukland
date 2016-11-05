using ScripturePublishingEntity;
using ScripturePublishingEntity.Repositories;
using ScripturePublishingService.Services;

namespace ScripturePublishingService.Factory
{
    public class ServiceFactory
    {
        public static ActionTypeService GetActionTypeService(WorkflowEngine context)
        {
            return new ActionTypeService(new ActionTypeRepository(context));
        }

        public static ProcessService GetProcessService(WorkflowEngine context)
        {
            return new ProcessService(new ProcessRepository(context));
        }

        public static ProcessStepService GetProcessStepService(WorkflowEngine context)
        {
            return new ProcessStepService(new ProcessStepRepository(context));
        }

        public static ResultTypeService GetResultTypeService(WorkflowEngine context)
        {
            return new ResultTypeService(new ResultTypeRepository(context));
        }
    }
}
