using ScripturePublishingEntity.Repositories;

namespace ScripturePublishingService.Services
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterService(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }
    }
}