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
using YK.Model;
using YK.Service;
using YK.Interface;
using YK.Common;

public partial class Admin_AdminModel_User_UpdatePwd : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        var entity = AdminService.UserService.Get(AdminUserID);

        if(TbOldPwd.Text.TrimEnd().ToEncryptStr()!=entity.UserPwd)
        {
            MessageDiv.InnerHtml = CommonClass.Alert("当前密码输入错误");
            return;
        }

        if (TbUserPwd.Text.TrimEnd().Length < 6)
        {
            MessageDiv.InnerHtml = CommonClass.Alert("密码长度必须大于6位数");
            return;
        }
        
        entity.UserPwd = TbUserPwd.Text.Trim().ToEncryptStr();
        if (AdminService.UserService.Update(entity) > 0)
        {
            MessageDiv.InnerHtml = CommonClass.Alert("密码修改成功");
        }
        else
        {
            MessageDiv.InnerHtml = CommonClass.Alert("密码修改失败");
        }
    }
}
