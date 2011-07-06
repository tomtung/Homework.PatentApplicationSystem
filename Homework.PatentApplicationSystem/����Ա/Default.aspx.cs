using System;
using System.Web.UI;

namespace Homework.PatentApplicationSystem.立案员
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/立案员/立案/Default.aspx");
        }
    }
}