using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///新闻类别
    /// </summary>
    public class TB_Info_NewsCategory
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///类别名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string Code { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
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
