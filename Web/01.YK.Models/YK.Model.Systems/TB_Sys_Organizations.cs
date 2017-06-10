using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace YK.Model.Systems
{
    /// <summary> 
    ///组织
    /// </summary>
    public class TB_Sys_Organizations : CommonProperty
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public string ID { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///编码
        /// </summary>
        public string Code { get; set; }
        /// <summary> 
        ///数据库
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary> 
        ///连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary> 
        ///状态
        /// </summary>
        public int State { get; set; }
    }
}
