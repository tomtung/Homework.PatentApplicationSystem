using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// 用于对用户<see cref="IWorkflowStepService.User"/>的某项任务进行流程控制。
    /// 实现此接口的对象应由<see cref="IUserSpecificServiceFactory"/>在运行时创建。
    /// </summary>
    public interface IWorkflowStepService : IUserSpecificService
    {
        /// <summary>
        /// 因用户<see cref="IWorkflowStepService.User"/>未完成当前任务而中止的案件的编号。
        /// </summary>
        IEnumerable<Guid> PendingCaseIds { get; }

        /// <summary>
        /// 表示用户<see cref="IWorkflowStepService.User"/>已完成当前任务，案件流程可以继续。
        /// </summary>
        /// <param name="caseId">要继续的案件的编号。</param>
        /// <param name="value">
        ///     任务结果，作为可能影响案件流程的参数。
        ///     <example>如对于内审任务，传入true/false表示内审是否通过。</example>
        /// </param>
        /// <returns>案件是否成功继续。</returns>
        bool ContinueCase(Guid caseId, object value);
    }

    public static class WorkflowStepServiceHelper
    {
        /// <summary>
        /// 表示用户<see cref="IWorkflowStepService.User"/>已完成当前任务，案件流程可以继续。
        /// </summary>
        /// <param name="caseId">要继续的案件的编号。</param>
        public static bool ContinueCase(this IWorkflowStepService service, Guid caseId)
        {
            return service.ContinueCase(caseId, new object());
        }

        /// <summary>
        /// 表示用户<see cref="IWorkflowStepService.User"/>已完成当前任务，案件流程可以继续。
        /// </summary>
        /// <param name="case">要继续的案件。</param>
        /// <returns>案件是否成功继续。</returns>
        public static bool ContinueCase(this IWorkflowStepService service, Case @case)
        {
            return service.ContinueCase(@case, new object());
        }

        /// <summary>
        /// 表示用户<see cref="IWorkflowStepService.User"/>已完成当前任务，案件流程可以继续。
        /// </summary>
        /// <param name="case">要继续的案件。</param>
        /// <param name="value">
        ///     任务结果，作为可能影响案件流程的参数。
        ///     <example>如对于内审任务，传入true/false表示内审是否通过。</example>
        /// </param>
        /// <returns>案件是否成功继续。</returns>
        public static bool ContinueCase(this IWorkflowStepService service, Case @case, object value)
        {
            return service.ContinueCase(@case.编号, value);
        }
    }
}