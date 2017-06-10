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

public partial class member_ReturnGood : MemberBasePage
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
        expression.Add(new Expression("OrderNumber", "=", Request["OrderNumber"]));
        
        List<TB_Order_OrderDetails> list = OrderService.OrderDetailsService.Search(expression);

        RepList.DataSource = list;
        RepList.DataBind();
    }

    protected void RepList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int count = e.CommandArgument.ToInt();
        TextBox tb = (TextBox)e.Item.FindControl("TbCount");
        Label lb = (Label)e.Item.FindControl("LbTooltip");

        if (e.CommandName == "jian")
        {
            if (tb.Text.ToInt() > 1)
            {
                tb.Text = (tb.Text.ToInt() - 1).ToStr();
            }
            else
            {
                lb.Text = "必须大于0";
            }
        }

        if (e.CommandName == "jia")
        {
            if (tb.Text.ToInt() < count - 1)
            {
                tb.Text = (tb.Text.ToInt() + 1).ToStr();
            }
            else
            {
                lb.Text = "必须小于或等于" + count;
            }
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        int count = 0;
        decimal totalAmount = 0;
        foreach(RepeaterItem item in RepList.Items)
        {
            int pid = ((HiddenField)item.FindControl("PID")).Value.ToInt();
            int count2 = ((TextBox)item.FindControl("TbCount")).Text.ToInt();
            CheckBox ck = (CheckBox)item.FindControl("ck");
            if (ck.Checked == true)
            {
                List<Expression> expression = new List<Expression>();
                expression.Add(new Expression("OrderNumber", "=", Request["OrderNumber"]));
                expression.Add(new Expression("ProductID", "=", pid));
                var detials = OrderService.OrderDetailsService.Get(expression);

                TB_ReturnGood_OrderDetails entity = new TB_ReturnGood_OrderDetails();
                entity.OrderNumber = Request["OrderNumber"];
                entity.UnitPrice = detials.Price;
                entity.ProID = detials.ProductID;
                entity.ProName = detials.ProName;
                entity.Quantity = count2;
                OrderService.ReturnGoodOrderDetailsService.Insert(entity);

                count += count2;
                totalAmount += count2 * detials.Price;
            }
        }

        TB_ReturnGood_Order order = new TB_ReturnGood_Order();
        order.MemberID = MemberID;
        order.OrderNumber = Request["OrderNumber"];
        order.Remark = FCKeditor1.Value;
        order.Type = DDLType.SelectedValue.ToInt();
        order.TotalAmount = totalAmount;
        order.Count = count;
        order.AddDate = DateTime.Now;

        OrderService.ReturnGoodOrderService.Insert(order);

        Response.Write("<script>alert('数据提交成功');window.location='ReturnGoodOrders.aspx';</script>");
    }
}
