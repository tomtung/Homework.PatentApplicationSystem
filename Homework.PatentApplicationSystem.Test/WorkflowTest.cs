using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommonServiceLocator.NinjectAdapter;
using FluentAssertions;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using NUnit.Framework;

namespace Homework.PatentApplicationSystem.Test
{
    [TestFixture]
    public class WorkflowTest
    {
        [TestFixtureSetUp]
        private void Setup()
        {
            // 这里使用我本机的Connection String。连接其它数据库服务器需要相应修改。
            const string connString =
                @"Data Source=TOMTUNG-THINK\SQLEXPRESS;Initial Catalog=HW_PAS;Integrated Security=True";
            IKernel kernel = new StandardKernel(new DefaultNinjectModule(connString));
            var serviceLocator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }


        private static void 新申请测试(Case @case, User 主办员, User 翻译, User 一校, User 二校)
        {
            立案(@case);
            分案(@case.编号, 主办员, 翻译, 一校, 二校);

            Action 处理新申请案件 =
                () => Parallel.Invoke(() => 办案(@case.编号, 主办员, TaskNames.撰写五书)
                                                .Should().BeTrue(),
                                      () =>
                                          {
                                              办案(@case.编号, 一校, TaskNames.原始资料翻译一校)
                                                  .Should().BeFalse();
                                              办案(@case.编号, 翻译, TaskNames.原始资料翻译)
                                                  .Should().BeTrue();

                                              办案(@case.编号, 二校, TaskNames.原始资料翻译二校)
                                                  .Should().BeFalse();
                                              办案(@case.编号, 一校, TaskNames.原始资料翻译一校)
                                                  .Should().BeTrue();

                                              办案(@case.编号, 二校, TaskNames.原始资料翻译二校)
                                                  .Should().BeTrue();
                                          });
            处理新申请案件();
            // 第一次内审不通过
            代理部内审(@case.编号, false);
            处理新申请案件();
            // 第二次内审通过
            代理部内审(@case.编号, true);

            办案(@case.编号, 主办员, TaskNames.定稿五书).Should().BeTrue();

            文员处理案件(@case.编号, TaskNames.制作专利请求书);

            流程部质检(@case.编号, true);
            处理提交并确认(@case.编号);
        }

        private static void 客户指示处理测试(Case @case, User user)
        {
            立案(@case);
            分案(@case.编号, user);
            办案(@case.编号, user, TaskNames.客户指示办案).Should().BeTrue();
            流程部质检(@case.编号, false);
            办案(@case.编号, user, TaskNames.客户指示办案).Should().BeTrue();
            流程部质检(@case.编号, false);
            办案(@case.编号, user, TaskNames.客户指示办案).Should().BeTrue();
            流程部质检(@case.编号, true);
            处理提交并确认(@case.编号);
        }

        private static void 官方来函测试(Case @case, User user)
        {
            立案(@case);
            分案(@case.编号, user);

            办案(@case.编号, user, TaskNames.官方来函办案);
            代理部内审(@case.编号, false);
            办案(@case.编号, user, TaskNames.官方来函办案);
            代理部内审(@case.编号, true);
            文员处理案件(@case.编号, TaskNames.制作官方格式函);
            流程部质检(@case.编号, false);
            办案(@case.编号, user, TaskNames.官方来函办案);
            代理部内审(@case.编号, true);
            文员处理案件(@case.编号, TaskNames.制作官方格式函);
            流程部质检(@case.编号, true);
            处理提交并确认(@case.编号);
        }

        private static void 立案(Case @case)
        {
            Debug.WriteLine("立案：" + @case.编号);
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            @case.状态 = CaseState.OnGoing;
            // 首先保存案件信息
            caseInfoManager.AddCase(@case);
            
            // 然后启动案件流程
            caseWorkflowManager.StartCase(@case);

            // 应该已经保存了
            Case? caseGot = caseInfoManager.GetCaseById(@case.编号);
            caseGot.Should().NotBeNull();
            caseGot.Value.状态.Should().Be(CaseState.OnGoing);
        }

