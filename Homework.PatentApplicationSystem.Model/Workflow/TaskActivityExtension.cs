using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    internal class TaskActivityExtension : ITaskActivityExtension
    {
        private readonly string _caseId;
        private readonly string _connectionString;

        #region Implementation of ITaskActivityExtension

        public void AddBookmarkRecord(string bookmarkName, object workflowInstanceId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Insert(CaseWorkflowManager.BookmarkTableName,
                                  new Dictionary<string, object>
                                      {
                                          {CaseWorkflowManager.CaseIdColumnName, _caseId},
                                          {CaseWorkflowManager.WorkflowinstanceidColumnName, workflowInstanceId},
                                          {CaseWorkflowManager.BookmarkNameColumnName, bookmarkName}
                                      });
            }
        }

        public void RemoveBookmarkRecord(string bookmarkName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string command = string.Format("DELETE FROM [{0}] WHERE {1} = @{1} AND {2} = @{2}",
                                               CaseWorkflowManager.BookmarkTableName,
                                               CaseWorkflowManager.CaseIdColumnName,
                                               CaseWorkflowManager.BookmarkNameColumnName);
                var parameters = new[]
                                     {
                                         new SqlParameter("@" + CaseWorkflowManager.CaseIdColumnName, _caseId),
                                         new SqlParameter("@" + CaseWorkflowManager.BookmarkNameColumnName, bookmarkName)
                                     };
                connection.ExecuteNonQuery(command, parameters);
            }
        }

        #endregion

        public TaskActivityExtension(string caseId, string connectionString)
        {
            _caseId = caseId;
            _connectionString = connectionString;
        }
    }
}