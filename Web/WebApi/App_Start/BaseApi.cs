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
    /// Api基类
    /// </summary>
    public class BaseApi : System.Web.Mvc.Controller
    {
        HttpContext context = System.Web.HttpContext.Current;

        /// <summary>
        /// 员工对象
        /// </summary>
        public TB_Member_Members member = new TB_Member_Members();

        public BaseApi()
        {
            //身份认证
            IdentityAuth();
        }

        /// <summary>
        /// 核查管理员
        /// </summary>
        public void IdentityAuth()
        {
            string access_token = Request["access_token"].ToStr();
            if (string.IsNullOrEmpty(access_token))
            {
                Response.Write(AjaxReponse(false, "身份认证失败", null));
            }
            else {
               string memberName = access_token.ToDecryptStr();
               List<Expression> express = new List<Expression>();
               express.Add(new Expression("MemberName", "=", memberName));
               var mem = MemberService.MembersService.Get(express);
               if (mem.ID > 0)
               {
                   member = mem;
               }
               else {
                   Response.Write(AjaxReponse(false, "身份认证失败", null));
               }
            }
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
