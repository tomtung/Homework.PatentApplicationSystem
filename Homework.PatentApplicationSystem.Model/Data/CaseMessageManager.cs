using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Data
{
    internal class CaseMessageManager : ICaseMessageManager
    {
        private const string TableName = "CaseMessage";
        private readonly SqlConnection _connection;

        public CaseMessageManager(SqlConnection connection)
        {
            _connection = connection;
        }

        #region Implementation of ICaseMessageManager

        public IEnumerable<CaseMessage> GetMessagesOf(string 案件编号)
        {
            try
            {
                _connection.Open();
                SqlDataReader reader = _connection.Select(TableName, new KeyValuePair<string, object>("案件编号", 案件编号));
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
                                                 SenderUsername = (string) reader["SendUsername"]
                                             });
                    }
                }
                return caseMessages;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void AddMessage(CaseMessage doc)
        {
            try
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
                                     {
                                         {"案件编号", doc.案件编号},
                                         {"Content", doc.Content},
                                         {"SenderUsername", doc.SenderUsername}
                                     };
                _connection.Insert(TableName, dictionary);
            }
            finally
            {
                _connection.Close();
            }
        }

        #endregion
    }
}