using System;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 表示案件与服务器上文件的关联关系。
    /// </summary>
    public struct CaseDoc
    {
        /// <summary>
        /// 显示给用户的文件名。
        /// </summary>
        public string FileName { get; set; }
        
        public Guid 案件编号 { get; set; }

        /// <summary>
        /// The date and time when the file was uploaded.
        /// </summary>
        public DateTime UploadDateTime { get; set; }

        /// <summary>
        /// Username of the user who uploaded the file.
        /// </summary>
        public string UploadUserName { get; set; }

        /// <summary>
        /// 文件在服务器上实际的存储路径。
        /// </summary>
        public string FilePath { get; set; }
    }
}
