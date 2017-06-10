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

public partial class Admin_SystemModel_Order_OrderList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["PageIndex"] = 1;
            ViewState["search"] = "";
            LoadDataBind();
        }
    }

    //加载所有信息
    public void LoadDataBind()
    {
        int pageSize = AspNetPager1.PageSize;
        int recordCount = 0;
        int pageIndex = ViewState["PageIndex"].ToInt();

        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("IsDelete", "=", "0"));

        int state = CommonClass.ReturnRequestInt("state", 0);
        int next = CommonClass.ReturnRequestInt("next", 0);
        expression.Add(new Expression("OrderStateID", "=", state.ToStr()));
        if (state == 0)
        {
            expression.Add(new Expression("IsPassing", "=", "0"));
        }
        else
        {
                expression.Add(new Expression("IsPassing", "=", "1"));
        }

        if (next > 0)
        {
            expression.Add(new Expression("OrderStateID", "=", next.ToStr()));
            expression.Add(new Expression("or"));
            expression.Add(new Expression("IsPassing", "=", "2"));
        }

        if (ViewState["StartDate"] != null)
        {
            expression.Add(new Expression("OrderDate", ">=", ViewState["StartDate"].ToStr()));
        }

        if (ViewState["EndDate"] != null)
        {
            expression.Add(new Expression("OrderDate", "<=", ViewState["EndDate"].ToStr()));
        }

        var list = OrderService.OrdersService.Search(pageSize, pageIndex, expression,"orderDate desc", ref recordCount);

        RepList.DataSource = list;
        RepList.DataBind();
    }

    //分页
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ViewState["PageIndex"] = e.NewPageIndex;
        LoadDataBind();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ViewState["StartDate"] = string.IsNullOrEmpty(TbStartDate.Text.Trim()) ? null : TbStartDate.Text.Trim();
        ViewState["EndDate"] = string.IsNullOrEmpty(TbEndDate.Text.Trim()) ? null : TbEndDate.Text.Trim();

        LoadDataBind();
    }

    //命令事件
    protected void RepList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = e.CommandArgument.ToInt();
        TB_Order_Orders order = OrderService.OrdersService.Get(id);
        switch (e.CommandName)
        {
            case "delete":
                order.IsDelete = true;
                break;
            case "Stocking":
                order.OrderStateID = 2;
                break;
            case "Ship":
                order.OrderStateID = 3;
                break;
            case "Sign":
                order.OrderStateID = 4;
                break;
            case "Complete":
                order.OrderStateID = 6;
                break;
        }
        OrderService.OrdersService.Update(order);
        LoadDataBind();
    }

    /// <summary>
    /// 修改订单状态
    /// </summary>
    /// <param name="state"></param>
    protected void UpdateOrderState(int state)
    {
        foreach (RepeaterItem item in RepList.Items)
        {
            CheckBox choose = (CheckBox)item.FindControl("CheckBoxChoose");
            if (choose.Checked == true)
            {
                int id = ((HiddenField)item.FindControl("HiddenFieldID")).Value.ToInt();
                TB_Order_Orders entity = OrderService.OrdersService.Get(id);
                if (state != 7)
                {
                    entity.OrderStateID = state;
                }
                else
                {
                    entity.IsDelete = true;
                }
                OrderService.OrdersService.Update(entity);
            }
        }
        LoadDataBind();
    }
}
