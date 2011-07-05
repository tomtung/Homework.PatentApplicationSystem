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
namespace Homework.PatentApplicationSystem.办案员.撰写五书
{
    public partial class 撰写五书 : System.Web.UI.Page
    {
        public string CurrentTaskNames { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            CurrentTaskNames = "撰写五书";

            User CurrentUser = (User)Session["User"];
            // if (!Page.IsPostBack)
            {
                List<string> tabs = new List<string>();
                tabs.Add("案件信息");
                tabs.Add("相关文件");

                this.TabStrip1.DataSource = tabs;

                string selectedCaseID = Session["SelectedCaseID"].ToString();
                var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
                var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                Case @case = caseInfoManager.GetCaseById(selectedCaseID).Value;
                this.caseInfo1.CaseID = selectedCaseID;
                this.filecontrol1.CaseID = selectedCaseID;
            }

        }
        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = this.TabStrip1.SelectedIndex;
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
        }
    }
}