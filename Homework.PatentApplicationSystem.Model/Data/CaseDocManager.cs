using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Data
{
    internal class CaseDocManager : ICaseDocManager
    {
        private const string CaseDocTableName = "案件文件";
        private readonly string _connectionString;

        public CaseDocManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region ICaseDocManager Members

        public IEnumerable<CaseDoc> GetDocsOf(string 案件编号)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataReader reader = connection.Select(CaseDocTableName,
                                                         new KeyValuePair<string, object>("案件编号", 案件编号));
                List<CaseDoc> caseDocs;
                using (reader)
                {
                    caseDocs = new List<CaseDoc>();
                    while (reader.Read())
                        caseDocs.Add(new CaseDoc
                                         {
                                             FileName = (string) reader["文件名"],
                                             UploadUserName = (string) reader["创建人"],
                                             UploadDateTime = (DateTime) reader["创建日期"],
                                             FilePath = (string) reader["文件路径"]
                                         });
                }
                return caseDocs;
            }
        }

        public void AddDoc(CaseDoc doc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var dictionary = new Dictionary<string, object>
                                     {
                                         {"文件名", doc.FileName},
                                         {"创建人", doc.UploadUserName},
                                         {"创建日期", doc.UploadDateTime},
                                         {"文件路径", doc.FilePath}
                                     };
                connection.Insert(CaseDocTableName, dictionary);
            }
        }

        public void RemoveDoc(CaseDoc doc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var prKey1 = new KeyValuePair<string, object>("案件编号", doc.案件编号);
                var prKey2 = new KeyValuePair<string, object>("文件名", doc.FileName);
                string command = string.Format("DELETE FROM [{0}] WHERE {1} = @{1} AND {2}=@{2}", CaseDocTableName,
                                               prKey1.Key, prKey2.Key);
                connection.ExecuteNonQuery(command);
            }
        }

        #endregion
    }
}