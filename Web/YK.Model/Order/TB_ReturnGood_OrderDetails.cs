using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///退货订单详细实体
    /// </summary>
    public class TB_ReturnGood_OrderDetails
    {
        /// <summary> 
        ///订单编号
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary> 
        ///商品编号
        /// </summary>
        public int ProID { get; set; }
        /// <summary> 
        ///商品名称
        /// </summary>
        public string ProName { get; set; }
        /// <summary> 
        ///单价
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary> 
        ///数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary> 
        ///退货原因
        /// </summary>
        public string Ask { get; set; }
    }
}
