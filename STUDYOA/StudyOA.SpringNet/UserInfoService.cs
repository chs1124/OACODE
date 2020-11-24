using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.SpringNet
{
    public class UserInfoService : IUserInfoService
    {
        public string UserName { get; set; }
        public Person person { get; set; }
        public string showMsg()
        {
            return "你大爷"+UserName+"年龄:"+person.Age;
        }
    }
}
