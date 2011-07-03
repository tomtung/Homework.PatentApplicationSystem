﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Data
{
    internal class CaseInfoManager : ICaseInfoManager
    {
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
                using (SqlDataReader reader = _connection.Select("案件", new KeyValuePair<string, object>("编号", caseId)))
                {
                    if (reader.Read())
                    {
                        CaseType caseType;
                        Enum.TryParse((string) reader["案件类型"], out caseType);
                        CaseState caseState;
                        Enum.TryParse((string) reader["状态"], out caseState);

                        return new Case
                                   {
                                       编号 = (string) reader["编号"],
                                       名称 = (string) reader["名称"],
                                       案件类型 = caseType,
                                       创建时间 = (DateTime) reader["创建时间"],
                                       绝限日 = (DateTime) reader["绝限日"],
                                       状态 = caseState,
                                       客户号 = (string) reader["客户号"],
                                       申请人证件号 = (string) reader["申请人证件号"],
                                       发明人身份证号 = (string) reader["发明人身份证号"],
                                       主办员用户名 = (string) reader["主办员用户名"],
                                       翻译用户名 = (string) reader["翻译用户名"],
                                       一校用户名 = (string) reader["一校用户名"],
                                       二校用户名 = (string) reader["二校用户名"]
                                   };
                    }
                    return null;
                }
            }
        }

        public void AddCase(Case @case)
        {
            using (_connection)
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
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
                _connection.Insert("案件", dictionary);
            }
        }

        #endregion
    }
}