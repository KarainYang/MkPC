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

public partial class Admin_SystemModel_Order_DeleteList : BasePage
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

        TB_Order_Orders order = new TB_Order_Orders();
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("IsDelete", "=", "1"));

        if (Request.QueryString["state"] != null)
        {
            int state = CommonClass.ReturnRequestInt("state", 0);
            expression.Add(new Expression("OrderStateID", "=", state.ToStr()));
        }

        var list = OrderService.OrdersService.Search(pageSize, pageIndex, expression, ref recordCount);

        if (ViewState["StartDate"] != null && ViewState["EndDate"] != null)
        {
            expression.Add(new Expression("OrderDate", ">=", ViewState["StartDate"].ToStr()));
            expression.Add(new Expression("OrderDate", "<=", ViewState["EndDate"].ToStr()));

            list = list.Where(o => o.OrderDate >= Convert.ToDateTime(ViewState["StartDate"]) && o.OrderDate <= Convert.ToDateTime(ViewState["EndDate"])).ToList();
        }

        RepList.DataSource = list;
        RepList.DataBind();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ViewState["StartDate"] = string.IsNullOrEmpty(TbStartDate.Text.Trim()) ? null : TbStartDate.Text.Trim();
        ViewState["EndDate"] = string.IsNullOrEmpty(TbEndDate.Text.Trim()) ? null : TbEndDate.Text.Trim();

        LoadDataBind();
    }


    //分页
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ViewState["PageIndex"] = e.NewPageIndex;
        LoadDataBind();
    }
}
