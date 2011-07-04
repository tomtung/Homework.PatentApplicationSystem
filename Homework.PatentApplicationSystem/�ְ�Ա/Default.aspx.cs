using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework.PatentApplicationSystem.分案员
{
    public partial class 分案员 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<string> tabs = new List<string>();
                tabs.Add("分案");
                this.TabStrip1.DataSource = tabs;
            }
        }
        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = this.TabStrip1.SelectedIndex;
        }
    }
}