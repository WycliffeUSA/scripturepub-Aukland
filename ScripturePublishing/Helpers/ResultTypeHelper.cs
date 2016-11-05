using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ScripturePublishingEntity;
using ScripturePublishingService.Factory;

namespace ScripturePublishing.Helpers
{
    public class ResultTypeHelper
    {
        public static List<SelectListItem> GetResultTypeList()
        {
            return ServiceFactory.GetResultTypeService(new WorkflowEngine()).GetResultTypes().Select(r => new SelectListItem
            {
                Value = r.ID.ToString(),
                Text = r.Description
            }).ToList();
        }

        public static List<SelectListItem> GetResultTypeList(int resultTypeId)
        {
            return ServiceFactory.GetResultTypeService(new WorkflowEngine()).GetResultTypes().Select(r => new SelectListItem
            {
                Value = r.ID.ToString(),
                Text = r.Description,
                Selected = r.ID == resultTypeId
            }).ToList();
        }
    }
}