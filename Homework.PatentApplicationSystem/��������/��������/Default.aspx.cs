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
namespace Homework.PatentApplicationSystem.代理部主管.代理部内审
{
    public partial class Default : System.Web.UI.Page
    {
        private string CurrentTaskNames;
        private void test()
        {
            if (Session["User"] == null)
            {
                User user = new User
                {
                    UserName = "seckcoder",
                    Password = "123",
                    Role = Role.代理部主管
                };
                Session["User"] = user;
            }



            if (Session["Case"] == null)
            {
                Case @case = new Case
                {
                    编号 = Guid.NewGuid().ToString(),
                    名称 = "testCase",
                    案件类型 = CaseType.新申请,
                    创建时间 = Convert.ToDateTime("2011-03-16"),
                    绝限日 = Convert.ToDateTime("2011-04-16"),
                    状态 = CaseState.OnGoing,
                    客户号 = "001",
                    申请人证件号 = "001",
                    发明人身份证号 = "001"
                };
                Session["Case"] = @case;
                var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
                var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                @case.状态 = CaseState.OnGoing;
                caseInfoManager.AddCase(@case);

            }


        }




        protected void Page_Load(object sender, EventArgs e)
        {
            test();

            CurrentTaskNames = TaskNames.代理部内审;
            //if (!Page.IsPostBack)
            {


                Case @case = (Case)Session["Case"];
                User user = (User)Session["User"];

                var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
                var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(CurrentTaskNames, user);
                this.CaseFile1.CurrentTaskNames = CurrentTaskNames;
                this.CaseFile1.CaseIDSource = pendingCaseIds;


            }
        }
    }
}