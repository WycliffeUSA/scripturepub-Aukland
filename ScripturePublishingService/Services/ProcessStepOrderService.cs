using System.Collections.Generic;
using System.Linq;
using ScripturePublishingEntity.Entities;
using ScripturePublishingEntity.Repositories;

namespace ScripturePublishingService.Services
{
    public class ProcessStepOrderService : IProcessStepOrderService
    {
        private readonly IProcessStepOrderRepository _processStepOrderRepository;

        public ProcessStepOrderService(IProcessStepOrderRepository processStepOrderRepository)
        {
            _processStepOrderRepository = processStepOrderRepository;
        }

        public List<ProcessStepOrder> GetProcessStepOrderings()
        {
            return _processStepOrderRepository.Get().ToList();
        }

        public ProcessStepOrder GetProcessStepOrderById(int id)
        {
            return _processStepOrderRepository.GetById(id);
        }

        public ProcessStepOrder Create(string lastProcessStepId, string nextProcessStepId, string resultTypeId)
        {
            var processStepOrder = new ProcessStepOrder
            {
                LastProcessStepID = !string.IsNullOrWhiteSpace(lastProcessStepId)
                    ? int.Parse(lastProcessStepId)
                    : (int?)null,
                NextProcessStepID = !string.IsNullOrWhiteSpace(nextProcessStepId)
                    ? int.Parse(nextProcessStepId)
                    : (int?)null,
                ResultTypeID = int.Parse(resultTypeId)
            };

            return _processStepOrderRepository.Add(processStepOrder);
        }

        public ProcessStepOrder Update(ProcessStepOrder processStepOrder)
        {
            return _processStepOrderRepository.Update(processStepOrder);
        }

        public void Delete(ProcessStepOrder processStepOrder)
        {
            _processStepOrderRepository.Delete(processStepOrder);
        }
    }
}