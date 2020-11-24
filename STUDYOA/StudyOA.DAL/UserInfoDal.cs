using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StudyOA.IDAL;
using StudyOA.Model;

namespace StudyOA.DAL
{
    public partial class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal  //先继承后实现
    {
        //    OAEntities db = new OAEntities();
        //    //添加
        //    public UserInfo AddEntity(UserInfo entity)
        //    {
        //        db.UserInfo.Add(entity);
        //        db.SaveChanges();
        //        return entity;
        //    }

        //    //删除
        //    public bool DeleteEntity(UserInfo entity)
        //    {
        //        db.Entry<UserInfo>(entity).State = System.Data.Entity.EntityState.Deleted;
        //        return db.SaveChanges() > 0;
        //    }

        //    //编辑更新
        //    public bool EditEntity(UserInfo entity)
        //    {
        //        db.Entry<UserInfo>(entity).State = System.Data.Entity.EntityState.Modified;
        //        return db.SaveChanges() > 0;

        //    }

        //    //查询
        //    public IQueryable<UserInfo> LoadEntities(Expression<Func<UserInfo, bool>> whereLambda)
        //    {
        //        return db.UserInfo.Where<UserInfo>(whereLambda);
        //    }

        //    //分页
        //    public IQueryable<UserInfo> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, s>> orderbyLambda, bool isAsc)
        //    {
        //        var temp = db.UserInfo.Where<UserInfo>(whereLambda);
        //        totalCount = temp.Count();
        //        if (isAsc)
        //        {
        //            temp = temp.OrderBy<UserInfo, s>(orderbyLambda).Skip<UserInfo>((pageIndex - 1) * pageSize).Take<UserInfo>(pageSize);

        //        }
        //        else
        //        {
        //            temp = temp.OrderByDescending<UserInfo, s>(orderbyLambda).Skip<UserInfo>((pageIndex - 1) * pageSize).Take<UserInfo>(pageSize);

        //        }
        //        return temp;
        //    }
        //}
    }
}
