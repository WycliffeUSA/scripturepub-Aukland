using ScripturePublishingEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScripturePublishing.Steps
{
    public abstract class StepBase
    {
        internal Dictionary<String, String> parameterData;
        internal String lastStepData;
        

        public StepBase(Dictionary<String, String> parameterData, String lastStepData)
        {
           
        }

        public abstract StepResult RunStep();
    }
}