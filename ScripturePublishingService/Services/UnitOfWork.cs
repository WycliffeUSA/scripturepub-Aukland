using ScripturePublishingEntity;

namespace ScripturePublishingService.Services
{
    public class UnitOfWork<T> : IUnitOfWork where T : WorkflowEngine
    {
        private readonly T _context;

        public UnitOfWork(T context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}