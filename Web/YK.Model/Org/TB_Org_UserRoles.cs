using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
 
namespace YK.Model
{
    /// <summary> 
    ///组织用户角色
    /// </summary>
    public class TB_Org_UserRoles : CommonProperty
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid ID { get; set; }
        /// <summary> 
        ///用户ID
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary> 
        ///角色ID
        /// </summary>
        public Guid RoleId { get; set; }
    }
}
