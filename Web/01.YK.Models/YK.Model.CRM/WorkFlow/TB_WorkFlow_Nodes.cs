using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///工作流节点表
    /// </summary>
    public class TB_WorkFlow_Nodes
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        /// <summary> 
        ///审批流编码
        /// </summary>
        public string MainCode { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///上级节点
        /// </summary>
        public int PreviousNode { get; set; }
        /// <summary> 
        ///下级节点
        /// </summary>
        public int NextNode { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        public int Type { get; set; }
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
