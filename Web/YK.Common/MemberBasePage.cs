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
    public class MemberBasePage : System.Web.UI.Page
    {

        /// <summary>
        /// 会员账号
        /// </summary>
        public static string MemberAccount = "";

        /// <summary>
        /// 会员编号
        /// </summary>
        public static int MemberID = 0;

        public MemberBasePage()
        {
            CheckMemberLogin();
        }

        /// <summary>
        /// 核查管理员
        /// </summary>
        public static void CheckMemberLogin()
        {
            if (HttpContext.Current.Request.Cookies["MemberInfo"] != null)
            {
                if (HttpContext.Current.Request.Cookies["MemberInfo"]["MemberName"] != null && HttpContext.Current.Request.Cookies["MemberInfo"]["MemberPwd"] != null)
                {
                    string UserName = HttpContext.Current.Request.Cookies["MemberInfo"]["MemberName"].ToString();
                    string UserPwd = HttpContext.Current.Request.Cookies["MemberInfo"]["MemberPwd"].ToString();

                    List<Expression> express = new List<Expression>();
                    express.Add(new Expression("MemberName", "=", UserName));
                    express.Add(new Expression("MemberPwd", "=", UserPwd));

                    TB_Member_Members entity = Core.Core<TB_Member_Members>.CoreTemplate.Get(express);
                    if (entity.ID == 0)
                    {
                        HttpContext.Current.Response.Redirect(CommonClass.AppPath + "Member/Login.aspx");
                    }
                    else
                    {
                        MemberAccount = entity.MemberName;
                        MemberID = entity.ID;
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect(CommonClass.AppPath + "Member/Login.aspx");
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect(CommonClass.AppPath + "Member/Login.aspx");
            }
        }
    }
}