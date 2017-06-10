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

public partial class Admin_SystemModel_Product_GroupView : BasePage
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
            TB_Product_Group model = ProductService.GroupService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                TbName.Text = model.GroupName;
                TbPrice.Text = model.Price.ToStr();
                TbGroupPrice.Text = model.GroupPrice.ToStr();
                TbStartDate.Text = model.StartDate.ToStr();
                TbStopDate.Text = model.StopDate.ToStr();
                ProImg.Url = model.ImgUrl;
                FckDes.Value = model.GroupDesc;
                DDLVouchType.SelectedValue = model.VouchType.ToStr();
                CheckBoxIsHidden.Checked = model.IsHidden;
                TbDate.Text = model.AddDate.ToString();
                TbOrderBy.Text = model.OrderBy.ToStr();
                ViewState["id"] = model.ID;
            }
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Product_Group model = new TB_Product_Group();
         if (ViewState["id"]!=null)
         {
             model = ProductService.GroupService.Get(ViewState["id"]);
         }
         model.GroupName = TbName.Text;
         model.Price = TbPrice.Text.ToDecimal();
         model.GroupPrice = TbGroupPrice.Text.ToDecimal();
         model.StartDate = TbStartDate.Text.ToDateTime();
         model.StopDate = TbStopDate.Text.ToDateTime();
         model.ImgUrl = ProImg.Url;
         model.GroupDesc = FckDes.Value;
         model.VouchType = DDLVouchType.SelectedValue.ToInt();
         model.IsHidden = CheckBoxIsHidden.Checked;
         model.OrderBy = TbOrderBy.Text.ToInt();
         model.AddDate=DateTime.Now;
         model.Creater = AdminUserName;

         if (ViewState["id"] == null)
         {
             if (ProductService.GroupService.Insert(model) == 1)
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
             if (ProductService.GroupService.Update(model) == 1)
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
