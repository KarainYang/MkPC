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

public partial class Admin_SystemModel_Product_PropertiesView : BasePage
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
        int categoryId = 0;
        if (!string.IsNullOrEmpty(Request["categoryId"]))
        {
            categoryId = Request["categoryId"].ToInt();
            ProductCategory.CategoryId = categoryId;
        }

        int ID = CommonClass.ReturnRequestInt("id", 0);
        if (ID > 0)
        {
            TB_Product_Properties model = ProductService.PropertiesService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                ProductCategory.CategoryId = model.ProCategoryId;
                TbName.Text = model.PropName;
                DDLPropType.SelectedValue = model.PropType.ToStr();
                TbPropValue.Text = model.PropValue;
                TbDate.Text = model.AddDate.ToString();
                TbOrderBy.Text = model.OrderBy.ToStr();
                ViewState["id"] = model.ID;
            }
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Product_Properties model = new TB_Product_Properties();
         if (ViewState["id"]!=null)
         {
             model = ProductService.PropertiesService.Get(ViewState["id"]);
         }
         model.ProCategoryId = ProductCategory.CategoryId;
         model.PropName = TbName.Text;
         model.PropType = DDLPropType.SelectedValue.ToInt();
         model.OrderBy = TbOrderBy.Text.ToInt();
         model.PropValue = TbPropValue.Text;
         model.Creater = AdminUserName;
         model.AddDate=Convert.ToDateTime(TbDate.Text);

         if (ViewState["id"] == null)
         {
             if (ProductService.PropertiesService.Insert(model) == 1)
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
             if (ProductService.PropertiesService.Update(model) == 1)
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
