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
using YK.Model;
using YK.Service;
using YK.Interface;
using YK.Common;

public partial class Admin_AdminModel_Member_MemberView : BasePage
{
    public int classID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind();
        }
    }

    //加载
    public void LoadDataBind()
    {
        TB_Member_Members model = new TB_Member_Members();
        int id = CommonClass.ReturnRequestInt("id", 0);        
        if ( id > 0)
        {
            model = MemberService.MembersService.Get(id);
            TbUserName.Text = model.MemberName;
            TbUserName.Enabled = false;
            TbUserPwd.Text = model.MemberPwd;
            TbMobile.Text = model.Mobile;
            TbEmail.Text = model.Email;
            TbRealName.Text = model.RealName;
            TbCity.Text = model.City;
            TbAge.Text = model.Age.ToStr();
            TbBirthday.Text = model.Birthday.ToShortDateString();
            PhotoUrl.Url = model.PhotoUrl;
            DDLSex.SelectedValue = model.Sex.ToStr();
            CheckBoxState.Checked = model.IsFreeze == 1 ? true : false;
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Member_Members model = new TB_Member_Members();
        if (ViewState["id"] != null)
        {
            model = MemberService.MembersService.Get(ViewState["id"]);
            model.MemberPwd = TbUserPwd.Text.Trim().ToEncryptStr();
        }
        model.MemberName = TbUserName.Text.Trim();        
        model.Mobile = TbMobile.Text;
        model.RealName = TbRealName.Text;
        model.Email = TbEmail.Text;
        model.Age = TbAge.Text.ToInt();
        model.City = TbCity.Text;
        model.Birthday = Convert.ToDateTime(TbBirthday.Text);
        model.PhotoUrl = PhotoUrl.Url;
        model.IsFreeze = CheckBoxState.Checked == false ? 0 : 1;
        model.LastLoginTime = DateTime.Now;

        IMember_Members members = MemberService.MembersService;
        if (ViewState["id"] == null)
        {
            if (members.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, AdminUserID, "添加会员" + model.MemberName);

                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (members.Update(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, AdminUserID, "修改会员" + model.MemberName);

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }
}
