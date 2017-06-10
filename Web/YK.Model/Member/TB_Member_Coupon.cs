using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///优惠券表
    /// </summary>
    public class TB_Member_Coupon
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///标题
        /// </summary>
        public string Title { get; set; }
        /// <summary> 
        ///抵扣金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary> 
        ///是否限时
        /// </summary>
        public bool IsSetDate { get; set; }
        /// <summary> 
        ///开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary> 
        ///结束时间
        /// </summary>
        public DateTime StopDate { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
