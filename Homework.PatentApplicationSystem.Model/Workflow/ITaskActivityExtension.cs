namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// ��������������չ�������˰���Id�͹�����Id���ṩ��ɾ��ǩ��¼�Ĳ�����
    /// </summary>
    internal interface ITaskActivityExtension
    {
        void AddBookmarkRecord(string bookmarkName, object workflowInstanceId);
        void RemoveBookmarkRecord(string bookmarkName);
    }
}