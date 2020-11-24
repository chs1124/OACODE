using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOA.Model;

namespace StudyOA.IDAL
{
   public partial interface IUserInfoDal:IBaseDal<UserInfo> //数据访问借口
    {

        //此处定义自己特有的方法

        //chaxun
        //IQueryable<UserInfo> LoadEntities(System.Linq.Expressions.Expression<Func<UserInfo,bool>>whereLambda);
        //IQueryable<UserInfo> LoadPageEntities<s>(int pageIndex,int pageSize,out int totalCount,
        //    System.Linq.Expressions.Expression<Func<UserInfo,bool>>whereLambda,
        //    System.Linq.Expressions.Expression<Func<UserInfo,s>>orderbyLambda,bool isAsc);
        //bool DeleteEntity(UserInfo entity);
        //bool EditEntity(UserInfo entity);
        //UserInfo AddEntity(UserInfo entity);

    }
}
