using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.IDAL
{
    /// <summary>
    /// 业务层调用的是数据会话层的接口
    /// </summary>
    public partial interface IDBSession
    {
         DbContext db{ get; }
        //IUserInfoDal userInfoDal { get; set; }
         bool savechanges();
    }
}  
