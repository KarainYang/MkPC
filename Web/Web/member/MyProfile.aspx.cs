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

public partial class member_MyProfile : MemberBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadDataBind();
        }
    }

    public void LoadDataBind()
    {
        TB_Member_Members member = new TB_Member_Members();
        member = MemberService.MembersService.Get(MemberID);
        TbRealName.Text = member.RealName;
        RadioBtnSex.SelectedValue = member.Sex.ToStr();
        TbEmail.Text = member.Email;
        TbMobile.Text = member.Mobile;
        HeaderImg.Url = member.PhotoUrl;
        TbBirthday.Text = member.Birthday.ToShortDateString();
        TbAddress.Text = member.Address;
        Address.Value = member.City;
        TbPosted.Text = member.PostCode;
        TbQQ.Text = member.QQ;
        if (!string.IsNullOrEmpty(member.Phone))
        {
            TbPhone.Text = member.Phone.Split('-')[0];
            TbPhone2.Text = member.Phone.Split('-')[1];
            TbPhone3.Text = member.Phone.Split('-')[2];   
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        TB_Member_Members member = new TB_Member_Members();
        member = MemberService.MembersService.Get(MemberID);        
        member.RealName = TbRealName.Text.Trim();
        member.Sex = RadioBtnSex.SelectedValue.ToInt();
        member.QQ = TbQQ.Text.Trim();
        member.Email = TbEmail.Text;
        member.PostCode = TbPosted.Text.Trim();
        member.PhotoUrl = HeaderImg.Url;
        member.Mobile = TbMobile.Text.Trim();
        member.Birthday = TbBirthday.Text.ToDateTime();
        member.Address = TbAddress.Text.Trim();
        member.City = Address.Value;
        member.Phone = TbPhone.Text.Trim() + "-" + TbPhone2.Text.Trim() + "-" + TbPhone3.Text.Trim();
        MemberService.MembersService.Update(member);
    }
}
