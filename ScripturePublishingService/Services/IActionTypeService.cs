using System.Collections.Generic;
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingService.Services
{
    public interface IActionTypeService
    {
        ActionType GetById(int id);

        List<ActionType> GetActionTypes();
    }
}