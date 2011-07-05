using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.ServiceLocation;
using Homework.PatentApplicationSystem.Model.Data;
namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class CaseInfoUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Case @case = ServiceLocator.Current.GetInstance<ICaseInfoManager>().GetCaseById(Session["SelectedCaseID"] as string).Value;
                this.lblCaseNameInfo.Text = @case.名称;
                this.lblCreateDateInfo.Text = @case.创建时间.ToString();
                this.lblDateLimitInfo.Text = @case.绝限日.ToString();
                this.lblClientNameInfo.Text = @case.客户号;
                this.lblClientIDInfo.Text = @case.申请人证件号;
                this.lblInventorIDInfo.Text = @case.发明人身份证号;
            }
        }
    }
}