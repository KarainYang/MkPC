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

public partial class promotion_PassGroupBuy : System.Web.UI.Page
{
    public List<TB_Product_Categorys> categoryList;
    public List<TB_Product_Group> groupBuyList;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind(1);
        }
    }

    public void LoadDataBind(int pageIndex)
    {
        categoryList = DataToCacheHelper.GetProductCategory().Where(m => m.ParentID == 0 && m.TypeID == 1).OrderBy(m => m.OrderBy).ToList();

        int recordCount = 0;
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("IsDelete", "=", "0"));
        express.Add(new Expression("StopDate", "<", DateTime.Now.ToShortDateString()));
        groupBuyList = ProductService.GroupService.Search(AspNetPager1.PageSize, pageIndex, express, "id desc,addDate desc", ref recordCount);
        AspNetPager1.RecordCount = recordCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        LoadDataBind(e.NewPageIndex);
    }

    /// <summary>
    /// 获取产品销售数量
    /// </summary>
    /// <param name="proId"></param>
    /// <returns></returns>
    protected int GetProSum(int proId)
    {
       return OrderService.OrderDetailsService.GetProSalesSum(1, proId).Sum(o => o.Count);
    }
}
