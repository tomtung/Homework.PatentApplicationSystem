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
namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class FeedBackUserControl : System.Web.UI.UserControl
    {
        public string CaseID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var caseMessageManager = ServiceLocator.Current.GetInstance<ICaseMessageManager>();
            this.DataListFeedBack.DataSource = caseMessageManager.GetMessagesOf(CaseID);
            this.DataListFeedBack.DataBind();
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            User currentUser = (User)Session["User"];
            CaseMessage doc = new CaseMessage
                              {
                                  案件编号 = CaseID,
                                  Content = this.tBoxContent.Text,
                                  SenderUsername = currentUser.UserName
                              };
            var caseMessageManager = ServiceLocator.Current.GetInstance<ICaseMessageManager>();
            caseMessageManager.AddMessage(doc);
        }
    }
}