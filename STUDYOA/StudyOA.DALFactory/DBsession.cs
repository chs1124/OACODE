using StudyOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOA.IDAL;
using StudyOA.DAL;
using System.Data.Entity;

namespace StudyOA.DALFactory
{
    /// <summary>
    /// 1.数据会话层：就是一个工厂类，负责完成所有数据操作类实例的创建，然后业务层通过数据会话层来获取要操作数据类的实例。
    /// 所以数据会话层将业务层和数据层解耦
    /// 2.提供一个方法对数据完成保存（如：对多张表操作时，只连一次数据库来保存数据）
    /// </summary>
    public partial class DBsession: IDBSession
    {

        public  DbContext db
        {
            get {
                return DBContextFactory.CreateDbContext();//创建EF实例
            }
        }  

        //OAEntities db = new OAEntities();
        //private IUserInfoDal _userInfoDal;
        //public IUserInfoDal userInfoDal
        //{
        //    get {
        //        if (_userInfoDal == null)
        //        {
        //            //_userInfoDal = new UserInfoDal();
        //            _userInfoDal = AbstractFactory.CreateUserInfoDal() ;
        //        }
        //        return _userInfoDal;
        //    }
        //    set
        //    {
        //        _userInfoDal = value;
        //    }
        //}



        public bool savechanges()
        {
            return db.SaveChanges()>0;
        }
    }
}
