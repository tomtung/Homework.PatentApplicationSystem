using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.办案员.定稿五书
{
    public partial class 定稿五书 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TaskName = TaskNames.定稿五书;
        }
    }
}