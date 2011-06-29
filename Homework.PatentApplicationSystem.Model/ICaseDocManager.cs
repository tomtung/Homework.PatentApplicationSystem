using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model
{
    public interface ICaseDocManager
    {
        /// <summary>
        /// Get document files that are related to case with given ID.
        /// </summary>
        IEnumerable<CaseDoc> GetDocsOf(Guid caseId);
        
        /// <summary>
        /// Add document file <param name="doc"/> to related files of the case with ID <param name="caseId"/>
        /// </summary>
        void AddDoc(Guid caseId, CaseDoc doc);

        /// <summary>
        /// Remove document file <param name="doc"/> from related files of the case with ID <param name="caseId"/>
        /// </summary>
        void RemoveDoc(Guid caseId, CaseDoc doc);
    }

    public static class CaseDocManagerHelper
    {
        /// <summary>
        /// Get document files that are related to <param name="case"/>.
        /// </summary>
        public static IEnumerable<CaseDoc> GetDocsOf(this ICaseDocManager manager, Case @case)
        {
            return manager.GetDocsOf(@case.±àºÅ);
        }

        /// <summary>
        /// Add document file <param name="doc"/> to related files of <param name="case"/>.
        /// </summary>
        public static void AddDoc(this ICaseDocManager manager, Case @case, CaseDoc doc)
        {
            manager.AddDoc(@case.±àºÅ, doc);
        }
    }
}
