using StudyOA.DALFactory;
using StudyOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.BLL
{
    public abstract class BaseService<T> where T:class,new()
    {
        public IDBSession currentDBSession
        {
            get { return DBSessionFactory.CreatDBSession(); }
        }
        public IDAL.IBaseDal<T> currentDal { get; set; }
        public abstract void setCurrentDal();
        public BaseService()
        {
            setCurrentDal();//子类一定要实现抽象方法
        }

        //添加
        public T AddEntity(T entity)
        {
            currentDal.AddEntity(entity);
            currentDBSession.savechanges();
            return entity;
        }

        //删除
        public bool DeleteEntity(T entity)
        {
            
            currentDal.DeleteEntity(entity);
            return currentDBSession.savechanges();
        }

        //编辑更新
        public bool EditEntity(T entity)
        {
           
            currentDal.EditEntity(entity);
            return currentDBSession.savechanges();
        }

        //查询
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {

            return currentDal.LoadEntities(whereLambda);
        }

        //分页
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
          
            return currentDal.LoadPageEntities<s>(pageIndex,pageSize,out totalCount,whereLambda,orderbyLambda,isAsc);
        }

    }
}
