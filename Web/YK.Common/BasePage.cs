using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using YK.Model;
using YK.Core;

namespace YK.Common
{
    /// <summary>
    /// 管理系统页面基类
    /// </summary>
    public class BasePage:System.Web.UI.Page
    {
        /// <summary>
        /// 获取目录路径
        /// </summary>
        public static string AppPath = HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";

        /// <summary>
        /// 管理员账号,员工名称
        /// </summary>
        public static string AdminUserName = "";
        /// <summary>
        /// 管理员编号
        /// </summary>
        public static int AdminUserID;
        /// <summary>
        /// 租户编码
        /// </summary>
        public static string OrgCode;


        public BasePage()
        {
            CheckAdminLogin();            
        }

        /// <summary>
        /// 核查管理员
        /// </summary>
        public static void CheckAdminLogin()
        {
            var adminInfo = HttpContext.Current.Request.Cookies["AdminInfo"];
            if ( adminInfo!= null)
            {
                if (adminInfo["UserName"] != null && adminInfo["UserPwd"] != null)
                {
                    string UserName = adminInfo["UserName"].ToString();
                    string UserPwd = adminInfo["UserPwd"].ToString();

                    AdminUserID = adminInfo["ID"].ToInt();
                    AdminUserName = UserName;
                    OrgCode = adminInfo["OrgCode"].ToStr(); 
                  
                    //List<Expression> express=new List<Expression>();
                    //express.Add(new Expression("UserName","=",UserName));
                    //express.Add(new Expression("UserPwd","=",UserPwd));
                    //TB_Admin_User entity= YK.Core.Core<TB_Admin_User>.CoreTemplate.Get(express);
                    //if (entity.ID==0)
                    //{
                    //    HttpContext.Current.Response.Redirect(AppPath + "Admin/Login.aspx");
                    //}
                    //AdminUserName = entity.UserName;
                    //AdminUserID = entity.ID;
                }
                else
                {
                    HttpContext.Current.Response.Redirect(AppPath + "Admin/Login.aspx");
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect(AppPath + "Admin/Login.aspx");
            }
        }
    }
}
