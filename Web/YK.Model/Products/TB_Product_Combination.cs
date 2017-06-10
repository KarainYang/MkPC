using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///组合商品实体
    /// </summary>
    public class TB_Product_Combination
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///主商品编号
        /// </summary>
        public int MasterProductID { get; set; }
        /// <summary> 
        ///组合商品编号
        /// </summary>
        public string ComProductID { get; set; }
        /// <summary> 
        ///组合价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary> 
        ///折扣
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///是否隐藏
        /// </summary>
        public bool IsHidden { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
