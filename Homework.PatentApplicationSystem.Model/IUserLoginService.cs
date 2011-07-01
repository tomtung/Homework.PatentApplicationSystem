using System;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 实现此接口提供用户登录验证服务。
    /// </summary>
    public interface IUserLoginService
    {
        /// <summary>
        /// 尝试用用户名<param name="userName"/>和密码<param name="password"/>登录系统。
        /// </summary>
        /// <returns>
        ///     一个Tuple，其第一个元素为<see cref="LoginResult"/>类型，表示登录结果；
        ///     若登录成功则第二个元素为用户名对应的<see cref="User"/>对象，否则为null。
        /// </returns>
        Tuple<LoginResult, User> Login(string userName, string password);
    }

    public enum LoginResult
    {
        Successful,
        UserNotExist,
        PasswordNotMatch
    }

    public class MockUserLoginService : IUserLoginService
    {
        #region IUserLoginService Members

        public Tuple<LoginResult, User> Login(string userName, string password)
        {
            LoginResult result = LoginResult.Successful;
            User user = null;

            switch (userName)
            {
                case "Successful":
                    result = LoginResult.Successful;
                    user = new User {UserName = userName, Password = password, Role = Role.立案员};
                    break;
                case "UserNotExist":
                    result = LoginResult.UserNotExist;
                    break;
                case "PasswordNotMatch":
                    result = LoginResult.PasswordNotMatch;
                    break;
            }

            return Tuple.Create(result, user);
        }

        #endregion
    }
}