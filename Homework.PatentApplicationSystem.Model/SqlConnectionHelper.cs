using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 实现了部分常用数据库操作。只对字段值做了防注入处理。
    /// </summary>
    internal static class SqlConnectionHelper
    {
        public static int ExecuteNonQuery(this SqlConnection connection, string commandText)
        {
            using (SqlCommand command = connection.CreateCommand(commandText))
            {
                return command.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(this SqlConnection connection, string commandText,
            IEnumerable<SqlParameter> parameters)
        {
            using (SqlCommand command = connection.CreateCommand(commandText))
            {
                command.Parameters.AddRange(parameters.ToArray());
                return command.ExecuteNonQuery();
            }
        }

        public static SqlDataReader ExecuteReader(this SqlConnection connection, string commandText)
        {
            using (SqlCommand command = connection.CreateCommand(commandText))
            {
                return command.ExecuteReader();
            }
        }

        public static SqlDataReader ExecuteReader(this SqlConnection connection, string commandText,
            IEnumerable<SqlParameter> parameters)
        {
            using (SqlCommand command = connection.CreateCommand(commandText))
            {
                command.Parameters.AddRange(parameters.ToArray());
                return command.ExecuteReader();
            }
        }

        private static SqlCommand CreateCommand(this SqlConnection connection, string commandText)
        {
            return new SqlCommand {Connection = connection, CommandText = commandText};
        }

        public static void Insert(this SqlConnection connection, string tableName,
            IEnumerable<KeyValuePair<string, Object>> keyValuePairs)
        {
            IEnumerable<string> columns = keyValuePairs.Select(pair => pair.Key);
            string columnList = columns.ToCommaSeperatedList();
            string valuePlaceHolders = columns.Select(c => "@" + c).ToCommaSeperatedList();
            string command = string.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tableName, columnList,
                valuePlaceHolders);

            IEnumerable<SqlParameter> parameters = keyValuePairs.Select(ToSqlParameter);

            connection.ExecuteNonQuery(command, parameters);
        }

        private static SqlParameter ToSqlParameter(this KeyValuePair<string, object> pair)
        {
            return new SqlParameter("@" + pair.Key, pair.Value);
        }

        private static string ToCommaSeperatedList(this IEnumerable<string> items)
        {
            return items.Skip(1).Aggregate(items.First(), (head, curr) => head + ", " + curr);
        }

        public static void Insert(this SqlConnection connection, string tableName,
            params KeyValuePair<string, Object>[] keyValuePairs)
        {
            connection.Insert(tableName, keyValuePairs as IEnumerable<KeyValuePair<string, Object>>);
        }

        public static int Update(this SqlConnection connection, string tableName,
            KeyValuePair<string, Object> condition, IEnumerable<KeyValuePair<string, Object>> keyValuePairs)
        {
            string updates = keyValuePairs.Select(p => string.Format("{0} = @{0}", p.Key)).ToCommaSeperatedList();
            string command = string.Format("UPDATE [{0}] SET {1} WHERE {2} = @new{2}", tableName, updates, condition.Key);

            IEnumerable<SqlParameter> parameters = new[] {new SqlParameter("@new" + condition.Key, condition.Value)}
                .Concat(keyValuePairs.Select(ToSqlParameter));

            return connection.ExecuteNonQuery(command, parameters);
        }

        public static int Update(this SqlConnection connection, string tableName,
            KeyValuePair<string, Object> condition, params KeyValuePair<string, Object>[] keyValuePairs)
        {
            return connection.Update(tableName, condition, keyValuePairs as IEnumerable<KeyValuePair<string, object>>);
        }

        public static SqlDataReader Select(this SqlConnection connection, string tableName,
            KeyValuePair<string, object> condition)
        {
            string command = string.Format("SELECT * FROM [{0}] WHERE {1} = @{1}", tableName, condition.Key);
            return connection.ExecuteReader(command, new[] {condition.ToSqlParameter()});
        }

        public static SqlDataReader Select(this SqlConnection connection, string tableName)
        {
            return connection.ExecuteReader(string.Format("SELECT * FROM [{0}]", tableName));
        }

        public static int Delete(this SqlConnection connection, string tableName, KeyValuePair<string, object> condition)
        {
            string command = string.Format("DELETE FROM [{0}] WHERE {1} = @{1}", tableName, condition.Key);
            return connection.ExecuteNonQuery(command, new[] {condition.ToSqlParameter()});
        }
    }
}