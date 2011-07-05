using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Homework.PatentApplicationSystem.代理部主管.代理部内审
{
    public partial class 代理部内审 : Page
    {
        public string CurrentTaskNames { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTaskNames = "代理部内审";

            if (!Page.IsPostBack)
            {
                var tabs = new List<string>();
                tabs.Add("案件信息");
                tabs.Add("相关文件");

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