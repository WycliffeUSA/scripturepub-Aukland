using System.Collections.Generic;
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingService.Services
{
    public interface IProcessStepService
    {
        ProcessStep GetProcessStepById(int id);

        List<ProcessStep> GetProcessSteps();

        ProcessStep Create(string actionTypeId, string processId);

        ProcessStep Update(ProcessStep processStep);

        void Delete(ProcessStep processStep);
    }
}