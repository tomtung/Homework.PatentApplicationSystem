using System;
using System.Web.UI;

namespace Homework.PatentApplicationSystem.质检员
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/质检员/流程部质检/Default.aspx");
        }
    }
}