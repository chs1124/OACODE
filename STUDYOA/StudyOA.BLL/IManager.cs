 
using StudyOA.IBLL;
using StudyOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.BLL
{
	
	public partial class ActionInfoService :BaseService<ActionInfo>,IActionInfoService
    {
    

		 public override void setCurrentDal()
        {
            currentDal = this.currentDBSession.ActionInfoDal;
        }
    }   
	
	public partial class DepartmentService :BaseService<Department>,IDepartmentService
    {
    

		 public override void setCurrentDal()
        {
            currentDal = this.currentDBSession.DepartmentDal;
        }
    }   
	
	public partial class R_UserInfo_ActionInfoService :BaseService<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoService
    {
    

		 public override void setCurrentDal()
        {
            currentDal = this.currentDBSession.R_UserInfo_ActionInfoDal;
        }
    }   
	
	public partial class RoleInfoService :BaseService<RoleInfo>,IRoleInfoService
    {
        public bool DeleteEntities(List<int> list)
        {
           var RoleInfoList= this.currentDBSession.RoleInfoDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var item in RoleInfoList)
            {
                this.currentDBSession.RoleInfoDal.DeleteEntity(item);
            }
            return this.currentDBSession.savechanges();
        }

        public override void setCurrentDal()
        {
            currentDal = this.currentDBSession.RoleInfoDal;
        }
    }   
	
	public partial class UserInfoService :BaseService<UserInfo>,IUserInfoService
    {
    

		 public override void setCurrentDal()
        {
            currentDal = this.currentDBSession.UserInfoDal;
        }
    }   
	
}