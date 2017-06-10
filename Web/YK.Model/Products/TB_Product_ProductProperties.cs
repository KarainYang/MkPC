using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///商品属性值
    /// </summary>
    public class TB_Product_ProductProperties
    {
        /// <summary> 
        ///商户编号
        /// </summary>
        public int ProId { get; set; }
        /// <summary> 
        ///属性编号
        /// </summary>
        public int PropertieId { get; set; }
        /// <summary> 
        ///值
        /// </summary>
        public string Value { get; set; }
    }
}
