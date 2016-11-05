using System.Collections.Generic;
using System.Web.Mvc;
using ScripturePublishing.Helpers;
using ScripturePublishing.Models;
using ScripturePublishingEntity.Entities;
using ScripturePublishingService.Services;

namespace ScripturePublishing.Controllers
{
    [Authorize]
    public class ParameterController : Controller
    {
        private readonly IParameterService _parameterService;
        private readonly IProcessStepService _processStepService;
        private readonly IUnitOfWork _uow;

        public ParameterController(
            IParameterService parameterService,
            IProcessStepService processStepService,
            IUnitOfWork uow)
        {
            _parameterService = parameterService;
            _processStepService = processStepService;
            _uow = uow;
        }

        public ActionResult Index()
        {
            var parameters = _parameterService.GetParameters();

            var parameterDtos = new List<ParameterDto>();

            foreach (var parameter in parameters)
            {
                var processStep = _processStepService.GetProcessStepById(parameter.ProcessStepId);

                parameterDtos.Add(parameter.MapDto(processStep.ID));
            }

            return View(parameterDtos);
        }

        public ActionResult Edit(int id)
        {
            var parameter = _parameterService.GetParameterById(id);
            var processStep = _processStepService.GetProcessStepById(parameter.ProcessStepId);

            return View(parameter.MapDto(processStep.ID));
        }

        [HttpPost]
        public ActionResult Index(string type, string name, string text, string processStepId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Index();

            _parameterService.Create(type, name, text, processStepId);
            _uow.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ParameterDto parameterDto)
        {
            var parameter = new Parameter
            {
                ID = parameterDto.ID,
                Name = parameterDto.Name,
                Text = parameterDto.Text,
                Type = parameterDto.Type,
                ProcessStepId = parameterDto.ProcessStepId
            };

            parameter = _parameterService.Update(parameter);
            _uow.Save();

            var processStep = _processStepService.GetProcessStepById(parameter.ProcessStepId);

            return View(parameter.MapDto(processStep.ID));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // _processService.Delete(processStep);
            return Index();
        }
    }
}