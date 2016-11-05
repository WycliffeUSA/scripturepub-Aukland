using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ScripturePublishingEntity;
using ScripturePublishingService.Factory;
using ScripturePublishingService.Services;

namespace ScripturePublishing.Helpers
{
    public class ProcessHelper
    {
        private static IProcessService _processService;

        public ProcessHelper(IProcessService processService)
        {
            _processService = processService;
        }

        public static List<SelectListItem> GetProcessList()
        {
            return ServiceFactory.GetProcessService(new WorkflowEngine()).GetProcesses().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
        }

        public static List<SelectListItem> GetProcessList(int processId)
        {
            return ServiceFactory.GetProcessService(new WorkflowEngine()).GetProcesses().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Selected = p.Id == processId
            }).ToList();
        }
    }
}