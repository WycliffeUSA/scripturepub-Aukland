using System.Collections.Generic;
using System.Linq;
using ScripturePublishingEntity.Entities;
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

        public ResultType GetById(int id)
        {
            return _resultTypeRepository.GetById(id);
        }

        public List<ResultType> GetResultTypes()
        {
            return _resultTypeRepository.Get().ToList();
        }
    }
}