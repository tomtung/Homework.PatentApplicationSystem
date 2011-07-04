using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Homework.PatentApplicationSystem.Model.Data;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    internal class CaseWorkflowManager : ICaseWorkflowManager
    {
        public const string CaseIdColumnName = "CaseId";
        public const string WorkflowinstanceidColumnName = "WorkflowInstanceId";
        public const string BookmarkNameColumnName = "BookmarkName";
        public const string BookmarkTableName = "WorkflowBookmark";
        private readonly ICaseInfoManager _caseInfoManager;
        private readonly string _connectionString;

        public CaseWorkflowManager(ICaseInfoManager caseInfoManager, string connectionString)
        {
            _caseInfoManager = caseInfoManager;
            _connectionString = connectionString;
        }

        #region ICaseWorkflowManager Members

        public void StartCase(Case @case)
        {
            WorkflowApplication wfApp = GetWorkflowApplication(new CaseWorkflow {CaseType = @case.案件类型}, @case.编号);
            lock (this)
                wfApp.Run();
        }

        public IEnumerable<string> GetPendingCaseIds(string taskName, User user)
        {
            if (!TaskNames.TasksOf(user.Role).Contains(taskName))
                return new string[0];

            return GetAllCaseIdsPendingAt(taskName).Where(id => IsTaskAssignedToUser(id, taskName, user));
        }


        public bool ResumeCase(string caseId, string taskName, object value)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader =
                        connection.Select(BookmarkTableName,
                                          new KeyValuePair<string, object>(CaseIdColumnName, caseId));
                    using (reader)
                    {
                        reader.Read();
                        Guid instanceId = Guid.Parse((string) reader[WorkflowinstanceidColumnName]);
                        WorkflowApplication wfApp = GetWorkflowApplication(new CaseWorkflow(), caseId);
                        lock (this)
                        {
                            wfApp.Load(instanceId);
                            return wfApp.ResumeBookmark(taskName, value) == BookmarkResumptionResult.Success;
                        }
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        #endregion

        private WorkflowApplication GetWorkflowApplication(Activity workflow, string caseId)
        {
            var wfApp = new WorkflowApplication(workflow)
                            {
                                InstanceStore = new SqlWorkflowInstanceStore(_connectionString),
                                PersistableIdle = e => PersistableIdleAction.Unload,
                                Completed = e =>
                                                {
                                                    Case? nullableCase = _caseInfoManager.GetCaseById(caseId);
                                                    if (nullableCase == null) return;
                                                    Case completedCase = nullableCase.Value;
                                                    completedCase.状态 = CaseState.Completed;
                                                    _caseInfoManager.UpdateCase(completedCase);
                                                }
                            };
            wfApp.Extensions.Add(new TaskActivityExtension(caseId, _connectionString));
            return wfApp;
        }

        private IEnumerable<string> GetAllCaseIdsPendingAt(string taskName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var caseIds = new List<string>();
                SqlDataReader reader =
                    connection.Select(BookmarkTableName,
                                      new KeyValuePair<string, object>(BookmarkNameColumnName,
                                                                       taskName));
                using (reader)
                    while (reader.Read())
                        caseIds.Add(reader[CaseIdColumnName].ToString());
                return caseIds;
            }
        }

        private bool IsTaskAssignedToUser(string caseId, string taskName, User user)
        {
            Case? nullableCase = _caseInfoManager.GetCaseById(caseId);
            if (nullableCase == null) return false;

            if (user.Role != Role.办案员) return true;

            Case @case = nullableCase.Value;
            return (taskName == TaskNames.撰写五书 || taskName == TaskNames.官方来函办案 || taskName == TaskNames.客户指示办案)
                   && @case.主办员用户名 == user.UserName
                   || taskName == TaskNames.原始资料翻译 && @case.翻译用户名 == user.UserName
                   || taskName == TaskNames.原始资料翻译一校 && @case.一校用户名 == user.UserName
                   || taskName == TaskNames.原始资料翻译二校 && @case.二校用户名 == user.UserName;
        }
    }
}