using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem
{
    public partial class CaseHandleMaster : MasterPage
    {
        private readonly ICaseWorkflowManager _caseWorkflowManager =
            ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

        private string _taskName;

        public string TaskName
        {
            get { return _taskName; }
            set
            {
                _taskName = value;
                Master.SetTaskName(value);
            }
        }

        public bool ShowTwoButtons
        {
            get { return DoubleButtonPanel.Visible; }
            set
            {
                SingleButtonPanel.Visible = !value;
                DoubleButtonPanel.Visible = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                TabStrip.DataSource = new[] {"案件信息", "相关文件"};
        }

        protected void TabStrip_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = TabStrip.SelectedIndex;
        }

        protected void ButtonPass_Click(object sender, EventArgs e)
        {
            _caseWorkflowManager.ResumeCase(Session["SelectedCaseID"].ToString(), TaskName, true);
            Response.Redirect("Default.aspx");
        }

        protected void ButtonCheck_Click(object sender, EventArgs e)
        {
            _caseWorkflowManager.ResumeCase(Session["SelectedCaseID"].ToString(), TaskName, false);
            Response.Redirect("Default.aspx");
        }
    }
}