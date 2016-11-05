using System.Web.Mvc;
using ScripturePublishingService.Services;

namespace ScripturePublishing.Controllers
{
    public class ManagementController : Controller
    {
        private readonly IProcessService _processService;

        public ManagementController(IProcessService processService)
        {
            _processService = processService;
        }
        
        public ActionResult Index()
        {
            var process = _processService.GetProcessById(1);
            return View(process);
        }
    }
}