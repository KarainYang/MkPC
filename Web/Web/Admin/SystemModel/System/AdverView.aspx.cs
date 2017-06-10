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

public partial class Admin_AdminModel_System_AdverView : BasePage
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
         DDLModel.DataSource= SystemService.AdverCategoryService.Search();
         DDLModel.DataTextField = "Name";
         DDLModel.DataValueField = "ID";
         DDLModel.DataBind();

        int id = CommonClass.ReturnRequestInt("id", 0);        
        if(id>0)
        {
            TB_System_Adver model = SystemService.AdverService.Get(id);
            if(model!=null)
            {
                DDLModel.SelectedValue = model.CategoryId.ToStr();
                TbName.Text = model.Name;
                TbCode.Text = model.Code;
                DDLAdverType.SelectedValue = model.AdverType.ToStr();
                TbWidth.Text = model.PicWidth;
                TbHeight.Text = model.PicHeight;
                TbRemark.Text = model.Remark;
                TbOrderBy.Text = model.OrderBy.ToStr();
                ViewState["id"] = model.ID;
            }            
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("Code", "=", TbCode.Text.TrimEnd()));        

        TB_System_Adver model = new TB_System_Adver();
        if (ViewState["id"] != null)
        {
            model = SystemService.AdverService.Get(ViewState["id"]);
            if (model.Code.ToLower() != TbCode.Text.TrimEnd().ToLower())
            {
                if (SystemService.AdverService.Search(express).Count > 0)
                {
                    MessageDiv.InnerHtml = CommonClass.Alert("当前标识已经存在，请重新输入");
                    return;
                }
            }
        }
        else
        {
            if (SystemService.AdverService.Search(express).Count > 0)
            {
                 MessageDiv.InnerHtml = CommonClass.Alert("当前标识已经存在，请重新输入");
                 return;
            }
        }

        model.CategoryId = DDLModel.SelectedValue.ToInt();
        model.Name = TbName.Text.Trim();
        model.Code = TbCode.Text;
        model.AdverType = DDLAdverType.SelectedValue.ToInt();
        model.PicWidth = TbWidth.Text;
        model.PicHeight = TbHeight.Text;
        model.Remark = TbRemark.Text;
        model.OrderBy = TbOrderBy.Text.ToInt();
        model.Creater = AdminUserName;
        model.AddDate = DateTime.Now;
        ISystem_Adver Adver = SystemService.AdverService;
        if (ViewState["id"] == null)
        {
            if (Adver.Insert(model) == 1)
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
            if (Adver.Update(model) == 1)
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
