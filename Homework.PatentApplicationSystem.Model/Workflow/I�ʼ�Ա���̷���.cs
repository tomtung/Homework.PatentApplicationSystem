namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// �����ʼ�Ա��ɫ�����̿��Ʒ����ɽ�ɫ��Ҫ�����������ɡ�
    /// ��ɫ���������ʱ��Ҫ������Щ�����<see cref="IWorkflowStepService.ContinueCase"/>����
    /// ʹ�������δ��ɶ�����İ������̼�����
    /// ʵ�ִ˽ӿڵĶ���Ӧ��<see cref="IUserSpecificServiceFactory"/>������ʱ������
    /// </summary>
    public interface I�ʼ�Ա���̷���
    {
        IWorkflowStepService ���̲��ʼ����� { get; }
        IWorkflowStepService �ύ�������� { get; }
    }
}