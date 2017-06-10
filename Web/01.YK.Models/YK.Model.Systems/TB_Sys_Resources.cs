using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace YK.Model.Systems
{
    /// <summary> 
    ///系统资源
    /// </summary>
    public class TB_Sys_Resources : CommonProperty
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public string ID { get; set; }
        /// <summary> 
        ///父级
        /// </summary>
        public string ParentID { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///路径
        /// </summary>
        public string Url { get; set; }        
        /// <summary> 
        ///是否作为菜单
        /// </summary>
        public bool IsMenu { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
    }
}
