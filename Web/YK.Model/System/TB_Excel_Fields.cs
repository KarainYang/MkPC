using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///Excel字段实体
    /// </summary>
    public class TB_Excel_Fields
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///模块编号
        /// </summary>
        public int ModelID { get; set; }
        /// <summary> 
        ///字段名称
        /// </summary>
        public string FieldName { get; set; }
        /// <summary> 
        ///中文名称
        /// </summary>
        public string ChineseName { get; set; }
        /// <summary> 
        ///类型，0导出，1为导入
        /// </summary>
        public string Type { get; set; }
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
