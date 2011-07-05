using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.ServiceLocation;
using Homework.PatentApplicationSystem.Model.Data;
namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class FileUserControl : System.Web.UI.UserControl
    {
        public string CaseID { get; set; }
        

        protected void Page_Load(object sender, EventArgs e)
        {

            this.listViewFiles.DataSource = ServiceLocator.Current.GetInstance<ICaseDocManager>().GetDocsOf(CaseID);
            this.listViewFiles.DataBind();
            
        }

        protected void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void lbtnDownload_Click(object sender, EventArgs e)
        {
            
        }
        

    }
}