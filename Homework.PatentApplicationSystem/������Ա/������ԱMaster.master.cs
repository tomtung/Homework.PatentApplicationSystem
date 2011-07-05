using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.代理部文员
{
    public partial class 代理部文员Master : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["User"] as User;
            if (user == null || user.Role != Role.代理部文员)
                Response.Redirect("/");
        }
    }
}