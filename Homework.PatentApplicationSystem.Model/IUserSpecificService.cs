namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// ��ʾ���û���ͬ����ͬ�ķ���
    /// ʵ�ִ˽ӿڵĶ���Ӧ��<see cref="IUserSpecificServiceFactory"/>������ʱ������
    /// </summary>
    public interface IUserSpecificService
    {
        /// <summary>
        /// ʹ�÷�����û���
        /// </summary>
        User User { get; }
    }
}