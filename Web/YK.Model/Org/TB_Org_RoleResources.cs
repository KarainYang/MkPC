using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
 
namespace YK.Model
{
    /// <summary> 
    ///组织角色资源
    /// </summary>
    public class TB_Org_RoleResources : CommonProperty
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid ID { get; set; }
        /// <summary> 
        ///角色ID
        /// </summary>
        public Guid RoleId { get; set; }
        /// <summary> 
        ///资源ID
        /// </summary>
        public Guid ResourceId { get; set; }
    }
}
