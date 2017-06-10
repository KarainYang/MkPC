using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///购物车实体
    /// </summary>
    public class TB_Product_Cart
    {
        /// <summary> 
        ///会员编号
        /// </summary>
        public int MemberID { get; set; }
        /// <summary> 
        ///商品类型,0为普通商品，1为团购商品
        /// </summary>
        public int Type { get; set; }
        /// <summary> 
        ///商品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary> 
        ///商品编号
        /// </summary>
        public string ProNumber { get; set; }
        /// <summary> 
        ///商品名称
        /// </summary>
        public string ProName { get; set; }
        /// <summary> 
        ///商品图片
        /// </summary>
        public string Picture { get; set; }
        /// <summary> 
        ///颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary> 
        ///尺码
        /// </summary>
        public string Size { get; set; }
        /// <summary> 
        ///商品总数
        /// </summary>
        public int Count { get; set; }
        /// <summary> 
        ///商品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary> 
        ///总价
        /// </summary>
        public decimal Total { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
