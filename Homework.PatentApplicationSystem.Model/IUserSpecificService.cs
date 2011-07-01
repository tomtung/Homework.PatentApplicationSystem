namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 表示因用户不同而不同的服务。
    /// 实现此接口的对象应由<see cref="IUserSpecificServiceFactory"/>在运行时创建。
    /// </summary>
    public interface IUserSpecificService
    {
        /// <summary>
        /// 使用服务的用户。
        /// </summary>
        User User { get; }
    }
}