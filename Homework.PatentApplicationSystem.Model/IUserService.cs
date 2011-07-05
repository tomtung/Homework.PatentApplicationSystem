using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 实现此接口提供用户登录验证服务。
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 尝试用用户名<param name="userName"/>和密码<param name="password"/>登录系统。
        /// </summary>
        /// <returns>
        ///     一个Tuple，其第一个元素为<see cref="LoginResult"/>类型，表示登录结果；
        ///     若登录成功则第二个元素为用户名对应的<see cref="User"/>对象，否则为null。
        /// </returns>
        Tuple<LoginResult, User> Login(string userName, string password);

        /// <summary>
        /// 获得角色为<param name="role"/>的用户列表。
        /// </summary>
        IEnumerable<User> GetUsersByRole(Role role);
    }

    public enum LoginResult
    {
        Successful,
        UserNotExist,
        PasswordNotMatch
    }
}