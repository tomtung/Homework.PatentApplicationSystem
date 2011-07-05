using System;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class CaseInfoUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Case @case =
                    ServiceLocator.Current.GetInstance<ICaseInfoManager>().GetCaseById(
                        Session["SelectedCaseID"] as string).Value;
                lblCaseNameInfo.Text = @case.名称;
                lblCreateDateInfo.Text = @case.创建时间.ToString();
                lblDateLimitInfo.Text = @case.绝限日.ToString();
                lblClientNameInfo.Text = @case.客户号;
                lblClientIDInfo.Text = @case.申请人证件号;
                lblInventorIDInfo.Text = @case.发明人身份证号;
            }
        }
    }
}