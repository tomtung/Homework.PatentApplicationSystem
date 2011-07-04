using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.ServiceLocation;
using Homework.PatentApplicationSystem.Model.Data;

namespace Homework.PatentApplicationSystem.立案员
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<string> tabs = new List<string>();
                tabs.Add("案件信息");
                tabs.Add("相关文件");
                this.TabStrip1.DataSource = tabs;
                
            }
        }

        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = this.TabStrip1.SelectedIndex;
        }
    }
}