using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.代理部主管.分案
{
    public partial class 分案 : Page
    {
        private readonly ICaseInfoManager _caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();

        private readonly ICaseWorkflowManager _caseWorkflowManager =
            ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

        private readonly IUserService _userService = ServiceLocator.Current.GetInstance<IUserService>();


        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetTaskName(TaskNames.分案);
            if (!Page.IsPostBack)
            {
                TabStrip.DataSource = new[] {"案件信息", "分案", "相关文件", "留言指示"};

                if (Session["SelectedCaseID"] == null) return;
                string selectedCaseId = Session["SelectedCaseID"].ToString();
                Case? caseById = _caseInfoManager.GetCaseById(selectedCaseId);
                if (caseById == null) return;
                Case @case = caseById.Value;

                lblCaseTypeInfo.Text = @case.案件类型.ToString();
                MultiVewDistributeCase.ActiveViewIndex = @case.案件类型 == CaseType.新申请 ? 1 : 0;

                IEnumerable<string> userNames = _userService.GetUsersByRole(Role.办案员).Select(user => user.UserName);
                foreach (ListBox box in new[] {lBoxSponsor, lBoxCaseWorker1, lBoxCaseWorker2, lBoxCaseWorker3})
                {
                    box.DataSource = userNames;
                    box.DataBind();
                }
            }
        }


        protected void TabStrip_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = TabStrip.SelectedIndex;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string caseId = Session["SelectedCaseID"].ToString();
            Case @case = _caseInfoManager.GetCaseById(caseId).Value;

            if (string.IsNullOrEmpty(lBoxSponsor.SelectedValue))
            {
                Response.Write("<script type='text/javascript'>alert(\"请选择主办员\");</script>");
                return;
            }
            @case.主办员用户名 = lBoxSponsor.SelectedValue;

            if (MultiVewDistributeCase.ActiveViewIndex == 1)
            {
                if (string.IsNullOrEmpty(lBoxCaseWorker1.SelectedValue))
                {
                    Response.Write("<script type='text/javascript'>alert(\"请选择翻译\");</script>");
                    return;
                }
                if (string.IsNullOrEmpty(lBoxCaseWorker2.SelectedValue))
                {
                    Response.Write("<script type='text/javascript'>alert(\"请选择一校\");</script>");
                    return;
                }
                if (string.IsNullOrEmpty(lBoxCaseWorker3.SelectedValue))
                {
                    Response.Write("<script type='text/javascript'>alert(\"请选择二校\");</script>");
                    return;
                }
                if (lBoxCaseWorker1.SelectedValue == lBoxCaseWorker2.SelectedValue
                    || lBoxCaseWorker1.SelectedValue == lBoxCaseWorker3.SelectedValue
                    || lBoxCaseWorker2.SelectedValue == lBoxCaseWorker3.SelectedValue)
                {
                    Response.Write("<script type='text/javascript'>alert(\"翻译、一校、二校不能为同一人\");</script>");
                    return;
                }
                @case.翻译用户名 = lBoxCaseWorker1.SelectedValue;
                @case.一校用户名 = lBoxCaseWorker2.SelectedValue;
                @case.二校用户名 = lBoxCaseWorker3.SelectedValue;
            }

            _caseInfoManager.UpdateCase(@case);
            _caseWorkflowManager.ResumeCase(@case, TaskNames.分案);
            Response.Redirect("/代理部主管/分案/Default.aspx");
        }
    }
}