﻿using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private readonly SqlConnection _connection;
        private readonly SqlWorkflowInstanceStore _instanceStore;

        public CaseWorkflowManager(ICaseInfoManager caseInfoManager, SqlConnection connection,
                                   SqlWorkflowInstanceStore instanceStore)
        {
            _caseInfoManager = caseInfoManager;
            _connection = connection;
            _instanceStore = instanceStore;
        }

        #region ICaseWorkflowManager Members

        public void StartCase(Case @case)
        {
            WorkflowApplication wfApp = GetWorkflowApplication(@case);
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
            try
            {
                Case @case = _caseInfoManager.GetCaseById(caseId).Value;
                using (_connection)
                {
                    _connection.Open();
                    SqlDataReader reader = _connection.Select(BookmarkTableName,
                                                              new KeyValuePair<string, object>(CaseIdColumnName, caseId));
                    using (reader)
                    {
                        reader.Read();
                        Guid instanceId = Guid.Parse(reader[WorkflowinstanceidColumnName].ToString());
                        WorkflowApplication wfApp = GetWorkflowApplication(@case);
                        wfApp.Load(instanceId);
                        return wfApp.ResumeBookmark(taskName, value) == BookmarkResumptionResult.Success;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        private WorkflowApplication GetWorkflowApplication(Case @case)
        {
            var wfApp = new WorkflowApplication(new CaseWorkflow {CaseType = @case.案件类型})
                            {
                                InstanceStore = _instanceStore,
                                PersistableIdle = e => PersistableIdleAction.Unload,
                                Completed = e =>
                                                {
                                                    Case? nullableCase = _caseInfoManager.GetCaseById(@case.编号);
                                                    if (nullableCase == null) return;
                                                    Case completedCase = nullableCase.Value;
                                                    completedCase.状态 = CaseState.Completed;
                                                    // TODO
                                                    //_caseInfoManager.Update(completedCase);
                                                }
                            };
            wfApp.Extensions.Add(new TaskActivityExtension(@case.编号, wfApp.Id, _connection));
            return wfApp;
        }

        private IEnumerable<string> GetAllCaseIdsPendingAt(string taskName)
        {
            using (_connection)
            {
                _connection.Open();
                var caseIds = new List<string>();
                SqlDataReader reader = _connection.Select(BookmarkTableName,
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