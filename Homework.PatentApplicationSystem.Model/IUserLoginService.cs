using System;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// ʵ�ִ˽ӿ��ṩ�û���¼��֤����
    /// </summary>
    public interface IUserLoginService
    {
        /// <summary>
        /// �������û���<param name="userName"/>������<param name="password"/>��¼ϵͳ��
        /// </summary>
        /// <returns>
        ///     һ��Tuple�����һ��Ԫ��Ϊ<see cref="LoginResult"/>���ͣ���ʾ��¼�����
        ///     ����¼�ɹ���ڶ���Ԫ��Ϊ�û�����Ӧ��<see cref="User"/>���󣬷���Ϊnull��
        /// </returns>
        Tuple<LoginResult,User> Login(string userName, string password);
    }

    public enum LoginResult
    {
        Successful,
        UserNotExist,
        PasswordNotMatch
    }

    public class MockUserLoginService : IUserLoginService
    {
        public Tuple<LoginResult, User> Login(string userName, string password)
        {
            LoginResult result = LoginResult.Successful;
            User user = null;

            switch (userName)
            {
                case "Successful":
                    result = LoginResult.Successful;
                    user = new User { UserName = userName, Password = password, Role = Role.����Ա };
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
    }
}