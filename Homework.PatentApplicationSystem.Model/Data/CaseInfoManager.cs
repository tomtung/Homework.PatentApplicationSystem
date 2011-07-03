using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Data
{
    internal class CaseInfoManager : ICaseInfoManager
    {
        private const string CaseTableName = "案件";
        private readonly SqlConnection _connection;

        public CaseInfoManager(SqlConnection connection)
        {
            _connection = connection;
        }

        #region ICaseInfoManager Members

        public Case? GetCaseById(string caseId)
        {
            using (_connection)
            {
                _connection.Open();
                SqlDataReader reader = _connection.Select(CaseTableName,
                                                          new KeyValuePair<string, object>("编号", caseId));
                using (reader)
                {
                    if (reader.Read())
                        return ExtractCase(reader);
                    return null;
                }
            }
        }

        public void AddCase(Case @case)
        {
            using (_connection)
            {
                _connection.Open();
                _connection.Insert(CaseTableName, ToKeyValuePairs(@case));
            }
        }


        public void UpdateCase(Case @case)
        {
            using (_connection)
            {
                _connection.Open();
                _connection.Update(CaseTableName,
                                   new KeyValuePair<string, object>("编号", @case.编号),
                                   ToKeyValuePairs(@case));
            }
        }

        #endregion

        private static IEnumerable<KeyValuePair<string, object>> ToKeyValuePairs(Case @case)
        {
            return new Dictionary<string, object>
                       {
                           {"编号", @case.编号},
                           {"名称", @case.名称},
                           {"案件类型", @case.案件类型},
                           {"创建时间", @case.创建时间},
                           {"绝限日", @case.绝限日},
                           {"状态", @case.状态},
                           {"客户号", @case.客户号},
                           {"申请人证件号", @case.申请人证件号},
                           {"发明人身份证号", @case.发明人身份证号},
                           {"主办员用户名", @case.主办员用户名},
                           {"翻译用户名", @case.翻译用户名},
                           {"一校用户名", @case.一校用户名},
                           {"二校用户名", @case.二校用户名}
                       };
        }


        private static Case ExtractCase(SqlDataReader reader)
        {
            return new Case
                       {
                           编号 = (string) reader["编号"],
                           名称 = (string) reader["名称"],
                           案件类型 = ((string) reader["案件类型"]).EnumParse<CaseType>(),
                           创建时间 = (DateTime) reader["创建时间"],
                           绝限日 = (DateTime) reader["绝限日"],
                           状态 = ((string) reader["状态"]).EnumParse<CaseState>(),
                           客户号 = (string) reader["客户号"],
                           申请人证件号 = (string) reader["申请人证件号"],
                           发明人身份证号 = (string) reader["发明人身份证号"],
                           主办员用户名 = (string) reader["主办员用户名"],
                           翻译用户名 = (string) reader["翻译用户名"],
                           一校用户名 = (string) reader["一校用户名"],
                           二校用户名 = (string) reader["二校用户名"]
                       };
        }
    }
}