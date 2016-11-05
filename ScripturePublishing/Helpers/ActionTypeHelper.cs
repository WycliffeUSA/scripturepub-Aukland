using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ScripturePublishingService.Services;

namespace ScripturePublishing.Helpers
{
    public class ActionTypeHelper
    {
        private static IActionTypeService _actionTypeService;

        public ActionTypeHelper(IActionTypeService actionTypeService)
        {
            _actionTypeService = actionTypeService;
        }

        public static List<SelectListItem> GetActionTypeList()
        {
            return _actionTypeService.GetActionTypes().Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = a.ActionName
            }).ToList();
        }

        public static List<SelectListItem> GetActionTypeList(int actionTypeId)
        {
            return _actionTypeService.GetActionTypes().Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = a.ActionName,
                Selected = a.ID == actionTypeId
            }).ToList();
        }
    }
}