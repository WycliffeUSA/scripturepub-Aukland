using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScripturePublishing.Steps
{
    public class DisplayAndShowInputStep : StepBase
    {
        public DisplayAndShowInputStep(Dictionary<string, string> parameterData, string lastStepData) : base(parameterData, lastStepData)
        {
        }

        public override StepResult RunStep()
        {
            var messages = base.parameterData.Select(x => x.Key == "Display" ? x.Value : InputWrap(x.Value));
            return new StepResult("Complete", messages);
        }

        public String InputWrap(String input)
        {
            return String.Format("<input type='text' name='{0}' id='{0}'> </input>", input);
        }
    }
}