using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace YK.Core
{
    /// <summary>
    /// 链接帮助
    /// </summary>
    public class ConnectionHelper
    {
        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <returns></returns>
        public  string GetConnectionString()
        {
            var dic = GetConnectionDic();
            if (dic != null)
            {
                return dic["connectionstring"];
            }
            return null;
        }
        /// <summary>
        /// 获取当前租户链接字典
        /// </summary>
        /// <returns></returns>
        public  Dictionary<string, string> GetConnectionDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string orgCode = HttpContext.Current.Request["orgCode"];
            if (string.IsNullOrEmpty(orgCode))
            {
                var adminInfo = HttpContext.Current.Request.Cookies["AdminInfo"];
                if (adminInfo != null && adminInfo["OrgCode"] != null)
                {
                    orgCode = adminInfo["OrgCode"].ToStr();
                }
            }
            if (!string.IsNullOrEmpty(orgCode))
            {
                //文件路径
                string fileUrl = HttpContext.Current.Server.MapPath("~/App_Data/Organization.xml");
                DataSet ds = new DataSet();
                ds.ReadXml(fileUrl);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["code"].ToStr().ToLower() == orgCode.ToLower())
                    {
                        dic.Add("connectionstring", dr["connectionstring"].ToStr());
                        dic.Add("provider", dr["provider"].ToStr());
                        return dic;
                    }
                }
            }
            else
            {
                dic.Add("connectionstring", ConfigurationManager.ConnectionStrings["SqlConn"].ToStr());
                dic.Add("provider", ConfigurationManager.ConnectionStrings["SqlConn"].ProviderName);
                return dic;
            }
            return null;
        }

        /// <summary>
        /// 获取租户链接字典
        /// </summary>
        /// <returns></returns>
        public  List<Dictionary<string, string>> GetOrgConnDic()
        {
            List<Dictionary<string, string>> dicList = new List<Dictionary<string, string>>();

            //文件路径
            string fileUrl = HttpContext.Current.Server.MapPath("~/App_Data/Organization.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(fileUrl);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("connectionstring", dr["connectionstring"].ToStr());
                dic.Add("provider", dr["provider"].ToStr());
                dic.Add("code", dr["code"].ToStr());
                dic.Add("name", dr["name"].ToStr());
                dicList.Add(dic);
            }
            return dicList;
        }
    }
}
