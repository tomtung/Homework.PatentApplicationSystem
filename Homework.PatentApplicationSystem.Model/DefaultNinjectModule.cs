using System;
using System.Activities.DurableInstancing;
using System.Data.SqlClient;
using System.Runtime.DurableInstancing;
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
            Bind<SqlConnection>().ToMethod(c => new SqlConnection(DbConnectionString));
            Bind<SqlWorkflowInstanceStore>().ToMethod(c => GetSqlWorkflowIntanceStore());

            Bind<IUserLoginService>().To<UserLoginService>().InSingletonScope();

            Bind<IClientInfoManager>().To<ClientInfoManager>().InThreadScope();
            Bind<ICaseInfoManager>().To<CaseInfoManager>().InThreadScope();
            Bind<ICaseDocManager>().To<CaseDocManager>().InThreadScope();
            Bind<ICaseMessageManager>().To<CaseMessageManager>().InThreadScope();

            Bind<ICaseWorkflowManager>().To<CaseWorkflowManager>().InThreadScope();
        }

        private SqlWorkflowInstanceStore GetSqlWorkflowIntanceStore()
        {
            var store =
                new SqlWorkflowInstanceStore(DbConnectionString);

            InstanceHandle handle = store.CreateInstanceHandle();
            InstanceView view = store.Execute(handle,
                                              new CreateWorkflowOwnerCommand
                                                  (),
                                              TimeSpan.FromSeconds(30));
            handle.Free();

            store.DefaultInstanceOwner = view.InstanceOwner;
            return store;
        }
    }
}