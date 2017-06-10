using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///加班
    /// </summary>
    public class TB_Employee_Overtime
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
        ///标题
        /// </summary>
        public string Title { get; set; }
        /// <summary> 
        ///开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary> 
        ///结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary> 
        ///加班小时
        /// </summary>
        public decimal Hours { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///审批人
        /// </summary>
        public int Approver { get; set; }
        /// <summary> 
        ///是否批准，0为未批，1为批准，2为不批准
        /// </summary>
        public int IsApproval { get; set; }
        /// <summary> 
        ///批准不通过原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime AddDate { get; set; }
    }
}
