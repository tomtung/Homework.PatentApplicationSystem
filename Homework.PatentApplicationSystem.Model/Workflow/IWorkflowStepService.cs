using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// ���ڶ��û�<see cref="IWorkflowStepService.User"/>��ĳ������������̿��ơ�
    /// ʵ�ִ˽ӿڵĶ���Ӧ��<see cref="IUserSpecificServiceFactory"/>������ʱ������
    /// </summary>
    public interface IWorkflowStepService : IUserSpecificService
    {
        /// <summary>
        /// ���û�<see cref="IWorkflowStepService.User"/>δ��ɵ�ǰ�������ֹ�İ����ı�š�
        /// </summary>
        IEnumerable<Guid> PendingCaseIds { get; }

        /// <summary>
        /// ��ʾ�û�<see cref="IWorkflowStepService.User"/>����ɵ�ǰ���񣬰������̿��Լ�����
        /// </summary>
        /// <param name="caseId">Ҫ�����İ����ı�š�</param>
        /// <param name="value">
        ///     ����������Ϊ����Ӱ�참�����̵Ĳ�����
        ///     <example>������������񣬴���true/false��ʾ�����Ƿ�ͨ����</example>
        /// </param>
        /// <returns></returns>
        bool ContinueCase(Guid caseId, object value);
    }

    public static class WorkflowStepServiceHelper
    {
        /// <summary>
        /// ��ʾ�û�<see cref="IWorkflowStepService.User"/>����ɵ�ǰ���񣬰������̿��Լ�����
        /// </summary>
        /// <param name="caseId">Ҫ�����İ����ı�š�</param>
        public static bool ContinueCase(this IWorkflowStepService service, Guid caseId)
        {
            return service.ContinueCase(caseId, new object());
        }

        /// <summary>
        /// ��ʾ�û�<see cref="IWorkflowStepService.User"/>����ɵ�ǰ���񣬰������̿��Լ�����
        /// </summary>
        /// <param name="case">Ҫ�����İ�����</param>
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
        /// <returns></returns>
        public static bool ContinueCase(this IWorkflowStepService service, Case @case, object value)
        {
            return service.ContinueCase(@case.���, value);
        }
    }
}