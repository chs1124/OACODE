using StudyOA.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.DALFactory
{
    public partial class AbstractFactory
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];
        //public static IUserInfoDal CreateUserInfoDal()
        //{
        //    string fullClassName = NameSpace + ".UserInfoDal";
        //    return CreateInstance(fullClassName) as IUserInfoDal;
            
        //}
        private static object CreateInstance(string className)
        {
            var assambly = Assembly.Load(AssemblyPath);
            return assambly.CreateInstance(className);
        }

    }
}
