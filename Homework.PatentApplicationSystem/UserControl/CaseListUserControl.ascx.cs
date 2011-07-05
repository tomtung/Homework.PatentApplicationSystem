using System;
using System.Linq;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class CaseListUserControl : System.Web.UI.UserControl
    {
        private readonly ICaseInfoManager _caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();

        private readonly ICaseWorkflowManager _caseWorkflowManager =
            ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

        public string CurrentTaskName
        {
            get { return ViewState["CurrentTaskNames"] as string; }
            set { ViewState["CurrentTaskNames"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listViewFiles.DataSource = _caseWorkflowManager.GetPendingCaseIds(CurrentTaskName,
                                                                                  (User) Session["User"])
                    .Select(id => _caseInfoManager.GetCaseById(id).Value);
                listViewFiles.DataBind();
            }
        }

        protected void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedCaseID"] = listViewFiles.SelectedValue.ToString();
            string url = string.Format(@"~/{0}/{1}/{1}.aspx", ((User) Session["User"]).Role, CurrentTaskName);
            Response.Redirect(url);
        }

        protected void listViewFiles_SelectedIndexChanging(object sender, EventArgs e)
        {
            // Do nothing.
        }
    }
}