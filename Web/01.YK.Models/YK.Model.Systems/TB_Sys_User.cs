using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace YK.Model.Systems
{
    /// <summary> 
    ///系统级用户
    /// </summary>
    public class TB_Sys_User : CommonProperty
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public string ID { get; set; }
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
