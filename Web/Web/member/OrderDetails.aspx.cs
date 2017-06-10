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

public partial class member_OrderDetails : MemberBasePage
{
    public TB_Order_Orders orders = new TB_Order_Orders();
    public TB_Order_Distribution distribution = new TB_Order_Distribution();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind();
        }
    }

    //加载所有信息
    public void LoadDataBind()
    {
        string OrderNumber = CommonClass.ReturnRequestStr("OrderNumber");

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("OrderNumber", "=", OrderNumber));

        orders=OrderService.OrdersService.Get(express);

        distribution = OrderService.DistributionService.Get(express);

        RepList.DataSource = OrderService.OrderDetailsService.Search(express);
        RepList.DataBind();
    }
}
