using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using ClassLibrary;


namespace ASPNET_Web_WebForms
{
    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            string[] attachmentFilePaths = new[] {
                @"E:\11.docx"
            };

            string[] toAddressList = new string[] { "manhngdnvn202210@gmail.com", "manhngdnvn202211@gmail.com" };
            string subject = "Hello";
            string body = "123";
            string[] ccAddressList = new string[] { "chien672001@gmail.com", "chienbinh672001@gmail.com" };
            string[] bccAddressList = new string[] { "chien15th11@gmail.com","chinnguyen672020@gmail.com" };

            SendMail.Send(toAddressList, subject, body, ccAddressList, bccAddressList, attachmentFilePaths);
        }
    }
}