namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// 控制案件流程控制类实现此接口。
    /// </summary>
    internal interface ICaseWorkflowManager
    {
        /// <summary>
        /// 使案件号为<param name="caseId"/>的案件从书签<param name="bookmarkName"/>处继续执行。
        /// </summary>
        /// <returns>案件是否成功继续。</returns>
        bool ResumeBookmark(string caseId, string bookmarkName, object value);
    }

    internal static class CaseWorkflowManagerHelper
    {
        /// <summary>
        /// 使案件号为<param name="caseId"/>的案件从书签<param name="bookmarkName"/>处继续执行。
        /// </summary>
        /// <returns>案件是否成功继续。</returns>
        public static bool ResumeBookmark(this ICaseWorkflowManager manager, string caseId, string bookmarkName)
        {
            return manager.ResumeBookmark(caseId, bookmarkName, new object());
        }
    }
}