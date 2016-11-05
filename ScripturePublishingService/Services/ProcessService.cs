using ScripturePublishingEntity.Repositories;

namespace ScripturePublishingService.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _processRepository;

        public ProcessService(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }
    }
}