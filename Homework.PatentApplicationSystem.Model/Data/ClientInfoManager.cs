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
                {"地址", customer.地址},
                {"邮编", customer.邮编}
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
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string 客户号)
        {
            throw new NotImplementedException();
        }

        public void AddCustomerContact(CustomerContact contact)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomerContact(CustomerContact contact)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerContact(CustomerContact contact)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerContact> GetCustomerContacts(string 客户号)
        {
            throw new NotImplementedException();
        }

        public void AddApplicant(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public void RemoveApplicant(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public void UpdateApplicant(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Applicant> GetAllApplicants()
        {
            throw new NotImplementedException();
        }

        public Applicant GetApplicant(string 申请人证件号)
        {
            throw new NotImplementedException();
        }

        public void AddInventor(Inventor inventor)
        {
            throw new NotImplementedException();
        }

        public void RemoveInventor(Inventor inventor)
        {
            throw new NotImplementedException();
        }

        public void UpdateInventor(Inventor inventor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventor> GetAllInventors()
        {
            throw new NotImplementedException();
        }

        public Inventor GetInventor(string 发明人身份证号证件号)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}