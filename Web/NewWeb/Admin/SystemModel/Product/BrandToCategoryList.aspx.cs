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

public partial class Admin_SystemModel_Product_BrandToCategoryList : BasePage
{
    protected List<TB_Product_Categorys> list = new List<TB_Product_Categorys>();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("BrandId", "=", Request["brandId"]));
        var query = ProductService.CategoryBrandsService.Search(express);
        foreach (var item in query)
        {
            list.Add(ProductService.CategoryService.Get(item.CategoryId));
        }
    }
}
