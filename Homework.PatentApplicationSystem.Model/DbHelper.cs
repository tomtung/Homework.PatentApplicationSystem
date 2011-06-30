using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 数据库访问帮助类
    /// </summary>
    class DbHelper
    {
        public SqlCommand Command { get; set; }

        public DbHelper(string sqlString)
        {
            var connection = new SqlConnection(sqlString);
            Command = new SqlCommand {Connection = connection};
        }

        public void Close()
        {
            Command.Connection.Close();
        }

        public int AddUpdateDelete(string sqlString)
        {
            Command.CommandText = sqlString;
            var rows = Command.ExecuteNonQuery();
            return rows;
        }
    }
}
