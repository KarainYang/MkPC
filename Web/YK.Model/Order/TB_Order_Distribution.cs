using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///订单配送信息实体
    /// </summary>
    public class TB_Order_Distribution
    {
        /// <summary> 
        ///订单编号
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary> 
        ///收货人
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary> 
        ///送货方式编号
        /// </summary>
        public int ConsignmentID { get; set; }
        /// <summary> 
        ///付款方式编号
        /// </summary>
        public int PaymentID { get; set; }
        /// <summary> 
        ///送货时间方式，如：不限时间，工作日，双休日
        /// </summary>
        public string RepceiptDateType { get; set; }
        /// <summary> 
        ///自提时间
        /// </summary>
        public string MentionDate { get; set; }
        /// <summary> 
        ///公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary> 
        ///地址
        /// </summary>
        public string Address { get; set; }
        /// <summary> 
        ///邮政编码
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary> 
        ///电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary> 
        ///传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary> 
        ///手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary> 
        ///邮箱
        /// </summary>
        public string Email { get; set; }
    }
}
