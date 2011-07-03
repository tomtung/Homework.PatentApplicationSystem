using System;

namespace Homework.PatentApplicationSystem.Model
{
    class UserLoginService : IUserLoginService
    {
        #region Implementation of IUserLoginService

        public Tuple<LoginResult, User> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}