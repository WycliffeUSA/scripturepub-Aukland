using ScripturePublishing.Steps;
using ScripturePublishingEntity.Entities;
using ScripturePublishingEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

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

        public StepController(IResultTypeRepository resultTypeRepository, IStateRepository stateRepository, IProcessStepRepository processStepRepository, IProcessRepository processRepository, IParameterRepository parameterRepository, IProcessStepOrderRepository processStepOrderRepository) {
            _resultTypeRepository = resultTypeRepository;
            _stateRepository = stateRepository;
            _processStepRepository = processStepRepository;
            _processRepository = processRepository;
            _parametersRepository = parameterRepository;
            _processStepOrderRepository = processStepOrderRepository;
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

                var processType = _processRepository.GetById(processStep.ActionTypeID).Name;
                var parameterData = GetParameterDataForProcessStep(processStep.ID);

                var step = StepFactory.GetStep(processType, parameterData, stateData.LastStepData);
                result = step.RunStep();


                var nextStep = GetNextStep(processStep.ID, stateData.ProcessID, result.ResultText);

                ProgressState(stateData.ID, nextStep, result.DataToPersist);
                returnToPage = result.DisplayToUser;
            }

            ViewBag.Mesages = result.PageMessages;
            return View("index");
        }

        [HttpPost]
        public ActionResult Index(int processId)
        {
            var state = GenerateNewState(processId);
            _stateRepository.Add(state);

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
        }

        private Dictionary<String, String> GetParameterDataForProcessStep(int processStepId)
        {
            return _parametersRepository.Get(x => x.ProcessStepId == processStepId).ToDictionary(x => x.Name, x => x.Text);
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