using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YK.Service;
using YK.Model;
using YK.Common;

namespace MobileWeb.Controllers.Api
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 登录
        /// </summary>
        public void Login()
        {
            string account = Request["account"].ToStr().Trim();
            string password = Request["password"].ToStr().Trim().ToEncryptStr();
            var member = MemberService.MembersService.Get(m => m.MemberName == account && m.MemberPwd == password);
            if (member != null)
            {
                string result = CommonClass.AjaxReponse(true, "登录成功", new
                {
                    member = member,
                    access_token = member.MemberPwd.ToEncryptStr()
                });
                System.Web.HttpContext.Current.Response.Write(result);
            }
            else {
                string result = CommonClass.AjaxReponse(false, "登录失败", null);
                System.Web.HttpContext.Current.Response.Write(result);
            }
        }
    }
}
