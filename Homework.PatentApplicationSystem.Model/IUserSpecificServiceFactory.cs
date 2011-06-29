namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 依用户身份创建不同的服务对象的工厂类实现此接口。
    /// </summary>
    public interface IUserSpecificServiceFactory
    {
        /// <summary>
        /// 为用户名为<param name="user"/>的用户创建<typeparam name="T"/>服务。
        /// </summary>
        /// <returns>创建的服务类。</returns>
        T GetService<T>(User user) where T : IUserSpecificService;
    }
}