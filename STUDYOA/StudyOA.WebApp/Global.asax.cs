using log4net;
using Spring.Web.Mvc;
using StudyOA.WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StudyOA.WebApp
{
    public class MvcApplication : SpringMvcApplication//System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//读取log4配置文件信息

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //开启一个线程，扫描异常信息队列
            string filePath = Server.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem((a)=> {
                while(true)
                {
                    //判断一下队列中是否有数据
                    if (MyExceptionAttribute.ExecptionQueue.Count() > 0)
                    {
                        Exception ex = MyExceptionAttribute.ExecptionQueue.Dequeue();
                        if (ex != null)
                        {
                            //将异常信息写到日志文件中.
                            //    string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                            //    File.AppendAllText(filePath + fileName + ".txt", ex.ToString(), System.Text.Encoding.UTF8);
                            ILog logger = LogManager.GetLogger("errorMsg");
                            logger.Error(ex.ToString());
                        }
                        else
                        {
                            Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
       

                }
            },filePath);
        }
    }
}
