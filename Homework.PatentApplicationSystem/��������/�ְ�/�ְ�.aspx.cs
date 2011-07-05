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
namespace Homework.PatentApplicationSystem.代理部主管.分案
{
    public partial class 分案 : System.Web.UI.Page
    {
        public string CurrentTaskNames { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTaskNames = "分案";

            User CurrentUser = (User)Session["User"];
            // if (!Page.IsPostBack)
            {
                List<string> tabs = new List<string>();
                tabs.Add("分案");
                tabs.Add("案件信息");
                tabs.Add("相关文件");
                tabs.Add("案件反馈");
                this.TabStrip1.DataSource = tabs;

                string selectedCaseID = Session["SelectedCaseID"].ToString();
                var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
                var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                Case @case = caseInfoManager.GetCaseById(selectedCaseID).Value;

                if (@case.案件类型 == CaseType.新申请)
                {
                    this.MultiVewDistributeCase.ActiveViewIndex = 1;
                }
                else
                {
                    this.MultiVewDistributeCase.ActiveViewIndex = 0;
                }

                this.lblCaseTypeInfo.Text = @case.案件类型.ToString();
                var userNames = ServiceLocator.Current.GetInstance<IUserService>().GetUsersByRole(Role.办案员).Select(user=>user.UserName);
                lBoxSponsor.DataSource =  lBoxCaseWorker1.DataSource =  lBoxCaseWorker2.DataSource = lBoxCaseWorker3.DataSource = userNames;
                lBoxSponsor.DataBind();
                lBoxCaseWorker1.DataBind();
                lBoxCaseWorker2.DataBind();
                lBoxCaseWorker3.DataBind();
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
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
            string caseId = Session["SelectedCaseID"].ToString();
            Case @case = caseInfoManager.GetCaseById(caseId).Value;
            User user = (User)Session["User"];

            if (this.lBoxSponsor.SelectedIndex >= 0)
            {
                @case.主办员用户名 = this.lBoxSponsor.SelectedValue;
            }

            if (this.lBoxCaseWorker1.SelectedIndex >= 0)
            {
                @case.翻译用户名 = this.lBoxCaseWorker1.SelectedValue;

            }
            if (this.lBoxCaseWorker2.SelectedIndex >= 0)
            {
                @case.一校用户名 = this.lBoxCaseWorker1.SelectedValue;

            }
            if (this.lBoxCaseWorker3.SelectedIndex >= 0)
            {
                @case.二校用户名 = this.lBoxCaseWorker1.SelectedValue;

            }
        }

    }
}