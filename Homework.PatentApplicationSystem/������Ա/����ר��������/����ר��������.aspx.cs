using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Homework.PatentApplicationSystem.代理部文员.制作专利请求书
{
    public partial class 制作专利请求书 : Page
    {
        public string CurrentTaskNames { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTaskNames = "制作专利请求书";

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