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

public partial class Admin_SystemModel_Report_SalesReport : BasePage
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
        //只显示已销售的订单
        expression.Add(new Expression("OrderStateID", "=", "6"));

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
}
