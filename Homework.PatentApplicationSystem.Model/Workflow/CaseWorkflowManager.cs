using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Data.SqlClient;
using Homework.PatentApplicationSystem.Model.Data;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    internal class CaseWorkflowManager : ICaseWorkflowManager
    {
        private readonly ICaseInfoManager _caseInfoManager;
        private readonly SqlConnection _connection;
        private readonly SqlWorkflowInstanceStore _instanceStore;

        public CaseWorkflowManager(SqlWorkflowInstanceStore instanceStore, ICaseInfoManager caseInfoManager,
                                   SqlConnection connection)
        {
            _instanceStore = instanceStore;
            _caseInfoManager = caseInfoManager;
            _connection = connection;
        }

        #region ICaseWorkflowManager Members

        public void StartCase(Case @case)
        {
            var workflow = new CaseWorkflow {CaseType = @case.案件类型};

            string caseId = @case.编号;
            var wfApp = new WorkflowApplication(workflow)
                            {
                                InstanceStore = _instanceStore,
                                PersistableIdle = e => PersistableIdleAction.Unload,
                                Completed = e =>
                                                {
                                                    Case c = _caseInfoManager.GetCaseById(caseId);
                                                    c.状态 = CaseState.Completed;
                                                }
                            };
            wfApp.Extensions.Add(new TaskActivityExtension(caseId, wfApp.Id, _connection));
        }

        public IEnumerable<string> GetPendingCaseIds(string taskName, User user)
        {
            throw new NotImplementedException();
        }

        public bool ResumeCase(string caseId, string taskName, object value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}