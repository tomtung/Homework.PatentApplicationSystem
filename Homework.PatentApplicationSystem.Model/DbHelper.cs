using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 数据库访问帮助类
    /// </summary>
    public class DbHelper : IDbHelper
    {
        public SqlCommand Command { get; set; }
        public SqlConnection Connection { get; set; }

        public DbHelper(string sqlString)
        {
            Connection = new SqlConnection(sqlString);
            Connection.Open();
            Command = new SqlCommand { Connection = this.Connection };
        }

        public void Close()
        {
            Connection.Close();
        }


        public int ExecuteNonQuery(string sqlString)
        {
            Command.CommandText = sqlString;
            var rows = Command.ExecuteNonQuery();
            return rows;
        }

        public int Add(string tableName, params KeyValuePair<string,Object>[] keyValue)
        {
            var keys = "";
            var values = "";
            for (int i = 0; i < keyValue.Length; ++i)
            {
                keys += keyValue[i].Key;
                values += keyValue[i].Value.ToString();
                if (i == keyValue.Length) continue;
                keys += ",";
                values += ",";
            }
            new int[]{1,2,3}.Skip()
            var s = new int[] {1, 2, 3}.Aggregate("", (current, i) => current + (i.ToString() + ','));
            var sqlCommand = 
                string.Format("insert into [{0}] ({1}) values ({2})",
                tableName, keys, values);
            return this.ExecuteNonQuery(sqlCommand);
        }

        public int Update(string tableName, KeyValuePair<string,Object> condition ,params KeyValuePair<string, Object>[] keyValue)
        {
            var conditionString = "";

            var sqlCommand =
                string.Format("update [{0}] set {1} where {2}",
                tableName, 
            return this.ExecuteNonQuery(sqlCommand);
        }

        public SqlDataReader ExecuteQuery(string sqlString)
        {
            Command.CommandText = sqlString;
            return Command.ExecuteReader();
        }

        //private Tuple<string, string> ConstructKeyValue(KeyValuePair<string,Object>[] keyValue)
        //{
        //    var keys = "";
        //    var values = "";
        //    for(int i = 0; i < keyValue.Length; ++i)
        //    {
        //        keys += keyValue[i].Key;
        //        values += keyValue[i].Value.ToString();
        //        if (i == keyValue.Length) continue;
        //        keys += ",";
        //        values += ",";
        //    }
        //    return new Tuple<string, string>(keys, values);
        //}
    }
}
