using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///工作流审批
    /// </summary>
    public class TB_WorkFlow_Approval
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///类型，0为员工，1为角色
        /// </summary>
        public int Type { get; set; }
        /// <summary> 
        ///节点ID
        /// </summary>
        public int NodeID { get; set; }
        /// <summary> 
        ///对象ID，员工编号或角色编号
        /// </summary>
        public int ObjectID { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///创建时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
