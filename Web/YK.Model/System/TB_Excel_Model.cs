using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///Excel模块实体
    /// </summary>
    public class TB_Excel_Model
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///模块名称
        /// </summary>
        public string ModelName { get; set; }
        /// <summary> 
        ///对应表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
    }
}
