using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyOA.Common;
using StudyOA.Model;

namespace StudyOA.WebApp.Controllers
{
    public class BaseController : Controller
    {
        public UserInfo LoginUser { get; set; }
        /// <summary>
        /// 执行控制器中的方法先执行此方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            bool isSucess = false;
            //if (Session["userInfo"] == null)
            if(Request.Cookies["sessionId"]!=null)
            {
                string sessionId = Request.Cookies["sessionId"].Value;
                //根据该值查
                object obj = MemcachedHelper.get(sessionId);
                if (obj != null)
                {
                    UserInfo userInfo = SerializeHelper.DeserializeToObject<UserInfo>(obj.ToString());
                    LoginUser = userInfo;
                    isSucess = true;
                    MemcachedHelper.set(sessionId,obj,DateTime.Now.AddMinutes(20));
                }
                //filterContext.HttpContext.Response.Redirect("/Login/Index");
                //filterContext.Result = Redirect("/Login/Index");
            }
            if (!isSucess)
            {
                filterContext.Result = Redirect("/Login/Index");
            }

        }
    }
}