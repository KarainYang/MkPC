using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using YK.Service;
using YK.Common;
using YK.Model;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "yankun", DateTime.Now, DateTime.Now.AddDays(1), false, "1");
        //string strE = FormsAuthentication.Encrypt(ticket);
        //HttpCookie cookieAuthen = new HttpCookie(FormsAuthentication.FormsCookieName);
        //cookieAuthen.Value = strE;
        //Response.Cookies.Add(cookieAuthen);

        HttpCookie cookieInfo = new HttpCookie("AdminInfo");
        cookieInfo.Values["OrgCode"] = "default";
        cookieInfo.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(cookieInfo);


        string UserName = TbUserName.Value.Trim();
        string Userpwd = TbUserPwd.Value.ToEncryptStr();

        if (Session["VerifyCode"] == null)
        {
            LbTooltip.Text = "验证失效，请点击重新获取！";
            return;
        }
        if (Session["VerifyCode"].ToStr() != TBYanZheng.Value.Trim())
        {
            LbTooltip.Text = "验证码错误，请重新输入！";
            return;
        }

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("UserName", "=", UserName));
        express.Add(new Expression("Userpwd", "=", Userpwd));
        TB_Admin_User model = AdminService.UserService.Get(express);
        if (model.ID > 0)
        {
            HttpCookie cookie = new HttpCookie("AdminInfo");
            cookie.Values["ID"] = model.ID.ToStr();
            cookie.Values["UserName"] = UserName;
            cookie.Values["UserPwd"] = Userpwd;

            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);

            //操作日志
            AdminService.LogService.Insert(OperationType.用户操作, model.ID, "用户" + model.UserName + "后台登录", UserName);

            Response.Redirect("Default.aspx");
        }
        else
        {
            LbTooltip.Text = "用户名或密码错误！";
        }
    }
}
