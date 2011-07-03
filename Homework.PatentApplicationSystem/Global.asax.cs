using System;
using System.Web;
using System.Web.Security;
using Homework.PatentApplicationSystem.Model;
using Ninject;

namespace Homework.PatentApplicationSystem
{
    public class Global : HttpApplication
    {
        public static IKernel Kernel = new StandardKernel();

        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            PrepareKernel();
            string[] m_Roles = typeof (Role).GetEnumNames();
            foreach (string role in m_Roles)
            {
                if (!Roles.RoleExists(role))
                {
                    Roles.CreateRole(role);
                }
            }
        }

        private static void PrepareKernel()
        {
            Kernel.Bind<IUserLoginService>().To<MockUserLoginService>().InSingletonScope();
        }

        private void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        private void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        private void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }

        private void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }
    }
}