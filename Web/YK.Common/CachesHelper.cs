using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace YK.Common
{
    /// <summary>
    /// 缓存处理类
    /// </summary>
    public class CachesHelper
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="CacheName">缓存名称</param>
        public static object GetCache(string CacheName)
        {
           return HttpContext.Current.Cache[CacheName];
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="CacheName">缓存名称</param>
        /// <param name="Value">缓存值</param>
        /// <param name="Hours">有效期（小时）</param>
        /// <returns></returns>
        public static void AddCache(string CacheName, object Value, int? Hours)
        {
            if (Hours.HasValue)
            {
                //HttpContext.Current.Cache.Insert("", "", new System.Web.Caching.CacheDependency("fileName"));
                HttpContext.Current.Cache.Insert(CacheName, Value, null, DateTime.Now.AddHours(Hours.Value), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Low, null);
            }
            else
            {
                HttpContext.Current.Cache.Insert(CacheName, Value);
            }
        }

        /// <summary>
        /// 移除指定缓存
        /// </summary>
        /// <param name="CacheName">缓存名称</param>
        /// <returns></returns>
        public static void RemoveCache(string CacheName)
        {
            HttpContext.Current.Cache.Remove(CacheName);
        }

        /// <summary>
        /// 移除所有缓存
        /// </summary>
        /// <returns></returns>
        public static void RemoveAllCache()
        {
            System.Collections.IDictionaryEnumerator enume = HttpContext.Current.Cache.GetEnumerator();
            while (enume.MoveNext())
            {
                HttpContext.Current.Cache.Remove(enume.Key.ToStr());
            }
        }
    }
}