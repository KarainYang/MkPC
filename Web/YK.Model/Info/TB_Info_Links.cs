using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///友情连接
    /// </summary>
    public class TB_Info_Links
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///标题
        /// </summary>
        public string Title { get; set; }
        /// <summary> 
        ///图片
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary> 
        ///连接地址
        /// </summary>
        public string Url { get; set; }
        /// <summary> 
        ///是否隐藏
        /// </summary>
        public bool IsHIdden { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
