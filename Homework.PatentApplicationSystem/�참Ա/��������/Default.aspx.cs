using System;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.办案员.定稿五书
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CaseFile1.CurrentTaskNames = TaskNames.定稿五书;
        }
    }
}