using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.办案员.原始资料翻译
{
    public partial class 原始资料翻译 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TaskName = TaskNames.原始资料翻译;
        }
    }
}