using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Data
{
    internal class ClientInfoManager : IClientInfoManager
    {
        private const string CustomerTableName = "客户";
        private const string ApplicantTableName = "申请人";
        private const string InventorTableName = "发明人";
        private const string CustomerContactTableName = "客户联系人";
        private readonly SqlConnection _connection;


        public ClientInfoManager(SqlConnection connection)
        {
            _connection = connection;
        }

        #region IClientInfoManager Members

        public void AddCustomer(Customer customer)
        {
            try
            {
                _connection.Open();
                _connection.Insert(CustomerTableName, ToKeyValuePairs(customer));
            }
            finally
            {
                _connection.Close();
            }
        }

        public void RemoveCustomer(Customer customer)
        {
            try
            {
                _connection.Open();
                _connection.Delete(CustomerTableName, new KeyValuePair<string, object>("客户号", customer.客户号));
            }
            finally
            {
                _connection.Close();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _connection.Open();
                _connection.Update(CustomerTableName,
                                   new KeyValuePair<string, object>("客户号", customer.客户号),
                                   ToKeyValuePairs(customer));
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                _connection.Open();
                List<Customer> customers;
                using (SqlDataReader reader = _connection.Select(CustomerTableName))
                {
                    customers = new List<Customer>();
                    while (reader.Read())
                        customers.Add(ExtractCustomer(reader));
                }
                return customers;
            }
            finally
            {
                _connection.Close();
            }
        }

        public Customer? GetCustomer(string 客户号)
        {
            try
            {
                _connection.Open();
                SqlDataReader reader = _connection.Select(CustomerTableName,
                                                          new KeyValuePair<string, object>("客户号", 客户号));
                using (reader)
                {
                    if (reader.Read())
                        return ExtractCustomer(reader);
                    return null;
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public void AddCustomerContact(CustomerContact contact)
        {
            try
            {
                _connection.Open();
                _connection.Insert(CustomerContactTableName, ToKeyValuePairs(contact));
            }
            finally
            {
                _connection.Close();
            }
        }

        public void RemoveCustomerContact(CustomerContact contact)
        {
            try
            {
                _connection.Open();
                _connection.Delete(CustomerContactTableName, new KeyValuePair<string, object>("客户号", contact.客户号));
            }
            finally
            {
                _connection.Close();
            }
        }

        public void UpdateCustomerContact(CustomerContact contact)
        {
            try
            {
                _connection.Open();
                _connection.Update(CustomerContactTableName,
                                   new KeyValuePair<string, object>("客户号", contact.客户号),
                                   ToKeyValuePairs(contact));
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<CustomerContact> GetCustomerContacts(string 客户号)
        {
            try
            {
                _connection.Open();
                var customerContacts = new List<CustomerContact>();
                SqlDataReader reader = _connection.Select(CustomerContactTableName,
                                                          new KeyValuePair<string, object>("客户号", 客户号));
                using (reader)
                {
                    while (reader.Read())
                        customerContacts.Add(ExtractCustomerContact(reader));
                }
                return customerContacts;
            }
            finally
            {
                _connection.Close();
            }
        }


        public void AddApplicant(Applicant applicant)
        {
            try
            {
                _connection.Open();
                _connection.Insert(ApplicantTableName, ToKeyValuePairs(applicant));
            }
            finally
            {
                _connection.Close();
            }
        }

        public void RemoveApplicant(Applicant applicant)
        {
            try
            {
                _connection.Open();
                _connection.Delete(ApplicantTableName, new KeyValuePair<string, object>("证件号", applicant.证件号));
            }
            finally
            {
                _connection.Close();
            }
        }

        public void UpdateApplicant(Applicant applicant)
        {
            try
            {
                _connection.Open();
                _connection.Update(ApplicantTableName,
                                   new KeyValuePair<string, object>("证件号", applicant.证件号),
                                   ToKeyValuePairs(applicant));
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<Applicant> GetAllApplicants()
        {
            try
            {
                _connection.Open();
                var applicants = new List<Applicant>();
                using (SqlDataReader reader = _connection.Select(ApplicantTableName))
                    while (reader.Read())
                        applicants.Add(ExtractApplicant(reader));
                return applicants;
            }
            finally
            {
                _connection.Close();
            }
        }

        public Applicant? GetApplicant(string 证件号)
        {
            try
            {
                _connection.Open();
                SqlDataReader reader = _connection.Select(ApplicantTableName,
                                                          new KeyValuePair<string, object>("证件号", 证件号));
                using (reader)
                {
                    if (reader.Read())
                        return ExtractApplicant(reader);
                    return null;
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public void AddInventor(Inventor inventor)
        {
            try
            {
                _connection.Open();
                _connection.Insert(InventorTableName, ToKeyValuePairs(inventor));
            }
            finally
            {
                _connection.Close();
            }
        }

        public void RemoveInventor(Inventor inventor)
        {
            try
            {
                _connection.Open();
                _connection.Delete(InventorTableName, new KeyValuePair<string, object>("身份证号", inventor.身份证号));
            }
            finally
            {
                _connection.Close();
            }
        }

        public void UpdateInventor(Inventor inventor)
        {
            try
            {
                _connection.Open();
                _connection.Update(InventorTableName,
                                   new KeyValuePair<string, object>("身份证号", inventor.身份证号),
                                   ToKeyValuePairs(inventor));
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<Inventor> GetAllInventors()
        {
            try
            {
                _connection.Open();
                var inventors = new List<Inventor>();
                using (SqlDataReader sqlDataReader = _connection.Select(InventorTableName))
                    while (sqlDataReader.Read())
                        inventors.Add(ExtractInventor(sqlDataReader));
                return inventors;
            }
            finally
            {
                _connection.Close();
            }
        }

        public Inventor? GetInventor(string 身份证号)
        {
            try
            {
                _connection.Open();
                SqlDataReader reader = _connection.Select(InventorTableName,
                                                          new KeyValuePair<string, object>("身份证号", 身份证号));
                using (reader)
                {
                    if (reader.Read())
                        return ExtractInventor(reader);
                    return null;
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        #endregion

        private static CustomerContact ExtractCustomerContact(SqlDataReader reader)
        {
            return new CustomerContact
                       {
                           姓名 = (string) reader["姓名"],
                           电话 = (string) reader["电话"],
                           Email = (string) reader["Email"],
                           联系人类型 = (string) reader["联系人类型"],
                           客户号 = (string) reader["客户号"]
                       };
        }

        private static Customer ExtractCustomer(SqlDataReader reader)
        {
            return new Customer
                       {
                           客户号 = (string) reader["客户号"],
                           类型 = (string) reader["类型"],
                           地址 = (string) reader["地址"],
                           邮编 = (string) reader["邮编"]
                       };
        }

        private static Applicant ExtractApplicant(SqlDataReader reader)
        {
            return new Applicant
                       {
                           证件号 = (string) reader["证件号"],
                           类型 = (string) reader["类型"],
                           中文名 = (string) reader["中文名"],
                           英文名 = (string) reader["英文名"],
                           简称 = (string) reader["简称"],
                           国家 = (string) reader["国家"],
                           省 = (string) reader["省"],
                           市区县 = (string) reader["市区县"],
                           中国地址 = (string) reader["中国地址"],
                           外国地址 = (string) reader["外国地址"],
                           邮编 = (string) reader["邮编"],
                           电话 = (string) reader["电话"],
                           传真 = (string) reader["传真"],
                           Email = (string) reader["Email"]
                       };
        }


        private static IEnumerable<KeyValuePair<string, object>> ToKeyValuePairs(Customer customer)
        {
            return new Dictionary<string, object>
                       {
                           {"客户号", customer.客户号},
                           {"类型", customer.类型},
                           {"地址", customer.地址},
                           {"邮编", customer.邮编}
                       };
        }


        private static IEnumerable<KeyValuePair<string, object>> ToKeyValuePairs(CustomerContact contact)
        {
            return new Dictionary<string, object>
                       {
                           {"姓名", contact.姓名},
                           {"电话", contact.电话},
                           {"Email", contact.Email},
                           {"联系人类型", contact.联系人类型},
                           {"客户号", contact.客户号}
                       };
        }

        private static IEnumerable<KeyValuePair<string, object>> ToKeyValuePairs(Applicant applicant)
        {
            return new Dictionary<string, object>
                       {
                           {"证件号", applicant.证件号},
                           {"类型", applicant.类型},
                           {"中文名", applicant.中文名},
                           {"英文名", applicant.英文名},
                           {"简称", applicant.简称},
                           {"国家", applicant.国家},
                           {"省", applicant.省},
                           {"市区县", applicant.市区县},
                           {"中国地址", applicant.中国地址},
                           {"外国地址", applicant.外国地址},
                           {"邮编", applicant.邮编},
                           {"电话", applicant.电话},
                           {"传真", applicant.传真},
                           {"Email", applicant.Email}
                       };
        }


        private static IEnumerable<KeyValuePair<string, object>> ToKeyValuePairs(Inventor inventor)
        {
            return new Dictionary<string, object>
                       {
                           {"身份证号", inventor.身份证号},
                           {"姓名", inventor.姓名},
                           {"电话", inventor.电话},
                           {"Email", inventor.Email}
                       };
        }


        private static Inventor ExtractInventor(SqlDataReader reader)
        {
            return new Inventor
                       {
                           Email = (string) reader["Email"],
                           姓名 = (string) reader["姓名"],
                           电话 = (string) reader["电话"],
                           身份证号 = (string) reader["身份证号"]
                       };
        }
    }
}