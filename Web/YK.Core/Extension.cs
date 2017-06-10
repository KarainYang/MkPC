using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

using YK.Model;

namespace YK.Core
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    internal static class Extension
    {
        public static Guid ToGuid(this object obj)
        {
            if (obj != null)
            {
                return new Guid(obj.ToStr());
            }
            return Guid.NewGuid();
        }
        public static object ToNullable(this object obj)
        {
            if (obj != null && obj.ToStr()!="")
            {
                return Convert.ChangeType(obj.ToStr(), obj.GetType(), null);
            }
            return null;
        }
        


        /// <summary>
        /// 转换成字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ToStr(this object obj)
        {
            string str = "";
            if (obj != null)
            {
                str = obj.ToString();
            }
            return str;          
        }

        /// <summary>
        /// 转换整数
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static int ToInt(this object obj)
        {
            int num = 0;
            if (obj != null)
            {
                if(int.TryParse(obj.ToStr(),out num)){}
            }
            return num;
        }

        /// <summary>
        /// 转换整数，对象，默认值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultVal">默认值</param>
        /// <returns></returns>
        public static int ToInt(this object obj,int defaultVal)
        {
            int num = defaultVal;
            if (obj != null)
            {
                if (int.TryParse(obj.ToStr(), out num)) { }
            }
            return num;
        }


        /// <summary>
        /// 转换十进制
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object obj)
        {
            return ToDecimal(obj,-1);
        }

        /// <summary>
        /// 转换十进制,并设置小数点长度
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="length">小数点长度</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object obj,int length)
        {
            decimal dec = 0.00m;
            if (obj != null)
            {
                if (decimal.TryParse(obj.ToString(), out dec))
                {
                    if(length!=-1)
                    {
                        dec = Math.Round(dec, length);
                    }
                }
            }
            return dec;
        }

        /// <summary>
        /// 转换单精度浮点数字（float）
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static float ToFloat(this object obj)
        {
            return ToFloat(obj,-1);
        }

        /// <summary>
        /// 转换单精度浮点数字（float）,(限制小数点长度)
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="length">小数点长度</param>
        /// <returns></returns>
        public static float ToFloat(this object obj,int length)
        {
            float f = 0.00f;
            if (obj != null)
            {
                if (float.TryParse(obj.ToString(), out f))
                {
                    if(length!=-1)
                    {
                        f =Convert.ToSingle(Math.Round(Convert.ToDouble(f),length));
                    }
                }
            }
            return f;
        }

        /// <summary>
        /// 转换双精度浮点数字（double）
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static double ToDouble(this object obj)
        {
            return ToDouble(obj,-1);
        }

        /// <summary>
        /// 转换双精度浮点数字（double）,(限制小数点长度)
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="length">小数点长度</param>
        /// <returns></returns>
        public static double ToDouble(this object obj,int length)
        {
            double d = 0.00;
            if (obj != null)
            {
                if (double.TryParse(obj.ToString(), out d))
                {
                    if(length!=-1)
                    {
                        d = Math.Round(d,length);
                    }
                }
            }
            return d;
        }

        /// <summary>
        /// 转换bool值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static bool ToBool(this object obj)
        {            
            return obj.ToStr().ToLower()=="false"?false:true;
        }

        /// <summary>
        /// 转换bool值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static bool ToIntToBool(this object obj)
        {
            return obj.ToStr().ToLower() == "0" ? true : false;
        }

        /// <summary>
        /// 转换bool值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ToBoolStr(this object obj)
        {
            return obj.ToStr().ToLower() == "true" ? "是" : "否";
        }

        /// <summary>
        /// 转换bool值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object obj)
        {
            DateTime nowDate;
            if (DateTime.TryParse(obj.ToStr(), out nowDate)) { };

            if (nowDate == DateTime.MinValue)
            {
                nowDate = DateTime.Now;
            }
            return nowDate;
        }

    }
}
