using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services;
using ScripturePublishing.Helpers;
using ScripturePublishing.Models;
using ScripturePublishingEntity.Entities;
using ScripturePublishingService.Services;

namespace ScripturePublishing.Controllers
{
    public class ProcessStepController : Controller
    {
        private readonly IProcessStepService _processStepService;
        private readonly IActionTypeService _actionTypeService;
        private readonly IProcessService _processService;
        private readonly IUnitOfWork _uow;

        public ProcessStepController(
            IProcessStepService processStepService,
            IActionTypeService actionTypeService,
            IProcessService processService,
            IUnitOfWork uow)
        {
            _processStepService = processStepService;
            _actionTypeService = actionTypeService;
            _processService = processService;
            _uow = uow;
        }

        public ActionResult Index()
        {
            var processSteps = _processStepService.GetProcessSteps();

            var processStepDtos = new List<ProcessStepDto>();

            foreach (var processStep in processSteps)
            {
                var actionType = _actionTypeService.GetById(processStep.ActionTypeID);
                var process = _processService.GetProcessById(processStep.ProcessID);

                processStepDtos.Add(processStep.MapDto(actionType.ActionName, process.Name));
            }

            return View(processStepDtos);
        }

        public ActionResult Edit(int id)
        {
            var processStep = _processStepService.GetProcessStepById(id);
            var actionType = _actionTypeService.GetById(processStep.ActionTypeID);
            var process = _processService.GetProcessById(processStep.ProcessID);

            return View(processStep.MapDto(actionType.ActionName, process.Name));
        }

        [HttpPost]
        public ActionResult Index(string actionTypeId, string processId)
        {
            if (string.IsNullOrWhiteSpace(actionTypeId) || string.IsNullOrWhiteSpace(processId))
                return Index();

            _processStepService.Create(actionTypeId, processId);
            _uow.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ProcessStepDto processStepDto)
        {
            var processStep = new ProcessStep
            {
                ID = processStepDto.ID,
                ProcessID = processStepDto.ProcessId,
                ActionTypeID = processStepDto.ActionTypeId
            };

            processStep = _processStepService.Update(processStep);
            _uow.Save();

            var actionType = _actionTypeService.GetById(processStep.ActionTypeID);
            var process = _processService.GetProcessById(processStep.ProcessID);

            return View(processStep.MapDto(actionType.ActionName, process.Name));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // _processService.Delete(processStep);
            return Index();
        }

        public List<SelectListItem> GetActionTypeList()
        {
            return _actionTypeService.GetActionTypes().Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = a.ActionName
            }).ToList();
        }

        public List<SelectListItem> GetActionTypeList(int actionTypeId)
        {
            return _actionTypeService.GetActionTypes().Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = a.ActionName,
                Selected = a.ID == actionTypeId
            }).ToList();
        }

        public List<SelectListItem> GetProcessList()
        {
            return _processService.GetProcesses().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
        }

        public List<SelectListItem> GetProcessList(int processId)
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