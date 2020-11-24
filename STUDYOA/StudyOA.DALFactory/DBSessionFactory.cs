using StudyOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.DALFactory
{
    public class DBSessionFactory
    {
        public static IDBSession CreatDBSession()
        {
            IDBSession DBsession = (IDBSession)CallContext.GetData("DBsession");
            if (DBsession == null)
            {
                DBsession = new DBsession();
                CallContext.SetData("DBsession",DBsession);
            }
            return DBsession;
        }
    }
}
