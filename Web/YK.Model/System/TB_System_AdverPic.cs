using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///广告图片
    /// </summary>
    public class TB_System_AdverPic
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///广告编号
        /// </summary>
        public int AdverId { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///图片路径
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary> 
        ///连接地址
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary> 
        ///是否隐藏
        /// </summary>
        public bool IsHidden { get; set; }
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
