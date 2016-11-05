using System.Collections.Generic;
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingService.Services
{
    public interface IParameterService
    {
        Parameter GetParameterById(int id);

        List<Parameter> GetParameters();

        Parameter Create(string type, string name, string text, string processStepId);

        Parameter Update(Parameter parameter);

        void Delete(Parameter parameter);
    }
}