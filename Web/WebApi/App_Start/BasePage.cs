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

namespace CRMMvc
{
    /// <summary>
    /// 管理系统页面基类
    /// </summary>
    public class BasePage : System.Web.Mvc.Controller
    {
        HttpContext context = System.Web.HttpContext.Current;

        /// <summary>
        /// 员工对象
        /// </summary>
        public TB_Member_Members member = new TB_Member_Members();

        /// <summary>
        /// 租户编码
        /// </summary>
        public string OrgCode;

        public BasePage()
        {
            if (!context.Request.Url.ToStr().ToLower().Contains("login"))
            {
                CheckAdminLogin();
            }
        }

        /// <summary>
        /// 核查管理员
        /// </summary>
        public void CheckAdminLogin()
        {
            var memInfo = context.Request.Cookies["MemInfo"];
            if (memInfo != null)
            {
                if (memInfo["Account"] != null && memInfo["Password"] != null)
                {

                    member.ID = memInfo["ID"].ToInt();
                    member.MemberName = context.Server.UrlDecode(memInfo["Account"].ToStr());
                    member.MemberPwd = context.Server.UrlDecode(memInfo["Password"].ToStr());
                    OrgCode = memInfo["OrgCode"].ToStr();
                }
            }
            else { 
                Login("default", "", "");
            }
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        [HttpPost]
        public string Login(string orgCode, string userName, string userPwd)
        {
            HttpCookie cookieInfo = new HttpCookie("MemInfo");
            cookieInfo.Values["OrgCode"] = orgCode;            

            List<Expression> express = new List<Expression>();
            express.Add(new Expression("MemberName", "=", userName));
            express.Add(new Expression("MemberPwd", "=", userPwd.ToEncryptStr()));

            var mem = MemberService.MembersService.Get(express);
            if (mem.ID > 0)
            {
                cookieInfo.Values["ID"] = mem.ID.ToStr();
                cookieInfo.Values["Account"] = mem.MemberName;
                cookieInfo.Values["Password"] = mem.MemberPwd;
                cookieInfo.Values["ChengNi"] = Server.UrlEncode(mem.ChengNi);
                Response.Cookies.Add(cookieInfo);

                return "1";
            }
            else
            {
                Random random = new Random();                
                mem = new TB_Member_Members();
                mem.MemberName = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(1000, 9999);
                mem.MemberPwd = "123456".ToEncryptStr();
                mem.ChengNi = "游客";
                mem.LastLoginTime = DateTime.Now;
                mem.AddDate = DateTime.Now;
                MemberService.MembersService.Insert(mem,true);

                cookieInfo.Values["ID"] = mem.ID.ToStr();
                cookieInfo.Values["Account"] = mem.MemberName;
                cookieInfo.Values["Password"] = mem.MemberPwd;
                cookieInfo.Values["ChengNi"] = System.Web.HttpContext.Current.Server.UrlEncode(mem.ChengNi);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookieInfo);

                return "0";
            }
        }
        /// <summary>
        /// 退出登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            HttpCookie cookie = new HttpCookie("MemInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return Redirect(Url.Action("Login", "Office"));
        }

        /// <summary>
        /// ajax输出
        /// </summary>
        /// <returns></returns>
        public string AjaxReponse(bool isSuccess,string message, object data)
        {
            var result = new
            {
                isSuccess = isSuccess,
                message = message,
                data = data
            };
            return JsonHelper.Serialize(result);
        }
    }
}
