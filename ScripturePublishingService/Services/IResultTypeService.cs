using System.Collections.Generic;
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingService.Services
{
    public interface IResultTypeService
    {
        ResultType GetById(int id);

        List<ResultType> GetResultTypes();
    }
}