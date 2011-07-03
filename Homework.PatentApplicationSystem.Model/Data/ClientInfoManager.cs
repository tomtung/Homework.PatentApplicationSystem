using System.Collections.Generic;
using System.Data.SqlClient;

namespace Homework.PatentApplicationSystem.Model.Data
{
    internal class ClientInfoManager : IClientInfoManager
    {
        private readonly SqlConnection _connection;

        public ClientInfoManager(SqlConnection connection)
        {
            _connection = connection;
        }

        #region IClientInfoManager Members

        public void AddCustomer(Customer customer)
        {
            using (_connection)
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
                                     {
                                         {"客户号", customer.客户号},
                                         {"类型", customer.类型},
                                         {"地址", customer.地址},
                                         {"邮编", customer.邮编}
                                     };
                _connection.Insert("客户", dictionary);
            }
        }

        public void RemoveCustomer(Customer customer)
        {
            using (_connection)
            {
                _connection.Open();
                _connection.Delete("客户", new KeyValuePair<string, object>("客户号", customer.客户号));
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (_connection)
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
                                     {
                                         {"客户号", customer.客户号},
                                         {"类型", customer.类型},
                                         {"地址", customer.地址},
                                         {"邮编", customer.邮编}
                                     };
                _connection.Update("客户", new KeyValuePair<string, object>("客户号", customer.客户号), dictionary);
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (_connection)
            {
                _connection.Open();
                List<Customer> customers;
                using (SqlDataReader reader = _connection.Select("客户"))
                {
                    customers = new List<Customer>();
                    while (reader.Read())
                        customers.Add(new Customer
                                          {
                                              客户号 = (string) reader["客户号"],
                                              类型 = (string) reader["类型"],
                                              地址 = (string) reader["地址"],
                                              邮编 = (string) reader["邮编"]
                                          });
                }
                return customers;
            }
        }

        public Customer? GetCustomer(string 客户号)
        {
            using (_connection)
            {
                _connection.Open();
                SqlDataReader reader = _connection.Select("客户", new KeyValuePair<string, object>("客户号", 客户号));
                using (reader)
                {
                    if (reader.Read())
                        return new Customer
                                   {
                                       客户号 = (string) reader["客户号"],
                                       类型 = (string) reader["类型"],
                                       地址 = (string) reader["地址"],
                                       邮编 = (string) reader["邮编"]
                                   };
                    return null;
                }
            }
        }

        public void AddCustomerContact(CustomerContact contact)
        {
            using (_connection)
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
                                     {
                                         {"姓名", contact.姓名},
                                         {"电话", contact.电话},
                                         {"Email", contact.Email},
                                         {"联系人类型", contact.联系人类型},
                                         {"客户号", contact.客户号}
                                     };
                _connection.Insert("客户联系人", dictionary);
            }
        }

        public void RemoveCustomerContact(CustomerContact contact)
        {
            using (_connection)
            {
                _connection.Open();
                _connection.Delete("客户联系人", new KeyValuePair<string, object>("客户号", contact.客户号));
            }
        }

