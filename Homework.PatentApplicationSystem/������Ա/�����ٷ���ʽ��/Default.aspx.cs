﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;
namespace Homework.PatentApplicationSystem.代理部文员.制作官方格式函
{
    public partial class Default : System.Web.UI.Page
    {
        private string CurrentTaskNames;
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTaskNames = TaskNames.制作官方格式函;
            if (!Page.IsPostBack)
            {
                var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
                var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                var user = Session["User"] as User;
                IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(TaskNames.分案, user);
                this.CaseFile1.CurrentTaskNames = CurrentTaskNames;
                this.CaseFile1.CaseIDSource = pendingCaseIds;
            }

        }
    }
}