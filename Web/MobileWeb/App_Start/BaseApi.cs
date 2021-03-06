using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

using YK.Common;
using YK.Model;
using YK.Service;
using YK.Cache;

namespace MobileWeb
{
    /// <summary>
    /// Api基类
    /// </summary>
    public class BaseApi : System.Web.Mvc.Controller
    {
        HttpContext context = System.Web.HttpContext.Current;

        /// <summary>
        /// 员工对象
        /// </summary>
        public TB_Member_Members member = new TB_Member_Members();

        /// <summary>
        /// 是否认证通过
        /// </summary>
        public bool isAuth = false;

        public BaseApi()
        {
            //身份认证
            IdentityAuth();
        }

        /// <summary>
        /// 核查管理员
        /// 此处可以适用两种场景：1app身份认证，2网页访问
        /// </summary>
        public void IdentityAuth()
        {
            string access_token = System.Web.HttpContext.Current.Request["access_token"].ToStr();
            //如果参数有access_token,已参数为准
            if (string.IsNullOrEmpty(access_token))
            {
                var memInfo = context.Request.Cookies["MemInfo"];
                if (memInfo != null)
                {
                    access_token = memInfo["access_token"];
                }
            }
            if (string.IsNullOrEmpty(access_token))
            {
                //游客登录
                TouristLogin();
                //System.Web.HttpContext.Current.Response.Write(CommonClass.AjaxReponse(false, "身份认证失败", null));
            }
            else {
                string memberName = access_token.ToDecryptStr();
                //先取缓存，如果不存在则取数据库
                var cacheEntity = BusinessCachesHelper<TB_Member_Members>.GetEntityCache(memberName);
                if (cacheEntity == null)
                {
                    List<Expression> express = new List<Expression>();
                    express.Add(new Expression("MemberName", "=", memberName));
                    member = MemberService.MembersService.Get(express);
                }
                else {
                    member = cacheEntity;
                }
                //是否存在该用户
                if (member.ID > 0)
                {
                    isAuth = true;
                    BusinessCachesHelper<TB_Member_Members>.AddEntityCache(memberName, member);

                    HttpCookie cookieInfo = new HttpCookie("MemInfo");
                    cookieInfo.Values["access_token"] = member.MemberName.ToEncryptStr();
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookieInfo);
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write(CommonClass.AjaxReponse(false, "身份认证失败", null));
                }
            }
        }

        /// <summary>
        /// 游客登录
        /// </summary>
        public void TouristLogin()
        {
            Random random = new Random();
            member = new TB_Member_Members();
            member.MemberName = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(1000, 9999);
            member.MemberPwd = "123456".ToEncryptStr();
            member.ChengNi = "游客";
            member.LastLoginTime = DateTime.Now;
            member.AddDate = DateTime.Now;
            MemberService.MembersService.Insert(member, true);

            HttpCookie cookieInfo = new HttpCookie("MemInfo");
            cookieInfo.Values["access_token"] = member.MemberName.ToEncryptStr();
            System.Web.HttpContext.Current.Response.Cookies.Add(cookieInfo);
        }
        
    }
}
