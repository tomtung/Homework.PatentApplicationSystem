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
namespace Homework.PatentApplicationSystem.立案员.立案
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["User"] as User;
            if (user == null || user.Role != Role.立案员)
                Response.Redirect("/");

            if (!Page.IsPostBack)
            {
                this.lBoxCaseType.DataSource = typeof(CaseType).GetEnumNames();
                this.lBoxCaseType.DataBind();
                var clientInfoManager = ServiceLocator.Current.GetInstance<IClientInfoManager>();
                this.lBoxClientName.DataSource = clientInfoManager.GetAllCustomers();
                this.lblDateLimit.Text = DateTime.Today.AddDays(30).ToString();
            }
        }
        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = this.TabStrip1.SelectedIndex;
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //创建Case
            Case @case = new Case
            {
                编号 = Guid.NewGuid().ToString(),
                名称 = this.tboxCaseName.Text,
                案件类型 = this.lBoxCaseType.SelectedValue.EnumParse<CaseType>(),
                创建时间 = Convert.ToDateTime(this.tboxCreateDate.Text),
                绝限日 = Convert.ToDateTime(this.lblDateLimit.Text),
                状态 = CaseState.OnGoing,
                客户号 = this.lBoxClientName.SelectedValue,
                申请人证件号 = this.tBoxClientID.Text,
                发明人身份证号 = this.tBoxInventorID.Text
            };
            
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
            caseInfoManager.AddCase(@case);

            // 然后启动案件流程
            caseWorkflowManager.StartCase(@case);


        }
    }
}