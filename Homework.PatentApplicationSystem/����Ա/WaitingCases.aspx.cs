using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.ServiceLocation;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
namespace Homework.PatentApplicationSystem.立案员
{
    public partial class WaitingCases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.CaseFile1.DataSource = ServiceLocator.Current.GetInstance<ICaseInfoManager>()
        }
    }
}