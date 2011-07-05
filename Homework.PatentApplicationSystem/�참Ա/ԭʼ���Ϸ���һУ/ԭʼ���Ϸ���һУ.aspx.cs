using System;
using System.Collections.Generic;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.办案员.原始资料翻译一校
{
    public partial class 原始资料翻译一校 : Page
    {
        public string CurrentTaskNames { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTaskNames = "原始资料翻译一校";

            var CurrentUser = (User) Session["User"];
            if (!Page.IsPostBack)
            {
                var tabs = new List<string>();
                tabs.Add("案件信息");
                tabs.Add("相关文件");

                TabStrip1.DataSource = tabs;
            }
        }

        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = TabStrip1.SelectedIndex;
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