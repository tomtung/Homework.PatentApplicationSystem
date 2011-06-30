using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model
{
    public interface ICaseDocManager
    {
        /// <summary>
        /// 返回与<see cref="Case.编号"/>为<param name="案件编号" />的<see cref="Case"/>相关的所有<see cref="CaseDoc"/>。
        /// </summary>
        IEnumerable<CaseDoc> GetDocsOf(Guid 案件编号);
        
        /// <summary>
        /// 保存路径为<see cref="CaseDoc.FilePath"/>的文件与案件编号为<see cref="CaseDoc.案件编号"/>的案件的关联。
        /// </summary>
        void AddDoc(CaseDoc doc);

        /// <summary>
        /// 解除路径为<see cref="CaseDoc.FilePath"/>的文件与案件编号为<see cref="CaseDoc.案件编号"/>的案件的关联。
        /// 但实际文件并不会被删除。
        /// </summary>
        void RemoveDoc(CaseDoc doc);
    }

    public static class CaseDocManagerHelper
    {
        /// <summary>
        /// 返回与案件<param name="case" />相关的所有<see cref="CaseDoc"/>。
        /// </summary>
        public static IEnumerable<CaseDoc> GetDocsOf(this ICaseDocManager manager, Case @case)
        {
            return manager.GetDocsOf(@case.编号);
        }
    }
}
