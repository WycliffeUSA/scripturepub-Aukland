using ScripturePublishingEntity.Repositories;

namespace ScripturePublishingService.Services
{
    public class ResultTypeService : IResultTypeService
    {
        private readonly IResultTypeRepository _resultTypeRepository;

        public ResultTypeService(IResultTypeRepository resultTypeRepository)
        {
            _resultTypeRepository = resultTypeRepository;
        }
    }
}