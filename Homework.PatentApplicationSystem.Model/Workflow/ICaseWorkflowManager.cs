using System.Collections.Generic;
using Homework.PatentApplicationSystem.Model.Data;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// 控制案件流程控制类实现此接口。
    /// </summary>
    public interface ICaseWorkflowManager
    {
        /// <summary>
        /// 开始进行案件<param name="case"/>流程。
        /// </summary>
        void StartCase(Case @case);

        /// <summary>
        /// 得到等待用户<param name="user"/>完成名为<param name="taskName"/>的任务的案件的编号列表。
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetPendingCaseIds(string taskName, User user);

        /// <summary>
        /// 表示编号为<param name="caseId"/>的案件中，名为<param name="taskName"/>的任务已被完成，案件流程可以继续。
        /// </summary>
        /// <param name="value">
        ///     任务结果，作为可能影响案件流程的参数。
        ///     <example>如对于内审任务，传入true/false表示内审是否通过。</example>
        /// </param>
        /// <returns>案件是否成功继续。</returns>
        bool ResumeCase(string caseId, string taskName, object value);
    }

    public static class CaseWorkflowManagerHelper
    {
        /// <summary>
        /// 表示编号为<param name="caseId"/>的案件中，名为<param name="taskName"/>的任务已被完成，案件流程可以继续。
        /// </summary>
        /// <returns>案件是否成功继续。</returns>
        public static bool ResumeCase(this ICaseWorkflowManager manager, string caseId, string taskName)
        {
            return manager.ResumeCase(caseId, taskName, new object());
        }

        /// <summary>
        /// 表示的案件<param name="case"/>中名为<param name="taskName"/>的任务已被完成，案件流程可以继续。
        /// </summary>
        /// <param name="value">
        ///     任务结果，作为可能影响案件流程的参数。
        ///     <example>如对于内审任务，传入true/false表示内审是否通过。</example>
        /// </param>
        /// <returns>案件是否成功继续。</returns>
        public static bool ResumeCase(this ICaseWorkflowManager manager, Case @case, string taskName, object value)
        {
            return manager.ResumeCase(@case.编号, taskName, value);
        }

        /// <summary>
        /// 表示的案件<param name="case"/>中名为<param name="taskName"/>的任务已被完成，案件流程可以继续。
        /// </summary>
        /// <returns>案件是否成功继续。</returns>
        public static bool ResumeCase(this ICaseWorkflowManager manager, Case @case, string taskName)
        {
            return manager.ResumeCase(@case, taskName, new object());
        }
    }
}