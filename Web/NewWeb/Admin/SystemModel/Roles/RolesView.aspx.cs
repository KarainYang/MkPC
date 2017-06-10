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

public partial class Admin_AdminModel_Roles_RolesView : BasePage
{
    public int classID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadDataBind();            
        }       
    }

    //加载
    public void LoadDataBind()
    {
        TB_Admin_Roles model = new TB_Admin_Roles();
        int id = CommonClass.ReturnRequestInt("id", 0);        
        if(id>0)
        {
            model = AdminService.RoleService.Get(id);
            TbRoleName.Text = model.RoleName;
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Admin_Roles model = new TB_Admin_Roles();
        if (ViewState["id"] != null)
        {
            model = AdminService.RoleService.Get(ViewState["id"]);
        }
        model.RoleName = TbRoleName.Text.Trim();
        model.OrderBy = 0;
        model.Creater = AdminUserName;
        model.AddDate = DateTime.Now;
        IAdmin_Roles AdminRoles = AdminService.RoleService;
        if (ViewState["id"] == null)
        {
            if (AdminRoles.Insert(model) == 1)
            {
                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (AdminRoles.Update(model) == 1)
            {
                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }
        }
    }
}
