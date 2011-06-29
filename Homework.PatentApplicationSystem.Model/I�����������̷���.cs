namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 包括代理部主管角色的流程控制服务，由角色需要处理的任务组成。
    /// 角色在完成任务时需要调用这些任务的<see cref="IWorkflowStepService.ContinueCase"/>方法
    /// 使因该任务未完成而挂起的案件流程继续。
    /// 实现此接口的对象应由<see cref="IUserSpecificServiceFactory"/>在运行时创建。
    /// </summary>
    public interface I代理部主管流程服务
    {
        IWorkflowStepService 中间文件处理分案任务 { get; }
        IWorkflowStepService 新申请分案任务 { get; }
        IWorkflowStepService 代理部内审任务 { get; }
    }
}