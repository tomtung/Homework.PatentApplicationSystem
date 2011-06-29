namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 包括办案员角色的流程控制服务，由角色需要处理的任务组成。
    /// 角色在完成任务时需要调用这些任务的<see cref="IWorkflowStepService.ContinueCase"/>方法
    /// 使因该任务未完成而挂起的案件流程继续。
    /// 实现此接口的对象应由<see cref="IUserSpecificServiceFactory"/>在运行时创建。
    /// </summary>
    public interface I办案员流程服务
    {
        IWorkflowStepService 撰写五书办案任务 { get; }
        IWorkflowStepService 原始资料翻译任务 { get; }
        IWorkflowStepService 原始资料翻译一校任务 { get; }
        IWorkflowStepService 原始资料翻译二校任务 { get; }
        IWorkflowStepService 定稿五书任务 { get; }
        IWorkflowStepService 官方来函办案任务 { get; }
        IWorkflowStepService 客户指示办案任务 { get; }
    }
}