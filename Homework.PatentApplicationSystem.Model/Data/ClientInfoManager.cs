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
        private readonly string _connectionString;


        public ClientInfoManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region IClientInfoManager Members

        public void AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Insert(CustomerTableName, ToKeyValuePairs(customer));
            }
        }

        public void RemoveCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Delete(CustomerTableName, new KeyValuePair<string, object>("客户号", customer.客户号));
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Update(CustomerTableName,
                                  new KeyValuePair<string, object>("客户号", customer.客户号),
                                  ToKeyValuePairs(customer));
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                List<Customer> customers;
                using (SqlDataReader reader = connection.Select(CustomerTableName))
                {
                    customers = new List<Customer>();
                    while (reader.Read())
                        customers.Add(ExtractCustomer(reader));
                }
                return customers;
            }
        }

        public Customer? GetCustomer(string 客户号)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataReader reader = connection.Select(CustomerTableName,
                                                         new KeyValuePair<string, object>("客户号", 客户号));
                using (reader)
                {
                    if (reader.Read())
                        return ExtractCustomer(reader);
                    return null;
                }
            }
        }

        public void AddCustomerContact(CustomerContact contact)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Insert(CustomerContactTableName, ToKeyValuePairs(contact));
            }
        }

        public void RemoveCustomerContact(CustomerContact contact)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Delete(CustomerContactTableName, new KeyValuePair<string, object>("姓名", contact.姓名));
            }
        }

        public void UpdateCustomerContact(CustomerContact contact)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Update(CustomerContactTableName,
                                  new KeyValuePair<string, object>("客户号", contact.客户号),
                                  ToKeyValuePairs(contact));
            }
        }

        public IEnumerable<CustomerContact> GetCustomerContacts(string 客户号)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var customerContacts = new List<CustomerContact>();
                SqlDataReader reader = connection.Select(CustomerContactTableName,
                                                         new KeyValuePair<string, object>("客户号", 客户号));
                using (reader)
                {
                    while (reader.Read())
                        customerContacts.Add(ExtractCustomerContact(reader));
                }
                return customerContacts;
            }
        }


        public void AddApplicant(Applicant applicant)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Insert(ApplicantTableName, ToKeyValuePairs(applicant));
            }
        }

        public void RemoveApplicant(Applicant applicant)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Delete(ApplicantTableName, new KeyValuePair<string, object>("证件号", applicant.证件号));
            }
        }

        public void UpdateApplicant(Applicant applicant)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Update(ApplicantTableName,
                                  new KeyValuePair<string, object>("证件号", applicant.证件号),
                                  ToKeyValuePairs(applicant));
            }
        }

        public IEnumerable<Applicant> GetAllApplicants()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var applicants = new List<Applicant>();
                using (SqlDataReader reader = connection.Select(ApplicantTableName))
                    while (reader.Read())
                        applicants.Add(ExtractApplicant(reader));
                return applicants;
            }
        }

        public Applicant? GetApplicant(string 证件号)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataReader reader = connection.Select(ApplicantTableName,
                                                         new KeyValuePair<string, object>("证件号", 证件号));
                using (reader)
                {
                    if (reader.Read())
                        return ExtractApplicant(reader);
                    return null;
                }
            }
        }

        public void AddInventor(Inventor inventor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Insert(InventorTableName, ToKeyValuePairs(inventor));
            }
        }

        public void RemoveInventor(Inventor inventor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Delete(InventorTableName, new KeyValuePair<string, object>("身份证号", inventor.身份证号));
            }
        }

        public void UpdateInventor(Inventor inventor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Update(InventorTableName,
                                  new KeyValuePair<string, object>("身份证号", inventor.身份证号),
                                  ToKeyValuePairs(inventor));
            }
        }

        public IEnumerable<Inventor> GetAllInventors()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var inventors = new List<Inventor>();
                using (SqlDataReader sqlDataReader = connection.Select(InventorTableName))
                    while (sqlDataReader.Read())
                        inventors.Add(ExtractInventor(sqlDataReader));
                return inventors;
            }
        }

        public Inventor? GetInventor(string 身份证号)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataReader reader = connection.Select(InventorTableName,
                                                         new KeyValuePair<string, object>("身份证号", 身份证号));
                using (reader)
                {
                    if (reader.Read())
                        return ExtractInventor(reader);
                    return null;
                }
            }
        }

        #endregion

        private static CustomerContact ExtractCustomerContact(SqlDataReader reader)
        {
            return new CustomerContact
                       {
                           姓名 = reader["姓名"] as string,
                           电话 = reader["电话"] as string,
                           Email = reader["Email"] as string,
                           联系人类型 = reader["联系人类型"] as string,
                           客户号 = reader["客户号"] as string
                       };
        }

        private static Customer ExtractCustomer(SqlDataReader reader)
        {
            return new Customer
                       {
                           客户号 = reader["客户号"] as string,
                           类型 = reader["类型"] as string,
                           地址 = reader["地址"] as string,
                           邮编 = reader["邮编"] as string
                       };
        }

        private static Applicant ExtractApplicant(SqlDataReader reader)
        {
            return new Applicant
                       {
                           证件号 = reader["证件号"] as string,
                           类型 = reader["类型"] as string,
                           中文名 = reader["中文名"] as string,
                           英文名 = reader["英文名"] as string,
                           简称 = reader["简称"] as string,
                           国家 = reader["国家"] as string,
                           省 = reader["省"] as string,
                           市区县 = reader["市区县"] as string,
                           中国地址 = reader["中国地址"] as string,
                           外国地址 = reader["外国地址"] as string,
                           邮编 = reader["邮编"] as string,
                           电话 = reader["电话"] as string,
                           传真 = reader["传真"] as string,
                           Email = reader["Email"] as string
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