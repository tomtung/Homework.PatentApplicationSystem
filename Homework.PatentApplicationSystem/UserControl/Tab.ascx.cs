using System;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class Tab : System.Web.UI.UserControl
    {
        public object DataSource { get; set; }


        public int SelectedIndex
        {
            get { return lstViewTabStrip.SelectedIndex; }
        }

        public event EventHandler TabClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lstViewTabStrip.DataSource = DataSource;
                lstViewTabStrip.DataBind();
                lstViewTabStrip.SelectedIndex = 0;
            }
        }

        protected void lstViewTabStrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabClick != null)
                TabClick(this, EventArgs.Empty);
        }

        protected void lstViewTabStrip_SelectedIndexChanging(object sender, EventArgs e)
        {
        }
    }
}