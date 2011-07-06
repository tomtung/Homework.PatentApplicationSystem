using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.质检员.流程部质检
{
    public partial class 流程部质检 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TaskName = TaskNames.流程部质检;
            Master.ShowTwoButtons = true;
        }
    }
}