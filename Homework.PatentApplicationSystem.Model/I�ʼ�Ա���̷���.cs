namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 包括质检员角色的流程控制服务，由角色需要处理的任务组成。
    /// 角色在完成任务时需要调用这些任务的<see cref="IWorkflowStepService.ContinueCase"/>方法
    /// 使因该任务未完成而挂起的案件流程继续。
    /// 实现此接口的对象应由<see cref="IUserSpecificServiceFactory"/>在运行时创建。
    /// </summary>
    public interface I质检员流程服务
    {
        IWorkflowStepService 流程部质检任务 { get; }
        IWorkflowStepService 提交处理任务 { get; }
    }
}