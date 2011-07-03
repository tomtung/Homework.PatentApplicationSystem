using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model
{
    internal class UserLoginService : IUserLoginService
    {
        private readonly SqlConnection _connection;

        public UserLoginService(SqlConnection connection)
        {
            _connection = connection;
        }

        #region Implementation of IUserLoginService

        public Tuple<LoginResult, User> Login(string userName, string password)
        {
            try
            {
                _connection.Open();
                LoginResult result;
                User user = null;
                SqlDataReader reader = _connection.Select("员工", new KeyValuePair<string, object>("UserName", userName));
                if (reader.Read())
                {
                    if ((string) reader["Password"] != password)
                    {
                        result = LoginResult.PasswordNotMatch;
                    }
                    else
                    {
                        result = LoginResult.Successful;
                        user = new User
                                   {
                                       UserName = (string) reader["UserName"],
                                       Password = (string) reader["Password"],
                                       Role = (Role) reader["Role"]
                                   };
                    }
                }
                else
                {
                    result = LoginResult.UserNotExist;
                }
                return Tuple.Create(result, user);
            }
            finally
            {
                _connection.Close();
            }
        }

        #endregion
    }
}