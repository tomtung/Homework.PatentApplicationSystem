namespace Homework.PatentApplicationSystem.Model.Data
{
    /// <summary>
    /// 一条某办案人员对某案件的留言信息。
    /// </summary>
    public struct CaseMessage
    {
        /// <summary>
        /// 信息所属的案件的编号。
        /// </summary>
        public string 案件编号 { get; set; }

        /// <summary>
        /// 信息内容。
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 该条信息发送者的用户名。
        /// </summary>
        public string SenderUsername { get; set; }
    }
}