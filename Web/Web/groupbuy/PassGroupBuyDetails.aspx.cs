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

public partial class promotion_PassGroupBuyDetails : System.Web.UI.Page
{
    public TB_Product_Group entity;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = CommonClass.ReturnRequestInt("id",0);
        entity = ProductService.GroupService.Get(id);
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
