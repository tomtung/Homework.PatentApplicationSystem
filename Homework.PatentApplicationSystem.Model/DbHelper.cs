using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 数据库访问帮助类
    /// </summary>
    public class DbHelper : IDbHelper
    {
        public SqlCommand Command { get; set; }
        public SqlConnection Connection { get; set; }

        public DbHelper(string sqlString)
        {
            Connection = new SqlConnection(sqlString);
            Connection.Open();
            Command = new SqlCommand { Connection = this.Connection };
        }

        public void Close()
        {
            Connection.Close();
        }


        public int AddUpdateDelete(string sqlString)
        {
            Command.CommandText = sqlString;
            var rows = Command.ExecuteNonQuery();
            return rows;
        }

        public SqlDataReader Select(string sqlString)
        {
            Command.CommandText = sqlString;
            return Command.ExecuteReader();
        }
    }
}
