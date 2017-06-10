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

using YK.Service;
using YK.Model;
using YK.Common;

public partial class member_ChangePwd : MemberBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        LbOldPwd.Text = "";
        LbNewPwd.Text = "";
        LbConfirmPwd.Text = "";
        LbCode.Text = "";
        LbTooltip.Text = "";

        if (string.IsNullOrEmpty(TbOldPwd.Text))
        {
            LbOldPwd.Text = "您输入的旧密码有误，请重新输入";
            return;
        }

        if (string.IsNullOrEmpty(TbNewPwd.Text) || TbNewPwd.Text.Length < 6 || TbNewPwd.Text.Length > 20)
        {
            LbNewPwd.Text = "新密码不能为空，且密码必须是6-20位字符";
            return;
        }

        if (TbNewPwd.Text!=TbConfirmPwd.Text)
        {
            LbConfirmPwd.Text = "两次密码不一致";
            return;
        }

        if (Session["MemberVerifyCode"] == null)
        {
            LbCode.Text = "验证码为空，请重新获取";
            return;
        }

        string code = Session["MemberVerifyCode"].ToStr();

        if (code != TbVerifyCode.Text.Trim())
        {
            LbCode.Text = "验证码错误，请重新输入";
            return;
        }

       TB_Member_Members member= MemberService.MembersService.Get(MemberID);
       if(member.MemberPwd!=TbOldPwd.Text.ToEncryptStr())
       {
           LbOldPwd.Text = "您输入的旧密码有误，请重新输入";
           return;
       }

       member.MemberPwd = TbNewPwd.Text.ToEncryptStr();
       if (MemberService.MembersService.Update(member) == 1)
       ClientScript.RegisterStartupScript(this.GetType(), "tishi", " alert('密码修改成功,请重新登陆！ ');window.location='Login.aspx'",true);
    }
}
