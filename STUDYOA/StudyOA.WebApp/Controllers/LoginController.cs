using StudyOA.Common;
using StudyOA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyOA.WebApp.Controllers
{
    public class LoginController : Controller
    {

        IUserInfoService userInfoService { get; set; }
        // GET: Login
        public ActionResult Index()
        {

            return View("Login");
        }
        #region 完成登陆
        public ActionResult UserLogin()
        {
            string validateCode = Session["ValidateCode"] != null ? Session["ValidateCode"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("验证码错误!!!");
            }
            Session["ValidateCode"] = null;
            string txtCode = Request["vCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("验证码错误!!!");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            var userInfo = userInfoService.LoadEntities(u=>u.UName==userName&&u.UPwd==userPwd).FirstOrDefault();
            if (userInfo != null)
            {
                //Session["userInfo"] = userInfo;
                string sessionId = Guid.NewGuid().ToString();
                MemcachedHelper.set(sessionId,SerializeHelper.SerializeToString(userInfo),DateTime.Now.AddMinutes(20));

                Response.Cookies["sessionId"].Value = sessionId;
                return Content("ok:登录成功" );
            }
            else
            {
                return Content("no:登录失败");
            }
        }
        #endregion

        #region 显示验证码
        public ActionResult ShowValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code= validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] buffer= validateCode.CreateValidateGraphic(code);
            return File(buffer,"image/jpeg");
        }
        #endregion
    }
}