using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Data
{
    internal class CaseDocManager : ICaseDocManager
    {
        #region ICaseDocManager Members

        public IEnumerable<CaseDoc> GetDocsOf(string 案件编号)
        {
            throw new NotImplementedException();
        }

        public void AddDoc(CaseDoc doc)
        {
            throw new NotImplementedException();
        }

        public void RemoveDoc(CaseDoc doc)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}