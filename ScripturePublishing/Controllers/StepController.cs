using ScripturePublishing.Steps;
using ScripturePublishingEntity.Entities;
using ScripturePublishingEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using ScripturePublishingService.Services;


namespace ScripturePublishing.Controllers
{
    [Authorize]
    public class StepController : Controller
    {
        IResultTypeRepository _resultTypeRepository;
        IStateRepository _stateRepository;
        IProcessStepRepository _processStepRepository;
        IProcessRepository _processRepository;
        IParameterRepository _parametersRepository;
        IProcessStepOrderRepository _processStepOrderRepository;
        IUnitOfWork _unitOfWork;
        IActionTypeRepository _actionTypeRepository;

        public StepController(IResultTypeRepository resultTypeRepository, IStateRepository stateRepository, IProcessStepRepository processStepRepository, IProcessRepository processRepository, IParameterRepository parameterRepository, IProcessStepOrderRepository processStepOrderRepository, IUnitOfWork unitOfWork, IActionTypeRepository actionTypeRepository) {
            _resultTypeRepository = resultTypeRepository;
            _stateRepository = stateRepository;
            _processStepRepository = processStepRepository;
            _processRepository = processRepository;
            _parametersRepository = parameterRepository;
            _processStepOrderRepository = processStepOrderRepository;
            _unitOfWork = unitOfWork;
            _actionTypeRepository = actionTypeRepository;
        }
        
        public ActionResult Index()
        {
            var stateData = GetCurrentStateData();
            if(stateData == null)
            {
                GenerateProcessedDropdown();
                return View("ChooseProcess");
            }

            StepResult result = null;
            bool returnToPage = false;


            while (!returnToPage)
            {
                var processStep = _processStepRepository.GetById(stateData.ProcessStepID);

                var processType = _actionTypeRepository.GetById(processStep.ActionTypeID).ActionName;
                var parameterData = GetParameterDataForProcessStep(processStep.ID);

                var step = StepFactory.GetStep(processType, parameterData, stateData.LastStepData);
                result = step.RunStep();


                var nextStep = GetNextStep(processStep.ID, stateData.ProcessID, result.ResultText);

                ProgressState(stateData.ID, nextStep, result.DataToPersist);
                returnToPage = result.DisplayToUser;
            }

            ViewBag.MessageLines = String.Join("<br />", result.PageMessages);
            return View("index");
        }

        [HttpPost]
        public ActionResult Index(int processId)
        {
            var state = GenerateNewState(processId);
            _stateRepository.Add(state);
            _unitOfWork.Save();
            return Index();
        }

        private void GenerateProcessedDropdown()
        {
            ViewBag.Processes = _processRepository.Get().Select(process => new SelectListItem() {Text=process.Name, Value=process.Id.ToString() });
        }

        private void ProgressState(int stateId, int stepId, String dataToPersist)
        {
            var state = _stateRepository.GetById(stateId);
            state.ProcessStepID = stepId;
            state.LastStepData = dataToPersist;
            _unitOfWork.Save();
        }

        private IEnumerable<Parameter> GetParameterDataForProcessStep(int processStepId)
        {
            return _parametersRepository.Get(x => x.ProcessStepId == processStepId);
        }


        public int GetNextStep(int stepId, int processId, String resultType)
        {
            var appropriateAction = _resultTypeRepository.Get(x => x.Description == resultType);
            if (!appropriateAction.Any())
            {
                throw new Exception("Appropriate action not found!");
            }

            int resultTypeId = appropriateAction.First().ID;

            return _processStepOrderRepository.Get(x => x.LastProcessStepID == stepId && x.ResultTypeID == resultTypeId).FirstOrDefault().NextProcessStepID.Value;
        }

        public State GetCurrentStateData()
        {
            return _stateRepository.Get().FirstOrDefault(x => x.UserID == GetUserID());
        }
        
        public String GetUserID()
        {
            //return (String)Membership.GetUser(User.Identity.Name).ProviderUserKey;
            return User.Identity.GetUserId();
        }

        public State GenerateNewState(int processId)
        {
            var state = new State();
            state.ProcessID = processId;
            state.UserID = GetUserID();
            state.ProcessStepID = (from step in _processStepRepository.Get().ToList() select step.ID).Min();
            return state;
        }

    }
}