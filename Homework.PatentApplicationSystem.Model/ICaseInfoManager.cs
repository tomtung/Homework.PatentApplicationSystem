using System;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// ���ڹ�������Ϣ��
    /// </summary>
    public interface ICaseInfoManager
    {
        /// <summary>
        /// ��ð������Ϊ<param name="caseId"/>�İ�����Ϣ��
        /// </summary>
        Case GetCaseById(Guid caseId);
        
        /// <summary>
        /// ���永��<param name="case"/>����Ϣ���÷����������Զ���ʼδ�����İ������̡�
        /// </summary>
        void AddCase(Case @case);
    }
}