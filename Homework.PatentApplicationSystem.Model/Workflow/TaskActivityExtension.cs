using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    internal class TaskActivityExtension : ITaskActivityExtension
    {
        private readonly string _caseId;
        private readonly SqlConnection _connection;

        private readonly Guid _workflowInstanceId;

        #region Implementation of ITaskActivityExtension

        public string CaseId
        {
            get { return _caseId; }
        }

        public Guid WorkflowInstanceId
        {
            get { return _workflowInstanceId; }
        }

        public void AddBookmarkRecord(string bookmarkName)
        {
            _connection.Open();
            _connection.Insert(CaseWorkflowManager.BookmarkTableName,
                               new Dictionary<string, object>
                                   {
                                       {CaseWorkflowManager.CaseIdColumnName, CaseId},
                                       {CaseWorkflowManager.WorkflowinstanceidColumnName, WorkflowInstanceId},
                                       {CaseWorkflowManager.BookmarkNameColumnName, bookmarkName}
                                   });
            _connection.Close();
        }

        public void RemoveBookmarkRecord(string bookmarkName)
        {
            _connection.Open();
            string command = string.Format("DELETE FROM [{0}] WHERE {1} = @{1} AND {2} = @{2}",
                                           CaseWorkflowManager.BookmarkTableName, CaseWorkflowManager.CaseIdColumnName,
                                           CaseWorkflowManager.BookmarkNameColumnName);
            var parameters = new[]
                                 {
                                     new SqlParameter("@" + CaseWorkflowManager.CaseIdColumnName, CaseId),
                                     new SqlParameter("@" + CaseWorkflowManager.BookmarkNameColumnName, bookmarkName)
                                 };
            _connection.ExecuteNonQuery(command, parameters);
            _connection.Close();
        }

        #endregion

        public TaskActivityExtension(string caseId, Guid workflowInstanceId, SqlConnection connection)
        {
            _caseId = caseId;
            _connection = connection;
            _workflowInstanceId = workflowInstanceId;
        }
    }
}