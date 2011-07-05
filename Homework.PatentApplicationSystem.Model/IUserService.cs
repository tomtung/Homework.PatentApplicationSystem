using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// ʵ�ִ˽ӿ��ṩ�û���¼��֤����
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// �������û���<param name="userName"/>������<param name="password"/>��¼ϵͳ��
        /// </summary>
        /// <returns>
        ///     һ��Tuple�����һ��Ԫ��Ϊ<see cref="LoginResult"/>���ͣ���ʾ��¼�����
        ///     ����¼�ɹ���ڶ���Ԫ��Ϊ�û�����Ӧ��<see cref="User"/>���󣬷���Ϊnull��
        /// </returns>
        Tuple<LoginResult, User> Login(string userName, string password);

        /// <summary>
        /// ��ý�ɫΪ<param name="role"/>���û��б�
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