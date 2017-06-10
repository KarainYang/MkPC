using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace YK.Model
{
    /// <summary> 
    ///退货订单实体
    /// </summary>
    public class TB_ReturnGood_Order
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///会员编号
        /// </summary>
        public int MemberID { get; set; }
        /// <summary> 
        ///类型，0为退货，1为返修
        /// </summary>
        public int Type { get; set; }
        /// <summary> 
        ///订单编号
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary> 
        ///退货订单数量
        /// </summary>
        public int Count { get; set; }
        /// <summary> 
        ///退货订单总金额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///状态，0为申请中，1为通过申请，2为已退款，3为未通过申请
        /// </summary>
        public int State { get; set; }
        /// <summary> 
        ///不通过原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary> 
        ///退货申请日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
