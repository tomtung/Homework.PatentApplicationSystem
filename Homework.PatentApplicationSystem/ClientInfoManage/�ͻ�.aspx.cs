using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.ClientInfoManage
{
    public partial class 客户 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListView1.DataSource = ServiceLocator.Current.GetInstance<IClientInfoManager>().GetAllCustomers();
            ListView1.DataBind();
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceLocator.Current.GetInstance<IClientInfoManager>().AddCustomer(new Customer()
                                                                                     {
                                                                                         客户号=Uid.Text,
                                                                                         地址=Address.Text,
                                                                                         类型=Type.Text,
                                                                                         邮编=ZipCode.Text
                                                                                     });
            Response.Redirect(Request.Url.ToString());  

          
        }
        protected void ListView1SelectedIndexChanged(object  sender, EventArgs e)
        {
            var s = ListView1.SelectedValue.ToString();
            ServiceLocator.Current.GetInstance<IClientInfoManager>().RemoveCustomer(new Customer()
                                                                                        {
                                                                                            客户号 = s
                                                                                         });
            Response.Redirect(Request.Url.ToString());  

        }
        protected void ListView1SelectedIndexChanging(object sender, EventArgs e)
        {


        }
    }
}