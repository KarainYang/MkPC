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

public partial class Admin_SystemModel_Order_FinanceAudit : BasePage
{
    public TB_Order_Orders orders = new TB_Order_Orders();
    public TB_Order_Distribution distribution = new TB_Order_Distribution();

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
        DDLPaymentType.DataSource = Dictionaries.GetDictionaries(DictionariesEnum.支付方式);
        DDLPaymentType.DataValueField = "ID";
        DDLPaymentType.DataTextField = "Title";
        DDLPaymentType.DataBind();

        //订单信息
        int id = CommonClass.ReturnRequestInt("id",0);
        orders = OrderService.OrdersService.Get(id);

        if (orders.IsPassing==1)
            RadioPassing.Checked=true;

        if (orders.IsPassing==2)
            RadioNoPassing.Checked=true;

        TbPassingReason.Text = orders.PassingReason;

        //支付信息
        List<Expression> express=new List<Expression>();
        express.Add(new Expression("OrderNumber","=",orders.OrderNumber));
        distribution = OrderService.DistributionService.Get(express);
        DDLPaymentType.SelectedValue = distribution.PaymentID.ToStr();

        RepList.DataSource = OrderService.OrderDetailsService.Search(express);
        RepList.DataBind();

        
    }

     //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int id = CommonClass.ReturnRequestInt("id", 0);
        orders = OrderService.OrdersService.Get(id);
        orders.FinAudStaff = AdminUserID;
        orders.IsPassing = RadioPassing.Checked ? 1 : 2;
        if (orders.IsPassing == 2)
        {
            orders.PassingReason = TbPassingReason.Text;
        }
        else
        {
            orders.PassingReason = "";
        }
        orders.OrderStateID = 5;

        if (OrderService.OrdersService.Update(orders) == 1)
        {
            List<Expression> express = new List<Expression>();
            express.Add(new Expression("OrderNumber", "=", orders.OrderNumber));

            TB_Order_Distribution distribution = OrderService.DistributionService.Get(express);
            distribution.PaymentID = DDLPaymentType.SelectedValue.ToInt();
            OrderService.DistributionService.Update(distribution);

            MessageDiv.InnerHtml = CommonClass.Reload("订单审核成功");
        }
        else
        {
            MessageDiv.InnerHtml = CommonClass.Reload("订单审核失败");
        }
    }
}
