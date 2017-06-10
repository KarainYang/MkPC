using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace YK.Common
{
    /// <summary>
    /// Cookie处理类
    /// </summary>
    public class CookiesHelper
    {
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="ParaNames">参数列表</param>
        /// <param name="Values">值列表</param>
        /// <returns></returns>
        public static void AddCookie(string CookieName, string[] paraNames, string[] Values, int? Hours)
        {
            HttpCookie cookie = new HttpCookie(CookieName);
            int i = 0;
            foreach (string name in paraNames)
            {
                cookie[name] = Values[i];
                i++;
            }
            if (Hours.HasValue)
            {
                cookie.Expires = DateTime.Now.AddHours(Hours.Value);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="Name">Cookie名称</param>
        /// <param name="ParaNames">参数列表</param>
        /// <param name="Values">值列表</param>
        public static void AddCookie(string Name, string[] ParaNames, string[] Values)
        {
            AddCookie(Name, ParaNames, Values, 0);
        }

        /// <summary>
        /// 移除指定Cookie
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <returns></returns>
        public static void RemoveCookie(string CookieName)
        {
            HttpContext.Current.Response.Cookies.Remove(CookieName);
        }

        /// <summary>
        /// 移除所有Cookie
        /// </summary>
        /// <returns></returns>
        public static void RemoveCookie()
        {
            HttpContext.Current.Response.Cookies.Clear();
        }
    }
}