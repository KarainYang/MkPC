using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///类别品牌表
    /// </summary>
    public class TB_Product_CategoryBrand
    {
        /// <summary> 
        ///类别编号
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary> 
        ///品牌编号
        /// </summary>
        public int BrandId { get; set; }
        /// <summary> 
        ///是否推荐
        /// </summary>
        public int VouchType { get; set; }
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
