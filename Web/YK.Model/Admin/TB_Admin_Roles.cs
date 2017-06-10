using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
 
namespace YK.Model
{
    /// <summary> 
    ///角色实体
    /// </summary>
    public class TB_Admin_Roles
    {
        /// <summary> 
        ///角色编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///角色名称
        /// </summary>
        public string RoleName { get; set; }
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
    }
}
