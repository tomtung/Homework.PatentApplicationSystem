using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Data
{
    internal class CaseMessageManager : ICaseMessageManager
    {
        private const string TableName = "CaseMessage";
        private readonly string _connectionString;

        public CaseMessageManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Implementation of ICaseMessageManager

        public IEnumerable<CaseMessage> GetMessagesOf(string 案件编号)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataReader reader = connection.Select(TableName, new KeyValuePair<string, object>("案件编号", 案件编号));
                List<CaseMessage> caseMessages;
                using (reader)
                {
                    caseMessages = new List<CaseMessage>();
                    while (reader.Read())
                    {
                        caseMessages.Add(new CaseMessage
                                             {
                                                 案件编号 = (string) reader["案件编号"],
                                                 Content = (string) reader["Content"],
                                                 SenderUsername = (string) reader["SenderName"]
                                             });
                    }
                }
                return caseMessages;
            }
        }

        public void AddMessage(CaseMessage doc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var dictionary = new Dictionary<string, object>
                                     {
                                         {"案件编号", doc.案件编号},
                                         {"Content", doc.Content},
                                         {"SenderName", doc.SenderUsername}
                                     };
                connection.Insert(TableName, dictionary);
            }
        }

        #endregion
    }
}