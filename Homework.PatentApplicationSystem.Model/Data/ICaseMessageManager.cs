using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Data
{
    public interface ICaseMessageManager
    {
        /// <summary>
        /// ������<see cref="Case.���"/>Ϊ<param name="�������" />��<see cref="Case"/>��ص�����<see cref="CaseMessage"/>��
        /// </summary>
        IEnumerable<CaseMessage> GetMessagesOf(string �������);

        /// <summary>
        /// ���һ��<see cref="CaseMessage"/>��
        /// </summary>
        void AddMessage(CaseMessage doc);
    }

    public static class CaseMessageManagerHelper
    {
        /// <summary>
        /// �����밸��<param name="case" />��ص�����<see cref="CaseMessage"/>��
        /// </summary>
        public static IEnumerable<CaseMessage> GetDocsOf(this ICaseMessageManager manager, Case @case)
        {
            return manager.GetMessagesOf(@case.���);
        }
    }
}