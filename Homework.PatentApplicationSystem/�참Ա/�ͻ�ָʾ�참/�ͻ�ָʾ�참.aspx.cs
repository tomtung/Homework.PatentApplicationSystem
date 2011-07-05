using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Homework.PatentApplicationSystem.办案员.客户指示办案
{
    public partial class 客户指示办案 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var tabs = new List<string> {"案件信息", "相关文件"};

                TabStrip1.DataSource = tabs;
            }
        }

        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = TabStrip1.SelectedIndex;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
        }
    }
}