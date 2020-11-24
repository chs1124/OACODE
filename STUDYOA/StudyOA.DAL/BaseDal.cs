using StudyOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.DAL
{
    public class BaseDal<T> where T:class,new()
    {
        //OAEntities db = new OAEntities();
        DbContext db = DBContextFactory.CreateDbContext();
        //添加
        public T AddEntity(T entity)
        {
            db.Set<T>().Add(entity);
            //db.SaveChanges();
            return entity;
        }

        //删除
        public bool DeleteEntity(T entity)
        {
            db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            //return db.SaveChanges() > 0;
            return true;
        }

        //编辑更新
        public bool EditEntity(T entity)
        {
            db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            //return db.SaveChanges() > 0;
            return true;
        }

        //查询
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            
            return db.Set<T>().Where<T>(whereLambda);
        }

        //分页
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);

            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);

            }
            return temp;
        }
    }
}

