using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.代理部主管.分案
{
    public partial class 分案 : Page
    {
        public string CurrentTaskNames { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTaskNames = "分案";

            if (!Page.IsPostBack)
            {
                var tabs = new List<string>();
                tabs.Add("分案");
                tabs.Add("案件信息");
                tabs.Add("相关文件");
                tabs.Add("案件反馈");
                TabStrip1.DataSource = tabs;


                if (Session["SelectedCaseID"] == null)
                {
                    Response.Redirect("../");
                }
                string selectedCaseID = Session["SelectedCaseID"].ToString();
                var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
                Case @case = caseInfoManager.GetCaseById(selectedCaseID).Value;

                if (@case.案件类型 == CaseType.新申请)
                {
                    MultiVewDistributeCase.ActiveViewIndex = 1;
                }
                else
                {
                    MultiVewDistributeCase.ActiveViewIndex = 0;
                }

                lblCaseTypeInfo.Text = @case.案件类型.ToString();
                IEnumerable<string> userNames =
                    ServiceLocator.Current.GetInstance<IUserService>().GetUsersByRole(Role.办案员).Select(
                        user => user.UserName);
                lBoxSponsor.DataSource =
                    lBoxCaseWorker1.DataSource = lBoxCaseWorker2.DataSource = lBoxCaseWorker3.DataSource = userNames;
                lBoxSponsor.DataBind();
                lBoxCaseWorker1.DataBind();
                lBoxCaseWorker2.DataBind();
                lBoxCaseWorker3.DataBind();
            }
        }


        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = TabStrip1.SelectedIndex;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
            string caseId = Session["SelectedCaseID"].ToString();
            Case @case = caseInfoManager.GetCaseById(caseId).Value;

            if (!string.IsNullOrEmpty(lBoxSponsor.SelectedValue))
                @case.主办员用户名 = lBoxSponsor.SelectedValue;
            else
            {
                Response.Write("<script type='text/javascript'>alert(\"请选择主办员\");</script>");
                return;
            }

            if (!string.IsNullOrEmpty(lBoxCaseWorker1.SelectedValue))
                @case.翻译用户名 = lBoxCaseWorker1.SelectedValue;
            else
            {
                Response.Write("<script type='text/javascript'>alert(\"请选择翻译\");</script>");
                return;
            }

            if (!string.IsNullOrEmpty(lBoxCaseWorker2.SelectedValue))
                @case.一校用户名 = lBoxCaseWorker2.SelectedValue;
            else
            {
                Response.Write("<script type='text/javascript'>alert(\"请选择一校\");</script>");
                return;
            }

            if (!string.IsNullOrEmpty(lBoxCaseWorker3.SelectedValue))
                @case.二校用户名 = lBoxCaseWorker3.SelectedValue;
            else
            {
                Response.Write("<script type='text/javascript'>alert(\"请选择二校\");</script>");
                return;
            }

            caseInfoManager.UpdateCase(@case);
            caseWorkflowManager.ResumeCase(@case, CurrentTaskNames);

            Response.Redirect("/代理部主管/分案/Default.aspx");
        }
    }
}