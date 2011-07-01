using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 数据库辅助接口
    /// </summary>
    public interface IDbHelper
    {
        /// <summary>
        /// 关闭字符串连接
        /// </summary>
        void Close();

        /// <summary>
        /// 无返回值函数
        /// 返回:影响的行数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string sqlString);

        /// <summary>
        /// Select函数
        /// 返回：SqlDataReader
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        SqlDataReader ExecuteQuery(string sqlString);

    }
}
