using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    /// <summary>
    /// 用于管理案件工作流的书签记录信息。
    /// </summary>
    internal interface IBookmarkRecordManager
    {
        /// <summary>
        /// 获得记录的所有暂停在书签<param name="bookmarkName"/>处的工作流的ID。
        /// </summary>
        IEnumerable<Guid> GetIdsOfAllCaseSuspendedAt(string bookmarkName);

        /// <summary>
        /// 记录ID为<param name="id"/>的工作流在书签<param name="bookmarkName"/>处暂停。
        /// </summary>
        void RecordBookmarkCreated(Guid id, string bookmarkName);

        /// <summary>
        /// 记录ID为<param name="id"/>的工作流已从书签<param name="bookmarkName"/>处继续。
        /// </summary>
        void RecordBookmarkResumed(Guid id, string bookmarkName);
    }
}
