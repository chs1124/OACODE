using StudyOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.IBLL
{
     public interface IBaseService<T> where T:class,new()
    {
        IDBSession currentDBSession{get;}
        IDAL.IBaseDal<T> currentDal { get; set; }
        //添加
        T AddEntity(T entity);
        //删除
        bool DeleteEntity(T entity);
        //编辑更新
        bool EditEntity(T entity);
        //查询
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        //分页
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);

    }
}
