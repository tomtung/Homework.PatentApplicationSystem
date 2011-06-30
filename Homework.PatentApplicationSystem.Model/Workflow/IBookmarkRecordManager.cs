using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// ���ڹ���������������ǩ��¼��Ϣ��
    /// </summary>
    internal interface IBookmarkRecordManager
    {
        /// <summary>
        /// ��ü�¼��������ͣ����ǩ<param name="bookmarkName"/>���Ĺ�������ID��
        /// </summary>
        IEnumerable<Guid> GetIdsOfAllCaseSuspendedAt(string bookmarkName);

        /// <summary>
        /// ��¼IDΪ<param name="id"/>�Ĺ���������ǩ<param name="bookmarkName"/>����ͣ��
        /// </summary>
        void RecordBookmarkCreated(Guid id, string bookmarkName);

        /// <summary>
        /// ��¼IDΪ<param name="id"/>�Ĺ������Ѵ���ǩ<param name="bookmarkName"/>��������
        /// </summary>
        void RecordBookmarkResumed(Guid id, string bookmarkName);
    }
}
