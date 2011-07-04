using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class CaseFileUserControl : System.Web.UI.UserControl
    {
        public object DataSource{get; set;}
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.listViewFiles.DataSource = DataSource;
            this.listViewFiles.DataBind();
        }

        protected void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTest.Text = this.listViewFiles.SelectedIndex.ToString();
        }

    }
}