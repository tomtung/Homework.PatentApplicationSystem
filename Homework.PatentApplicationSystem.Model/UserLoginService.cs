using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model
{
    internal class UserLoginService : IUserLoginService
    {
        private readonly string _connectionString;

        public UserLoginService(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Implementation of IUserLoginService

        public Tuple<LoginResult, User> Login(string userName, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                LoginResult result;
                User user = null;
                SqlDataReader reader = connection.Select("员工", new KeyValuePair<string, object>("UserName", userName));
                if (reader.Read())
                    if ((string) reader["Password"] != password)
                        result = LoginResult.PasswordNotMatch;
                    else
                    {
                        result = LoginResult.Successful;
                        user = ExtractUser(reader);
                    }
                else
                    result = LoginResult.UserNotExist;
                return Tuple.Create(result, user);
            }
        }

        private static User ExtractUser(SqlDataReader reader)
        {
            return new User
                       {
                           UserName = (string) reader["UserName"],
                           Password = (string) reader["Password"],
                           Role = ((string) reader["Role"]).EnumParse<Role>()
                       };
        }

        #endregion
    }
}