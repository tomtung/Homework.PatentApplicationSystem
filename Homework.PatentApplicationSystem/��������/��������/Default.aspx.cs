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
        



        protected void Page_Load(object sender, EventArgs e)
        {
            //test();

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