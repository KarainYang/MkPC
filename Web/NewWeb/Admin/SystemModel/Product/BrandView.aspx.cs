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

public partial class Admin_SystemModel_Product_BrandView : BasePage
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
        TB_Product_Brands model = new TB_Product_Brands();
        model.ID = CommonClass.ReturnRequestInt("id", 0);        
        if (model.ID.ToInt() > 0)
        {
            model = ProductService.BrandsService.Get(model.ID);
            DDLType.SelectedValue = model.TypeID.ToStr();
            TbName.Text = model.BrandName;
            CheckBoxHidden.Checked = model.IsHidden;
            CheckBoxVouch.Checked = model.VouchType==0?false:true;
            TbOrderBy.Text = model.OrderBy.ToStr();
            ImgUrl.Url = model.PicUrl;
            TbDesc.Text = model.Description;
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Product_Brands model = new TB_Product_Brands();
        if (ViewState["id"] != null)
        {
            model = ProductService.BrandsService.Get(ViewState["id"]);
        }
        model.TypeID = DDLType.SelectedValue.ToInt();
        model.BrandName = TbName.Text.Trim();
        model.IsHidden = CheckBoxHidden.Checked;
        model.VouchType = CheckBoxVouch.Checked == false ? 0 : 1;
        model.PicUrl = ImgUrl.Url;
        model.Description = TbDesc.Text;
        model.ParentID = 0;
        model.Creater = AdminUserName;
        model.AddDate = DateTime.Now;
        IProduct_Brands brandService = ProductService.BrandsService;
        if (ViewState["id"] == null)
        {
            if (brandService.Insert(model) == 1)
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
            if (brandService.Update(model) == 1)
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
