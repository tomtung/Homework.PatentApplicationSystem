using System;
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
            _connection.Open();
            var dictionary = new Dictionary<string, object>
                                 {
                                     {"客户号", customer.客户号},
                                     {"类型", customer.类型},
                                     {"地址",customer.地址},
                                     {"邮编",customer.邮编}
                                 };
            _connection.Insert("客户", dictionary);
            _connection.Close();
        }

        public void RemoveCustomer(Customer customer)
        {
            _connection.Open();
            _connection.Delete("客户", new KeyValuePair<string, object>("客户号", customer.客户号));
            _connection.Close();
        }

        public void UpdateCustomer(Customer customer)
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
            _connection.Close();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            _connection.Open();
            var sqlDataReader = _connection.Select("客户");
            var customers = new List<Customer>();
            while (sqlDataReader.Read())
                customers.Add(new Customer
                                  {客户号=(string) sqlDataReader["客户号"], 类型=(string) sqlDataReader["类型"], 
                                      地址=(string) sqlDataReader["地址"], 邮编=(string) sqlDataReader["邮编"]});
            sqlDataReader.Close();
            _connection.Close();
            return customers;
        }

        public Customer? GetCustomer(string 客户号)
        {
            _connection.Open();
            var sqlDataReader = _connection.Select("客户", new KeyValuePair<string, object>("客户号", 客户号));
            Customer? customer = null;
            if (sqlDataReader.Read())
            {
                customer = new Customer
                               {
                                   客户号 = (string) sqlDataReader["客户号"],
                                   类型 = (string) sqlDataReader["类型"],
                                   地址 = (string) sqlDataReader["地址"],
                                   邮编 = (string) sqlDataReader["邮编"]
                               };

            }
            sqlDataReader.Close();
            _connection.Close();
            return customer;
        }

        public void AddCustomerContact(CustomerContact contact)
        {
            _connection.Open();
            var dictionary = new Dictionary<string,object>
                                 {
                                     {"姓名", contact.姓名},
                                     {"电话",contact.电话},
                                     {"Email",contact.Email},
                                     {"联系人类型", contact.联系人类型},
                                     {"客户号", contact.客户号}
                                 };
            _connection.Insert("客户联系人", dictionary);
            _connection.Close();
        }

        public void RemoveCustomerContact(CustomerContact contact)
        {
            _connection.Open();
            _connection.Delete("客户联系人", new KeyValuePair<string, object>("客户号", contact.客户号));
            _connection.Close();
        }

        public void UpdateCustomerContact(CustomerContact contact)
        {
            _connection.Open();
            var dictionary = new Dictionary<string,object>
                        {
                            {"姓名", contact.姓名},
                            {"电话",contact.电话},
                            {"Email",contact.Email},
                            {"联系人类型", contact.联系人类型},
                            {"客户号", contact.客户号}
                        };
            _connection.Update("客户联系人", new KeyValuePair<string, object>("客户号", contact.客户号),dictionary);
            _connection.Close();
        }

        public IEnumerable<CustomerContact> GetCustomerContacts(string 客户号)
        {
            _connection.Open();
            var sqlDataReader = _connection.Select("客户联系人", new KeyValuePair<string, object>("客户号", 客户号));
            var customerContacts = new List<CustomerContact>();
            while (sqlDataReader.Read())
                customerContacts.Add(new CustomerContact
                {
                    姓名 = (string)sqlDataReader["姓名"],
                    电话 = (string)sqlDataReader["电话"],
                    Email = (string)sqlDataReader["Email"],
                    联系人类型 = (string)sqlDataReader["联系人类型"],
                    客户号 = (string)sqlDataReader["客户号"]
                });
            sqlDataReader.Close();
            _connection.Close();
            return customerContacts;
        }

        public void AddApplicant(Applicant applicant)
        {
            _connection.Open();
            var dictionary = new Dictionary<string, object>
                                 {
                                     {"证件号",applicant.证件号},
                                     {"类型",applicant.类型},
                                     {"中文名",applicant.中文名},
                                     {"英文名",applicant.英文名},
                                     {"简称",applicant.简称},
                                     {"国家",applicant.国家},
                                     {"省",applicant.省},
                                     {"市区县",applicant.市区县},
                                     {"中国地址",applicant.中国地址},
                                     {"外国地址",applicant.外国地址},
                                     {"邮编",applicant.邮编},
                                     {"电话",applicant.电话},
                                     {"传真",applicant.传真},
                                     {"Email",applicant.Email}
                                 };
            _connection.Insert("申请人", dictionary);
            _connection.Close();
        }

        public void RemoveApplicant(Applicant applicant)
        {
            _connection.Open();
            _connection.Delete("申请人", new KeyValuePair<string, object>("证件号", applicant.证件号));
            _connection.Close();
        }

        public void UpdateApplicant(Applicant applicant)
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
            _connection.Close();
        }

        public IEnumerable<Applicant> GetAllApplicants()
        {
            _connection.Open();
            var sqlDataReader = _connection.Select("申请人");
            var applicants = new List<Applicant>();
            while (sqlDataReader.Read())
                applicants.Add(new Applicant
                                   {
                                       证件号 = (string) sqlDataReader["证件号"],
                                       类型 = (string) sqlDataReader["类型"],
                                       中文名 = (string) sqlDataReader["中文名"],
                                       英文名 = (string) sqlDataReader["英文名"],
                                       简称 = (string) sqlDataReader["简称"],
                                       国家 = (string) sqlDataReader["国家"],
                                       省 = (string) sqlDataReader["省"],
                                       市区县 = (string) sqlDataReader["市区县"],
                                       中国地址 = (string) sqlDataReader["中国地址"],
                                       外国地址 = (string) sqlDataReader["外国地址"],
                                       邮编 = (string) sqlDataReader["邮编"],
                                       电话 = (string) sqlDataReader["电话"],
                                       传真 = (string) sqlDataReader["传真"],
                                       Email = (string) sqlDataReader["Email"]
                                   });
            sqlDataReader.Close();
            _connection.Close();
            return applicants;
        }

        public Applicant? GetApplicant(string 证件号)
        {
            _connection.Open();
            var sqlDataReader = _connection.Select("申请人", new KeyValuePair<string, object>("证件号", 证件号));
            Applicant? applicant = null;
            if (sqlDataReader.Read())
            {
                applicant = new Applicant
                                {
                                    证件号 = (string) sqlDataReader["证件号"],
                                    类型 = (string) sqlDataReader["类型"],
                                    中文名 = (string) sqlDataReader["中文名"],
                                    英文名 = (string) sqlDataReader["英文名"],
                                    简称 = (string) sqlDataReader["简称"],
                                    国家 = (string) sqlDataReader["国家"],
                                    省 = (string) sqlDataReader["省"],
                                    市区县 = (string) sqlDataReader["市区县"],
                                    中国地址 = (string) sqlDataReader["中国地址"],
                                    外国地址 = (string) sqlDataReader["外国地址"],
                                    邮编 = (string) sqlDataReader["邮编"],
                                    电话 = (string) sqlDataReader["电话"],
                                    传真 = (string) sqlDataReader["传真"],
                                    Email = (string) sqlDataReader["Email"]
                                };
            }
            sqlDataReader.Close();
            _connection.Close();
            return applicant;
        }

        public void AddInventor(Inventor inventor)
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
            _connection.Close();
        }

        public void RemoveInventor(Inventor inventor)
        {
            _connection.Open();
            _connection.Delete("发明人", new KeyValuePair<string, object>("身份证号", inventor.身份证号));
            _connection.Close();
        }

        public void UpdateInventor(Inventor inventor)
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
            _connection.Close();
        }

        public IEnumerable<Inventor> GetAllInventors()
        {
            _connection.Open();
            var sqlDataReader = _connection.Select("发明人");
            var inventors = new List<Inventor>();
            while (sqlDataReader.Read())
                inventors.Add(new Inventor
                                  {
                                      Email=(string) sqlDataReader["Email"],
                                      姓名=(string) sqlDataReader["姓名"],
                                      电话=(string) sqlDataReader["电话"],
                                      身份证号=(string) sqlDataReader["身份证号"]
                                  });
            sqlDataReader.Close();
            _connection.Close();
            return inventors;

        }

        public Inventor? GetInventor(string 身份证号)
        {
            _connection.Open();
            var sqlDataReader = _connection.Select("发明人", new KeyValuePair<string, object>("身份证号", 身份证号));
            Inventor? inventor = null;
            if (sqlDataReader.Read())
                inventor  = new Inventor
                {
                    Email = (string)sqlDataReader["Email"],
                    姓名 = (string)sqlDataReader["姓名"],
                    电话 = (string)sqlDataReader["电话"],
                    身份证号 = (string)sqlDataReader["身份证号"]
                };
            sqlDataReader.Close();
            _connection.Close();
            return inventor;
        }

        #endregion
    }
}