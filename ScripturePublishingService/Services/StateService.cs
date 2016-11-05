using ScripturePublishingEntity.Repositories;

namespace ScripturePublishingService.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
    }
}