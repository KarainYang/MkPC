using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

using System.Xml.Linq;
using YK.Model;
using YK.Service;
using YK.Common;

public partial class member_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["MemberVerifyCode"] == null)
        {
            LbCode.Text = "验证码为空，请重新获取";
            return;
        }

        string code=Session["MemberVerifyCode"].ToStr();
        if (code != TbVerifyCode.Text)
        {
            LbCode.Text = "验证码错误，请重新输入";
            return;
        }

        string MemberName = TbMemberName.Text.Trim();
        string MemberPwd = TbMemberPwd.Text.ToEncryptStr();

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("MemberName", "=", MemberName));
        express.Add(new Expression("MemberPwd", "=", MemberPwd));
        TB_Member_Members model = MemberService.MembersService.Get(express);

        if (model.ID>0)
        {
            HttpCookie cookie = new HttpCookie("MemberInfo");
            cookie.Values["ID"] = model.ID.ToString();
            cookie.Values["MemberName"] = MemberName;
            cookie.Values["MemberPwd"] = MemberPwd;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);

            Response.Redirect("Index.aspx");
        }
        else
        {
            LbTooltip.Text = "用户名或密码错误！";
        }
    }
}
