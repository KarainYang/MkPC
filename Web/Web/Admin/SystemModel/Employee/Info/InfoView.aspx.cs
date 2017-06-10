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
using YK.Interface;
using YK.Service;
using YK.Common;
using YK.Model.CRM;

public partial class Admin_SystemModel_Employee_Info_InfoView : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();
            LoadDataBind();
        }
    }
                   
    //加载
    public void LoadDataBind()
    {
        int ID = CommonClass.ReturnRequestInt("id", 0);
        if (ID > 0)
        {
            TB_Employee_Info model = EmployeeService.InfoService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                ViewState["id"] = model.ID;
                DDLCateogry.SelectedValue = model.CategoryID.ToStr();
                TbTitle.Text = model.Title;
                FckContent.Value = model.Remark;
            }
        }
    }

    public void BindCategory()
    {
        DDLCateogry.DataSource = EmployeeService.InfoCategoryService.Search();
        DDLCateogry.DataTextField = "Name";
        DDLCateogry.DataValueField = "ID";
        DDLCateogry.DataBind();
    }


    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Employee_Info model = new TB_Employee_Info();
        if (ViewState["id"] != null)
        {
            model = EmployeeService.InfoService.Get(ViewState["id"]);
        }
        model.CategoryID = DDLCateogry.SelectedValue.ToInt();
        model.Title =TbTitle.Text;
        model.Remark = FckContent.Value;
        model.Creater = AdminUserName;

        if (ViewState["id"] == null)
        {
            if (EmployeeService.InfoService.Insert(model) == 1)
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
            if (EmployeeService.InfoService.Update(model) == 1)
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
