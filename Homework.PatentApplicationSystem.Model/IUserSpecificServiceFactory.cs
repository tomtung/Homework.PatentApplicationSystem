namespace Homework.PatentApplicationSystem.Model
{
    public interface IUserSpecificServiceFactory
    {
        T GetService<T>(User user) where T : IUserSpecificService;
    }
}