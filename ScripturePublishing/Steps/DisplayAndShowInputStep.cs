using ScripturePublishingEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScripturePublishing.Steps
{
    public class DisplayAndShowInputStep : StepBase
    {
        public DisplayAndShowInputStep(IEnumerable<Parameter> parameterData, string lastStepData) : base(parameterData, lastStepData)
        {
        }

        public override StepResult RunStep()
        {
            var messages = base.parameterData.Select(x => x.Type == "Display" ? x.Text : InputWrap(x.Name, x.Text));
            return new StepResult("Complete", messages);
        }

        public String InputWrap(String elementName, String placeholderText)
        {
            return String.Format("<input type='text' name='{0}' id='{0}' placeholder='{1}'> </input>", elementName, placeholderText);
        }
    }
}