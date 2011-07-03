using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonServiceLocator.NinjectAdapter;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Homework.PatentApplicationSystem.Model.Workflow;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Homework.PatentApplicationSystem.Demo.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            SetUp();

            var @case = new Case{案件类型 = CaseType.客户指示处理};

            立案(@case);

            分案();
        }

        private static void 分案()
        {
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();


            var user = new User { UserName = "某代理部主管", Password = "123", Role = Role.代理部主管 };
            
            var pendingCaseIds = caseWorkflowManager.GetPendingCaseIds(TaskNames.分案, user);

        }

        private static void 立案(Case @case)
        {
            var caseInfoManager = ServiceLocator.Current.GetInstance<ICaseInfoManager>();
            var caseWorkflowManager = ServiceLocator.Current.GetInstance<ICaseWorkflowManager>();

            caseInfoManager.AddCase(@case);
            caseWorkflowManager.StartCase(@case);
        }

        private static void SetUp()
        {
            // 这几行在 Global.asax.cs里写
            const string connString = @"Data Source=TOMTUNG-THINK\SQLEXPRESS;Initial Catalog=HW_PAS;Integrated Security=True";
            IKernel kernel = new StandardKernel(new DefaultNinjectModule(connString));
            var serviceLocator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
    }
}
