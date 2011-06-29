using System;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// A document related to some case.
    /// </summary>
    public struct CaseDoc
    {
        /// <summary>
        /// The date and time when the file was uploaded.
        /// </summary>
        public DateTime UploadDateTime { get; set; }

        /// <summary>
        /// Username of the user who uploaded the file.
        /// </summary>
        public string UploadUserName { get; set; }

        /// <summary>
        /// Path of the upload file.
        /// </summary>
        public string FilePath { get; set; }
    }
}
