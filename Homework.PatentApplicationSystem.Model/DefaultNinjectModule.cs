using Homework.PatentApplicationSystem.Model.Data;

using Ninject.Modules;

namespace Homework.PatentApplicationSystem.Model
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IClientInfoManager>().To<ClientInfoManager>().InSingletonScope();
        }
    }
}