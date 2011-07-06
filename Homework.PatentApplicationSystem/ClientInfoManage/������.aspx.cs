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
    public partial class 发明人 : System.Web.UI.Page
    {
        private IClientInfoManager _clientInfoManager = ServiceLocator.Current.GetInstance<IClientInfoManager>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListView1.DataSource = _clientInfoManager.GetAllInventors();
            ListView1.DataBind();
        }

        protected void ListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = ListView1.SelectedValue.ToString();
            _clientInfoManager.RemoveInventor(new Inventor(){身份证号=s});
            Response.Redirect(Request.Url.ToString());
        }

        protected void ListView1SelectedIndexChanging(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _clientInfoManager.AddInventor(new Inventor()
                                               {
                                                   Email = Email.Text,
                                                   姓名 = Name.Text,
                                                   电话 = Tel.Text,
                                                   身份证号 = Uid.Text
                                               });
            Response.Redirect(Request.Url.ToString());
        }
    }
}