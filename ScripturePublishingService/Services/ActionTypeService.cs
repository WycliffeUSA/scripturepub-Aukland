using System.Collections.Generic;
using System.Linq;
using ScripturePublishingEntity.Entities;
using ScripturePublishingEntity.Repositories;

namespace ScripturePublishingService.Services
{
    public class ActionTypeService : IActionTypeService
    {
        private readonly IActionTypeRepository _actionTypeRepository;

        public ActionTypeService(IActionTypeRepository actionTypeRepository)
        {
            _actionTypeRepository = actionTypeRepository;
        }

        public ActionType GetById(int id)
        {
            return _actionTypeRepository.GetById(id);
        }

        public List<ActionType> GetActionTypes()
        {
            return _actionTypeRepository.Get().ToList();
        }
    }
}