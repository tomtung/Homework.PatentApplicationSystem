using System;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.办案员.撰写五书
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var user = Session["User"] as User;
                if (user == null || user.Role != Role.办案员)
                    Response.Redirect("/");

                CaseFile1.CurrentTaskNames = TaskNames.撰写五书;
            }
        }
    }
}