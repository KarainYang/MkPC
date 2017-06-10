using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///商品属性实体
    /// </summary>
    public class TB_Product_Properties
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary> 
        ///商品类别编号
        /// </summary>
        public int ProCategoryId { get; set; }

        /// <summary> 
        ///属性名称
        /// </summary>
        public string PropName { get; set; }
        /// <summary> 
        ///属性类型
        /// </summary>
        public int PropType { get; set; }
        /// <summary> 
        ///属性值
        /// </summary>
        public string PropValue { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary> 
        ///语言
        /// </summary>
        public string Langs { get; set; }
    }
}
