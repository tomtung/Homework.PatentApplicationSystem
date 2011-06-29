using System;

namespace Homework.PatentApplicationSystem.Model
{
    public interface IUserLoginService
    {
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
                    user = new User { UserName = userName, Password = password, Role = Role.Á¢°¸Ô± };
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