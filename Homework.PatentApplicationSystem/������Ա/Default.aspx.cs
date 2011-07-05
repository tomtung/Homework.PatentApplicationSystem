using System;
using System.Web.UI;

namespace Homework.PatentApplicationSystem.代理部文员
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/代理部文员/制作专利请求书/Default.aspx");
        }
    }
}