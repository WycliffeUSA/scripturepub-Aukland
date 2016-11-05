using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ScripturePublishingEntity;
using ScripturePublishingService.Factory;

namespace ScripturePublishing.Helpers
{
    public class ProcessStepHelper
    {
        public static List<SelectListItem> GetProcessStepList()
        {
            var processStepList = ServiceFactory.GetProcessStepService(new WorkflowEngine()).GetProcessSteps().Select(p => new SelectListItem
            {
                Value = p.ID.ToString(),
                Text = p.ID.ToString()
            }).ToList();

            processStepList.Insert(0, new SelectListItem {Value = "", Text = ""});

            return processStepList;
        }

        public static List<SelectListItem> GetProcessStepList(int? processStepId)
        {
            var processStepList = ServiceFactory.GetProcessStepService(new WorkflowEngine()).GetProcessSteps().Select(p => new SelectListItem
            {
                Value = p.ID.ToString(),
                Text = p.ID.ToString(),
                Selected = p.ID == processStepId
            }).ToList();

            processStepList.Insert(0, new SelectListItem { Value = "", Text = "", Selected = !processStepId.HasValue});

            return processStepList;
        }
    }
}