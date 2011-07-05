using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model
{
    internal class UserService : IUserService
    {
        private const string _tableName = "员工";
        private readonly string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Implementation of IUserService

        public Tuple<LoginResult, User> Login(string userName, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                LoginResult result;
                User user = null;
                SqlDataReader reader = connection.Select(_tableName, new KeyValuePair<string, object>("UserName", userName));
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

        public IEnumerable<User> GetUsersByRole(Role role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var users = new List<User>();
                var reader = connection.Select(_tableName, new KeyValuePair<string, object>("Role", role.ToString()));
                while (reader.Read())
                    users.Add(ExtractUser(reader));
                reader.Close();
                return users;
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