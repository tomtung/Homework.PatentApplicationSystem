using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.Security;
using Homework.PatentApplicationSystem.Model;
namespace Homework.PatentApplicationSystem
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            if (user != null)
                lblUserName.Text = user.UserName.ToString();
            else
                lblUserName.Text = "Session State Management Error!!! User can't be extracted from Session";
        }
    }
}
