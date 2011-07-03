using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Data
{
    public interface ICaseMessageManager
    {
        /// <summary>
        /// 返回与<see cref="Case.编号"/>为<param name="案件编号" />的<see cref="Case"/>相关的所有<see cref="CaseMessage"/>。
        /// </summary>
        IEnumerable<CaseMessage> GetMessagesOf(string 案件编号);

        /// <summary>
        /// 添加一条<see cref="CaseMessage"/>。
        /// </summary>
        void AddMessage(CaseMessage doc);
    }

    public static class CaseMessageManagerHelper
    {
        /// <summary>
        /// 返回与案件<param name="case" />相关的所有<see cref="CaseMessage"/>。
        /// </summary>
        public static IEnumerable<CaseMessage> GetDocsOf(this ICaseMessageManager manager, Case @case)
        {
            return manager.GetMessagesOf(@case.编号);
        }
    }
}