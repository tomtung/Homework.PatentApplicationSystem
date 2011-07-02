using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Data
{
    class CaseInfoManager:ICaseInfoManager
    {
        private readonly SqlConnection _connection;

        public CaseInfoManager(SqlConnection connection)
        {
            _connection = connection;
        }

        public Case? GetCaseById(string caseId)
        {
            _connection.Open();
            var sqlDataReader = _connection.Select("案件", new KeyValuePair<string, object>("编号", caseId));
            Case? @case = null;
            if (sqlDataReader.Read())
                @case = new Case()
                            {
                                编号=@case.Value.编号,
                                名称 = (string)sqlDataReader["名称"],
                                案件类型 = (CaseType)sqlDataReader["案件类型"],
                                创建时间 = (DateTime)sqlDataReader["创建时间"],
                                绝限日 = (DateTime)sqlDataReader["绝限日"],
                                状态 = (CaseState)sqlDataReader["状态"],
                                客户号 = (string)sqlDataReader["客户号"],
                                申请人证件号 = (string)sqlDataReader["申请人证件号"],
                                发明人身份证号 = (string)sqlDataReader["发明人身份证号"],
                                主办员用户名 = (string)sqlDataReader["主办员用户名"],
                                翻译用户名 = (string)sqlDataReader["翻译用户名"],
                                一校用户名 = (string)sqlDataReader["一校用户名"],
                                二校用户名 = (string)sqlDataReader["二校用户名"]
                            };
            sqlDataReader.Close();
            _connection.Close();
            return @case;
        }

        public void AddCase(Case @case)
        {
            _connection.Open();
            var dictionary = new Dictionary<string, object>()
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
            _connection.Insert("案件", dictionary );
            _connection.Close();
        }
    }
}
