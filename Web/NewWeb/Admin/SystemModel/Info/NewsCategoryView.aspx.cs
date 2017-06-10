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

public partial class Admin_SystemModel_Info_NewsCategoryView : BasePage
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
            TB_Info_NewsCategory model = InfoService.NewsCategoryService.Get(id);
            TbName.Text = model.Name;
            TbCode.Text = model.Code;
            TbOrderBy.Text = model.OrderBy.ToStr();
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Info_NewsCategory model = new TB_Info_NewsCategory();
        if (ViewState["id"] != null)
        {
            model = InfoService.NewsCategoryService.Get(ViewState["id"]);
        }
        model.Name = TbName.Text;
        model.Code = TbCode.Text;
        model.OrderBy = TbOrderBy.Text.ToInt();
        model.Creater = AdminUserName;

        IInfo_NewsCategory NewsCategory = InfoService.NewsCategoryService;
        if (ViewState["id"] == null)
        {
            model.AddDate = DateTime.Now;
            if (NewsCategory.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "添加新闻类别" + model.Name);

                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (NewsCategory.Update(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "修改新闻类别" + model.Name);

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }
}
