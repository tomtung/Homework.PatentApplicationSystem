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


            //var clientInfoManager = new ClientInfoManager(new SqlConnection("Data Source=LDD-PC;Initial Catalog=HW_PAS;Integrated Security=True"));
            //var customer = new Customer() {地址 = "x Road", 客户号 = "123", 类型 = "哦", 邮编 = "123-321"};
            ////clientInfoManager.AddCustomer(customer);
            //var allCustomers = clientInfoManager.GetAllCustomers();
            //foreach (var allCustomer in allCustomers)
            //{
            //    Debug.WriteLine(allCustomer.客户号);   
            //}
            
            //var customerContact = new CustomerContact() {姓名 = "1", Email = "2", 客户号 = "123", 电话 = "12321", 联系人类型 = "哦"};
            //clientInfoManager.AddCustomerContact(customerContact);
            //clientInfoManager.RemoveCustomerContact(customerContact);
            //clientInfoManager.AddCustomerContact(customerContact);
            //foreach (var i in clientInfoManager.GetCustomerContacts("132"))
            //{
            //    Debug.WriteLine(i.姓名);    
            //}
            //customerContact.电话 = "800";
            //clientInfoManager.UpdateCustomerContact(customerContact);

            //var applicant = new Applicant()
            //                    {
            //                        证件号="34224",
            //                        类型="null",
            //                        中文名="中文名",
            //                        英文名="English Name",
            //                        简称="EN",
            //                        国家="CHN",
            //                        省="Pro",
            //                        市区县="",
            //                        中国地址="xx roadl sdflj ",
            //                        外国地址="sfljds",
            //                        邮编="123",
            //                        电话="423",
            //                        传真="",
            //                        Email="f@f.f"
            //                    };
            //clientInfoManager.AddApplicant(applicant);
            //clientInfoManager.RemoveApplicant(applicant);
            //clientInfoManager.AddApplicant(applicant);
            //foreach( var x in clientInfoManager.GetAllApplicants())
            //    Debug.WriteLine(x.证件号);

            //applicant.英文名 = "Lucy";
            //clientInfoManager.UpdateApplicant(applicant);
            //var applicant1 = clientInfoManager.GetApplicant("34224");
            //Debug.WriteLine(applicant1.Value.证件号);

            //var inventor = new Inventor()
            //                   {
            //                       Email = "Email",
            //                       姓名 = "名字",
            //                       电话 = "otr",
            //                       身份证号 = "34001"

            //                   };
            //clientInfoManager.AddInventor(inventor);
            //clientInfoManager.RemoveInventor(inventor);
            //clientInfoManager.AddInventor(inventor);
            //var allInventors = clientInfoManager.GetAllInventors();
            //foreach (var x in allInventors)
            //{
            //    Debug.WriteLine(x.身份证号);
            //}
            //inventor.电话 = "885";
            //clientInfoManager.UpdateInventor(inventor);
            //Debug.WriteLine(clientInfoManager.GetInventor("34001").Value.身份证号);


        }   
    }
}
