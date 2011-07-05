using System;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class FeedBackUserControl : System.Web.UI.UserControl
    {
        public string CaseID { get; set; }
//        public User User { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var caseMessageManager = ServiceLocator.Current.GetInstance<ICaseMessageManager>();
            DataListFeedBack.DataSource = caseMessageManager.GetMessagesOf(CaseID);
            DataListFeedBack.DataBind();
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            var doc = new CaseMessage
                          {
                              案件编号 = CaseID,
                              Content = commentText.Value,
                              SenderUsername = ((User) Session["User"]).UserName
                          };
            var caseMessageManager = ServiceLocator.Current.GetInstance<ICaseMessageManager>();
            caseMessageManager.AddMessage(doc);
            Response.Redirect(Request.Url.ToString());
        }
    }
}