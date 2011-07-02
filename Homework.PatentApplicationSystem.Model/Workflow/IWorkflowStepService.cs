using System.Collections.Generic;

using Homework.PatentApplicationSystem.Model.Data;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// ���ڶ��û�<see cref="IWorkflowStepService.User"/>��ĳ������������̿��ơ�
    /// </summary>
    public interface IWorkflowStepService : IUserSpecificService
    {
        /// <summary>
        /// ���û�<see cref="IWorkflowStepService.User"/>δ��ɵ�ǰ�������ֹ�İ����ı�š�
        /// </summary>
        IEnumerable<string> PendingCaseIds { get; }

        /// <summary>
        /// ��ʾ�û�<see cref="IWorkflowStepService.User"/>����ɵ�ǰ���񣬰������̿��Լ�����
        /// </summary>
        /// <param name="caseId">Ҫ�����İ����ı�š�</param>
        /// <param name="value">
        ///     ����������Ϊ����Ӱ�참�����̵Ĳ�����
        ///     <example>������������񣬴���true/false��ʾ�����Ƿ�ͨ����</example>
        /// </param>
        /// <returns>�����Ƿ�ɹ�������</returns>
        bool ContinueCase(string caseId, object value);
    }

    public static class WorkflowStepServiceHelper
    {
        /// <summary>
        /// ��ʾ�û�<see cref="IWorkflowStepService.User"/>����ɵ�ǰ���񣬰������̿��Լ�����
        /// </summary>
        /// <param name="caseId">Ҫ�����İ����ı�š�</param>
        public static bool ContinueCase(this IWorkflowStepService service, string caseId)
        {
            return service.ContinueCase(caseId, new object());
        }

        /// <summary>
        /// ��ʾ�û�<see cref="IWorkflowStepService.User"/>����ɵ�ǰ���񣬰������̿��Լ�����
        /// </summary>
        /// <param name="case">Ҫ�����İ�����</param>
        /// <returns>�����Ƿ�ɹ�������</returns>
        public static bool ContinueCase(this IWorkflowStepService service, Case @case)
        {
            return service.ContinueCase(@case, new object());
        }

        /// <summary>
        /// ��ʾ�û�<see cref="IWorkflowStepService.User"/>����ɵ�ǰ���񣬰������̿��Լ�����
        /// </summary>
        /// <param name="case">Ҫ�����İ�����</param>
        /// <param name="value">
        ///     ����������Ϊ����Ӱ�참�����̵Ĳ�����
        ///     <example>������������񣬴���true/false��ʾ�����Ƿ�ͨ����</example>
        /// </param>
        /// <returns>�����Ƿ�ɹ�������</returns>
        public static bool ContinueCase(this IWorkflowStepService service, Case @case, object value)
        {
            return service.ContinueCase(@case.���, value);
        }
    }
}