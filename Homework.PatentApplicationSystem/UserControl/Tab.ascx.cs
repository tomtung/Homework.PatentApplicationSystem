using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class Tab : System.Web.UI.UserControl
    {
        public event EventHandler TabClick;
       
        private object _dataSource;
        public object DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value;  }
        }

        
        public int SelectedIndex
        {
            get { return this.lstViewTabStrip.SelectedIndex; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.lstViewTabStrip.DataSource = DataSource;
                this.lstViewTabStrip.DataBind();
                this.lstViewTabStrip.SelectedIndex = 0;
                   

            }
            

        }
        protected void lstViewTabStrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabClick != null)
                TabClick(this,EventArgs.Empty);
        }
        protected void lstViewTabStrip_SelectedIndexChanging(object sender, EventArgs e)
        {

        }
    }
}