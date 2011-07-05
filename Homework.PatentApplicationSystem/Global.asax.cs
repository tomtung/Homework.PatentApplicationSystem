using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using CommonServiceLocator.NinjectAdapter;
using Homework.PatentApplicationSystem.Model;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Homework.PatentApplicationSystem
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            PrepareKernel();
            //string[] m_Roles = typeof (Role).GetEnumNames();
            //foreach (string role in m_Roles)
            //{
            //    if (!Roles.RoleExists(role))
            //    {
            //        Roles.CreateRole(role);
            //    }
            //}
        }

        private static void PrepareKernel()
        {
            Configuration webconfig =
                WebConfigurationManager.OpenWebConfiguration("/");
            ConnectionStringSettings connString =
                webconfig.ConnectionStrings.ConnectionStrings["ApplicationServices"];
            IKernel kernel = new StandardKernel(new DefaultNinjectModule(connString.ConnectionString));
            var serviceLocator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
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