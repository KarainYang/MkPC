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
using System.Xml.Linq;
using System.Collections.Generic;

using YK.Model;
using YK.Service;
using YK.Common;

public partial class member_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        
        if (Session["MemberVerifyCode"]==null)
        {
            LbCode.Text = "验证码为空，请重新获取";
            LbCode.CssClass = "tips ared";
            return;
        }
        string verifyCode=Session["MemberVerifyCode"].ToStr();

        if (verifyCode != TbVerifyCode.Text.Trim())
        {
            LbCode.Text = "验证码错误，请重新输入";
            LbCode.CssClass = "tips ared";
            return;
        }

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("MemberName", "=", TbMemberName.Text.Trim()));
        TB_Member_Members model = MemberService.MembersService.Get(express);

        if (model.ID > 0)
        {
            LbTooltip.Text = "当前用户已存在，请重新输入";
            return;
        }

        TB_Member_Members member = new TB_Member_Members();
        member.MemberName = TbMemberName.Text.TrimEnd();
        member.MemberPwd = TbMemberPwd.Text.ToEncryptStr();
        member.Email = TbEmail.Text.TrimEnd();
        member.LastLoginTime = DateTime.Now;
        member.Birthday = DateTime.Now;

        if (MemberService.MembersService.Insert(member) == 1)
        {
            HttpCookie cookie = new HttpCookie("MemberInfo");
            cookie.Values["ID"] = member.ID.ToStr();
            cookie.Values["MemberName"] = member.MemberName;
            cookie.Values["MemberPwd"] = member.MemberPwd;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);

            Response.Redirect("Success.aspx?userName="+TbMemberName.Text);
        }
    }
}
