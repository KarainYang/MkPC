using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///工作流审批记录
    /// </summary>
    public class TB_WorkFlow_ApprovalRecord
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///审批流标识
        /// </summary>
        public string MainCode { get; set; }
        /// <summary>
        /// 节点ID
        /// </summary>
        public int NodeId { get; set; }
        /// <summary> 
        ///审批对象ID
        /// </summary>
        public int ObjectID { get; set; }
        /// <summary> 
        ///说明
        /// </summary>
        public string Reason { get; set; }
        /// <summary> 
        ///创建人
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
