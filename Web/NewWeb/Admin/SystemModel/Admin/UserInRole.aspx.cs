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

using YK.Model;
using YK.Service;
using YK.Common;

public partial class Admin_AdminModel_User_UserInRole : BasePage
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
        int id = CommonClass.ReturnRequestInt("id",0);
        ViewState["id"] = id;        
        CheckBoxRolesList.DataSource = AdminService.RoleService.Search().OrderBy(r=>r.OrderBy);
        CheckBoxRolesList.DataTextField = "RoleName";
        CheckBoxRolesList.DataValueField = "ID";
        CheckBoxRolesList.DataBind();
        //获取管理员所有角色
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("AdminUserID", "=", id.ToStr()));
        List<TB_Admin_UserInRole> list = AdminService.UserInRoleService.Search(express);
        //选取管理员角色
        foreach(ListItem li in CheckBoxRolesList.Items)
        {
            foreach(TB_Admin_UserInRole model in list)
            {
                if (li.Value == model.RoleID.ToStr())
                {
                    li.Selected = true;
                }
            }
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Admin_UserInRole model = new TB_Admin_UserInRole();
        model.AdminUserID = CommonClass.ReturnRequestInt("id", 0);

        List<int> RoleList = new List<int>();
        //获取管理员所有角色
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("AdminUserID", "=", model.AdminUserID.ToStr()));
        int count=0;
        List<TB_Admin_UserInRole> list = AdminService.UserInRoleService.Search(1000, 1, express,"", ref count);
        foreach (TB_Admin_UserInRole model2 in list)
        {
            //加入泛型数组中
            RoleList.Add(model2.RoleID);
        }

        foreach(ListItem li in CheckBoxRolesList.Items)
        {
            if (li.Selected == true)
            {
                //如果不包含就添加，如果包含则不添加
                if (!RoleList.Contains(li.Value.ToInt()))
                {
                    model.RoleID = li.Value.ToInt();
                    AdminService.UserInRoleService.Insert(model);
                }
            }
            else
            {
                List<Expression> express2 = new List<Expression>();
                express2.Add(new Expression("AdminUserID", "=", model.AdminUserID.ToStr()));
                express2.Add(new Expression("RoleID", "=", li.Value));

                //如果不选择，可能管理员角色列表中存在，就将其删除
                AdminService.UserInRoleService.Delete(express2);
            }
        }
           
        MessageDiv.InnerHtml = CommonClass.Reload("数据保存成功");
    }
}
