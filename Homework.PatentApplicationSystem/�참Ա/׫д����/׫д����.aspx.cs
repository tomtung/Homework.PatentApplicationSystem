using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.办案员.撰写五书
{
    public partial class 撰写五书 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TaskName = TaskNames.撰写五书;
        }
    }
}