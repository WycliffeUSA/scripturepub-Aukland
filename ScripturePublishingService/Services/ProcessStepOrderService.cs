using ScripturePublishingEntity.Repositories;

namespace ScripturePublishingService.Services
{
    public class ProcessStepOrderService : IProcessStepOrderService
    {
        private readonly IProcessStepOrderRepository _processStepOrderRepository;

        public ProcessStepOrderService(IProcessStepOrderRepository processStepOrderRepository)
        {
            _processStepOrderRepository = processStepOrderRepository;
        }
    }
}