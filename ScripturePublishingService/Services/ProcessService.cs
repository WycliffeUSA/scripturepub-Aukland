using ScripturePublishingEntity.Entities;
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

        public Process GetProcessById(int id)
        {
            return _processRepository.GetById(id);
        }
    }
}