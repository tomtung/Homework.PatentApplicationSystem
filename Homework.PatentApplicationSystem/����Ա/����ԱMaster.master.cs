using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;

namespace Homework.PatentApplicationSystem.立案员
{
    public partial class 立案员Master : System.Web.UI.MasterPage
    {
        public void SetTask(string taskName)
        {
            if (taskName == TaskNames.立案)
                立案Tab.Attributes.Add("class", "selected");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}