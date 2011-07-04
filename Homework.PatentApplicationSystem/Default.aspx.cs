using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
//using System.Web.Security;

namespace Homework.PatentApplicationSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User) Session["User"];
            if (user != null)
                lblUserName.Text = user.UserName;
            else
                lblUserName.Text = "Session State Management Error!!! User can't be extracted from Session";
        }
    }
}