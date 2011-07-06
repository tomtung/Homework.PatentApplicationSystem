using System;
using System.Linq;
using System.Web.UI;
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

            TabStrip.DataSource = new[] {"发明人", "客户", "客户联系人"};

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
    }
}