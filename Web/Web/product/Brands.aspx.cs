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

using YK.Common;
using YK.Service;
using YK.Model;

public partial class product_Brands : System.Web.UI.Page
{
    protected List<TB_Product_Brands> brandList=new List<TB_Product_Brands>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind();            
        }  
    }

    public void LoadDataBind()
    {
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("ParentId", "=", "0"));
        RepCategorys.DataSource = ProductService.CategoryService.Search(express);
        RepCategorys.DataBind();
    }

    public void RepCategorys_ItemDataBind(object sender, RepeaterItemEventArgs e)
    {
       int categoryId= ((HiddenField)e.Item.FindControl("HiddenFieldID")).Value.ToInt();
       Repeater rep = (Repeater)e.Item.FindControl("RepBrands");
       rep.DataSource = ProductService.BrandsService.GetCategoryBrands(categoryId);
       rep.DataBind();

    }
}
