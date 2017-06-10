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

public partial class Admin_AdminModel_Product_CategoryAdverView : BasePage
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
        int proCategoryId = Request["categoryId"].ToInt();
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("ProCategoryId", "=", proCategoryId));
        TB_System_Adver model = SystemService.AdverService.Get(express);

        if (model.ID > 0)
        {
            DDLAdverType.SelectedValue = model.AdverType.ToStr();
            TbWidth.Text = model.PicWidth;
            TbHeight.Text = model.PicHeight;
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {        
        TB_System_Adver model = new TB_System_Adver();
        if (ViewState["id"] != null)
        {
            model.ID = ViewState["id"].ToInt();
        }
        model.ProCategoryId = Request["categoryId"].ToInt();
        model.AdverType = DDLAdverType.SelectedValue.ToInt();
        model.PicWidth = TbWidth.Text;
        model.PicHeight = TbHeight.Text;
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
