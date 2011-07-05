using System;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.办案员.原始资料翻译二校
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CaseFile1.CurrentTaskNames = TaskNames.原始资料翻译二校;
        }
    }
}