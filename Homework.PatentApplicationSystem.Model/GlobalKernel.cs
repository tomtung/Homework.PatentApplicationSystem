using Ninject;

namespace Homework.PatentApplicationSystem.Model
{
    public static class GlobalKernel
    {
        private static readonly IKernel _instance = new StandardKernel();
        public static IKernel Instance { get { return _instance; } }

        static GlobalKernel()
        {
            var dbHelper = new DbHelper(@"Data Source=LDD-PC;Initial Catalog=HW_PAS;Integrated Security=True");
            Instance.Bind<IDbHelper>().ToConstant(dbHelper);
        }
    }
}