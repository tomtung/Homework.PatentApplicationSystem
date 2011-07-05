using System;
using System.Web.UI;

namespace Homework.PatentApplicationSystem.办案员
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/办案员/撰写五书/Default.aspx");
        }
    }
}