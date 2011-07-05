using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;
namespace Homework.PatentApplicationSystem.质检员.流程部质检
{
    public partial class 流程部质检 : System.Web.UI.Page
    {
        public string CurrentTaskNames { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            CurrentTaskNames = "流程部质检";

            if (!Page.IsPostBack)
            {
                var tabs = new List<string> {"案件信息", "相关文件"};

                this.TabStrip1.DataSource = tabs;

                string selectedCaseId = Session["SelectedCaseID"].ToString();
                this.caseInfo1.CaseID = selectedCaseId;
                this.filecontrol1.CaseID = selectedCaseId;
            }

        }
        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = this.TabStrip1.SelectedIndex;
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
            string selectedCaseID = Session["SelectedCaseID"].ToString();
            caseWorkflowManager.ResumeCase(selectedCaseID, CurrentTaskNames);
            Response.Redirect("Default.aspx");
        }
    }
}