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

public partial class member_Orders : MemberBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind(1);
        }
    }

    protected void LoadDataBind(int pageIndex)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("OrderType", "=", "0"));
        expression.Add(new Expression("MemberID","=",MemberID.ToStr()));
        expression.Add(new Expression("OrderStateID", "=", CommonClass.ReturnRequestInt("state",0).ToStr()));
        
        int recordCount=0;
        List<TB_Order_Orders> list=OrderService.OrdersService.Search(AspNetPager1.PageSize, pageIndex, expression, "OrderDate desc", ref recordCount);

        if (TbKey.Value != "订单编号")
        {
            list = list.Where(o => o.OrderNumber.Contains(TbKey.Value)).ToList();
        }

        RepList.DataSource = list;
        RepList.DataBind();
        AspNetPager1.RecordCount = recordCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        LoadDataBind(e.NewPageIndex);
    }

   
    protected void RepList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        string orderNumber = ((HiddenField)e.Item.FindControl("HiddenFieldOrderNumber")).Value;
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("OrderNumber", "=", orderNumber));

        Repeater rep = (Repeater)e.Item.FindControl("RepDetails");
        rep.DataSource = OrderService.OrderDetailsService.Search(expression);
        rep.DataBind();
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (TbKey.Value != "订单编号")
        {
           LoadDataBind(1);
        }        
    }
}
