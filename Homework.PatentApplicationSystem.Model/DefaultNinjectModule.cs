using System;
using System.Activities.DurableInstancing;
using System.Data.SqlClient;
using System.Runtime.DurableInstancing;
using Homework.PatentApplicationSystem.Model.Data;
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
            Bind<SqlWorkflowInstanceStore>()
                .ToMethod(c =>
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
                              });
            Bind<IClientInfoManager>().To<ClientInfoManager>().InSingletonScope();
        }
    }
}