        public void UpdateCustomerContact(CustomerContact contact)
        {
            using (_connection)
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
                                     {
                                         {"姓名", contact.姓名},
                                         {"电话", contact.电话},
                                         {"Email", contact.Email},
                                         {"联系人类型", contact.联系人类型},
                                         {"客户号", contact.客户号}
                                     };
                _connection.Update("客户联系人", new KeyValuePair<string, object>("客户号", contact.客户号), dictionary);
            }
        }

        public IEnumerable<CustomerContact> GetCustomerContacts(string 客户号)
        {
            using (_connection)
            {
                _connection.Open();
                var customerContacts = new List<CustomerContact>();
                SqlDataReader reader = _connection.Select("客户联系人",
                                                          new KeyValuePair<string, object>("客户号", 客户号));
                using (reader)
                {
                    while (reader.Read())
                        customerContacts.Add(new CustomerContact
                                                 {
                                                     姓名 = (string) reader["姓名"],
                                                     电话 = (string) reader["电话"],
                                                     Email = (string) reader["Email"],
                                                     联系人类型 = (string) reader["联系人类型"],
                                                     客户号 = (string) reader["客户号"]
                                                 });
                }
                return customerContacts;
            }
        }

        public void AddApplicant(Applicant applicant)
        {
            using (_connection)
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
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
                _connection.Insert("申请人", dictionary);
            }
        }

        public void RemoveApplicant(Applicant applicant)
        {
            using (_connection)
            {
                _connection.Open();
                _connection.Delete("申请人", new KeyValuePair<string, object>("证件号", applicant.证件号));
            }
        }

        public void UpdateApplicant(Applicant applicant)
        {
            using (_connection)
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
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
                _connection.Update("申请人", new KeyValuePair<string, object>("证件号", applicant.证件号), dictionary);
            }
        }

        public IEnumerable<Applicant> GetAllApplicants()
        {
            using (_connection)
            {
                _connection.Open();
                var applicants = new List<Applicant>();
                using (SqlDataReader reader = _connection.Select("申请人"))
                    while (reader.Read())
                        applicants.Add(new Applicant
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
                                           });
                return applicants;
            }
        }

        public Applicant? GetApplicant(string 证件号)
        {
            using (_connection)
            {
                _connection.Open();
                SqlDataReader reader = _connection.Select("申请人", new KeyValuePair<string, object>("证件号", 证件号));
                using (reader)
                {
                    if (reader.Read())
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
                    return null;
                }
            }
        }

        public void AddInventor(Inventor inventor)
        {
            using (_connection)
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
                                     {
                                         {"身份证号", inventor.身份证号},
                                         {"姓名", inventor.姓名},
                                         {"电话", inventor.电话},
                                         {"Email", inventor.Email}
                                     };
                _connection.Insert("发明人", dictionary);
            }
        }

        public void RemoveInventor(Inventor inventor)
        {
            using (_connection)
            {
                _connection.Open();
                _connection.Delete("发明人", new KeyValuePair<string, object>("身份证号", inventor.身份证号));
            }
        }

        public void UpdateInventor(Inventor inventor)
        {
            using (_connection)
            {
                _connection.Open();
                var dictionary = new Dictionary<string, object>
                                     {
                                         {"身份证号", inventor.身份证号},
                                         {"姓名", inventor.姓名},
                                         {"电话", inventor.电话},
                                         {"Email", inventor.Email}
                                     };
                _connection.Update("发明人", new KeyValuePair<string, object>("身份证号", inventor.身份证号), dictionary);
            }
        }

        public IEnumerable<Inventor> GetAllInventors()
        {
            using (_connection)
            {
                _connection.Open();
                var inventors = new List<Inventor>();
                using (SqlDataReader sqlDataReader = _connection.Select("发明人"))
                    while (sqlDataReader.Read())
                        inventors.Add(new Inventor
                                          {
                                              Email = (string) sqlDataReader["Email"],
                                              姓名 = (string) sqlDataReader["姓名"],
                                              电话 = (string) sqlDataReader["电话"],
                                              身份证号 = (string) sqlDataReader["身份证号"]
                                          });
                return inventors;
            }
        }

        public Inventor? GetInventor(string 身份证号)
        {
            using (_connection)
            {
                _connection.Open();
                SqlDataReader reader = _connection.Select("发明人", new KeyValuePair<string, object>("身份证号", 身份证号));
                using (reader)
                {
                    if (reader.Read())
                        return new Inventor
                                   {
                                       Email = (string) reader["Email"],
                                       姓名 = (string) reader["姓名"],
                                       电话 = (string) reader["电话"],
                                       身份证号 = (string) reader["身份证号"]
                                   };
                    return null;
                }
            }
        }

        #endregion
    }
}