using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///角色资源实体
    /// </summary>
    public class TB_Admin_RoleInResources
    {
        /// <summary> 
        ///角色编号
        /// </summary>
        public int RoleID { get; set; }
        /// <summary> 
        ///资源编号
        /// </summary>
        public int ResourceID { get; set; }
    }
}
