using System;
using System.Collections.Generic;

using Homework.PatentApplicationSystem.Model.Data;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    internal class CaseWorkflowManager : ICaseWorkflowManager
    {
        public void StartCase(Case @case)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetPendingCaseIds(string taskName, User user)
        {
            throw new NotImplementedException();
        }

        public bool ResumeCase(string caseId, string taskName, object value)
        {
            throw new NotImplementedException();
        }
    }
}