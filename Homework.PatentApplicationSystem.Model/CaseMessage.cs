using System;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// һ��ĳ�참��Ա��ĳ������������Ϣ��
    /// </summary>
    public struct CaseMessage
    {
        /// <summary>
        /// ��Ϣ�����İ����ı�š�
        /// </summary>
        public Guid ������� { get; set; }

        /// <summary>
        /// ��Ϣ���ݡ�
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// ������Ϣ�����ߵ��û�����
        /// </summary>
        public string SenderUsername { get; set; }
    }
}