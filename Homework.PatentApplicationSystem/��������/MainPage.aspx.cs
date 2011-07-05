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
namespace Homework.PatentApplicationSystem.分案员
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                



            }
        }
        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = this.TabStrip1.SelectedIndex;
        }
    }
}