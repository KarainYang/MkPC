using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
 
namespace YK.Model
{
    /// <summary> 
    ///组织用户
    /// </summary>
    public class TB_Org_User : CommonProperty
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid ID { get; set; }
        /// <summary> 
        ///组织ID
        /// </summary>
        public Guid OrganizationId { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary> 
        ///密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary> 
        ///状态
        /// </summary>
        public int State { get; set; }
    }
}
