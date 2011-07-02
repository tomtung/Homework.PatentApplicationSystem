namespace Homework.PatentApplicationSystem.Model.Data
{
    /// <summary>
    /// 用于管理案件信息。
    /// </summary>
    public interface ICaseInfoManager
    {
        /// <summary>
        /// 获得案件编号为<param name="caseId"/>的案件信息。
        /// </summary>
        Case? GetCaseById(string caseId);

        /// <summary>
        /// 保存案件<param name="case"/>的信息。该方法并不会自动开始未启动的案件流程。
        /// </summary>
        void AddCase(Case @case);
    }
}