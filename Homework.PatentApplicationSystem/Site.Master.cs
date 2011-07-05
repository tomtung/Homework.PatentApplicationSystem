using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
namespace Homework.PatentApplicationSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                User currentUser = (User)Session["User"];
                if (currentUser == null)
                    this.lblCurrentUser.Text = "用户";
                else
                    this.lblCurrentUser.Text = currentUser.UserName;
            }

        }

        protected void linkBtnExit_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}