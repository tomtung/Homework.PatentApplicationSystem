using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem
{
    public partial class SiteMaster : MasterPage
    {
        public void SetTaskName(string taskName)
        {
            var currentUser = Session["User"] as User;
            if (currentUser == null || !TaskNames.TasksOf(currentUser.Role).Contains(taskName))
                Response.Redirect("~/Account/Login.aspx");

            var tab = FindControl(taskName + "Tab") as HtmlGenericControl;
            if (tab != null)
                tab.Attributes["class"] = "selected";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var currentUser = (User) Session["User"];
                if (currentUser == null)
                    Response.Redirect("~/Account/Login.aspx");
                else
                {
                    lblCurrentUser.Text = currentUser.UserName;
                    switch (currentUser.Role)
                    {
                        case Role.立案员:
                            立案员Tabs.Visible = true;
                            break;
                        case Role.质检员:
                            质检员Tabs.Visible = true;
                            break;
                        case Role.代理部主管:
                            代理部主管Tabs.Visible = true;
                            break;
                        case Role.办案员:
                            办案员Tabs.Visible = true;
                            break;
                        case Role.代理部文员:
                            代理部文员Tabs.Visible = true;
                            break;
                    }
                }
            }
        }

        protected void linkBtnExit_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}