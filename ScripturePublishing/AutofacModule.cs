﻿using System.Configuration;
using Autofac;
using ScripturePublishingEntity;
using ScripturePublishingEntity.Repositories;
using ScripturePublishingService.Services;

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
            builder.RegisterType<ProcessStepRepository>().As<IProcessStepRepository>().InstancePerRequest();
            builder.RegisterType<ProcessStepOrderRepository>().As<IProcessStepOrderRepository>().InstancePerRequest();
            builder.RegisterType<ResultTypeRepository>().As<IResultTypeRepository>().InstancePerRequest();
            builder.RegisterType<StateRepository>().As<IStateRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();

            //Services
            builder.RegisterType<ProcessService>().As<IProcessService>().InstancePerRequest();
            builder.RegisterType<ProcessStepService>().As<IProcessStepService>().InstancePerRequest();
            builder.RegisterType<ProcessStepOrderService>().As<IProcessStepOrderService>().InstancePerRequest();
            builder.RegisterType<ResultTypeService>().As<IResultTypeService>().InstancePerRequest();
            builder.RegisterType<StateService>().As<IStateService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            base.Load(builder);
        }
    }
}