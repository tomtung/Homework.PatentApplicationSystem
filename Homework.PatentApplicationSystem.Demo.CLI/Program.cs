using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CommonServiceLocator.NinjectAdapter;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Homework.PatentApplicationSystem.Demo.CLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SetUp();

            // 这还应该填入更多信息，懒得写了暂时= =
            var @case = new Case
                            {
                                编号 = "ABCDEFG",
                                // 这两个日期一定要写，否则会报错= =
                                创建时间 = DateTime.Now,
                                绝限日 = DateTime.Now.AddDays(30),
                                案件类型 = CaseType.客户指示处理
                            };

            立案(@case);

            分案();

            办案();

            质检(false); // 这次不通过

            办案();

            质检(true); // 这次就通过了吧

            完成();
        }

        private static void 完成()
        {
            Console.WriteLine("完成");
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            // 质检员
            var user = new User {UserName = "某质检员", Password = "123", Role = Role.质检员};

            // 查看待办案件
            IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(TaskNames.处理提交并确认, user);
            // 选择其中一个
            Case @case = caseInfoManager.GetCaseById(pendingCaseIds.First()).Value;
            // 各种…………
            // 好了
            caseWorkflowManager.ResumeCase(@case.编号, TaskNames.处理提交并确认);

            // 工作流在另一条线程上执行，可能还没处理完，注意查看调试窗口信息
            Console.ReadKey();

            // 从他眼前消失
            Debug.Assert(!caseWorkflowManager.GetPendingCaseIds(TaskNames.处理提交并确认, user).Contains(@case.编号));
            // 案件状态也变成已完成
            @case = caseInfoManager.GetCaseById(pendingCaseIds.First()).Value;
            Debug.Assert(@case.状态 == CaseState.Completed);
        }

        private static void 质检(bool 通过)
        {
            Console.WriteLine("质检");
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            // 质检员
            var user = new User {UserName = "某质检员", Password = "123", Role = Role.质检员};

            // 查看待办案件
            IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(TaskNames.流程部质检, user);
            // 选择其中一个
            Case @case = caseInfoManager.GetCaseById(pendingCaseIds.First()).Value;
            // 各种检验………………
            // 检验完了
            caseWorkflowManager.ResumeCase(@case.编号, TaskNames.流程部质检, 通过);

            // 工作流在另一条线程上执行，可能还没处理完，注意查看调试窗口信息
            Console.ReadKey();

            // 案件就从他眼前消失了
            Debug.Assert(!caseWorkflowManager.GetPendingCaseIds(TaskNames.流程部质检, user).Contains(@case.编号));
        }

        private static void 办案()
        {
            Console.WriteLine("办案");
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            // 某个酱油办案员
            var userx = new User {UserName = "办案员X", Password = "123", Role = Role.办案员};
            // 因为没有分案给他，他应该看不到案件
            Debug.Assert(caseWorkflowManager.GetPendingCaseIds(TaskNames.客户指示办案, userx).Count() == 0);

            // 这才是要办案的办案员
            var user = new User {UserName = "办案员A", Password = "123", Role = Role.办案员};
            // 查看待办案件
            IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(TaskNames.客户指示办案, user);
            // 选择其中一个
            Case @case = caseInfoManager.GetCaseById(pendingCaseIds.First()).Value;
            // 做某些办案活动……（上传下载文件、留言什么的，调用其它接口了就）
            // 办完了
            caseWorkflowManager.ResumeCase(@case.编号, TaskNames.客户指示办案);

            // 工作流在另一条线程上执行，可能还没处理完，注意查看调试窗口信息
            Console.ReadKey();

            // 案件应该就从他眼前消失了
            Debug.Assert(!caseWorkflowManager.GetPendingCaseIds(TaskNames.客户指示办案, user).Contains(@case.编号));
        }

        private static void 分案()
        {
            Console.WriteLine("分案");
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            // 已登录的代理部主管
            var user = new User {UserName = "某代理部主管", Password = "123", Role = Role.代理部主管};

            // 查看待分案的案件
            IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(TaskNames.分案, user);

            // 选择其中一个
            Case @case = caseInfoManager.GetCaseById(pendingCaseIds.First()).Value;

            // 指定主办员
            @case.主办员用户名 = "办案员A";

            // 更新案件信息
            caseInfoManager.UpdateCase(@case);

            // 任务完成
            caseWorkflowManager.ResumeCase(@case, TaskNames.分案);

            // 工作流在另一条线程上执行，可能还没处理完，注意查看调试窗口信息
            Console.ReadKey();

            // 应该就已经从他的分案任务表中移除了
            Debug.Assert(!caseWorkflowManager.GetPendingCaseIds(TaskNames.分案, user).Contains(@case.编号));
        }

        private static void 立案(Case @case)
        {
            Console.WriteLine("立案");
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            @case.状态 = CaseState.OnGoing;
            caseInfoManager.AddCase(@case);
            caseWorkflowManager.StartCase(@case);

            // 应该已经保存了
            @case = caseInfoManager.GetCaseById(@case.编号).Value;
            Debug.Assert(@case.状态 == CaseState.OnGoing);

            // 工作流在另一条线程上执行，可能还没处理完，注意查看调试窗口信息
            Console.ReadKey();
        }

        private static void SetUp()
        {
            // 这几行在 Global.asax.cs里写
            const string connString =
                @"Data Source=TOMTUNG-THINK\SQLEXPRESS;Initial Catalog=HW_PAS;Integrated Security=True";
            IKernel kernel = new StandardKernel(new DefaultNinjectModule(connString));
            var serviceLocator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
    }
}