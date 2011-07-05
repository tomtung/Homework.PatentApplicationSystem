using System;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Ninject.Modules;

namespace Homework.PatentApplicationSystem.Model
{
    public class DefaultNinjectModule : NinjectModule
    {
        public DefaultNinjectModule(string dbConnectionString)
        {
            DbConnectionString = dbConnectionString;
        }

        public string DbConnectionString { get; set; }

        public override void Load()
        {
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<String>().ToMethod(c => DbConnectionString).WhenInjectedInto<UserService>();

            Bind<IClientInfoManager>().To<ClientInfoManager>().InSingletonScope();
            Bind<String>().ToMethod(c => DbConnectionString).WhenInjectedInto<ClientInfoManager>();

            Bind<ICaseInfoManager>().To<CaseInfoManager>().InSingletonScope();
            Bind<String>().ToMethod(c => DbConnectionString).WhenInjectedInto<CaseInfoManager>();

            Bind<ICaseDocManager>().To<CaseDocManager>().InSingletonScope();
            Bind<String>().ToMethod(c => DbConnectionString).WhenInjectedInto<CaseDocManager>();

            Bind<ICaseMessageManager>().To<CaseMessageManager>().InSingletonScope();
            Bind<String>().ToMethod(c => DbConnectionString).WhenInjectedInto<CaseMessageManager>();

            Bind<ICaseWorkflowManager>().To<CaseWorkflowManager>().InSingletonScope();
            Bind<String>().ToMethod(c => DbConnectionString).WhenInjectedInto<CaseWorkflowManager>();

            Bind<WordToPdfConverter>().ToSelf().InSingletonScope();
        }
    }
}