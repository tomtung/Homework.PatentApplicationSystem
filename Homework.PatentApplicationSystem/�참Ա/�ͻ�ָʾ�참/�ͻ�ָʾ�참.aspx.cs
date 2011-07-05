using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework.PatentApplicationSystem.办案员.客户指示办案
{
    public partial class 客户指示办案 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                List<string> tabs = new List<string>();
                tabs.Add("案件信息");
                tabs.Add("相关文件");
                
                this.TabStrip1.DataSource = tabs;

                string selectedCaseID = Session["SelectedCaseID"].ToString();
                caseInfo1.CaseID = selectedCaseID;
                filecontrol1.CaseID = selectedCaseID;
            }

        }
        protected void TabStrip1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = this.TabStrip1.SelectedIndex;
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}