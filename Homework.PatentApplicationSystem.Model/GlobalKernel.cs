using Ninject;

namespace Homework.PatentApplicationSystem.Model
{
    public static class GlobalKernel
    {
        public static readonly IKernel Instance = new StandardKernel();
    }
}