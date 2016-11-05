using System.Collections.Generic;
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingService.Services
{
    public interface IProcessService
    {
        Process GetProcessById(int id);

        List<Process> GetProcesses();

        Process Create(string name, int version);

        Process Update(Process process);

        void Delete(Process process);
    }
}