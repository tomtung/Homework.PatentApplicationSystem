using System;
using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    internal class WorkflowStepService : IWorkflowStepService
    {
        private readonly string _bookmarkName;
        private readonly User _user;

        internal WorkflowStepService(User user, string bookmarkName)
        {
            _user = user;
            _bookmarkName = bookmarkName;
        }

        public string BookmarkName
        {
            get { return _bookmarkName; }
        }

        #region Implementation of IUserSpecificService

        public User User
        {
            get { return _user; }
        }

        #endregion

        #region Implementation of IWorkflowStepService

        public IEnumerable<Guid> PendingCaseIds
        {
            get { throw new NotImplementedException(); }
        }

        public bool ContinueCase(Guid caseId, object value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}