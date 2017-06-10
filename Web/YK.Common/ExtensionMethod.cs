using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

using YK.Model;
using YK.Core;
using System.Data;
using System.Reflection;

namespace YK.Common
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExtensionMethod
    {
        /// <summary>
        /// In
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool In(this object obj, List<object> array)
        {
            return true;
        }
        /// <summary>
        /// NotIn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool NotIn(this object obj, List<object> array)
        {
            return true;
        }
        /// <summary>
        /// Like
        /// </summary>
        /// <param name="str"></param>
        /// <param name="likeStr"></param>
        /// <returns></returns>
        public static bool Like(this string str, string likeStr)
        {
            return true;
        }
        /// <summary>
        /// NotLike
        /// </summary>
        /// <param name="str"></param>
        /// <param name="likeStr"></param>
        /// <returns></returns>
        public static bool NotLike(this string str, string likeStr)
        {
            return true;
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
        /// 是否推荐
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ToIsVouch(this object obj)
        {
            string str = "";
            if (obj != null)
            {
                str = obj.ToStr().ToLower() == "false" ? "不推荐" : "推荐";
            }
            return str;
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ToIsHidden(this object obj)
        {
            string str = "";
            if (obj != null)
            {
                str = obj.ToStr().ToLower() == "false" ? "不隐藏" : "隐藏";
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

        /// <summary>
        /// 截取object类型的字符串，主要是那些为null的数据进行处理
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string SubstringStr(this object obj, int length)
        {
            string str = "";
            if (obj!=null)
            {
                str=obj.ToString();
                if(str.Length>=length)
                {
                    str = str.Substring(0,length);
                }
            }
            return str;
        }

        #region 加解密字符串

        const string KEY_64 = "VavicApp";//注意了，是8个字符，64位
        const string IV_64 = "VavicApp";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="obj">加密数据</param>
        /// <returns></returns>
        public static string ToEncryptStr(this object obj)
        {
            string data = obj.ToStr();
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="obj">解密数据</param>
        /// <returns></returns>
        public static string ToDecryptStr(this object obj)
        {
            //转换成字符串
            string data = obj.ToStr();
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }

        #endregion

        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="htmlString">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string ClearHTML(this object htmlString)
        {
            string[] aryReg ={   
                      @"<script[^>]*?>.*?</script>",       
                      @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",   
                      @"([\r\n])[\s]+",   
                      @"&(quot|#34);",   
                      @"&(amp|#38);",   
                      @"&(lt|#60);",   
                      @"&(gt|#62);",     
                      @"&(nbsp|#160);",     
                      @"&(iexcl|#161);",   
                      @"&(cent|#162);",   
                      @"&(pound|#163);",   
                      @"&(copy|#169);",   
                      @"&#(\d+);",   
                      @"-->",   
                      @"<!--.*\n"   
                    };

            string[] aryRep = { "", "", "", "\"", "&", "<", ">", "   ", "\xa1", "\xa2", "\xa3", "\xa9", "", "\r\n", "" };

            string strOutput = htmlString.ToStr();

            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryRep[i]);
            }

            string[] olds = { "&amp;", "amp;", "amp", "rdquo;", "ldquo;", "&quot;", "\"", "&", "<", ">", "\r\n" };

            foreach (string old in olds)
            {
                strOutput = strOutput.Replace(old, "");
            }

            return strOutput;
        }

        /// <summary>
        /// 获取实体对象
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <param name="obj">值</param>
        /// <returns></returns>
        public static TEntity GetEntity<TEntity>(this object obj) where TEntity:new()
        {
            return Core.Core<TEntity>.CoreTemplate.Get(obj);
        }

        /// <summary>
        /// 获取实体对象列表
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <param name="obj">值</param>
        /// <param name="fieldName">字段名称</param>
        /// <returns></returns>
        public static TEntity GetEntity<TEntity>(this object obj,string fieldName) where TEntity : new()
        {

            List<Expression> express = new List<Expression>();
            express.Add(new Expression(fieldName,"=",obj.ToStr()));
            return Core.Core<TEntity>.CoreTemplate.Get(express);
        }

        /// <summary>
        /// 获取实体对象列表
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <param name="obj">值</param>
        /// <param name="fieldName">字段名称</param>
        /// <returns></returns>
        public static List<TEntity> GetEntityList<TEntity>(this object obj, string fieldName) where TEntity : new()
        {
            List<Expression> express = new List<Expression>();
            express.Add(new Expression(fieldName, "=", obj.ToStr()));
            return Core.Core<TEntity>.CoreTemplate.Search(express);
        }

        /// <summary>
        /// 同步java加密方式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SynchroJavaEncryptStr(this object obj)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(obj.ToStr()));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToStr();

            #region java加密方式
            //import java.security.MessageDigest;
            //public static  String compute(String inStr) {
            //        MessageDigest md5=null;
            //        try {
            //            md5 = MessageDigest.getInstance("MD5");
            //        } catch (Exception e) {
            //            System.out.println(e.toString());
            //            e.printStackTrace();
            //            return "";
            //        }
            //        char[] charArray = inStr.toCharArray();
            //        byte[] byteArray = new byte[charArray.length];

            //        for (int i = 0; i < charArray.length; i++)
            //            byteArray[i] = (byte) charArray[i];

            //        byte[] md5Bytes = md5.digest(byteArray);

            //        StringBuffer hexValue = new StringBuffer();

            //        for (int i = 0; i < md5Bytes.length; i++) {
            //            int val = ((int) md5Bytes[i]) & 0xff;
            //            if (val < 16)
            //                hexValue.append("0");
            //            hexValue.append(Integer.toHexString(val));
            //        }

            //        return hexValue.toString();
            //    } 
            #endregion
        }

        /// <summary>
        /// 将数据表转换为实体列表
        /// </summary>
        /// <returns></returns>
        public static List<TEntity> ToEntityList<TEntity>(this DataTable dt)
        {
            List<TEntity> list = new List<TEntity>();
            foreach (DataRow dr in dt.Rows)
            {
                //实体
                TEntity entity = System.Activator.CreateInstance<TEntity>();
                //创建列
                foreach (PropertyInfo prop in entity.GetType().GetProperties())
                {
                    if (dt.Columns.Contains(prop.Name))
                    {
                        prop.SetValue(entity, dr[prop.Name], null);
                    }
                }
                list.Add(entity);
            }
            return list;
        }
    }
}
