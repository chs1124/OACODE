using StudyOA.IBLL;
using StudyOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOA.IDAL;

namespace StudyOA.BLL
{
    public partial class UserInfoService :BaseService<UserInfo>,IUserInfoService
    {
     
        //public override void setCurrentDal()
        //{
        //    currentDal = this.curentDBSession.userInfoDal;
        //} 
        public bool DeleteEntities(List<int> list)
        {
            
            var userInfoList = this.currentDBSession.UserInfoDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var userInfo in userInfoList)
            {
                this.currentDBSession.UserInfoDal.DeleteEntity(userInfo);
                
            }
              return this.currentDBSession.savechanges();
        }

        public bool SetRoleUserInfo(int userId,List<int> roleIdList)
        {
            var userInfo= this.currentDBSession.UserInfoDal.LoadEntities(u => u.ID == userId).FirstOrDefault();
            if (userInfo != null)
            { 
            foreach (int roleId in roleIdList)
            {
                var roleInfo = this.currentDBSession.RoleInfoDal.LoadEntities(r => r.ID == roleId).FirstOrDefault();
                userInfo.RoleInfo.Add(roleInfo);
            }
               return this.currentDBSession.savechanges();
            }
            return false;
        }
        public void SetUserInfo(UserInfo userInfo)
        {
            this.currentDBSession.UserInfoDal.AddEntity(userInfo);
            this.currentDBSession.UserInfoDal.DeleteEntity(userInfo);
            this.currentDBSession.UserInfoDal.EditEntity(userInfo);
            this.currentDBSession.savechanges();
        }
    }
}
