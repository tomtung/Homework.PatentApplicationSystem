using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;
namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class SendMailUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString.Get("To")))
                txtTo.Text = Request.QueryString.Get("To");
            SendMail.From = "lijialing19900316@126.com";
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SendMail.Send(txtSubject.Text, txtBody.Text, txtTo.Text, false);
            }


        }
    }
}