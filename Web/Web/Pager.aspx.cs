using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using YK.Common;
using YK.Model;

public partial class Pager : System.Web.UI.Page
{
    protected List<YK.Model.TB_Product_Products> list = new List<YK.Model.TB_Product_Products>();
    protected void Page_Load(object sender, EventArgs e)
    {
        int pageIndex=Request["page"].ToInt();
        pageIndex = pageIndex == 0 ? 1 : pageIndex;

        int recordCount=0;

        list = YK.Service.ProductService.ProductsService.Search(10, pageIndex, new List<Expression>(), ref recordCount);

        PagerDiv.InnerHtml = YK.Common.CommonClass.GetPagerHtml(10, pageIndex, recordCount, 5);

        //PagerDiv.InnerHtml += YK.Common.CommonClass.GetPagerAjaxHtml(Request.Url.ToStr(), 10, pageIndex, recordCount, 5, "PagerDiv");
    }
}
