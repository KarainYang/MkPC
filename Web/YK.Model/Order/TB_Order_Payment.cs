using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///支付方式实体
    /// </summary>
    public class TB_Order_Payment
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///付款方式
        /// </summary>
        public string PaymentTitle { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string PaymentNote { get; set; }
        /// <summary> 
        ///语言
        /// </summary>
        public string Langs { get; set; }
    }
}
