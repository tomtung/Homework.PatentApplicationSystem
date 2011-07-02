using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model.Data
{
    /// <summary>
    /// 申请人、发明人和客户及其联系人的信息管理类实现此接口。
    /// </summary>
    public interface IClientInfoManager
    {
        void AddCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        Customer? GetCustomer(string 客户号);

        void AddCustomerContact(CustomerContact contact);
        void RemoveCustomerContact(CustomerContact contact);
        void UpdateCustomerContact(CustomerContact contact);
        IEnumerable<CustomerContact> GetCustomerContacts(string 客户号);

        void AddApplicant(Applicant applicant);
        void RemoveApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        IEnumerable<Applicant> GetAllApplicants();
        Applicant? GetApplicant(string 证件号);

        void AddInventor(Inventor inventor);
        void RemoveInventor(Inventor inventor);
        void UpdateInventor(Inventor inventor);
        IEnumerable<Inventor> GetAllInventors();
        Inventor? GetInventor(string 身份证号);
    }

    public static class ClientInfoManagerHelper
    {
        public static IEnumerable<CustomerContact> GetCustomerContacts(this IClientInfoManager manager,
            Customer customer)
        {
            return manager.GetCustomerContacts(customer.客户号);
        }
    }
}