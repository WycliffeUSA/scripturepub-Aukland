using ScripturePublishingEntity.Repositories;

namespace ScripturePublishingService.Services
{
    public class ProcessStepService : IProcessStepService
    {
        private readonly IProcessStepRepository _processStepRepository;

        public ProcessStepService(IProcessStepRepository processStepRepository)
        {
            _processStepRepository = processStepRepository;
        }
    }
}