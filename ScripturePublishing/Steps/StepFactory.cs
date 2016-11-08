using ScripturePublishingEntity.Entities;
using System;
using System.Collections.Generic;


namespace ScripturePublishing.Steps
{
    public class StepFactory
    {
        public static StepBase GetStep(String input, IEnumerable<Parameter> parameterData, String LastStepData)
        {
            switch (input)
            {
                case "DisplayMessage":
                    return new DisplayMessageStep(parameterData, LastStepData);
                case "DisplayAndShowInput":
                    return new DisplayAndShowInputStep(parameterData, LastStepData);
                default:
                    throw new Exception("No steps implemented for this action type!");
            }
        }
    }
}