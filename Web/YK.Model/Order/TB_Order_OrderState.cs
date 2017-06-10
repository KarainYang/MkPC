using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///订单状态实体
    /// </summary>
    public class TB_Order_OrderState
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///订单状态
        /// </summary>
        public string OrderStateTitle { get; set; }
        /// <summary> 
        ///下一状态
        /// </summary>
        public int NextState { get; set; }
        /// <summary> 
        ///语言
        /// </summary>
        public string Langs { get; set; }
    }
}
