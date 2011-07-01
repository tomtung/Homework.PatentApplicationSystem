namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 申请人信息
    /// </summary>
    public struct Applicant
    {
        public string 证件号 { get; set; }
        public string 类型 { get; set; }
        public string 中文名 { get; set; }
        public string 英文名 { get; set; }
        public string 简称 { get; set; }
        public string 国家 { get; set; }
        public string 省 { get; set; }
        public string 市区县 { get; set; }
        public string 中国地址 { get; set; }
        public string 外国地址 { get; set; }
        public string 邮编 { get; set; }
        public string 电话 { get; set; }
        public string 传真 { get; set; }
        public string Email { get; set; }
    }
}