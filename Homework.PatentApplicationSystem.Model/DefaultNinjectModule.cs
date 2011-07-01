using System;

using Ninject.Modules;

namespace Homework.PatentApplicationSystem.Model
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbHelper>().To<DbHelper>().InSingletonScope();
            Bind<IClientInfoManager>().To<ClientInfoManager>().InSingletonScope();
        }
    }
}
