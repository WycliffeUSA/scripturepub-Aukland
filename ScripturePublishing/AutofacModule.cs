using System.Configuration;
using Autofac;
using ScripturePublishingEntity;
using ScripturePublishingEntity.Repositories;

namespace ScripturePublishing
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            builder.RegisterType<WorkflowEngine>().WithParameter("connection", connectionString).InstancePerRequest();
           // builder.RegisterType<UnitOfWork<ApprovalServiceDbContext>>().As<IUnitOfWork>().InstancePerRequest();

            //Repositories
            builder.RegisterType<ProcessRepository>().As<IProcessRepository>().InstancePerRequest();

            //Services
            //builder.RegisterType<ScratchPadService>().As<IScratchPadService>().InstancePerRequest();

            base.Load(builder);
        }
    }
}