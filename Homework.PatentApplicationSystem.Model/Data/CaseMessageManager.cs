using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Data
{
    class CaseMessageManager : ICaseMessageManager
    {
        #region Implementation of ICaseMessageManager

        public IEnumerable<CaseMessage> GetMessagesOf(string 案件编号)
        {
            throw new NotImplementedException();
        }

        public void AddMessage(CaseMessage doc)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}