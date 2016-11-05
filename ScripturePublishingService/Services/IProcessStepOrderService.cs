using System.Collections.Generic;
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingService.Services
{
    public interface IProcessStepOrderService
    {
        List<ProcessStepOrder> GetProcessStepOrderings();

        ProcessStepOrder GetProcessStepOrderById(int id);

        ProcessStepOrder Create(string lastProcessStepId, string nextProcessStepId, string resultTypeId);

        ProcessStepOrder Update(ProcessStepOrder processStepOrder);

        void Delete(ProcessStepOrder processStepOrder);
    }
}