using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///团购商品实体
    /// </summary>
    public class TB_Product_Group
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///团购名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary> 
        ///图片
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary> 
        ///原价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary> 
        ///团购价
        /// </summary>
        public decimal GroupPrice { get; set; }
        /// <summary> 
        ///团购开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary> 
        ///结束时间
        /// </summary>
        public DateTime StopDate { get; set; }
        /// <summary> 
        ///团购描述
        /// </summary>
        public string GroupDesc { get; set; }
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
