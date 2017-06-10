using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///资源实体
    /// </summary>
    public class TB_Admin_Resources
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///资源名称
        /// </summary>
        public string ResourceName { get; set; }
        /// <summary> 
        ///父级
        /// </summary>
        public int ParentID { get; set; }
        /// <summary> 
        ///路径
        /// </summary>
        public string Url { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }

        /// <summary>
        /// 是否作为导航菜单显示
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// 下级目录
        /// </summary>
        public List<TB_Admin_Resources> ChildTree { get; set; }

    }
}
