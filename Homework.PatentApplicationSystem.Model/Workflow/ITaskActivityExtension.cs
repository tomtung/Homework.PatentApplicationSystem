namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// ��������������չ�������˰���Id�͹�����Id���ṩ��ɾ��ǩ��¼�Ĳ�����
    /// </summary>
    internal interface ITaskActivityExtension
    {
        string CaseId { get; }
        string WorkflowInstanceId { get; }
        void AddBookmarkRecord(string bookmarkName);
        void RemoveBookmarkRecord(string bookmarkName);
    }
}