namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// ����������Ա��ɫ�����̿��Ʒ����ɽ�ɫ��Ҫ�����������ɡ�
    /// ��ɫ���������ʱ��Ҫ������Щ�����<see cref="IWorkflowStepService.ContinueCase"/>����
    /// ʹ�������δ��ɶ�����İ������̼�����
    /// ʵ�ִ˽ӿڵĶ���Ӧ��<see cref="IUserSpecificServiceFactory"/>������ʱ������
    /// </summary>
    public interface I������Ա���̷���
    {
        IWorkflowStepService �����ٷ���ʽ������ { get; }
        IWorkflowStepService ����ר������������ { get; }
    }
}