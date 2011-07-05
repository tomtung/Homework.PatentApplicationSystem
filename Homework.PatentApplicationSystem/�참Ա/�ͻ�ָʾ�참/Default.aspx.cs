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
namespace Homework.PatentApplicationSystem.办案员.客户指示办案
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["User"] as User;
            if (user == null || user.Role != Role.代理部主管) Response.Redirect("/");
            if (!Page.IsPostBack)
            {



                var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(CurrentTaskNames, user);
                this.CaseFile1.CurrentTaskNames = TaskNames.分案;
                this.CaseFile1.CaseIDSource = pendingCaseIds;

            }
        }
    }
}