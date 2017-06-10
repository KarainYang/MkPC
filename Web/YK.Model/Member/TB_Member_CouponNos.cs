using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///优惠券发放表
    /// </summary>
    public class TB_Member_CouponNos
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///优惠券表编号
        /// </summary>
        public int CouponID { get; set; }
        /// <summary> 
        ///会员编号
        /// </summary>
        public int MemberID { get; set; }
        /// <summary> 
        ///优惠券编号
        /// </summary>
        public string CouponNo { get; set; }
        /// <summary> 
        ///抵扣金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary> 
        ///是否已使用
        /// </summary>
        public bool IsUse { get; set; }
        /// <summary> 
        ///发放时间
        /// </summary>
        public DateTime SendDate { get; set; }
    }
}
