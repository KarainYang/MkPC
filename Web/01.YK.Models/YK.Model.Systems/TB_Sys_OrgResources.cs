using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace YK.Model.Systems
{
    /// <summary> 
    ///系统组织资源
    /// </summary>
    public class TB_Sys_OrgResources : CommonProperty
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public string ID { get; set; }
        /// <summary> 
        ///组织ID
        /// </summary>
        public string OrganizationId { get; set; }
        /// <summary> 
        ///资源ID
        /// </summary>
        public string ResourceId { get; set; }
    }
}
