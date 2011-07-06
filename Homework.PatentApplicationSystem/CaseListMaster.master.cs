using System.Web.UI;

namespace Homework.PatentApplicationSystem
{
    public partial class CaseListMaster : MasterPage
    {
        public string TaskName
        {
            get { return CaseList.CurrentTaskName; }
            set
            {
                CaseList.CurrentTaskName = value;
                Master.SetTaskName(value);
            }
        }
    }
}