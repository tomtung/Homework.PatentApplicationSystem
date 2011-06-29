using System;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// ���ڹ�������Ϣ���°����Ĵ�����
    /// </summary>
    public interface ICaseManager
    {
        /// <summary>
        /// ��ð������Ϊ<param name="caseId"/>�İ�����Ϣ��
        /// </summary>
        Case GetCaseById(Guid caseId);
        
        /// <summary>
        /// ���永��<param name="case"/>����Ϣ���������˰������̡�
        /// </summary>
        void CreateCase(Case @case);
    }
}