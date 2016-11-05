using System.Web.Mvc;
using ScripturePublishingEntity.Entities;
using ScripturePublishingService.Services;

namespace ScripturePublishing.Controllers
{
    public class ProcessController : Controller
    {
        private readonly IProcessService _processService;
        private readonly IUnitOfWork _uow;

        public ProcessController(
            IProcessService processService,
            IUnitOfWork uow)
        {
            _processService = processService;
            _uow = uow;
        }

        public ActionResult Index()
        {
            var processes = _processService.GetProcesses();
            return View(processes);
        }

        public ActionResult Edit(int id)
        {
            var process = _processService.GetProcessById(id);
            return View(process);
        }

        [HttpPost]
        public ActionResult Index(string name, int? version)
        {
            if (string.IsNullOrWhiteSpace(name) || !version.HasValue)
                return Index();

            _processService.Create(name, version.Value);
            _uow.Save();

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult Edit(Process process)
        {
            process = _processService.Update(process);
            _uow.Save();
            return View(process);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
           // _processService.Delete(process);
            return Index();
        }
    }
}