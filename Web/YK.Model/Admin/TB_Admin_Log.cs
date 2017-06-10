using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
 
namespace YK.Model
{
    /// <summary> 
    ///操作日志实体
    /// </summary>
    public class TB_Admin_Log
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///操作类型
        /// </summary>
        public string Type { get; set; }
        /// <summary> 
        ///操作者
        /// </summary>
        public string Operator { get; set; }
        /// <summary> 
        ///操作对象编号
        /// </summary>
        public int ObjId { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
