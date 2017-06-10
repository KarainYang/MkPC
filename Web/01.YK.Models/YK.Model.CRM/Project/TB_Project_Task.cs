using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///任务管理
    /// </summary>
    public class TB_Project_Task
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
        ///项目编号
        /// </summary>
        public int ProjectID { get; set; }
        /// <summary> 
        ///项目名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary> 
        ///结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary> 
        ///处理人
        /// </summary>
        public int Handler { get; set; }
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
        ///处理状态，0为未处理，1为已处理，2为拒绝，三为重现
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 进度
        /// </summary>
        public int Progress { get; set; }
        /// <summary> 
        ///拒绝原因
        /// </summary>
        public string Reason2 { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
