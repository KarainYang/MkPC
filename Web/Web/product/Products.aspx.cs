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

public partial class product_Products : System.Web.UI.Page
{
    protected List<TB_Product_Brands> brandList=new List<TB_Product_Brands>();
    protected int memberID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //获取会员信息
        if (Request.Cookies["MemberInfo"] != null)
        {
            memberID = Request.Cookies["MemberInfo"].Values["ID"].ToInt();
        }

        if (!IsPostBack)
        {
            LoadDataBind(1);            
        }

        BindBrands();    
    }

    /// <summary>
    /// 绑定品牌
    /// </summary>
    public void BindBrands()
    {
        int categoryId = CommonClass.ReturnRequestInt("categoryId", 0);
        bool isCategory = false;//是否存在类别
        if (categoryId > 0)
        {
            TB_Product_Categorys entity = ProductService.CategoryService.Get(categoryId);
            if (entity.ID > 0)
            {
                brandList = ProductService.BrandsService.GetCategoryBrands(categoryId);
                isCategory = true;                
            }

        }
        if (!isCategory)
        {
            brandList = ProductService.BrandsService.GetAllVouchBrands(categoryId);
        }    
    }

    public void LoadDataBind(int pageIndex)
    {
        int recordCount = 0;
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("IsDelete", "=", "0"));
        string key = CommonClass.ReturnRequestStr("key"); 
        int min = CommonClass.ReturnRequestInt("min"); 
        int max = CommonClass.ReturnRequestInt("max"); 
        int categoryId = CommonClass.ReturnRequestInt("categoryId");
        int brandId = CommonClass.ReturnRequestInt("brandId");
        string orderBy = CommonClass.ReturnRequestStr("orderBy");

        //搜索关键词
        if (!string.IsNullOrEmpty(key))
        {
            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("KeyWord", "=", key));

            TB_Info_HotSearch model = InfoService.HotSearchService.Get(expression);
            model.KeyWord = key;
            model.AddDate = DateTime.Now;

            //获取会员信息
            if (Request.Cookies["MemberInfo"] != null)
            {
                model.Creater = Request.Cookies["MemberInfo"].Values["MemberName"].ToStr();
            }

            if (model.ID == 0)
            {                
                InfoService.HotSearchService.Insert(model);
            }
            else
            {
                InfoService.HotSearchService.Update(model);
            }
        }

        if (categoryId > 0)
        {
            express.Add(new Expression("CategoryId", "in", ProductService.CategoryService.GetCategoryList(categoryId)));
        }
        if(brandId>0)
        {
            express.Add(new Expression("BrandID", "=",brandId.ToStr()));
        }
        string orderByStr = "id desc,addDate desc";
        if(!string.IsNullOrEmpty(orderBy))
        {
            switch(orderBy)
            {
                case "price":
                    orderByStr = "SalesPrice asc";
                    break;
                case "date":
                    orderByStr = "addDate desc";
                    break;
            }
        }
        if (Request.QueryString["mark"]!=null)
        {
            express.Add(new Expression("Mark", "like", Request.QueryString["mark"]));
        }
        if (max > 0)
        {
            express.Add(new Expression("SalesPrice", ">=", min.ToStr()));
            express.Add(new Expression("SalesPrice", "<", max.ToStr()));
        }
        else
        {
            express.Add(new Expression("SalesPrice", ">=", min.ToStr()));
        }

        RepList.DataSource = ProductService.ProductsService.Search(AspNetPager1.PageSize, pageIndex, express, orderByStr, ref recordCount);
        RepList.DataBind();
        AspNetPager1.RecordCount = recordCount;
        AspNetPager2.RecordCount = recordCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        LoadDataBind(e.NewPageIndex);
    }

    protected void RepList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int proId = e.CommandArgument.ToInt();
        switch (e.CommandName)
        { 
            case "buy":
                Cart.AddCart(proId,1);
                break;
            case "favorites":
                TB_Product_Collection collection=new TB_Product_Collection();
                collection.MemberID=memberID;
                collection.ProductID=proId;
                collection.AddDate=DateTime.Now;
                collection.Url=Request.Url.ToStr();
                ProductService.CollectionService.Insert(collection);             
                break;
            case "balance":
                break;
        }
        Response.Redirect(Request.Url.ToStr());
    }
}
