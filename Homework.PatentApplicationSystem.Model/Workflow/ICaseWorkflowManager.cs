using System;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// ���ư������̿�����ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface ICaseWorkflowManager
    {
        /// <summary>
        /// ʹ������Ϊ<param name="caseId"/>�İ�������ǩ<param name="bookmarkName"/>������ִ�С�
        /// </summary>
        /// <returns>�����Ƿ�ɹ�������</returns>
        bool ResumeBookmark(Guid caseId, string bookmarkName, object value);
    }

    internal static class CaseWorkflowManagerHelper
    {
        /// <summary>
        /// ʹ������Ϊ<param name="caseId"/>�İ�������ǩ<param name="bookmarkName"/>������ִ�С�
        /// </summary>
        /// <returns>�����Ƿ�ɹ�������</returns>
        public static bool ResumeBookmark(this ICaseWorkflowManager manager, Guid caseId, string bookmarkName)
        {
            return manager.ResumeBookmark(caseId, bookmarkName, new object());
        }
    }
}