        private static void 分案(string caseId, User 主办员, User 翻译 = null, User 一校 = null, User 二校 = null)
        {
            Debug.WriteLine("分案：" + caseId);
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            // 已登录的代理部主管
            var user = new User {UserName = "某代理部主管", Password = "123", Role = Role.代理部主管};

            // 查看待分案的案件
            IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(TaskNames.分案, user);
            pendingCaseIds.Should().Contain(caseId);

            Case @case = caseInfoManager.GetCaseById(caseId).Value;

            // 指定办案员
            @case.主办员用户名 = 主办员.UserName;
            // 除非是新申请案件，以下三项都为空
            if (翻译 != null) @case.翻译用户名 = 翻译.UserName;
            if (一校 != null) @case.一校用户名 = 一校.UserName;
            if (二校 != null) @case.二校用户名 = 二校.UserName;

            // 更新案件信息
            caseInfoManager.UpdateCase(@case);

            // 任务完成
            caseWorkflowManager.ResumeCase(@case, TaskNames.分案);

            // 这时案件应该就已经从他的分案任务表中移除了
            caseWorkflowManager.GetPendingCaseIds(TaskNames.分案, user).Should().NotContain(caseId);
        }


        private static bool 办案(string caseId, User user, string taskName)
        {
            Debug.WriteLine(taskName + "：" + caseId + " by " + user.UserName);
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            // 待处理案件
            IEnumerable<string> pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(taskName, user);
            if (!pendingCaseIds.Contains(caseId)) return false;

            // 办案过程，发消息上传下载文档什么的……

            // 办好了
            caseWorkflowManager.ResumeCase(caseId, taskName);

            // 这时案件应该就已经从他的任务表中移除了
            caseWorkflowManager.GetPendingCaseIds(taskName, user).Should().NotContain(caseId);
            return true;
        }

        private static void 代理部内审(string caseId, bool pass)
        {
            Debug.WriteLine("代理部内审：" + caseId);
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            var user = new User {UserName = "某代理部主管", Password = "123", Role = Role.代理部主管};
            caseWorkflowManager.GetPendingCaseIds(TaskNames.代理部内审, user).Should().Contain(caseId);

            // 各种审…………

            // 审完了
            caseWorkflowManager.ResumeCase(caseId, TaskNames.代理部内审, pass);

            // 这时案件应该就已经从他的任务表中移除了
            caseWorkflowManager.GetPendingCaseIds(TaskNames.代理部内审, user).Should().NotContain(caseId);
        }

        private static void 文员处理案件(string caseId, string taskName)
        {
            Debug.WriteLine(taskName + "：" + caseId);
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            var user = new User {UserName = "某文员", Password = "123", Role = Role.代理部文员};
            caseWorkflowManager.GetPendingCaseIds(taskName, user).Should().Contain(caseId);

            // 制作…………

            // 好了
            caseWorkflowManager.ResumeCase(caseId, taskName);

            // 这时案件应该就已经从他的任务表中移除了
            caseWorkflowManager.GetPendingCaseIds(taskName, user).Should().NotContain(caseId);
        }

        private static void 流程部质检(string caseId, bool pass)
        {
            Debug.WriteLine("流程部质检：" + caseId);
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            var user = new User {UserName = "某质检员", Password = "123", Role = Role.质检员};
            caseWorkflowManager.GetPendingCaseIds(TaskNames.流程部质检, user).Should().Contain(caseId);

            // 各种检验…………

            // 检验完了
            caseWorkflowManager.ResumeCase(caseId, TaskNames.流程部质检, pass);

            // 这时案件应该就已经从他的任务表中移除了
            caseWorkflowManager.GetPendingCaseIds(TaskNames.流程部质检, user).Should().NotContain(caseId);
        }

