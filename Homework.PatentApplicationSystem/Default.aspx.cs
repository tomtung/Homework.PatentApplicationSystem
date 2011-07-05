using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
//using System.Web.Security;

namespace Homework.PatentApplicationSystem
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["User"] as User;
            if (user == null)
                Server.Transfer("/Account/Login.aspx");
            else
                Server.Transfer("/" + user.Role + "/Default.aspx");
        }
    }
}