using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///类别属性实体
    /// </summary>
    public class TB_Product_CategoryProperties
    {
        /// <summary> 
        ///类别编号
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary> 
        ///属性编号
        /// </summary>
        public int PropertieId { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
    }
}
