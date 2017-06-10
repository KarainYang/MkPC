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

using YK.Service;
using YK.Model;
using YK.Common;

public partial class Controls_ProCategory : System.Web.UI.UserControl
{
    /// <summary>
    /// 是否为首页
    /// </summary>
    public bool IsHome { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        IEnumerable<TB_Product_Categorys> list = DataToCacheHelper.GetProductCategory().Where(c => c.ParentID == 0 && c.TypeID == 0);
        if (IsHome == true)
        {
            list = list.Where(c => c.VouchType == 1).OrderBy(c => c.OrderBy);
        }
        RepCategory.DataSource = list;
        RepCategory.DataBind();
    }
    //一级类别绑定
    protected void RepCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int id = ((HiddenField)e.Item.FindControl("HiddenFieldID")).Value.ToInt();      
        Repeater repBrands = (Repeater)e.Item.FindControl("RepBrands");
        repBrands.DataSource = ProductService.BrandsService.GetCategoryVouchBrands(id);
        repBrands.DataBind();

        //List<Expression> express = new List<Expression>();
        //express.Add(new Expression("CategoryId", "=", id.ToStr()));
        //List<TB_Product_CategoryBrand> list = ProductService.CategoryBrandsService.Search(express);
        //string bids = "";
        //foreach (TB_Product_CategoryBrand entity in list)
        //{
        //    bids += entity.BrandId.ToStr() + ",";
        //}
        //bids = bids.TrimEnd(',');
        //if (bids != "")
        //{
        //    List<Expression> express2 = new List<Expression>();
        //    express2.Add(new Expression("id", "in", bids));
        //    Repeater repBrands = (Repeater)e.Item.FindControl("RepBrands");
        //    repBrands.DataSource = ProductService.BrandsService.Search(express2);
        //    repBrands.DataBind();
        //}


        Repeater rep = (Repeater)e.Item.FindControl("RepChildCategory");
        rep.DataSource = DataToCacheHelper.GetProductCategory().Where(m => m.ParentID == id && m.TypeID == 0).OrderBy(m => m.OrderBy);
        rep.DataBind();        
    }
    //二级类别绑定
    protected void RepChildCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int id = ((HiddenField)e.Item.FindControl("HiddenFieldID")).Value.ToInt();
        Repeater rep = (Repeater)e.Item.FindControl("RepChildCategory");
        rep.DataSource = DataToCacheHelper.GetProductCategory().Where(m => m.ParentID == id && m.TypeID == 0).OrderBy(m => m.OrderBy);
        rep.DataBind();
    }
}
