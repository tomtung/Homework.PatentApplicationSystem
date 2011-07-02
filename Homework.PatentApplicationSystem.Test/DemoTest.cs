using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using NUnit.Framework;
using FluentAssertions;
using Moq;

namespace Homework.PatentApplicationSystem.Test
{
    [TestFixture]
    public class DemoTest
    {
        [Test]
        public void SomeTest()
        {
            1.Should().Be(1);
            true.Should().BeTrue();

            //Action action = () => { throw new NotSupportedException(); };
            //action.ShouldThrow<NotSupportedException>();

            var mock = new Mock<IUserSpecificService>();
            mock.SetupGet(s => s.User)
                .Returns(new User {UserName = "李冬冬", Password = "mystenarice", Role = Role.立案员});
            Debug.WriteLine(mock.Object.User.UserName);


            var clientInfoManager = new ClientInfoManager(new SqlConnection("Data Source=LDD-PC;Initial Catalog=HW_PAS;Integrated Security=True"));
            var customer = new Customer() {地址 = "x Road", 客户号 = "123", 类型 = "哦", 邮编 = "123-321"};
            clientInfoManager.AddCustomer(customer);
            var allCustomers = clientInfoManager.GetAllCustomers();
            foreach (var allCustomer in allCustomers)
            {
                Debug.WriteLine(allCustomer.客户号);   
            }
            var customerContact = new CustomerContact() {姓名 = "1", Email = "2", 客户号 = "123", 电话 = "12321", 联系人类型 = "哦"};
            clientInfoManager.AddCustomerContact(customerContact);
            clientInfoManager.RemoveCustomerContact(customerContact);
            clientInfoManager.AddCustomerContact(customerContact);
            foreach (var i in clientInfoManager.GetCustomerContacts("132"))
            {
                Debug.WriteLine(i.姓名);    
            }
            


        }
    }
}
