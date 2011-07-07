using System;
using System.Linq;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem
{
    public partial class 客户管理 : Page
    {
        private readonly IClientInfoManager _clientInfoManager = ServiceLocator.Current.GetInstance<IClientInfoManager>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetTaskName("客户管理");

            TabStrip.DataSource = new[] {"客户", "客户联系人", "申请人", "发明人"};

            InventorListView.DataSource = _clientInfoManager.GetAllInventors();
            InventorListView.DataBind();
            var customers = _clientInfoManager.GetAllCustomers();
            CustomerListView.DataSource = customers;
            CustomerListView.DataBind();
            CustomerContactListView.DataSource = customers
                .Select(c => c.客户号)
                .SelectMany(cid => _clientInfoManager.GetCustomerContacts(cid));
            CustomerContactListView.DataBind();
        }

        protected void InventorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clientInfoManager.RemoveInventor(new Inventor {身份证号 = InventorListView.SelectedValue.ToString()});
            Response.Redirect(Request.Url.ToString());
        }

        protected void InventorListView_SelectedIndexChanging(object sender, EventArgs e)
        {
            // Nothing
        }

        protected void AddInventorButton_Click(object sender, EventArgs e)
        {
            _clientInfoManager.AddInventor(new Inventor
                                               {
                                                   Email = InventorEmail.Text,
                                                   姓名 = InventorName.Text,
                                                   电话 = InventorTel.Text,
                                                   身份证号 = InventorUid.Text
                                               });
            Response.Redirect(Request.Url.ToString());
        }

        protected void CustomerListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clientInfoManager.RemoveCustomer(new Customer {客户号 = CustomerListView.SelectedValue.ToString()});
            Response.Redirect(Request.Url.ToString());
        }

        protected void CustomerListView_SelectedIndexChanging(object sender, EventArgs e)
        {
            // Nothing
        }

        protected void AddCustomerButton_Click(object sender, EventArgs e)
        {
            _clientInfoManager.AddCustomer(new Customer
                                               {
                                                   客户号 = CustomerUid.Text,
                                                   地址 = CustomerAddress.Text,
                                                   类型 = CustomerType.Text,
                                                   邮编 = CustomerZipCode.Text
                                               });
            Response.Redirect(Request.Url.ToString());
        }

        protected void CustomerContactListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bug, but fine...
            _clientInfoManager.RemoveCustomerContact(new CustomerContact() { 姓名 = CustomerContactListView.SelectedValue.ToString() });
            Response.Redirect(Request.Url.ToString());
        }

        protected void CustomerContactListView_SelectedIndexChanging(object sender, EventArgs e)
        {
            // Nothing
        }

        protected void AddCustomerContactListViewButton_Click(object sender, EventArgs e)
        {
            _clientInfoManager.AddCustomerContact(new CustomerContact()
            {
                Email = CustomerContactEmail.Text,
                姓名 = CustomerContactName.Text,
                客户号 = CustomerContactCustomerID.Text,
                电话 = CustomerContactTel.Text,
                联系人类型 = CustomerContactType.Text
            });
            Response.Redirect(Request.Url.ToString());
        }

        protected void TabStrip_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = TabStrip.SelectedIndex;
        }

        protected void ApplicantListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clientInfoManager.RemoveApplicant(new Applicant {证件号 = ApplicantListView.SelectedValue.ToString()});
            Response.Redirect(Request.Url.ToString());
        }

        protected void ApplicantListView_SelectedIndexChanging(object sender, EventArgs e)
        {
            // Nothing
        }

        protected void AddApplicantButton_Click(object sender, EventArgs e)
        {
            _clientInfoManager.AddApplicant(new Applicant
                                                {
                                                    证件号 = 申请人证件号.Text,
                                                    类型 = 申请人类型.Text,
                                                    中文名 = 申请人中文名.Text,
                                                    英文名 = 申请人英文名.Text,
                                                    简称 = 申请人简称.Text,
                                                    国家 = 申请人国家.Text,
                                                    省 = 申请人省.Text,
                                                    市区县 = 申请人市区县.Text,
                                                    中国地址 = 申请人中国地址.Text,
                                                    外国地址 = 申请人外国地址.Text,
                                                    邮编 = 申请人邮编.Text,
                                                    电话 = 申请人电话.Text,
                                                    传真 = 申请人传真.Text,
                                                    Email = 申请人Email.Text
                                                });
            Response.Redirect(Request.Url.ToString());
        }
    }
}