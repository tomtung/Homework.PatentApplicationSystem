using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.ClientInfoMange
{
    public partial class 客户联系人 : System.Web.UI.Page
    {
        private IClientInfoManager _clientInfoManager = ServiceLocator.Current.GetInstance<IClientInfoManager>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListView1.DataSource = _clientInfoManager.GetCustomerContacts("anything should be okay");
            ListView1.DataBind();
        }
        protected void ListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = ListView1.SelectedValue.ToString();
            _clientInfoManager.RemoveCustomerContact(new CustomerContact() { 姓名 = s });
            Response.Redirect(Request.Url.ToString());
        }
        protected void ListView1SelectedIndexChanging(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _clientInfoManager.AddCustomerContact( new CustomerContact()
                                                       {
                                                           Email = Email.Text,
                                                           姓名 = Name.Text,
                                                           客户号 = CustomerID.Text,
                                                           电话 = Tel.Text,
                                                           联系人类型 = Type.Text
                                                       });
            Response.Redirect(Request.Url.ToString());
        }

    }
}