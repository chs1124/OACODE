using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOA.Common
{
    public class MemcachedHelper
    {

        private static readonly MemcachedClient mc =null;
        static MemcachedHelper()
        {
            string[] serverlist = { "127.0.0.1:11211", "172.0.0.1:11211" };
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();
            // 获得客户端实例
             mc = new MemcachedClient();
            mc.EnableCompression = false;
        }

        /// <summary>
        /// 存储数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool set(string key, object value, DateTime time)
        {
            return mc.Set(key, value, time);
        }
        /// <summary>
        /// 取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object get(string key)
        {
           return  mc.Get(key);
        }
        public static bool delete(string key)
        {
            if (mc.KeyExists(key))
            {
               return mc.Delete(key);
            }
            return false;
        }
    }
}
