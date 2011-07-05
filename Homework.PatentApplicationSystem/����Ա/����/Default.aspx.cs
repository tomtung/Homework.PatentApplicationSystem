using System;
using System.Web.UI;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.立案员.立案
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetTaskName(TaskNames.立案);
            if (!Page.IsPostBack)
            {
                lBoxCaseType.DataSource = typeof (CaseType).GetEnumNames();
                lBoxCaseType.DataBind();
                var clientInfoManager = ServiceLocator.Current.GetInstance<IClientInfoManager>();
                lblDateLimitInfo.Text = DateTime.Now.AddDays(30).ToString();
                lblCreateDateInfo.Text = DateTime.Now.ToString();
            }
        }

        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = TabStrip1.SelectedIndex;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //创建Case
            var @case = new Case
                            {
                                编号 = Guid.NewGuid().ToString(),
                                名称 = tboxCaseName.Text,
                                案件类型 = lBoxCaseType.SelectedValue.EnumParse<CaseType>(),
                                创建时间 = Convert.ToDateTime(lblCreateDateInfo.Text),
                                绝限日 = Convert.ToDateTime(lblDateLimitInfo.Text),
                                状态 = CaseState.OnGoing,
                                客户号 = tBoxClientName.Text,
                                申请人证件号 = tBoxClientID.Text,
                                发明人身份证号 = tBoxInventorID.Text
                            };


            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
            caseInfoManager.AddCase(@case);

            // 然后启动案件流程
            caseWorkflowManager.StartCase(@case);

            Response.Redirect(Request.Url.ToString());
        }
    }
}