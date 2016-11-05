using System.Collections.Generic;
using System.Linq;
using ScripturePublishingEntity.Entities;
using ScripturePublishingEntity.Repositories;

namespace ScripturePublishingService.Services
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterService(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public Parameter GetParameterById(int id)
        {
            return _parameterRepository.GetById(id);
        }

        public List<Parameter> GetParameters()
        {
            return _parameterRepository.Get().ToList();
        }

        public Parameter Create(string type, string name, string text, string processStepId)
        {
            var parameter = new Parameter
            {
                Name = name,
                Text = text,
                Type = type,
                ProcessStepId = int.Parse(processStepId)
            };

            return _parameterRepository.Add(parameter);
        }

        public Parameter Update(Parameter parameter)
        {
            return _parameterRepository.Update(parameter);
        }

        public void Delete(Parameter parameter)
        {
            _parameterRepository.Delete(parameter);
        }
    }
}