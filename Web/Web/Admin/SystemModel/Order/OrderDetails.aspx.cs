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

public partial class Admin_SystemModel_Order_OrderDetails : BasePage
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
        int id = CommonClass.ReturnRequestInt("id",0);
        orders = OrderService.OrdersService.Get(id);
        List<Expression> express=new List<Expression>();
        express.Add(new Expression("OrderNumber","=",orders.OrderNumber));

        distribution = OrderService.DistributionService.Get(express);

        RepList.DataSource = OrderService.OrderDetailsService.Search(express);
        RepList.DataBind();
    }
}
