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

public partial class order_ShoppingCart2 : MemberBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind();
        }
    }

    //加载
    public void LoadDataBind()
    {
        //var list = OrderService.PaymentService.Search();
        ////付款方式
        //foreach (TB_Order_Payment model in list)
        //{
        //    ListItem li = new ListItem();
        //    li.Text = model.PaymentTitle + " " + model.PaymentNote;
        //    li.Value = model.ID.ToString();
        //    RadioBtnPaymentList.Items.Add(li);
        //}

        List<DictionariesEntity> PaymentType = Dictionaries.GetDictionaries(DictionariesEnum.支付方式);
        //付款方式
        foreach (DictionariesEntity entity in PaymentType)
        {
            ListItem li = new ListItem();
            li.Text = entity.Title+" "+entity.Remark;
            li.Value = entity.ID.ToStr();
            RadioBtnPaymentList.Items.Add(li);
        }

        List<DictionariesEntity> ConsigumentType = Dictionaries.GetDictionaries(DictionariesEnum.配送方式);
        ListItem li0 = new ListItem();
        li0.Text = "==请选择==";
        li0.Value = "";
        DDLConsigument.Items.Add(li0);
        //配送方式
        foreach (DictionariesEntity entity in ConsigumentType)
        {
            ListItem li = new ListItem();
            li.Text = entity.Title;
            li.Value = entity.ID.ToStr();
            DDLConsigument.Items.Add(li);
        }

        List<DictionariesEntity> RepceiptDateType = Dictionaries.GetDictionaries(DictionariesEnum.配送时间);
        //配送时间
        foreach (DictionariesEntity entity in RepceiptDateType)
        {
            ListItem li = new ListItem();
            li.Text = entity.Title;
            li.Value = entity.Title;
            DDLRepceiptDateType.Items.Add(li);
        }

        List<DictionariesEntity> InvoiceType = Dictionaries.GetDictionaries(DictionariesEnum.发票类型);
        //发票类型
        foreach (DictionariesEntity entity in InvoiceType)
        {
            ListItem li = new ListItem();
            li.Text = entity.Title;
            li.Value = entity.Title;
            RadioBtnInvoiceType.Items.Add(li);
        }

        List<DictionariesEntity> InvoiceValue = Dictionaries.GetDictionaries(DictionariesEnum.发票内容);
        //发票内容
        foreach (DictionariesEntity entity in InvoiceValue)
        {
            ListItem li = new ListItem();
            li.Text = entity.Title;
            li.Value = entity.Title;
            RadioBtnInvoiceValue.Items.Add(li);
        }

        //绑定购物车
        RepList.DataSource = Cart.GetCart();
        RepList.DataBind();

        IDictionary<string, object> idic =ActivityHelper.GetActivity();

        LbTotalAmount.Text = Cart.GetTotalAmount().ToStr();
        LbRemark.Text = "商品金额：" + Cart.GetTotalAmount().ToStr() +"元," + idic["info"];
    }

    //提交订单
    protected void BtnSubmitOrder_Click(object sender, EventArgs e)
    {
        Random random = new Random();

    gotoBack:
        string OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(1000, 9999);
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("OrderNumber", "=", OrderNumber));
        if (OrderService.OrdersService.Get(express).ID > 0)
        {
            goto gotoBack;
        }

        TB_Order_Orders order = new TB_Order_Orders();
        order.OrderNumber = OrderNumber;
        order.OrderType = 0;
        order.OrderDate = DateTime.Now;
        order.OrderStateID = 0;

        int count = 0;
        decimal priceCount = 0;
        foreach (DataRow dr in Cart.GetCart().Tables[0].Rows)
        {
            count += dr["count"].ToInt();
            priceCount += dr["count"].ToInt() * dr["price"].ToDecimal();
        }
        order.ProCount = count;
        order.MemberID = MemberID;
        order.MoneySum = priceCount;       


        //发票信息
        order.IsInvoice = RadioBtnIsInvoice.SelectedValue.ToInt();
        order.InvoiceType = RadioBtnInvoiceType.SelectedValue;
        order.InvoiceValue = RadioBtnInvoiceValue.SelectedValue;
        order.InvoiceLookUp = RadioButtonListInvoiceLookUp.SelectedValue;
        order.CompanyName = TbCompanyName.Text;
        order.Remark = TbRemark.Text;

        //收货人信息
        TB_Order_Distribution distribution = new TB_Order_Distribution();
        distribution.OrderNumber = OrderNumber;
        distribution.Address = Address.Text + TbAddress.Text;
        distribution.BuyerName = TbName.Text;
        distribution.CompanyName = TbCompanyName.Text;
        distribution.ConsignmentID = DDLConsigument.SelectedValue.ToInt();
        distribution.PaymentID = RadioBtnPaymentList.SelectedValue.ToInt();
        distribution.Phone = TbPhone.Text;
        distribution.PostalCode = TbPostedCode.Text;
        distribution.Mobile = TbMobile.Text;
        distribution.Email = TbEmail.Text;
        distribution.RepceiptDateType = DDLRepceiptDateType.SelectedValue;
        distribution.MentionDate = TbMentionDate.Text;
   

        TB_Member_BuyerInfo buyerInfo = new TB_Member_BuyerInfo();
        buyerInfo.MemberID = MemberID;
        buyerInfo.Zone = Address.Value + "|" + Address.Text;
        buyerInfo.Address = TbAddress.Text;
        buyerInfo.BuyerName = TbName.Text;       
        buyerInfo.Phone = TbPhone.Text;
        buyerInfo.PostalCode = TbPostedCode.Text;
        buyerInfo.Mobile = TbMobile.Text;
        buyerInfo.Email = TbEmail.Text;

        

        if (OrderService.OrdersService.Insert(order) == 1)
        {
            OrderService.DistributionService.Insert(distribution);

            DataSet ds = Cart.GetCart();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TB_Order_OrderDetails details = new TB_Order_OrderDetails();
                details.OrderNumber = OrderNumber;
                details.Type = dr["type"].ToInt();
                details.ProductID = dr["id"].ToInt();
                details.ProName = dr["name"].ToStr();
                details.ProNumber = dr["proNumber"].ToStr();
                details.Count = dr["count"].ToInt();
                details.Price = dr["price"].ToDecimal();
                details.Picture = dr["img"].ToStr();
                details.Total = dr["price"].ToDecimal() * dr["count"].ToInt();

                OrderService.OrderDetailsService.Insert(details);
            }

            MemberService.BuyerInfoService.Insert(buyerInfo);

            Cart.ClearCart();

            Response.Redirect("ShoppingCart3.aspx?OrderNumber="+OrderNumber);
        }       

    }
}
