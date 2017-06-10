using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///管理员角色实体
    /// </summary>
    public class TB_Admin_UserInRole
    {
        /// <summary> 
        ///管理员编号
        /// </summary>
        public int AdminUserID { get; set; }
        /// <summary> 
        ///角色编号
        /// </summary>
        public int RoleID { get; set; }
    }
}
