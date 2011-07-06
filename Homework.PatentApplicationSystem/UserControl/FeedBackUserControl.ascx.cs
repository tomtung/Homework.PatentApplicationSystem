using System;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class FeedBackUserControl : System.Web.UI.UserControl
    {
        private readonly ICaseMessageManager _caseMessageManager = ServiceLocator.Current.GetInstance<ICaseMessageManager>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var caseId = Session["SelectedCaseID"] as string;
            DataListFeedBack.DataSource = _caseMessageManager.GetMessagesOf(caseId);
            DataListFeedBack.DataBind();
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            var caseId = Session["SelectedCaseID"] as string;
            var user = (User) Session["User"];
            var doc = new CaseMessage
                          {
                              案件编号 = caseId,
                              Content = commentText.Value,
                              SenderUsername = user.UserName
                          };
            _caseMessageManager.AddMessage(doc);
            Response.Redirect(Request.Url.ToString());
        }
    }
}