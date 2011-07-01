namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// �����참Ա��ɫ�����̿��Ʒ����ɽ�ɫ��Ҫ�����������ɡ�
    /// ��ɫ���������ʱ��Ҫ������Щ�����<see cref="IWorkflowStepService.ContinueCase"/>����
    /// ʹ�������δ��ɶ�����İ������̼�����
    /// ʵ�ִ˽ӿڵĶ���Ӧ��<see cref="IUserSpecificServiceFactory"/>������ʱ������
    /// </summary>
    public interface I�참Ա���̷���
    {
        IWorkflowStepService ׫д����참���� { get; }
        IWorkflowStepService ԭʼ���Ϸ������� { get; }
        IWorkflowStepService ԭʼ���Ϸ���һУ���� { get; }
        IWorkflowStepService ԭʼ���Ϸ����У���� { get; }
        IWorkflowStepService ������������ { get; }
        IWorkflowStepService �ٷ������참���� { get; }
        IWorkflowStepService �ͻ�ָʾ�참���� { get; }
    }
}