        private static void 处理提交并确认(string caseId)
        {
            Debug.WriteLine("处理提交并确认：" + caseId);
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            var user = new User {UserName = "某质检员", Password = "123", Role = Role.质检员};
            caseWorkflowManager.GetPendingCaseIds(TaskNames.处理提交并确认, user).Should().Contain(caseId);

            // 各种…………

            // 好了
            caseWorkflowManager.ResumeCase(caseId, TaskNames.处理提交并确认);

            // 这时案件应该就已经从他的任务表中移除了
            caseWorkflowManager.GetPendingCaseIds(TaskNames.处理提交并确认, user).Should().NotContain(caseId);
            // 案件状态也变成已完成
            ServiceLocator.Current.GetInstance<ICaseInfoManager>()
                .GetCaseById(caseId).Value.状态.Should().Be(CaseState.Completed);
        }

        /// <summary>
        /// 测试整个工作流程。
        /// 此测试<b>不是</b>可以自动化执行的单元测试。
        /// 测试前需删除数据库并用项目提供的脚本重建。
        /// </summary>
        [Test]
        public void TestEntireWorkflow()
        {
            // 三个办案员
            var 办案员A = new User {UserName = "办案员A", Password = "AAA", Role = Role.办案员};
            var 办案员B = new User {UserName = "办案员B", Password = "BBB", Role = Role.办案员};
            var 办案员C = new User {UserName = "办案员C", Password = "CCC", Role = Role.办案员};

            // 并行处理10个案件案件
            Parallel.Invoke(() => 客户指示处理测试(new Case
                                               {
                                                   编号 = "111",
                                                   创建时间 = DateTime.Now,
                                                   绝限日 = DateTime.Now.AddDays(30),
                                                   案件类型 = CaseType.客户指示处理
                                               }, 办案员B),
                            () => 客户指示处理测试(new Case
                                               {
                                                   编号 = "222",
                                                   创建时间 = DateTime.Now,
                                                   绝限日 = DateTime.Now.AddDays(30),
                                                   案件类型 = CaseType.客户指示处理
                                               }, 办案员B),
                            () => 客户指示处理测试(new Case
                                               {
                                                   编号 = "333",
                                                   创建时间 = DateTime.Now,
                                                   绝限日 = DateTime.Now.AddDays(30),
                                                   案件类型 = CaseType.客户指示处理
                                               }, 办案员A),
                            () => 新申请测试(new Case
                                            {
                                                编号 = "444",
                                                创建时间 = DateTime.Now,
                                                绝限日 = DateTime.Now.AddDays(30),
                                                案件类型 = CaseType.新申请
                                            }, 办案员A, 办案员B, 办案员A, 办案员C),
                            () => 新申请测试(new Case
                                            {
                                                编号 = "555",
                                                创建时间 = DateTime.Now,
                                                绝限日 = DateTime.Now.AddDays(30),
                                                案件类型 = CaseType.新申请
                                            }, 办案员A, 办案员B, 办案员A, 办案员C),
                            () => 新申请测试(new Case
                                            {
                                                编号 = "666",
                                                创建时间 = DateTime.Now,
                                                绝限日 = DateTime.Now.AddDays(30),
                                                案件类型 = CaseType.新申请
                                            }, 办案员A, 办案员A, 办案员B, 办案员C),
                            () => 新申请测试(new Case
                                            {
                                                编号 = "777",
                                                创建时间 = DateTime.Now,
                                                绝限日 = DateTime.Now.AddDays(30),
                                                案件类型 = CaseType.新申请
                                            }, 办案员A, 办案员C, 办案员B, 办案员A),
                            () => 官方来函测试(new Case
                                             {
                                                 编号 = "888",
                                                 创建时间 = DateTime.Now,
                                                 绝限日 = DateTime.Now.AddDays(30),
                                                 案件类型 = CaseType.官方来函
                                             }, 办案员C),
                            () => 官方来函测试(new Case
                                             {
                                                 编号 = "999",
                                                 创建时间 = DateTime.Now,
                                                 绝限日 = DateTime.Now.AddDays(30),
                                                 案件类型 = CaseType.官方来函
                                             }, 办案员B),
                            () => 官方来函测试(new Case
                                             {
                                                 编号 = "000",
                                                 创建时间 = DateTime.Now,
                                                 绝限日 = DateTime.Now.AddDays(30),
                                                 案件类型 = CaseType.官方来函
                                             }, 办案员B));
        }
    }
}