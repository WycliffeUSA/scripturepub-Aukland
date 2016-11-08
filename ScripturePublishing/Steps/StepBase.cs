using ScripturePublishingEntity.Entities;
using ScripturePublishingEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScripturePublishing.Steps
{
    public abstract class StepBase
    {
        internal IEnumerable<Parameter> parameterData;
        internal String lastStepData;
        

        public StepBase(IEnumerable<Parameter> parameterData, String lastStepData)
        {
            this.parameterData = parameterData;
            this.lastStepData = lastStepData;
        }

        public abstract StepResult RunStep();
    }
}