using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 数据库访问帮助类
    /// </summary>
    public class DbHelper : IDbHelper
    {
        public DbHelper(string sqlString)
        {
            Connection = new SqlConnection(sqlString);
            Connection.Open();
            Command = new SqlCommand {Connection = Connection};
        }

        public SqlCommand Command { get; set; }
        public SqlConnection Connection { get; set; }

        #region IDbHelper Members

        public void Close()
        {
            Connection.Close();
        }

        public int AddUpdateDelete(string sqlString)
        {
            Command.CommandText = sqlString;
            int rows = Command.ExecuteNonQuery();
            return rows;
        }

        public SqlDataReader Select(string sqlString)
        {
            Command.CommandText = sqlString;
            return Command.ExecuteReader();
        }

        #endregion
    }
}