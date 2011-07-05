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
namespace Homework.PatentApplicationSystem.质检员.处理提交并确认
{
    public partial class Default : System.Web.UI.Page
    {
        private string CurrentTaskNames;
 

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTaskNames = TaskNames.处理提交并确认;
            if (!Page.IsPostBack)
            {
                var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                var user = Session["User"] as User;
                IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(CurrentTaskNames, user);
                this.CaseFile1.CurrentTaskNames = CurrentTaskNames;
            }
        }
    }
}