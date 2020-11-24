using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.Common
{
    public class SerializeHelper
    {
        /// <summary>
        /// 对数据进行序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeToString(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static T DeserializeToObject<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
