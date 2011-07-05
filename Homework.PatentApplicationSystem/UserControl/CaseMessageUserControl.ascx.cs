using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;
namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class CaseMessageUserControl : System.Web.UI.UserControl
    {
        public string CaseID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                this.DataListCaseMessage.DataSource = ServiceLocator.Current.GetInstance<ICaseMessageManager>().GetMessagesOf(CaseID);
                this.DataListCaseMessage.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            var caseMessageManager = ServiceLocator.Current.GetInstance<ICaseMessageManager>();
            CaseMessage @doc = new CaseMessage
                                {
                                    案件编号 = CaseID,
                                    Content = this.tBoxFeedBack.Text,
                                    SenderUsername = Session["UserName"].ToString()
                                };
            caseMessageManager.AddMessage(doc);

        }
    }
}