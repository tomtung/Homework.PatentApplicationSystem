using System;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// ��������������չ�������˰���Id�͹�����Id���ṩ��ɾ��ǩ��¼�Ĳ�����
    /// </summary>
    internal interface ITaskActivityExtension
    {
        string CaseId { get; }
        Guid WorkflowInstanceId { get; }
        void AddBookmarkRecord(string bookmarkName);
        void RemoveBookmarkRecord(string bookmarkName);
    }
}