using System;
using System.Collections.Generic;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.办案员.撰写五书
{
    public partial class 撰写五书 : Page
    {
        private readonly ICaseWorkflowManager _caseWorkflowManager =
            ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

        public string CurrentTaskNames
        {
            get { return TaskNames.撰写五书; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                TabStrip.DataSource = new List<string> {"案件信息", "相关文件"};
        }

        protected void TabStrip_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = TabStrip.SelectedIndex;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            _caseWorkflowManager.ResumeCase(Session["SelectedCaseID"].ToString(), CurrentTaskNames, true);
            Response.Redirect("Default.aspx");
        }
    }
}