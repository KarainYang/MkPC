using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
 
namespace YK.Model
{
    /// <summary> 
    ///优惠券发送表
    /// </summary>
    public class TB_Activity_CouponNos
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///活动编号
        /// </summary>
        public int ActivityID { get; set; }
        /// <summary> 
        ///会员编号
        /// </summary>
        public int MemberID { get; set; }
        /// <summary> 
        ///优惠券编号
        /// </summary>
        public string CouponNo { get; set; }
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
