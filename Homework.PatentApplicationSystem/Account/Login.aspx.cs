using System;
using System.Web;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
using Microsoft.Practices.ServiceLocation;
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
            var service = ServiceLocator.Current.GetInstance<IUserService>();
            Tuple<LoginResult, User> loginRes = service.Login(username, pwd);
            if (loginRes.Item1 == LoginResult.Successful)
            {
                Session["User"] = loginRes.Item2;
                string url = "~/" + loginRes.Item2.Role.ToString() + "/Default.aspx";
                Response.Redirect(url);

            }
            else if (loginRes.Item1 == LoginResult.UserNotExist)
            {
                this.lblErrorMessage.Text = "用户名不存在";

            }
            else
            {
                this.lblErrorMessage.Text = "密码不匹配";
            }
            
            
        }
    }
}