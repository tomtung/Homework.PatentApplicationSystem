using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;
namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class SetupCaseCaseInfoUserControl : System.Web.UI.UserControl
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private Case _newCase;
        public Case NewCase
        {
            get { return _newCase; }
            set { _newCase = value; }
                 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.lBoxCaseType.DataSource = typeof(CaseType).GetEnumNames();
                this.lBoxCaseType.DataBind();
                var clientInfoManager = ServiceLocator.Current.GetInstance<IClientInfoManager>();
                this.lBoxClientName.DataSource = clientInfoManager.GetAllCustomers();
                this.lblDateLimit.Text = DateTime.Today.AddDays(30).ToString();

            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            _newCase.名称 = this.tboxCaseName.Text;
            _newCase.案件类型 = this.lBoxCaseType.SelectedValue.EnumParse<CaseType>();
            _newCase.创建时间 = Convert.ToDateTime(this.tboxCreateDate.Text);
            _newCase.客户号 = this.lBoxClientName.SelectedValue;
            _newCase.申请人证件号 = this.tBoxClientID.Text;
            _newCase.申请人证件号 = this.tBoxDepartmentID.Text;
            _newCase.发明人身份证号 = this.tBoxClientID.Text;
        }

    }
}