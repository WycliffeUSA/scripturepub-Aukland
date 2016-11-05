using System.Security.Cryptography.X509Certificates;
using ScripturePublishingEntity.Entities;

namespace ScripturePublishingService.Services
{
    public interface IProcessService
    {
        Process GetProcessById(int id);
    }
}