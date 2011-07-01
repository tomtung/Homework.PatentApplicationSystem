using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// �����ˡ������˺Ϳͻ�������ϵ�˵���Ϣ������ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IClientInfoManager
    {
        void AddCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(string �ͻ���);

        void AddCustomerContact(CustomerContact contact);
        void RemoveCustomerContact(CustomerContact contact);
        void UpdateCustomerContact(CustomerContact contact);
        IEnumerable<CustomerContact> GetCustomerContacts(string �ͻ���);

        void AddApplicant(Applicant applicant);
        void RemoveApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        IEnumerable<Applicant> GetAllApplicants();
        Applicant GetApplicant(string ������֤����);

        void AddInventor(Inventor inventor);
        void RemoveInventor(Inventor inventor);
        void UpdateInventor(Inventor inventor);
        IEnumerable<Inventor> GetAllInventors();
        Inventor GetInventor(string ���������֤��֤����);
    }

    public static class ClientInfoManagerHelper
    {
        public static IEnumerable<CustomerContact> GetCustomerContacts(this IClientInfoManager manager,
            Customer customer)
        {
            return manager.GetCustomerContacts(customer.�ͻ���);
        }
    }
}