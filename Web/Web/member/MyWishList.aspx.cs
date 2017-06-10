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

public partial class member_MyWishList : MemberBasePage
{
    public List<TB_Product_Products> prolist=new List<TB_Product_Products>();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDataBind(1);
    }

    public void LoadDataBind(int pageIndex)
    { 
        List<Expression> expression=new List<Expression>();
        expression.Add(new Expression("MemberID","=",MemberID.ToStr()));
        int recordCount=0;
        List<TB_Product_Collection> list= ProductService.CollectionService.Search(AspNetPager1.PageSize, pageIndex, expression, "AddDate desc", ref recordCount);
        AspNetPager1.RecordCount = recordCount;
        foreach(TB_Product_Collection entity in list)
        {
            prolist.Add(ProductService.ProductsService.Get(entity.ProductID));
        }
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        LoadDataBind(e.NewPageIndex);
    }
    
    protected void BtnAddCart_Click(object sender, EventArgs e)
    {
        string pids = Request["pid"];
        if(!string.IsNullOrEmpty(pids))
        {
            foreach(string id in pids.Split(','))
            {
                Cart.AddCart(id.ToInt(),1);
            }
            Response.Redirect(CommonClass.AppPath + "order/ShoppingCart.aspx");
        }        
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string pids = Request["pid"];
        if(!string.IsNullOrEmpty(pids))
        {
            foreach (string id in pids.Split(','))
            {
                List<Expression> expression = new List<Expression>();
                expression.Add(new Expression("MemberID", "=", MemberID.ToStr()));
                expression.Add(new Expression("ProductID", "=", id));
                ProductService.CollectionService.Delete(expression);
            }
        }
        LoadDataBind(1);
    }
}
