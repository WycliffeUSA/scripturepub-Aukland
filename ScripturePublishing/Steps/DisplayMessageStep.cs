using ScripturePublishingEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScripturePublishing.Steps
{
    public class DisplayMessageStep : StepBase
    {
        public DisplayMessageStep(IEnumerable<Parameter> parameterData, string lastStepData) : base(parameterData, lastStepData)
        {
        }

        public override StepResult RunStep()
        {
            return new StepResult("Complete", base.parameterData.Select(x=>x.Text));
        }
    }
}