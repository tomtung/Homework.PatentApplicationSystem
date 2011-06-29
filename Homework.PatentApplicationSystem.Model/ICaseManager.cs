using System;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 用于管理案件信息和新案件的创建。
    /// </summary>
    public interface ICaseManager
    {
        /// <summary>
        /// 获得案件编号为<param name="caseId"/>的案件信息。
        /// </summary>
        Case GetCaseById(Guid caseId);
        
        /// <summary>
        /// 保存案件<param name="case"/>的信息，并启动此案件流程。
        /// </summary>
        void CreateCase(Case @case);
    }
}