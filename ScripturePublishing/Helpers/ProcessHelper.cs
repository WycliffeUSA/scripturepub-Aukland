using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
            return _processService.GetProcesses().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
        }

        public static List<SelectListItem> GetProcessList(int processId)
        {
            return _processService.GetProcesses().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Selected = p.Id == processId
            }).ToList();
        }
    }
}