using System;
using System.Collections.Generic;
using System.Linq;

namespace ScripturePublishing.Steps
{
    public class StepResult
    {
        public StepResult(String resultText)
        {
            ResultText = resultText;
        }

        public StepResult(String resultText, IEnumerable<String> PageMessages)
        {
            ResultText = resultText;
        }

        public String ResultText { get; private set; }

        public String DataToPersist { get; set; }

        public IEnumerable<String> PageMessages;

        public bool DisplayToUser
        {
            get
            {
                return !PageMessages.Any();
            }
        }
    }
}