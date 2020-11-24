 
using StudyOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.IBLL
{
	
	public partial interface IActionInfoService : IBaseService<ActionInfo>
    {
       
    }   
	
	public partial interface IDepartmentService : IBaseService<Department>
    {
       
    }   
	
	public partial interface IR_UserInfo_ActionInfoService : IBaseService<R_UserInfo_ActionInfo>
    {
       
    }   
	
	public partial interface IRoleInfoService : IBaseService<RoleInfo>
    {
        bool DeleteEntities(List<int> list);
      
    }   
	
	public partial interface IUserInfoService : IBaseService<UserInfo>
    {
         bool SetRoleUserInfo(int userId, List<int> roleIdList);
    }   
	
}