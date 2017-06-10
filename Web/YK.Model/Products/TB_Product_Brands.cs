using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace YK.Model
{
    /// <summary> 
    ///商品品牌实体
    /// </summary>
    public class TB_Product_Brands
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///类型，0为普通，1为团购
        /// </summary>
        public int TypeID { get; set; }
        /// <summary> 
        ///父类编号
        /// </summary>
        public int ParentID { get; set; }
        /// <summary> 
        ///品牌名称
        /// </summary>
        public string BrandName { get; set; }
        /// <summary> 
        ///图片路径
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary> 
        ///描述
        /// </summary>
        public string Description { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary> 
        ///是否隐藏
        /// </summary>
        public bool IsHidden { get; set; }
        /// <summary> 
        ///是否推荐
        /// </summary>
        public int VouchType { get; set; }
        /// <summary> 
        ///是否删除
        /// </summary>
        public bool IsDelete { get; set; }
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
