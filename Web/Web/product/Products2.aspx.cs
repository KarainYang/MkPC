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

public partial class product_Products2 : System.Web.UI.Page
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

}
