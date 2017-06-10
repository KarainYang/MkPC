using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///工作报告
    /// </summary>
    public class TB_Employee_WorkStatement
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
        ///类型，0日报、1周报、2月报
        /// </summary>
        public int Type { get; set; }
        /// <summary> 
        ///标题
        /// </summary>
        public string Title { get; set; }
        /// <summary> 
        ///工作总结
        /// </summary>
        public string WorkSummary { get; set; }
        /// <summary> 
        ///工作计划
        /// </summary>
        public string WorkPlan { get; set; }
        /// <summary> 
        ///报告日期
        /// </summary>
        public DateTime StatementDate { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
