namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// �����������ܽ�ɫ�����̿��Ʒ����ɽ�ɫ��Ҫ�����������ɡ�
    /// ��ɫ���������ʱ��Ҫ������Щ�����<see cref="IWorkflowStepService.ContinueCase"/>����
    /// ʹ�������δ��ɶ�����İ������̼�����
    /// ʵ�ִ˽ӿڵĶ���Ӧ��<see cref="IUserSpecificServiceFactory"/>������ʱ������
    /// </summary>
    public interface I�����������̷���
    {
        IWorkflowStepService �м��ļ�����ְ����� { get; }
        IWorkflowStepService ������ְ����� { get; }
        IWorkflowStepService ������������ { get; }
    }
}