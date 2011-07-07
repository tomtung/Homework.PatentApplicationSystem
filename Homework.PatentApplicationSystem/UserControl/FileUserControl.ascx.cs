using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
<<<<<<< HEAD
using System.Data;
=======
>>>>>>> 1d64f65f361e7abf6b6a576291ce771b70c4fe1d
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class FileUserControl : System.Web.UI.UserControl
    {
        private readonly ICaseDocManager _caseDocManager = ServiceLocator.Current.GetInstance<ICaseDocManager>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var caseId = Session["SelectedCaseID"] as string;
            if (!Page.IsPostBack)
            {

                listViewFiles.DataSource = _caseDocManager.GetDocsOf(caseId);
                listViewFiles.DataBind();
            }
        }

        protected void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = listViewFiles.SelectedValue.ToString();
            var selectedDoc =
                _caseDocManager.GetDocsOf(Session["SelectedCaseID"] as string)
                    .Where(doc => doc.FileName == fileName)
                    .First();
            SendDownload(fileName, Server.MapPath(selectedDoc.FilePath));
        }

        private void SendDownload(string fileName, string filePath)
        {
            var info = new FileInfo(filePath);
            long fileSize = info.Length;
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachement;filename=" + fileName);
            //指定文件大小  
            Response.AddHeader("Content-Length", fileSize.ToString());
            Response.WriteFile(filePath, 0, fileSize);
            Response.Flush();
            Response.Close();
        }

        protected void listViewFiles_SelectedIndexChanging(object sender, EventArgs e)
        {

        }

        protected void lbtnDownload_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InputFile.Visible = true;
            btnUpload.Visible = true;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (InputFile.HasFile)
            {
                IEnumerable<CaseDoc> docs = _caseDocManager.GetDocsOf(Session["SelectedCaseID"] as string);
                bool multiUploadTime = false;
                foreach (CaseDoc doc in docs)
                {
                    if (doc.FileName == InputFile.FileName)
                    {
                        lblErrorMessage.Text = "您多次上传了同一文件， 请删除现有文件再上传";
                        lblErrorMessage.Visible = true;
                        multiUploadTime = true;
                    }

                }

                if (!multiUploadTime)
                {
                    string saveFilePath = Path.Combine("~/App_Data/", Guid.NewGuid().ToString());

                    InputFile.MoveTo(Server.MapPath(saveFilePath), Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                    var CurrentUser = (User)Session["User"];
                    var m_Doc = new CaseDoc
                    {
                        FileName = InputFile.FileName,
                        UploadDateTime = DateTime.Now,
                        UploadUserName = CurrentUser.UserName,
                        FilePath = saveFilePath,
                        案件编号 = Session["SelectedCaseID"] as string
                    };
                    var caseDocManager = _caseDocManager;
                    caseDocManager.AddDoc(m_Doc);
                    InputFile.Visible = false;
                    btnUpload.Visible = false;

                    var caseId = Session["SelectedCaseID"] as string;
                    listViewFiles.DataSource = _caseDocManager.GetDocsOf(caseId);
                    listViewFiles.DataBind();
                }
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //foreach (ListViewDataItem item in listViewFiles.Items)
            //{
            //    var cBox1 = item.FindControl("cBox1") as CheckBox;
            //    if (cBox1.Checked)
            //    {
            //        string fileName = listViewFiles.DataKeys[item.DataItemIndex].Value.ToString();
            //        IEnumerable<CaseDoc> docs =
            //            _caseDocManager.GetDocsOf(Session["SelectedCaseID"] as string);
            //        var caseDocManager = _caseDocManager;

            //        foreach (CaseDoc m_Doc in docs)
            //        {
            //            if (m_Doc.FileName == fileName)
            //            {
            //                caseDocManager.RemoveDoc(m_Doc);
            //                break;
            //            }
            //        }
            //    }
            //}

            //var caseId = Session["SelectedCaseID"] as string;
            //listViewFiles.DataSource = _caseDocManager.GetDocsOf(caseId);
            //listViewFiles.DataBind();

<<<<<<< HEAD
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
=======
>>>>>>> 1d64f65f361e7abf6b6a576291ce771b70c4fe1d
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
