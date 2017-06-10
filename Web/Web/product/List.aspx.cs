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

public partial class product_List : System.Web.UI.Page
{
    /// <summary>
    /// 会员编号
    /// </summary>
    protected int memberID = 0;
    /// <summary>
    /// 记录数
    /// </summary>
    public int recordCount;

    protected void Page_Load(object sender, EventArgs e)
    {
        //获取会员信息
        if (Request.Cookies["MemberInfo"] != null)
        {
            memberID = Request.Cookies["MemberInfo"].Values["ID"].ToInt();
        }

 
        int page=Request["page"].ToInt();
        page = page == 0 ? 1 : page;

        LoadDataBind(page);            
      
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
        var list = ProductService.ProductsService.Search(12, pageIndex, express, orderByStr, ref recordCount);
        RepList.DataSource = list;
        RepList.DataBind();

        recordCount = recordCount;
        Pages.InnerHtml = YK.Common.CommonClass.GetPagerAjaxHtml(Request.Url.ToStr(), 12, Request["page"].ToInt(), recordCount, 6, "Box");
    }
}
