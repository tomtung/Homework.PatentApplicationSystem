using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework.PatentApplicationSystem.分案员
{
    public partial class 内审 : System.Web.UI.Page
    {
        public string CaseID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    List<string> tabs = new List<string>();
                    tabs.Add("案件信息");
                    tabs.Add("相关文件");
                    tabs.Add("案件反馈");
                    this.TabStrip1.DataSource = tabs;
                    //string selectedCaseID = Session["SelectedCaseID"].ToString();
                    //var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
                    //var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                    //Case @case = caseInfoManager.GetCaseById(selectedCaseID).Value;
                    this.caseInfo1.CaseID = CaseID;
                    this.fileControl1.CaseID = CaseID;
                    this.FeedBack1.CaseID = CaseID;

                }
                
            }
        }
        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = this.TabStrip1.SelectedIndex;
        }
    }
}