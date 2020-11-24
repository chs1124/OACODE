using StudyOA.BLL;
using StudyOA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyOA.Model;
using StudyOA.Model.EnumType;

namespace StudyOA.WebApp.Controllers
{
    public class UserInfoController : BaseController/*Controller*/
    {
        // GET: UserInfo
        IUserInfoService userInfoService { get; set; }
        IRoleInfoService RoleInfoService { get; set; }
        IActionInfoService ActionInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        #region  获取表格数据     
        public ActionResult GetUserInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DeleteEnumType.Normarl;
            var userInfoList= userInfoService.LoadPageEntities<int>(pageIndex,pageSize,out totalCount,
              c=>c.DelFlag== delFlag, c=>c.ID,false );
            var temp = from u in userInfoList
                       select new
                       {
                           ID=u.ID,
                           UName=u.UName,
                           UPwd=u.UPwd,
                           Remark=u.Remark,
                           SubTime=u.SubTime
                       };
            return Json(new { rows=temp,total=totalCount});
        }
        #endregion
        #region 删除数据
        public ActionResult DeleteUserInfo()
        {
            string strId = Request["strId"] != null ? Request["strId"] : "";
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (string id in strIds)
            {
                list.Add(Convert.ToInt16(id));
            }
            if (userInfoService.DeleteEntities(list))
            {
                return ViewBag.data("ok");
            }
            else
            {
                return ViewBag.data("no");
            }
            
        }
        #endregion
        #region 添加数据
        public ActionResult AddUserInfo(UserInfo userInfo)
        {
            userInfo.DelFlag = 0;
            userInfo.ModifiedOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            userInfoService.AddEntity(userInfo);

            return ViewBag.data("ok");
        }
        #endregion
        #region 查询要编辑数据
        public ActionResult ShowEditInfo()
        {
            int id = int.Parse(Request["ID"]);
           var userInfoObj= userInfoService.LoadEntities(u=>u.ID==id).FirstOrDefault();
            return Json(userInfoObj, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 修改数据
        public ActionResult EditUserInfo(UserInfo userInfo)
        {
            userInfo.ModifiedOn = DateTime.Now;
            if (userInfoService.EditEntity(userInfo))
            {
                return ViewBag.data("ok");
            }
            else
            {
                return ViewBag.data("no");
            }
        }
        #endregion
        #region 展示用户已经有的角色
        public ActionResult ShowUserRoleInfo() {
            int id = int.Parse(Request["id"]);
            var userInfo = this.userInfoService.LoadEntities(u=>u.ID==id).FirstOrDefault();
            ViewBag.UserInfo = userInfo;
            short delFlag = (short)DeleteEnumType.Normarl;
            var allRoleList = RoleInfoService.LoadEntities(r => r.DelFlag == delFlag).ToList();
          
            var allUuserRoleIdList = (from r in userInfo.RoleInfo
                                      select r.ID).ToList();
            ViewBag.AllRoleList = allRoleList;
            ViewBag.AllUserRoleIdList = allUuserRoleIdList;
            return View();
        }
        #endregion
        #region 分配角色
        public ActionResult SetUserRoleInfo()
        {
            int userId = int.Parse(Request["userId"]);
            string[] allKeys = Request.Form.AllKeys;
            List<int> roleIdList = new List<int>();
            foreach (string key in allKeys)
            {
                if (key.StartsWith("cba_"))
                {
                    string k = key.Replace("cba_","");
                    roleIdList.Add(Convert.ToInt32(k));
                }
            }
            if (userInfoService.SetRoleUserInfo(userId, roleIdList))
            {
                return Content("ok");
            }
            else {
                return Content("no");
            }
        }
        #endregion

        #region 展示用户已有的权限
        public ActionResult ShowUserAction()
        {
            int userId = int.Parse(Request["Id"]);
            var userInfo = userInfoService.LoadEntities(u=>u.ID==userId).FirstOrDefault();
            ViewBag.UserInfo = userInfo;

            //所有权限
            short delFlag = (short)DeleteEnumType.Normarl;
            var allActionList = ActionInfoService.LoadEntities(a => a.DelFlag == delFlag).ToList();
            var allActionIdList = (from a in userInfo.R_UserInfo_ActionInfo
                                   select a).ToList();
            ViewBag.AllActionList = allActionList;
            ViewBag.AllActionIdList = allActionIdList;
            return View();

        }
        #endregion
    }
}