using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
 
namespace YK.Model
{
    /// <summary> 
    ///广告
    /// </summary>
    public class TB_System_Adver
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///类别编号
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 商品类别编号，用于一级类别对应的广告
        /// </summary>
        public int ProCategoryId { get; set; }
        /// <summary> 
        ///标识
        /// </summary>
        public string Code { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///广告类型，0为单图片广告，1为图片切换广告
        /// </summary>
        public int AdverType { get; set; }
        /// <summary> 
        ///图片宽度
        /// </summary>
        public string PicWidth { get; set; }
        /// <summary> 
        ///图片高度
        /// </summary>
        public string PicHeight { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
