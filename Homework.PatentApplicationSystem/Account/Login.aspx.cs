using System;
using System.Web;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.Account
{
    public partial class Login : Page
    {
        private readonly IUserService _userService = ServiceLocator.Current.GetInstance<IUserService>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Tuple<LoginResult, User> loginRes = _userService.Login(txtUserName.Text, txtPWD.Text);
            if (loginRes.Item1 == LoginResult.Successful)
            {
                Session["User"] = loginRes.Item2;

                Response.Redirect("/");
            }
            else if (loginRes.Item1 == LoginResult.UserNotExist)
                Response.Write("<script type='text/javascript'>alert(\"用户不存在\");</script>");
            else
                Response.Write("<script type='text/javascript'>alert(\"密码错误\");</script>");
        }
    }
}