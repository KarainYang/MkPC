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

public partial class Admin_AdminModel_System_AdverCategoryView : BasePage
{
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
        int id = CommonClass.ReturnRequestInt("id", 0);        
        if(id>0)
        {
            List<Expression> express = new List<Expression>();
            express.Add(new Expression("ID", "=", id.ToStr()));
            TB_System_AdverCategory model = SystemService.AdverCategoryService.Get(express);
            if(model!=null)
            {
                TbName.Text = model.Name;
                TbOrderBy.Text = model.OrderBy.ToStr();
                ViewState["id"] = model.ID;
            }            
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_System_AdverCategory model = new TB_System_AdverCategory();
        if (ViewState["id"] != null)
        {
            model = SystemService.AdverCategoryService.Get(ViewState["id"]);
        }
        model.Name = TbName.Text.Trim();
        model.OrderBy = TbOrderBy.Text.ToInt();
        model.Creater = AdminUserName;
        model.AddDate = DateTime.Now;
        ISystem_AdverCategory adverCategory = SystemService.AdverCategoryService;
        if (ViewState["id"] == null)
        {
            if (adverCategory.Insert(model) == 1)
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
            if (adverCategory.Update(model) == 1)
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
