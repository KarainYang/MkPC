using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///客户拜访/回访
    /// </summary>
    public class TB_Customer_VisitRcord
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///员工编号
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary> 
        ///客户编号
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///处理方式
        /// </summary>
        public int Type { get; set; }
        /// <summary> 
        ///联系人
        /// </summary>
        public string ContractName { get; set; }
        /// <summary> 
        ///电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary> 
        ///拜访时间
        /// </summary>
        public DateTime VisitDate { get; set; }
        /// <summary> 
        ///拜访内容
        /// </summary>
        public string VisitContent { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
