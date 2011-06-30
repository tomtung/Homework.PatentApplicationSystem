namespace Homework.PatentApplicationSystem.Model.Workflow
{
    internal static class BookmarkNames
    {
        public const string 立案 = "立案";

        public const string 中间文件处理分案 = "中间文件处理分案";
        public const string 新申请分案 = "新申请分案";

        public const string 客户指示办案 = "客户指示办案";
        public const string 官方来函办案 = "官方来函办案";

        public const string 撰写五书 = "撰写五书";
        public const string 原始资料翻译 = "原始资料翻译";
        public const string 原始资料翻译一校 = "原始资料翻译一校";
        public const string 原始资料翻译二校 = "原始资料翻译二校";

        public const string 代理部内审 = "代理部内审";

        public const string 定稿五书 = "定稿五书";
        public const string 制作专利请求书 = "制作专利请求书";

        public const string 制作官方格式函 = "制作官方格式函";

        public const string 流程部质检 = "流程部质检";
        public const string 处理提交并确认 = "处理提交并确认";

        public static string[] 立案员任务 = new[] {立案};

        public static string[] 代理部主管任务 = new[] {中间文件处理分案, 新申请分案, 代理部内审};

        public static string[] 代理部文员任务 = new[] { 制作官方格式函, 制作专利请求书 };

        public static string[] 办案员任务 = new[]
                                           {
                                               撰写五书, 
                                               原始资料翻译, 
                                               原始资料翻译一校, 
                                               原始资料翻译二校, 
                                               客户指示办案, 
                                               官方来函办案,
                                               定稿五书
                                           };

        public static string[] 质检员任务 = new[] {流程部质检, 处理提交并确认};
    }
}