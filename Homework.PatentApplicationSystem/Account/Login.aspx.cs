using System;
using System.Web;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
using Ninject;

namespace Homework.PatentApplicationSystem.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" +
                                            HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string pwd = txtPWD.Text;
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