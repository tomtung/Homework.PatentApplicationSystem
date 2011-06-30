using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model
{
    public interface ICaseDocManager
    {
        /// <summary>
        /// ������<see cref="Case.���"/>Ϊ<param name="�������" />��<see cref="Case"/>��ص�����<see cref="CaseDoc"/>��
        /// </summary>
        IEnumerable<CaseDoc> GetDocsOf(Guid �������);
        
        /// <summary>
        /// ����·��Ϊ<see cref="CaseDoc.FilePath"/>���ļ��밸�����Ϊ<see cref="CaseDoc.�������"/>�İ����Ĺ�����
        /// </summary>
        void AddDoc(CaseDoc doc);

        /// <summary>
        /// ���·��Ϊ<see cref="CaseDoc.FilePath"/>���ļ��밸�����Ϊ<see cref="CaseDoc.�������"/>�İ����Ĺ�����
        /// ��ʵ���ļ������ᱻɾ����
        /// </summary>
        void RemoveDoc(CaseDoc doc);
    }

    public static class CaseDocManagerHelper
    {
        /// <summary>
        /// �����밸��<param name="case" />��ص�����<see cref="CaseDoc"/>��
        /// </summary>
        public static IEnumerable<CaseDoc> GetDocsOf(this ICaseDocManager manager, Case @case)
        {
            return manager.GetDocsOf(@case.���);
        }
    }
}
