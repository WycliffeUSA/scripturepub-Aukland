using System.Collections.Generic;
using System.Web.Mvc;
using ScripturePublishing.Helpers;
using ScripturePublishing.Models;
using ScripturePublishingEntity.Entities;
using ScripturePublishingService.Services;

namespace ScripturePublishing.Controllers
{
    [Authorize]
    public class ProcessStepOrderController : Controller
    {
        private readonly IProcessStepOrderService _processStepOrderService;
        private readonly IResultTypeService _resultTypeService;
        private readonly IUnitOfWork _uow;

        public ProcessStepOrderController(
            IProcessStepOrderService processStepOrderService,
            IResultTypeService resultTypeService,
            IUnitOfWork uow)
        {
            _processStepOrderService = processStepOrderService;
            _resultTypeService = resultTypeService;
            _uow = uow;
        }

        public ActionResult Index()
        {
            var processStepOrderings = _processStepOrderService.GetProcessStepOrderings();

            var processStepOrderingDtos = new List<ProcessStepOrderDto>();

            foreach (var processStepOrdering in processStepOrderings)
            {
                var resultType = _resultTypeService.GetById(processStepOrdering.ResultTypeID);

                processStepOrderingDtos.Add(processStepOrdering.MapDto(resultType.Description));
            }

            return View(processStepOrderingDtos);
        }

        public ActionResult Edit(int id)
        {
            var processStepOrdering = _processStepOrderService.GetProcessStepOrderById(id);
            var resultType = _resultTypeService.GetById(processStepOrdering.ResultTypeID);

            return View(processStepOrdering.MapDto(resultType.Description));
        }

        [HttpPost]
        public ActionResult Index(string lastProcessStepId, string nextProcessStepId, string resultTypeId)
        {
            if (string.IsNullOrWhiteSpace(lastProcessStepId) && string.IsNullOrWhiteSpace(nextProcessStepId))
                return Index();

            _processStepOrderService.Create(lastProcessStepId, nextProcessStepId, resultTypeId);
            _uow.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ProcessStepOrderDto processStepOrderDto)
        {
            var processStepOrder = new ProcessStepOrder
            {
                ID = processStepOrderDto.ID,
                LastProcessStepID = processStepOrderDto.LastProcessStepId,
                NextProcessStepID = processStepOrderDto.NextProcessStepId,
                ResultTypeID =  processStepOrderDto.ResultTypeId
            };

            processStepOrder = _processStepOrderService.Update(processStepOrder);
            _uow.Save();

            var resultType = _resultTypeService.GetById(processStepOrder.ResultTypeID);

            return View(processStepOrder.MapDto(resultType.Description));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // _processService.Delete(processStep);
            return Index();
        }
    }
}