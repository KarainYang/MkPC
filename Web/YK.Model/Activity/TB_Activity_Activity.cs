using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
 
namespace YK.Model
{
    /// <summary> 
    ///活动
    /// </summary>
    public class TB_Activity_Activity
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///活动名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///活动类型，1.满x元免运费，2.满x元送x积分,3.满x元打x折，4.满x元送优惠券
        /// </summary>
        public int Type { get; set; }
        /// <summary> 
        ///金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary> 
        ///是否设置时间
        /// </summary>
        public bool IsSetDate { get; set; }
        /// <summary> 
        ///活动开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary> 
        ///结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary> 
        ///活动描述
        /// </summary>
        public string Description { get; set; }
        /// <summary> 
        ///积分
        /// </summary>
        public int Integral { get; set; }
        /// <summary> 
        ///折扣
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary> 
        ///优惠券抵扣金额
        /// </summary>
        public decimal DeductibleAmount { get; set; }
        /// <summary> 
        ///优惠券是否设置时间
        /// </summary>
        public bool CouponIsSetDate { get; set; }
        /// <summary> 
        ///优惠券开始时间
        /// </summary>
        public DateTime CouponStartDate { get; set; }
        /// <summary> 
        ///优惠券结束时间
        /// </summary>
        public DateTime CouponEndDate { get; set; }
        /// <summary> 
        ///是否启用
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
