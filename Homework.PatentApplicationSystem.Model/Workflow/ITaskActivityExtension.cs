namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// 案件工作流的扩展。保存了案件Id和工作流Id，提供增删书签记录的操作。
    /// </summary>
    internal interface ITaskActivityExtension
    {
        string CaseId { get; }
        string WorkflowInstanceId { get; }
        void AddBookmarkRecord(string bookmarkName);
        void RemoveBookmarkRecord(string bookmarkName);
    }
}