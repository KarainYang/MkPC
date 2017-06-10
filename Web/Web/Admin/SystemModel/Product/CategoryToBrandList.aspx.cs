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
using YK.Common;
using YK.Service;

public partial class Admin_SystemModel_Product_CategoryBrandList : BasePage
{
    protected int cid = 0;//类别编号
    protected void Page_Load(object sender, EventArgs e)
    {
        cid = Request.QueryString["cid"].ToInt();

        if (!IsPostBack)
        {
            LoadDataBind();
        }
    }

    //加载所有信息
    public void LoadDataBind()
    {
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("ParentId","=","0"));
        RepList.DataSource = ProductService.BrandsService.Search(express);
        RepList.DataBind();
    }

    protected void RepList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int bid = ((HiddenField)e.Item.FindControl("HiddenFieldID")).Value.ToInt();        

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("CategoryId", "=", cid.ToStr()));
        express.Add(new Expression("BrandId", "=", bid.ToStr()));
        TB_Product_CategoryBrand entity=ProductService.CategoryBrandsService.Get(express);
        if(entity.CategoryId>0)
        {

            ((CheckBox)e.Item.FindControl("CheckBoxChoose")).Checked = true;
            ((CheckBox)e.Item.FindControl("CheckIsVouch")).Checked = entity.VouchType == 0 ? false : true;
            ((TextBox)e.Item.FindControl("TbOrderBy")).Text = entity.OrderBy.ToStr();
        }
    }

    //推荐设置
    protected void ButtonSet_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem ri in RepList.Items)
        {
            CheckBox cb = ((CheckBox)ri.FindControl("CheckBoxChoose"));
            int bid = Convert.ToInt32(((HiddenField)ri.FindControl("HiddenFieldID")).Value);
            int vouchType = ((CheckBox)ri.FindControl("CheckIsVouch")).Checked == true ? 1 : 0;
            int orderBy = ((TextBox)ri.FindControl("TbOrderBy")).Text.ToInt();

            List<Expression> express = new List<Expression>();
            express.Add(new Expression("CategoryId", "=", cid.ToStr()));
            express.Add(new Expression("BrandId", "=", bid.ToStr()));

            if (cb.Checked == true)
            {
                TB_Product_CategoryBrand entity = new TB_Product_CategoryBrand();
                entity.CategoryId = cid;
                entity.BrandId = bid;
                entity.Creater = AdminUserName;
                entity.VouchType = vouchType;
                entity.OrderBy = orderBy;

                if (ProductService.CategoryBrandsService.Search(express).Count == 0)
                {
                    ProductService.CategoryBrandsService.Insert(entity);
                }
                else
                {
                    ProductService.CategoryBrandsService.Update(entity, express);
                }
            }
            else
            {
                ProductService.CategoryBrandsService.Delete(express);
            }
        }
        MessageDiv.InnerHtml = CommonClass.Reload("品牌设置成功");
    }

}
