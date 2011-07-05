using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.代理部文员.制作官方格式函
{
    public partial class 制作官方格式函 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TaskName = TaskNames.制作官方格式函;
        }
    }
}