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
using YK.Interface.Systems;
using YK.Model;
using YK.Service;
using YK.Model.Systems;
using YK.Common;

public partial class Admin_AdminModel_Organization_OrganizationView : BasePage
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
        string id = CommonClass.ReturnRequestStr("id");
        if (!string.IsNullOrEmpty(id))
        {
            TB_Sys_Organizations model = SysService.SysOrganizations.Get(id);

            TbName.Text = model.Name;
            TbCode.Text = model.Code;
            TbConnStr.Text = model.ConnectionString;
            CheckBoxState.Checked = model.State == 1 ? true : false;
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Sys_Organizations model = new TB_Sys_Organizations();
        if (ViewState["id"] != null)
        {
            model = SysService.SysOrganizations.Get(ViewState["id"]);
        }
        else
        {
            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("Code", "=", TbCode.Text.TrimEnd()));
            if (SysService.SysOrganizations.Search(expression).Count > 0)
            {
                MessageDiv.InnerHtml = CommonClass.Alert("此用户已存在，请重新输入");
                return;
            }
        }
        model.Name = TbName.Text.Trim();
        model.Code = TbCode.Text.Trim();
        model.ConnectionString = TbConnStr.Text;
        model.State = CheckBoxState.Checked == false ? 0 : 1;
        model.Creater = AdminUserName;
        model.CreatedOn = DateTime.Now;
        ISysOrganizations sysOrgService = SysService.SysOrganizations;
        if (ViewState["id"] == null)
        {
            if (sysOrgService.Insert(model) == 1)
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
            if (sysOrgService.Update(model) == 1)
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
