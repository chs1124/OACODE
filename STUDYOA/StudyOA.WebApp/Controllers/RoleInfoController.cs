using StudyOA.IBLL;
using StudyOA.Model;
using StudyOA.Model.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyOA.WebApp.Controllers
{
    public class RoleInfoController : BaseController
    {
        IRoleInfoService RoleInfoService { get; set; }
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }
        #region 获取角色列表
        public ActionResult GetRoleInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DeleteEnumType.Normarl;
            var roleList = RoleInfoService.LoadPageEntities(pageIndex,pageSize,out totalCount,u=>u.DelFlag==delFlag,u=>u.ID,true);
            var temp = from r in roleList
                       select new
                       {
                           ID = r.ID,
                           RoleName = r.RoleName,
                           Sort = r.Sort,
                           SubTime = r.SubTime,
                           Remark=r.Remark
                       };
            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 展示添加表单
        public ActionResult ShowAddInfo()
        {
            return View();
        }
        #endregion

        #region 添加角色
        public ActionResult AddRoleInfo(RoleInfo roleInfo)
        {
            roleInfo.ModifiedOn = DateTime.Now;
            roleInfo.SubTime = DateTime.Now;
            roleInfo.DelFlag = 0;
            RoleInfoService.AddEntity(roleInfo);
            return Content("ok");
        }
        #endregion

        #region 删除

        public ActionResult DeleteRoleInfo()
        {
            string strId = Request["strId"] != null ? Request["strId"] : "";
            string[] strIds =strId.Split(',');
            List<int> list = new List<int>();
            foreach (string item in strIds)
            {
                list.Add(Convert.ToInt16(item));
            }
            if (RoleInfoService.DeleteEntities(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }

        }
        #endregion
    }
}