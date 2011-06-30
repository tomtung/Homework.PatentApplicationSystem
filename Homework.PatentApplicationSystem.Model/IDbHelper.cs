namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 数据库辅助接口
    /// </summary>
    internal public interface IDbHelper
    {
        /// <summary>
        /// 关闭字符串连接
        /// </summary>
        void Close();

        /// <summary>
        /// 增删改函数
        /// 返回:影响的行数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        int AddUpdateDelete(string sqlString);
    }
}
