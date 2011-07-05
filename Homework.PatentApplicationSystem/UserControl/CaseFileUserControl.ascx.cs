using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Workflow;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;
namespace Homework.PatentApplicationSystem.UserControl
{

   
    public partial class CaseFileUserControl : System.Web.UI.UserControl
    {
        public IEnumerable<string> CaseIDSource{get; set;}
        public string CurrentTaskNames { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
                var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                User currentUser = (User)Session["User"];
                this.listViewFiles.DataSource = caseWorkflowManager.GetPendingCaseIds(CurrentTaskNames, currentUser).Select(id => caseInfoManager.GetCaseById(id).Value);
                
                this.listViewFiles.DataBind();

            }
        }

        protected void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void lbtnSelect_Click(object sender, EventArgs e)
        {
            Session["SelectedCaseID"] = this.listViewFiles.SelectedDataKey.Value;
            User currentUser = (User)Session["User"];
            string url = "~/" + currentUser.Role + "/MainPage.aspx";
            Response.Redirect(url);
        }

    }
}