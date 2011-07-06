using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class FileUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var caseId = Session["SelectedCaseID"] as string;
            listViewFiles.DataSource = ServiceLocator.Current.GetInstance<ICaseDocManager>().GetDocsOf(caseId);
            listViewFiles.DataBind();
        }

        protected void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FileName = listViewFiles.SelectedValue.ToString();
            string filePath = "";
            IEnumerable<CaseDoc> docs =
                ServiceLocator.Current.GetInstance<ICaseDocManager>().GetDocsOf(Session["SelectedCaseID"] as string);
            foreach (CaseDoc doc in docs)
            {
                if (doc.FileName == FileName)
                    filePath = doc.FilePath;
            }


            filePath = Server.MapPath(filePath);
            var fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }

        protected void listViewFiles_SelectedIndexChanging(object sender, EventArgs e)
        {

        }

        protected void lbtnDownload_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            FileUpload1.Visible = true;
            btnUpload.Visible = true;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentLength < 10485760)
                {
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/App_Data/") + FileUpload1.FileName);
                }
            }


            var CurrentUser = (User)Session["User"];
            var doc = new CaseDoc
                          {
                              FileName = Guid.NewGuid().ToString(),
                              UploadDateTime = DateTime.Now,
                              UploadUserName = CurrentUser.UserName,
                              FilePath = "~/App_Data/FileName",
                              案件编号 = Session["SelectedCaseID"] as string
                          };
            var caseDocManager = ServiceLocator.Current.GetInstance<ICaseDocManager>();
            caseDocManager.AddDoc(doc);
            FileUpload1.Visible = false;
            btnUpload.Visible = false;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewDataItem item in listViewFiles.Items)
            {
                var cBox1 = item.FindControl("cBox1") as CheckBox;
                if (cBox1.Checked)
                {
                    DataRowView rowView = (DataRowView)item.DataItem;
                    CaseDoc m_Doc = new CaseDoc
                                {
                                    案件编号 = rowView["案件编号"].ToString(),
                                    FileName = rowView["FileName"].ToString(),
                                    UploadDateTime = Convert.ToDateTime(rowView["UploadDateTime"]),
                                    UploadUserName = rowView["UploadUserName"].ToString(),
                                    FilePath = rowView["FilePath"].ToString()
                                };
                    //CaseDoc m_Doc = (CaseDoc)item.DataItem;
                    var caseDocManager = ServiceLocator.Current.GetInstance<ICaseDocManager>();
                    caseDocManager.RemoveDoc(m_Doc);

                }
            }
            var caseId = Session["SelectedCaseID"] as string;
            listViewFiles.DataSource = ServiceLocator.Current.GetInstance<ICaseDocManager>().GetDocsOf(caseId);
            listViewFiles.DataBind();
        }
    }
}