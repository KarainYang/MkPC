using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///订单实体
    /// </summary>
    public class TB_Order_Orders
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///订单类型，0普通订单，1位团购订单
        /// </summary>
        public int OrderType { get; set; }
        /// <summary> 
        ///订单编号
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary> 
        ///订单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary> 
        ///用户留言
        /// </summary>
        public string BuyerNote { get; set; }
        /// <summary> 
        ///订单状态编号
        /// </summary>
        public int OrderStateID { get; set; }
        /// <summary> 
        ///会员编号
        /// </summary>
        public int MemberID { get; set; }
        /// <summary> 
        ///商品总数
        /// </summary>
        public int ProCount { get; set; }
        /// <summary> 
        ///总价
        /// </summary>
        public decimal MoneySum { get; set; }
        /// <summary> 
        ///购买商品赠送的积分
        /// </summary>
        public int Integral { get; set; }
        /// <summary> 
        ///运费
        /// </summary>
        public decimal Freight { get; set; }
        /// <summary> 
        ///参与活动编号
        /// </summary>
        public string ActivityID { get; set; }
        /// <summary> 
        ///活动描述
        /// </summary>
        public string ActivityDesc { get; set; }
        /// <summary> 
        ///是否开发票，0为不开发票，1为开发票
        /// </summary>
        public int IsInvoice { get; set; }
        /// <summary> 
        ///发票类型
        /// </summary>
        public string InvoiceType { get; set; }
        /// <summary> 
        ///发票抬头
        /// </summary>
        public string InvoiceLookUp { get; set; }
        /// <summary> 
        ///公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary> 
        ///发票内容
        /// </summary>
        public string InvoiceValue { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///语言
        /// </summary>
        public string Langs { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }


        /// <summary>
        /// 客服审核人员
        /// </summary>
        public int Customer { get; set; }

        /// <summary>
        /// 备货员
        /// </summary>
        public int StockingMembers { get; set; }
        /// <summary>
        /// 发货员
        /// </summary>
        public int DeliveryStaff { get; set; }
        /// <summary>
        /// 签收员
        /// </summary>
        public int SignStaff { get; set; }
        /// <summary>
        /// 财务审核人员
        /// </summary>
        public int FinAudStaff { get; set; }
        /// <summary>
        /// 审核，0为未审核，1为通过过审核，2为不通过审核
        /// </summary>
        public int IsPassing { get; set; }
        /// <summary>
        /// 审核不通过原因
        /// </summary>
        public string PassingReason { get; set; }
    }
}
