namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// ���û���ݴ�����ͬ�ķ������Ĺ�����ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IUserSpecificServiceFactory
    {
        /// <summary>
        /// Ϊ�û���Ϊ<param name="user"/>���û�����<typeparam name="T"/>����
        /// </summary>
        /// <returns>�����ķ����ࡣ</returns>
        T GetService<T>(User user) where T : IUserSpecificService;
    }
}