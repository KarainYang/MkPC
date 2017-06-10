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
using System.Linq;

using YK.Interface;
using YK.Model;
using YK.Service;

using YK.Common;

public partial class Admin_AdminModel_User_UserView : BasePage
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
        int id = CommonClass.ReturnRequestInt("id", 0);      
        if (id > 0)
        {
            TB_Admin_User model = AdminService.UserService.Get(id);

            TbUserName.Text = model.UserName;
            TbUserName.Enabled = false;
            TbUserPwd.Text = model.UserPwd;
            CheckBoxState.Checked = model.UserState == 1 ? true : false;
            ViewState["id"] = model.ID;

            TbUserName.Enabled = false;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {  
        TB_Admin_User model = new TB_Admin_User();
        if (ViewState["id"] != null)
        {
            model = AdminService.UserService.Get(ViewState["id"]);
        }
        else
        {
            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("UserName", "=", TbUserName.Text.TrimEnd()));
            if (AdminService.UserService.Search(expression).Count > 0)
            {
                MessageDiv.InnerHtml = CommonClass.Alert("此用户已存在，请重新输入");
                return;
            }
        }

        if (TbUserPwd.Text.TrimEnd().Length < 6)
        {
            MessageDiv.InnerHtml = CommonClass.Alert("密码长度必须大于6位数");
            return;
        }

        model.UserName = TbUserName.Text.Trim();
        model.UserPwd = TbUserPwd.Text.Trim().ToEncryptStr();
        model.UserState = CheckBoxState.Checked == false ? 0 : 1;
        model.LastLoginTime = DateTime.Now;
        model.Creater = AdminUserName;
        model.AddDate = DateTime.Now;
        IAdmin_User AdminUser = AdminService.UserService;
        if (ViewState["id"] == null)
        {
            if (AdminUser.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "添加用户" + model.UserName);

                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (AdminUser.Update(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "修改用户" + model.UserName);

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }
}
