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
namespace Homework.PatentApplicationSystem.代理部文员.制作专利请求书
{
    public partial class Default : System.Web.UI.Page
    {
        private string CurrentTaskNames;
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTaskNames = TaskNames.制作专利请求书;
            if (!Page.IsPostBack)
            {
                var user = Session["User"] as User;
                if (user == null || user.Role != Role.代理部文员)
                {
                    Response.Redirect("/");
                }

                var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
                var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();
                IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(TaskNames.分案, user);
                this.CaseFile1.CaseIDSource = pendingCaseIds;

            }
        }
    }
}