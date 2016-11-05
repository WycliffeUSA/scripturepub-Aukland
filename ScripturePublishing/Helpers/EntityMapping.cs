using ScripturePublishing.Models;
using ScripturePublishingEntity.Entities;

namespace ScripturePublishing.Helpers
{
    public static class EntityMapping
    {
        public static ProcessStepDto MapDto(this ProcessStep processStep, string actionTypeName, string processName)
        {
            return new ProcessStepDto
            {
                ID = processStep.ID,
                ActionTypeId = processStep.ActionTypeID,
                ActionTypeName = actionTypeName,
                ProcessId = processStep.ProcessID,
                ProcessName = processName
            };
        }

        public static ProcessStepOrderDto MapDto(this ProcessStepOrder processStepOrder, string resultTypeDescription)
        {
            return new ProcessStepOrderDto
            {
                ID = processStepOrder.ID,
                LastProcessStepId = processStepOrder.LastProcessStepID,
                NextProcessStepId = processStepOrder.NextProcessStepID,
                ResultTypeId = processStepOrder.ResultTypeID,
                ResultTypeDescription = resultTypeDescription
            };
        }
    }
}