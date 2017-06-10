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

public partial class Controls_ProBrowse : System.Web.UI.UserControl
{
    public List<TB_Product_Products> productList = new List<TB_Product_Products>();
    protected void Page_Load(object sender, EventArgs e)
    {        
        //获取会员信息
        if (Request.Cookies["MemberInfo"] != null)
        {
            int memberID = Request.Cookies["MemberInfo"].Values["ID"].ToInt();

            //添加浏览记录
            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("MemberId", "=", memberID.ToStr()));
            List<TB_Product_BrowerRecord> list = ProductService.BrowerRecordService.Search(5, expression).OrderByDescending(b => b.BrowerDate).ToList();
            foreach (TB_Product_BrowerRecord entity in list)
            {
                productList.Add(ProductService.ProductsService.Get(entity.ProId));
            }
        }
    }
}