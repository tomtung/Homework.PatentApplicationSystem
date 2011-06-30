using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using Ninject;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.ToString();
            string pwd = txtPWD.Text.ToString();
            var service = Global.Kernel.Get<IUserLoginService>();
            Tuple<LoginResult, User> loginRes = service.Login(username, pwd);
            //string url = "~/" + loginRes.Item2.Role.ToString() + "/Default.aspx";
            //Response.Redirect(url);
            Session["User"] = loginRes.Item2;
            string url = "~/Default.aspx";
            Response.Redirect(url);

        }
    }
}
