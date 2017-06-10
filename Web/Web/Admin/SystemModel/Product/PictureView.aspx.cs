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

public partial class Admin_SystemModel_Product_PictureView : BasePage
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
        int ID = CommonClass.ReturnRequestInt("id", 0);
        if (ID > 0)
        {
            TB_Product_Picture model = ProductService.PictureService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                TbName.Text = model.Name;
                Picture.Url = model.PicUrl;
                TbDate.Text = model.AddDate.ToString();
                TbOrderBy.Text = model.OrderBy.ToStr();
                ViewState["id"] = model.ID;
            }
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Product_Picture model = new TB_Product_Picture();
        if (ViewState["id"] != null)
        {
            model = ProductService.PictureService.Get(ViewState["id"]);
        }
        else
        {
            model.ProID = Request["pid"].ToInt();
        }
         model.Name = TbName.Text;
         model.PicUrl = Picture.Url;
         model.OrderBy = TbOrderBy.Text.ToInt();
         model.Creater = AdminUserName;
         model.AddDate=Convert.ToDateTime(TbDate.Text);

         if (ViewState["id"] == null)
         {
             if (ProductService.PictureService.Insert(model) == 1)
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
             model.ID = ViewState["id"].ToInt();
             if (ProductService.PictureService.Update(model) == 1)
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
