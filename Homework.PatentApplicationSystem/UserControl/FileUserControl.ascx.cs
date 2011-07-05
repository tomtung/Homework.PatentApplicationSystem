﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.ServiceLocation;
using Homework.PatentApplicationSystem.Model;
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

            string FileName = listViewFiles.SelectedValue.ToString();
            string filePath = "";
            IEnumerable<CaseDoc> docs =   ServiceLocator.Current.GetInstance<ICaseDocManager>().GetDocsOf(CaseID);
            foreach (CaseDoc doc in docs)
            {
                if (doc.FileName == FileName)
                    filePath = doc.FilePath;
            }


            
            filePath = Server.MapPath(filePath);
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
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


            User CurrentUser = (User) Session["User"];
            CaseDoc doc = new CaseDoc
            {
                FileName = Guid.NewGuid().ToString(),
                UploadDateTime = DateTime.Now,
                UploadUserName = CurrentUser.UserName,
                FilePath = "~/App_Data/FileName",
                案件编号 = CaseID
            };
            var caseDocManager = ServiceLocator.Current.GetInstance<ICaseDocManager>();
            caseDocManager.AddDoc(doc);
            FileUpload1.Visible = false;
            btnUpload.Visible = false;
        }
    }
}