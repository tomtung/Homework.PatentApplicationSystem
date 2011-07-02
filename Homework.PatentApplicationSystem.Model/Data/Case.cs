using System;

namespace Homework.PatentApplicationSystem.Model.Data
{
    /// <summary>
    /// 案件信息。
    /// </summary>
    public struct Case
    {
        public string 编号 { get; set; }
        public string 名称 { get; set; }
        public CaseType 案件类型 { get; set; }
        public DateTime 创建时间 { get; set; }
        public DateTime 绝限日 { get; set; }
        public CaseState 状态 { get; set; }
        public string 客户号 { get; set; }
        public string 申请人证件号 { get; set; }
        public string 发明人身份证号 { get; set; }
        public string 主办员用户名 { get; set; }
        public string 翻译用户名 { get; set; }
        public string 一校用户名 { get; set; }
        public string 二校用户名 { get; set; }
    }

    public enum CaseState
    {
        OnGoing,
        Completed
    }
}